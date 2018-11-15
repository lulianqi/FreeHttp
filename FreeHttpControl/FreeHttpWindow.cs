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
        public FreeHttpWindow(FiddlerModificHttpRuleCollection yourRuleCollection , FiddlerModificSettingInfo yourModifcSettingInfo):this()
        {
            fiddlerModificHttpRuleCollection = yourRuleCollection;
            ModificSettingInfo = yourModifcSettingInfo;
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
        /// get or set ModificSettingInfo
        /// </summary>
        public FiddlerModificSettingInfo ModificSettingInfo { get;  set; }

        /// <summary>
        /// get or set IsSetResponseLatencyEable
        /// </summary>
        public bool IsSetResponseLatencyEable
        {
            get { return isSetResponseLatencyEable; }
            private set { isSetResponseLatencyEable = value; ChangeSetResponseLatencyMode(value == true ? 0 : -1); }
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


        MarkControlService markControlService;
        FiddlerModificHttpRuleCollection fiddlerModificHttpRuleCollection;
        bool isSetResponseLatencyEable;


        private void FreeHttpWindow_Load(object sender, EventArgs e)
        {
            LoadFiddlerModificHttpRuleCollection(fiddlerModificHttpRuleCollection);
            if(ModificSettingInfo==null)
            {
                ModificSettingInfo = new FiddlerModificSettingInfo(false, true, true);
            }
            if(ModificSettingInfo.IsDefaultEnableRule)
            {
                pb_requestRuleSwitch_Click(null, null);
                pb_responseRuleSwitch_Click(null, null);
            }
            tbe_RequestBodyModific.Visible = false;
            tbe_ResponseBodyModific.Visible = false;
            tbe_urlFilter.Visible = false;
            tbe_RequestBodyModific.OnCloseEditBox += tbe_BodyModific_OnCloseEditBox;
            tbe_ResponseBodyModific.OnCloseEditBox += tbe_BodyModific_OnCloseEditBox;
            tbe_urlFilter.OnCloseEditBox += tbe_BodyModific_OnCloseEditBox;

            markControlService = new MarkControlService(1000);
            cb_macthMode.SelectedIndex = 0;
            tabControl_Modific.SelectedIndex = 0;
            IsSetResponseLatencyEable = false;
        }

        #region Public Event
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
            else if(sender == tb_urlFilter)
            {
                tbe = tbe_urlFilter;
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
            else if (sender == tb_urlFilter)
            {
                tbe = tbe_urlFilter;
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
                MarkControl(tabControl_Modific.SelectedTab, Color.Plum, 2);
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
            ChangeSetResponseLatencyMode((tabControl_Modific.SelectedIndex == 0 || tabControl_Modific.SelectedIndex == 1) ? -1 : 0);
        }

        private void pb_responseLatency_Click(object sender, EventArgs e)
        {
            if (IsSetResponseLatencyEable)
            {
                SetVaule f = new SetVaule("Set Latency", "Enter the exact number of milliseconds by which to delay the response", sender == pb_responseLatency ? "0" : lbl_ResponseLatency.GetLatency().ToString(), new Func<string, bool>((string checkValue) => { int tempValue; if (checkValue == "") return true; return (int.TryParse(checkValue, out tempValue) && tempValue>=0); }));
                f.OnSetValue += f_OnSetValue;
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Can not set latency  in reqest modific mode\r\njust change to response modific mode", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        void f_OnSetValue(object sender, SetVaule.SetVauleEventArgs e)
        {
            if (e.SetValue == null || e.SetValue == "0" || e.SetValue == "")
            {
                ChangeSetResponseLatencyMode(0);
            }
            else
            {
                //impossible to exception throw
                ChangeSetResponseLatencyMode(int.Parse(e.SetValue));
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

        private void httpTamperSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingWindow f = new SettingWindow(ModificSettingInfo);
            f.ShowDialog();
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
            if (nowRuleListView.SelectedItems != null && nowRuleListView.SelectedItems.Count>0)
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
            else
            {
                MessageBox.Show("please select the rules that your want remove");
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
