using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using FreeHttp.HttpHelper;

namespace FreeHttp.FreeHttpControl
{
    public partial class FreeHttpWindow : UserControl
    {
        public FreeHttpWindow()
        {
            InitializeComponent();
            //this.DoubleBuffered = true;
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();
        }

        public event EventHandler OnGetSession;

        bool isRequestRuleEnable;
        bool isResponseRuleEnable;

        private void FreeHttpWindow_Load(object sender, EventArgs e)
        {
            foreach(Control contor in this.Controls)
            {
                
            }

            cb_macthMode.SelectedIndex = 0;
        }




        #region Inner Function
        private bool IsRequestReplaceRawMode
        {
            get { return !panel_requestReplace_startLine.Visible; }
        }

        private void ChangeEditRuleMode(int modeId ,string mes)
        {
            switch (modeId)
            {
                case 1:
                    lb_editRuleMode.Text = "New Mode";
                    pictureBox_editRuleMode.Image = FreeHttp.Resources.MyResource.add_mode;
                    break;
                case 2:
                    lb_editRuleMode.Text = string.Format("Edit {0}", mes);
                    pictureBox_editRuleMode.Image = FreeHttp.Resources.MyResource.add_mode;
                    break;
                default:
                    break;
            }
        }
        
        private FiddlerUriMatch GetUriMatch()
        {
            FiddlerUriMatchMode matchMode = FiddlerUriMatchMode.AllPass;
            if (!Enum.TryParse<FiddlerUriMatchMode>(cb_macthMode.Text, out matchMode))
            {
                throw new Exception("get error FiddlerUriMatchMode");
            }
            return new FiddlerUriMatch(matchMode, tb_urlFilter.Text);
        }

        private FiddlerRequsetChange GetRequestModificInfo()
        {
            FiddlerRequsetChange requsetChange = new FiddlerRequsetChange();
            requsetChange.HttpRawRequest = null;
            requsetChange.UriMatch = GetUriMatch();
            requsetChange.UriModific = new ContentModific(tb_requestModific_uriModificKey.Text, tb_requestModific_uriModificValue.Text);
            if (requestRemoveHeads.ListDataView.Items.Count>0)
            {
                requsetChange.HeadDelList = new List<string>();
                foreach(ListViewItem tempRequestRemoveHead in requestRemoveHeads.ListDataView.Items)
                {
                    requsetChange.HeadDelList.Add(tempRequestRemoveHead.Text);
                }
            }
            if (requestAddHeads.ListDataView.Items.Count > 0)
            {
                requsetChange.HeadAddList = new List<string>();
                foreach (ListViewItem tempRequestAddHead in requestAddHeads.ListDataView.Items)
                {
                    requsetChange.HeadAddList.Add(tempRequestAddHead.Text);
                }
            }
            requsetChange.BodyModific = new ContentModific(tb_requestModific_body.Text, rtb_requestModific_body.Text);
            return requsetChange;
        }

        private FiddlerRequsetChange GetRequestReplaceInfo()
        {
            FiddlerRequsetChange requsetReplace = new FiddlerRequsetChange();
            requsetReplace.UriMatch = GetUriMatch();
            if (IsRequestReplaceRawMode)
            {
                requsetReplace.HttpRawRequest = HttpRequest.GetHttpRequest(rtb_requestRaw.Text.Replace("\n", "\r\n"));
            }
            else
            {
                requsetReplace.HttpRawRequest = new HttpRequest();
                requsetReplace.HttpRawRequest.RequestMethod = cb_editRequestMethod.Text;
                requsetReplace.HttpRawRequest.RequestUri = tb_requestReplace_uri.Text;
                requsetReplace.HttpRawRequest.RequestVersions = cb_editRequestEdition.Text;
                requsetReplace.HttpRawRequest.RequestLine = string.Format("{0} {1} {2}", cb_editRequestMethod.Text, tb_requestReplace_uri.Text, cb_editRequestEdition.Text);

                requsetReplace.HttpRawRequest.RequestHeads = new List<KeyValuePair<string, string>>();
                if (elv_requsetReplace.ListDataView.Items.Count > 0)
                {
                    foreach (ListViewItem item in elv_requsetReplace.ListDataView.Items)
                    {
                        string headStr = item.Text;
                        if (headStr.Contains(": "))
                        {
                            string key = headStr.Remove(headStr.IndexOf(": "));
                            string value = headStr.Substring(headStr.IndexOf(": ") + 2);
                            requsetReplace.HttpRawRequest.RequestHeads.Add(new KeyValuePair<string, string>(key, value));
                        }
                        else
                        {
                            throw new Exception(string.Format("find eror head with {0}", headStr));
                        }
                    }
                }

                string tempRequstBody = rtb_requsetReplace_body.Text;
                if (tempRequstBody.StartsWith("\n<<replace file path>>"))
                {
                    string tempPath = tempRequstBody.Remove(0, 22);
                    if (File.Exists(tempPath))
                    {
                        using (FileStream fileStream = new FileStream(tempPath, FileMode.Open, FileAccess.Read, FileShare.Read))
                        {
                            if (fileStream.Length > int.MaxValue)
                            {
                                throw new Exception(string.Format("your file path in  ResponseEntity is too  large with {0}", tempPath));
                            }
                            requsetReplace.HttpRawRequest.RequestEntity = new byte[fileStream.Length];
                            fileStream.Position = 0;
                            fileStream.Read(requsetReplace.HttpRawRequest.RequestEntity, 0, requsetReplace.HttpRawRequest.RequestEntity.Length);
                        }

                    }
                    else
                    {
                        throw new Exception(string.Format("your file path in  ResponseEntity is not Exists with {0}", tempPath));
                    }
                }
                else
                {
                    requsetReplace.HttpRawRequest.RequestEntity = Encoding.UTF8.GetBytes(tempRequstBody);
                }
            }

            if (antoContentLengthToolStripMenuItem.Checked)
            {
                //if (requsetReplace.HttpRawRequest.RequestEntity != null){}
                List<KeyValuePair<string, string>> mvKvpList = new List<KeyValuePair<string, string>>();
                foreach(KeyValuePair<string, string> kvp in requsetReplace.HttpRawRequest.RequestHeads)
                {
                    if(kvp.Key=="Content-Length")
                    {
                        mvKvpList.Add(kvp);
                    }
                }
                if(mvKvpList.Count>0)
                {
                    foreach (KeyValuePair<string, string> kvp in mvKvpList)
                    {
                        requsetReplace.HttpRawRequest.RequestHeads.Remove(kvp);
                    }
                }
                requsetReplace.HttpRawRequest.RequestHeads.Add(new KeyValuePair<string, string>("Content-Length", requsetReplace.HttpRawRequest.RequestEntity == null ? "0" : requsetReplace.HttpRawRequest.RequestEntity.Length.ToString()));
            }

            return requsetReplace;
        }

        private FiddlerResponseChange GetResponseModificInfo()
        {
            FiddlerResponseChange responseChange = new FiddlerResponseChange();
            responseChange.HttpRawResponse = null;
            responseChange.UriMatch = GetUriMatch();
            if (responseRemoveHeads.ListDataView.Items.Count > 0)
            {
                responseChange.HeadDelList = new List<string>();
                foreach (ListViewItem tempRequestRemoveHead in responseRemoveHeads.ListDataView.Items)
                {
                    responseChange.HeadDelList.Add(tempRequestRemoveHead.Text);
                }
            }
            if (responseAddHeads.ListDataView.Items.Count > 0)
            {
                responseChange.HeadAddList = new List<string>();
                foreach (ListViewItem tempRequestAddHead in responseAddHeads.ListDataView.Items)
                {
                    responseChange.HeadAddList.Add(tempRequestAddHead.Text);
                }
            }
            responseChange.BodyModific = new ContentModific(tb_responseModific_body.Text, rtb_reponseModific_body.Text);
            return responseChange;
        }

        private FiddlerResponseChange GetResponseReplaceInfo()
        {
            FiddlerResponseChange responseChange = new FiddlerResponseChange();
            responseChange.UriMatch = GetUriMatch();
            responseChange.HttpRawResponse = rawResponseEdit.GetHttpResponse();
            responseChange.IsIsDirectRespons = rawResponseEdit.IsDirectRespons;
            return responseChange;
        }

        #endregion

        #region Public Function
        
        public void SetModificSession(Fiddler.Session session)
        {
            tb_urlFilter.Text = session.fullUrl;
            cb_macthMode.SelectedIndex = 2;

            //Request Replace
            tb_requestReplace_uri.Text = session.fullUrl;
            cb_editRequestEdition.Text = ((Fiddler.HTTPHeaders)(session.oRequest.headers)).HTTPVersion;
            cb_editRequestMethod.Text = session.RequestMethod;
            elv_requsetReplace.ListDataView.Items.Clear();
            foreach(var tempHead in session.RequestHeaders)
            {
                elv_requsetReplace.ListDataView.Items.Add(String.Format("{0}: {1}",tempHead.Name,tempHead.Value));
            }
            rtb_requsetReplace_body.Clear();
            if(session.requestBodyBytes!=null)
            {
                if(session.requestBodyBytes.Length>0)
                {
                    //Encoding tempRequestEncoding = session.GetRequestBodyEncoding() == null ? Encoding.UTF8 : session.GetRequestBodyEncoding();
                    //rtb_requsetReplace_body.Text = tempRequestEncoding.GetString(session.requestBodyBytes);
                    rtb_requsetReplace_body.Text = session.GetRequestBodyAsString();
                }
            }
            MemoryStream tempRequestStream = new MemoryStream();
            if (session.WriteRequestToStream(false, true, true, tempRequestStream))
            {
                byte[] tempRequestBytes = new byte[tempRequestStream.Length];
                tempRequestBytes = tempRequestStream.ToArray();
                //tempRequestStream.ReadAsync(tempRequestBytes, 0, (int)tempRequestStream.Length);
                //tempRequestStream.Position=0;
                //tempRequestStream.Read(tempRequestBytes, 0, (int)tempRequestStream.Length);
                rtb_requestRaw.Clear();
                rtb_requestRaw.Text = Encoding.UTF8.GetString(tempRequestBytes);
            }
            else
            {
                rtb_requestRaw.Clear();
                rtb_requestRaw.Text = "read RequestStream fail";
            }
            tempRequestStream.Close();

            //Response Replace

            MemoryStream tempReponseStream = new MemoryStream();
            if (session.WriteResponseToStream(tempReponseStream,false))
            {
                byte[] tempResponseBytes = new byte[tempReponseStream.Length];
                tempResponseBytes = tempReponseStream.ToArray();
                rawResponseEdit.SetText(Encoding.UTF8.GetString(tempResponseBytes));
            }
            else
            {
                rawResponseEdit.SetText("read ResponseStream fail");
            }
            tempReponseStream.Close();
        }

        #endregion

        #region Public Event

        private void pb_getSession_Click(object sender, EventArgs e)
        {
            if(OnGetSession!=null)
            {
                this.OnGetSession(this, null);
            }
        }

        private void addFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            object sourceControl = ((ContextMenuStrip)(((ToolStripMenuItem)sender).Owner)).SourceControl;
            RichTextBox tempRtb = null;
            if (sourceControl == rtb_requsetReplace_body)
            {
                tempRtb = rtb_requsetReplace_body;
            }

            if (openFileDialog_addFIle.ShowDialog() == DialogResult.OK)
            {
                string tempPath = openFileDialog_addFIle.FileName;
                int tempIndex = tempRtb.Text.IndexOf("<<replace file path>>");
                if (tempIndex >= 0)
                {
                    tempRtb.Text = tempRtb.Text.Remove(tempIndex);
                }

                if (!tempRtb.Text.EndsWith("\n"))
                {
                    tempRtb.AppendText("\n");
                }

                tempRtb.AppendText(string.Format("<<replace file path>>{0}", tempPath));
            }

            
        }

        private void antoContentLengthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            antoContentLengthToolStripMenuItem.Checked = !antoContentLengthToolStripMenuItem.Checked;
        }

        private void pb_ruleComfrim_Click(object sender, EventArgs e)
        {
            FiddlerRequsetChange nowRequestChange = null;
            FiddlerResponseChange nowResponseChange = null;
            IFiddlerHttpTamper fiddlerHttpTamper = null;
            ListView tamperRuleListView = null;
            try
            {
                switch (tabControl_Modific.SelectedIndex)
                {
                    case 0:
                        nowRequestChange = GetRequestModificInfo();
                        break;
                    case 1:
                        nowRequestChange = GetRequestReplaceInfo();
                        break;
                    case 2:
                        nowResponseChange = GetResponseModificInfo();
                        break;
                    case 3:
                        nowResponseChange = GetResponseReplaceInfo();
                        break;
                    default:
                        throw new Exception("unknow http tamper tab");
                        //break;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Stop",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                nowRequestChange = null;
                nowResponseChange = null;
            }
            finally
            {
                if (nowRequestChange != null)
                {
                    fiddlerHttpTamper = nowRequestChange;
                    tamperRuleListView = lv_requestRuleList;
                }
                else if (nowResponseChange != null)
                {
                    fiddlerHttpTamper = nowResponseChange;
                    tamperRuleListView = lv_responseRuleList;
                }
            }

            if (fiddlerHttpTamper == null)
            {
                return;
            }

            ListViewItem nowRuleItem = new ListViewItem(new string[] { (tamperRuleListView.Items.Count + 1).ToString(), string.Format("【{0}】: {1}", fiddlerHttpTamper.UriMatch.MatchMode.ToString(), fiddlerHttpTamper.UriMatch.MatchUri) }, fiddlerHttpTamper.IsRawReplace ? 1 : 0);
            tamperRuleListView.Items.Add(nowRuleItem);
        }

         //pictureBox change for all
        public void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            ((PictureBox)sender).BackColor = Color.Honeydew;
        }

        //pictureBox change for all
        public void pictureBox_MouseLeave(object sender, EventArgs e)
        {
            ((PictureBox)sender).BackColor = Color.Transparent;
        }

        private void tabControl_Modific_Resize(object sender, EventArgs e)
        {
            tb_urlFilter.Width = tabControl_Modific.Width - 250;

            //tabPage_requestModific
            requestRemoveHeads.Width = (tabControl_Modific.Width - 22) / 3;
            requestAddHeads.Width = (tabControl_Modific.Width - 22) * 2 / 3;

            tb_requestModific_uriModificValue.Width = tabControl_Modific.Width - 126;
            tb_requestModific_body.Width = tabControl_Modific.Width - 92;

            //tabPage_requestReplace
            tb_requestReplace_uri.Width = tabControl_Modific.Width - 289;

            //tabPage_reponseModific
            responseRemoveHeads.Width = (tabControl_Modific.Width - 22) / 3;
            responseAddHeads.Width = (tabControl_Modific.Width - 22) * 2 / 3;

            tb_responseModific_body.Width = tabControl_Modific.Width - 92;

            //rule list
            columnHeader_requstRule.Width = lv_requestRuleList.Width - 70;
            columnHeader_responseRule.Width = lv_responseRuleList.Width - 70;
        }
        #endregion

        #region rule control
        private void pb_requestRuleSwitch_Click(object sender, EventArgs e)
        {
            if(isRequestRuleEnable)
            {
                pb_requestRuleSwitch.Image = Resources.MyResource.switch_off;
                isRequestRuleEnable = false;
            }
            else
            {
                pb_requestRuleSwitch.Image = Resources.MyResource.switch_on;
                isRequestRuleEnable = true;
            }
        }

        private void pb_responseRuleSwitch_Click(object sender, EventArgs e)
        {
            if(isResponseRuleEnable)
            {
                pb_responseRuleSwitch.Image = Resources.MyResource.switch_off;
                isResponseRuleEnable = false;
            }
            else
            {
                pb_responseRuleSwitch.Image = Resources.MyResource.switch_on;
                isResponseRuleEnable = true;
            }
        }
        #endregion

        #region RequestModific

        #endregion

        #region RequestReplace
        private void pb_requestReplace_changeMode_Click(object sender, EventArgs e)
        {
            if (panel_requestReplace_startLine.Visible == true)
            {
                panel_requestReplace_startLine.Visible = splitContainer_requestReplace.Visible = false;
                pb_requestReplace_changeMode.Visible = true;
                tabPage_requestReplace.Controls.Add(pb_requestReplace_changeMode);
                pb_requestReplace_changeMode.BringToFront();
            }
            else
            {
                panel_requestReplace_startLine.Visible = splitContainer_requestReplace.Visible = true;
                panel_requestReplace_startLine.Controls.Add(pb_requestReplace_changeMode);
            }
        }


        #endregion



        #region ResponseModific

        #endregion

        #region ResponseReplace

        #endregion

    }
}
