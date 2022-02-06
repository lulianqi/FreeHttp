using FreeHttp.FiddlerHelper;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FreeHttp.FreeHttpControl
{
    public partial class RuleInfoWindow : CBalloon.CBalloonBase
    {

        public RuleInfoWindow(ListViewItem yourListViewItem)
        {
            InitializeComponent();
            //this.Width= System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width/2;
            InnerListViewItem = yourListViewItem;
            timer = new Timer();
            timer.Interval = 200;
            timer.Tick += Timer_Tick;
        }

        public ListViewItem InnerListViewItem { get; private set; }
        Timer timer;
        Rectangle lastListViewItemRectangle;
        bool isLoadRuleComplete = false;
        Point nowLocation = Point.Empty;


        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
        private void LoadRuleInfo(IFiddlerHttpTamper ruleInfo )
        {
            Action<FiddlerRequestChange> GetFiddlerRequestChangeAddition = (nowFiddlerRequestChange) =>
            {
                if ((nowFiddlerRequestChange.ParameterPickList != null && nowFiddlerRequestChange.ParameterPickList.Count > 0) || nowFiddlerRequestChange.IsHasParameter)
                {
                    rtb_ruleInfo.AddRtbStr("Addition ", Color.Red, true, new Font(FontFamily.GenericMonospace, 14));
                    if (nowFiddlerRequestChange.IsHasParameter)
                    {
                        rtb_ruleInfo.AddRtbStr("Has Parameter: ", Color.Blue, false);
                        rtb_ruleInfo.AppendText("true");
                        rtb_ruleInfo.AppendText("\r\n");
                    }
                    if (nowFiddlerRequestChange.ParameterPickList != null && nowFiddlerRequestChange.ParameterPickList.Count > 0)
                    {
                        foreach (var tempRequest in nowFiddlerRequestChange.ParameterPickList)
                        {
                            rtb_ruleInfo.AddRtbStr("Request Parameter Pick: ", Color.Blue, false);
                            rtb_ruleInfo.AppendText(tempRequest.ToString());
                            rtb_ruleInfo.AppendText("\r\n");
                        }
                    }
                }
            };
            Action<FiddlerResponseChange> GetFiddlerResponseChangeAddition = (nowFiddlerResponseChange) =>
            {
                if ((nowFiddlerResponseChange.ParameterPickList != null && nowFiddlerResponseChange.ParameterPickList.Count > 0) || nowFiddlerResponseChange.IsHasParameter || nowFiddlerResponseChange.ResponseLatency > 0)
                {
                    rtb_ruleInfo.AddRtbStr("Addition ", Color.Red, true, new Font(FontFamily.GenericMonospace, 14));
                    if (nowFiddlerResponseChange.IsHasParameter)
                    {
                        rtb_ruleInfo.AddRtbStr("Has Parameter: ", Color.Blue, false);
                        rtb_ruleInfo.AppendText("true");
                        rtb_ruleInfo.AppendText("\r\n");
                    }
                    if (nowFiddlerResponseChange.ResponseLatency > 0)
                    {
                        rtb_ruleInfo.AddRtbStr("ResponseLatency: ", Color.Blue, false);
                        rtb_ruleInfo.AppendText(nowFiddlerResponseChange.ResponseLatency + "ms");
                        rtb_ruleInfo.AppendText("\r\n");
                    }
                    if (nowFiddlerResponseChange.ParameterPickList != null && nowFiddlerResponseChange.ParameterPickList.Count > 0)
                    {
                        foreach (var tempResponse in nowFiddlerResponseChange.ParameterPickList)
                        {
                            rtb_ruleInfo.AddRtbStr("Response Parameter Pick: ", Color.Blue, false);
                            rtb_ruleInfo.AppendText(tempResponse.ToString());
                            rtb_ruleInfo.AppendText("\r\n");
                        }
                    }
                }
            };

            isLoadRuleComplete = false;
            MyControlHelper.SetControlFreeze(rtb_ruleInfo);
            MyControlHelper.SetControlFreeze(this);
            pb_ruleIcon.Image = InnerListViewItem.ImageList.Images[InnerListViewItem.ImageIndex];
            rtb_ruleInfo.Clear();
            rtb_ruleInfo.AddRtbStr("Filter ", Color.Red, true, new Font(FontFamily.GenericMonospace, 14));
            if (ruleInfo.HttpFilter.UriMatch!=null)
            {
                rtb_ruleInfo.AddRtbStr("Uri: ", Color.Blue, false);
                rtb_ruleInfo.AppendText(ruleInfo.HttpFilter.UriMatch.ToString());
                rtb_ruleInfo.AppendText("\r\n");
            }
            if (ruleInfo.HttpFilter.HeadMatch != null && ruleInfo.HttpFilter.HeadMatch.HeadsFilter.Count>0)
            {
                foreach (var tempHeaderFilter in ruleInfo.HttpFilter.HeadMatch.HeadsFilter)
                {
                    rtb_ruleInfo.AddRtbStr("Header: ", Color.Blue, false);
                    rtb_ruleInfo.AppendText(string.Format("{0} [contain] {1}", tempHeaderFilter.Key, tempHeaderFilter.Value));
                    rtb_ruleInfo.AppendText("\r\n");
                }
            }
            if (ruleInfo.HttpFilter.BodyMatch != null)
            {
                rtb_ruleInfo.AddRtbStr("Entity: ", Color.Blue, false);
                rtb_ruleInfo.AppendText(ruleInfo.HttpFilter.BodyMatch.ToString());
                rtb_ruleInfo.AppendText("\r\n");
            }
            rtb_ruleInfo.AddRtbStr("Action ", Color.Red, true, new Font(FontFamily.GenericMonospace, 14));

            switch (ruleInfo.TamperProtocol)
            {
                case TamperProtocalType.Http:
                    if(ruleInfo is FiddlerRequestChange)
                    {
                        lb_ruleId.Text = string.Format("Http Request Tamper Rule {0}", InnerListViewItem.SubItems[0].Text);

                        FiddlerRequestChange nowFiddlerRequestChange = ruleInfo as FiddlerRequestChange;
                        if (nowFiddlerRequestChange.IsRawReplace)
                        {
                            rtb_ruleInfo.AddRtbStr("Request Replace", Color.Blue, true);
                            rtb_ruleInfo.AppendText(nowFiddlerRequestChange.HttpRawRequest.OriginSting);
                            rtb_ruleInfo.AppendText("\r\n");
                        }
                        else
                        {
                            if (nowFiddlerRequestChange.UriModific != null && nowFiddlerRequestChange.UriModific.ModificMode != HttpHelper.ContentModificMode.NoChange)
                            {
                                rtb_ruleInfo.AddRtbStr("Request Uri Modific: ", Color.Blue, false);
                                rtb_ruleInfo.AppendText(nowFiddlerRequestChange.UriModific.ToString());
                                rtb_ruleInfo.AppendText("\r\n");
                            }
                            if (nowFiddlerRequestChange.HeadDelList != null && nowFiddlerRequestChange.HeadDelList.Count > 0)
                            {
                                foreach (var tempHeaderDel in nowFiddlerRequestChange.HeadDelList)
                                {
                                    rtb_ruleInfo.AddRtbStr("Request Head Delete: ", Color.Blue, false);
                                    rtb_ruleInfo.AppendText(tempHeaderDel);
                                }
                            }
                            if (nowFiddlerRequestChange.HeadAddList != null && nowFiddlerRequestChange.HeadAddList.Count > 0)
                            {
                                foreach (var tempHeaderAdd in nowFiddlerRequestChange.HeadAddList)
                                {
                                    rtb_ruleInfo.AddRtbStr("Request Head Add: ", Color.Blue, false);
                                    rtb_ruleInfo.AppendText(tempHeaderAdd);
                                    rtb_ruleInfo.AppendText("\r\n");
                                }
                            }
                            if (nowFiddlerRequestChange.BodyModific != null && nowFiddlerRequestChange.BodyModific.ModificMode != HttpHelper.ContentModificMode.NoChange)
                            {
                                rtb_ruleInfo.AddRtbStr("Request Entity Modific: ", Color.Blue, false);
                                rtb_ruleInfo.AppendText(nowFiddlerRequestChange.BodyModific.ToString());
                                rtb_ruleInfo.AppendText("\r\n");
                            }
                        }
                        GetFiddlerRequestChangeAddition(nowFiddlerRequestChange);
                    }
                    else if(ruleInfo is FiddlerResponseChange)
                    {
                        lb_ruleId.Text = string.Format("Http Response Tamper Rule {0}", InnerListViewItem.SubItems[0].Text);

                        FiddlerResponseChange nowFiddlerResponseChange = ruleInfo as FiddlerResponseChange;
                        if (nowFiddlerResponseChange.IsRawReplace)
                        {
                            rtb_ruleInfo.AddRtbStr("Request Replace", Color.Blue, true);
                            rtb_ruleInfo.AppendText(nowFiddlerResponseChange.HttpRawResponse.OriginSting);
                            rtb_ruleInfo.AppendText("\r\n");
                        }
                        else
                        {
                            if (nowFiddlerResponseChange.HeadDelList != null && nowFiddlerResponseChange.HeadDelList.Count > 0)
                            {
                                foreach (var tempHeaderDel in nowFiddlerResponseChange.HeadDelList)
                                {
                                    rtb_ruleInfo.AddRtbStr("Response Head Delete: ", Color.Blue, false);
                                    rtb_ruleInfo.AppendText(tempHeaderDel);
                                    rtb_ruleInfo.AppendText("\r\n");
                                }
                            }
                            if (nowFiddlerResponseChange.HeadAddList != null && nowFiddlerResponseChange.HeadAddList.Count > 0)
                            {
                                foreach (var tempHeaderAdd in nowFiddlerResponseChange.HeadAddList)
                                {
                                    rtb_ruleInfo.AddRtbStr("Response Head Add: ", Color.Blue, false);
                                    rtb_ruleInfo.AppendText(tempHeaderAdd);
                                    rtb_ruleInfo.AppendText("\r\n");
                                }
                            }
                            if (nowFiddlerResponseChange.BodyModific != null && nowFiddlerResponseChange.BodyModific.ModificMode != HttpHelper.ContentModificMode.NoChange)
                            {
                                rtb_ruleInfo.AddRtbStr("Response Entity Modific: ", Color.Blue, false);
                                rtb_ruleInfo.AppendText(nowFiddlerResponseChange.BodyModific.ToString());
                                rtb_ruleInfo.AppendText("\r\n");
                            }
                        }

                        GetFiddlerResponseChangeAddition(nowFiddlerResponseChange);
                    }
                    break;
                case TamperProtocalType.WebSocket:
                    if (ruleInfo is FiddlerRequestChange)
                    {
                        lb_ruleId.Text = string.Format("Websocket Send Tamper Rule {0}", InnerListViewItem.SubItems[0].Text);

                        FiddlerRequestChange nowFiddlerWebSocketRequestChange = ruleInfo as FiddlerRequestChange;
                        if (nowFiddlerWebSocketRequestChange.BodyModific != null && nowFiddlerWebSocketRequestChange.BodyModific.ModificMode != HttpHelper.ContentModificMode.NoChange)
                        {
                            rtb_ruleInfo.AddRtbStr("Socket Payload Modific: ", Color.Blue, false);
                            rtb_ruleInfo.AppendText(nowFiddlerWebSocketRequestChange.BodyModific.ToString());
                            rtb_ruleInfo.AppendText("\r\n");
                        }
                        GetFiddlerRequestChangeAddition(nowFiddlerWebSocketRequestChange);
                    }
                    else if (ruleInfo is FiddlerResponseChange)
                    {
                        lb_ruleId.Text = string.Format("Websocket Receive Tamper Rule {0}", InnerListViewItem.SubItems[0].Text);

                        FiddlerResponseChange nowFiddlerWebSocketResponseChange = ruleInfo as FiddlerResponseChange;
                        if (nowFiddlerWebSocketResponseChange.BodyModific != null && nowFiddlerWebSocketResponseChange.BodyModific.ModificMode != HttpHelper.ContentModificMode.NoChange)
                        {
                            rtb_ruleInfo.AddRtbStr("Socket Payload Modific: ", Color.Blue, false);
                            rtb_ruleInfo.AppendText(nowFiddlerWebSocketResponseChange.BodyModific.ToString());
                            rtb_ruleInfo.AppendText("\r\n");
                        }
                        GetFiddlerResponseChangeAddition(nowFiddlerWebSocketResponseChange);
                    }

                    break;
                default:
                    break;
            }
            if(!string.IsNullOrEmpty(ruleInfo.HttpFilter.Name))
            {
                lb_ruleId.Text += string.Format(" ({0})", ruleInfo.HttpFilter.Name);
            }
            isLoadRuleComplete = true;
            MyControlHelper.SetControlUnfreeze(rtb_ruleInfo);
            MyControlHelper.SetControlUnfreeze(this);
            if (rtb_ruleInfo.Rtf.EndsWith("\r\n"))
            {
                rtb_ruleInfo.Rtf = rtb_ruleInfo.Rtf.Remove(rtb_ruleInfo.Rtf.Length - 2, 2);
            }
        }

        private void MyCBalloon_Load(object sender, EventArgs e)
        {
            isLoadRuleComplete = false;
            if (InnerListViewItem != null && InnerListViewItem.Tag is IFiddlerHttpTamper)
            {
                IFiddlerHttpTamper nowRule = InnerListViewItem.Tag as IFiddlerHttpTamper;
                LoadRuleInfo(nowRule );
                
                lastListViewItemRectangle = InnerListViewItem.Bounds;
                timer.Start();
            }
            else
            {
                MessageBox.Show("can not find rule data ", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.Close();
            }
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            if(InnerListViewItem==null || InnerListViewItem.ListView==null)
            {
                Close();
                return;
            }
            try
            {
                //Item被折叠后获取Bounds属性会异常
                _ = InnerListViewItem.Bounds;
            }
            catch
            {
                Close();
                return;
            }
            if(lastListViewItemRectangle != InnerListViewItem.Bounds)
            {
                lastListViewItemRectangle = InnerListViewItem.Bounds;
                Form mainForm = this.Owner.Owner;
                int tempFinalY = InnerListViewItem.Bounds.Y;
                if(tempFinalY < 0)
                {
                    tempFinalY = 0;
                }
                else if(tempFinalY> InnerListViewItem.ListView.Height)
                {
                    tempFinalY = InnerListViewItem.ListView.Height;
                }
                Point myPosition = new Point(InnerListViewItem.Bounds.X, tempFinalY);
                myPosition = InnerListViewItem.ListView.PointToScreen(myPosition);
                myPosition = mainForm.PointToClient(myPosition);
                myPosition.Offset(40, 10);
                this.UpdateBalloonPosition(myPosition);
            }
        }

        private void pictureBox_close_Click(object sender, EventArgs e)
        {
            this.Owner.Activate();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            RefreshRuleInfo();
        }

        public void RefreshRuleInfo()
        {
            if (InnerListViewItem == null || InnerListViewItem.ListView == null)
            {
                Close();
                return;
            }
            if (InnerListViewItem.Tag !=null && InnerListViewItem.Tag is IFiddlerHttpTamper)
            {
                IFiddlerHttpTamper nowRule = InnerListViewItem.Tag as IFiddlerHttpTamper;
                LoadRuleInfo(nowRule);
            }
        }
        public new void Close()
        {
            if(timer!=null)
            {
                timer.Stop();
                timer.Dispose();
            }
            InnerListViewItem = null;
            base.Close();
        }

        private void rtb_ruleInfo_ContentsResized(object sender, ContentsResizedEventArgs e)
        {
            var richTextBox = (RichTextBox)sender;
            //    richTextBox.Width = e.NewRectangle.Width;
            int lineheight = richTextBox.Font.Height;
            int nHeight = lineheight;
            if (e.NewRectangle.Height < lineheight)
                nHeight = lineheight;
            else
                nHeight = e.NewRectangle.Height + lineheight;

            richTextBox.Height = nHeight > System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height / 2 ? System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height / 2 : nHeight;

            this.Height = richTextBox.Height + 95;
            this.reSizeMe();
        }

       
    }
}
