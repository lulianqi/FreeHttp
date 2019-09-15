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
using FreeHttp.AutoTest.RunTimeStaticData;
using FreeHttp.FiddlerHelper;
using FreeHttp.AutoTest.ParameterizationPick;

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

        public enum GetSessionAction
        {
            ShowShowResponse,
            SetCookies,
            DeleteCookies
        }

        public class GetSessionRawDataEventArgs : EventArgs
        {
            public GetSessionAction SessionAction { get; set; }
            public GetSessionRawDataEventArgs(GetSessionAction sessionAction)
            {
                SessionAction = sessionAction;
            }
        }

        public class GetSessionEventArgs
        {
            public bool IsGetSuccess { get; set; } = false;
            public String Uri { get; set; }
            public List<KeyValuePair<string,string>> RequestHeads { get; set; }
            public String RequestEntity { get; set; }
            public List<KeyValuePair<string, string>> ResponseHeads { get; set; }
            public String ResponseEntity { get; set; }
            public bool IsGetEntity { get; private set; } = false;
            public GetSessionEventArgs(bool isGetEntity)
            {
                IsGetEntity = isGetEntity;
            }

        }
        public class GetSessionSeekHeadEventArgs : EventArgs
        {
            public string SeekUri { get; set; }
            public KeyValuePair<string,string> ResquestHead { get; set; }
            public KeyValuePair<string, string> ResponseHead { get; set; }

            public GetSessionSeekHeadEventArgs(KeyValuePair<string, string> resquestHead , KeyValuePair<string, string> responseHead)
            {
                ResquestHead = resquestHead;
                ResponseHead = responseHead;
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
        public FreeHttpWindow(FiddlerModificHttpRuleCollection yourRuleCollection, FiddlerModificSettingInfo yourModifcSettingInfo, ActuatorStaticDataCollection yourStaticDataCollection)
            : this()
        {
            fiddlerModificHttpRuleCollection = yourRuleCollection;
            ModificSettingInfo = yourModifcSettingInfo;
            StaticDataCollection = yourStaticDataCollection;
            if(fiddlerModificHttpRuleCollection!=null&&StaticDataCollection!=null)
            {
                foreach(var fr in fiddlerModificHttpRuleCollection.ResponseRuleList)
                {
                    fr.ActuatorStaticDataController = new FiddlerActuatorStaticDataCollectionController(StaticDataCollection);
                    if(fr.IsRawReplace)
                    {
                        if(fr.HttpRawResponse.ParameterizationContent==null)
                        {
                            fr.HttpRawResponse.ParameterizationContent = new AutoTest.ParameterizationContent.CaseParameterizationContent(fr.HttpRawResponse.OriginSting);
                        }
                        fr.HttpRawResponse.SetActuatorStaticDataCollection(StaticDataCollection);
                    }
                }
                foreach (var fr in fiddlerModificHttpRuleCollection.RequestRuleList)
                {
                    fr.ActuatorStaticDataController = new FiddlerActuatorStaticDataCollectionController(StaticDataCollection);
                    if (fr.IsRawReplace)
                    {
                        if (fr.HttpRawRequest.ParameterizationContent== null)
                        {
                            fr.HttpRawRequest.ParameterizationContent = new AutoTest.ParameterizationContent.CaseParameterizationContent(fr.HttpRawRequest.OriginSting);
                        }
                        fr.HttpRawRequest.SetActuatorStaticDataCollection(StaticDataCollection);
                    }
                }
            }
            if(!rawResponseEdit.SetContextMenuStrip(contextMenuStrip_AddFile))
            {
                MessageBox.Show("RawResponseEdit SetContextMenuStrip fail");
            }
            
        }
        

        /// <summary>
        /// On get the http session button click
        /// </summary>
        public event EventHandler OnUpdataFromSession;
        /// <summary>
        /// On get the raw http data link click   (EventHandler<GetSessionRawDataEventArgs>)
        /// </summary>
        public event GetSessionRawDataEventHandler OnGetSessionRawData;

        /// <summary>
        /// find your seek head vaule in session (only use in synchronization)
        /// </summary>
        public event EventHandler<GetSessionSeekHeadEventArgs> OnGetSessionSeekHead;

        /// <summary>
        /// get select session info
        /// </summary>
        public event EventHandler<GetSessionEventArgs> OnGetSessionEventArgs;

        //public 

        /// <summary>
        /// get or set ModificSettingInfo
        /// </summary>
        public FiddlerModificSettingInfo ModificSettingInfo { get;  set; }

        /// <summary>
        /// get or set ModificSettingInfo
        /// </summary>
        public ActuatorStaticDataCollection StaticDataCollection { get; set; }

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

        FiddlerModificHttpRuleCollection fiddlerModificHttpRuleCollection;
        bool isSetResponseLatencyEable;


        private void FreeHttpWindow_Load(object sender, EventArgs e)
        {
            try
            {
                LoadFiddlerModificHttpRuleCollection(fiddlerModificHttpRuleCollection);
            }
            catch(Exception ex)
            {
                MessageBox.Show(string.Format("{0}\r\n{1}", ex.Message, ex.InnerException==null? "":ex.InnerException.Message), "load user rule fail");
                if (File.Exists("RuleData.xml"))
                {
                    File.Copy("RuleData.xml", "RuleData.lastErrorFile", true);
                }
            }
            if (StaticDataCollection == null)
            {
                StaticDataCollection = new ActuatorStaticDataCollection(true);
            }
            if(ModificSettingInfo==null)
            {
                ModificSettingInfo = new FiddlerModificSettingInfo(false, true, true);
            }
            if(ModificSettingInfo.IsDefaultEnableRule)
            {
                pb_requestRuleSwitch_Click(null, null);
                pb_responseRuleSwitch_Click(null, null);
            }

            FreeHttp.MyHelper.MyGlobalHelper.OnGetGlobalMessage += ((obj, arg) => { PutWarn(arg.Message); });
            
            tbe_RequestBodyModific.Visible = false;
            tbe_ResponseBodyModific.Visible = false;
            tbe_urlFilter.Visible = false;
            tbe_RequestBodyModific.OnCloseEditBox += tbe_BodyModific_OnCloseEditBox;
            tbe_ResponseBodyModific.OnCloseEditBox += tbe_BodyModific_OnCloseEditBox;
            tbe_urlFilter.OnCloseEditBox += tbe_BodyModific_OnCloseEditBox;


            cb_macthMode.SelectedIndex = 0;
            tabControl_Modific.SelectedIndex = 0;
            IsSetResponseLatencyEable = false;

            //rtb_MesInfo.AllowDrop = true;
            //rtb_MesInfo.DragEnter += rtb_MesInfo_DragEnter;
            //rtb_MesInfo.DragDrop += rtb_MesInfo_DragDrop;

            splitContainer_httpEditInfo.AllowDrop = true;
            splitContainer_httpEditInfo.DragEnter += rtb_MesInfo_DragEnter;
            splitContainer_httpEditInfo.DragDrop += rtb_MesInfo_DragDrop;

            panel_modific_Contorl.AllowDrop = true;
            panel_modific_Contorl.DragEnter += rtb_MesInfo_DragEnter;
            panel_modific_Contorl.DragDrop += rtb_MesInfo_DragDrop;

            MyControlHelper.SetRichTextBoxDropString(rtb_requsetReplace_body);
            MyControlHelper.SetRichTextBoxDropString(rtb_requestRaw);
        }

        #region Public Event
        private void tabControl_Modific_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if(NowEditMode== RuleEditMode.EditRequsetRule)
            {
                if (((TabControl)sender).SelectedIndex == 2 || ((TabControl)sender).SelectedIndex == 3)
                {
                    MessageBox.Show("the select requst rule is in editing (that pink rule in rule list) \r\nyou should save or cancel this editing before edit response", "STOP");
                    e.Cancel = true;
                }
            }
            else if(NowEditMode== RuleEditMode.EditResponseRule)
            {
                if (((TabControl)sender).SelectedIndex == 0 || ((TabControl)sender).SelectedIndex == 1)
                {
                    MessageBox.Show("the select response rule is in editing (that pink rule in rule list)\r\nyou should save or cancel this editing before edit requst", "STOP");
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
                tempRtb = sourceControl as RichTextBox;
                if (tempRtb == null)
                {
                    //throw new Exception("not adapt this event");
                    MessageBox.Show("get file fail , please try again or add manually");
                    return;
                }
            }

            if (openFileDialog_addFIle.ShowDialog() == DialogResult.OK)
            {
                string tempPath = openFileDialog_addFIle.FileName;
                int tempIndex = tempRtb.Text.IndexOf("<<replace file path>>");
                if (tempIndex >= 0)
                {
                    tempRtb.Text = tempRtb.Text.Remove(tempIndex);
                }

                if (!tempRtb.Text.EndsWith("\n\n") && tempRtb != rtb_requsetReplace_body)
                {
                    if (tempRtb.Text.EndsWith("\n"))
                    {
                        tempRtb.AppendText("\n");
                    }
                    else
                    {
                        tempRtb.AppendText("\n\n");
                    }
                }

                tempRtb.AppendText(string.Format("<<replace file path>>{0}", tempPath));
            }
        }

        private void contextMenuStrip_addParameter_Opening(object sender, CancelEventArgs e)
        {
            ((System.Windows.Forms.ToolStripDropDown)(sender)).Tag = ((ToolStripDropDown)(sender)).OwnerItem;
        }

        private void contextMenuStrip_AddFile_Opening(object sender, CancelEventArgs e)
        {
            ((ContextMenuStrip)sender).Tag = ((ContextMenuStrip)sender).SourceControl;
        }

        private void addParameterDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string additionStr = null;
            string addParameterStr = null;
            if(sender ==currentValueToolStripMenuItem)
            {
                additionStr = "(=)";
            }
            else if (sender == nextValueToolStripMenuItem)
            {
                additionStr = "(+)";
            }
            else if (sender == previousValueToolStripMenuItem)
            {
                additionStr = "(-)";
            }
            else
            {
                return;
            }
            if(((System.Windows.Forms.ToolStripItem)(sender)).Owner.Tag==null)
            {
                MessageBox.Show("add parameter fail ,please add manually");
                return;
            }
            object tempTag = ((System.Windows.Forms.ToolStripItem)(sender)).Owner.Tag;
            addParameterStr = string.Format("*#{0}{1}*#", ((ToolStripItem)tempTag).Text, additionStr);
            //there is a bug in dot net 4.5 when call SourceControl (https://github.com/Microsoft/dotnet/issues/434 )
            //RichTextBox tempRichTextBox = ((ContextMenuStrip)((((ToolStripItem)(tempTag)).OwnerItem).OwnerItem.Owner)).SourceControl as RichTextBox;
            RichTextBox tempRichTextBox = ((ContextMenuStrip)((((ToolStripItem)(tempTag)).OwnerItem).OwnerItem.Owner)).Tag as RichTextBox;
            if(tempRichTextBox==null)
            {
                MessageBox.Show("add parameter fail ,please add manually");
                return ;
            }
            int selectionStart = tempRichTextBox.SelectionStart;
            tempRichTextBox.Text = tempRichTextBox.Text.Insert(selectionStart, addParameterStr);
            tempRichTextBox.Select(selectionStart, addParameterStr.Length);
            useParameterDataToolStripMenuItem.Checked = true;
        }


        private void addParameterDataToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            keyValueToolStripMenuItem.DropDownItems.Clear();
            parameterToolStripMenuItem.DropDownItems.Clear();
            dataSouceToolStripMenuItem.DropDownItems.Clear();
            if(StaticDataCollection==null)
            {
                return;
            }
            if (StaticDataCollection.RunActuatorStaticDataKeyList != null && StaticDataCollection.RunActuatorStaticDataKeyList.Count>0)
            {
                foreach(var tempItem in StaticDataCollection.RunActuatorStaticDataKeyList)
                {
                    //keyValueToolStripMenuItem.DropDownItems.Add(tempItem.Key);
                    ToolStripMenuItem tempTmi = new ToolStripMenuItem(tempItem.Key);
                    tempTmi.DropDown = contextMenuStrip_addParameter;
                    keyValueToolStripMenuItem.DropDownItems.Add(tempTmi);
                    
                }
                keyValueToolStripMenuItem.Enabled = true;
            }
            else
            {
                keyValueToolStripMenuItem.Enabled = false;
            }
            if (StaticDataCollection.RunActuatorStaticDataParameterList != null && StaticDataCollection.RunActuatorStaticDataParameterList.Count > 0)
            {
                foreach (var tempItem in StaticDataCollection.RunActuatorStaticDataParameterList)
                {
                    //parameterToolStripMenuItem.DropDownItems.Add(tempItem.Key);
                    ToolStripMenuItem tempTmi = new ToolStripMenuItem(tempItem.Key);
                    tempTmi.DropDown = contextMenuStrip_addParameter;
                    parameterToolStripMenuItem.DropDownItems.Add(tempTmi);
                }
                parameterToolStripMenuItem.Enabled = true;
            }
            else
            {
                parameterToolStripMenuItem.Enabled = false;
            }
            if (StaticDataCollection.RunActuatorStaticDataSouceList != null && StaticDataCollection.RunActuatorStaticDataSouceList.Count > 0)
            {
                foreach (var tempItem in StaticDataCollection.RunActuatorStaticDataSouceList)
                {
                    //dataSouceToolStripMenuItem.DropDownItems.Add(tempItem.Key);
                    ToolStripMenuItem tempTmi = new ToolStripMenuItem(tempItem.Key);
                    tempTmi.DropDown = contextMenuStrip_addParameter;
                    dataSouceToolStripMenuItem.DropDownItems.Add(tempTmi);
                }
                dataSouceToolStripMenuItem.Enabled = true;
            }
            else
            {
                dataSouceToolStripMenuItem.Enabled = false;
            }
        }

        private void antoContentLengthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            antoContentLengthToolStripMenuItem.Checked = !antoContentLengthToolStripMenuItem.Checked;
        }

        private void useParameterDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            useParameterDataToolStripMenuItem.Checked = !useParameterDataToolStripMenuItem.Checked;
        }

        private void pictureBox_editRuleMode_Click(object sender, EventArgs e)
        {
            pb_ruleComfrim_Click(sender, e);
        }
        private void pictureBox_editHttpFilter_Click(object sender, EventArgs e)
        {

            pictureBox_editHttpFilter.Tag = GetHttpFilter();

            HttpFilterWindow f = new HttpFilterWindow(pictureBox_editHttpFilter.Tag);
            f.ShowDialog();

            if (((FiddlerHttpFilter)pictureBox_editHttpFilter.Tag).HeadMatch != null || ((FiddlerHttpFilter)pictureBox_editHttpFilter.Tag).BodyMatch != null)
            {
                pictureBox_editHttpFilter.Image = Resources.MyResource.filter_on;
            }
            else
            {
                pictureBox_editHttpFilter.Image = Resources.MyResource.filter_off;
            }
            SetUriMatch(((FiddlerHttpFilter)pictureBox_editHttpFilter.Tag).UriMatch);
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
            tb_urlFilter.Width = tabControl_Modific.Width - 275;

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
            FiddlerRequestChange nowRequestChange = null;
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
                PutError(string.Format("add rule fail :{0}", ex.Message));
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

            if (fiddlerHttpTamper.HttpFilter == null || fiddlerHttpTamper.HttpFilter.UriMatch == null)
            {
                MessageBox.Show("you Uri Filter is not legal \r\n check it again", "edit again");
                MarkControl(groupBox_urlFilter, Color.Plum, 2);
                return;
            }

            ListViewItem nowRuleItem = null;
            foreach (ListViewItem tempItem in tamperRuleListView.Items)
            {
                if (tempItem == EditListViewItem)
                {
                    continue;
                }
                //if (fiddlerHttpTamper.HttpFilter.UriMatch.Equals(tempItem.Tag))
                if (fiddlerHttpTamper.HttpFilter.Equals(tempItem.Tag))
                {
                    MarkRuleItem(tempItem, Color.Plum, 2);
                    DialogResult tempDs;
                    //add mode
                    if (EditListViewItem == null)
                    {
                        tempDs = MessageBox.Show(string.Format("find same url filter with [Rule:{0}], do you want create the same uri rule \r\n    [Yes]       new a same url filter rule \r\n    [No]       update the rule \r\n    [Cancel]  give up save", tempItem.SubItems[0].Text), "find same rule ", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        if (tempDs == DialogResult.Yes)
                        {
                            continue; 
                        }
                        else if (tempDs == DialogResult.No)
                        {
                            nowRuleItem = tempItem;
                            SyncEnableSateToIFiddlerHttpTamper(nowRuleItem, fiddlerHttpTamper);
                            UpdataRuleToListView(nowRuleItem, fiddlerHttpTamper, true);
                            break;
                        }
                        else
                        {
                            return;
                        }
                    }
                    //edit mode
                    else
                    {
                        tempDs = MessageBox.Show(string.Format("find same uri filter with [Rule:{0}], do you want save the rule \r\n    [Yes]       skip the same uri filter rule \r\n    [No]       remove the rule \r\n    [Cancel]  give up save", tempItem.SubItems[0].Text), "find same rule ", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        if (tempDs == DialogResult.Yes)
                        {
                            continue;
                        }
                        else if (tempDs == DialogResult.No)
                        {
                            tamperRuleListView.Items.Remove(tempItem);
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
                SetVaule f = new SetVaule("Set Latency", "Enter the exact number of milliseconds by which to delay the response", sender == pb_responseLatency ? "0" : lbl_ResponseLatency.GetLatency().ToString(), new Func<string, bool>((string checkValue) => { int tempValue; if (checkValue == "") return true; return (int.TryParse(checkValue, out tempValue) && tempValue>=0); }));
                f.OnSetValue += f_OnSetValue;
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Can not set latency  in reqest modific mode\r\njust change to response modific mode", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void pb_pickRule_Click(object sender, EventArgs e)
        {
            EditParameterPickWindow f;
            if(pb_pickRule.Tag is List<ParameterPick>)
            {
                f = new EditParameterPickWindow((List<ParameterPick>)pb_pickRule.Tag, SetHttpParameterPick);
            }
            else
            {
                f = new EditParameterPickWindow(null,SetHttpParameterPick);
            }
            f.StartPosition = FormStartPosition.CenterParent;
            f.ShowDialog();
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
                //DialogResult dialogResult ;
                if (MessageBox.Show("your are in Response Edit Mode.\r\ndo you want give up the editing and new a rule to continue this quick rule?", "Continue or not", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    pb_ruleCancel_Click(this, e);
                }
                else
                {
                    return;
                }
            }
            tabControl_Modific.SelectedIndex = 0;
            requestRemoveHeads.ListDataView.Items.Add("Pragma");
            //requestRemoveHeads.ListDataView.Items.Add("Expires");//If there is a Cache-Control header with the max-age or s-maxage directive in the response, the Expires header is ignored.   <Expires: Wed, 21 Oct 2018 15:28:00 GMT>   Expires是一个响应头
            requestRemoveHeads.ListDataView.Items.Add("Cache-Control");
            //requestRemoveHeads.ListDataView.Items.Add("ETag");//ETag 也是HTTP响应头。 与If-None-Match 完成缓存验证 ，与 If-Match 请求头部，检测到"空中碰撞"的编辑冲突。
            //requestRemoveHeads.ListDataView.Items.Add("Last-Modified");//Last-Modified  是一个响应首部，其中包含源头服务器认定的资源做出修改的日期及时间。 它通常被用作一个验证器来判断接收到的或者存储的资源是否彼此一致。由于精确度比  ETag 要低，所以这是一个备用机制。包含有  If-Modified-Since 或 If-Unmodified-Since 首部的条件请求会使用这个字段。
            requestRemoveHeads.ListDataView.Items.Add("If-None-Match");
            requestRemoveHeads.ListDataView.Items.Add("If-Modified-Since");
            requestAddHeads.ListDataView.Items.Add("Pragma: no-cache");
            requestAddHeads.ListDataView.Items.Add("Cache-Control: no-cache");

            if (tb_urlFilter.Text == "")
            {
                GetSessionEventArgs sessionArgs = GetNowHttpSession();
                if(sessionArgs.IsGetSuccess&& sessionArgs.Uri!=null)
                {
                    SetUriMatch(new FiddlerUriMatch(FiddlerUriMatchMode.Is, sessionArgs.Uri));
                }
            }
        }

        private void addCookieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (NowEditMode == RuleEditMode.EditResponseRule)
            {
                if (MessageBox.Show("your are in Response Edit Mode.\r\ndo you want give up the editing and new a rule to continue this quick rule?", "Continue or not", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    pb_ruleCancel_Click(this, e);
                }
                else
                {
                    return;
                }
            }
            tabControl_Modific.SelectedIndex = 0;
            EditKeyVaule f = new EditKeyVaule(requestAddHeads.ListDataView, "Cookie", ": ");
            f.ShowDialog();
        }

        private void addUserAgentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (NowEditMode == RuleEditMode.EditResponseRule)
            {
                if (MessageBox.Show("your are in Response Edit Mode.\r\ndo you want give up the editing and new a rule to continue this quick rule?", "Continue or not", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    pb_ruleCancel_Click(this, e);
                }
                else
                {
                    return;
                }
            }
            tabControl_Modific.SelectedIndex = 0;
            requestRemoveHeads.ListDataView.Items.Add("User-Agent");
            EditKeyVaule f = new EditKeyVaule(requestAddHeads.ListDataView, "User-Agent", ": ");
            f.ShowDialog();
        }
        private void ChangeSessionEncodingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetSessionSeekHeadEventArgs seekHeadArgs = new GetSessionSeekHeadEventArgs(new KeyValuePair<string, string>("Content-Type", null), new KeyValuePair<string, string>("Content-Type", null));
            if(OnGetSessionSeekHead!=null)
            {
                this.OnGetSessionSeekHead(this,seekHeadArgs);
            }
            ChangeEncodeForm.ChangeEncodeInfo changeEncodeInfo = new ChangeEncodeForm.ChangeEncodeInfo { ContentType_Request= seekHeadArgs.ResquestHead.Value, ContentType_Response= seekHeadArgs.ResponseHead.Value, NowEncode=null, EditMode = NowEditMode };
            ChangeEncodeForm f = new ChangeEncodeForm(changeEncodeInfo);
            DialogResult dialogResult =  f.ShowDialog();

            if(string.IsNullOrEmpty(changeEncodeInfo.NowEncode))
            {
                return;
            }
            if (changeEncodeInfo.ContentType_Request == null)
            {
                FiddlerResponseChange responseChange = new FiddlerResponseChange();
                if (seekHeadArgs.SeekUri != null)
                {
                    responseChange.HttpFilter = new FiddlerHttpFilter(new FiddlerUriMatch(FiddlerUriMatchMode.Is, seekHeadArgs.SeekUri));
                }
                responseChange.HeadDelList = new List<string> { "Content-Type" };
                responseChange.HeadAddList = new List<string>{string.Format("Content-Type: {0}", changeEncodeInfo.ContentType_Response)};
                responseChange.BodyModific = new ContentModific(string.Format("<recode>{0}", changeEncodeInfo.NowEncode), "");
                SetResponseModificInfo(responseChange);
            }
            else
            {
                FiddlerRequestChange requestChange = new FiddlerRequestChange();
                if (seekHeadArgs.SeekUri != null)
                {
                    requestChange.HttpFilter = new FiddlerHttpFilter(new FiddlerUriMatch(FiddlerUriMatchMode.Is, seekHeadArgs.SeekUri));
                }
                requestChange.HeadDelList = new List<string> { "Content-Type" };
                requestChange.HeadAddList = new List<string> { string.Format("Content-Type: {0}", changeEncodeInfo.ContentType_Request) };
                requestChange.BodyModific = new ContentModific(string.Format("<recode>{0}", changeEncodeInfo.NowEncode), "");
                SetRequestModificInfo(requestChange);
            }
        }
        private void deleteCookieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (NowEditMode == RuleEditMode.EditRequsetRule)
            {
                if (MessageBox.Show("your are in Request Edit Mode.\r\ndo you want give up the editing and new a rule to continue this quick rule?", "Continue or not", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    pb_ruleCancel_Click(this, e);
                }
                else
                {
                    return;
                }
            }
            tabControl_Modific.SelectedIndex = 2;

            string tempDomain = String.Empty;
            GetSessionEventArgs sessionArgs = GetNowHttpSession();
            if (sessionArgs.IsGetSuccess && sessionArgs.RequestHeads!=null)
            {
                try
                {
                    tempDomain = sessionArgs.RequestHeads.First(headerItem => headerItem.Key.Trim().ToLower() == "host").Value.Trim();
                }
                catch
                {
                    tempDomain = "www.yourhost.com";
                }
            }

            EditCookieForm f = new EditCookieForm(responseAddHeads.ListDataView, null, null, string.Format("Max-Age=1;Domain={0};Path=/", tempDomain));
            f.ShowDialog();
            if (tb_urlFilter.Text == "")
            {
                if (sessionArgs.IsGetSuccess && sessionArgs.Uri != null)
                {
                    SetUriMatch(new FiddlerUriMatch(FiddlerUriMatchMode.Is, sessionArgs.Uri));
                }
            }
        }

        private void setClientCookieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (NowEditMode == RuleEditMode.EditRequsetRule)
            {
                if (MessageBox.Show("your are in Request Edit Mode.\r\ndo you want give up the editing and new a rule to continue this quick rule?", "Continue or not", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    pb_ruleCancel_Click(this, e);
                }
                else
                {
                    return;
                }
            }
            tabControl_Modific.SelectedIndex =2;
            EditCookieForm f = new EditCookieForm(responseAddHeads.ListDataView);
            f.ShowDialog();
        }

        private void copySessionCookiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (NowEditMode == RuleEditMode.EditRequsetRule)
            {
                if (MessageBox.Show("your are in Request Edit Mode.\r\ndo you want give up the editing and new a rule to continue this quick rule?", "Continue or not", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    pb_ruleCancel_Click(this, e);
                }
                else
                {
                    return;
                }
            }
            tabControl_Modific.SelectedIndex = 2;
            if (OnGetSessionRawData != null)
            {
                this.OnGetSessionRawData(this, new GetSessionRawDataEventArgs(GetSessionAction.SetCookies));
            }
             
        }

        private void removeSessionCookiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (NowEditMode == RuleEditMode.EditRequsetRule)
            {
                if (MessageBox.Show("your are in Request Edit Mode.\r\ndo you want give up the editing and new a rule to continue this quick rule?", "Continue or not", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    pb_ruleCancel_Click(this, e);
                }
                else
                {
                    return;
                }
            }
            tabControl_Modific.SelectedIndex = 2;
            if (OnGetSessionRawData != null)
            {
                this.OnGetSessionRawData(this, new GetSessionRawDataEventArgs(GetSessionAction.DeleteCookies));
            }
        }
        private void showSelectedSessionStreamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(OnGetSessionRawData!=null)
            {
                this.OnGetSessionRawData(this, new GetSessionRawDataEventArgs(GetSessionAction.ShowShowResponse));
            }
        }

        private void httpTamperSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingWindow f = new SettingWindow(ModificSettingInfo);
            f.ShowDialog();
        }

        private void parameterDataManageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form tempFrom in (Fiddler.FiddlerApplication.UI).OwnedForms)
            {
                if (tempFrom is StaticDataManageWindow)
                {
                    tempFrom.Location = new Point((System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width - tempFrom.Width) / 2, (System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height-tempFrom.Height) / 2);
                    return;
                }
            }
            StaticDataManageWindow staticDataManageWindow;
            staticDataManageWindow = new StaticDataManageWindow(StaticDataCollection);
            staticDataManageWindow.Owner = Fiddler.FiddlerApplication.UI;
            staticDataManageWindow.StartPosition = FormStartPosition.CenterScreen;
            //f.ShowDialog();
            staticDataManageWindow.Show();
        }

        private void FeedbackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserFeedbackWindow f = new UserFeedbackWindow(this);
            f.StartPosition = FormStartPosition.CenterParent;
            f.ShowDialog();
        }

        private void CodeInGithubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/lulianqi/FreeHttp");
        }

        private void DocumentationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://doc.lulianqi.com/FreeHttp/Documentation/recent");
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
                    SetRequestModificInfo((FiddlerRequestChange)nowListViewItem.Tag);

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
                nowListViewItem.ListView.SelectedItems.Clear();
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
                tabControl_Modific.SelectedIndex = 0;
                MarkTipControl(tabPage_requestModific);
                //MarkControl(pb_getSession, Color.MediumSpringGreen, 1);
            }
            else if (sender == pb_addResponseRule)
            {
                ChangeEditRuleMode(RuleEditMode.NewRuleMode, null, null);
                tabControl_Modific.SelectedIndex = 2;
                MarkTipControl(tabPage_responseModific);
                //MarkControl(pb_getSession, Color.MediumSpringGreen, 1);
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
            if (OnUpdataFromSession != null)
            {
                this.OnUpdataFromSession(this, null);
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

        private void tb_urlFilter_DragEnter(object sender, DragEventArgs e)
        {
            Fiddler.Session[] draggedSessions = (Fiddler.Session[])e.Data.GetData(typeof(Fiddler.Session[]));
            e.Effect = (draggedSessions == null || draggedSessions.Length < 1) ? DragDropEffects.None : e.AllowedEffect;
        }

        private void tb_urlFilter_DragDrop(object sender, DragEventArgs e)
        {
            Fiddler.Session[] draggedSessions = (Fiddler.Session[])e.Data.GetData(typeof(Fiddler.Session[]));
            if (draggedSessions != null && draggedSessions.Length > 0)
            {
                tb_urlFilter.Text = draggedSessions[0].fullUrl;
            }
        }

        void rtb_MesInfo_DragEnter(object sender, DragEventArgs e)
        {
            Fiddler.Session[] draggedSessions = (Fiddler.Session[])e.Data.GetData(typeof(Fiddler.Session[]));
            e.Effect = (draggedSessions == null || draggedSessions.Length < 1) ? DragDropEffects.None : e.AllowedEffect;
        }
        void rtb_MesInfo_DragDrop(object sender, DragEventArgs e)
        {
            Fiddler.Session[] draggedSessions = (Fiddler.Session[])e.Data.GetData(typeof(Fiddler.Session[]));
            if (draggedSessions != null && draggedSessions.Length > 0)
            {
                for(int i =0;i<draggedSessions.Length;i++)
                {
                    string tempStr = FiddlerSessionTamper.GetSessionRawData(draggedSessions[i], true);
                    PutInfo(tempStr == null ? "error session" : string.Format("Get Raw Data\r\n{0}", tempStr));
                }
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
