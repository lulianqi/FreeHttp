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

namespace FreeHttp.FreeHttpControl
{
    public partial class FreeHttpWindow : UserControl
    {
        /// <summary>
        /// the information for the mark Control
        /// </summary>
        class RemindControlInfo
        {
            public int RemindTime { get; set; }
            public Color OriginColor { get; set; }

            public RemindControlInfo(int yourRemindTime, Color yourOriginColor)
            {
                RemindTime = yourRemindTime;
                OriginColor = yourOriginColor;
            }
        }

        /// <summary>
        /// Http modific mode
        /// </summary>
        public enum RuleEditMode
        {
            NewRuleMode,
            EditRequsetRule,
            EditResponseRule
        }

        public class GetSessionRawDataEventArgs : EventArgs
        {
            public bool IsShowResponse { get; set; }
            public GetSessionRawDataEventArgs(bool isShowResponse)
            {
                IsShowResponse = isShowResponse;
            }
        }

        public delegate void GetSessionRawDataEventHandler(object sender, GetSessionRawDataEventArgs e);

        public FreeHttpWindow()
        {
            InitializeComponent();
            //this.DoubleBuffered = true;
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();
        }

        /// <summary>
        /// FreeHttpWindow
        /// </summary>
        /// <param name="yourRuleCollection">the history rule</param>
        public FreeHttpWindow(FiddlerModificHttpRuleCollection yourRuleCollection):this()
        {
            fiddlerModificHttpRuleCollection = yourRuleCollection;
        }
        

        /// <summary>
        /// On get the http session button click
        /// </summary>
        public event EventHandler OnGetSession;
        /// <summary>
        /// On get the raw http data link click
        /// </summary>
        public event GetSessionRawDataEventHandler OnGetSessionRawData;

        
        /// <summary>
        /// get or set IsSetResponseLatencyEable
        /// </summary>
        public bool IsSetResponseLatencyEable
        {
            get { return isSetResponseLatencyEable; }
            private set { isSetResponseLatencyEable = value; ChangeSetResponseLatencyMode(value==true?"":null); }
        }

        /// <summary>
        /// Is Request Rule Enable
        /// </summary>
        public bool IsRequestRuleEnable { get;private set; }
       
        /// <summary>
        /// Is Response Rule Enable
        /// </summary>
        public bool IsResponseRuleEnable { get; private set; }

        /// <summary>
        /// Get the RequestRule ListView
        /// </summary>
        public ListView RequestRuleListView { get { return lv_requestRuleList; } }

        /// <summary>
        /// Get the ResponseRule ListView
        /// </summary>
        public ListView ResponseRuleListView { get { return lv_responseRuleList; } }

        /// <summary>
        /// Get edit ListViewItem (if it is not in edit mode return null)
        /// </summary>
        public ListViewItem EditListViewItem { get; private set; }
       
        /// <summary>
        /// Get now edit mode
        /// </summary>
        public RuleEditMode NowEditMode { get; private set; }

        Timer myTimer = new Timer();
        Dictionary<ListViewItem, int> highlightItemDc;
        Dictionary<Control, RemindControlInfo> remindControlDc;
        FiddlerModificHttpRuleCollection fiddlerModificHttpRuleCollection;
        bool isSetResponseLatencyEable;


        private void FreeHttpWindow_Load(object sender, EventArgs e)
        {
            foreach(Control contor in this.Controls)
            {
                
            }
            LoadFiddlerModificHttpRuleCollection(fiddlerModificHttpRuleCollection);
            tbe_RequestBodyModific.Visible = false;
            tbe_ResponseBodyModific.Visible = false;
            tbe_RequestBodyModific.OnCloseEditBox += tbe_BodyModific_OnCloseEditBox;
            tbe_ResponseBodyModific.OnCloseEditBox += tbe_BodyModific_OnCloseEditBox;
            highlightItemDc = new Dictionary<ListViewItem, int>();
            remindControlDc = new Dictionary<Control, RemindControlInfo>();
            myTimer.Interval = 1000;
            myTimer.Tick += myTimer_Tick;
            myTimer.Start();

            cb_macthMode.SelectedIndex = 0;
            tabControl_Modific.SelectedIndex = 0;
            IsSetResponseLatencyEable = false;
        }

        #region Inner Function
        /// <summary>
        /// load history rule list
        /// </summary>
        /// <param name="yourRuleCollecttion">RuleCollecttion</param>
        private void LoadFiddlerModificHttpRuleCollection(FiddlerModificHttpRuleCollection yourRuleCollecttion)
        {
            if(yourRuleCollecttion!=null)
            {
                if(yourRuleCollecttion.RequestRuleList!=null)
                {
                    foreach(var tempRule in yourRuleCollecttion.RequestRuleList)
                    {
                        AddRuleToListView(lv_requestRuleList, tempRule ,false);
                    }
                }
                if(yourRuleCollecttion.ResponseRuleList!=null)
                {
                    foreach (var tempRule in yourRuleCollecttion.ResponseRuleList)
                    {
                        AddRuleToListView(lv_responseRuleList, tempRule,false);
                    }
                }
            }
        }

        private void AddRuleToListView(ListView yourListViews,IFiddlerHttpTamper yourHttpTamper,bool isMark)
        {
            ListViewItem nowRuleItem = new ListViewItem(new string[] { (yourListViews.Items.Count + 1).ToString(), string.Format("【{0}】: {1}", yourHttpTamper.UriMatch.MatchMode.ToString(), yourHttpTamper.UriMatch.MatchUri) }, yourHttpTamper.IsRawReplace ? 1 : 0);
            nowRuleItem.Tag = yourHttpTamper;
            nowRuleItem.ToolTipText = yourHttpTamper.UriMatch.MatchUri;
            nowRuleItem.Checked = yourHttpTamper.IsEnable;
            yourListViews.Items.Add(nowRuleItem);
            if (isMark)
            {
                MarkRuleItem(nowRuleItem);
                PutWarn(string.Format("Add {0} {1}", yourListViews.Columns[1].Text, nowRuleItem.SubItems[0].Text));
            }
            AdjustRuleListViewIndex(yourListViews);
            
        }

        private void UpdataRuleToListView(ListViewItem yourListViewItem, IFiddlerHttpTamper yourHttpTamper, bool isMark)
        {
            yourListViewItem.Tag = yourHttpTamper;
            yourListViewItem.SubItems[1].Text = string.Format("【{0}】: {1}", yourHttpTamper.UriMatch.MatchMode.ToString(), yourHttpTamper.UriMatch.MatchUri);
            yourListViewItem.ImageIndex = yourHttpTamper.IsRawReplace ? 1 : 0;
            yourListViewItem.ToolTipText = yourHttpTamper.UriMatch.MatchUri;
            yourListViewItem.Checked = yourHttpTamper.IsEnable;
            if(isMark)
            {
                MarkRuleItem(yourListViewItem);
                PutWarn(string.Format("Updata {0} {1}", yourListViewItem.ListView.Columns[1].Text, yourListViewItem.SubItems[0].Text));
            }
        }

        private void SyncEnableSateToIFiddlerHttpTamper(ListViewItem yourListViewItem, IFiddlerHttpTamper yourHttpTamper)
        {
            if(yourListViewItem!=null && yourHttpTamper!=null)
            {
                yourHttpTamper.IsEnable = yourListViewItem.Checked;
            }
        }

        private bool IsRequestReplaceRawMode
        {
            get { return !panel_requestReplace_startLine.Visible; }
        }

        private void ChangeEditRuleMode(RuleEditMode editMode, string mes, ListViewItem yourListViewItem)
        {
            switch (editMode)
            {
                case RuleEditMode.NewRuleMode:  // new rule
                    lb_editRuleMode.Text = (mes == null ? "New Mode" : mes);
                    pictureBox_editRuleMode.Image = FreeHttp.Resources.MyResource.add_mode;
                    this.toolTip_forMainWindow.SetToolTip(this.pictureBox_editRuleMode, "new a rule");
                    EditListViewItem = null;
                    break;
                case RuleEditMode.EditRequsetRule:  //edit request
                    lb_editRuleMode.Text = (mes == null ? "Edit Mode" : mes);
                    EditListViewItem = yourListViewItem;
                    pictureBox_editRuleMode.Image = FreeHttp.Resources.MyResource.edit_mode;
                    this.toolTip_forMainWindow.SetToolTip(this.pictureBox_editRuleMode, "save change for your requst rule");
                    break;
                case RuleEditMode.EditResponseRule:  //edit response
                    lb_editRuleMode.Text = (mes == null ? "Edit Mode" : mes);
                    EditListViewItem = yourListViewItem;
                    pictureBox_editRuleMode.Image = FreeHttp.Resources.MyResource.edit_mode;
                    this.toolTip_forMainWindow.SetToolTip(this.pictureBox_editRuleMode, "save change for your response rule");
                    break;
                default:
                    throw new Exception("get not support mode");
                    //break;
            }
            ClearModificInfo();
            NowEditMode = editMode;
        }

        private void MarkControl(Control yourControl, Color yourColor, int yourShowTick)
        {
            if (yourControl != null)
            {
                if (remindControlDc.ContainsKey(yourControl))
                {
                    remindControlDc[yourControl] = new RemindControlInfo(yourShowTick, remindControlDc[yourControl].OriginColor);
                }
                else
                {
                    remindControlDc.Add(yourControl, new RemindControlInfo(yourShowTick, yourControl.BackColor));
                }
                yourControl.BackColor = yourColor;
            }
        }

        private void MarkRuleItem(ListViewItem yourItem,Color yourColor,int yourShowTick)
        {
            if (yourItem != null)
            {
                yourItem.BackColor = yourColor;
                if (highlightItemDc.ContainsKey(yourItem))
                {
                    highlightItemDc[yourItem] = yourShowTick;
                }
                else
                {
                    highlightItemDc.Add(yourItem, yourShowTick);
                }
            }
        }

        private void MarkRuleItem(ListViewItem yourItem)
        {
            MarkRuleItem(yourItem, Color.PowderBlue, 5);
        }


        private FiddlerUriMatch GetUriMatch()
        {
            FiddlerUriMatchMode matchMode = FiddlerUriMatchMode.AllPass;
            if (!Enum.TryParse<FiddlerUriMatchMode>(cb_macthMode.Text, out matchMode))
            {
                throw new Exception("get error FiddlerUriMatchMode");
            }
            if (matchMode != FiddlerUriMatchMode.AllPass && tb_urlFilter.Text=="")
            {
                return null;
            }
            return new FiddlerUriMatch(matchMode, tb_urlFilter.Text);
        }

        private int GetResponseLatency()
        {
            return lbl_ResponseLatency.Text == "" ? 0 : int.Parse(lbl_ResponseLatency.Text);
        }

        private void SetUriMatch(FiddlerUriMatch fiddlerUriMatch)
        {
            if (fiddlerUriMatch != null)
            {
                cb_macthMode.Text = fiddlerUriMatch.MatchMode.ToString();
                tb_urlFilter.Text = string.IsNullOrEmpty(fiddlerUriMatch.MatchUri) ? "" : fiddlerUriMatch.MatchUri;
            }
        }

        private void SetResponseLatency(string yourLatency)
        {
            ChangeSetResponseLatencyMode(yourLatency);
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

                requsetReplace.HttpRawRequest.RequestHeads = new List<MyKeyValuePair<string, string>>();
                if (elv_requsetReplace.ListDataView.Items.Count > 0)
                {
                    foreach (ListViewItem item in elv_requsetReplace.ListDataView.Items)
                    {
                        string headStr = item.Text;
                        if (headStr.Contains(": "))
                        {
                            string key = headStr.Remove(headStr.IndexOf(": "));
                            string value = headStr.Substring(headStr.IndexOf(": ") + 2);
                            requsetReplace.HttpRawRequest.RequestHeads.Add(new MyKeyValuePair<string, string>(key, value));
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
                requsetReplace.HttpRawRequest.SetAutoContentLength();
            }
            return requsetReplace;
        }

        private FiddlerResponseChange GetResponseModificInfo()
        {
            FiddlerResponseChange responseChange = new FiddlerResponseChange();
            responseChange.HttpRawResponse = null;
            responseChange.UriMatch = GetUriMatch();
            responseChange.LesponseLatency = GetResponseLatency();
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
            responseChange.BodyModific = new ContentModific(tb_responseModific_body.Text, rtb_respenseModific_body.Text);
            return responseChange;
        }

        private FiddlerResponseChange GetResponseReplaceInfo()
        {
            FiddlerResponseChange responseChange = new FiddlerResponseChange();
            responseChange.UriMatch = GetUriMatch();
            responseChange.LesponseLatency = GetResponseLatency();
            responseChange.HttpRawResponse = rawResponseEdit.GetHttpResponse();
            responseChange.IsIsDirectRespons = rawResponseEdit.IsDirectRespons;
            return responseChange;
        }

        private void ClearModificInfo()
        {
            cb_macthMode.Text = "";
            tb_urlFilter.Text = "";
            tb_requestModific_uriModificKey.Text = "";
            tb_requestModific_uriModificValue.Text = "";
            tb_requestModific_body.Text = "";
            cb_editRequestMethod.Text = "";
            tb_requestReplace_uri.Text = "";
            cb_editRequestEdition.Text = "";
            tb_responseModific_body.Text = "";
            rawResponseEdit.ClearInfo();
            requestRemoveHeads.ListDataView.Items.Clear();
            requestAddHeads.ListDataView.Items.Clear();
            elv_requsetReplace.ListDataView.Items.Clear();
            responseRemoveHeads.ListDataView.Items.Clear();
            responseAddHeads.ListDataView.Items.Clear();
            rtb_requestModific_body.Clear();
            rtb_requsetReplace_body.Clear();
            rtb_requestRaw.Clear();
            tabControl_Modific_Selecting(this.tabControl_Modific, null);
        }

        private void SetRequestModificInfo(FiddlerRequsetChange fiddlerRequsetChange)
        {
            SetUriMatch(fiddlerRequsetChange.UriMatch);
            if(fiddlerRequsetChange.HttpRawRequest==null)
            {
                tabControl_Modific.SelectedIndex = 0;
                if (fiddlerRequsetChange.UriModific != null && fiddlerRequsetChange.UriModific.ModificMode != ContentModificMode.NoChange)
                {
                    tb_requestModific_uriModificKey.Text = fiddlerRequsetChange.UriModific.TargetKey;
                    tb_requestModific_uriModificValue.Text = fiddlerRequsetChange.UriModific.ReplaceContent;
                }
                if (fiddlerRequsetChange.HeadDelList != null)
                {
                    foreach(string tempHead in fiddlerRequsetChange.HeadDelList)
                    {
                        requestRemoveHeads.ListDataView.Items.Add(tempHead);
                    }
                }
                if(fiddlerRequsetChange.HeadAddList!=null)
                {
                    foreach (string tempHead in fiddlerRequsetChange.HeadAddList)
                    {
                        requestAddHeads.ListDataView.Items.Add(tempHead);
                    }
                }
                if (fiddlerRequsetChange.BodyModific != null && fiddlerRequsetChange.BodyModific.ModificMode!= ContentModificMode.NoChange)
                {
                    tb_requestModific_body.Text = fiddlerRequsetChange.BodyModific.TargetKey;
                    rtb_requestModific_body.AppendText(fiddlerRequsetChange.BodyModific.ReplaceContent);
                }
            }
            else
            {
                tabControl_Modific.SelectedIndex = 1;
                if(IsRequestReplaceRawMode)
                {
                    pb_requestReplace_changeMode_Click(null, null);
                }
                cb_editRequestMethod.Text = fiddlerRequsetChange.HttpRawRequest.RequestMethod;
                tb_requestReplace_uri.Text = fiddlerRequsetChange.HttpRawRequest.RequestUri;
                cb_editRequestEdition.Text = fiddlerRequsetChange.HttpRawRequest.RequestVersions;
                if(fiddlerRequsetChange.HttpRawRequest.RequestHeads!=null)
                {
                    foreach (MyKeyValuePair<string, string> tempHead in fiddlerRequsetChange.HttpRawRequest.RequestHeads)
                    {
                        elv_requsetReplace.ListDataView.Items.Add(string.Format("{0}: {1}", tempHead.Key, tempHead.Value));
                    }
                }
                if (fiddlerRequsetChange.HttpRawRequest.RequestEntity!=null)
                {
                    rtb_requsetReplace_body.AppendText(Encoding.UTF8.GetString(fiddlerRequsetChange.HttpRawRequest.RequestEntity));
                }
                if(fiddlerRequsetChange.HttpRawRequest.OriginSting!=null)
                {
                    rtb_requestRaw.AppendText(fiddlerRequsetChange.HttpRawRequest.OriginSting);
                }

            }
            SetResponseLatency(null);
        }

        private void SetResponseModificInfo(FiddlerResponseChange fiddlerResponseChange)
        {
            SetUriMatch(fiddlerResponseChange.UriMatch);
            if (fiddlerResponseChange.HttpRawResponse == null)
            {
                tabControl_Modific.SelectedIndex = 2;
                if(fiddlerResponseChange.HeadDelList!=null)
                {
                    foreach (string tempHead in fiddlerResponseChange.HeadDelList)
                    {
                        responseRemoveHeads.ListDataView.Items.Add(tempHead);
                    }
                }
                if (fiddlerResponseChange.HeadAddList != null)
                {
                    foreach (string tempHead in fiddlerResponseChange.HeadAddList)
                    {
                        responseAddHeads.ListDataView.Items.Add(tempHead);
                    }
                }
                if (fiddlerResponseChange.BodyModific != null && fiddlerResponseChange.BodyModific.ModificMode != ContentModificMode.NoChange)
                {
                    tb_responseModific_body.Text = fiddlerResponseChange.BodyModific.TargetKey;
                    rtb_respenseModific_body.AppendText(fiddlerResponseChange.BodyModific.ReplaceContent);
                }
            }
            else
            {
                tabControl_Modific.SelectedIndex = 3;
                rawResponseEdit.IsDirectRespons = fiddlerResponseChange.IsIsDirectRespons;
                if(fiddlerResponseChange.HttpRawResponse.OriginSting!=null)
                {
                    rawResponseEdit.SetText(fiddlerResponseChange.HttpRawResponse.OriginSting);
                }
            }
            SetResponseLatency(fiddlerResponseChange.LesponseLatency.ToString());
        }
        private void AdjustRuleListViewIndex(ListView ruleListView)
        {
            if(ruleListView.Items.Count>0)
            {
                for(int i=0;i<ruleListView.Items.Count;i++)
                {
                    ruleListView.Items[i].SubItems[0].Text = (i + 1).ToString();
                }
            }
        }

        #endregion

        #region Public Function
        
        public void CloseEditRtb()
        {
            tbe_RequestBodyModific.CloseRichTextBox();
            tbe_ResponseBodyModific.CloseRichTextBox();
            tbe_RequestBodyModific.Visible = tb_requestModific_body.Focused;
            tbe_ResponseBodyModific.Visible = tb_responseModific_body.Focused;
        }
        public void SetModificSession(Fiddler.Session session)
        {
            ChangeEditRuleMode(RuleEditMode.NewRuleMode, null, null);

            tb_urlFilter.Text = session.fullUrl;
            cb_macthMode.SelectedIndex = 2;

            if (tabControl_Modific.SelectedIndex == 0)
            {
                tabControl_Modific.SelectedIndex = 1;
            }
            else if (tabControl_Modific.SelectedIndex == 2)
            {
                tabControl_Modific.SelectedIndex = 3;
            }

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

        public void MarkMatchRule(ListViewItem yourItem)
        {
            MarkRuleItem(yourItem, Color.Khaki, 3);
        }

        public void PutInfo(string info)
        {
            rtb_MesInfo.SelectionColor = Color.Black;
            rtb_MesInfo.AppendText(string.Format("【{0}】:{1}", DateTime.Now.ToString(), info));
            rtb_MesInfo.AppendText("\r\n");
            rtb_MesInfo.SelectionColor = Color.Black;
        }

        public void PutWarn(string info)
        {
            rtb_MesInfo.SelectionColor = Color.Indigo;
            rtb_MesInfo.AppendText(string.Format("【{0}】:{1}", DateTime.Now.ToString(), info));
            rtb_MesInfo.AppendText("\r\n");
            rtb_MesInfo.SelectionColor = Color.Black;
        }

        public void PutError(string info)
        {
            rtb_MesInfo.SelectionColor = Color.Red;
            rtb_MesInfo.AppendText(string.Format("【{0}】:{1}", DateTime.Now.ToString(), info));
            rtb_MesInfo.AppendText("\r\n");
            rtb_MesInfo.SelectionColor = Color.Black;
        }
        
        #endregion

        #region Public Event

        void myTimer_Tick(object sender, EventArgs e)
        {
            if (highlightItemDc.Count > 0)
            {
                //MyControlHelper.SetControlFreeze(lv_requestRuleList);
                List<ListViewItem> tempRemoveItem = new List<ListViewItem>();
                List<ListViewItem> tempHighlightList = new List<ListViewItem>();
                tempHighlightList.AddRange(highlightItemDc.Keys);
                foreach (var tempHighlightItem in tempHighlightList)
                {
                    highlightItemDc[tempHighlightItem]--;
                    if (highlightItemDc[tempHighlightItem] == 0)
                    {
                        tempHighlightItem.BackColor = Color.Transparent;
                        tempRemoveItem.Add(tempHighlightItem);
                    }
                }
                //MyControlHelper.SetControlUnfreeze(lv_requestRuleList);
                foreach (var tempItem in tempRemoveItem)
                {
                    highlightItemDc.Remove(tempItem);
                }
            }

            if (remindControlDc.Count > 0)
            {
                List<Control> tempRemoveControl = new List<Control>();
                List<Control> tempRemindList = new List<Control>();
                tempRemindList.AddRange(remindControlDc.Keys);
                foreach (var tempRemindControl in tempRemindList)
                {
                    remindControlDc[tempRemindControl].RemindTime--;
                    if (remindControlDc[tempRemindControl].RemindTime == 0)
                    {
                        tempRemindControl.BackColor = remindControlDc[tempRemindControl].OriginColor;
                        tempRemoveControl.Add(tempRemindControl);
                    }
                }

                foreach (var tempItem in tempRemoveControl)
                {
                    tempItem.BackColor = remindControlDc[tempItem].OriginColor;
                    remindControlDc.Remove(tempItem);
                }
            }
        }


        private void tabControl_Modific_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if(NowEditMode== RuleEditMode.EditRequsetRule)
            {
                if (((TabControl)sender).SelectedIndex == 2 || ((TabControl)sender).SelectedIndex == 3)
                {
                    MessageBox.Show("the select requst rule is in editing \r\n    you can not edit response", "STOP");
                    e.Cancel = true;
                }
            }
            else if(NowEditMode== RuleEditMode.EditResponseRule)
            {
                if (((TabControl)sender).SelectedIndex == 0 || ((TabControl)sender).SelectedIndex == 1)
                {
                    MessageBox.Show("the select response rule is in editing \r\n    you can not edit requst", "STOP");
                    e.Cancel = true;
                }
            } 
            else
            {
                if (((TabControl)sender).SelectedIndex == 0 || ((TabControl)sender).SelectedIndex == 1)
                {
                    IsSetResponseLatencyEable = false;
                }
                else
                {
                    IsSetResponseLatencyEable = true;
                }
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
            else if (sourceControl == rtb_requestRaw)
            {
                tempRtb = rtb_requestRaw;
            }
            else
            {
                throw new Exception("not adapt this event");
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

        private void pictureBox_editRuleMode_Click(object sender, EventArgs e)
        {
            pb_ruleComfrim_Click(sender, e);
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


        private void tb_Modific_body_Enter(object sender, EventArgs e)
        {
            TextBoxEditer tbe = null;
            if (sender == tb_requestModific_body)
            {
                tbe = tbe_RequestBodyModific;
            }
            else if (sender == tb_responseModific_body)
            {
                tbe = tbe_ResponseBodyModific;
            }
            else
            {
                throw new Exception("nonsupport sender in tb_Modific_body_Enter");
            }
            tbe.Visible = true;
        }

        private void tb_Modific_body_Leave(object sender, EventArgs e)
        {
            TextBoxEditer tbe = null;
            if (sender == tb_requestModific_body)
            {
                tbe = tbe_RequestBodyModific;
            }
            else if (sender == tb_responseModific_body)
            {
                tbe = tbe_ResponseBodyModific;
            }
            else
            {
                throw new Exception("nonsupport sender in tb_Modific_body_Enter");
            }

            if (!(tbe.IsShowEditRichTextBox))
            {
                tbe.Visible = false;
            }
           
        }

        void tbe_BodyModific_OnCloseEditBox(object sender, TextBoxEditer.CloseEditBoxEventArgs e)
        {
            ((TextBoxEditer)sender).Visible = false;
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
            
        }

        private void splitContainer_httpControl_Resize(object sender, EventArgs e)
        {
            //rule list
            columnHeader_requstRule.Width = lv_requestRuleList.Width - 70;
            columnHeader_responseRule.Width = lv_responseRuleList.Width - 70;
        }
        #endregion

        #region Modific ContorLine
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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

            if (fiddlerHttpTamper.UriMatch == null)
            {
                MessageBox.Show("you Uri Filter is not legal \r\n check it again", "edit again");
                MarkControl(groupBox_urlFilter, Color.Plum, 2);
                return;
            }

            ListViewItem nowRuleItem = null;
            foreach (ListViewItem tempItem in tamperRuleListView.Items)
            {
                if (fiddlerHttpTamper.UriMatch.Equals(tempItem.Tag))
                {
                    if (tempItem == EditListViewItem)
                    {
                        continue;
                    }
                    MarkRuleItem(tempItem, Color.Plum, 2);
                    DialogResult tempDs;
                    //add mode
                    if (EditListViewItem == null)
                    {
                        tempDs = MessageBox.Show(string.Format("find same uri filter with [Rule:{0}], do you want update the rule \r\n    [Yes]       update the rule \r\n    [No]       new a same uri filter rule \r\n    [Cancel]  give up save", tempItem.SubItems[0].Text), "find same rule ", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        if (tempDs == DialogResult.Yes)
                        {
                            nowRuleItem = tempItem;
                            SyncEnableSateToIFiddlerHttpTamper(nowRuleItem, fiddlerHttpTamper);
                            UpdataRuleToListView(nowRuleItem, fiddlerHttpTamper, true);
                            break;
                        }
                        else if (tempDs == DialogResult.No)
                        {
                            continue;
                        }
                        else
                        {
                            return;
                        }
                    }
                    //edit mode
                    else
                    {
                        tempDs = MessageBox.Show(string.Format("find same uri filter with [Rule:{0}], do you want remove the rule \r\n    [Yes]       remove the rule \r\n    [No]       skip the same uri filter rule \r\n    [Cancel]  give up save", tempItem.SubItems[0].Text), "find same rule ", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        if (tempDs == DialogResult.Yes)
                        {
                            tamperRuleListView.Items.Remove(tempItem);
                            continue;
                        }
                        else if (tempDs == DialogResult.No)
                        {
                            continue;
                        }
                        else
                        {
                            return;
                        }
                    }


                }
            }

            if (nowRuleItem == null)
            {
                if (EditListViewItem == null)
                {
                    AddRuleToListView(tamperRuleListView, fiddlerHttpTamper, true);
                }
                else
                {
                    SyncEnableSateToIFiddlerHttpTamper(EditListViewItem, fiddlerHttpTamper);
                    UpdataRuleToListView(EditListViewItem, fiddlerHttpTamper, true);
                }
            }

            ChangeEditRuleMode(RuleEditMode.NewRuleMode, null, null);
        }

        private void pb_ruleCancel_Click(object sender, EventArgs e)
        {
            ClearModificInfo();
            PutWarn("Clear the Modific Info");
            ChangeEditRuleMode(RuleEditMode.NewRuleMode, null, null);
        }

        private void pb_responseLatency_Click(object sender, EventArgs e)
        {
            if (IsSetResponseLatencyEable)
            {
                SetVaule f = new SetVaule("Set Latency", "Enter the exact number of milliseconds by which to delay the response", sender == pb_responseLatency ? "0" : lbl_ResponseLatency.Text, new Func<string, bool>((string checkValue) => { int tempValue; if (checkValue == "") return true; return int.TryParse(checkValue, out tempValue); }));
                f.OnSetValue += f_OnSetValue;
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Can not set latency  in reqest modific mode\r\njust change to response modific mode", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void ChangeSetResponseLatencyMode(string yourLatency)
        {
            if(yourLatency==null)
            {
                lbl_ResponseLatency.Text = "";
                lbl_ResponseLatency.Visible = false;
                pb_responseLatency.Image = Resources.MyResource.naozhong_off;
                pb_responseLatency.Visible = true;
                isSetResponseLatencyEable = false;
            }
            else if (yourLatency == "" || yourLatency == "0")
            {
                lbl_ResponseLatency.Text = "";
                lbl_ResponseLatency.Visible = false;
                pb_responseLatency.Image = Resources.MyResource.naozhong_on;
                pb_responseLatency.Visible = true;
                isSetResponseLatencyEable = true;
            }
            else
            {
               lbl_ResponseLatency.Text = yourLatency;
                if (lbl_ResponseLatency.Width <= pb_responseLatency.Width)
                {
                    lbl_ResponseLatency.Location = new Point( pb_responseLatency.Location.X,lbl_ResponseLatency.Location.Y);
                }
                else
                {
                    lbl_ResponseLatency.Location = new Point( pb_responseLatency.Location.X - (lbl_ResponseLatency.Width - pb_responseLatency.Width),lbl_ResponseLatency.Location.Y);
                }
                lbl_ResponseLatency.Visible = true;
                pb_responseLatency.Visible = false;
                isSetResponseLatencyEable = true;
            }
        }

        void f_OnSetValue(object sender, SetVaule.SetVauleEventArgs e)
        {
            if (e.SetValue == null || e.SetValue == "0" || e.SetValue == "")
            {
                ChangeSetResponseLatencyMode("");
            }
            else
            {
                ChangeSetResponseLatencyMode(e.SetValue);
            }
        }

        private void disableCacheToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(NowEditMode== RuleEditMode.EditResponseRule)
            {
                MessageBox.Show("your are in Response Edit Mode ","Stop");
                return;
            }
            tabControl_Modific.SelectedIndex = 0;
            requestRemoveHeads.ListDataView.Items.Add("Pragma");
            requestRemoveHeads.ListDataView.Items.Add("Cache-Control");
            requestRemoveHeads.ListDataView.Items.Add("If-None-Match");
            requestRemoveHeads.ListDataView.Items.Add("If-Modified-Since");
            requestAddHeads.ListDataView.Items.Add("Pragma: no-cache");
            requestAddHeads.ListDataView.Items.Add("Cache-Control: no-cache");
        }

        private void addCookieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (NowEditMode == RuleEditMode.EditResponseRule)
            {
                MessageBox.Show("your are in Response Edit Mode ", "Stop");
                return;
            }
            tabControl_Modific.SelectedIndex = 0;
            AddHead f = new AddHead(requestAddHeads.ListDataView, "Cookie");
            f.ShowDialog();
        }

        private void addUserAgentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (NowEditMode == RuleEditMode.EditResponseRule)
            {
                MessageBox.Show("your are in Response Edit Mode ", "Stop");
                return;
            }
            tabControl_Modific.SelectedIndex = 0;
            requestRemoveHeads.ListDataView.Items.Add("User-Agent");
            AddHead f = new AddHead(requestAddHeads.ListDataView, "User-Agent");
            f.ShowDialog();
        }

        private void deleteCookieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (NowEditMode == RuleEditMode.EditRequsetRule)
            {
                MessageBox.Show("your are in Requset Edit Mode ", "Stop");
                return;
            }
            tabControl_Modific.SelectedIndex = 2;
            EditCookieForm f = new EditCookieForm(responseAddHeads.ListDataView, null, null, "Max-Age=1;Domain=www.yourhost.com;Path=/");
            f.ShowDialog();
        }

        private void setClientCookieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (NowEditMode == RuleEditMode.EditRequsetRule)
            {
                MessageBox.Show("your are in Requset Edit Mode ", "Stop");
                return;
            }
            tabControl_Modific.SelectedIndex =2;
            EditCookieForm f = new EditCookieForm(responseAddHeads.ListDataView);
            f.ShowDialog();
        }

        private void showSelectedSessionStreamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(OnGetSessionRawData!=null)
            {
                this.OnGetSessionRawData(this, new GetSessionRawDataEventArgs(true));
            }
        }

        #endregion

        #region Rule control
        private void pb_requestRuleSwitch_Click(object sender, EventArgs e)
        {
            if(IsRequestRuleEnable)
            {
                pb_requestRuleSwitch.Image = Resources.MyResource.switch_off;
                IsRequestRuleEnable = false;
                PutWarn("Request Temper Rule Forbidden");
            }
            else
            {
                pb_requestRuleSwitch.Image = Resources.MyResource.switch_on;
                IsRequestRuleEnable = true;
                PutWarn("Request Temper Rule Enabled");
            }
        }

        private void pb_responseRuleSwitch_Click(object sender, EventArgs e)
        {
            if(IsResponseRuleEnable)
            {
                pb_responseRuleSwitch.Image = Resources.MyResource.switch_off;
                IsResponseRuleEnable = false;
                PutWarn("Response Temper Rule Forbidden");
            }
            else
            {
                pb_responseRuleSwitch.Image = Resources.MyResource.switch_on;
                IsResponseRuleEnable = true;
                PutWarn("Response Temper Rule Enabled");
            }
        }

        private void lv_RuleList_DoubleClick(object sender, EventArgs e)
        {
            //Point p = PointToClient(new Point(Cursor.Position.X, Cursor.Position.Y)); 
            //ListViewItem lvi = ((ListView)sender).GetItemAt(p.X, p.Y);
            if (((ListView)sender).SelectedItems == null || ((ListView)sender).SelectedItems.Count == 0)
            {
                return;
            }
            ListViewItem nowListViewItem = ((ListView)sender).SelectedItems[0];
            if (nowListViewItem != null)
            {
                if (sender == lv_requestRuleList)
                {
                    ChangeEditRuleMode(RuleEditMode.EditRequsetRule, string.Format("Edit Requst {0}", nowListViewItem.SubItems[0].Text), nowListViewItem);
                    SetRequestModificInfo((FiddlerRequsetChange)nowListViewItem.Tag);

                }
                else if (sender == lv_responseRuleList)
                {
                    ChangeEditRuleMode(RuleEditMode.EditResponseRule, string.Format("Edit Response {0}", nowListViewItem.SubItems[0].Text), nowListViewItem);
                    SetResponseModificInfo((FiddlerResponseChange)nowListViewItem.Tag);
                }
                else
                {
                    MessageBox.Show("not adaptive to lv_RuleList_DoubleClick");
                }
            }
        }

        private void lv_RuleList_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (e.Item != null)
            {
                ((IFiddlerHttpTamper)e.Item.Tag).IsEnable = e.Item.Checked;
            }
        }
        private void pb_addTemperRule_Click(object sender, EventArgs e)
        {
            if (sender == pb_addRequestRule)
            {
                ChangeEditRuleMode(RuleEditMode.NewRuleMode, null, null);
                tabControl_Modific.SelectedIndex = 1;
                MarkControl(pb_getSession, Color.LightYellow, 1);
            }
            else if (sender == pb_addResponseRule)
            {
                ChangeEditRuleMode(RuleEditMode.NewRuleMode, null, null);
                tabControl_Modific.SelectedIndex = 2;
                MarkControl(pb_getSession, Color.LightYellow, 1);
            }
            else
            {
                return;
            }
        }
        private void pb_removeTemperRule_Click(object sender, EventArgs e)
        {
            ListView nowRuleListView = null;
            if (sender == pb_removeRequestRule)
            {
                nowRuleListView = lv_requestRuleList;
            }
            else if (sender == pb_removeResponseRule)
            {
                nowRuleListView = lv_responseRuleList;
            }
            else
            {
                return;
            }
            if (nowRuleListView.SelectedItems != null)
            {
                foreach (ListViewItem tempItem in nowRuleListView.SelectedItems)
                {
                    if (tempItem == EditListViewItem)
                    {
                        ChangeEditRuleMode(RuleEditMode.NewRuleMode, null, null);
                        PutWarn("you editing rule is removed ,now change to [NewRuleMode]");
                    }
                    nowRuleListView.Items.Remove(tempItem);
                }
                AdjustRuleListViewIndex(nowRuleListView);
            }

        }

        #region RuleToolStripMenuItem

        private ListView GetRuleToolStripMenuItemSourceControl(object sender)
        {
            object sourceControl = ((ContextMenuStrip)(((ToolStripMenuItem)sender).Owner)).SourceControl;
            if (sourceControl == lv_requestRuleList)
            {
                return lv_requestRuleList;
            }
            else if (sourceControl == lv_responseRuleList)
            {
                return lv_responseRuleList;
            }
            else
            {
                throw new Exception("nonsupported SelectedRuleToolStripMenuItem_Click");
            }
        }
        private void removeSelectedRuleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListView tempRuleLv = GetRuleToolStripMenuItemSourceControl(sender);

            if (tempRuleLv == lv_requestRuleList)
            {
                pb_removeTemperRule_Click(pb_removeRequestRule, null);
            }
            else if (tempRuleLv == lv_responseRuleList)
            {
                pb_removeTemperRule_Click(pb_removeResponseRule, null);
            }
            else
            {
                throw new Exception("nonsupported SelectedRuleToolStripMenuItem_Click");
            }
        }

        private void removeAllRuleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(!(MessageBox.Show("if you want remove all your tamper rule in this list","reconfirm ",MessageBoxButtons.OKCancel,MessageBoxIcon.Question)== DialogResult.OK))
            {
                return;
            }
            ListView tempRuleLv = GetRuleToolStripMenuItemSourceControl(sender);
            if (EditListViewItem != null && EditListViewItem.ListView == tempRuleLv)
            {
                ChangeEditRuleMode(RuleEditMode.NewRuleMode, null, null);
                PutWarn("you editing rule is removed ,now change to [NewRuleMode]");
            }
            tempRuleLv.Items.Clear();
        }

        private void enableThisRuleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListView tempRuleLv = GetRuleToolStripMenuItemSourceControl(sender);
            if (tempRuleLv.SelectedItems != null)
            {
                foreach (ListViewItem tempItem in tempRuleLv.SelectedItems)
                {
                    tempItem.Checked = true;
                }
            }
        }

        private void enableAllRuleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListView tempRuleLv = GetRuleToolStripMenuItemSourceControl(sender);

            foreach (ListViewItem tempItem in tempRuleLv.Items)
            {
                tempItem.Checked = true;
            }
        }

        private void unableAllRuleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListView tempRuleLv = GetRuleToolStripMenuItemSourceControl(sender);

            foreach (ListViewItem tempItem in tempRuleLv.Items)
            {
                tempItem.Checked = false;
            }
        }

        private void editThisRuleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListView tempRuleLv = GetRuleToolStripMenuItemSourceControl(sender);
            lv_RuleList_DoubleClick(tempRuleLv, null);
        }

        #endregion


        #endregion

        #region Url Filter

        private void pb_getSession_Click(object sender, EventArgs e)
        {
            if (OnGetSession != null)
            {
                this.OnGetSession(this, null);
            }
        }
        private void cb_macthMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_macthMode.Text == "AllPass")
            {
                tb_urlFilter.Text = "";
                tb_urlFilter.Enabled = false;
            }
            else
            {
                tb_urlFilter.Enabled = true;
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
                this.toolTip_forMainWindow.SetToolTip(this.pb_requestReplace_changeMode, "change request replace mode to format mode");
                pb_requestReplace_changeMode.BringToFront();
            }
            else
            {
                panel_requestReplace_startLine.Visible = splitContainer_requestReplace.Visible = true;
                panel_requestReplace_startLine.Controls.Add(pb_requestReplace_changeMode);
                this.toolTip_forMainWindow.SetToolTip(this.pb_requestReplace_changeMode, "change request replace mode to raw mode");
            }
        }


        #endregion

        #region ResponseModific

        #endregion

        #region ResponseReplace

        #endregion

    }
}
