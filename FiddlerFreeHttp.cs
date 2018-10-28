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


[assembly: Fiddler.RequiredVersion("2.3.5.0")]
namespace FreeHttp
{
    
    public class FiddlerFreeHttp : IAutoTamper
    {
        private bool isOnLoad = false;
        private TabPage tabPage; //创建插件的选项卡页
        private FreeHttpWindow myFreeHttpWindow; //MyControl自定义控件

        private bool isSkipTlsHandshake = true;

        private void ShowMes(string mes)
        {
            string mesStr = string.Format("【{0}】:{1}", DateTime.Now.ToString(), mes);
            FiddlerObject.log(mesStr);
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
                            ShowMes(string.Format("error to deal add head string with [{0}]", tempAddHead));
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
                        ShowMes(string.Format("error in GetRequestBodyAsString [{0}]", ex.Message));
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

        private void ModificSessionResponse(Session oSession, FiddlerResponseChange nowFiddlerResponseChange)
        {
            if (nowFiddlerResponseChange.IsRawReplace)
            {
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
                            ShowMes(string.Format("error to deal add head string with [{0}]", tempAddHead));
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
                        ShowMes(string.Format("error in GetResponseBodyAsString [{0}]", ex.Message));
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

        private void ReplaceSessionResponse(Session oSession, FiddlerResponseChange nowFiddlerResponseChange)
        {
            using (MemoryStream ms = new MemoryStream(nowFiddlerResponseChange.HttpRawResponse.GetRawHttpResponse()))
            {
                if (!oSession.LoadResponseFromStream(ms, null))
                {
                    ShowMes("error to oSession.LoadResponseFromStream");
                    ShowMes("try to modific the response");
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
                myFreeHttpWindow.Dock = DockStyle.Fill;
                tabPage.Controls.Add(myFreeHttpWindow);
                FiddlerApplication.UI.tabsViews.TabPages.Add(tabPage);
                isOnLoad = true;
            }
        }

        void myFreeHttpWindow_OnGetSession(object sender, EventArgs e)
        {
            Session tempSession = Fiddler.FiddlerObject.UI.GetFirstSelectedSession();
            if (tempSession != null)
            {
                myFreeHttpWindow.SetModificSession(tempSession);
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
                    myFreeHttpWindow.MarkMatchRule(matchItem);
                    MarkSession(oSession);
                    FiddlerRequsetChange nowFiddlerRequsetChange = ((FiddlerRequsetChange)matchItem.Tag);

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

                    myFreeHttpWindow.MarkMatchRule(matchItem);
                    MarkSession(oSession);
                    FiddlerResponseChange nowFiddlerResponseChange = ((FiddlerResponseChange)matchItem.Tag);

                    if (nowFiddlerResponseChange.IsIsDirectRespons)
                    {
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

                    myFreeHttpWindow.MarkMatchRule(matchItem);
                    MarkSession(oSession);
                    FiddlerResponseChange nowFiddlerResponseChange = ((FiddlerResponseChange)matchItem.Tag);

                    ModificSessionResponse(oSession, nowFiddlerResponseChange);
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

    }
}
