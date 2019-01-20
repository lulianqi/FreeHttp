using Fiddler;
using FreeHttp.AutoTest.RunTimeStaticData;
using FreeHttp.FiddlerHelper;
using FreeHttp.FreeHttpControl;
using FreeHttp.HttpHelper;
using FreeHttp.MyHelper;
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

        private void ShowMes(string mes)
        {
            if(!isOnLoad)
            {
                return;
            }
            if (myFreeHttpWindow.InvokeRequired)
            {
                myFreeHttpWindow.BeginInvoke(new Action<string>(myFreeHttpWindow.PutInfo), mes);
            }
            else
            {
                myFreeHttpWindow.PutInfo(mes);
            }
        }

        private void ShowError(string mes)
        {
            if (!isOnLoad)
            {
                return;
            }
            FiddlerObject.log(mes);
            if (myFreeHttpWindow.InvokeRequired)
            {
                myFreeHttpWindow.BeginInvoke(new Action<string>(myFreeHttpWindow.PutError), mes);
            }
            else
            {
                myFreeHttpWindow.PutError(mes);
            }
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
            SerializableHelper.SerializeData<FiddlerModificSettingInfo>(myFreeHttpWindow.ModificSettingInfo, "FreeHttpSetting.xml");
            SerializableHelper.SerializeContractData<ActuatorStaticDataCollection>(myFreeHttpWindow.StaticDataCollection, "FreeHttpStaticDataCollection.xml");
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
                try
                {
                    myFreeHttpWindow = new FreeHttpWindow(SerializableHelper.DeserializeRuleList(), SerializableHelper.DeserializeData<FiddlerModificSettingInfo>("FreeHttpSetting.xml"), SerializableHelper.DeserializeContractData<FreeHttp.AutoTest.RunTimeStaticData.ActuatorStaticDataCollection>("FreeHttpStaticDataCollection.xml"));
                }
                catch(Exception ex)
                {
                    AddFiddlerObjectLog(string.Format("【FiddlerFreeHttp】load configuration fial : {0}", ex.Message));
                }
                finally
                {
                    if(myFreeHttpWindow==null)
                    {
                        myFreeHttpWindow=new FreeHttpWindow(null,null,null);
                    }
                }
                myFreeHttpWindow.OnGetSession += myFreeHttpWindow_OnGetSession;
                myFreeHttpWindow.OnGetSessionRawData += myFreeHttpWindow_OnGetSessionRawData;
                myFreeHttpWindow.Dock = DockStyle.Fill;
                tabPage.Controls.Add(myFreeHttpWindow);
                FiddlerApplication.UI.tabsViews.TabPages.Add(tabPage);
                Fiddler.FiddlerApplication.UI.Deactivate += UI_Deactivate;
                isOnLoad = true;
            }
        }

        void UI_Deactivate(object sender, EventArgs e)
        {
            myFreeHttpWindow.CloseEditRtb();
        }

        void myFreeHttpWindow_OnGetSessionRawData(object sender, FreeHttpWindow.GetSessionRawDataEventArgs e)
        {
            Session tempSession = Fiddler.FiddlerObject.UI.GetFirstSelectedSession();
            if (tempSession != null)
            {
                if (e.IsGetCookies)
                {
                    myFreeHttpWindow.SetClientCookies(tempSession.RequestHeaders["Cookie"]);
                }
                else
                {
                    string tempStr = FiddlerSessionTamper.GetSessionRawData(tempSession, e.IsShowResponse);
                    ShowMes(tempStr == null ? "error session" : string.Format("Get Raw Data\r\n{0}", tempStr));
                    myFreeHttpWindow.ShowOwnerWindow(tempSession.fullUrl, tempStr);
                }
            }
            else
            {
                Fiddler.FiddlerObject.UI.ShowAlert(new frmAlert("STOP", "please select a session", "OK"));
                //((FreeHttpWindow)sender).MarkWarnControl(Fiddler.FiddlerApplication.UI.lvSessions);
                FreeHttpWindow.MarkWarnControl(Fiddler.FiddlerApplication.UI.lvSessions);
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
                //((FreeHttpWindow)sender).MarkWarnControl(Fiddler.FiddlerApplication.UI.Controls[0]);
                FreeHttpWindow.MarkWarnControl(Fiddler.FiddlerApplication.UI.lvSessions);
            }
        }

        public void AutoTamperRequestAfter(Session oSession)
        {
            //throw new NotImplementedException();
            
        }

        public void AutoTamperRequestBefore(Session oSession)
        {

            //if (oSession.HTTPMethodIs("CONNECT") && oSession.HostnameIs("api.map.baidu.com"))
            //{
            //    oSession["x-OverrideSslProtocols"] = "ssl3.0";
            //}
            //oSession.oRequest["AddOrigin"] = "from lijie PC";
            if (!isOnLoad)
            {
                return;
            }
            if (myFreeHttpWindow.IsRequestRuleEnable)
            {
                //IsRequestRuleEnable is more efficient then string comparison (so if not IsRequestRuleEnable the string comparison will not execute)
                if (myFreeHttpWindow.ModificSettingInfo.IsSkipTlsHandshake && oSession.RequestMethod == "CONNECT")
                {
                    return;
                }
                List<ListViewItem> matchItems = FiddlerSessionHelper.FindMatchTanperRule(oSession, myFreeHttpWindow.RequestRuleListView,true);
                if (matchItems != null && matchItems.Count>0)
                {
                    foreach (var matchItem in matchItems)
                    {
                        FiddlerRequsetChange nowFiddlerRequsetChange = ((FiddlerRequsetChange)matchItem.Tag);
                        FreeHttpWindow.MarkMatchRule(matchItem);
                        MarkSession(oSession);
                        ShowMes(string.Format("macth the [requst rule {0}] with {1}", matchItem.SubItems[0].Text, oSession.fullUrl));
                        FiddlerSessionTamper.ModificSessionRequest(oSession, nowFiddlerRequsetChange,ShowError,ShowMes);
                        if(myFreeHttpWindow.ModificSettingInfo.IsOnlyMatchFistTamperRule)
                        {
                            break;
                        }
                    }
                }
            }

            if (myFreeHttpWindow.IsResponseRuleEnable)
            {
                if (myFreeHttpWindow.ModificSettingInfo.IsSkipTlsHandshake && oSession.RequestMethod == "CONNECT")
                {
                    return;
                }
                List<ListViewItem> matchItems = FiddlerSessionHelper.FindMatchTanperRule(oSession, myFreeHttpWindow.ResponseRuleListView,false);
                if (matchItems != null && matchItems.Count>0)
                {
                    foreach (var matchItem in matchItems)
                    {
                        FiddlerResponseChange nowFiddlerResponseChange = ((FiddlerResponseChange)matchItem.Tag);
                        if (nowFiddlerResponseChange.IsIsDirectRespons)
                        {
                            FreeHttpWindow.MarkMatchRule(matchItem);
                            MarkSession(oSession);
                            ShowMes(string.Format("macth the [reponse rule {0}] with {1}", matchItem.SubItems[0].Text, oSession.fullUrl));
                            FiddlerSessionTamper.ReplaceSessionResponse(oSession, nowFiddlerResponseChange,ShowError,ShowMes);
                            //oSession.state = SessionStates.Done;
                            if (myFreeHttpWindow.ModificSettingInfo.IsOnlyMatchFistTamperRule)
                            {
                                break;
                            }
                        }
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
                if (myFreeHttpWindow.ModificSettingInfo.IsSkipTlsHandshake && oSession.RequestMethod == "CONNECT")
                {
                    return;
                }
                List<ListViewItem> matchItems = FiddlerSessionHelper.FindMatchTanperRule(oSession, myFreeHttpWindow.ResponseRuleListView,false);
                if (matchItems != null && matchItems.Count>0)
                {
                    foreach (var matchItem in matchItems)
                    {
                        FiddlerResponseChange nowFiddlerResponseChange = ((FiddlerResponseChange)matchItem.Tag);
                        if (!(nowFiddlerResponseChange.IsRawReplace && nowFiddlerResponseChange.IsIsDirectRespons))
                        {
                            FreeHttpWindow.MarkMatchRule(matchItem);
                            MarkSession(oSession);
                            ShowMes(string.Format("macth the [reponse rule {0}] with {1}", matchItem.SubItems[0].Text, oSession.fullUrl));
                            FiddlerSessionTamper.ModificSessionResponse(oSession, nowFiddlerResponseChange,ShowError,ShowMes);
                        }
                        if (nowFiddlerResponseChange.LesponseLatency > 0)
                        {
                            ShowMes(string.Format("[reponse rule {0}] is modified , now lesponse {1} ms", matchItem.SubItems[0].Text, nowFiddlerResponseChange.LesponseLatency));
                            System.Threading.Thread.Sleep(nowFiddlerResponseChange.LesponseLatency);
                        }
                        if (myFreeHttpWindow.ModificSettingInfo.IsOnlyMatchFistTamperRule)
                        {
                            break;
                        }
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
