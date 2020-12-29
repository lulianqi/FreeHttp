using FreeHttp;

namespace FreeHttp.FreeHttpControl
{
    partial class FreeHttpWindow
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FreeHttpWindow));
            this.imageList_forTab = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip_AddFile = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator_addAndCheck = new System.Windows.Forms.ToolStripSeparator();
            this.antoContentLengthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog_addFIle = new System.Windows.Forms.OpenFileDialog();
            this.splitContainer_main = new System.Windows.Forms.SplitContainer();
            this.splitContainer_httpEditInfo = new System.Windows.Forms.SplitContainer();
            this.rtb_MesInfo = new System.Windows.Forms.RichTextBox();
            this.groupBox_urlFilter = new System.Windows.Forms.GroupBox();
            this.tb_urlFilter = new System.Windows.Forms.TextBox();
            this.lb_editRuleMode = new System.Windows.Forms.Label();
            this.cb_macthMode = new System.Windows.Forms.ComboBox();
            this.splitContainer_httpControl = new System.Windows.Forms.SplitContainer();
            this.contextMenu_ruleList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolTip_forMainWindow = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuStrip_addParameter = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panel_modific = new FreeHttp.FreeHttpControl.MyPanel();
            this.tabControl_Modific = new System.Windows.Forms.TabControl();
            this.tabPage_requestModific = new System.Windows.Forms.TabPage();
            this.splitContainer_requestModific = new System.Windows.Forms.SplitContainer();
            this.groupBox_headsModific = new System.Windows.Forms.GroupBox();
            this.requestAddHeads = new FreeHttp.FreeHttpControl.EditListView();
            this.requestRemoveHeads = new FreeHttp.FreeHttpControl.EditListView();
            this.groupBox_bodyModific = new System.Windows.Forms.GroupBox();
            this.panel2 = new FreeHttp.FreeHttpControl.MyPanel();
            this.rtb_requestModific_body = new System.Windows.Forms.RichTextBox();
            this.panel1 = new FreeHttp.FreeHttpControl.MyPanel();
            this.tbe_RequestBodyModific = new FreeHttp.FreeHttpControl.TextBoxEditer();
            this.tb_requestModific_body = new FreeHttp.FreeHttpControl.WatermakTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox_uriModific = new System.Windows.Forms.GroupBox();
            this.tb_requestModific_uriModificKey = new FreeHttp.FreeHttpControl.WatermakTextBox();
            this.tb_requestModific_uriModificValue = new System.Windows.Forms.TextBox();
            this.tabPage_requestReplace = new System.Windows.Forms.TabPage();
            this.splitContainer_requestReplace = new System.Windows.Forms.SplitContainer();
            this.elv_requsetReplace = new FreeHttp.FreeHttpControl.EditListView();
            this.rtb_requsetReplace_body = new System.Windows.Forms.RichTextBox();
            this.rtb_requestRaw = new System.Windows.Forms.RichTextBox();
            this.panel_requestReplace_startLine = new FreeHttp.FreeHttpControl.MyPanel();
            this.lb_editStartLine = new System.Windows.Forms.Label();
            this.tb_requestReplace_uri = new FreeHttp.FreeHttpControl.WatermakTextBox();
            this.cb_editRequestMethod = new System.Windows.Forms.ComboBox();
            this.cb_editRequestEdition = new System.Windows.Forms.ComboBox();
            this.tabPage_responseModific = new System.Windows.Forms.TabPage();
            this.splitContainer_responseModific = new System.Windows.Forms.SplitContainer();
            this.groupBox_reponseHeadModific = new System.Windows.Forms.GroupBox();
            this.responseAddHeads = new FreeHttp.FreeHttpControl.EditListView();
            this.responseRemoveHeads = new FreeHttp.FreeHttpControl.EditListView();
            this.groupBox_responseBodyModific = new System.Windows.Forms.GroupBox();
            this.panel3 = new FreeHttp.FreeHttpControl.MyPanel();
            this.rtb_respenseModific_body = new System.Windows.Forms.RichTextBox();
            this.panel4 = new FreeHttp.FreeHttpControl.MyPanel();
            this.tbe_ResponseBodyModific = new FreeHttp.FreeHttpControl.TextBoxEditer();
            this.tb_responseModific_body = new FreeHttp.FreeHttpControl.WatermakTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage_responseReplace = new System.Windows.Forms.TabPage();
            this.rawResponseEdit = new FreeHttp.FreeHttpControl.RawResponseEdit();
            this.panel_modific_Contorl = new FreeHttp.FreeHttpControl.MyPanel();
            this.lbl_ResponseLatency = new System.Windows.Forms.LinkLabel();
            this.menuStrip_quickRule = new System.Windows.Forms.MenuStrip();
            this.quickRuleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbe_urlFilter = new FreeHttp.FreeHttpControl.TextBoxEditer();
            this.lv_requestRuleList = new FreeHttp.FreeHttpControl.MyListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_requstRule = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lv_responseRuleList = new FreeHttp.FreeHttpControl.MyListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_responseRule = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.addFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addParameterDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keyValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parameterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataSouceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.editDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pb_requestReplace_changeMode = new System.Windows.Forms.PictureBox();
            this.pb_parameterSwitch = new FreeHttp.FreeHttpControl.MySwitchPictureButton();
            this.pb_protocolSwitch = new FreeHttp.FreeHttpControl.MySwitchPictureButton();
            this.pb_pickRule = new System.Windows.Forms.PictureBox();
            this.pb_responseLatency = new System.Windows.Forms.PictureBox();
            this.pb_ruleComfrim = new System.Windows.Forms.PictureBox();
            this.pb_ruleCancel = new System.Windows.Forms.PictureBox();
            this.disableCacheToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addCookieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteCookieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setClientCookieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copySessionCookiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeSessionCookiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addUserAgentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeSessionEncodingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.independentWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showSelectedSessionStreamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parameterDataManageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.httpTamperSettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadingRemoteRuleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.feedbackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.codeInGithubToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.documentationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox_editHttpFilter = new System.Windows.Forms.PictureBox();
            this.pictureBox_editRuleMode = new System.Windows.Forms.PictureBox();
            this.pb_getSession = new System.Windows.Forms.PictureBox();
            this.pb_addRequestRule = new System.Windows.Forms.PictureBox();
            this.pb_removeRequestRule = new System.Windows.Forms.PictureBox();
            this.pb_requestRuleSwitch = new System.Windows.Forms.PictureBox();
            this.removeSelectedRuleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeAllRuleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableThisRuleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableAllRuleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unableAllRuleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editThisRuleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copySelectedRuleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pb_addResponseRule = new System.Windows.Forms.PictureBox();
            this.pb_removeResponseRule = new System.Windows.Forms.PictureBox();
            this.pb_responseRuleSwitch = new System.Windows.Forms.PictureBox();
            this.currentValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nextValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.previousValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip_AddFile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_main)).BeginInit();
            this.splitContainer_main.Panel1.SuspendLayout();
            this.splitContainer_main.Panel2.SuspendLayout();
            this.splitContainer_main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_httpEditInfo)).BeginInit();
            this.splitContainer_httpEditInfo.Panel1.SuspendLayout();
            this.splitContainer_httpEditInfo.Panel2.SuspendLayout();
            this.splitContainer_httpEditInfo.SuspendLayout();
            this.groupBox_urlFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_httpControl)).BeginInit();
            this.splitContainer_httpControl.Panel1.SuspendLayout();
            this.splitContainer_httpControl.Panel2.SuspendLayout();
            this.splitContainer_httpControl.SuspendLayout();
            this.contextMenu_ruleList.SuspendLayout();
            this.contextMenuStrip_addParameter.SuspendLayout();
            this.panel_modific.SuspendLayout();
            this.tabControl_Modific.SuspendLayout();
            this.tabPage_requestModific.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_requestModific)).BeginInit();
            this.splitContainer_requestModific.Panel1.SuspendLayout();
            this.splitContainer_requestModific.Panel2.SuspendLayout();
            this.splitContainer_requestModific.SuspendLayout();
            this.groupBox_headsModific.SuspendLayout();
            this.groupBox_bodyModific.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox_uriModific.SuspendLayout();
            this.tabPage_requestReplace.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_requestReplace)).BeginInit();
            this.splitContainer_requestReplace.Panel1.SuspendLayout();
            this.splitContainer_requestReplace.Panel2.SuspendLayout();
            this.splitContainer_requestReplace.SuspendLayout();
            this.panel_requestReplace_startLine.SuspendLayout();
            this.tabPage_responseModific.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_responseModific)).BeginInit();
            this.splitContainer_responseModific.Panel1.SuspendLayout();
            this.splitContainer_responseModific.Panel2.SuspendLayout();
            this.splitContainer_responseModific.SuspendLayout();
            this.groupBox_reponseHeadModific.SuspendLayout();
            this.groupBox_responseBodyModific.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tabPage_responseReplace.SuspendLayout();
            this.panel_modific_Contorl.SuspendLayout();
            this.menuStrip_quickRule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_requestReplace_changeMode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_parameterSwitch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_protocolSwitch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_pickRule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_responseLatency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_ruleComfrim)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_ruleCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_editHttpFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_editRuleMode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_getSession)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_addRequestRule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_removeRequestRule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_requestRuleSwitch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_addResponseRule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_removeResponseRule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_responseRuleSwitch)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList_forTab
            // 
            this.imageList_forTab.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_forTab.ImageStream")));
            this.imageList_forTab.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_forTab.Images.SetKeyName(0, "request_modific.png");
            this.imageList_forTab.Images.SetKeyName(1, "request_replace.png");
            this.imageList_forTab.Images.SetKeyName(2, "response_modific.png");
            this.imageList_forTab.Images.SetKeyName(3, "response_replace.png");
            this.imageList_forTab.Images.SetKeyName(4, "ws_replace.png");
            // 
            // contextMenuStrip_AddFile
            // 
            this.contextMenuStrip_AddFile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addFileToolStripMenuItem,
            this.addParameterDataToolStripMenuItem,
            this.toolStripSeparator_addAndCheck,
            this.antoContentLengthToolStripMenuItem});
            this.contextMenuStrip_AddFile.Name = "contextMenuStrip_AddFile";
            this.contextMenuStrip_AddFile.Size = new System.Drawing.Size(196, 76);
            this.contextMenuStrip_AddFile.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_AddFile_Opening);
            // 
            // toolStripSeparator_addAndCheck
            // 
            this.toolStripSeparator_addAndCheck.Name = "toolStripSeparator_addAndCheck";
            this.toolStripSeparator_addAndCheck.Size = new System.Drawing.Size(192, 6);
            // 
            // antoContentLengthToolStripMenuItem
            // 
            this.antoContentLengthToolStripMenuItem.Checked = true;
            this.antoContentLengthToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.antoContentLengthToolStripMenuItem.Name = "antoContentLengthToolStripMenuItem";
            this.antoContentLengthToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.antoContentLengthToolStripMenuItem.Text = "anto Content-Length";
            this.antoContentLengthToolStripMenuItem.Click += new System.EventHandler(this.antoContentLengthToolStripMenuItem_Click);
            // 
            // openFileDialog_addFIle
            // 
            this.openFileDialog_addFIle.FileName = "openFileDialog";
            // 
            // splitContainer_main
            // 
            this.splitContainer_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_main.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_main.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.splitContainer_main.Name = "splitContainer_main";
            // 
            // splitContainer_main.Panel1
            // 
            this.splitContainer_main.Panel1.Controls.Add(this.splitContainer_httpEditInfo);
            this.splitContainer_main.Panel1.Controls.Add(this.groupBox_urlFilter);
            // 
            // splitContainer_main.Panel2
            // 
            this.splitContainer_main.Panel2.Controls.Add(this.splitContainer_httpControl);
            this.splitContainer_main.Size = new System.Drawing.Size(966, 552);
            this.splitContainer_main.SplitterDistance = 609;
            this.splitContainer_main.TabIndex = 0;
            // 
            // splitContainer_httpEditInfo
            // 
            this.splitContainer_httpEditInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_httpEditInfo.Location = new System.Drawing.Point(0, 44);
            this.splitContainer_httpEditInfo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.splitContainer_httpEditInfo.Name = "splitContainer_httpEditInfo";
            this.splitContainer_httpEditInfo.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer_httpEditInfo.Panel1
            // 
            this.splitContainer_httpEditInfo.Panel1.Controls.Add(this.panel_modific);
            // 
            // splitContainer_httpEditInfo.Panel2
            // 
            this.splitContainer_httpEditInfo.Panel2.Controls.Add(this.rtb_MesInfo);
            this.splitContainer_httpEditInfo.Size = new System.Drawing.Size(609, 508);
            this.splitContainer_httpEditInfo.SplitterDistance = 356;
            this.splitContainer_httpEditInfo.TabIndex = 7;
            // 
            // rtb_MesInfo
            // 
            this.rtb_MesInfo.BackColor = System.Drawing.Color.Azure;
            this.rtb_MesInfo.DetectUrls = false;
            this.rtb_MesInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_MesInfo.HideSelection = false;
            this.rtb_MesInfo.Location = new System.Drawing.Point(0, 0);
            this.rtb_MesInfo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rtb_MesInfo.Name = "rtb_MesInfo";
            this.rtb_MesInfo.Size = new System.Drawing.Size(609, 148);
            this.rtb_MesInfo.TabIndex = 0;
            this.rtb_MesInfo.Text = "";
            // 
            // groupBox_urlFilter
            // 
            this.groupBox_urlFilter.Controls.Add(this.pictureBox_editHttpFilter);
            this.groupBox_urlFilter.Controls.Add(this.tbe_urlFilter);
            this.groupBox_urlFilter.Controls.Add(this.lb_editRuleMode);
            this.groupBox_urlFilter.Controls.Add(this.pictureBox_editRuleMode);
            this.groupBox_urlFilter.Controls.Add(this.pb_getSession);
            this.groupBox_urlFilter.Controls.Add(this.cb_macthMode);
            this.groupBox_urlFilter.Controls.Add(this.tb_urlFilter);
            this.groupBox_urlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_urlFilter.Location = new System.Drawing.Point(0, 0);
            this.groupBox_urlFilter.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox_urlFilter.Name = "groupBox_urlFilter";
            this.groupBox_urlFilter.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox_urlFilter.Size = new System.Drawing.Size(609, 44);
            this.groupBox_urlFilter.TabIndex = 6;
            this.groupBox_urlFilter.TabStop = false;
            this.groupBox_urlFilter.Text = "Url Filter";
            // 
            // tb_urlFilter
            // 
            this.tb_urlFilter.AllowDrop = true;
            this.tb_urlFilter.Location = new System.Drawing.Point(104, 18);
            this.tb_urlFilter.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tb_urlFilter.Name = "tb_urlFilter";
            this.tb_urlFilter.Size = new System.Drawing.Size(344, 21);
            this.tb_urlFilter.TabIndex = 0;
            this.toolTip_forMainWindow.SetToolTip(this.tb_urlFilter, "the match vaule (match full url include http:// and ？key=value)");
            this.tb_urlFilter.DragDrop += new System.Windows.Forms.DragEventHandler(this.tb_urlFilter_DragDrop);
            this.tb_urlFilter.DragEnter += new System.Windows.Forms.DragEventHandler(this.tb_urlFilter_DragEnter);
            this.tb_urlFilter.Enter += new System.EventHandler(this.tb_Modific_body_Enter);
            this.tb_urlFilter.Leave += new System.EventHandler(this.tb_Modific_body_Leave);
            // 
            // lb_editRuleMode
            // 
            this.lb_editRuleMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_editRuleMode.AutoSize = true;
            this.lb_editRuleMode.Location = new System.Drawing.Point(497, 21);
            this.lb_editRuleMode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_editRuleMode.Name = "lb_editRuleMode";
            this.lb_editRuleMode.Size = new System.Drawing.Size(53, 12);
            this.lb_editRuleMode.TabIndex = 40;
            this.lb_editRuleMode.Text = "New Rule";
            // 
            // cb_macthMode
            // 
            this.cb_macthMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_macthMode.FormattingEnabled = true;
            this.cb_macthMode.Items.AddRange(new object[] {
            "Contain",
            "StartWith",
            "Is",
            "Regex",
            "AllPass"});
            this.cb_macthMode.Location = new System.Drawing.Point(30, 18);
            this.cb_macthMode.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cb_macthMode.Name = "cb_macthMode";
            this.cb_macthMode.Size = new System.Drawing.Size(72, 20);
            this.cb_macthMode.TabIndex = 2;
            this.toolTip_forMainWindow.SetToolTip(this.cb_macthMode, resources.GetString("cb_macthMode.ToolTip"));
            this.cb_macthMode.SelectedIndexChanged += new System.EventHandler(this.cb_macthMode_SelectedIndexChanged);
            // 
            // splitContainer_httpControl
            // 
            this.splitContainer_httpControl.BackColor = System.Drawing.SystemColors.Window;
            this.splitContainer_httpControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_httpControl.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_httpControl.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.splitContainer_httpControl.Name = "splitContainer_httpControl";
            this.splitContainer_httpControl.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer_httpControl.Panel1
            // 
            this.splitContainer_httpControl.Panel1.Controls.Add(this.pb_addRequestRule);
            this.splitContainer_httpControl.Panel1.Controls.Add(this.pb_removeRequestRule);
            this.splitContainer_httpControl.Panel1.Controls.Add(this.pb_requestRuleSwitch);
            this.splitContainer_httpControl.Panel1.Controls.Add(this.lv_requestRuleList);
            // 
            // splitContainer_httpControl.Panel2
            // 
            this.splitContainer_httpControl.Panel2.Controls.Add(this.pb_addResponseRule);
            this.splitContainer_httpControl.Panel2.Controls.Add(this.pb_removeResponseRule);
            this.splitContainer_httpControl.Panel2.Controls.Add(this.pb_responseRuleSwitch);
            this.splitContainer_httpControl.Panel2.Controls.Add(this.lv_responseRuleList);
            this.splitContainer_httpControl.Size = new System.Drawing.Size(353, 552);
            this.splitContainer_httpControl.SplitterDistance = 201;
            this.splitContainer_httpControl.TabIndex = 0;
            this.splitContainer_httpControl.Resize += new System.EventHandler(this.splitContainer_httpControl_Resize);
            // 
            // contextMenu_ruleList
            // 
            this.contextMenu_ruleList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeSelectedRuleToolStripMenuItem,
            this.removeAllRuleToolStripMenuItem,
            this.copySelectedRuleToolStripMenuItem,
            this.enableThisRuleToolStripMenuItem,
            this.enableAllRuleToolStripMenuItem,
            this.unableAllRuleToolStripMenuItem,
            this.editThisRuleToolStripMenuItem});
            this.contextMenu_ruleList.Name = "contextMenu_ruleList";
            this.contextMenu_ruleList.Size = new System.Drawing.Size(199, 180);
            // 
            // contextMenuStrip_addParameter
            // 
            this.contextMenuStrip_addParameter.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentValueToolStripMenuItem,
            this.nextValueToolStripMenuItem,
            this.previousValueToolStripMenuItem});
            this.contextMenuStrip_addParameter.Name = "contextMenuStrip_addParameter";
            this.contextMenuStrip_addParameter.Size = new System.Drawing.Size(167, 70);
            this.contextMenuStrip_addParameter.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_addParameter_Opening);
            // 
            // panel_modific
            // 
            this.panel_modific.BackColor = System.Drawing.SystemColors.Control;
            this.panel_modific.Controls.Add(this.tabControl_Modific);
            this.panel_modific.Controls.Add(this.panel_modific_Contorl);
            this.panel_modific.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_modific.Location = new System.Drawing.Point(0, 0);
            this.panel_modific.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel_modific.Name = "panel_modific";
            this.panel_modific.Size = new System.Drawing.Size(609, 356);
            this.panel_modific.TabIndex = 7;
            // 
            // tabControl_Modific
            // 
            this.tabControl_Modific.Controls.Add(this.tabPage_requestModific);
            this.tabControl_Modific.Controls.Add(this.tabPage_requestReplace);
            this.tabControl_Modific.Controls.Add(this.tabPage_responseModific);
            this.tabControl_Modific.Controls.Add(this.tabPage_responseReplace);
            this.tabControl_Modific.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_Modific.ImageList = this.imageList_forTab;
            this.tabControl_Modific.Location = new System.Drawing.Point(0, 0);
            this.tabControl_Modific.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabControl_Modific.Name = "tabControl_Modific";
            this.tabControl_Modific.SelectedIndex = 0;
            this.tabControl_Modific.Size = new System.Drawing.Size(609, 329);
            this.tabControl_Modific.TabIndex = 0;
            this.toolTip_forMainWindow.SetToolTip(this.tabControl_Modific, resources.GetString("tabControl_Modific.ToolTip"));
            this.tabControl_Modific.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl_Modific_Selecting);
            this.tabControl_Modific.Resize += new System.EventHandler(this.tabControl_Modific_Resize);
            // 
            // tabPage_requestModific
            // 
            this.tabPage_requestModific.BackColor = System.Drawing.Color.Transparent;
            this.tabPage_requestModific.Controls.Add(this.splitContainer_requestModific);
            this.tabPage_requestModific.Controls.Add(this.groupBox_uriModific);
            this.tabPage_requestModific.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabPage_requestModific.ImageKey = "request_modific.png";
            this.tabPage_requestModific.Location = new System.Drawing.Point(4, 23);
            this.tabPage_requestModific.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage_requestModific.Name = "tabPage_requestModific";
            this.tabPage_requestModific.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage_requestModific.Size = new System.Drawing.Size(601, 302);
            this.tabPage_requestModific.TabIndex = 0;
            this.tabPage_requestModific.Text = "Request Modific";
            // 
            // splitContainer_requestModific
            // 
            this.splitContainer_requestModific.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_requestModific.Location = new System.Drawing.Point(4, 56);
            this.splitContainer_requestModific.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.splitContainer_requestModific.Name = "splitContainer_requestModific";
            this.splitContainer_requestModific.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer_requestModific.Panel1
            // 
            this.splitContainer_requestModific.Panel1.Controls.Add(this.groupBox_headsModific);
            // 
            // splitContainer_requestModific.Panel2
            // 
            this.splitContainer_requestModific.Panel2.Controls.Add(this.groupBox_bodyModific);
            this.splitContainer_requestModific.Size = new System.Drawing.Size(593, 243);
            this.splitContainer_requestModific.SplitterDistance = 107;
            this.splitContainer_requestModific.TabIndex = 1;
            // 
            // groupBox_headsModific
            // 
            this.groupBox_headsModific.Controls.Add(this.requestAddHeads);
            this.groupBox_headsModific.Controls.Add(this.requestRemoveHeads);
            this.groupBox_headsModific.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_headsModific.Location = new System.Drawing.Point(0, 0);
            this.groupBox_headsModific.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox_headsModific.Name = "groupBox_headsModific";
            this.groupBox_headsModific.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox_headsModific.Size = new System.Drawing.Size(593, 107);
            this.groupBox_headsModific.TabIndex = 1;
            this.groupBox_headsModific.TabStop = false;
            this.groupBox_headsModific.Text = "Heads Modific";
            // 
            // requestAddHeads
            // 
            this.requestAddHeads.ColumnHeaderName = "Add Head";
            this.requestAddHeads.Dock = System.Windows.Forms.DockStyle.Right;
            this.requestAddHeads.IsItemUnique = false;
            this.requestAddHeads.IsKeyValue = true;
            this.requestAddHeads.Location = new System.Drawing.Point(279, 17);
            this.requestAddHeads.Margin = new System.Windows.Forms.Padding(6);
            this.requestAddHeads.Name = "requestAddHeads";
            this.requestAddHeads.Size = new System.Drawing.Size(310, 87);
            this.requestAddHeads.SplitStr = ": ";
            this.requestAddHeads.TabIndex = 1;
            // 
            // requestRemoveHeads
            // 
            this.requestRemoveHeads.ColumnHeaderName = "Remove Head";
            this.requestRemoveHeads.Dock = System.Windows.Forms.DockStyle.Left;
            this.requestRemoveHeads.IsItemUnique = false;
            this.requestRemoveHeads.IsKeyValue = false;
            this.requestRemoveHeads.Location = new System.Drawing.Point(4, 17);
            this.requestRemoveHeads.Margin = new System.Windows.Forms.Padding(6);
            this.requestRemoveHeads.Name = "requestRemoveHeads";
            this.requestRemoveHeads.Size = new System.Drawing.Size(275, 87);
            this.requestRemoveHeads.SplitStr = ": ";
            this.requestRemoveHeads.TabIndex = 0;
            // 
            // groupBox_bodyModific
            // 
            this.groupBox_bodyModific.Controls.Add(this.panel2);
            this.groupBox_bodyModific.Controls.Add(this.panel1);
            this.groupBox_bodyModific.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_bodyModific.Location = new System.Drawing.Point(0, 0);
            this.groupBox_bodyModific.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox_bodyModific.Name = "groupBox_bodyModific";
            this.groupBox_bodyModific.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox_bodyModific.Size = new System.Drawing.Size(593, 132);
            this.groupBox_bodyModific.TabIndex = 2;
            this.groupBox_bodyModific.TabStop = false;
            this.groupBox_bodyModific.Text = "Body Modific";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rtb_requestModific_body);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(4, 50);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(585, 79);
            this.panel2.TabIndex = 48;
            // 
            // rtb_requestModific_body
            // 
            this.rtb_requestModific_body.ContextMenuStrip = this.contextMenuStrip_AddFile;
            this.rtb_requestModific_body.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_requestModific_body.Location = new System.Drawing.Point(0, 0);
            this.rtb_requestModific_body.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rtb_requestModific_body.Name = "rtb_requestModific_body";
            this.rtb_requestModific_body.Size = new System.Drawing.Size(585, 79);
            this.rtb_requestModific_body.TabIndex = 0;
            this.rtb_requestModific_body.Text = "";
            this.toolTip_forMainWindow.SetToolTip(this.rtb_requestModific_body, "empty mean not change the request body");
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbe_RequestBodyModific);
            this.panel1.Controls.Add(this.tb_requestModific_body);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(4, 17);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(585, 33);
            this.panel1.TabIndex = 47;
            // 
            // tbe_RequestBodyModific
            // 
            this.tbe_RequestBodyModific.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbe_RequestBodyModific.BackColor = System.Drawing.SystemColors.Window;
            this.tbe_RequestBodyModific.EditTextBox = this.tb_requestModific_body;
            this.tbe_RequestBodyModific.Location = new System.Drawing.Point(562, 6);
            this.tbe_RequestBodyModific.MainContainerControl = this;
            this.tbe_RequestBodyModific.Margin = new System.Windows.Forms.Padding(6);
            this.tbe_RequestBodyModific.Name = "tbe_RequestBodyModific";
            this.tbe_RequestBodyModific.Size = new System.Drawing.Size(17, 17);
            this.tbe_RequestBodyModific.TabIndex = 49;
            // 
            // tb_requestModific_body
            // 
            this.tb_requestModific_body.AcceptsReturn = true;
            this.tb_requestModific_body.Location = new System.Drawing.Point(64, 5);
            this.tb_requestModific_body.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tb_requestModific_body.Name = "tb_requestModific_body";
            this.tb_requestModific_body.Size = new System.Drawing.Size(519, 21);
            this.tb_requestModific_body.TabIndex = 47;
            this.toolTip_forMainWindow.SetToolTip(this.tb_requestModific_body, resources.GetString("tb_requestModific_body.ToolTip"));
            this.tb_requestModific_body.WatermarkText = "empty mean replace all body , start with \"<regex>\" mean regex replace,\"<hex>\" mea" +
    "n hex replace ,\"<recode>\"mean change the character set";
            this.tb_requestModific_body.Enter += new System.EventHandler(this.tb_Modific_body_Enter);
            this.tb_requestModific_body.Leave += new System.EventHandler(this.tb_Modific_body_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 48;
            this.label1.Text = "Replace";
            // 
            // groupBox_uriModific
            // 
            this.groupBox_uriModific.Controls.Add(this.tb_requestModific_uriModificKey);
            this.groupBox_uriModific.Controls.Add(this.tb_requestModific_uriModificValue);
            this.groupBox_uriModific.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_uriModific.Location = new System.Drawing.Point(4, 3);
            this.groupBox_uriModific.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox_uriModific.Name = "groupBox_uriModific";
            this.groupBox_uriModific.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox_uriModific.Size = new System.Drawing.Size(593, 53);
            this.groupBox_uriModific.TabIndex = 0;
            this.groupBox_uriModific.TabStop = false;
            this.groupBox_uriModific.Text = "Uri Modific";
            // 
            // tb_requestModific_uriModificKey
            // 
            this.tb_requestModific_uriModificKey.Location = new System.Drawing.Point(6, 20);
            this.tb_requestModific_uriModificKey.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tb_requestModific_uriModificKey.Name = "tb_requestModific_uriModificKey";
            this.tb_requestModific_uriModificKey.Size = new System.Drawing.Size(94, 21);
            this.tb_requestModific_uriModificKey.TabIndex = 4;
            this.toolTip_forMainWindow.SetToolTip(this.tb_requestModific_uriModificKey, "set it empty when you want replace all the full url");
            this.tb_requestModific_uriModificKey.WatermarkText = "empty is all";
            // 
            // tb_requestModific_uriModificValue
            // 
            this.tb_requestModific_uriModificValue.Location = new System.Drawing.Point(106, 20);
            this.tb_requestModific_uriModificValue.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tb_requestModific_uriModificValue.Name = "tb_requestModific_uriModificValue";
            this.tb_requestModific_uriModificValue.Size = new System.Drawing.Size(485, 21);
            this.tb_requestModific_uriModificValue.TabIndex = 3;
            this.toolTip_forMainWindow.SetToolTip(this.tb_requestModific_uriModificValue, "empty mean not change the url");
            // 
            // tabPage_requestReplace
            // 
            this.tabPage_requestReplace.Controls.Add(this.splitContainer_requestReplace);
            this.tabPage_requestReplace.Controls.Add(this.rtb_requestRaw);
            this.tabPage_requestReplace.Controls.Add(this.panel_requestReplace_startLine);
            this.tabPage_requestReplace.ImageKey = "request_replace.png";
            this.tabPage_requestReplace.Location = new System.Drawing.Point(4, 23);
            this.tabPage_requestReplace.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage_requestReplace.Name = "tabPage_requestReplace";
            this.tabPage_requestReplace.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage_requestReplace.Size = new System.Drawing.Size(601, 302);
            this.tabPage_requestReplace.TabIndex = 1;
            this.tabPage_requestReplace.Text = "Request Replace";
            this.tabPage_requestReplace.UseVisualStyleBackColor = true;
            // 
            // splitContainer_requestReplace
            // 
            this.splitContainer_requestReplace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_requestReplace.Location = new System.Drawing.Point(4, 36);
            this.splitContainer_requestReplace.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.splitContainer_requestReplace.Name = "splitContainer_requestReplace";
            this.splitContainer_requestReplace.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer_requestReplace.Panel1
            // 
            this.splitContainer_requestReplace.Panel1.Controls.Add(this.elv_requsetReplace);
            // 
            // splitContainer_requestReplace.Panel2
            // 
            this.splitContainer_requestReplace.Panel2.Controls.Add(this.rtb_requsetReplace_body);
            this.splitContainer_requestReplace.Size = new System.Drawing.Size(593, 263);
            this.splitContainer_requestReplace.SplitterDistance = 102;
            this.splitContainer_requestReplace.TabIndex = 18;
            // 
            // elv_requsetReplace
            // 
            this.elv_requsetReplace.ColumnHeaderName = "Request Heads";
            this.elv_requsetReplace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elv_requsetReplace.IsItemUnique = false;
            this.elv_requsetReplace.IsKeyValue = true;
            this.elv_requsetReplace.Location = new System.Drawing.Point(0, 0);
            this.elv_requsetReplace.Margin = new System.Windows.Forms.Padding(6);
            this.elv_requsetReplace.Name = "elv_requsetReplace";
            this.elv_requsetReplace.Size = new System.Drawing.Size(593, 102);
            this.elv_requsetReplace.SplitStr = ": ";
            this.elv_requsetReplace.TabIndex = 2;
            // 
            // rtb_requsetReplace_body
            // 
            this.rtb_requsetReplace_body.ContextMenuStrip = this.contextMenuStrip_AddFile;
            this.rtb_requsetReplace_body.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_requsetReplace_body.Location = new System.Drawing.Point(0, 0);
            this.rtb_requsetReplace_body.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rtb_requsetReplace_body.Name = "rtb_requsetReplace_body";
            this.rtb_requsetReplace_body.Size = new System.Drawing.Size(593, 157);
            this.rtb_requsetReplace_body.TabIndex = 1;
            this.rtb_requsetReplace_body.Text = "";
            // 
            // rtb_requestRaw
            // 
            this.rtb_requestRaw.ContextMenuStrip = this.contextMenuStrip_AddFile;
            this.rtb_requestRaw.DetectUrls = false;
            this.rtb_requestRaw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_requestRaw.Location = new System.Drawing.Point(4, 36);
            this.rtb_requestRaw.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rtb_requestRaw.Name = "rtb_requestRaw";
            this.rtb_requestRaw.Size = new System.Drawing.Size(593, 263);
            this.rtb_requestRaw.TabIndex = 0;
            this.rtb_requestRaw.Text = "";
            // 
            // panel_requestReplace_startLine
            // 
            this.panel_requestReplace_startLine.Controls.Add(this.pb_requestReplace_changeMode);
            this.panel_requestReplace_startLine.Controls.Add(this.lb_editStartLine);
            this.panel_requestReplace_startLine.Controls.Add(this.tb_requestReplace_uri);
            this.panel_requestReplace_startLine.Controls.Add(this.cb_editRequestMethod);
            this.panel_requestReplace_startLine.Controls.Add(this.cb_editRequestEdition);
            this.panel_requestReplace_startLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_requestReplace_startLine.Location = new System.Drawing.Point(4, 3);
            this.panel_requestReplace_startLine.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel_requestReplace_startLine.Name = "panel_requestReplace_startLine";
            this.panel_requestReplace_startLine.Size = new System.Drawing.Size(593, 33);
            this.panel_requestReplace_startLine.TabIndex = 17;
            // 
            // lb_editStartLine
            // 
            this.lb_editStartLine.AutoSize = true;
            this.lb_editStartLine.Location = new System.Drawing.Point(4, 9);
            this.lb_editStartLine.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_editStartLine.Name = "lb_editStartLine";
            this.lb_editStartLine.Size = new System.Drawing.Size(71, 12);
            this.lb_editStartLine.TabIndex = 13;
            this.lb_editStartLine.Text = "Start Line:";
            // 
            // tb_requestReplace_uri
            // 
            this.tb_requestReplace_uri.Location = new System.Drawing.Point(160, 6);
            this.tb_requestReplace_uri.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tb_requestReplace_uri.Name = "tb_requestReplace_uri";
            this.tb_requestReplace_uri.Size = new System.Drawing.Size(322, 21);
            this.tb_requestReplace_uri.TabIndex = 16;
            this.tb_requestReplace_uri.WatermarkText = null;
            // 
            // cb_editRequestMethod
            // 
            this.cb_editRequestMethod.FormattingEnabled = true;
            this.cb_editRequestMethod.Items.AddRange(new object[] {
            "GET",
            "POST",
            "HEAD",
            "PUT",
            "DELETE",
            "CONNECT",
            "OPTIONS",
            "TRACE"});
            this.cb_editRequestMethod.Location = new System.Drawing.Point(76, 6);
            this.cb_editRequestMethod.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cb_editRequestMethod.Name = "cb_editRequestMethod";
            this.cb_editRequestMethod.Size = new System.Drawing.Size(78, 20);
            this.cb_editRequestMethod.TabIndex = 14;
            // 
            // cb_editRequestEdition
            // 
            this.cb_editRequestEdition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_editRequestEdition.FormattingEnabled = true;
            this.cb_editRequestEdition.Items.AddRange(new object[] {
            "HTTP/1.1",
            "HTTP/0.9",
            "HTTP/1.0",
            "HTTP/1.2",
            "HTTP/2.0"});
            this.cb_editRequestEdition.Location = new System.Drawing.Point(485, 6);
            this.cb_editRequestEdition.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cb_editRequestEdition.Name = "cb_editRequestEdition";
            this.cb_editRequestEdition.Size = new System.Drawing.Size(78, 20);
            this.cb_editRequestEdition.TabIndex = 15;
            // 
            // tabPage_responseModific
            // 
            this.tabPage_responseModific.Controls.Add(this.splitContainer_responseModific);
            this.tabPage_responseModific.ImageKey = "request_modific.png";
            this.tabPage_responseModific.Location = new System.Drawing.Point(4, 23);
            this.tabPage_responseModific.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage_responseModific.Name = "tabPage_responseModific";
            this.tabPage_responseModific.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage_responseModific.Size = new System.Drawing.Size(601, 302);
            this.tabPage_responseModific.TabIndex = 2;
            this.tabPage_responseModific.Text = "Response Modific";
            this.tabPage_responseModific.UseVisualStyleBackColor = true;
            // 
            // splitContainer_responseModific
            // 
            this.splitContainer_responseModific.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_responseModific.Location = new System.Drawing.Point(4, 3);
            this.splitContainer_responseModific.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.splitContainer_responseModific.Name = "splitContainer_responseModific";
            this.splitContainer_responseModific.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer_responseModific.Panel1
            // 
            this.splitContainer_responseModific.Panel1.Controls.Add(this.groupBox_reponseHeadModific);
            // 
            // splitContainer_responseModific.Panel2
            // 
            this.splitContainer_responseModific.Panel2.Controls.Add(this.groupBox_responseBodyModific);
            this.splitContainer_responseModific.Size = new System.Drawing.Size(593, 296);
            this.splitContainer_responseModific.SplitterDistance = 114;
            this.splitContainer_responseModific.TabIndex = 2;
            // 
            // groupBox_reponseHeadModific
            // 
            this.groupBox_reponseHeadModific.Controls.Add(this.responseAddHeads);
            this.groupBox_reponseHeadModific.Controls.Add(this.responseRemoveHeads);
            this.groupBox_reponseHeadModific.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_reponseHeadModific.Location = new System.Drawing.Point(0, 0);
            this.groupBox_reponseHeadModific.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox_reponseHeadModific.Name = "groupBox_reponseHeadModific";
            this.groupBox_reponseHeadModific.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox_reponseHeadModific.Size = new System.Drawing.Size(593, 114);
            this.groupBox_reponseHeadModific.TabIndex = 1;
            this.groupBox_reponseHeadModific.TabStop = false;
            this.groupBox_reponseHeadModific.Text = "Heads Modific";
            // 
            // responseAddHeads
            // 
            this.responseAddHeads.ColumnHeaderName = "Add Head";
            this.responseAddHeads.Dock = System.Windows.Forms.DockStyle.Right;
            this.responseAddHeads.IsItemUnique = false;
            this.responseAddHeads.IsKeyValue = true;
            this.responseAddHeads.Location = new System.Drawing.Point(279, 17);
            this.responseAddHeads.Margin = new System.Windows.Forms.Padding(6);
            this.responseAddHeads.Name = "responseAddHeads";
            this.responseAddHeads.Size = new System.Drawing.Size(310, 94);
            this.responseAddHeads.SplitStr = ": ";
            this.responseAddHeads.TabIndex = 1;
            // 
            // responseRemoveHeads
            // 
            this.responseRemoveHeads.ColumnHeaderName = "Remove Head";
            this.responseRemoveHeads.Dock = System.Windows.Forms.DockStyle.Left;
            this.responseRemoveHeads.IsItemUnique = false;
            this.responseRemoveHeads.IsKeyValue = false;
            this.responseRemoveHeads.Location = new System.Drawing.Point(4, 17);
            this.responseRemoveHeads.Margin = new System.Windows.Forms.Padding(6);
            this.responseRemoveHeads.Name = "responseRemoveHeads";
            this.responseRemoveHeads.Size = new System.Drawing.Size(275, 94);
            this.responseRemoveHeads.SplitStr = ": ";
            this.responseRemoveHeads.TabIndex = 0;
            // 
            // groupBox_responseBodyModific
            // 
            this.groupBox_responseBodyModific.Controls.Add(this.panel3);
            this.groupBox_responseBodyModific.Controls.Add(this.panel4);
            this.groupBox_responseBodyModific.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_responseBodyModific.Location = new System.Drawing.Point(0, 0);
            this.groupBox_responseBodyModific.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox_responseBodyModific.Name = "groupBox_responseBodyModific";
            this.groupBox_responseBodyModific.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox_responseBodyModific.Size = new System.Drawing.Size(593, 178);
            this.groupBox_responseBodyModific.TabIndex = 2;
            this.groupBox_responseBodyModific.TabStop = false;
            this.groupBox_responseBodyModific.Text = "Body Modific";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.rtb_respenseModific_body);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(4, 50);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(585, 125);
            this.panel3.TabIndex = 48;
            // 
            // rtb_respenseModific_body
            // 
            this.rtb_respenseModific_body.ContextMenuStrip = this.contextMenuStrip_AddFile;
            this.rtb_respenseModific_body.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_respenseModific_body.Location = new System.Drawing.Point(0, 0);
            this.rtb_respenseModific_body.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rtb_respenseModific_body.Name = "rtb_respenseModific_body";
            this.rtb_respenseModific_body.Size = new System.Drawing.Size(585, 125);
            this.rtb_respenseModific_body.TabIndex = 0;
            this.rtb_respenseModific_body.Text = "";
            this.toolTip_forMainWindow.SetToolTip(this.rtb_respenseModific_body, "empty mean not change the response body");
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.tbe_ResponseBodyModific);
            this.panel4.Controls.Add(this.tb_responseModific_body);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(4, 17);
            this.panel4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(585, 33);
            this.panel4.TabIndex = 47;
            // 
            // tbe_ResponseBodyModific
            // 
            this.tbe_ResponseBodyModific.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbe_ResponseBodyModific.BackColor = System.Drawing.SystemColors.Window;
            this.tbe_ResponseBodyModific.EditTextBox = this.tb_responseModific_body;
            this.tbe_ResponseBodyModific.Location = new System.Drawing.Point(561, 6);
            this.tbe_ResponseBodyModific.MainContainerControl = this;
            this.tbe_ResponseBodyModific.Margin = new System.Windows.Forms.Padding(6);
            this.tbe_ResponseBodyModific.Name = "tbe_ResponseBodyModific";
            this.tbe_ResponseBodyModific.Size = new System.Drawing.Size(17, 17);
            this.tbe_ResponseBodyModific.TabIndex = 50;
            // 
            // tb_responseModific_body
            // 
            this.tb_responseModific_body.Location = new System.Drawing.Point(63, 5);
            this.tb_responseModific_body.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tb_responseModific_body.Name = "tb_responseModific_body";
            this.tb_responseModific_body.Size = new System.Drawing.Size(519, 21);
            this.tb_responseModific_body.TabIndex = 47;
            this.toolTip_forMainWindow.SetToolTip(this.tb_responseModific_body, resources.GetString("tb_responseModific_body.ToolTip"));
            this.tb_responseModific_body.WatermarkText = "empty mean replace all body , start with \"<regex>\" mean regex replace,\"<hex>\" mea" +
    "n hex replace , \"<recode>\"mean change the character set";
            this.tb_responseModific_body.Enter += new System.EventHandler(this.tb_Modific_body_Enter);
            this.tb_responseModific_body.Leave += new System.EventHandler(this.tb_Modific_body_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 48;
            this.label2.Text = "Replace";
            // 
            // tabPage_responseReplace
            // 
            this.tabPage_responseReplace.Controls.Add(this.rawResponseEdit);
            this.tabPage_responseReplace.ImageKey = "request_replace.png";
            this.tabPage_responseReplace.Location = new System.Drawing.Point(4, 23);
            this.tabPage_responseReplace.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage_responseReplace.Name = "tabPage_responseReplace";
            this.tabPage_responseReplace.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage_responseReplace.Size = new System.Drawing.Size(601, 302);
            this.tabPage_responseReplace.TabIndex = 3;
            this.tabPage_responseReplace.Text = "Response Replace";
            this.tabPage_responseReplace.UseVisualStyleBackColor = true;
            // 
            // rawResponseEdit
            // 
            this.rawResponseEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rawResponseEdit.IsDirectRespons = false;
            this.rawResponseEdit.IsUseParameterData = false;
            this.rawResponseEdit.Location = new System.Drawing.Point(4, 3);
            this.rawResponseEdit.Margin = new System.Windows.Forms.Padding(6);
            this.rawResponseEdit.Name = "rawResponseEdit";
            this.rawResponseEdit.Size = new System.Drawing.Size(593, 296);
            this.rawResponseEdit.TabIndex = 0;
            // 
            // panel_modific_Contorl
            // 
            this.panel_modific_Contorl.AllowDrop = true;
            this.panel_modific_Contorl.Controls.Add(this.pb_parameterSwitch);
            this.panel_modific_Contorl.Controls.Add(this.pb_protocolSwitch);
            this.panel_modific_Contorl.Controls.Add(this.pb_pickRule);
            this.panel_modific_Contorl.Controls.Add(this.lbl_ResponseLatency);
            this.panel_modific_Contorl.Controls.Add(this.pb_responseLatency);
            this.panel_modific_Contorl.Controls.Add(this.pb_ruleComfrim);
            this.panel_modific_Contorl.Controls.Add(this.pb_ruleCancel);
            this.panel_modific_Contorl.Controls.Add(this.menuStrip_quickRule);
            this.panel_modific_Contorl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_modific_Contorl.Location = new System.Drawing.Point(0, 329);
            this.panel_modific_Contorl.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel_modific_Contorl.Name = "panel_modific_Contorl";
            this.panel_modific_Contorl.Size = new System.Drawing.Size(609, 27);
            this.panel_modific_Contorl.TabIndex = 0;
            // 
            // lbl_ResponseLatency
            // 
            this.lbl_ResponseLatency.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_ResponseLatency.AutoSize = true;
            this.lbl_ResponseLatency.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbl_ResponseLatency.Location = new System.Drawing.Point(463, 8);
            this.lbl_ResponseLatency.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_ResponseLatency.Name = "lbl_ResponseLatency";
            this.lbl_ResponseLatency.Size = new System.Drawing.Size(11, 12);
            this.lbl_ResponseLatency.TabIndex = 41;
            this.lbl_ResponseLatency.TabStop = true;
            this.lbl_ResponseLatency.Text = "0";
            this.toolTip_forMainWindow.SetToolTip(this.lbl_ResponseLatency, "set response latency");
            this.lbl_ResponseLatency.Click += new System.EventHandler(this.pb_responseLatency_Click);
            // 
            // menuStrip_quickRule
            // 
            this.menuStrip_quickRule.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip_quickRule.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quickRuleToolStripMenuItem,
            this.modificToolToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip_quickRule.Location = new System.Drawing.Point(73, 0);
            this.menuStrip_quickRule.Name = "menuStrip_quickRule";
            this.menuStrip_quickRule.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.menuStrip_quickRule.Size = new System.Drawing.Size(223, 24);
            this.menuStrip_quickRule.TabIndex = 2;
            this.menuStrip_quickRule.Text = "menuStrip1";
            // 
            // quickRuleToolStripMenuItem
            // 
            this.quickRuleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.disableCacheToolStripMenuItem,
            this.addCookieToolStripMenuItem,
            this.deleteCookieToolStripMenuItem,
            this.setClientCookieToolStripMenuItem,
            this.copySessionCookiesToolStripMenuItem,
            this.removeSessionCookiesToolStripMenuItem,
            this.addUserAgentToolStripMenuItem,
            this.changeSessionEncodingToolStripMenuItem});
            this.quickRuleToolStripMenuItem.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.quickRuleToolStripMenuItem.Name = "quickRuleToolStripMenuItem";
            this.quickRuleToolStripMenuItem.Padding = new System.Windows.Forms.Padding(2, 0, 4, 0);
            this.quickRuleToolStripMenuItem.Size = new System.Drawing.Size(80, 21);
            this.quickRuleToolStripMenuItem.Text = "Quick Rule";
            // 
            // modificToolToolStripMenuItem
            // 
            this.modificToolToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.independentWindowToolStripMenuItem,
            this.showSelectedSessionStreamToolStripMenuItem,
            this.parameterDataManageToolStripMenuItem,
            this.httpTamperSettingToolStripMenuItem,
            this.loadingRemoteRuleToolStripMenuItem});
            this.modificToolToolStripMenuItem.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.modificToolToolStripMenuItem.Name = "modificToolToolStripMenuItem";
            this.modificToolToolStripMenuItem.Size = new System.Drawing.Size(94, 21);
            this.modificToolToolStripMenuItem.Text = "Modific Tool";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.feedbackToolStripMenuItem,
            this.codeInGithubToolStripMenuItem,
            this.documentationToolStripMenuItem});
            this.helpToolStripMenuItem.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(47, 21);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // tbe_urlFilter
            // 
            this.tbe_urlFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbe_urlFilter.BackColor = System.Drawing.SystemColors.Window;
            this.tbe_urlFilter.EditTextBox = this.tb_urlFilter;
            this.tbe_urlFilter.Location = new System.Drawing.Point(430, 19);
            this.tbe_urlFilter.MainContainerControl = this;
            this.tbe_urlFilter.Margin = new System.Windows.Forms.Padding(6);
            this.tbe_urlFilter.Name = "tbe_urlFilter";
            this.tbe_urlFilter.Size = new System.Drawing.Size(17, 17);
            this.tbe_urlFilter.TabIndex = 50;
            // 
            // lv_requestRuleList
            // 
            this.lv_requestRuleList.AllowDrop = true;
            this.lv_requestRuleList.CheckBoxes = true;
            this.lv_requestRuleList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader_requstRule});
            this.lv_requestRuleList.ContextMenuStrip = this.contextMenu_ruleList;
            this.lv_requestRuleList.Cursor = System.Windows.Forms.Cursors.Default;
            this.lv_requestRuleList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_requestRuleList.FullRowSelect = true;
            this.lv_requestRuleList.HideSelection = false;
            this.lv_requestRuleList.Location = new System.Drawing.Point(0, 0);
            this.lv_requestRuleList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lv_requestRuleList.Name = "lv_requestRuleList";
            this.lv_requestRuleList.ShowItemToolTips = true;
            this.lv_requestRuleList.Size = new System.Drawing.Size(353, 201);
            this.lv_requestRuleList.SmallImageList = this.imageList_forTab;
            this.lv_requestRuleList.TabIndex = 0;
            this.lv_requestRuleList.UseCompatibleStateImageBehavior = false;
            this.lv_requestRuleList.View = System.Windows.Forms.View.Details;
            this.lv_requestRuleList.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lv_RuleList_ItemChecked);
            this.lv_requestRuleList.ItemMouseHover += new System.Windows.Forms.ListViewItemMouseHoverEventHandler(this.lv_ruleList_ItemMouseHover);
            this.lv_requestRuleList.DoubleClick += new System.EventHandler(this.lv_RuleList_DoubleClick);
            this.lv_requestRuleList.MouseLeave += new System.EventHandler(this.lv_ruleList_MouseLeave);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 54;
            // 
            // columnHeader_requstRule
            // 
            this.columnHeader_requstRule.Text = "Request Rule";
            this.columnHeader_requstRule.Width = 280;
            // 
            // lv_responseRuleList
            // 
            this.lv_responseRuleList.AllowDrop = true;
            this.lv_responseRuleList.CheckBoxes = true;
            this.lv_responseRuleList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader_responseRule});
            this.lv_responseRuleList.ContextMenuStrip = this.contextMenu_ruleList;
            this.lv_responseRuleList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_responseRuleList.FullRowSelect = true;
            this.lv_responseRuleList.HideSelection = false;
            this.lv_responseRuleList.Location = new System.Drawing.Point(0, 0);
            this.lv_responseRuleList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lv_responseRuleList.Name = "lv_responseRuleList";
            this.lv_responseRuleList.ShowItemToolTips = true;
            this.lv_responseRuleList.Size = new System.Drawing.Size(353, 347);
            this.lv_responseRuleList.SmallImageList = this.imageList_forTab;
            this.lv_responseRuleList.TabIndex = 1;
            this.lv_responseRuleList.UseCompatibleStateImageBehavior = false;
            this.lv_responseRuleList.View = System.Windows.Forms.View.Details;
            this.lv_responseRuleList.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lv_RuleList_ItemChecked);
            this.lv_responseRuleList.ItemMouseHover += new System.Windows.Forms.ListViewItemMouseHoverEventHandler(this.lv_ruleList_ItemMouseHover);
            this.lv_responseRuleList.DoubleClick += new System.EventHandler(this.lv_RuleList_DoubleClick);
            this.lv_responseRuleList.MouseLeave += new System.EventHandler(this.lv_ruleList_MouseLeave);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "ID";
            this.columnHeader3.Width = 54;
            // 
            // columnHeader_responseRule
            // 
            this.columnHeader_responseRule.Text = "Response Rule";
            this.columnHeader_responseRule.Width = 280;
            // 
            // addFileToolStripMenuItem
            // 
            this.addFileToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("addFileToolStripMenuItem.Image")));
            this.addFileToolStripMenuItem.Name = "addFileToolStripMenuItem";
            this.addFileToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.addFileToolStripMenuItem.Text = "add file";
            this.addFileToolStripMenuItem.Click += new System.EventHandler(this.addFileToolStripMenuItem_Click);
            // 
            // addParameterDataToolStripMenuItem
            // 
            this.addParameterDataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.keyValueToolStripMenuItem,
            this.parameterToolStripMenuItem,
            this.dataSouceToolStripMenuItem,
            this.toolStripSeparator1,
            this.editDataToolStripMenuItem});
            this.addParameterDataToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("addParameterDataToolStripMenuItem.Image")));
            this.addParameterDataToolStripMenuItem.Name = "addParameterDataToolStripMenuItem";
            this.addParameterDataToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.addParameterDataToolStripMenuItem.Text = "add Parameter Data";
            this.addParameterDataToolStripMenuItem.DropDownOpening += new System.EventHandler(this.addParameterDataToolStripMenuItem_DropDownOpening);
            // 
            // keyValueToolStripMenuItem
            // 
            this.keyValueToolStripMenuItem.Name = "keyValueToolStripMenuItem";
            this.keyValueToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.keyValueToolStripMenuItem.Text = "KeyValue";
            // 
            // parameterToolStripMenuItem
            // 
            this.parameterToolStripMenuItem.Name = "parameterToolStripMenuItem";
            this.parameterToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.parameterToolStripMenuItem.Text = "Parameter";
            // 
            // dataSouceToolStripMenuItem
            // 
            this.dataSouceToolStripMenuItem.Name = "dataSouceToolStripMenuItem";
            this.dataSouceToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.dataSouceToolStripMenuItem.Text = "DataSouce";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(135, 6);
            // 
            // editDataToolStripMenuItem
            // 
            this.editDataToolStripMenuItem.Name = "editDataToolStripMenuItem";
            this.editDataToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.editDataToolStripMenuItem.Text = "Edit Data";
            this.editDataToolStripMenuItem.Click += new System.EventHandler(this.parameterDataManageToolStripMenuItem_Click);
            // 
            // pb_requestReplace_changeMode
            // 
            this.pb_requestReplace_changeMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_requestReplace_changeMode.BackColor = System.Drawing.Color.Transparent;
            this.pb_requestReplace_changeMode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_requestReplace_changeMode.Image = ((System.Drawing.Image)(resources.GetObject("pb_requestReplace_changeMode.Image")));
            this.pb_requestReplace_changeMode.Location = new System.Drawing.Point(567, 5);
            this.pb_requestReplace_changeMode.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pb_requestReplace_changeMode.Name = "pb_requestReplace_changeMode";
            this.pb_requestReplace_changeMode.Size = new System.Drawing.Size(23, 22);
            this.pb_requestReplace_changeMode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_requestReplace_changeMode.TabIndex = 38;
            this.pb_requestReplace_changeMode.TabStop = false;
            this.toolTip_forMainWindow.SetToolTip(this.pb_requestReplace_changeMode, "change request replace");
            this.pb_requestReplace_changeMode.Click += new System.EventHandler(this.pb_requestReplace_changeMode_Click);
            this.pb_requestReplace_changeMode.MouseLeave += new System.EventHandler(this.pictureBox_MouseLeave);
            this.pb_requestReplace_changeMode.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            // 
            // pb_parameterSwitch
            // 
            this.pb_parameterSwitch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_parameterSwitch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_parameterSwitch.Image = global::FreeHttp.Properties.Resources.noParameter;
            this.pb_parameterSwitch.IsAutoChangeSwitchState = true;
            this.pb_parameterSwitch.Location = new System.Drawing.Point(512, 1);
            this.pb_parameterSwitch.Margin = new System.Windows.Forms.Padding(2);
            this.pb_parameterSwitch.Name = "pb_parameterSwitch";
            this.pb_parameterSwitch.Size = new System.Drawing.Size(25, 25);
            this.pb_parameterSwitch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_parameterSwitch.SwitchOffImage = global::FreeHttp.Properties.Resources.noParameter;
            this.pb_parameterSwitch.SwitchOnImage = global::FreeHttp.Properties.Resources.useParameter;
            this.pb_parameterSwitch.SwitchState = false;
            this.pb_parameterSwitch.TabIndex = 43;
            this.pb_parameterSwitch.TabStop = false;
            this.toolTip_forMainWindow.SetToolTip(this.pb_parameterSwitch, "enable the parameter data");
            // 
            // pb_protocolSwitch
            // 
            this.pb_protocolSwitch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_protocolSwitch.Image = global::FreeHttp.Properties.Resources.httpEnable;
            this.pb_protocolSwitch.IsAutoChangeSwitchState = false;
            this.pb_protocolSwitch.Location = new System.Drawing.Point(0, 1);
            this.pb_protocolSwitch.Margin = new System.Windows.Forms.Padding(2);
            this.pb_protocolSwitch.Name = "pb_protocolSwitch";
            this.pb_protocolSwitch.Size = new System.Drawing.Size(71, 23);
            this.pb_protocolSwitch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_protocolSwitch.SwitchOffImage = global::FreeHttp.Properties.Resources.wsEnable;
            this.pb_protocolSwitch.SwitchOnImage = global::FreeHttp.Properties.Resources.httpEnable;
            this.pb_protocolSwitch.SwitchState = true;
            this.pb_protocolSwitch.TabIndex = 1;
            this.pb_protocolSwitch.TabStop = false;
            this.pb_protocolSwitch.Click += new System.EventHandler(this.pb_protocolSwitch_Click);
            // 
            // pb_pickRule
            // 
            this.pb_pickRule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_pickRule.BackColor = System.Drawing.Color.Transparent;
            this.pb_pickRule.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_pickRule.Image = ((System.Drawing.Image)(resources.GetObject("pb_pickRule.Image")));
            this.pb_pickRule.Location = new System.Drawing.Point(486, 1);
            this.pb_pickRule.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pb_pickRule.Name = "pb_pickRule";
            this.pb_pickRule.Size = new System.Drawing.Size(25, 25);
            this.pb_pickRule.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_pickRule.TabIndex = 42;
            this.pb_pickRule.TabStop = false;
            this.toolTip_forMainWindow.SetToolTip(this.pb_pickRule, "set parameter pick info");
            this.pb_pickRule.Click += new System.EventHandler(this.pb_pickRule_Click);
            this.pb_pickRule.MouseLeave += new System.EventHandler(this.pictureBox_MouseLeave);
            this.pb_pickRule.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            // 
            // pb_responseLatency
            // 
            this.pb_responseLatency.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_responseLatency.BackColor = System.Drawing.Color.Transparent;
            this.pb_responseLatency.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_responseLatency.Image = ((System.Drawing.Image)(resources.GetObject("pb_responseLatency.Image")));
            this.pb_responseLatency.Location = new System.Drawing.Point(460, 1);
            this.pb_responseLatency.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pb_responseLatency.Name = "pb_responseLatency";
            this.pb_responseLatency.Size = new System.Drawing.Size(25, 25);
            this.pb_responseLatency.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_responseLatency.TabIndex = 39;
            this.pb_responseLatency.TabStop = false;
            this.toolTip_forMainWindow.SetToolTip(this.pb_responseLatency, "set response latency");
            this.pb_responseLatency.Click += new System.EventHandler(this.pb_responseLatency_Click);
            // 
            // pb_ruleComfrim
            // 
            this.pb_ruleComfrim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_ruleComfrim.BackColor = System.Drawing.Color.Transparent;
            this.pb_ruleComfrim.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_ruleComfrim.Image = ((System.Drawing.Image)(resources.GetObject("pb_ruleComfrim.Image")));
            this.pb_ruleComfrim.Location = new System.Drawing.Point(581, 1);
            this.pb_ruleComfrim.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pb_ruleComfrim.Name = "pb_ruleComfrim";
            this.pb_ruleComfrim.Size = new System.Drawing.Size(25, 25);
            this.pb_ruleComfrim.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_ruleComfrim.TabIndex = 37;
            this.pb_ruleComfrim.TabStop = false;
            this.toolTip_forMainWindow.SetToolTip(this.pb_ruleComfrim, "affirm your modific rule");
            this.pb_ruleComfrim.Click += new System.EventHandler(this.pb_ruleComfrim_Click);
            this.pb_ruleComfrim.MouseLeave += new System.EventHandler(this.pictureBox_MouseLeave);
            this.pb_ruleComfrim.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            // 
            // pb_ruleCancel
            // 
            this.pb_ruleCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_ruleCancel.BackColor = System.Drawing.Color.Transparent;
            this.pb_ruleCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_ruleCancel.Image = global::FreeHttp.Properties.Resources.cancel;
            this.pb_ruleCancel.Location = new System.Drawing.Point(555, 1);
            this.pb_ruleCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pb_ruleCancel.Name = "pb_ruleCancel";
            this.pb_ruleCancel.Size = new System.Drawing.Size(25, 25);
            this.pb_ruleCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_ruleCancel.TabIndex = 38;
            this.pb_ruleCancel.TabStop = false;
            this.toolTip_forMainWindow.SetToolTip(this.pb_ruleCancel, "clear your rule edit info");
            this.pb_ruleCancel.Click += new System.EventHandler(this.pb_ruleCancel_Click);
            this.pb_ruleCancel.MouseLeave += new System.EventHandler(this.pictureBox_MouseLeave);
            this.pb_ruleCancel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            // 
            // disableCacheToolStripMenuItem
            // 
            this.disableCacheToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("disableCacheToolStripMenuItem.Image")));
            this.disableCacheToolStripMenuItem.Name = "disableCacheToolStripMenuItem";
            this.disableCacheToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.disableCacheToolStripMenuItem.Text = "disable cache";
            this.disableCacheToolStripMenuItem.Click += new System.EventHandler(this.disableCacheToolStripMenuItem_Click);
            // 
            // addCookieToolStripMenuItem
            // 
            this.addCookieToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("addCookieToolStripMenuItem.Image")));
            this.addCookieToolStripMenuItem.Name = "addCookieToolStripMenuItem";
            this.addCookieToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.addCookieToolStripMenuItem.Text = "add cookie";
            this.addCookieToolStripMenuItem.Click += new System.EventHandler(this.addCookieToolStripMenuItem_Click);
            // 
            // deleteCookieToolStripMenuItem
            // 
            this.deleteCookieToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("deleteCookieToolStripMenuItem.Image")));
            this.deleteCookieToolStripMenuItem.Name = "deleteCookieToolStripMenuItem";
            this.deleteCookieToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.deleteCookieToolStripMenuItem.Text = "delete cookie";
            this.deleteCookieToolStripMenuItem.Click += new System.EventHandler(this.deleteCookieToolStripMenuItem_Click);
            // 
            // setClientCookieToolStripMenuItem
            // 
            this.setClientCookieToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("setClientCookieToolStripMenuItem.Image")));
            this.setClientCookieToolStripMenuItem.Name = "setClientCookieToolStripMenuItem";
            this.setClientCookieToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.setClientCookieToolStripMenuItem.Text = "set client cookie";
            this.setClientCookieToolStripMenuItem.Click += new System.EventHandler(this.setClientCookieToolStripMenuItem_Click);
            // 
            // copySessionCookiesToolStripMenuItem
            // 
            this.copySessionCookiesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copySessionCookiesToolStripMenuItem.Image")));
            this.copySessionCookiesToolStripMenuItem.Name = "copySessionCookiesToolStripMenuItem";
            this.copySessionCookiesToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.copySessionCookiesToolStripMenuItem.Text = "copy session cookies";
            this.copySessionCookiesToolStripMenuItem.Click += new System.EventHandler(this.copySessionCookiesToolStripMenuItem_Click);
            // 
            // removeSessionCookiesToolStripMenuItem
            // 
            this.removeSessionCookiesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("removeSessionCookiesToolStripMenuItem.Image")));
            this.removeSessionCookiesToolStripMenuItem.Name = "removeSessionCookiesToolStripMenuItem";
            this.removeSessionCookiesToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.removeSessionCookiesToolStripMenuItem.Text = "remove session cookies";
            this.removeSessionCookiesToolStripMenuItem.Click += new System.EventHandler(this.removeSessionCookiesToolStripMenuItem_Click);
            // 
            // addUserAgentToolStripMenuItem
            // 
            this.addUserAgentToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("addUserAgentToolStripMenuItem.Image")));
            this.addUserAgentToolStripMenuItem.Name = "addUserAgentToolStripMenuItem";
            this.addUserAgentToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.addUserAgentToolStripMenuItem.Text = "add UserAgent";
            this.addUserAgentToolStripMenuItem.Click += new System.EventHandler(this.addUserAgentToolStripMenuItem_Click);
            // 
            // changeSessionEncodingToolStripMenuItem
            // 
            this.changeSessionEncodingToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("changeSessionEncodingToolStripMenuItem.Image")));
            this.changeSessionEncodingToolStripMenuItem.Name = "changeSessionEncodingToolStripMenuItem";
            this.changeSessionEncodingToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.changeSessionEncodingToolStripMenuItem.Text = "change session encoding";
            this.changeSessionEncodingToolStripMenuItem.Click += new System.EventHandler(this.ChangeSessionEncodingToolStripMenuItem_Click);
            // 
            // independentWindowToolStripMenuItem
            // 
            this.independentWindowToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("independentWindowToolStripMenuItem.Image")));
            this.independentWindowToolStripMenuItem.Name = "independentWindowToolStripMenuItem";
            this.independentWindowToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.independentWindowToolStripMenuItem.Text = "independent window";
            this.independentWindowToolStripMenuItem.Click += new System.EventHandler(this.independentWindowToolStripMenuItem_Click);
            // 
            // showSelectedSessionStreamToolStripMenuItem
            // 
            this.showSelectedSessionStreamToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("showSelectedSessionStreamToolStripMenuItem.Image")));
            this.showSelectedSessionStreamToolStripMenuItem.Name = "showSelectedSessionStreamToolStripMenuItem";
            this.showSelectedSessionStreamToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.showSelectedSessionStreamToolStripMenuItem.Text = "show selected session stream";
            this.showSelectedSessionStreamToolStripMenuItem.Click += new System.EventHandler(this.showSelectedSessionStreamToolStripMenuItem_Click);
            // 
            // parameterDataManageToolStripMenuItem
            // 
            this.parameterDataManageToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("parameterDataManageToolStripMenuItem.Image")));
            this.parameterDataManageToolStripMenuItem.Name = "parameterDataManageToolStripMenuItem";
            this.parameterDataManageToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.parameterDataManageToolStripMenuItem.Text = "parameter data manage";
            this.parameterDataManageToolStripMenuItem.Click += new System.EventHandler(this.parameterDataManageToolStripMenuItem_Click);
            // 
            // httpTamperSettingToolStripMenuItem
            // 
            this.httpTamperSettingToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("httpTamperSettingToolStripMenuItem.Image")));
            this.httpTamperSettingToolStripMenuItem.Name = "httpTamperSettingToolStripMenuItem";
            this.httpTamperSettingToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.httpTamperSettingToolStripMenuItem.Text = "http tamper setting";
            this.httpTamperSettingToolStripMenuItem.Click += new System.EventHandler(this.httpTamperSettingToolStripMenuItem_Click);
            // 
            // loadingRemoteRuleToolStripMenuItem
            // 
            this.loadingRemoteRuleToolStripMenuItem.Image = global::FreeHttp.Properties.Resources.cloud;
            this.loadingRemoteRuleToolStripMenuItem.Name = "loadingRemoteRuleToolStripMenuItem";
            this.loadingRemoteRuleToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.loadingRemoteRuleToolStripMenuItem.Text = "loading remote rule";
            this.loadingRemoteRuleToolStripMenuItem.Click += new System.EventHandler(this.loadingRemoteRuleToolStripMenuItem_Click);
            // 
            // feedbackToolStripMenuItem
            // 
            this.feedbackToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("feedbackToolStripMenuItem.Image")));
            this.feedbackToolStripMenuItem.Name = "feedbackToolStripMenuItem";
            this.feedbackToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.feedbackToolStripMenuItem.Text = "feedback";
            this.feedbackToolStripMenuItem.Click += new System.EventHandler(this.FeedbackToolStripMenuItem_Click);
            // 
            // codeInGithubToolStripMenuItem
            // 
            this.codeInGithubToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("codeInGithubToolStripMenuItem.Image")));
            this.codeInGithubToolStripMenuItem.Name = "codeInGithubToolStripMenuItem";
            this.codeInGithubToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.codeInGithubToolStripMenuItem.Text = "code in github";
            this.codeInGithubToolStripMenuItem.Click += new System.EventHandler(this.CodeInGithubToolStripMenuItem_Click);
            // 
            // documentationToolStripMenuItem
            // 
            this.documentationToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("documentationToolStripMenuItem.Image")));
            this.documentationToolStripMenuItem.Name = "documentationToolStripMenuItem";
            this.documentationToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.documentationToolStripMenuItem.Text = "documentation";
            this.documentationToolStripMenuItem.Click += new System.EventHandler(this.DocumentationToolStripMenuItem_Click);
            // 
            // pictureBox_editHttpFilter
            // 
            this.pictureBox_editHttpFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_editHttpFilter.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_editHttpFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_editHttpFilter.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_editHttpFilter.Image")));
            this.pictureBox_editHttpFilter.Location = new System.Drawing.Point(449, 17);
            this.pictureBox_editHttpFilter.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBox_editHttpFilter.Name = "pictureBox_editHttpFilter";
            this.pictureBox_editHttpFilter.Size = new System.Drawing.Size(20, 20);
            this.pictureBox_editHttpFilter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_editHttpFilter.TabIndex = 51;
            this.pictureBox_editHttpFilter.TabStop = false;
            this.toolTip_forMainWindow.SetToolTip(this.pictureBox_editHttpFilter, "edit advanced http filter");
            this.pictureBox_editHttpFilter.Click += new System.EventHandler(this.pictureBox_editHttpFilter_Click);
            this.pictureBox_editHttpFilter.MouseLeave += new System.EventHandler(this.pictureBox_MouseLeave);
            this.pictureBox_editHttpFilter.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            // 
            // pictureBox_editRuleMode
            // 
            this.pictureBox_editRuleMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_editRuleMode.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_editRuleMode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_editRuleMode.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_editRuleMode.Image")));
            this.pictureBox_editRuleMode.Location = new System.Drawing.Point(471, 16);
            this.pictureBox_editRuleMode.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBox_editRuleMode.Name = "pictureBox_editRuleMode";
            this.pictureBox_editRuleMode.Size = new System.Drawing.Size(23, 22);
            this.pictureBox_editRuleMode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_editRuleMode.TabIndex = 39;
            this.pictureBox_editRuleMode.TabStop = false;
            this.toolTip_forMainWindow.SetToolTip(this.pictureBox_editRuleMode, "new a rule");
            this.pictureBox_editRuleMode.Click += new System.EventHandler(this.pictureBox_editRuleMode_Click);
            this.pictureBox_editRuleMode.MouseLeave += new System.EventHandler(this.pictureBox_MouseLeave);
            this.pictureBox_editRuleMode.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            // 
            // pb_getSession
            // 
            this.pb_getSession.BackColor = System.Drawing.Color.Transparent;
            this.pb_getSession.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_getSession.Image = ((System.Drawing.Image)(resources.GetObject("pb_getSession.Image")));
            this.pb_getSession.Location = new System.Drawing.Point(5, 16);
            this.pb_getSession.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pb_getSession.Name = "pb_getSession";
            this.pb_getSession.Size = new System.Drawing.Size(24, 24);
            this.pb_getSession.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_getSession.TabIndex = 38;
            this.pb_getSession.TabStop = false;
            this.toolTip_forMainWindow.SetToolTip(this.pb_getSession, "get http sesion in left session list");
            this.pb_getSession.Click += new System.EventHandler(this.pb_getSession_Click);
            this.pb_getSession.MouseLeave += new System.EventHandler(this.pictureBox_MouseLeave);
            this.pb_getSession.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            // 
            // pb_addRequestRule
            // 
            this.pb_addRequestRule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_addRequestRule.BackColor = System.Drawing.Color.Transparent;
            this.pb_addRequestRule.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_addRequestRule.Image = ((System.Drawing.Image)(resources.GetObject("pb_addRequestRule.Image")));
            this.pb_addRequestRule.Location = new System.Drawing.Point(279, 1);
            this.pb_addRequestRule.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pb_addRequestRule.Name = "pb_addRequestRule";
            this.pb_addRequestRule.Size = new System.Drawing.Size(20, 20);
            this.pb_addRequestRule.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_addRequestRule.TabIndex = 53;
            this.pb_addRequestRule.TabStop = false;
            this.toolTip_forMainWindow.SetToolTip(this.pb_addRequestRule, "add a new request rule");
            this.pb_addRequestRule.Click += new System.EventHandler(this.pb_addTemperRule_Click);
            // 
            // pb_removeRequestRule
            // 
            this.pb_removeRequestRule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_removeRequestRule.BackColor = System.Drawing.Color.Transparent;
            this.pb_removeRequestRule.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_removeRequestRule.Image = ((System.Drawing.Image)(resources.GetObject("pb_removeRequestRule.Image")));
            this.pb_removeRequestRule.Location = new System.Drawing.Point(299, 1);
            this.pb_removeRequestRule.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pb_removeRequestRule.Name = "pb_removeRequestRule";
            this.pb_removeRequestRule.Size = new System.Drawing.Size(20, 20);
            this.pb_removeRequestRule.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_removeRequestRule.TabIndex = 52;
            this.pb_removeRequestRule.TabStop = false;
            this.toolTip_forMainWindow.SetToolTip(this.pb_removeRequestRule, "remove selected rule");
            this.pb_removeRequestRule.Click += new System.EventHandler(this.pb_removeTemperRule_Click);
            // 
            // pb_requestRuleSwitch
            // 
            this.pb_requestRuleSwitch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_requestRuleSwitch.BackColor = System.Drawing.Color.Transparent;
            this.pb_requestRuleSwitch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_requestRuleSwitch.Image = ((System.Drawing.Image)(resources.GetObject("pb_requestRuleSwitch.Image")));
            this.pb_requestRuleSwitch.Location = new System.Drawing.Point(317, 1);
            this.pb_requestRuleSwitch.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pb_requestRuleSwitch.Name = "pb_requestRuleSwitch";
            this.pb_requestRuleSwitch.Size = new System.Drawing.Size(36, 20);
            this.pb_requestRuleSwitch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_requestRuleSwitch.TabIndex = 38;
            this.pb_requestRuleSwitch.TabStop = false;
            this.toolTip_forMainWindow.SetToolTip(this.pb_requestRuleSwitch, "enable the requst rule");
            this.pb_requestRuleSwitch.Click += new System.EventHandler(this.pb_requestRuleSwitch_Click);
            // 
            // removeSelectedRuleToolStripMenuItem
            // 
            this.removeSelectedRuleToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("removeSelectedRuleToolStripMenuItem.Image")));
            this.removeSelectedRuleToolStripMenuItem.Name = "removeSelectedRuleToolStripMenuItem";
            this.removeSelectedRuleToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.removeSelectedRuleToolStripMenuItem.Text = "remove selected rule";
            this.removeSelectedRuleToolStripMenuItem.Click += new System.EventHandler(this.removeSelectedRuleToolStripMenuItem_Click);
            // 
            // removeAllRuleToolStripMenuItem
            // 
            this.removeAllRuleToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("removeAllRuleToolStripMenuItem.Image")));
            this.removeAllRuleToolStripMenuItem.Name = "removeAllRuleToolStripMenuItem";
            this.removeAllRuleToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.removeAllRuleToolStripMenuItem.Text = "remove all rule";
            this.removeAllRuleToolStripMenuItem.Click += new System.EventHandler(this.removeAllRuleToolStripMenuItem_Click);
            // 
            // enableThisRuleToolStripMenuItem
            // 
            this.enableThisRuleToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("enableThisRuleToolStripMenuItem.Image")));
            this.enableThisRuleToolStripMenuItem.Name = "enableThisRuleToolStripMenuItem";
            this.enableThisRuleToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.enableThisRuleToolStripMenuItem.Text = "enable this rule";
            this.enableThisRuleToolStripMenuItem.Click += new System.EventHandler(this.enableThisRuleToolStripMenuItem_Click);
            // 
            // enableAllRuleToolStripMenuItem
            // 
            this.enableAllRuleToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("enableAllRuleToolStripMenuItem.Image")));
            this.enableAllRuleToolStripMenuItem.Name = "enableAllRuleToolStripMenuItem";
            this.enableAllRuleToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.enableAllRuleToolStripMenuItem.Text = "enable all rule";
            this.enableAllRuleToolStripMenuItem.Click += new System.EventHandler(this.enableAllRuleToolStripMenuItem_Click);
            // 
            // unableAllRuleToolStripMenuItem
            // 
            this.unableAllRuleToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("unableAllRuleToolStripMenuItem.Image")));
            this.unableAllRuleToolStripMenuItem.Name = "unableAllRuleToolStripMenuItem";
            this.unableAllRuleToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.unableAllRuleToolStripMenuItem.Text = "unable all rule";
            this.unableAllRuleToolStripMenuItem.Click += new System.EventHandler(this.unableAllRuleToolStripMenuItem_Click);
            // 
            // editThisRuleToolStripMenuItem
            // 
            this.editThisRuleToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("editThisRuleToolStripMenuItem.Image")));
            this.editThisRuleToolStripMenuItem.Name = "editThisRuleToolStripMenuItem";
            this.editThisRuleToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.editThisRuleToolStripMenuItem.Text = "edit this rule";
            this.editThisRuleToolStripMenuItem.Click += new System.EventHandler(this.editThisRuleToolStripMenuItem_Click);
            // 
            // copySelectedRuleToolStripMenuItem
            // 
            this.copySelectedRuleToolStripMenuItem.Image = global::FreeHttp.Properties.Resources.copy;
            this.copySelectedRuleToolStripMenuItem.Name = "copySelectedRuleToolStripMenuItem";
            this.copySelectedRuleToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.copySelectedRuleToolStripMenuItem.Text = "copy selected rule";
            this.copySelectedRuleToolStripMenuItem.Click += new System.EventHandler(this.copySelectedRuleToolStripMenuItem_Click);
            // 
            // pb_addResponseRule
            // 
            this.pb_addResponseRule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_addResponseRule.BackColor = System.Drawing.Color.Transparent;
            this.pb_addResponseRule.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_addResponseRule.Image = ((System.Drawing.Image)(resources.GetObject("pb_addResponseRule.Image")));
            this.pb_addResponseRule.Location = new System.Drawing.Point(277, 1);
            this.pb_addResponseRule.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pb_addResponseRule.Name = "pb_addResponseRule";
            this.pb_addResponseRule.Size = new System.Drawing.Size(20, 20);
            this.pb_addResponseRule.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_addResponseRule.TabIndex = 55;
            this.pb_addResponseRule.TabStop = false;
            this.toolTip_forMainWindow.SetToolTip(this.pb_addResponseRule, "add a new response rule");
            this.pb_addResponseRule.Click += new System.EventHandler(this.pb_addTemperRule_Click);
            // 
            // pb_removeResponseRule
            // 
            this.pb_removeResponseRule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_removeResponseRule.BackColor = System.Drawing.Color.Transparent;
            this.pb_removeResponseRule.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_removeResponseRule.Image = ((System.Drawing.Image)(resources.GetObject("pb_removeResponseRule.Image")));
            this.pb_removeResponseRule.Location = new System.Drawing.Point(297, 1);
            this.pb_removeResponseRule.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pb_removeResponseRule.Name = "pb_removeResponseRule";
            this.pb_removeResponseRule.Size = new System.Drawing.Size(20, 20);
            this.pb_removeResponseRule.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_removeResponseRule.TabIndex = 54;
            this.pb_removeResponseRule.TabStop = false;
            this.toolTip_forMainWindow.SetToolTip(this.pb_removeResponseRule, "remove selected rule");
            this.pb_removeResponseRule.Click += new System.EventHandler(this.pb_removeTemperRule_Click);
            // 
            // pb_responseRuleSwitch
            // 
            this.pb_responseRuleSwitch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_responseRuleSwitch.BackColor = System.Drawing.Color.Transparent;
            this.pb_responseRuleSwitch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_responseRuleSwitch.Image = ((System.Drawing.Image)(resources.GetObject("pb_responseRuleSwitch.Image")));
            this.pb_responseRuleSwitch.Location = new System.Drawing.Point(317, 1);
            this.pb_responseRuleSwitch.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pb_responseRuleSwitch.Name = "pb_responseRuleSwitch";
            this.pb_responseRuleSwitch.Size = new System.Drawing.Size(36, 20);
            this.pb_responseRuleSwitch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_responseRuleSwitch.TabIndex = 39;
            this.pb_responseRuleSwitch.TabStop = false;
            this.toolTip_forMainWindow.SetToolTip(this.pb_responseRuleSwitch, "enable the response rule");
            this.pb_responseRuleSwitch.Click += new System.EventHandler(this.pb_responseRuleSwitch_Click);
            // 
            // currentValueToolStripMenuItem
            // 
            this.currentValueToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("currentValueToolStripMenuItem.Image")));
            this.currentValueToolStripMenuItem.Name = "currentValueToolStripMenuItem";
            this.currentValueToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.currentValueToolStripMenuItem.Text = "current value";
            this.currentValueToolStripMenuItem.Click += new System.EventHandler(this.addParameterDataToolStripMenuItem_Click);
            // 
            // nextValueToolStripMenuItem
            // 
            this.nextValueToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("nextValueToolStripMenuItem.Image")));
            this.nextValueToolStripMenuItem.Name = "nextValueToolStripMenuItem";
            this.nextValueToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.nextValueToolStripMenuItem.Text = "next value";
            this.nextValueToolStripMenuItem.Click += new System.EventHandler(this.addParameterDataToolStripMenuItem_Click);
            // 
            // previousValueToolStripMenuItem
            // 
            this.previousValueToolStripMenuItem.Image = global::FreeHttp.Properties.Resources._goto;
            this.previousValueToolStripMenuItem.Name = "previousValueToolStripMenuItem";
            this.previousValueToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.previousValueToolStripMenuItem.Text = "next multi value";
            this.previousValueToolStripMenuItem.Click += new System.EventHandler(this.addParameterDataToolStripMenuItem_Click);
            // 
            // FreeHttpWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer_main);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FreeHttpWindow";
            this.Size = new System.Drawing.Size(966, 552);
            this.Load += new System.EventHandler(this.FreeHttpWindow_Load);
            this.contextMenuStrip_AddFile.ResumeLayout(false);
            this.splitContainer_main.Panel1.ResumeLayout(false);
            this.splitContainer_main.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_main)).EndInit();
            this.splitContainer_main.ResumeLayout(false);
            this.splitContainer_httpEditInfo.Panel1.ResumeLayout(false);
            this.splitContainer_httpEditInfo.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_httpEditInfo)).EndInit();
            this.splitContainer_httpEditInfo.ResumeLayout(false);
            this.groupBox_urlFilter.ResumeLayout(false);
            this.groupBox_urlFilter.PerformLayout();
            this.splitContainer_httpControl.Panel1.ResumeLayout(false);
            this.splitContainer_httpControl.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_httpControl)).EndInit();
            this.splitContainer_httpControl.ResumeLayout(false);
            this.contextMenu_ruleList.ResumeLayout(false);
            this.contextMenuStrip_addParameter.ResumeLayout(false);
            this.panel_modific.ResumeLayout(false);
            this.tabControl_Modific.ResumeLayout(false);
            this.tabPage_requestModific.ResumeLayout(false);
            this.splitContainer_requestModific.Panel1.ResumeLayout(false);
            this.splitContainer_requestModific.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_requestModific)).EndInit();
            this.splitContainer_requestModific.ResumeLayout(false);
            this.groupBox_headsModific.ResumeLayout(false);
            this.groupBox_bodyModific.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox_uriModific.ResumeLayout(false);
            this.groupBox_uriModific.PerformLayout();
            this.tabPage_requestReplace.ResumeLayout(false);
            this.splitContainer_requestReplace.Panel1.ResumeLayout(false);
            this.splitContainer_requestReplace.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_requestReplace)).EndInit();
            this.splitContainer_requestReplace.ResumeLayout(false);
            this.panel_requestReplace_startLine.ResumeLayout(false);
            this.panel_requestReplace_startLine.PerformLayout();
            this.tabPage_responseModific.ResumeLayout(false);
            this.splitContainer_responseModific.Panel1.ResumeLayout(false);
            this.splitContainer_responseModific.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_responseModific)).EndInit();
            this.splitContainer_responseModific.ResumeLayout(false);
            this.groupBox_reponseHeadModific.ResumeLayout(false);
            this.groupBox_responseBodyModific.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.tabPage_responseReplace.ResumeLayout(false);
            this.panel_modific_Contorl.ResumeLayout(false);
            this.panel_modific_Contorl.PerformLayout();
            this.menuStrip_quickRule.ResumeLayout(false);
            this.menuStrip_quickRule.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_requestReplace_changeMode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_parameterSwitch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_protocolSwitch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_pickRule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_responseLatency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_ruleComfrim)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_ruleCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_editHttpFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_editRuleMode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_getSession)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_addRequestRule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_removeRequestRule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_requestRuleSwitch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_addResponseRule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_removeResponseRule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_responseRuleSwitch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer_main;
        private System.Windows.Forms.TabControl tabControl_Modific;
        private System.Windows.Forms.TabPage tabPage_requestModific;
        private System.Windows.Forms.TabPage tabPage_requestReplace;
        private System.Windows.Forms.TabPage tabPage_responseModific;
        private System.Windows.Forms.TabPage tabPage_responseReplace;
        private System.Windows.Forms.SplitContainer splitContainer_httpControl;
        private MyListView lv_requestRuleList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader_requstRule;
        private MyListView lv_responseRuleList;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader_responseRule;
        private System.Windows.Forms.GroupBox groupBox_urlFilter;
        private System.Windows.Forms.ComboBox cb_macthMode;
        private System.Windows.Forms.TextBox tb_urlFilter;
        private System.Windows.Forms.GroupBox groupBox_bodyModific;
        private System.Windows.Forms.GroupBox groupBox_headsModific;
        private System.Windows.Forms.GroupBox groupBox_uriModific;
        private System.Windows.Forms.PictureBox pb_ruleComfrim;
        private WatermakTextBox tb_requestModific_uriModificKey;
        private System.Windows.Forms.TextBox tb_requestModific_uriModificValue;
        private System.Windows.Forms.Label label1;
        private WatermakTextBox tb_requestModific_body;
        private EditListView requestRemoveHeads;
        private EditListView requestAddHeads;
        private System.Windows.Forms.SplitContainer splitContainer_requestModific;
        private MyPanel panel1;
        private MyPanel panel_modific_Contorl;
        private MyPanel panel2;
        private System.Windows.Forms.RichTextBox rtb_requestModific_body;
        private System.Windows.Forms.PictureBox pb_getSession;
        private System.Windows.Forms.PictureBox pictureBox_editRuleMode;
        private MyPanel panel_modific;
        private System.Windows.Forms.ComboBox cb_editRequestEdition;
        private System.Windows.Forms.ComboBox cb_editRequestMethod;
        private System.Windows.Forms.Label lb_editStartLine;
        private System.Windows.Forms.SplitContainer splitContainer_requestReplace;
        private MyPanel panel_requestReplace_startLine;
        private EditListView elv_requsetReplace;
        private System.Windows.Forms.PictureBox pb_requestReplace_changeMode;
        private System.Windows.Forms.RichTextBox rtb_requestRaw;
        private System.Windows.Forms.SplitContainer splitContainer_responseModific;
        private System.Windows.Forms.GroupBox groupBox_reponseHeadModific;
        private EditListView responseAddHeads;
        private System.Windows.Forms.GroupBox groupBox_responseBodyModific;
        private MyPanel panel3;
        private System.Windows.Forms.RichTextBox rtb_respenseModific_body;
        private MyPanel panel4;
        private WatermakTextBox tb_responseModific_body;
        private System.Windows.Forms.Label label2;
        private RawResponseEdit rawResponseEdit;
        private System.Windows.Forms.PictureBox pb_requestRuleSwitch;
        private System.Windows.Forms.PictureBox pb_responseRuleSwitch;
        private System.Windows.Forms.PictureBox pb_addRequestRule;
        private System.Windows.Forms.PictureBox pb_removeRequestRule;
        private System.Windows.Forms.PictureBox pb_addResponseRule;
        private System.Windows.Forms.PictureBox pb_removeResponseRule;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_AddFile;
        private System.Windows.Forms.ToolStripMenuItem addFileToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog_addFIle;
        private System.Windows.Forms.RichTextBox rtb_requsetReplace_body;
        private EditListView responseRemoveHeads;
        private WatermakTextBox tb_requestReplace_uri;
        private System.Windows.Forms.Label lb_editRuleMode;
        private System.Windows.Forms.SplitContainer splitContainer_httpEditInfo;
        private System.Windows.Forms.RichTextBox rtb_MesInfo;
        private System.Windows.Forms.ContextMenuStrip contextMenu_ruleList;
        private System.Windows.Forms.ToolStripMenuItem removeSelectedRuleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeAllRuleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enableAllRuleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unableAllRuleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enableThisRuleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editThisRuleToolStripMenuItem;
        private System.Windows.Forms.PictureBox pb_ruleCancel;
        private System.Windows.Forms.MenuStrip menuStrip_quickRule;
        private System.Windows.Forms.ToolStripMenuItem quickRuleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disableCacheToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addCookieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setClientCookieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificToolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showSelectedSessionStreamToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip_forMainWindow;
        private System.Windows.Forms.ToolStripMenuItem addUserAgentToolStripMenuItem;
        private TextBoxEditer tbe_RequestBodyModific;
        private TextBoxEditer tbe_ResponseBodyModific;
        private System.Windows.Forms.ToolStripMenuItem deleteCookieToolStripMenuItem;
        private System.Windows.Forms.PictureBox pb_responseLatency;
        private System.Windows.Forms.LinkLabel lbl_ResponseLatency;
        private TextBoxEditer tbe_urlFilter;
        private System.Windows.Forms.ToolStripMenuItem httpTamperSettingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copySessionCookiesToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox_editHttpFilter;
        private System.Windows.Forms.ToolStripMenuItem parameterDataManageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem antoContentLengthToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keyValueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parameterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataSouceToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator_addAndCheck;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_addParameter;
        private System.Windows.Forms.ToolStripMenuItem currentValueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nextValueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem previousValueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addParameterDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editDataToolStripMenuItem;
        private System.Windows.Forms.PictureBox pb_pickRule;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem removeSessionCookiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem feedbackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem codeInGithubToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem documentationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeSessionEncodingToolStripMenuItem;
        private MySwitchPictureButton pb_protocolSwitch;
        private MySwitchPictureButton pb_parameterSwitch;
        internal System.Windows.Forms.ToolStripMenuItem independentWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadingRemoteRuleToolStripMenuItem;
        internal System.Windows.Forms.ImageList imageList_forTab;
        private System.Windows.Forms.ToolStripMenuItem copySelectedRuleToolStripMenuItem;
    }
}
