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
            this.addFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.antoContentLengthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog_addFIle = new System.Windows.Forms.OpenFileDialog();
            this.splitContainer_main = new System.Windows.Forms.SplitContainer();
            this.splitContainer_httpEditInfo = new System.Windows.Forms.SplitContainer();
            this.rtb_MesInfo = new System.Windows.Forms.RichTextBox();
            this.groupBox_urlFilter = new System.Windows.Forms.GroupBox();
            this.tb_urlFilter = new System.Windows.Forms.TextBox();
            this.lb_editRuleMode = new System.Windows.Forms.Label();
            this.pictureBox_editRuleMode = new System.Windows.Forms.PictureBox();
            this.pb_getSession = new System.Windows.Forms.PictureBox();
            this.cb_macthMode = new System.Windows.Forms.ComboBox();
            this.splitContainer_httpControl = new System.Windows.Forms.SplitContainer();
            this.pb_addRequestRule = new System.Windows.Forms.PictureBox();
            this.pb_removeRequestRule = new System.Windows.Forms.PictureBox();
            this.pb_requestRuleSwitch = new System.Windows.Forms.PictureBox();
            this.contextMenu_ruleList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeSelectedRuleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeAllRuleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableThisRuleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableAllRuleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unableAllRuleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editThisRuleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pb_addResponseRule = new System.Windows.Forms.PictureBox();
            this.pb_removeResponseRule = new System.Windows.Forms.PictureBox();
            this.pb_responseRuleSwitch = new System.Windows.Forms.PictureBox();
            this.toolTip_forMainWindow = new System.Windows.Forms.ToolTip(this.components);
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
            this.pb_requestReplace_changeMode = new System.Windows.Forms.PictureBox();
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
            this.pb_responseLatency = new System.Windows.Forms.PictureBox();
            this.pb_ruleComfrim = new System.Windows.Forms.PictureBox();
            this.pb_ruleCancel = new System.Windows.Forms.PictureBox();
            this.menuStrip_quickRule = new System.Windows.Forms.MenuStrip();
            this.quickRuleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disableCacheToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addCookieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteCookieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setClientCookieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addUserAgentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showSelectedSessionStreamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.httpTamperSettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbe_urlFilter = new FreeHttp.FreeHttpControl.TextBoxEditer();
            this.lv_requestRuleList = new FreeHttp.FreeHttpControl.MyListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_requstRule = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lv_responseRuleList = new FreeHttp.FreeHttpControl.MyListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_responseRule = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_editRuleMode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_getSession)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_httpControl)).BeginInit();
            this.splitContainer_httpControl.Panel1.SuspendLayout();
            this.splitContainer_httpControl.Panel2.SuspendLayout();
            this.splitContainer_httpControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_addRequestRule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_removeRequestRule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_requestRuleSwitch)).BeginInit();
            this.contextMenu_ruleList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_addResponseRule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_removeResponseRule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_responseRuleSwitch)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.pb_requestReplace_changeMode)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.pb_responseLatency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_ruleComfrim)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_ruleCancel)).BeginInit();
            this.menuStrip_quickRule.SuspendLayout();
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
            // 
            // contextMenuStrip_AddFile
            // 
            this.contextMenuStrip_AddFile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addFileToolStripMenuItem,
            this.antoContentLengthToolStripMenuItem});
            this.contextMenuStrip_AddFile.Name = "contextMenuStrip_forRtbResponse";
            this.contextMenuStrip_AddFile.Size = new System.Drawing.Size(196, 48);
            // 
            // addFileToolStripMenuItem
            // 
            this.addFileToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("addFileToolStripMenuItem.Image")));
            this.addFileToolStripMenuItem.Name = "addFileToolStripMenuItem";
            this.addFileToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.addFileToolStripMenuItem.Text = "add file";
            this.addFileToolStripMenuItem.Click += new System.EventHandler(this.addFileToolStripMenuItem_Click);
            // 
            // antoContentLengthToolStripMenuItem
            // 
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
            this.splitContainer_main.SplitterDistance = 611;
            this.splitContainer_main.TabIndex = 0;
            // 
            // splitContainer_httpEditInfo
            // 
            this.splitContainer_httpEditInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_httpEditInfo.Location = new System.Drawing.Point(0, 44);
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
            this.splitContainer_httpEditInfo.Size = new System.Drawing.Size(611, 508);
            this.splitContainer_httpEditInfo.SplitterDistance = 358;
            this.splitContainer_httpEditInfo.TabIndex = 7;
            // 
            // rtb_MesInfo
            // 
            this.rtb_MesInfo.BackColor = System.Drawing.SystemColors.ControlLight;
            this.rtb_MesInfo.DetectUrls = false;
            this.rtb_MesInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_MesInfo.HideSelection = false;
            this.rtb_MesInfo.Location = new System.Drawing.Point(0, 0);
            this.rtb_MesInfo.Name = "rtb_MesInfo";
            this.rtb_MesInfo.Size = new System.Drawing.Size(611, 146);
            this.rtb_MesInfo.TabIndex = 0;
            this.rtb_MesInfo.Text = "";
            // 
            // groupBox_urlFilter
            // 
            this.groupBox_urlFilter.Controls.Add(this.tbe_urlFilter);
            this.groupBox_urlFilter.Controls.Add(this.lb_editRuleMode);
            this.groupBox_urlFilter.Controls.Add(this.pictureBox_editRuleMode);
            this.groupBox_urlFilter.Controls.Add(this.pb_getSession);
            this.groupBox_urlFilter.Controls.Add(this.cb_macthMode);
            this.groupBox_urlFilter.Controls.Add(this.tb_urlFilter);
            this.groupBox_urlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_urlFilter.Location = new System.Drawing.Point(0, 0);
            this.groupBox_urlFilter.Name = "groupBox_urlFilter";
            this.groupBox_urlFilter.Size = new System.Drawing.Size(611, 44);
            this.groupBox_urlFilter.TabIndex = 6;
            this.groupBox_urlFilter.TabStop = false;
            this.groupBox_urlFilter.Text = "Url Filter";
            // 
            // tb_urlFilter
            // 
            this.tb_urlFilter.Location = new System.Drawing.Point(126, 18);
            this.tb_urlFilter.Name = "tb_urlFilter";
            this.tb_urlFilter.Size = new System.Drawing.Size(361, 21);
            this.tb_urlFilter.TabIndex = 0;
            this.toolTip_forMainWindow.SetToolTip(this.tb_urlFilter, "the match vaule (match full url include http:// and ？key=value)");
            this.tb_urlFilter.Enter += new System.EventHandler(this.tb_Modific_body_Enter);
            this.tb_urlFilter.Leave += new System.EventHandler(this.tb_Modific_body_Leave);
            // 
            // lb_editRuleMode
            // 
            this.lb_editRuleMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_editRuleMode.AutoSize = true;
            this.lb_editRuleMode.Location = new System.Drawing.Point(515, 23);
            this.lb_editRuleMode.Name = "lb_editRuleMode";
            this.lb_editRuleMode.Size = new System.Drawing.Size(53, 12);
            this.lb_editRuleMode.TabIndex = 40;
            this.lb_editRuleMode.Text = "New Rule";
            // 
            // pictureBox_editRuleMode
            // 
            this.pictureBox_editRuleMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_editRuleMode.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_editRuleMode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_editRuleMode.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_editRuleMode.Image")));
            this.pictureBox_editRuleMode.Location = new System.Drawing.Point(489, 17);
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
            this.pb_getSession.Location = new System.Drawing.Point(5, 17);
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
            this.cb_macthMode.Location = new System.Drawing.Point(31, 19);
            this.cb_macthMode.Name = "cb_macthMode";
            this.cb_macthMode.Size = new System.Drawing.Size(89, 20);
            this.cb_macthMode.TabIndex = 2;
            this.toolTip_forMainWindow.SetToolTip(this.cb_macthMode, resources.GetString("cb_macthMode.ToolTip"));
            this.cb_macthMode.SelectedIndexChanged += new System.EventHandler(this.cb_macthMode_SelectedIndexChanged);
            // 
            // splitContainer_httpControl
            // 
            this.splitContainer_httpControl.BackColor = System.Drawing.SystemColors.Window;
            this.splitContainer_httpControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_httpControl.Location = new System.Drawing.Point(0, 0);
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
            this.splitContainer_httpControl.Size = new System.Drawing.Size(351, 552);
            this.splitContainer_httpControl.SplitterDistance = 203;
            this.splitContainer_httpControl.TabIndex = 0;
            this.splitContainer_httpControl.Resize += new System.EventHandler(this.splitContainer_httpControl_Resize);
            // 
            // pb_addRequestRule
            // 
            this.pb_addRequestRule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_addRequestRule.BackColor = System.Drawing.Color.Transparent;
            this.pb_addRequestRule.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_addRequestRule.Image = ((System.Drawing.Image)(resources.GetObject("pb_addRequestRule.Image")));
            this.pb_addRequestRule.Location = new System.Drawing.Point(276, 1);
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
            this.pb_removeRequestRule.Location = new System.Drawing.Point(296, 1);
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
            this.pb_requestRuleSwitch.Location = new System.Drawing.Point(314, 1);
            this.pb_requestRuleSwitch.Name = "pb_requestRuleSwitch";
            this.pb_requestRuleSwitch.Size = new System.Drawing.Size(36, 20);
            this.pb_requestRuleSwitch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_requestRuleSwitch.TabIndex = 38;
            this.pb_requestRuleSwitch.TabStop = false;
            this.toolTip_forMainWindow.SetToolTip(this.pb_requestRuleSwitch, "enable the requst rule");
            this.pb_requestRuleSwitch.Click += new System.EventHandler(this.pb_requestRuleSwitch_Click);
            // 
            // contextMenu_ruleList
            // 
            this.contextMenu_ruleList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeSelectedRuleToolStripMenuItem,
            this.removeAllRuleToolStripMenuItem,
            this.enableThisRuleToolStripMenuItem,
            this.enableAllRuleToolStripMenuItem,
            this.unableAllRuleToolStripMenuItem,
            this.editThisRuleToolStripMenuItem});
            this.contextMenu_ruleList.Name = "contextMenu_ruleList";
            this.contextMenu_ruleList.Size = new System.Drawing.Size(199, 136);
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
            // pb_addResponseRule
            // 
            this.pb_addResponseRule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_addResponseRule.BackColor = System.Drawing.Color.Transparent;
            this.pb_addResponseRule.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_addResponseRule.Image = ((System.Drawing.Image)(resources.GetObject("pb_addResponseRule.Image")));
            this.pb_addResponseRule.Location = new System.Drawing.Point(274, 1);
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
            this.pb_removeResponseRule.Location = new System.Drawing.Point(294, 1);
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
            this.pb_responseRuleSwitch.Location = new System.Drawing.Point(314, 1);
            this.pb_responseRuleSwitch.Name = "pb_responseRuleSwitch";
            this.pb_responseRuleSwitch.Size = new System.Drawing.Size(36, 20);
            this.pb_responseRuleSwitch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_responseRuleSwitch.TabIndex = 39;
            this.pb_responseRuleSwitch.TabStop = false;
            this.toolTip_forMainWindow.SetToolTip(this.pb_responseRuleSwitch, "enable the response rule");
            this.pb_responseRuleSwitch.Click += new System.EventHandler(this.pb_responseRuleSwitch_Click);
            // 
            // panel_modific
            // 
            this.panel_modific.BackColor = System.Drawing.SystemColors.Control;
            this.panel_modific.Controls.Add(this.tabControl_Modific);
            this.panel_modific.Controls.Add(this.panel_modific_Contorl);
            this.panel_modific.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_modific.Location = new System.Drawing.Point(0, 0);
            this.panel_modific.Name = "panel_modific";
            this.panel_modific.Size = new System.Drawing.Size(611, 358);
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
            this.tabControl_Modific.Name = "tabControl_Modific";
            this.tabControl_Modific.SelectedIndex = 0;
            this.tabControl_Modific.Size = new System.Drawing.Size(611, 331);
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
            this.tabPage_requestModific.Name = "tabPage_requestModific";
            this.tabPage_requestModific.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_requestModific.Size = new System.Drawing.Size(603, 304);
            this.tabPage_requestModific.TabIndex = 0;
            this.tabPage_requestModific.Text = "Request Modific";
            // 
            // splitContainer_requestModific
            // 
            this.splitContainer_requestModific.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_requestModific.Location = new System.Drawing.Point(3, 56);
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
            this.splitContainer_requestModific.Size = new System.Drawing.Size(597, 245);
            this.splitContainer_requestModific.SplitterDistance = 112;
            this.splitContainer_requestModific.TabIndex = 1;
            // 
            // groupBox_headsModific
            // 
            this.groupBox_headsModific.Controls.Add(this.requestAddHeads);
            this.groupBox_headsModific.Controls.Add(this.requestRemoveHeads);
            this.groupBox_headsModific.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_headsModific.Location = new System.Drawing.Point(0, 0);
            this.groupBox_headsModific.Name = "groupBox_headsModific";
            this.groupBox_headsModific.Size = new System.Drawing.Size(597, 112);
            this.groupBox_headsModific.TabIndex = 1;
            this.groupBox_headsModific.TabStop = false;
            this.groupBox_headsModific.Text = "Heads Modific";
            // 
            // requestAddHeads
            // 
            this.requestAddHeads.ColumnHeaderName = "Add Head";
            this.requestAddHeads.Dock = System.Windows.Forms.DockStyle.Right;
            this.requestAddHeads.IsKeyValue = true;
            this.requestAddHeads.Location = new System.Drawing.Point(284, 17);
            this.requestAddHeads.Name = "requestAddHeads";
            this.requestAddHeads.Size = new System.Drawing.Size(310, 92);
            this.requestAddHeads.TabIndex = 1;
            // 
            // requestRemoveHeads
            // 
            this.requestRemoveHeads.ColumnHeaderName = "Remove Head";
            this.requestRemoveHeads.Dock = System.Windows.Forms.DockStyle.Left;
            this.requestRemoveHeads.IsKeyValue = false;
            this.requestRemoveHeads.Location = new System.Drawing.Point(3, 17);
            this.requestRemoveHeads.Name = "requestRemoveHeads";
            this.requestRemoveHeads.Size = new System.Drawing.Size(275, 92);
            this.requestRemoveHeads.TabIndex = 0;
            // 
            // groupBox_bodyModific
            // 
            this.groupBox_bodyModific.Controls.Add(this.panel2);
            this.groupBox_bodyModific.Controls.Add(this.panel1);
            this.groupBox_bodyModific.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_bodyModific.Location = new System.Drawing.Point(0, 0);
            this.groupBox_bodyModific.Name = "groupBox_bodyModific";
            this.groupBox_bodyModific.Size = new System.Drawing.Size(597, 129);
            this.groupBox_bodyModific.TabIndex = 2;
            this.groupBox_bodyModific.TabStop = false;
            this.groupBox_bodyModific.Text = "Body Modific";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rtb_requestModific_body);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 50);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(591, 76);
            this.panel2.TabIndex = 48;
            // 
            // rtb_requestModific_body
            // 
            this.rtb_requestModific_body.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_requestModific_body.Location = new System.Drawing.Point(0, 0);
            this.rtb_requestModific_body.Name = "rtb_requestModific_body";
            this.rtb_requestModific_body.Size = new System.Drawing.Size(591, 76);
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
            this.panel1.Location = new System.Drawing.Point(3, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(591, 33);
            this.panel1.TabIndex = 47;
            // 
            // tbe_RequestBodyModific
            // 
            this.tbe_RequestBodyModific.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbe_RequestBodyModific.EditTextBox = this.tb_requestModific_body;
            this.tbe_RequestBodyModific.Location = new System.Drawing.Point(568, 4);
            this.tbe_RequestBodyModific.MainContainerControl = this;
            this.tbe_RequestBodyModific.Name = "tbe_RequestBodyModific";
            this.tbe_RequestBodyModific.Size = new System.Drawing.Size(21, 21);
            this.tbe_RequestBodyModific.TabIndex = 49;
            // 
            // tb_requestModific_body
            // 
            this.tb_requestModific_body.AcceptsReturn = true;
            this.tb_requestModific_body.Location = new System.Drawing.Point(69, 5);
            this.tb_requestModific_body.Name = "tb_requestModific_body";
            this.tb_requestModific_body.Size = new System.Drawing.Size(519, 21);
            this.tb_requestModific_body.TabIndex = 47;
            this.tb_requestModific_body.WatermarkText = "empty mean replace all body";
            this.tb_requestModific_body.Enter += new System.EventHandler(this.tb_Modific_body_Enter);
            this.tb_requestModific_body.Leave += new System.EventHandler(this.tb_Modific_body_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 9);
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
            this.groupBox_uriModific.Location = new System.Drawing.Point(3, 3);
            this.groupBox_uriModific.Name = "groupBox_uriModific";
            this.groupBox_uriModific.Size = new System.Drawing.Size(597, 53);
            this.groupBox_uriModific.TabIndex = 0;
            this.groupBox_uriModific.TabStop = false;
            this.groupBox_uriModific.Text = "Uri Modific";
            // 
            // tb_requestModific_uriModificKey
            // 
            this.tb_requestModific_uriModificKey.Location = new System.Drawing.Point(6, 20);
            this.tb_requestModific_uriModificKey.Name = "tb_requestModific_uriModificKey";
            this.tb_requestModific_uriModificKey.Size = new System.Drawing.Size(94, 21);
            this.tb_requestModific_uriModificKey.TabIndex = 4;
            this.toolTip_forMainWindow.SetToolTip(this.tb_requestModific_uriModificKey, "set it empty when you want replace all the full url");
            this.tb_requestModific_uriModificKey.WatermarkText = "empty is all";
            // 
            // tb_requestModific_uriModificValue
            // 
            this.tb_requestModific_uriModificValue.Location = new System.Drawing.Point(106, 20);
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
            this.tabPage_requestReplace.Name = "tabPage_requestReplace";
            this.tabPage_requestReplace.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_requestReplace.Size = new System.Drawing.Size(603, 304);
            this.tabPage_requestReplace.TabIndex = 1;
            this.tabPage_requestReplace.Text = "Request Replace";
            this.tabPage_requestReplace.UseVisualStyleBackColor = true;
            // 
            // splitContainer_requestReplace
            // 
            this.splitContainer_requestReplace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_requestReplace.Location = new System.Drawing.Point(3, 36);
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
            this.splitContainer_requestReplace.Size = new System.Drawing.Size(597, 265);
            this.splitContainer_requestReplace.SplitterDistance = 108;
            this.splitContainer_requestReplace.TabIndex = 18;
            // 
            // elv_requsetReplace
            // 
            this.elv_requsetReplace.ColumnHeaderName = "Request Heads";
            this.elv_requsetReplace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elv_requsetReplace.IsKeyValue = true;
            this.elv_requsetReplace.Location = new System.Drawing.Point(0, 0);
            this.elv_requsetReplace.Name = "elv_requsetReplace";
            this.elv_requsetReplace.Size = new System.Drawing.Size(597, 108);
            this.elv_requsetReplace.TabIndex = 2;
            // 
            // rtb_requsetReplace_body
            // 
            this.rtb_requsetReplace_body.ContextMenuStrip = this.contextMenuStrip_AddFile;
            this.rtb_requsetReplace_body.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_requsetReplace_body.Location = new System.Drawing.Point(0, 0);
            this.rtb_requsetReplace_body.Name = "rtb_requsetReplace_body";
            this.rtb_requsetReplace_body.Size = new System.Drawing.Size(597, 153);
            this.rtb_requsetReplace_body.TabIndex = 1;
            this.rtb_requsetReplace_body.Text = "";
            // 
            // rtb_requestRaw
            // 
            this.rtb_requestRaw.ContextMenuStrip = this.contextMenuStrip_AddFile;
            this.rtb_requestRaw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_requestRaw.Location = new System.Drawing.Point(3, 36);
            this.rtb_requestRaw.Name = "rtb_requestRaw";
            this.rtb_requestRaw.Size = new System.Drawing.Size(597, 265);
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
            this.panel_requestReplace_startLine.Location = new System.Drawing.Point(3, 3);
            this.panel_requestReplace_startLine.Name = "panel_requestReplace_startLine";
            this.panel_requestReplace_startLine.Size = new System.Drawing.Size(597, 33);
            this.panel_requestReplace_startLine.TabIndex = 17;
            // 
            // pb_requestReplace_changeMode
            // 
            this.pb_requestReplace_changeMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_requestReplace_changeMode.BackColor = System.Drawing.Color.Transparent;
            this.pb_requestReplace_changeMode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_requestReplace_changeMode.Image = ((System.Drawing.Image)(resources.GetObject("pb_requestReplace_changeMode.Image")));
            this.pb_requestReplace_changeMode.Location = new System.Drawing.Point(571, 5);
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
            // lb_editStartLine
            // 
            this.lb_editStartLine.AutoSize = true;
            this.lb_editStartLine.Location = new System.Drawing.Point(3, 9);
            this.lb_editStartLine.Name = "lb_editStartLine";
            this.lb_editStartLine.Size = new System.Drawing.Size(71, 12);
            this.lb_editStartLine.TabIndex = 13;
            this.lb_editStartLine.Text = "Start Line:";
            // 
            // tb_requestReplace_uri
            // 
            this.tb_requestReplace_uri.Location = new System.Drawing.Point(160, 6);
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
            this.cb_editRequestEdition.Location = new System.Drawing.Point(488, 6);
            this.cb_editRequestEdition.Name = "cb_editRequestEdition";
            this.cb_editRequestEdition.Size = new System.Drawing.Size(78, 20);
            this.cb_editRequestEdition.TabIndex = 15;
            // 
            // tabPage_responseModific
            // 
            this.tabPage_responseModific.Controls.Add(this.splitContainer_responseModific);
            this.tabPage_responseModific.ImageKey = "request_modific.png";
            this.tabPage_responseModific.Location = new System.Drawing.Point(4, 23);
            this.tabPage_responseModific.Name = "tabPage_responseModific";
            this.tabPage_responseModific.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_responseModific.Size = new System.Drawing.Size(603, 304);
            this.tabPage_responseModific.TabIndex = 2;
            this.tabPage_responseModific.Text = "Response Modific";
            this.tabPage_responseModific.UseVisualStyleBackColor = true;
            // 
            // splitContainer_responseModific
            // 
            this.splitContainer_responseModific.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_responseModific.Location = new System.Drawing.Point(3, 3);
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
            this.splitContainer_responseModific.Size = new System.Drawing.Size(597, 298);
            this.splitContainer_responseModific.SplitterDistance = 119;
            this.splitContainer_responseModific.TabIndex = 2;
            // 
            // groupBox_reponseHeadModific
            // 
            this.groupBox_reponseHeadModific.Controls.Add(this.responseAddHeads);
            this.groupBox_reponseHeadModific.Controls.Add(this.responseRemoveHeads);
            this.groupBox_reponseHeadModific.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_reponseHeadModific.Location = new System.Drawing.Point(0, 0);
            this.groupBox_reponseHeadModific.Name = "groupBox_reponseHeadModific";
            this.groupBox_reponseHeadModific.Size = new System.Drawing.Size(597, 119);
            this.groupBox_reponseHeadModific.TabIndex = 1;
            this.groupBox_reponseHeadModific.TabStop = false;
            this.groupBox_reponseHeadModific.Text = "Heads Modific";
            // 
            // responseAddHeads
            // 
            this.responseAddHeads.ColumnHeaderName = "Add Head";
            this.responseAddHeads.Dock = System.Windows.Forms.DockStyle.Right;
            this.responseAddHeads.IsKeyValue = true;
            this.responseAddHeads.Location = new System.Drawing.Point(284, 17);
            this.responseAddHeads.Name = "responseAddHeads";
            this.responseAddHeads.Size = new System.Drawing.Size(310, 99);
            this.responseAddHeads.TabIndex = 1;
            // 
            // responseRemoveHeads
            // 
            this.responseRemoveHeads.ColumnHeaderName = "Remove Head";
            this.responseRemoveHeads.Dock = System.Windows.Forms.DockStyle.Left;
            this.responseRemoveHeads.IsKeyValue = false;
            this.responseRemoveHeads.Location = new System.Drawing.Point(3, 17);
            this.responseRemoveHeads.Name = "responseRemoveHeads";
            this.responseRemoveHeads.Size = new System.Drawing.Size(275, 99);
            this.responseRemoveHeads.TabIndex = 0;
            // 
            // groupBox_responseBodyModific
            // 
            this.groupBox_responseBodyModific.Controls.Add(this.panel3);
            this.groupBox_responseBodyModific.Controls.Add(this.panel4);
            this.groupBox_responseBodyModific.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_responseBodyModific.Location = new System.Drawing.Point(0, 0);
            this.groupBox_responseBodyModific.Name = "groupBox_responseBodyModific";
            this.groupBox_responseBodyModific.Size = new System.Drawing.Size(597, 175);
            this.groupBox_responseBodyModific.TabIndex = 2;
            this.groupBox_responseBodyModific.TabStop = false;
            this.groupBox_responseBodyModific.Text = "Body Modific";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.rtb_respenseModific_body);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 50);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(591, 122);
            this.panel3.TabIndex = 48;
            // 
            // rtb_respenseModific_body
            // 
            this.rtb_respenseModific_body.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_respenseModific_body.Location = new System.Drawing.Point(0, 0);
            this.rtb_respenseModific_body.Name = "rtb_respenseModific_body";
            this.rtb_respenseModific_body.Size = new System.Drawing.Size(591, 122);
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
            this.panel4.Location = new System.Drawing.Point(3, 17);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(591, 33);
            this.panel4.TabIndex = 47;
            // 
            // tbe_ResponseBodyModific
            // 
            this.tbe_ResponseBodyModific.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbe_ResponseBodyModific.EditTextBox = this.tb_responseModific_body;
            this.tbe_ResponseBodyModific.Location = new System.Drawing.Point(567, 5);
            this.tbe_ResponseBodyModific.MainContainerControl = this;
            this.tbe_ResponseBodyModific.Name = "tbe_ResponseBodyModific";
            this.tbe_ResponseBodyModific.Size = new System.Drawing.Size(21, 21);
            this.tbe_ResponseBodyModific.TabIndex = 50;
            // 
            // tb_responseModific_body
            // 
            this.tb_responseModific_body.Location = new System.Drawing.Point(69, 5);
            this.tb_responseModific_body.Name = "tb_responseModific_body";
            this.tb_responseModific_body.Size = new System.Drawing.Size(519, 21);
            this.tb_responseModific_body.TabIndex = 47;
            this.tb_responseModific_body.WatermarkText = "empty mean replace all body";
            this.tb_responseModific_body.Enter += new System.EventHandler(this.tb_Modific_body_Enter);
            this.tb_responseModific_body.Leave += new System.EventHandler(this.tb_Modific_body_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 9);
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
            this.tabPage_responseReplace.Name = "tabPage_responseReplace";
            this.tabPage_responseReplace.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_responseReplace.Size = new System.Drawing.Size(603, 304);
            this.tabPage_responseReplace.TabIndex = 3;
            this.tabPage_responseReplace.Text = "Response Replace";
            this.tabPage_responseReplace.UseVisualStyleBackColor = true;
            // 
            // rawResponseEdit
            // 
            this.rawResponseEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rawResponseEdit.IsDirectRespons = false;
            this.rawResponseEdit.Location = new System.Drawing.Point(3, 3);
            this.rawResponseEdit.Name = "rawResponseEdit";
            this.rawResponseEdit.Size = new System.Drawing.Size(597, 298);
            this.rawResponseEdit.TabIndex = 0;
            // 
            // panel_modific_Contorl
            // 
            this.panel_modific_Contorl.Controls.Add(this.lbl_ResponseLatency);
            this.panel_modific_Contorl.Controls.Add(this.pb_responseLatency);
            this.panel_modific_Contorl.Controls.Add(this.pb_ruleComfrim);
            this.panel_modific_Contorl.Controls.Add(this.pb_ruleCancel);
            this.panel_modific_Contorl.Controls.Add(this.menuStrip_quickRule);
            this.panel_modific_Contorl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_modific_Contorl.Location = new System.Drawing.Point(0, 331);
            this.panel_modific_Contorl.Name = "panel_modific_Contorl";
            this.panel_modific_Contorl.Size = new System.Drawing.Size(611, 27);
            this.panel_modific_Contorl.TabIndex = 0;
            // 
            // lbl_ResponseLatency
            // 
            this.lbl_ResponseLatency.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_ResponseLatency.AutoSize = true;
            this.lbl_ResponseLatency.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbl_ResponseLatency.Location = new System.Drawing.Point(534, 8);
            this.lbl_ResponseLatency.Name = "lbl_ResponseLatency";
            this.lbl_ResponseLatency.Size = new System.Drawing.Size(11, 12);
            this.lbl_ResponseLatency.TabIndex = 41;
            this.lbl_ResponseLatency.TabStop = true;
            this.lbl_ResponseLatency.Text = "0";
            this.toolTip_forMainWindow.SetToolTip(this.lbl_ResponseLatency, "set response latency");
            this.lbl_ResponseLatency.Click += new System.EventHandler(this.pb_responseLatency_Click);
            // 
            // pb_responseLatency
            // 
            this.pb_responseLatency.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_responseLatency.BackColor = System.Drawing.Color.Transparent;
            this.pb_responseLatency.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_responseLatency.Image = ((System.Drawing.Image)(resources.GetObject("pb_responseLatency.Image")));
            this.pb_responseLatency.Location = new System.Drawing.Point(531, 2);
            this.pb_responseLatency.Name = "pb_responseLatency";
            this.pb_responseLatency.Size = new System.Drawing.Size(24, 24);
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
            this.pb_ruleComfrim.Location = new System.Drawing.Point(584, 2);
            this.pb_ruleComfrim.Name = "pb_ruleComfrim";
            this.pb_ruleComfrim.Size = new System.Drawing.Size(24, 24);
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
            this.pb_ruleCancel.Image = ((System.Drawing.Image)(resources.GetObject("pb_ruleCancel.Image")));
            this.pb_ruleCancel.Location = new System.Drawing.Point(557, 2);
            this.pb_ruleCancel.Name = "pb_ruleCancel";
            this.pb_ruleCancel.Size = new System.Drawing.Size(24, 24);
            this.pb_ruleCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_ruleCancel.TabIndex = 38;
            this.pb_ruleCancel.TabStop = false;
            this.toolTip_forMainWindow.SetToolTip(this.pb_ruleCancel, "clear your rule edit info");
            this.pb_ruleCancel.Click += new System.EventHandler(this.pb_ruleCancel_Click);
            this.pb_ruleCancel.MouseLeave += new System.EventHandler(this.pictureBox_MouseLeave);
            this.pb_ruleCancel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            // 
            // menuStrip_quickRule
            // 
            this.menuStrip_quickRule.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip_quickRule.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quickRuleToolStripMenuItem,
            this.modificToolToolStripMenuItem});
            this.menuStrip_quickRule.Location = new System.Drawing.Point(5, 0);
            this.menuStrip_quickRule.Name = "menuStrip_quickRule";
            this.menuStrip_quickRule.Size = new System.Drawing.Size(182, 25);
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
            this.addUserAgentToolStripMenuItem});
            this.quickRuleToolStripMenuItem.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.quickRuleToolStripMenuItem.Name = "quickRuleToolStripMenuItem";
            this.quickRuleToolStripMenuItem.Padding = new System.Windows.Forms.Padding(2, 0, 4, 0);
            this.quickRuleToolStripMenuItem.Size = new System.Drawing.Size(80, 21);
            this.quickRuleToolStripMenuItem.Text = "Quick Rule";
            // 
            // disableCacheToolStripMenuItem
            // 
            this.disableCacheToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("disableCacheToolStripMenuItem.Image")));
            this.disableCacheToolStripMenuItem.Name = "disableCacheToolStripMenuItem";
            this.disableCacheToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.disableCacheToolStripMenuItem.Text = "disable cache";
            this.disableCacheToolStripMenuItem.Click += new System.EventHandler(this.disableCacheToolStripMenuItem_Click);
            // 
            // addCookieToolStripMenuItem
            // 
            this.addCookieToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("addCookieToolStripMenuItem.Image")));
            this.addCookieToolStripMenuItem.Name = "addCookieToolStripMenuItem";
            this.addCookieToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.addCookieToolStripMenuItem.Text = "add cookie";
            this.addCookieToolStripMenuItem.Click += new System.EventHandler(this.addCookieToolStripMenuItem_Click);
            // 
            // deleteCookieToolStripMenuItem
            // 
            this.deleteCookieToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("deleteCookieToolStripMenuItem.Image")));
            this.deleteCookieToolStripMenuItem.Name = "deleteCookieToolStripMenuItem";
            this.deleteCookieToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.deleteCookieToolStripMenuItem.Text = "delete cookie";
            this.deleteCookieToolStripMenuItem.Click += new System.EventHandler(this.deleteCookieToolStripMenuItem_Click);
            // 
            // setClientCookieToolStripMenuItem
            // 
            this.setClientCookieToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("setClientCookieToolStripMenuItem.Image")));
            this.setClientCookieToolStripMenuItem.Name = "setClientCookieToolStripMenuItem";
            this.setClientCookieToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.setClientCookieToolStripMenuItem.Text = "set client cookie";
            this.setClientCookieToolStripMenuItem.Click += new System.EventHandler(this.setClientCookieToolStripMenuItem_Click);
            // 
            // addUserAgentToolStripMenuItem
            // 
            this.addUserAgentToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("addUserAgentToolStripMenuItem.Image")));
            this.addUserAgentToolStripMenuItem.Name = "addUserAgentToolStripMenuItem";
            this.addUserAgentToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.addUserAgentToolStripMenuItem.Text = "add UserAgent";
            this.addUserAgentToolStripMenuItem.Click += new System.EventHandler(this.addUserAgentToolStripMenuItem_Click);
            // 
            // modificToolToolStripMenuItem
            // 
            this.modificToolToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showSelectedSessionStreamToolStripMenuItem,
            this.httpTamperSettingToolStripMenuItem});
            this.modificToolToolStripMenuItem.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.modificToolToolStripMenuItem.Name = "modificToolToolStripMenuItem";
            this.modificToolToolStripMenuItem.Size = new System.Drawing.Size(94, 21);
            this.modificToolToolStripMenuItem.Text = "Modific Tool";
            // 
            // showSelectedSessionStreamToolStripMenuItem
            // 
            this.showSelectedSessionStreamToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("showSelectedSessionStreamToolStripMenuItem.Image")));
            this.showSelectedSessionStreamToolStripMenuItem.Name = "showSelectedSessionStreamToolStripMenuItem";
            this.showSelectedSessionStreamToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.showSelectedSessionStreamToolStripMenuItem.Text = "show selected session stream";
            this.showSelectedSessionStreamToolStripMenuItem.Click += new System.EventHandler(this.showSelectedSessionStreamToolStripMenuItem_Click);
            // 
            // httpTamperSettingToolStripMenuItem
            // 
            this.httpTamperSettingToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("httpTamperSettingToolStripMenuItem.Image")));
            this.httpTamperSettingToolStripMenuItem.Name = "httpTamperSettingToolStripMenuItem";
            this.httpTamperSettingToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.httpTamperSettingToolStripMenuItem.Text = "http tamper setting";
            this.httpTamperSettingToolStripMenuItem.Click += new System.EventHandler(this.httpTamperSettingToolStripMenuItem_Click);
            // 
            // tbe_urlFilter
            // 
            this.tbe_urlFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbe_urlFilter.EditTextBox = this.tb_urlFilter;
            this.tbe_urlFilter.Location = new System.Drawing.Point(466, 18);
            this.tbe_urlFilter.MainContainerControl = this;
            this.tbe_urlFilter.Name = "tbe_urlFilter";
            this.tbe_urlFilter.Size = new System.Drawing.Size(21, 21);
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
            this.lv_requestRuleList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_requestRuleList.FullRowSelect = true;
            this.lv_requestRuleList.Location = new System.Drawing.Point(0, 0);
            this.lv_requestRuleList.Name = "lv_requestRuleList";
            this.lv_requestRuleList.ShowItemToolTips = true;
            this.lv_requestRuleList.Size = new System.Drawing.Size(351, 203);
            this.lv_requestRuleList.SmallImageList = this.imageList_forTab;
            this.lv_requestRuleList.TabIndex = 0;
            this.lv_requestRuleList.UseCompatibleStateImageBehavior = false;
            this.lv_requestRuleList.View = System.Windows.Forms.View.Details;
            this.lv_requestRuleList.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lv_RuleList_ItemChecked);
            this.lv_requestRuleList.DoubleClick += new System.EventHandler(this.lv_RuleList_DoubleClick);
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
            this.lv_responseRuleList.Location = new System.Drawing.Point(0, 0);
            this.lv_responseRuleList.Name = "lv_responseRuleList";
            this.lv_responseRuleList.ShowItemToolTips = true;
            this.lv_responseRuleList.Size = new System.Drawing.Size(351, 345);
            this.lv_responseRuleList.SmallImageList = this.imageList_forTab;
            this.lv_responseRuleList.TabIndex = 1;
            this.lv_responseRuleList.UseCompatibleStateImageBehavior = false;
            this.lv_responseRuleList.View = System.Windows.Forms.View.Details;
            this.lv_responseRuleList.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lv_RuleList_ItemChecked);
            this.lv_responseRuleList.DoubleClick += new System.EventHandler(this.lv_RuleList_DoubleClick);
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
            // FreeHttpWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer_main);
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_editRuleMode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_getSession)).EndInit();
            this.splitContainer_httpControl.Panel1.ResumeLayout(false);
            this.splitContainer_httpControl.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_httpControl)).EndInit();
            this.splitContainer_httpControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_addRequestRule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_removeRequestRule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_requestRuleSwitch)).EndInit();
            this.contextMenu_ruleList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_addResponseRule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_removeResponseRule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_responseRuleSwitch)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.pb_requestReplace_changeMode)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.pb_responseLatency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_ruleComfrim)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_ruleCancel)).EndInit();
            this.menuStrip_quickRule.ResumeLayout(false);
            this.menuStrip_quickRule.PerformLayout();
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
        private System.Windows.Forms.ImageList imageList_forTab;
        private System.Windows.Forms.PictureBox pb_addRequestRule;
        private System.Windows.Forms.PictureBox pb_removeRequestRule;
        private System.Windows.Forms.PictureBox pb_addResponseRule;
        private System.Windows.Forms.PictureBox pb_removeResponseRule;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_AddFile;
        private System.Windows.Forms.ToolStripMenuItem addFileToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog_addFIle;
        private System.Windows.Forms.RichTextBox rtb_requsetReplace_body;
        private System.Windows.Forms.ToolStripMenuItem antoContentLengthToolStripMenuItem;
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

    }
}
