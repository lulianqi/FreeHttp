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
            this.tb_responseModific_body = new FreeHttp.FreeHttpControl.WatermakTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage_responseReplace = new System.Windows.Forms.TabPage();
            this.rawResponseEdit = new FreeHttp.FreeHttpControl.RawResponseEdit();
            this.panel_modific_Contorl = new FreeHttp.FreeHttpControl.MyPanel();
            this.pb_ruleComfrim = new System.Windows.Forms.PictureBox();
            this.groupBox_urlFilter = new System.Windows.Forms.GroupBox();
            this.lb_editRuleMode = new System.Windows.Forms.Label();
            this.pictureBox_editRuleMode = new System.Windows.Forms.PictureBox();
            this.pb_getSession = new System.Windows.Forms.PictureBox();
            this.cb_macthMode = new System.Windows.Forms.ComboBox();
            this.tb_urlFilter = new System.Windows.Forms.TextBox();
            this.splitContainer_httpControl = new System.Windows.Forms.SplitContainer();
            this.pb_addRequestRule = new System.Windows.Forms.PictureBox();
            this.pb_removeRequestRule = new System.Windows.Forms.PictureBox();
            this.pb_requestRuleSwitch = new System.Windows.Forms.PictureBox();
            this.lv_requestRuleList = new FreeHttp.FreeHttpControl.MyListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_requstRule = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pb_addResponseRule = new System.Windows.Forms.PictureBox();
            this.pb_removeResponseRule = new System.Windows.Forms.PictureBox();
            this.pb_responseRuleSwitch = new System.Windows.Forms.PictureBox();
            this.lv_responseRuleList = new FreeHttp.FreeHttpControl.MyListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_responseRule = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip_AddFile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_main)).BeginInit();
            this.splitContainer_main.Panel1.SuspendLayout();
            this.splitContainer_main.Panel2.SuspendLayout();
            this.splitContainer_main.SuspendLayout();
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
            ((System.ComponentModel.ISupportInitialize)(this.pb_ruleComfrim)).BeginInit();
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
            this.splitContainer_main.Panel1.Controls.Add(this.panel_modific);
            this.splitContainer_main.Panel1.Controls.Add(this.groupBox_urlFilter);
            // 
            // splitContainer_main.Panel2
            // 
            this.splitContainer_main.Panel2.Controls.Add(this.splitContainer_httpControl);
            this.splitContainer_main.Size = new System.Drawing.Size(966, 552);
            this.splitContainer_main.SplitterDistance = 611;
            this.splitContainer_main.TabIndex = 0;
            // 
            // panel_modific
            // 
            this.panel_modific.Controls.Add(this.tabControl_Modific);
            this.panel_modific.Controls.Add(this.panel_modific_Contorl);
            this.panel_modific.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_modific.Location = new System.Drawing.Point(0, 44);
            this.panel_modific.Name = "panel_modific";
            this.panel_modific.Size = new System.Drawing.Size(611, 508);
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
            this.tabControl_Modific.Size = new System.Drawing.Size(611, 481);
            this.tabControl_Modific.TabIndex = 0;
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
            this.tabPage_requestModific.Size = new System.Drawing.Size(603, 454);
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
            this.splitContainer_requestModific.Size = new System.Drawing.Size(597, 395);
            this.splitContainer_requestModific.SplitterDistance = 93;
            this.splitContainer_requestModific.TabIndex = 1;
            // 
            // groupBox_headsModific
            // 
            this.groupBox_headsModific.Controls.Add(this.requestAddHeads);
            this.groupBox_headsModific.Controls.Add(this.requestRemoveHeads);
            this.groupBox_headsModific.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_headsModific.Location = new System.Drawing.Point(0, 0);
            this.groupBox_headsModific.Name = "groupBox_headsModific";
            this.groupBox_headsModific.Size = new System.Drawing.Size(597, 93);
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
            this.requestAddHeads.Size = new System.Drawing.Size(310, 73);
            this.requestAddHeads.TabIndex = 1;
            // 
            // requestRemoveHeads
            // 
            this.requestRemoveHeads.ColumnHeaderName = "Remove Head";
            this.requestRemoveHeads.Dock = System.Windows.Forms.DockStyle.Left;
            this.requestRemoveHeads.IsKeyValue = false;
            this.requestRemoveHeads.Location = new System.Drawing.Point(3, 17);
            this.requestRemoveHeads.Name = "requestRemoveHeads";
            this.requestRemoveHeads.Size = new System.Drawing.Size(275, 73);
            this.requestRemoveHeads.TabIndex = 0;
            // 
            // groupBox_bodyModific
            // 
            this.groupBox_bodyModific.Controls.Add(this.panel2);
            this.groupBox_bodyModific.Controls.Add(this.panel1);
            this.groupBox_bodyModific.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_bodyModific.Location = new System.Drawing.Point(0, 0);
            this.groupBox_bodyModific.Name = "groupBox_bodyModific";
            this.groupBox_bodyModific.Size = new System.Drawing.Size(597, 298);
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
            this.panel2.Size = new System.Drawing.Size(591, 245);
            this.panel2.TabIndex = 48;
            // 
            // rtb_requestModific_body
            // 
            this.rtb_requestModific_body.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_requestModific_body.Location = new System.Drawing.Point(0, 0);
            this.rtb_requestModific_body.Name = "rtb_requestModific_body";
            this.rtb_requestModific_body.Size = new System.Drawing.Size(591, 245);
            this.rtb_requestModific_body.TabIndex = 0;
            this.rtb_requestModific_body.Text = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tb_requestModific_body);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(591, 33);
            this.panel1.TabIndex = 47;
            // 
            // tb_requestModific_body
            // 
            this.tb_requestModific_body.Location = new System.Drawing.Point(69, 5);
            this.tb_requestModific_body.Name = "tb_requestModific_body";
            this.tb_requestModific_body.Size = new System.Drawing.Size(519, 21);
            this.tb_requestModific_body.TabIndex = 47;
            this.tb_requestModific_body.WatermarkText = "empty mean replace all body";
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
            this.tb_requestModific_uriModificKey.WatermarkText = "empty is all";
            // 
            // tb_requestModific_uriModificValue
            // 
            this.tb_requestModific_uriModificValue.Location = new System.Drawing.Point(106, 20);
            this.tb_requestModific_uriModificValue.Name = "tb_requestModific_uriModificValue";
            this.tb_requestModific_uriModificValue.Size = new System.Drawing.Size(485, 21);
            this.tb_requestModific_uriModificValue.TabIndex = 3;
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
            this.tabPage_requestReplace.Size = new System.Drawing.Size(603, 454);
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
            this.splitContainer_requestReplace.Size = new System.Drawing.Size(597, 415);
            this.splitContainer_requestReplace.SplitterDistance = 142;
            this.splitContainer_requestReplace.TabIndex = 18;
            // 
            // elv_requsetReplace
            // 
            this.elv_requsetReplace.ColumnHeaderName = "Request Heads";
            this.elv_requsetReplace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elv_requsetReplace.IsKeyValue = true;
            this.elv_requsetReplace.Location = new System.Drawing.Point(0, 0);
            this.elv_requsetReplace.Name = "elv_requsetReplace";
            this.elv_requsetReplace.Size = new System.Drawing.Size(597, 142);
            this.elv_requsetReplace.TabIndex = 2;
            // 
            // rtb_requsetReplace_body
            // 
            this.rtb_requsetReplace_body.ContextMenuStrip = this.contextMenuStrip_AddFile;
            this.rtb_requsetReplace_body.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_requsetReplace_body.Location = new System.Drawing.Point(0, 0);
            this.rtb_requsetReplace_body.Name = "rtb_requsetReplace_body";
            this.rtb_requsetReplace_body.Size = new System.Drawing.Size(597, 269);
            this.rtb_requsetReplace_body.TabIndex = 1;
            this.rtb_requsetReplace_body.Text = "";
            // 
            // rtb_requestRaw
            // 
            this.rtb_requestRaw.ContextMenuStrip = this.contextMenuStrip_AddFile;
            this.rtb_requestRaw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_requestRaw.Location = new System.Drawing.Point(3, 36);
            this.rtb_requestRaw.Name = "rtb_requestRaw";
            this.rtb_requestRaw.Size = new System.Drawing.Size(597, 415);
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
            this.pb_requestReplace_changeMode.Click += new System.EventHandler(this.pb_requestReplace_changeMode_Click);
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
            this.cb_editRequestMethod.Location = new System.Drawing.Point(76, 5);
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
            this.tabPage_responseModific.Size = new System.Drawing.Size(603, 454);
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
            this.splitContainer_responseModific.Size = new System.Drawing.Size(597, 448);
            this.splitContainer_responseModific.SplitterDistance = 105;
            this.splitContainer_responseModific.TabIndex = 2;
            // 
            // groupBox_reponseHeadModific
            // 
            this.groupBox_reponseHeadModific.Controls.Add(this.responseAddHeads);
            this.groupBox_reponseHeadModific.Controls.Add(this.responseRemoveHeads);
            this.groupBox_reponseHeadModific.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_reponseHeadModific.Location = new System.Drawing.Point(0, 0);
            this.groupBox_reponseHeadModific.Name = "groupBox_reponseHeadModific";
            this.groupBox_reponseHeadModific.Size = new System.Drawing.Size(597, 105);
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
            this.responseAddHeads.Size = new System.Drawing.Size(310, 85);
            this.responseAddHeads.TabIndex = 1;
            // 
            // responseRemoveHeads
            // 
            this.responseRemoveHeads.ColumnHeaderName = "Remove Head";
            this.responseRemoveHeads.Dock = System.Windows.Forms.DockStyle.Left;
            this.responseRemoveHeads.IsKeyValue = false;
            this.responseRemoveHeads.Location = new System.Drawing.Point(3, 17);
            this.responseRemoveHeads.Name = "responseRemoveHeads";
            this.responseRemoveHeads.Size = new System.Drawing.Size(275, 85);
            this.responseRemoveHeads.TabIndex = 0;
            // 
            // groupBox_responseBodyModific
            // 
            this.groupBox_responseBodyModific.Controls.Add(this.panel3);
            this.groupBox_responseBodyModific.Controls.Add(this.panel4);
            this.groupBox_responseBodyModific.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_responseBodyModific.Location = new System.Drawing.Point(0, 0);
            this.groupBox_responseBodyModific.Name = "groupBox_responseBodyModific";
            this.groupBox_responseBodyModific.Size = new System.Drawing.Size(597, 339);
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
            this.panel3.Size = new System.Drawing.Size(591, 286);
            this.panel3.TabIndex = 48;
            // 
            // rtb_respenseModific_body
            // 
            this.rtb_respenseModific_body.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_respenseModific_body.Location = new System.Drawing.Point(0, 0);
            this.rtb_respenseModific_body.Name = "rtb_respenseModific_body";
            this.rtb_respenseModific_body.Size = new System.Drawing.Size(591, 286);
            this.rtb_respenseModific_body.TabIndex = 0;
            this.rtb_respenseModific_body.Text = "";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.tb_responseModific_body);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(3, 17);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(591, 33);
            this.panel4.TabIndex = 47;
            // 
            // tb_responseModific_body
            // 
            this.tb_responseModific_body.Location = new System.Drawing.Point(69, 5);
            this.tb_responseModific_body.Name = "tb_responseModific_body";
            this.tb_responseModific_body.Size = new System.Drawing.Size(519, 21);
            this.tb_responseModific_body.TabIndex = 47;
            this.tb_responseModific_body.WatermarkText = "empty mean replace all body";
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
            this.tabPage_responseReplace.Size = new System.Drawing.Size(603, 454);
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
            this.rawResponseEdit.Size = new System.Drawing.Size(597, 448);
            this.rawResponseEdit.TabIndex = 0;
            // 
            // panel_modific_Contorl
            // 
            this.panel_modific_Contorl.Controls.Add(this.pb_ruleComfrim);
            this.panel_modific_Contorl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_modific_Contorl.Location = new System.Drawing.Point(0, 481);
            this.panel_modific_Contorl.Name = "panel_modific_Contorl";
            this.panel_modific_Contorl.Size = new System.Drawing.Size(611, 27);
            this.panel_modific_Contorl.TabIndex = 0;
            // 
            // pb_ruleComfrim
            // 
            this.pb_ruleComfrim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_ruleComfrim.BackColor = System.Drawing.Color.Transparent;
            this.pb_ruleComfrim.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_ruleComfrim.Image = ((System.Drawing.Image)(resources.GetObject("pb_ruleComfrim.Image")));
            this.pb_ruleComfrim.Location = new System.Drawing.Point(584, 2);
            this.pb_ruleComfrim.Name = "pb_ruleComfrim";
            this.pb_ruleComfrim.Size = new System.Drawing.Size(23, 22);
            this.pb_ruleComfrim.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_ruleComfrim.TabIndex = 37;
            this.pb_ruleComfrim.TabStop = false;
            this.pb_ruleComfrim.Click += new System.EventHandler(this.pb_ruleComfrim_Click);
            // 
            // groupBox_urlFilter
            // 
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
            this.pictureBox_editRuleMode.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox_editRuleMode.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_editRuleMode.Image")));
            this.pictureBox_editRuleMode.Location = new System.Drawing.Point(489, 17);
            this.pictureBox_editRuleMode.Name = "pictureBox_editRuleMode";
            this.pictureBox_editRuleMode.Size = new System.Drawing.Size(23, 22);
            this.pictureBox_editRuleMode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_editRuleMode.TabIndex = 39;
            this.pictureBox_editRuleMode.TabStop = false;
            // 
            // pb_getSession
            // 
            this.pb_getSession.BackColor = System.Drawing.Color.Transparent;
            this.pb_getSession.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_getSession.Image = ((System.Drawing.Image)(resources.GetObject("pb_getSession.Image")));
            this.pb_getSession.Location = new System.Drawing.Point(5, 17);
            this.pb_getSession.Name = "pb_getSession";
            this.pb_getSession.Size = new System.Drawing.Size(23, 22);
            this.pb_getSession.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_getSession.TabIndex = 38;
            this.pb_getSession.TabStop = false;
            this.pb_getSession.Click += new System.EventHandler(this.pb_getSession_Click);
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
            this.cb_macthMode.SelectedIndexChanged += new System.EventHandler(this.cb_macthMode_SelectedIndexChanged);
            // 
            // tb_urlFilter
            // 
            this.tb_urlFilter.Location = new System.Drawing.Point(126, 18);
            this.tb_urlFilter.Name = "tb_urlFilter";
            this.tb_urlFilter.Size = new System.Drawing.Size(361, 21);
            this.tb_urlFilter.TabIndex = 0;
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
            this.pb_requestRuleSwitch.Click += new System.EventHandler(this.pb_requestRuleSwitch_Click);
            // 
            // lv_requestRuleList
            // 
            this.lv_requestRuleList.CheckBoxes = true;
            this.lv_requestRuleList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader_requstRule});
            this.lv_requestRuleList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_requestRuleList.FullRowSelect = true;
            this.lv_requestRuleList.Location = new System.Drawing.Point(0, 0);
            this.lv_requestRuleList.Name = "lv_requestRuleList";
            this.lv_requestRuleList.Size = new System.Drawing.Size(351, 203);
            this.lv_requestRuleList.SmallImageList = this.imageList_forTab;
            this.lv_requestRuleList.TabIndex = 0;
            this.lv_requestRuleList.UseCompatibleStateImageBehavior = false;
            this.lv_requestRuleList.View = System.Windows.Forms.View.Details;
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
            this.pb_responseRuleSwitch.Click += new System.EventHandler(this.pb_responseRuleSwitch_Click);
            // 
            // lv_responseRuleList
            // 
            this.lv_responseRuleList.CheckBoxes = true;
            this.lv_responseRuleList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader_responseRule});
            this.lv_responseRuleList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_responseRuleList.FullRowSelect = true;
            this.lv_responseRuleList.Location = new System.Drawing.Point(0, 0);
            this.lv_responseRuleList.Name = "lv_responseRuleList";
            this.lv_responseRuleList.Size = new System.Drawing.Size(351, 345);
            this.lv_responseRuleList.SmallImageList = this.imageList_forTab;
            this.lv_responseRuleList.TabIndex = 1;
            this.lv_responseRuleList.UseCompatibleStateImageBehavior = false;
            this.lv_responseRuleList.View = System.Windows.Forms.View.Details;
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
            ((System.ComponentModel.ISupportInitialize)(this.pb_ruleComfrim)).EndInit();
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

    }
}
