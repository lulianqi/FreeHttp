using Fiddler;
using FreeHttp.FreeHttpControl;
using FreeHttp.HttpHelper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

/*******************************************************************************
* Copyright (c) 2018 lulianqi
* All rights reserved.
* 
* 文件名称: 
* 内容摘要: mycllq@hotmail.com
* 
* 历史记录:
* 日	  期:   20181103           创建人: lulianqi [mycllq@hotmail.com]
* 描    述: 创建
*
* 历史记录:
* 日	  期:                      修改:  
* 描    述: 
*******************************************************************************/

[assembly: Fiddler.RequiredVersion("2.3.5.0")]
namespace FreeHttp
{
    
    public class FiddlerFreeHttp : IAutoTamper ,IDisposable
    {
        private bool isOnLoad = false;
        private TabPage tabPage; 
        private FreeHttpWindow myFreeHttpWindow; 

        /// <summary>
        /// the rule will skip tls handshake when it is true
        /// </summary>
        private bool isSkipTlsHandshake = true;

        private void ShowMes(string mes)
        {
            if(!isOnLoad)
            {
                return;
            }
            myFreeHttpWindow.PutInfo(mes);
        }

        private void ShowError(string mes)
        {
            if (!isOnLoad)
            {
                return;
            }
            FiddlerObject.log(mes);
            myFreeHttpWindow.PutError(mes);
        }

        private void AddFiddlerObjectLog(string mes)
        {
            FiddlerObject.log(mes);
        }
        private void SetStatusText(string mes)
        {
            FiddlerObject.StatusText = mes;
        }

        private void MarkSession(Session oSession)
        {
            oSession["ui-backcolor"] = "Khaki";
            oSession["ui-bold"] = "true";
            oSession["ui-color"] = "Indigo";
            oSession.RefreshUI();
        }
        public void OnBeforeUnload()
        {
            SerializableHelper.SerializeRuleList(myFreeHttpWindow.RequestRuleListView, myFreeHttpWindow.ResponseRuleListView);
        }

        /// <summary>
        /// Modific the http request in oSession with your rule
        /// </summary>
        /// <param name="oSession">oSession</param>
        /// <param name="nowFiddlerRequsetChange">FiddlerRequsetChange</param>
        private void ModificSessionRequest(Session oSession, FiddlerRequsetChange nowFiddlerRequsetChange)
        {
            if (nowFiddlerRequsetChange.IsRawReplace)
            {
                ReplaceSessionRequest(oSession, nowFiddlerRequsetChange);
            }
            else
            {
                if (nowFiddlerRequsetChange.UriModific != null && nowFiddlerRequsetChange.UriModific.ModificMode != ContentModificMode.NoChange)
                {
                    oSession.fullUrl = nowFiddlerRequsetChange.UriModific.GetFinalContent(oSession.fullUrl);
                }
                if (nowFiddlerRequsetChange.HeadDelList != null && nowFiddlerRequsetChange.HeadDelList.Count > 0)
                {
                    foreach (var tempDelHead in nowFiddlerRequsetChange.HeadDelList)
                    {
                        oSession.RequestHeaders.Remove(tempDelHead);
                    }
                }
                if (nowFiddlerRequsetChange.HeadAddList != null && nowFiddlerRequsetChange.HeadAddList.Count > 0)
                {
                    foreach (var tempAddHead in nowFiddlerRequsetChange.HeadAddList)
                    {
                        if (tempAddHead.Contains(": "))
                        {
                            oSession.RequestHeaders.Add(tempAddHead.Remove(tempAddHead.IndexOf(": ")), tempAddHead.Substring(tempAddHead.IndexOf(": ") + 2));
                        }
                        else
                        {
                            ShowError(string.Format("error to deal add head string with [{0}]", tempAddHead));
                        }
                    }
                }
                if (nowFiddlerRequsetChange.BodyModific != null && nowFiddlerRequsetChange.BodyModific.ModificMode != ContentModificMode.NoChange)
                {
                    string sourceRequestBody = null;
                    try  //GetRequestBodyAsString may throw exception
                    {
                        //oSession.utilDecodeRequest();
                        sourceRequestBody = oSession.GetRequestBodyAsString();
                    }
                    catch (Exception ex)
                    {
                        ShowError(string.Format("error in GetRequestBodyAsString [{0}]", ex.Message));
                        oSession.utilDecodeRequest();
                        sourceRequestBody = oSession.GetRequestBodyEncoding().GetString(oSession.requestBodyBytes);
                    }
                    finally
                    {
                        //oSession.requestBodyBytes = oSession.GetRequestBodyEncoding().GetBytes(nowFiddlerRequsetChange.BodyModific.GetFinalContent(sourceRequestBody)); // 直接修改内部成员
                        //oSession.ResponseBody = oSession.GetRequestBodyEncoding().GetBytes(nowFiddlerRequsetChange.BodyModific.GetFinalContent(sourceRequestBody)); //修改内部成员 更新Content-Length ，适用于hex数据
                        oSession.utilSetRequestBody(nowFiddlerRequsetChange.BodyModific.GetFinalContent(sourceRequestBody));  //utilSetRequestBody 虽然会自动更新Content-Length 但是会强制使用utf8 ，适用于字符串
                    }
                }
            }
        }

        /// <summary>
        /// Replace the http request in oSession with your rule (it may call by ModificSessionRequest)
        /// </summary>
        /// <param name="oSession">oSession</param>
        /// <param name="nowFiddlerRequsetChange">FiddlerRequsetChange</param>
        private void ReplaceSessionRequest(Session oSession, FiddlerRequsetChange nowFiddlerRequsetChange)
        {
            oSession.oRequest.headers = new HTTPRequestHeaders();
            oSession.RequestMethod = nowFiddlerRequsetChange.HttpRawRequest.RequestMethod;
            oSession.fullUrl = nowFiddlerRequsetChange.HttpRawRequest.RequestUri;
            ((Fiddler.HTTPHeaders)(oSession.RequestHeaders)).HTTPVersion = nowFiddlerRequsetChange.HttpRawRequest.RequestVersions;
            if (nowFiddlerRequsetChange.HttpRawRequest.RequestHeads != null)
            {
                foreach (var tempHead in nowFiddlerRequsetChange.HttpRawRequest.RequestHeads)
                {
                    oSession.oRequest.headers.Add(tempHead.Key, tempHead.Value);
                }
            }
            oSession.requestBodyBytes = nowFiddlerRequsetChange.HttpRawRequest.RequestEntity;
        }

        /// <summary>
        /// Modific the http response in oSession with your rule (if IsRawReplace and  IsIsDirectRespons it will not call ReplaceSessionResponse)
        /// </summary>
        /// <param name="oSession">oSession</param>
        /// <param name="nowFiddlerResponseChange">FiddlerResponseChange</param>
        private void ModificSessionResponse(Session oSession, FiddlerResponseChange nowFiddlerResponseChange)
        {
            if (nowFiddlerResponseChange.IsRawReplace)
            {
                //if IsIsDirectRespons do nothing
                if (!nowFiddlerResponseChange.IsIsDirectRespons)
                {
                    ReplaceSessionResponse(oSession, nowFiddlerResponseChange);
                }
            }
            else
            {
                if (nowFiddlerResponseChange.HeadDelList != null && nowFiddlerResponseChange.HeadDelList.Count > 0)
                {
                    foreach (var tempDelHead in nowFiddlerResponseChange.HeadDelList)
                    {
                        oSession.ResponseHeaders.Remove(tempDelHead);
                    }
                }
                if (nowFiddlerResponseChange.HeadAddList != null && nowFiddlerResponseChange.HeadAddList.Count > 0)
                {
                    foreach (var tempAddHead in nowFiddlerResponseChange.HeadAddList)
                    {
                        if (tempAddHead.Contains(": "))
                        {
                            oSession.ResponseHeaders.Add(tempAddHead.Remove(tempAddHead.IndexOf(": ")), tempAddHead.Substring(tempAddHead.IndexOf(": ") + 2));
                        }
                        else
                        {
                            ShowError(string.Format("error to deal add head string with [{0}]", tempAddHead));
                        }
                    }
                }
                if (nowFiddlerResponseChange.BodyModific != null && nowFiddlerResponseChange.BodyModific.ModificMode != ContentModificMode.NoChange)
                {
                    //you should not change the media data as string
                    string sourceResponseBody = null;
                    try
                    {
                        sourceResponseBody = oSession.GetResponseBodyAsString();
                    }
                    catch (Exception ex)
                    {
                        ShowError(string.Format("error in GetResponseBodyAsString [{0}]", ex.Message));
                        oSession.utilDecodeResponse();
                        sourceResponseBody = oSession.GetResponseBodyEncoding().GetString(oSession.ResponseBody);
                    }
                    finally
                    {
                        oSession.utilSetResponseBody(nowFiddlerResponseChange.BodyModific.GetFinalContent(sourceResponseBody));
                    }

                    //you can use below code to modific the body
                    //oSession.utilDecodeResponse();
                    //oSession.utilReplaceInResponse("","");
                    //oSession.utilDeflateResponse();
                }
            }
        }

        /// <summary>
        /// Replace the http response in oSession with your rule
        /// </summary>
        /// <param name="oSession">oSession</param>
        /// <param name="nowFiddlerResponseChange">FiddlerResponseChange</param>
        private void ReplaceSessionResponse(Session oSession, FiddlerResponseChange nowFiddlerResponseChange)
        {
            using (MemoryStream ms = new MemoryStream(nowFiddlerResponseChange.HttpRawResponse.GetRawHttpResponse()))
            {
                if (!oSession.LoadResponseFromStream(ms, null))
                {
                    ShowError("error to oSession.LoadResponseFromStream");
                    ShowError("try to modific the response");
                    //modific the response
                    oSession.oResponse.headers = new HTTPResponseHeaders();
                    oSession.oResponse.headers.HTTPResponseCode = nowFiddlerResponseChange.HttpRawResponse.ResponseCode;
                    oSession.ResponseHeaders.StatusDescription = nowFiddlerResponseChange.HttpRawResponse.ResponseStatusDescription;
                    ((Fiddler.HTTPHeaders)(oSession.ResponseHeaders)).HTTPVersion = nowFiddlerResponseChange.HttpRawResponse.ResponseVersion;
                    if (nowFiddlerResponseChange.HttpRawResponse.ResponseHeads != null && nowFiddlerResponseChange.HttpRawResponse.ResponseHeads.Count > 0)
                    {
                        foreach (var tempHead in nowFiddlerResponseChange.HttpRawResponse.ResponseHeads)
                        {
                            oSession.oResponse.headers.Add(tempHead.Key, tempHead.Value);
                        }
                    }
                    oSession.responseBodyBytes = nowFiddlerResponseChange.HttpRawResponse.ResponseEntity;
                }
            }
        }
        
        public void OnLoad()
        {
            FiddlerObject.log(string.Format("【FiddlerFreeHttp】:{0}", "OnLoad"));
            if (!isOnLoad)
            {

                tabPage = new TabPage();
                tabPage.Text = "Free Http";
                if (FiddlerApplication.UI.tabsViews.ImageList != null)
                {
                    Image myIco = FreeHttp.Resources.MyResource.freehttpico;
                    FiddlerApplication.UI.tabsViews.ImageList.Images.Add(myIco);
                    tabPage.ImageIndex = FiddlerApplication.UI.tabsViews.ImageList.Images.Count - 1;
                }
                myFreeHttpWindow = new FreeHttpWindow(SerializableHelper.DeserializeRuleList());
                myFreeHttpWindow.OnGetSession += myFreeHttpWindow_OnGetSession;
                myFreeHttpWindow.OnGetSessionRawData += myFreeHttpWindow_OnGetSessionRawData;
                myFreeHttpWindow.Dock = DockStyle.Fill;
                tabPage.Controls.Add(myFreeHttpWindow);
                FiddlerApplication.UI.tabsViews.TabPages.Add(tabPage);
                isOnLoad = true;
            }
        }

        void myFreeHttpWindow_OnGetSessionRawData(object sender, FreeHttpWindow.GetSessionRawDataEventArgs e)
        {
            Session tempSession = Fiddler.FiddlerObject.UI.GetFirstSelectedSession();
            if (tempSession != null)
            {
                StringBuilder sbRawData = new StringBuilder("Get Raw Data\r\n");
                MemoryStream ms = new MemoryStream();
                //tempSession.WriteToStream(SmartAssembly, false);
                tempSession.WriteRequestToStream(true, true, ms);
                ms.Position = 0;
                StreamReader sr = new StreamReader(ms,Encoding.UTF8);
                sbRawData.Append(sr.ReadToEnd());
                sr.Close();
                ms.Close();
 
                if (tempSession.requestBodyBytes != null && tempSession.requestBodyBytes.Length>0)
                {
                    sbRawData.AppendLine(tempSession.GetRequestBodyAsString());
                    sbRawData.Append("\r\n");
                }
                if (e.IsShowResponse && tempSession.bHasResponse)
                {
                    sbRawData.AppendLine(tempSession.ResponseHeaders.ToString());
                    sbRawData.Append("\r\n");
                    if (tempSession.responseBodyBytes != null && tempSession.responseBodyBytes.Length > 0)
                    {
                        sbRawData.AppendLine(tempSession.GetResponseBodyAsString());
                    }
                }
                ShowMes(sbRawData.ToString());
            }
            else
            {
                Fiddler.FiddlerObject.UI.ShowAlert(new frmAlert("STOP", "please select a session", "OK"));
            }
        }

        void myFreeHttpWindow_OnGetSession(object sender, EventArgs e)
        {
            Session tempSession = Fiddler.FiddlerObject.UI.GetFirstSelectedSession();
            if (tempSession != null)
            {
                ShowMes(string.Format("Get http session in {0}",tempSession.fullUrl));
                ((FreeHttpWindow)sender).SetModificSession(tempSession);
            }
            else
            {
                Fiddler.FiddlerObject.UI.ShowAlert(new frmAlert("STOP", "please select a session", "OK"));
            }
        }

        public void AutoTamperRequestAfter(Session oSession)
        {
            //throw new NotImplementedException();

            
        }

        public void AutoTamperRequestBefore(Session oSession)
        {
            if (!isOnLoad)
            {
                return;
            }
            if (myFreeHttpWindow.IsRequestRuleEnable)
            {
                ListViewItem matchItem = FiddlerSessionHelper.FindMatchTanperRule(oSession, myFreeHttpWindow.RequestRuleListView);
                if (matchItem != null)
                {
                    if (isSkipTlsHandshake && oSession.RequestMethod == "CONNECT")
                    {
                        return;
                    }
                    
                    FiddlerRequsetChange nowFiddlerRequsetChange = ((FiddlerRequsetChange)matchItem.Tag);
                    myFreeHttpWindow.MarkMatchRule(matchItem);
                    MarkSession(oSession);
                    ShowMes(string.Format("macth the [requst rule {0}] with {1}",matchItem.SubItems[0].Text,oSession.fullUrl));
                    ModificSessionRequest(oSession, nowFiddlerRequsetChange);
                }
            }

            if (myFreeHttpWindow.IsResponseRuleEnable)
            {
                ListViewItem matchItem = FiddlerSessionHelper.FindMatchTanperRule(oSession, myFreeHttpWindow.ResponseRuleListView);
                if (matchItem != null)
                {
                    if (isSkipTlsHandshake && oSession.RequestMethod == "CONNECT")
                    {
                        return;
                    }

                    FiddlerResponseChange nowFiddlerResponseChange = ((FiddlerResponseChange)matchItem.Tag);

                    if (nowFiddlerResponseChange.IsIsDirectRespons)
                    {
                        myFreeHttpWindow.MarkMatchRule(matchItem);
                        MarkSession(oSession);
                        ShowMes(string.Format("macth the [reponse rule {0}] with {1}", matchItem.SubItems[0].Text, oSession.fullUrl));
                        ReplaceSessionResponse(oSession, nowFiddlerResponseChange);
                        //oSession.state = SessionStates.Done;
                    }
                }
            }
        }

        public void AutoTamperResponseAfter(Session oSession)
        {
            if (!isOnLoad)
            {
                return;
            }
            if (myFreeHttpWindow.IsResponseRuleEnable)
            {
                ListViewItem matchItem = FiddlerSessionHelper.FindMatchTanperRule(oSession, myFreeHttpWindow.ResponseRuleListView);
                if (matchItem != null)
                {
                    if (isSkipTlsHandshake && oSession.RequestMethod == "CONNECT")
                    {
                        return;
                    }
                    FiddlerResponseChange nowFiddlerResponseChange = ((FiddlerResponseChange)matchItem.Tag);
                    if (!(nowFiddlerResponseChange.IsRawReplace && nowFiddlerResponseChange.IsIsDirectRespons))
                    {
                        myFreeHttpWindow.MarkMatchRule(matchItem);
                        MarkSession(oSession);
                        ShowMes(string.Format("macth the [reponse rule {0}] with {1}", matchItem.SubItems[0].Text, oSession.fullUrl));
                        ModificSessionResponse(oSession, nowFiddlerResponseChange);
                    }
                }
            }

        }

        public void AutoTamperResponseBefore(Session oSession)
        {
            //throw new NotImplementedException();
        }

        public void OnBeforeReturningError(Session oSession)
        {
            //throw new NotImplementedException();
        }


        public void Dispose()
        {
            tabPage.Dispose();
            myFreeHttpWindow.Dispose();
        }
    }
}
