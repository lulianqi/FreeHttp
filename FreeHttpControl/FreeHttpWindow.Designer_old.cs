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
            this.splitContainer_main = new System.Windows.Forms.SplitContainer();
            this.tabControl_Modific = new System.Windows.Forms.TabControl();
            this.tabPage_requestModific = new System.Windows.Forms.TabPage();
            this.panel_modific_Contorl = new MyPanel();
            this.groupBox_uriModific = new System.Windows.Forms.GroupBox();
            this.tb_requestModific_uriModificValue = new System.Windows.Forms.TextBox();
            this.tabPage_requestReplace = new System.Windows.Forms.TabPage();
            this.tabPage_responseModific = new System.Windows.Forms.TabPage();
            this.tabPage_responseReplace = new System.Windows.Forms.TabPage();
            this.groupBox_urlFilter = new System.Windows.Forms.GroupBox();
            this.lb_editRuleMode = new System.Windows.Forms.Label();
            this.cb_macthMode = new System.Windows.Forms.ComboBox();
            this.tb_urlFilter = new System.Windows.Forms.TextBox();
            this.splitContainer_httpControl = new System.Windows.Forms.SplitContainer();
            this.lv_requestRuleList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_requstRule = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lv_responseRuleList = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_responseRule = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cb_editRequestEdition = new System.Windows.Forms.ComboBox();
            this.cb_editRequestMethod = new System.Windows.Forms.ComboBox();
            this.lb_editStartLine = new System.Windows.Forms.Label();
            this.panel_modific = new MyPanel();
            this.panel_requestReplace_startLine = new MyPanel();
            this.splitContainer_requestReplace = new System.Windows.Forms.SplitContainer();
            this.rtb_requsetReplace_body = new System.Windows.Forms.RichTextBox();
            this.rtb_requestRaw = new System.Windows.Forms.RichTextBox();
            this.splitContainer_responseModific = new System.Windows.Forms.SplitContainer();
            this.groupBox_reponseHeadModific = new System.Windows.Forms.GroupBox();
            this.groupBox_responseBodyModific = new System.Windows.Forms.GroupBox();
            this.panel3 = new MyPanel();
            this.rtb_reponseModific_body = new System.Windows.Forms.RichTextBox();
            this.panel4 = new MyPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.pb_requestReplace_changeMode = new System.Windows.Forms.PictureBox();
            this.pb_editCookietComfrim = new System.Windows.Forms.PictureBox();
            this.pictureBox_editRuleMode = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pb_requestRuleSwitch = new System.Windows.Forms.PictureBox();
            this.pb_responseRuleSwitch = new System.Windows.Forms.PictureBox();
            this.imageList_forTab = new System.Windows.Forms.ImageList(this.components);
            this.pictureBox_add = new System.Windows.Forms.PictureBox();
            this.pictureBox_remove = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.splitContainer_requestModific = new System.Windows.Forms.SplitContainer();
            this.groupBox_headsModific = new System.Windows.Forms.GroupBox();
            this.groupBox_bodyModific = new System.Windows.Forms.GroupBox();
            this.panel2 = new MyPanel();
            this.rtb_requestModific_body = new System.Windows.Forms.RichTextBox();
            this.panel1 = new MyPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.requestAddHeads = new FreeHttp.FreeHttpControl.EditListView();
            this.requestRemoveHeads = new FreeHttp.FreeHttpControl.EditListView();
            this.tb_requestModific_body = new FreeHttp.FreeHttpControl.WatermakTextBox();
            this.tb_requestModific_uriModificKey = new FreeHttp.FreeHttpControl.WatermakTextBox();
            this.editListView1 = new FreeHttp.FreeHttpControl.EditListView();
            this.tb_requestReplace_uri = new FreeHttp.FreeHttpControl.WatermakTextBox();
            this.responseAddHeads = new FreeHttp.FreeHttpControl.EditListView();
            this.responseRemoveHeads = new FreeHttp.FreeHttpControl.EditListView();
            this.tb_responseModific_body = new FreeHttp.FreeHttpControl.WatermakTextBox();
            this.rawResponseEdit1 = new FreeHttp.FreeHttpControl.RawResponseEdit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_main)).BeginInit();
            this.splitContainer_main.Panel1.SuspendLayout();
            this.splitContainer_main.Panel2.SuspendLayout();
            this.splitContainer_main.SuspendLayout();
            this.tabControl_Modific.SuspendLayout();
            this.tabPage_requestModific.SuspendLayout();
            this.panel_modific_Contorl.SuspendLayout();
            this.groupBox_uriModific.SuspendLayout();
            this.tabPage_requestReplace.SuspendLayout();
            this.tabPage_responseModific.SuspendLayout();
            this.tabPage_responseReplace.SuspendLayout();
            this.groupBox_urlFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_httpControl)).BeginInit();
            this.splitContainer_httpControl.Panel1.SuspendLayout();
            this.splitContainer_httpControl.Panel2.SuspendLayout();
            this.splitContainer_httpControl.SuspendLayout();
            this.panel_modific.SuspendLayout();
            this.panel_requestReplace_startLine.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_requestReplace)).BeginInit();
            this.splitContainer_requestReplace.Panel1.SuspendLayout();
            this.splitContainer_requestReplace.Panel2.SuspendLayout();
            this.splitContainer_requestReplace.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_responseModific)).BeginInit();
            this.splitContainer_responseModific.Panel1.SuspendLayout();
            this.splitContainer_responseModific.Panel2.SuspendLayout();
            this.splitContainer_responseModific.SuspendLayout();
            this.groupBox_reponseHeadModific.SuspendLayout();
            this.groupBox_responseBodyModific.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_requestReplace_changeMode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_editCookietComfrim)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_editRuleMode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_requestRuleSwitch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_responseRuleSwitch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_add)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_remove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_requestModific)).BeginInit();
            this.splitContainer_requestModific.Panel1.SuspendLayout();
            this.splitContainer_requestModific.Panel2.SuspendLayout();
            this.splitContainer_requestModific.SuspendLayout();
            this.groupBox_headsModific.SuspendLayout();
            this.groupBox_bodyModific.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            this.splitContainer_main.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer_main_Paint);
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
            this.tabControl_Modific.Resize += new System.EventHandler(this.tabControl_Modific_Resize);
            // 
            // tabPage_requestModific
            // 
            this.tabPage_requestModific.Controls.Add(this.splitContainer_requestModific);
            this.tabPage_requestModific.Controls.Add(this.groupBox_uriModific);
            this.tabPage_requestModific.ImageKey = "request_modific.png";
            this.tabPage_requestModific.Location = new System.Drawing.Point(4, 23);
            this.tabPage_requestModific.Name = "tabPage_requestModific";
            this.tabPage_requestModific.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_requestModific.Size = new System.Drawing.Size(603, 454);
            this.tabPage_requestModific.TabIndex = 0;
            this.tabPage_requestModific.Text = "Request Modific";
            this.tabPage_requestModific.UseVisualStyleBackColor = true;
            // 
            // panel_modific_Contorl
            // 
            this.panel_modific_Contorl.Controls.Add(this.pb_editCookietComfrim);
            this.panel_modific_Contorl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_modific_Contorl.Location = new System.Drawing.Point(0, 481);
            this.panel_modific_Contorl.Name = "panel_modific_Contorl";
            this.panel_modific_Contorl.Size = new System.Drawing.Size(611, 27);
            this.panel_modific_Contorl.TabIndex = 0;
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
            // tabPage_responseReplace
            // 
            this.tabPage_responseReplace.Controls.Add(this.rawResponseEdit1);
            this.tabPage_responseReplace.ImageKey = "request_replace.png";
            this.tabPage_responseReplace.Location = new System.Drawing.Point(4, 23);
            this.tabPage_responseReplace.Name = "tabPage_responseReplace";
            this.tabPage_responseReplace.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_responseReplace.Size = new System.Drawing.Size(603, 454);
            this.tabPage_responseReplace.TabIndex = 3;
            this.tabPage_responseReplace.Text = "Response Replace";
            this.tabPage_responseReplace.UseVisualStyleBackColor = true;
            // 
            // groupBox_urlFilter
            // 
            this.groupBox_urlFilter.Controls.Add(this.lb_editRuleMode);
            this.groupBox_urlFilter.Controls.Add(this.pictureBox_editRuleMode);
            this.groupBox_urlFilter.Controls.Add(this.pictureBox1);
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
            this.lb_editRuleMode.Location = new System.Drawing.Point(522, 23);
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
            "AllPass "});
            this.cb_macthMode.Location = new System.Drawing.Point(31, 19);
            this.cb_macthMode.Name = "cb_macthMode";
            this.cb_macthMode.Size = new System.Drawing.Size(89, 20);
            this.cb_macthMode.TabIndex = 2;
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
            this.splitContainer_httpControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_httpControl.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_httpControl.Name = "splitContainer_httpControl";
            this.splitContainer_httpControl.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer_httpControl.Panel1
            // 
            this.splitContainer_httpControl.Panel1.Controls.Add(this.pictureBox_add);
            this.splitContainer_httpControl.Panel1.Controls.Add(this.pictureBox_remove);
            this.splitContainer_httpControl.Panel1.Controls.Add(this.pb_requestRuleSwitch);
            this.splitContainer_httpControl.Panel1.Controls.Add(this.lv_requestRuleList);
            // 
            // splitContainer_httpControl.Panel2
            // 
            this.splitContainer_httpControl.Panel2.Controls.Add(this.pictureBox2);
            this.splitContainer_httpControl.Panel2.Controls.Add(this.pictureBox3);
            this.splitContainer_httpControl.Panel2.Controls.Add(this.pb_responseRuleSwitch);
            this.splitContainer_httpControl.Panel2.Controls.Add(this.lv_responseRuleList);
            this.splitContainer_httpControl.Size = new System.Drawing.Size(351, 552);
            this.splitContainer_httpControl.SplitterDistance = 203;
            this.splitContainer_httpControl.TabIndex = 0;
            // 
            // lv_requestRuleList
            // 
            this.lv_requestRuleList.CheckBoxes = true;
            this.lv_requestRuleList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader_requstRule});
            this.lv_requestRuleList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_requestRuleList.Location = new System.Drawing.Point(0, 0);
            this.lv_requestRuleList.Name = "lv_requestRuleList";
            this.lv_requestRuleList.Size = new System.Drawing.Size(351, 203);
            this.lv_requestRuleList.TabIndex = 0;
            this.lv_requestRuleList.UseCompatibleStateImageBehavior = false;
            this.lv_requestRuleList.View = System.Windows.Forms.View.Details;
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
            this.lv_responseRuleList.CheckBoxes = true;
            this.lv_responseRuleList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader_responseRule});
            this.lv_responseRuleList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_responseRuleList.Location = new System.Drawing.Point(0, 0);
            this.lv_responseRuleList.Name = "lv_responseRuleList";
            this.lv_responseRuleList.Size = new System.Drawing.Size(351, 345);
            this.lv_responseRuleList.TabIndex = 1;
            this.lv_responseRuleList.UseCompatibleStateImageBehavior = false;
            this.lv_responseRuleList.View = System.Windows.Forms.View.Details;
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
            // cb_editRequestEdition
            // 
            this.cb_editRequestEdition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_editRequestEdition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            // cb_editRequestMethod
            // 
            this.cb_editRequestMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            // lb_editStartLine
            // 
            this.lb_editStartLine.AutoSize = true;
            this.lb_editStartLine.Location = new System.Drawing.Point(3, 9);
            this.lb_editStartLine.Name = "lb_editStartLine";
            this.lb_editStartLine.Size = new System.Drawing.Size(71, 12);
            this.lb_editStartLine.TabIndex = 13;
            this.lb_editStartLine.Text = "Start Line:";
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
            // splitContainer_requestReplace
            // 
            this.splitContainer_requestReplace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_requestReplace.Location = new System.Drawing.Point(3, 36);
            this.splitContainer_requestReplace.Name = "splitContainer_requestReplace";
            this.splitContainer_requestReplace.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer_requestReplace.Panel1
            // 
            this.splitContainer_requestReplace.Panel1.Controls.Add(this.editListView1);
            // 
            // splitContainer_requestReplace.Panel2
            // 
            this.splitContainer_requestReplace.Panel2.Controls.Add(this.rtb_requsetReplace_body);
            this.splitContainer_requestReplace.Size = new System.Drawing.Size(597, 415);
            this.splitContainer_requestReplace.SplitterDistance = 142;
            this.splitContainer_requestReplace.TabIndex = 18;
            // 
            // rtb_requsetReplace_body
            // 
            this.rtb_requsetReplace_body.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_requsetReplace_body.Location = new System.Drawing.Point(0, 0);
            this.rtb_requsetReplace_body.Name = "rtb_requsetReplace_body";
            this.rtb_requsetReplace_body.Size = new System.Drawing.Size(597, 269);
            this.rtb_requsetReplace_body.TabIndex = 1;
            this.rtb_requsetReplace_body.Text = "";
            // 
            // rtb_requestRaw
            // 
            this.rtb_requestRaw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_requestRaw.Location = new System.Drawing.Point(3, 36);
            this.rtb_requestRaw.Name = "rtb_requestRaw";
            this.rtb_requestRaw.Size = new System.Drawing.Size(597, 415);
            this.rtb_requestRaw.TabIndex = 0;
            this.rtb_requestRaw.Text = "";
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
            this.panel3.Controls.Add(this.rtb_reponseModific_body);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 50);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(591, 286);
            this.panel3.TabIndex = 48;
            // 
            // rtb_reponseModific_body
            // 
            this.rtb_reponseModific_body.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_reponseModific_body.Location = new System.Drawing.Point(0, 0);
            this.rtb_reponseModific_body.Name = "rtb_reponseModific_body";
            this.rtb_reponseModific_body.Size = new System.Drawing.Size(591, 286);
            this.rtb_reponseModific_body.TabIndex = 0;
            this.rtb_reponseModific_body.Text = "";
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 48;
            this.label2.Text = "Replace";
            // 
            // pb_requestReplace_changeMode
            // 
            this.pb_requestReplace_changeMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_requestReplace_changeMode.BackColor = System.Drawing.Color.Transparent;
            this.pb_requestReplace_changeMode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_requestReplace_changeMode.Image = ((System.Drawing.Image)(resources.GetObject("pb_requestReplace_changeMode.Image")));
            this.pb_requestReplace_changeMode.Location = new System.Drawing.Point(571, 4);
            this.pb_requestReplace_changeMode.Name = "pb_requestReplace_changeMode";
            this.pb_requestReplace_changeMode.Size = new System.Drawing.Size(23, 22);
            this.pb_requestReplace_changeMode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_requestReplace_changeMode.TabIndex = 38;
            this.pb_requestReplace_changeMode.TabStop = false;
            this.pb_requestReplace_changeMode.Click += new System.EventHandler(this.pb_requestReplace_changeMode_Click);
            // 
            // pb_editCookietComfrim
            // 
            this.pb_editCookietComfrim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_editCookietComfrim.BackColor = System.Drawing.Color.Transparent;
            this.pb_editCookietComfrim.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_editCookietComfrim.Image = ((System.Drawing.Image)(resources.GetObject("pb_editCookietComfrim.Image")));
            this.pb_editCookietComfrim.Location = new System.Drawing.Point(584, 2);
            this.pb_editCookietComfrim.Name = "pb_editCookietComfrim";
            this.pb_editCookietComfrim.Size = new System.Drawing.Size(23, 22);
            this.pb_editCookietComfrim.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_editCookietComfrim.TabIndex = 37;
            this.pb_editCookietComfrim.TabStop = false;
            // 
            // pictureBox_editRuleMode
            // 
            this.pictureBox_editRuleMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_editRuleMode.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_editRuleMode.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox_editRuleMode.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_editRuleMode.Image")));
            this.pictureBox_editRuleMode.Location = new System.Drawing.Point(496, 17);
            this.pictureBox_editRuleMode.Name = "pictureBox_editRuleMode";
            this.pictureBox_editRuleMode.Size = new System.Drawing.Size(23, 22);
            this.pictureBox_editRuleMode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_editRuleMode.TabIndex = 39;
            this.pictureBox_editRuleMode.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(5, 17);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(23, 22);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 38;
            this.pictureBox1.TabStop = false;
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
            // imageList_forTab
            // 
            this.imageList_forTab.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_forTab.ImageStream")));
            this.imageList_forTab.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_forTab.Images.SetKeyName(0, "request_modific.png");
            this.imageList_forTab.Images.SetKeyName(1, "request_replace.png");
            this.imageList_forTab.Images.SetKeyName(2, "response_modific.png");
            this.imageList_forTab.Images.SetKeyName(3, "response_replace.png");
            // 
            // pictureBox_add
            // 
            this.pictureBox_add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_add.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_add.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_add.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_add.Image")));
            this.pictureBox_add.Location = new System.Drawing.Point(276, 1);
            this.pictureBox_add.Name = "pictureBox_add";
            this.pictureBox_add.Size = new System.Drawing.Size(20, 20);
            this.pictureBox_add.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_add.TabIndex = 53;
            this.pictureBox_add.TabStop = false;
            // 
            // pictureBox_remove
            // 
            this.pictureBox_remove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_remove.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_remove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_remove.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_remove.Image")));
            this.pictureBox_remove.Location = new System.Drawing.Point(296, 1);
            this.pictureBox_remove.Name = "pictureBox_remove";
            this.pictureBox_remove.Size = new System.Drawing.Size(20, 20);
            this.pictureBox_remove.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_remove.TabIndex = 52;
            this.pictureBox_remove.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(274, 1);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(20, 20);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 55;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(294, 1);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(20, 20);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 54;
            this.pictureBox3.TabStop = false;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 48;
            this.label1.Text = "Replace";
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
            // tb_requestModific_body
            // 
            this.tb_requestModific_body.Location = new System.Drawing.Point(69, 5);
            this.tb_requestModific_body.Name = "tb_requestModific_body";
            this.tb_requestModific_body.Size = new System.Drawing.Size(519, 21);
            this.tb_requestModific_body.TabIndex = 47;
            this.tb_requestModific_body.WatermarkText = "empty mean replace all body";
            // 
            // tb_requestModific_uriModificKey
            // 
            this.tb_requestModific_uriModificKey.Location = new System.Drawing.Point(6, 20);
            this.tb_requestModific_uriModificKey.Name = "tb_requestModific_uriModificKey";
            this.tb_requestModific_uriModificKey.Size = new System.Drawing.Size(94, 21);
            this.tb_requestModific_uriModificKey.TabIndex = 4;
            this.tb_requestModific_uriModificKey.WatermarkText = "empty is all";
            // 
            // editListView1
            // 
            this.editListView1.ColumnHeaderName = "Request Heads";
            this.editListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editListView1.IsKeyValue = true;
            this.editListView1.Location = new System.Drawing.Point(0, 0);
            this.editListView1.Name = "editListView1";
            this.editListView1.Size = new System.Drawing.Size(597, 142);
            this.editListView1.TabIndex = 2;
            // 
            // tb_requestReplace_uri
            // 
            this.tb_requestReplace_uri.Location = new System.Drawing.Point(160, 6);
            this.tb_requestReplace_uri.Name = "tb_requestReplace_uri";
            this.tb_requestReplace_uri.Size = new System.Drawing.Size(322, 21);
            this.tb_requestReplace_uri.TabIndex = 16;
            this.tb_requestReplace_uri.WatermarkText = null;
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
            // tb_responseModific_body
            // 
            this.tb_responseModific_body.Location = new System.Drawing.Point(69, 5);
            this.tb_responseModific_body.Name = "tb_responseModific_body";
            this.tb_responseModific_body.Size = new System.Drawing.Size(519, 21);
            this.tb_responseModific_body.TabIndex = 47;
            this.tb_responseModific_body.WatermarkText = "empty mean replace all body";
            // 
            // rawResponseEdit1
            // 
            this.rawResponseEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rawResponseEdit1.Location = new System.Drawing.Point(3, 3);
            this.rawResponseEdit1.Name = "rawResponseEdit1";
            this.rawResponseEdit1.Size = new System.Drawing.Size(597, 448);
            this.rawResponseEdit1.TabIndex = 0;
            // 
            // FreeHttpWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer_main);
            this.Name = "FreeHttpWindow";
            this.Size = new System.Drawing.Size(966, 552);
            this.Load += new System.EventHandler(this.FreeHttpWindow_Load);
            this.splitContainer_main.Panel1.ResumeLayout(false);
            this.splitContainer_main.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_main)).EndInit();
            this.splitContainer_main.ResumeLayout(false);
            this.tabControl_Modific.ResumeLayout(false);
            this.tabPage_requestModific.ResumeLayout(false);
            this.panel_modific_Contorl.ResumeLayout(false);
            this.groupBox_uriModific.ResumeLayout(false);
            this.groupBox_uriModific.PerformLayout();
            this.tabPage_requestReplace.ResumeLayout(false);
            this.tabPage_responseModific.ResumeLayout(false);
            this.tabPage_responseReplace.ResumeLayout(false);
            this.groupBox_urlFilter.ResumeLayout(false);
            this.groupBox_urlFilter.PerformLayout();
            this.splitContainer_httpControl.Panel1.ResumeLayout(false);
            this.splitContainer_httpControl.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_httpControl)).EndInit();
            this.splitContainer_httpControl.ResumeLayout(false);
            this.panel_modific.ResumeLayout(false);
            this.panel_requestReplace_startLine.ResumeLayout(false);
            this.panel_requestReplace_startLine.PerformLayout();
            this.splitContainer_requestReplace.Panel1.ResumeLayout(false);
            this.splitContainer_requestReplace.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_requestReplace)).EndInit();
            this.splitContainer_requestReplace.ResumeLayout(false);
            this.splitContainer_responseModific.Panel1.ResumeLayout(false);
            this.splitContainer_responseModific.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_responseModific)).EndInit();
            this.splitContainer_responseModific.ResumeLayout(false);
            this.groupBox_reponseHeadModific.ResumeLayout(false);
            this.groupBox_responseBodyModific.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_requestReplace_changeMode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_editCookietComfrim)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_editRuleMode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_requestRuleSwitch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_responseRuleSwitch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_add)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_remove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.splitContainer_requestModific.Panel1.ResumeLayout(false);
            this.splitContainer_requestModific.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_requestModific)).EndInit();
            this.splitContainer_requestModific.ResumeLayout(false);
            this.groupBox_headsModific.ResumeLayout(false);
            this.groupBox_bodyModific.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.ListView lv_requestRuleList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader_requstRule;
        private System.Windows.Forms.ListView lv_responseRuleList;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader_responseRule;
        private System.Windows.Forms.GroupBox groupBox_urlFilter;
        private System.Windows.Forms.ComboBox cb_macthMode;
        private System.Windows.Forms.TextBox tb_urlFilter;
        private System.Windows.Forms.GroupBox groupBox_bodyModific;
        private System.Windows.Forms.GroupBox groupBox_headsModific;
        private System.Windows.Forms.GroupBox groupBox_uriModific;
        private System.Windows.Forms.PictureBox pb_editCookietComfrim;
        private WatermakTextBox tb_requestModific_uriModificKey;
        private System.Windows.Forms.TextBox tb_requestModific_uriModificValue;
        private System.Windows.Forms.Label label1;
        private WatermakTextBox tb_requestModific_body;
        private EditListView requestRemoveHeads;
        private EditListView requestAddHeads;
        private System.Windows.Forms.SplitContainer splitContainer_requestModific;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel_modific_Contorl;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RichTextBox rtb_requestModific_body;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lb_editRuleMode;
        private System.Windows.Forms.PictureBox pictureBox_editRuleMode;
        private System.Windows.Forms.Panel panel_modific;
        private WatermakTextBox tb_requestReplace_uri;
        private System.Windows.Forms.ComboBox cb_editRequestEdition;
        private System.Windows.Forms.ComboBox cb_editRequestMethod;
        private System.Windows.Forms.Label lb_editStartLine;
        private System.Windows.Forms.SplitContainer splitContainer_requestReplace;
        private System.Windows.Forms.Panel panel_requestReplace_startLine;
        private EditListView editListView1;
        private System.Windows.Forms.RichTextBox rtb_requsetReplace_body;
        private System.Windows.Forms.PictureBox pb_requestReplace_changeMode;
        private System.Windows.Forms.RichTextBox rtb_requestRaw;
        private System.Windows.Forms.SplitContainer splitContainer_responseModific;
        private System.Windows.Forms.GroupBox groupBox_reponseHeadModific;
        private EditListView responseAddHeads;
        private EditListView responseRemoveHeads;
        private System.Windows.Forms.GroupBox groupBox_responseBodyModific;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RichTextBox rtb_reponseModific_body;
        private System.Windows.Forms.Panel panel4;
        private WatermakTextBox tb_responseModific_body;
        private System.Windows.Forms.Label label2;
        private RawResponseEdit rawResponseEdit1;
        private System.Windows.Forms.PictureBox pb_requestRuleSwitch;
        private System.Windows.Forms.PictureBox pb_responseRuleSwitch;
        private System.Windows.Forms.ImageList imageList_forTab;
        private System.Windows.Forms.PictureBox pictureBox_add;
        private System.Windows.Forms.PictureBox pictureBox_remove;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;

    }
}
