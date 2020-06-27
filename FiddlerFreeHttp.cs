using Fiddler;
using FreeHttp.AutoTest.RunTimeStaticData;
using FreeHttp.FiddlerHelper;
using FreeHttp.FreeHttpControl;
using FreeHttp.MyHelper;
using FreeHttp.WebService;
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

    public class FiddlerFreeHttp : IAutoTamper, IDisposable
    {
        private bool isOnLoad = false;                  //是否已经加载过tab
        private bool isCheckedUpdata = false;           //是否已经成功完成更新检查，如果检查失败会被重新设置为false
        private bool isSkipUiHide = false;              //是否跳过匹配被隐藏的session
        private bool isInFreeHttpTab = false;           //是否在正在FreeHttp Tab页中
        private TabPage tabPage;
        private FreeHttpWindow myFreeHttpWindow;
        private UpgradeService upgradeService;
        private OperationReportService operationReportService;

        private void ShowMes(string mes)
        {
            if (!isOnLoad)
            {
                return;
            }
            if (myFreeHttpWindow.InvokeRequired)
            {
                //BeginInvoke,Invoke will execute in the contol ui thread, but Invoke will with the end in the ui thread
                //myFreeHttpWindow.Invoke(new Action(()=>{System.Threading.Thread.Sleep(10000);}) );
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
            AddFiddlerObjectLog(mes);
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
            FiddlerObject.log(string.Format("【FiddlerFreeHttp】:{0}", mes));
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
            SerializableHelper.SerializeData<FiddlerModificSettingInfo>(myFreeHttpWindow.ModificSettingInfo, "FreeHttp\\FreeHttpSetting.xml");
            SerializableHelper.SerializeContractData<ActuatorStaticDataCollection>(myFreeHttpWindow.StaticDataCollection, "FreeHttp\\FreeHttpStaticDataCollection.xml");
            if (isInFreeHttpTab)
            {
                operationReportService.OutOperation(DateTime.Now, myFreeHttpWindow.RequestRuleListView.Items.Count, myFreeHttpWindow.ResponseRuleListView.Items.Count);
            }
            if (operationReportService.HasAnyOperation && myFreeHttpWindow.ModificSettingInfo.IsSkipConnectTunnels)
            {
                operationReportService.FiddlerRequestChangeRuleList = myFreeHttpWindow.FiddlerRequestChangeList;
                operationReportService.FiddlerResponseChangeRuleList = myFreeHttpWindow.FiddlerResponseChangeList;
                operationReportService.StartReportThread();
            }
        }

        public void OnLoad()
        {
            AddFiddlerObjectLog("OnLoad");
            //string workPath = string.Format("{0}\\FreeHttp", System.Windows.Forms.Application.StartupPath);
            string workPath = string.Format("{0}\\FreeHttp", Directory.GetCurrentDirectory());
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
                    if (!Directory.Exists(workPath))
                    {
                        AddFiddlerObjectLog(string.Format("Create working directory {0}", workPath));
                        Directory.CreateDirectory(workPath);
                    }
                    AddFiddlerObjectLog(string.Format("load configuration"));
                    myFreeHttpWindow = new FreeHttpWindow(SerializableHelper.DeserializeRuleList(), SerializableHelper.DeserializeData<FiddlerModificSettingInfo>("FreeHttp\\FreeHttpSetting.xml"), SerializableHelper.DeserializeContractData<FreeHttp.AutoTest.RunTimeStaticData.ActuatorStaticDataCollection>("FreeHttp\\FreeHttpStaticDataCollection.xml"));
                }
                catch (Exception ex)
                {
                    AddFiddlerObjectLog(string.Format("load configuration fial ,{0}", ex.Message));
                }
                finally
                {
                    if (myFreeHttpWindow == null)
                    {
                        myFreeHttpWindow = new FreeHttpWindow(null, null, null);
                    }
                }
                myFreeHttpWindow.OnUpdataFromSession += myFreeHttpWindow_OnUpdataFromSession;
                myFreeHttpWindow.OnGetSessionRawData += myFreeHttpWindow_OnGetSessionRawData;
                myFreeHttpWindow.OnGetSessionEventArgs += MyFreeHttpWindow_OnGetSessionEventArgs;
                myFreeHttpWindow.OnGetSessionSeekHead += myFreeHttpWindow_OnGetSessionSeekHead;
                myFreeHttpWindow.Dock = DockStyle.Fill;
                myFreeHttpWindow.Enter += myFreeHttpWindow_Enter;
                tabPage.Controls.Add(myFreeHttpWindow);
                FiddlerApplication.UI.tabsViews.TabPages.Add(tabPage);
                Fiddler.FiddlerApplication.UI.Deactivate += UI_Deactivate;
                FiddlerApplication.UI.tabsViews.SelectedIndexChanged += tabsViews_SelectedIndexChanged;
                FiddlerApplication.OnWebSocketMessage += FiddlerApplication_OnWebSocketMessage;

                upgradeService = new UpgradeService();
                upgradeService.GetUpgradeMes += upgradeService_GetUpgradeMes;
                operationReportService = new OperationReportService();

                isOnLoad = true;
            }
        }


        void tabsViews_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isCheckedUpdata == false && FiddlerApplication.UI.tabsViews.SelectedTab == tabPage)
            {
                isCheckedUpdata = true;
                upgradeService.StartCheckUpgrade();
                //upgradeService.StartCheckUpgradeThread();
            }

            //operation report
            if (FiddlerApplication.UI.tabsViews.SelectedTab == tabPage)
            {
                isInFreeHttpTab = true;
                operationReportService.InOperation(DateTime.Now);
            }
            else if (isInFreeHttpTab)
            {
                isInFreeHttpTab = false;
                operationReportService.OutOperation(DateTime.Now, myFreeHttpWindow.RequestRuleListView.Items.Count, myFreeHttpWindow.ResponseRuleListView.Items.Count);
            }
        }

        void myFreeHttpWindow_Enter(object sender, EventArgs e)
        {
            //when myFreeHttpWindow is enter do somethings
        }


        void UI_Deactivate(object sender, EventArgs e)
        {
            myFreeHttpWindow.CloseEditRtb();
        }


        private void upgradeService_GetUpgradeMes(object sender, UpgradeService.UpgradeServiceEventArgs e)
        {
            if (e.IsSuccess)
            {
                if (MessageBox.Show("Find new version for [ FreeHttp Plug-in ] \r\nDo you want goto upgrade page to udpade your FreeHttp", "find updata", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    if (string.IsNullOrEmpty(e.UpgradeMes))
                    {
                        MessageBox.Show("UpgradeMes is error");
                        return;
                    }
                    try
                    {
                        System.Diagnostics.Process.Start(e.UpgradeMes);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(string.Format("UpgradeMes is error \r\n{0}", ex.Message));
                        return;
                    }
                }
            }
            else
            {
                isCheckedUpdata = false;
            }
        }
        private void myFreeHttpWindow_OnGetSessionRawData(object sender, FreeHttpWindow.GetSessionRawDataEventArgs e)
        {
            Session tempSession = Fiddler.FiddlerObject.UI.GetFirstSelectedSession();
            if (tempSession == null)
            {
                Fiddler.FiddlerObject.UI.ShowAlert(new frmAlert("STOP", "please select a session", "OK"));
                FreeHttpWindow.MarkWarnControl(Fiddler.FiddlerApplication.UI.lvSessions);
                return;
            }
            switch (e.SessionAction)
            {
                case FreeHttpWindow.GetSessionAction.ShowShowResponse:
                    string tempStr = FiddlerSessionTamper.GetSessionRawData(tempSession, true);
                    ShowMes(tempStr == null ? "error session" : string.Format("Get Raw Data\r\n{0}", tempStr));
                    myFreeHttpWindow.ShowOwnerWindow(tempSession.fullUrl, tempStr);
                    break;
                case FreeHttpWindow.GetSessionAction.SetCookies:
                    myFreeHttpWindow.SetClientAddCookies(tempSession.RequestHeaders["Cookie"]);
                    break;
                case FreeHttpWindow.GetSessionAction.DeleteCookies:
                    myFreeHttpWindow.SetClientDelCookies(tempSession.RequestHeaders["Cookie"]);
                    break;
                default:
                    Fiddler.FiddlerObject.UI.ShowAlert(new frmAlert("STOP", "Not supported this SessionAction", "OK"));
                    break;
            }
        }
        private void MyFreeHttpWindow_OnGetSessionEventArgs(object sender, FreeHttpWindow.GetSessionEventArgs e)
        {
            Session tempSession = Fiddler.FiddlerObject.UI.GetFirstSelectedSession();
            if (tempSession == null)
            {
                e.IsGetSuccess = false;
            }
            else
            {
                e.IsGetSuccess = FiddlerSessionTamper.GetSessionData(tempSession, e);
            }
        }
        private void myFreeHttpWindow_OnGetSessionSeekHead(object sender, FreeHttpWindow.GetSessionSeekHeadEventArgs e)
        {
            Session tempSession = Fiddler.FiddlerObject.UI.GetFirstSelectedSession();
            if (tempSession == null)
            {
                FreeHttpWindow.MarkWarnControl(Fiddler.FiddlerApplication.UI.lvSessions);
            }
            else
            {
                if (e != null && e.ResquestHead.Key != null)
                {
                    //HTTPHeaderItem nowHTTPHeaderItem = tempSession.RequestHeaders.First(hTTPHeaderItem => hTTPHeaderItem.Name == e.ResquestHead.Key);
                    HTTPHeaderItem nowHTTPHeaderItem = tempSession.RequestHeaders.FirstOrDefault(hTTPHeaderItem => hTTPHeaderItem.Name == e.ResquestHead.Key);

                    if (nowHTTPHeaderItem != null)
                    {
                        e.ResquestHead = new KeyValuePair<string, string>(nowHTTPHeaderItem.Name, nowHTTPHeaderItem.Value);
                        e.SeekUri = tempSession.fullUrl;
                    }
                }

                if (e != null && e.ResponseHead.Key != null)
                {
                    HTTPHeaderItem nowHTTPHeaderItem = tempSession.ResponseHeaders.FirstOrDefault(hTTPHeaderItem => hTTPHeaderItem.Name == e.ResponseHead.Key);
                    if (nowHTTPHeaderItem != null)
                    {
                        e.ResponseHead = new KeyValuePair<string, string>(nowHTTPHeaderItem.Name, nowHTTPHeaderItem.Value);
                        e.SeekUri = tempSession.fullUrl;
                    }
                }
            }
        }
        private void myFreeHttpWindow_OnUpdataFromSession(object sender, EventArgs e)
        {
            Session tempSession = Fiddler.FiddlerObject.UI.GetFirstSelectedSession();
            if (tempSession != null)
            {
                ShowMes(string.Format("Get http session in {0}", tempSession.fullUrl));
                ((FreeHttpWindow)sender).SetModificSession(tempSession);
            }
            else
            {
                Fiddler.FiddlerObject.UI.ShowAlert(new frmAlert("STOP", "please select a session", "OK"));
                //((FreeHttpWindow)sender).MarkWarnControl(Fiddler.FiddlerApplication.UI.Controls[0]);
                FreeHttpWindow.MarkWarnControl(Fiddler.FiddlerApplication.UI.lvSessions);
            }
        }

        private void FiddlerApplication_OnWebSocketMessage(object sender, WebSocketMessageEventArgs e)
        {
            //((Bitmap)((Fiddler.Session)sender).ViewItem.ImageList.Images[34]).Save(@"D:\A1.ico", System.Drawing.Imaging.ImageFormat.Icon);
            Session oSession = (Session)sender;
            WebSocketMessage webSocketMessage = e.oWSM;
            if (!isOnLoad)
            {
                return;
            }
            if(webSocketMessage==null)
            {
                AddFiddlerObjectLog("get null WebSocketMessage");
                return;
            }
            if (webSocketMessage.FrameType == WebSocketFrameTypes.Close ||
                webSocketMessage.FrameType == WebSocketFrameTypes.Ping ||
                webSocketMessage.FrameType == WebSocketFrameTypes.Pong ||
                webSocketMessage.FrameType == WebSocketFrameTypes.Reservedx3 ||
                webSocketMessage.FrameType == WebSocketFrameTypes.Reservedx4 ||
                webSocketMessage.FrameType == WebSocketFrameTypes.Reservedx5 ||
                webSocketMessage.FrameType == WebSocketFrameTypes.Reservedx6 ||
                webSocketMessage.FrameType == WebSocketFrameTypes.Reservedx7 ||
                webSocketMessage.FrameType == WebSocketFrameTypes.ReservedxB ||
                webSocketMessage.FrameType == WebSocketFrameTypes.ReservedxC ||
                webSocketMessage.FrameType == WebSocketFrameTypes.ReservedxD ||
                webSocketMessage.FrameType == WebSocketFrameTypes.ReservedxE ||
                webSocketMessage.FrameType == WebSocketFrameTypes.ReservedxF)
            {
                return;
            }
            if ((myFreeHttpWindow.IsRequestRuleEnable && webSocketMessage.IsOutbound)|| (myFreeHttpWindow.IsResponseRuleEnable && !webSocketMessage.IsOutbound))
            {
                if (isSkipUiHide && oSession["ui-hide"] == "true")
                {
                    return;
                }
                if (myFreeHttpWindow.ModificSettingInfo.IsSkipConnectTunnels && oSession.RequestMethod == "CONNECT") 
                {
                    return;
                }
                bool isRequest = webSocketMessage.IsOutbound;
                List<IFiddlerHttpTamper> matchItems = null;
                if(isRequest)
                {
                    matchItems = FiddlerSessionHelper.FindMatchTanperRule(oSession, myFreeHttpWindow.FiddlerRequestChangeList, isRequest, webSocketMessage);
                }
                else
                {
                    //oSession.WriteResponseToStream(new MemoryStream(new Byte[] { 0x81,0x81,0x01,0x41 }), false);
                    //WebSocket ws = oSession.__oTunnel as WebSocket;
                    //ws.listMessages.Add(webSocketMessage);
                    matchItems = FiddlerSessionHelper.FindMatchTanperRule(oSession, myFreeHttpWindow.FiddlerResponseChangeList, isRequest, webSocketMessage);
                }
                if (matchItems != null && matchItems.Count > 0)
                {
                    foreach (var matchItem in matchItems)
                    {
                        ListViewItem tempListViewItem = myFreeHttpWindow.FindListViewItemFromRule(matchItem);
                        FreeHttpWindow.MarkMatchRule(tempListViewItem);
                        MarkSession(oSession);
                        ShowMes(string.Format("macth the [requst rule {0}] with {1}", tempListViewItem.SubItems[0].Text, oSession.fullUrl));
                        FiddlerSessionTamper.ModificWebSocketMessage(oSession, webSocketMessage, matchItem ,isRequest, ShowError, ShowMes);
                        if (!isRequest)
                        {
                            FiddlerResponseChange nowFiddlerResponseChange = ((FiddlerResponseChange)matchItem);
                            if (nowFiddlerResponseChange.LesponseLatency > 0)
                            {
                                ShowMes(string.Format("[reponse rule {0}] is modified , now delay {1} ms", tempListViewItem.SubItems[0].Text, nowFiddlerResponseChange.LesponseLatency));
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
                if (isSkipUiHide && oSession["ui-hide"] == "true")
                {
                    return;
                }
                if (myFreeHttpWindow.ModificSettingInfo.IsSkipConnectTunnels && oSession.RequestMethod == "CONNECT")
                {
                    return;
                }
                List<IFiddlerHttpTamper> matchItems = FiddlerSessionHelper.FindMatchTanperRule(oSession, myFreeHttpWindow.FiddlerRequestChangeList,true);
                if (matchItems != null && matchItems.Count>0)
                {
                    foreach (var matchItem in matchItems)
                    {
                        FiddlerRequestChange nowFiddlerRequsetChange = ((FiddlerRequestChange)matchItem);
                        ListViewItem tempListViewItem = myFreeHttpWindow.FindListViewItemFromRule(matchItem);
                        FreeHttpWindow.MarkMatchRule(tempListViewItem);
                        MarkSession(oSession);
                        ShowMes(string.Format("macth the [requst rule {0}] with {1}", tempListViewItem.SubItems[0].Text, oSession.fullUrl));
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
                if (myFreeHttpWindow.ModificSettingInfo.IsSkipConnectTunnels && oSession.RequestMethod == "CONNECT")
                {
                    return;
                }
                List<IFiddlerHttpTamper> matchItems = FiddlerSessionHelper.FindMatchTanperRule(oSession, myFreeHttpWindow.FiddlerResponseChangeList,false);
                if (matchItems != null && matchItems.Count>0)
                {
                    oSession.bBufferResponse = true;//  if any response rule may match the Session, we should set bBufferResponse true (When streaming is enabled for a response, each block of data read from the server is immediately passed to the client application. )
                    foreach (var matchItem in matchItems)
                    {
                        FiddlerResponseChange nowFiddlerResponseChange = ((FiddlerResponseChange)matchItem);
                        ListViewItem tempListViewItem = myFreeHttpWindow.FindListViewItemFromRule(matchItem);
                        if (nowFiddlerResponseChange.IsIsDirectRespons)
                        {
                            FreeHttpWindow.MarkMatchRule(tempListViewItem);
                            MarkSession(oSession);
                            ShowMes(string.Format("macth the [reponse rule {0}] with {1}", tempListViewItem.SubItems[0].Text, oSession.fullUrl));
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
                if (isSkipUiHide && oSession["ui-hide"] == "true")
                {
                    return;
                }
                if (myFreeHttpWindow.ModificSettingInfo.IsSkipConnectTunnels && oSession.RequestMethod == "CONNECT")
                {
                    return;
                }
                List<IFiddlerHttpTamper> matchItems = FiddlerSessionHelper.FindMatchTanperRule(oSession, myFreeHttpWindow.FiddlerResponseChangeList,false);
                if (matchItems != null && matchItems.Count>0)
                {
                    foreach (var matchItem in matchItems)
                    {
                        FiddlerResponseChange nowFiddlerResponseChange = ((FiddlerResponseChange)matchItem);
                        ListViewItem tempListViewItem = myFreeHttpWindow.FindListViewItemFromRule(matchItem);
                        if (!(nowFiddlerResponseChange.IsRawReplace && nowFiddlerResponseChange.IsIsDirectRespons))
                        {
                            FreeHttpWindow.MarkMatchRule(tempListViewItem);
                            MarkSession(oSession);
                            ShowMes(string.Format("macth the [reponse rule {0}] with {1}", tempListViewItem.SubItems[0].Text, oSession.fullUrl));
                            FiddlerSessionTamper.ModificSessionResponse(oSession, nowFiddlerResponseChange,ShowError,ShowMes);
                        }
                        if (nowFiddlerResponseChange.LesponseLatency > 0)
                        {
                            ShowMes(string.Format("[reponse rule {0}] is modified , now delay {1} ms", tempListViewItem.SubItems[0].Text, nowFiddlerResponseChange.LesponseLatency));
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
            this.AutoTamperResponseAfter(oSession);
        }


        public void Dispose()
        {
            tabPage.Dispose();
            myFreeHttpWindow.Dispose();
        }
    }
}
