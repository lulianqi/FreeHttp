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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FreeHttpWindow));
            this.splitContainer_main = new System.Windows.Forms.SplitContainer();
            this.splitContainer_httpEdit = new System.Windows.Forms.SplitContainer();
            this.groupBox_urlFilter = new System.Windows.Forms.GroupBox();
            this.cb_macthMode = new System.Windows.Forms.ComboBox();
            this.tb_urlFilter = new System.Windows.Forms.TextBox();
            this.tabControl_Modific = new System.Windows.Forms.TabControl();
            this.tabPage_requestModific = new System.Windows.Forms.TabPage();
            this.groupBox_bodyModific = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_responseReplace = new System.Windows.Forms.TextBox();
            this.rtb_reponse = new System.Windows.Forms.RichTextBox();
            this.groupBox_headsModific = new System.Windows.Forms.GroupBox();
            this.groupBox_uriModific = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabPage_requestReplace = new System.Windows.Forms.TabPage();
            this.tabPage_responseModific = new System.Windows.Forms.TabPage();
            this.tabPage_responseReplace = new System.Windows.Forms.TabPage();
            this.splitContainer_httpControl = new System.Windows.Forms.SplitContainer();
            this.lv_requestRuleList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lv_responseRuleList = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pb_editCookietComfrim = new System.Windows.Forms.PictureBox();
            this.requestAddHeads = new FreeHttp.FreeHttpControl.EditListView();
            this.requestRemoveHeads = new FreeHttp.FreeHttpControl.EditListView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_main)).BeginInit();
            this.splitContainer_main.Panel1.SuspendLayout();
            this.splitContainer_main.Panel2.SuspendLayout();
            this.splitContainer_main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_httpEdit)).BeginInit();
            this.splitContainer_httpEdit.Panel1.SuspendLayout();
            this.splitContainer_httpEdit.Panel2.SuspendLayout();
            this.splitContainer_httpEdit.SuspendLayout();
            this.groupBox_urlFilter.SuspendLayout();
            this.tabControl_Modific.SuspendLayout();
            this.tabPage_requestModific.SuspendLayout();
            this.groupBox_bodyModific.SuspendLayout();
            this.groupBox_headsModific.SuspendLayout();
            this.groupBox_uriModific.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_httpControl)).BeginInit();
            this.splitContainer_httpControl.Panel1.SuspendLayout();
            this.splitContainer_httpControl.Panel2.SuspendLayout();
            this.splitContainer_httpControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_editCookietComfrim)).BeginInit();
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
            this.splitContainer_main.Panel1.Controls.Add(this.splitContainer_httpEdit);
            // 
            // splitContainer_main.Panel2
            // 
            this.splitContainer_main.Panel2.Controls.Add(this.splitContainer_httpControl);
            this.splitContainer_main.Size = new System.Drawing.Size(966, 552);
            this.splitContainer_main.SplitterDistance = 611;
            this.splitContainer_main.TabIndex = 0;
            // 
            // splitContainer_httpEdit
            // 
            this.splitContainer_httpEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_httpEdit.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_httpEdit.Name = "splitContainer_httpEdit";
            this.splitContainer_httpEdit.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer_httpEdit.Panel1
            // 
            this.splitContainer_httpEdit.Panel1.Controls.Add(this.groupBox_urlFilter);
            // 
            // splitContainer_httpEdit.Panel2
            // 
            this.splitContainer_httpEdit.Panel2.Controls.Add(this.tabControl_Modific);
            this.splitContainer_httpEdit.Size = new System.Drawing.Size(611, 552);
            this.splitContainer_httpEdit.SplitterDistance = 44;
            this.splitContainer_httpEdit.TabIndex = 0;
            // 
            // groupBox_urlFilter
            // 
            this.groupBox_urlFilter.Controls.Add(this.cb_macthMode);
            this.groupBox_urlFilter.Controls.Add(this.tb_urlFilter);
            this.groupBox_urlFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_urlFilter.Location = new System.Drawing.Point(0, 0);
            this.groupBox_urlFilter.Name = "groupBox_urlFilter";
            this.groupBox_urlFilter.Size = new System.Drawing.Size(611, 44);
            this.groupBox_urlFilter.TabIndex = 6;
            this.groupBox_urlFilter.TabStop = false;
            this.groupBox_urlFilter.Text = "Url Filter";
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
            this.cb_macthMode.Location = new System.Drawing.Point(6, 21);
            this.cb_macthMode.Name = "cb_macthMode";
            this.cb_macthMode.Size = new System.Drawing.Size(106, 20);
            this.cb_macthMode.TabIndex = 2;
            // 
            // tb_urlFilter
            // 
            this.tb_urlFilter.Location = new System.Drawing.Point(116, 20);
            this.tb_urlFilter.Name = "tb_urlFilter";
            this.tb_urlFilter.Size = new System.Drawing.Size(491, 21);
            this.tb_urlFilter.TabIndex = 0;
            // 
            // tabControl_Modific
            // 
            this.tabControl_Modific.Controls.Add(this.tabPage_requestModific);
            this.tabControl_Modific.Controls.Add(this.tabPage_requestReplace);
            this.tabControl_Modific.Controls.Add(this.tabPage_responseModific);
            this.tabControl_Modific.Controls.Add(this.tabPage_responseReplace);
            this.tabControl_Modific.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_Modific.Location = new System.Drawing.Point(0, 0);
            this.tabControl_Modific.Name = "tabControl_Modific";
            this.tabControl_Modific.SelectedIndex = 0;
            this.tabControl_Modific.Size = new System.Drawing.Size(611, 504);
            this.tabControl_Modific.TabIndex = 0;
            this.tabControl_Modific.Resize += new System.EventHandler(this.tabControl_Modific_Resize);
            // 
            // tabPage_requestModific
            // 
            this.tabPage_requestModific.Controls.Add(this.pb_editCookietComfrim);
            this.tabPage_requestModific.Controls.Add(this.groupBox_bodyModific);
            this.tabPage_requestModific.Controls.Add(this.groupBox_headsModific);
            this.tabPage_requestModific.Controls.Add(this.groupBox_uriModific);
            this.tabPage_requestModific.Location = new System.Drawing.Point(4, 22);
            this.tabPage_requestModific.Name = "tabPage_requestModific";
            this.tabPage_requestModific.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_requestModific.Size = new System.Drawing.Size(603, 478);
            this.tabPage_requestModific.TabIndex = 0;
            this.tabPage_requestModific.Text = "Request Modific";
            this.tabPage_requestModific.UseVisualStyleBackColor = true;
            // 
            // groupBox_bodyModific
            // 
            this.groupBox_bodyModific.Controls.Add(this.label1);
            this.groupBox_bodyModific.Controls.Add(this.tb_responseReplace);
            this.groupBox_bodyModific.Controls.Add(this.rtb_reponse);
            this.groupBox_bodyModific.Location = new System.Drawing.Point(6, 175);
            this.groupBox_bodyModific.Name = "groupBox_bodyModific";
            this.groupBox_bodyModific.Size = new System.Drawing.Size(591, 269);
            this.groupBox_bodyModific.TabIndex = 2;
            this.groupBox_bodyModific.TabStop = false;
            this.groupBox_bodyModific.Text = "Heads Modific";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 48;
            this.label1.Text = "Replace";
            // 
            // tb_responseReplace
            // 
            this.tb_responseReplace.Location = new System.Drawing.Point(55, 23);
            this.tb_responseReplace.Name = "tb_responseReplace";
            this.tb_responseReplace.Size = new System.Drawing.Size(533, 21);
            this.tb_responseReplace.TabIndex = 47;
            // 
            // rtb_reponse
            // 
            this.rtb_reponse.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rtb_reponse.Location = new System.Drawing.Point(3, 49);
            this.rtb_reponse.Name = "rtb_reponse";
            this.rtb_reponse.Size = new System.Drawing.Size(585, 217);
            this.rtb_reponse.TabIndex = 46;
            this.rtb_reponse.Text = "";
            // 
            // groupBox_headsModific
            // 
            this.groupBox_headsModific.Controls.Add(this.requestAddHeads);
            this.groupBox_headsModific.Controls.Add(this.requestRemoveHeads);
            this.groupBox_headsModific.Location = new System.Drawing.Point(6, 65);
            this.groupBox_headsModific.Name = "groupBox_headsModific";
            this.groupBox_headsModific.Size = new System.Drawing.Size(591, 104);
            this.groupBox_headsModific.TabIndex = 1;
            this.groupBox_headsModific.TabStop = false;
            this.groupBox_headsModific.Text = "Heads Modific";
            // 
            // groupBox_uriModific
            // 
            this.groupBox_uriModific.Controls.Add(this.textBox2);
            this.groupBox_uriModific.Controls.Add(this.textBox1);
            this.groupBox_uriModific.Location = new System.Drawing.Point(6, 6);
            this.groupBox_uriModific.Name = "groupBox_uriModific";
            this.groupBox_uriModific.Size = new System.Drawing.Size(591, 53);
            this.groupBox_uriModific.TabIndex = 0;
            this.groupBox_uriModific.TabStop = false;
            this.groupBox_uriModific.Text = "Uri Modific";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(6, 20);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(94, 21);
            this.textBox2.TabIndex = 4;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(106, 20);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(479, 21);
            this.textBox1.TabIndex = 3;
            // 
            // tabPage_requestReplace
            // 
            this.tabPage_requestReplace.Location = new System.Drawing.Point(4, 22);
            this.tabPage_requestReplace.Name = "tabPage_requestReplace";
            this.tabPage_requestReplace.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_requestReplace.Size = new System.Drawing.Size(603, 478);
            this.tabPage_requestReplace.TabIndex = 1;
            this.tabPage_requestReplace.Text = "Request Replace";
            this.tabPage_requestReplace.UseVisualStyleBackColor = true;
            // 
            // tabPage_responseModific
            // 
            this.tabPage_responseModific.Location = new System.Drawing.Point(4, 22);
            this.tabPage_responseModific.Name = "tabPage_responseModific";
            this.tabPage_responseModific.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_responseModific.Size = new System.Drawing.Size(603, 478);
            this.tabPage_responseModific.TabIndex = 2;
            this.tabPage_responseModific.Text = "Response Modific";
            this.tabPage_responseModific.UseVisualStyleBackColor = true;
            // 
            // tabPage_responseReplace
            // 
            this.tabPage_responseReplace.Location = new System.Drawing.Point(4, 22);
            this.tabPage_responseReplace.Name = "tabPage_responseReplace";
            this.tabPage_responseReplace.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_responseReplace.Size = new System.Drawing.Size(603, 478);
            this.tabPage_responseReplace.TabIndex = 3;
            this.tabPage_responseReplace.Text = "Response Replace";
            this.tabPage_responseReplace.UseVisualStyleBackColor = true;
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
            this.splitContainer_httpControl.Panel1.Controls.Add(this.lv_requestRuleList);
            // 
            // splitContainer_httpControl.Panel2
            // 
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
            this.columnHeader2});
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
            // columnHeader2
            // 
            this.columnHeader2.Text = "Request Rule";
            this.columnHeader2.Width = 280;
            // 
            // lv_responseRuleList
            // 
            this.lv_responseRuleList.CheckBoxes = true;
            this.lv_responseRuleList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
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
            // columnHeader4
            // 
            this.columnHeader4.Text = "Response Rule";
            this.columnHeader4.Width = 280;
            // 
            // pb_editCookietComfrim
            // 
            this.pb_editCookietComfrim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_editCookietComfrim.BackColor = System.Drawing.Color.Transparent;
            this.pb_editCookietComfrim.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_editCookietComfrim.Image = ((System.Drawing.Image)(resources.GetObject("pb_editCookietComfrim.Image")));
            this.pb_editCookietComfrim.Location = new System.Drawing.Point(574, 450);
            this.pb_editCookietComfrim.Name = "pb_editCookietComfrim";
            this.pb_editCookietComfrim.Size = new System.Drawing.Size(23, 22);
            this.pb_editCookietComfrim.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_editCookietComfrim.TabIndex = 37;
            this.pb_editCookietComfrim.TabStop = false;
            // 
            // requestAddHeads
            // 
            this.requestAddHeads.ColumnHeaderName = "Add Head";
            this.requestAddHeads.Dock = System.Windows.Forms.DockStyle.Right;
            this.requestAddHeads.IsKeyValue = true;
            this.requestAddHeads.Location = new System.Drawing.Point(278, 17);
            this.requestAddHeads.Name = "requestAddHeads";
            this.requestAddHeads.Size = new System.Drawing.Size(310, 84);
            this.requestAddHeads.TabIndex = 1;
            // 
            // requestRemoveHeads
            // 
            this.requestRemoveHeads.ColumnHeaderName = "Remove Head";
            this.requestRemoveHeads.Dock = System.Windows.Forms.DockStyle.Left;
            this.requestRemoveHeads.IsKeyValue = false;
            this.requestRemoveHeads.Location = new System.Drawing.Point(3, 17);
            this.requestRemoveHeads.Name = "requestRemoveHeads";
            this.requestRemoveHeads.Size = new System.Drawing.Size(269, 84);
            this.requestRemoveHeads.TabIndex = 0;
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
            this.splitContainer_httpEdit.Panel1.ResumeLayout(false);
            this.splitContainer_httpEdit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_httpEdit)).EndInit();
            this.splitContainer_httpEdit.ResumeLayout(false);
            this.groupBox_urlFilter.ResumeLayout(false);
            this.groupBox_urlFilter.PerformLayout();
            this.tabControl_Modific.ResumeLayout(false);
            this.tabPage_requestModific.ResumeLayout(false);
            this.groupBox_bodyModific.ResumeLayout(false);
            this.groupBox_bodyModific.PerformLayout();
            this.groupBox_headsModific.ResumeLayout(false);
            this.groupBox_uriModific.ResumeLayout(false);
            this.groupBox_uriModific.PerformLayout();
            this.splitContainer_httpControl.Panel1.ResumeLayout(false);
            this.splitContainer_httpControl.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_httpControl)).EndInit();
            this.splitContainer_httpControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_editCookietComfrim)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer_main;
        private System.Windows.Forms.SplitContainer splitContainer_httpEdit;
        private System.Windows.Forms.TabControl tabControl_Modific;
        private System.Windows.Forms.TabPage tabPage_requestModific;
        private System.Windows.Forms.TabPage tabPage_requestReplace;
        private System.Windows.Forms.TabPage tabPage_responseModific;
        private System.Windows.Forms.TabPage tabPage_responseReplace;
        private System.Windows.Forms.SplitContainer splitContainer_httpControl;
        private System.Windows.Forms.ListView lv_requestRuleList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ListView lv_responseRuleList;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.GroupBox groupBox_urlFilter;
        private System.Windows.Forms.ComboBox cb_macthMode;
        private System.Windows.Forms.TextBox tb_urlFilter;
        private System.Windows.Forms.GroupBox groupBox_bodyModific;
        private System.Windows.Forms.GroupBox groupBox_headsModific;
        private System.Windows.Forms.GroupBox groupBox_uriModific;
        private System.Windows.Forms.PictureBox pb_editCookietComfrim;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_responseReplace;
        private System.Windows.Forms.RichTextBox rtb_reponse;
        private EditListView requestRemoveHeads;
        private EditListView requestAddHeads;

    }
}
