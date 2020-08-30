using FreeHttp.FiddlerHelper;
using System;
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
            myListViewItem = yourListViewItem;
            timer = new Timer();
            timer.Interval = 200;
            timer.Tick += Timer_Tick;
        }

        

        //RichTextBox rtb_errorList = new RichTextBox();
        //rtb_errorList.AppendText("test");
        //rtb_errorList.Dock = DockStyle.Fill;
        //this.Controls.Add(rtb_errorList);

        ListViewItem myListViewItem;
        Timer timer;
        Rectangle lastListViewItemRectangle;
        Point nowLocation = Point.Empty;


        private void analyzeCaseData()
        {
            //System.Drawing.Image myBit = Image.FromFile(@"D:/123.png", false);
            //Bitmap myBit = Resources.MyResource.show;
            //Graphics GraphicsMyg = rtb_Content.CreateGraphics();
            //GraphicsMyg.DrawImage(myBit,0, 0, myBit.Width/10, myBit.Height/10);
            //GraphicsMyg.ResetTransform();
        }

        private void LoadRuleInfo(IFiddlerHttpTamper ruleInfo )
        {
            pb_ruleIcon.Image = myListViewItem.ImageList.Images[myListViewItem.ImageIndex];
            rtb_filter.AddRtbStr("Filter ", Color.Red, true, new Font(FontFamily.GenericMonospace, 14));
            if (ruleInfo.HttpFilter.UriMatch!=null)
            {
                rtb_filter.AddRtbStr("Uri: ", Color.Blue, false);
                rtb_filter.AppendText(ruleInfo.HttpFilter.UriMatch.ToString());
                rtb_filter.AppendText("\r\n");
            }
            if (ruleInfo.HttpFilter.HeadMatch != null && ruleInfo.HttpFilter.HeadMatch.HeadsFilter.Count>0)
            {
                foreach (var tempHeaderFilter in ruleInfo.HttpFilter.HeadMatch.HeadsFilter)
                {
                    rtb_filter.AddRtbStr("Header: ", Color.Blue, false);
                    rtb_filter.AppendText(string.Format("{0} [contain] {1}", tempHeaderFilter.Key, tempHeaderFilter.Value));
                    rtb_filter.AppendText("\r\n");
                }
            }
            if (ruleInfo.HttpFilter.BodyMatch != null)
            {
                rtb_filter.AddRtbStr("Entity: ", Color.Blue, false);
                rtb_filter.AppendText(ruleInfo.HttpFilter.BodyMatch.ToString());
                rtb_filter.AppendText("\r\n");
            }
            rtb_filter.AddRtbStr("Action ", Color.Red, true, new Font(FontFamily.GenericMonospace, 14));

            switch (ruleInfo.TamperProtocol)
            {
                case TamperProtocalType.Http:
                    if(ruleInfo is FiddlerRequestChange)
                    {
                        lb_ruleId.Text = string.Format("Http Request Tamper Rule {0}", myListViewItem.SubItems[0].Text);

                        FiddlerRequestChange nowFiddlerRequestChange = ruleInfo as FiddlerRequestChange;
                        if (nowFiddlerRequestChange.IsRawReplace)
                        {
                            rtb_filter.AddRtbStr("Request Replace", Color.Blue, true);
                            rtb_filter.AppendText(nowFiddlerRequestChange.HttpRawRequest.OriginSting);
                            rtb_filter.AppendText("\r\n");
                        }
                        else
                        {
                            if (nowFiddlerRequestChange.UriModific != null && nowFiddlerRequestChange.UriModific.ModificMode != HttpHelper.ContentModificMode.NoChange)
                            {
                                rtb_filter.AddRtbStr("Request Uri Modific: ", Color.Blue, false);
                                rtb_filter.AppendText(nowFiddlerRequestChange.UriModific.ToString());
                                rtb_filter.AppendText("\r\n");
                            }
                            if (nowFiddlerRequestChange.HeadDelList != null && nowFiddlerRequestChange.HeadDelList.Count > 0)
                            {
                                foreach (var tempHeaderDel in nowFiddlerRequestChange.HeadDelList)
                                {
                                    rtb_filter.AddRtbStr("Request Head Delete: ", Color.Blue, false);
                                    rtb_filter.AppendText(tempHeaderDel);
                                }
                            }
                            if (nowFiddlerRequestChange.HeadAddList != null && nowFiddlerRequestChange.HeadAddList.Count > 0)
                            {
                                foreach (var tempHeaderAdd in nowFiddlerRequestChange.HeadAddList)
                                {
                                    rtb_filter.AddRtbStr("Request Head Add: ", Color.Blue, false);
                                    rtb_filter.AppendText(tempHeaderAdd);
                                    rtb_filter.AppendText("\r\n");
                                }
                            }
                            if (nowFiddlerRequestChange.BodyModific != null && nowFiddlerRequestChange.BodyModific.ModificMode != HttpHelper.ContentModificMode.NoChange)
                            {
                                rtb_filter.AddRtbStr("Request Entity Modific: ", Color.Blue, false);
                                rtb_filter.AppendText(nowFiddlerRequestChange.BodyModific.ToString());
                                rtb_filter.AppendText("\r\n");
                            }
                        }
                    }
                    else if(ruleInfo is FiddlerResponseChange)
                    {
                        lb_ruleId.Text = string.Format("Http Response Tamper Rule {0}", myListViewItem.SubItems[0].Text);

                        FiddlerResponseChange nowFiddlerResponseChange = ruleInfo as FiddlerResponseChange;
                        if (nowFiddlerResponseChange.IsRawReplace)
                        {
                            rtb_filter.AddRtbStr("Request Replace", Color.Blue, true);
                            rtb_filter.AppendText(nowFiddlerResponseChange.HttpRawResponse.OriginSting);
                            rtb_filter.AppendText("\r\n");
                        }
                        else
                        {
                            if (nowFiddlerResponseChange.HeadDelList != null && nowFiddlerResponseChange.HeadDelList.Count > 0)
                            {
                                foreach (var tempHeaderDel in nowFiddlerResponseChange.HeadDelList)
                                {
                                    rtb_filter.AddRtbStr("Response Head Delete: ", Color.Blue, false);
                                    rtb_filter.AppendText(tempHeaderDel);
                                }
                            }
                            if (nowFiddlerResponseChange.HeadAddList != null && nowFiddlerResponseChange.HeadAddList.Count > 0)
                            {
                                foreach (var tempHeaderAdd in nowFiddlerResponseChange.HeadAddList)
                                {
                                    rtb_filter.AddRtbStr("Response Head Add: ", Color.Blue, false);
                                    rtb_filter.AppendText(tempHeaderAdd);
                                    rtb_filter.AppendText("\r\n");
                                }
                            }
                            if (nowFiddlerResponseChange.BodyModific != null && nowFiddlerResponseChange.BodyModific.ModificMode != HttpHelper.ContentModificMode.NoChange)
                            {
                                rtb_filter.AddRtbStr("Response Entity Modific: ", Color.Blue, false);
                                rtb_filter.AppendText(nowFiddlerResponseChange.BodyModific.ToString());
                                rtb_filter.AppendText("\r\n");
                            }
                        }
                    }
                    break;
                case TamperProtocalType.WebSocket:
                    if (ruleInfo is FiddlerRequestChange)
                    {
                        lb_ruleId.Text = string.Format("Websocket Send Tamper Rule {0}", myListViewItem.SubItems[0].Text);

                        FiddlerRequestChange nowFiddlerWebSocketRequestChange = ruleInfo as FiddlerRequestChange;
                        if (nowFiddlerWebSocketRequestChange.BodyModific != null && nowFiddlerWebSocketRequestChange.BodyModific.ModificMode != HttpHelper.ContentModificMode.NoChange)
                        {
                            rtb_filter.AddRtbStr("Socket Payload Modific: ", Color.Blue, false);
                            rtb_filter.AppendText(nowFiddlerWebSocketRequestChange.BodyModific.ToString());
                            rtb_filter.AppendText("\r\n");
                        }
                    }
                    else if (ruleInfo is FiddlerResponseChange)
                    {
                        lb_ruleId.Text = string.Format("Websocket Receive Tamper Rule {0}", myListViewItem.SubItems[0].Text);

                        FiddlerResponseChange nowFiddlerWebSocketRequestChange = ruleInfo as FiddlerResponseChange;
                        if (nowFiddlerWebSocketRequestChange.BodyModific != null && nowFiddlerWebSocketRequestChange.BodyModific.ModificMode != HttpHelper.ContentModificMode.NoChange)
                        {
                            rtb_filter.AddRtbStr("Socket Payload Modific: ", Color.Blue, false);
                            rtb_filter.AppendText(nowFiddlerWebSocketRequestChange.BodyModific.ToString());
                            rtb_filter.AppendText("\r\n");
                        }
                    }

                    break;
                default:
                    break;
            }
            if(!string.IsNullOrEmpty(ruleInfo.HttpFilter.Name))
            {
                lb_ruleId.Text += string.Format(" ({0})", ruleInfo.HttpFilter.Name);
            }
                  
        }

        private void MyCBalloon_Load(object sender, EventArgs e)
        {
            if (myListViewItem != null && myListViewItem.Tag is IFiddlerHttpTamper)
            {
                IFiddlerHttpTamper nowRule = myListViewItem.Tag as IFiddlerHttpTamper;
                LoadRuleInfo(nowRule );
                lastListViewItemRectangle = myListViewItem.Bounds;
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
            if(myListViewItem==null || myListViewItem.ListView==null)
            {
                Close();
                return;
            }
            if(lastListViewItemRectangle != myListViewItem.Bounds)
            {
                lastListViewItemRectangle = myListViewItem.Bounds;
                Form mainForm = this.Owner.Owner;
                Point myPosition = new Point(myListViewItem.Bounds.X, myListViewItem.Bounds.Y);
                myPosition = myListViewItem.ListView.PointToScreen(myPosition);
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

        public void RefreshRuleInfo()
        {
            if (myListViewItem != null && myListViewItem.Tag is IFiddlerHttpTamper)
            {
                IFiddlerHttpTamper nowRule = myListViewItem.Tag as IFiddlerHttpTamper;
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
            myListViewItem = null;
            //this.Dispose();
            base.Close();
        }


    }
}
