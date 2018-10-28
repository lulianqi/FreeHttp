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

                    if (nowFiddlerRequsetChange.IsRawReplace)
                    {
                        //using(MemoryStream ms = new MemoryStream(nowFiddlerRequsetChange.HttpRawRequest.GetRawHttpRequest()))
                        //{
                        //}
                        oSession.oRequest.headers = new HTTPRequestHeaders();
                        oSession.RequestMethod = nowFiddlerRequsetChange.HttpRawRequest.RequestMethod;
                        oSession.fullUrl = nowFiddlerRequsetChange.HttpRawRequest.RequestUri;
                        ((Fiddler.HTTPHeaders)(oSession.RequestHeaders)).HTTPVersion = nowFiddlerRequsetChange.HttpRawRequest.RequestVersions;
                        if(nowFiddlerRequsetChange.HttpRawRequest.RequestHeads!=null)
                        {
                            foreach(var tempHead in nowFiddlerRequsetChange.HttpRawRequest.RequestHeads)
                            {
                                oSession.oRequest.headers.Add(tempHead.Key, tempHead.Value);
                            }
                        }
                        oSession.requestBodyBytes = nowFiddlerRequsetChange.HttpRawRequest.RequestEntity;
                    }
                    else
                    {
                        if (nowFiddlerRequsetChange.UriModific != null && nowFiddlerRequsetChange.UriModific.ModificMode!= ContentModificMode.NoChange)
                        {
                            oSession.fullUrl = nowFiddlerRequsetChange.UriModific.GetFinalContent(oSession.fullUrl);
                        }
                        if(nowFiddlerRequsetChange.HeadDelList!=null&&nowFiddlerRequsetChange.HeadDelList.Count>0)
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
                            }
                        }
                        if(nowFiddlerRequsetChange.BodyModific!=null && nowFiddlerRequsetChange.BodyModific.ModificMode!= ContentModificMode.NoChange)
                        {
                            string sourceRequestBody = oSession.GetRequestBodyAsString();
                            oSession.requestBodyBytes = oSession.GetRequestBodyEncoding().GetBytes(nowFiddlerRequsetChange.BodyModific.GetFinalContent(sourceRequestBody));
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
                ListViewItem matchItem = FiddlerSessionHelper.FindMatchTanperRule(oSession, myFreeHttpWindow.ResponseRuleListView);
                if (matchItem != null)
                {
                    if (isSkipTlsHandshake && oSession.RequestMethod == "CONNECT")
                    {
                        return;
                    }

                    myFreeHttpWindow.MarkMatchRule(matchItem);
                    MarkSession(oSession);
                    FiddlerResponseChange nowFiddlerRequsetChange = ((FiddlerResponseChange)matchItem.Tag);

                    if (nowFiddlerRequsetChange.IsRawReplace)
                    {
                        if (!nowFiddlerRequsetChange.IsIsDirectRespons)
                        {
                            using (MemoryStream ms = new MemoryStream(nowFiddlerRequsetChange.HttpRawResponse.GetRawHttpResponse()))
                            {
                                if (!oSession.LoadResponseFromStream(ms, null))
                                {
                                    ShowMes("error to oSession.LoadResponseFromStream");
                                }
                            }
                        }
                    }
                    else
                    {

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

    }
}
