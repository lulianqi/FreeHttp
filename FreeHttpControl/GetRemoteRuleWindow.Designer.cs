
namespace FreeHttp.FreeHttpControl
{
    partial class GetRemoteRuleWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GetRemoteRuleWindow));
            this.lb_info_1 = new System.Windows.Forms.Label();
            this.bt_getRule = new System.Windows.Forms.Button();
            this.bt_replaceRule = new System.Windows.Forms.Button();
            this.lb_info_2 = new System.Windows.Forms.Label();
            this.lv_remote_responseRuleList = new FreeHttp.FreeHttpControl.MyListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_responseRule = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lv_remote_requestRuleList = new FreeHttp.FreeHttpControl.MyListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_requstRule = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.watermakTextBox_ruleToken = new FreeHttp.FreeHttpControl.WatermakTextBox();
            this.SuspendLayout();
            // 
            // lb_info_1
            // 
            this.lb_info_1.AutoSize = true;
            this.lb_info_1.Location = new System.Drawing.Point(12, 18);
            this.lb_info_1.Name = "lb_info_1";
            this.lb_info_1.Size = new System.Drawing.Size(113, 12);
            this.lb_info_1.TabIndex = 12;
            this.lb_info_1.Text = "remote tule token:";
            // 
            // bt_getRule
            // 
            this.bt_getRule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_getRule.Location = new System.Drawing.Point(543, 14);
            this.bt_getRule.Name = "bt_getRule";
            this.bt_getRule.Size = new System.Drawing.Size(75, 23);
            this.bt_getRule.TabIndex = 13;
            this.bt_getRule.Text = "Get Rule";
            this.bt_getRule.UseVisualStyleBackColor = true;
            this.bt_getRule.Click += new System.EventHandler(this.bt_getRule_Click);
            // 
            // bt_replaceRule
            // 
            this.bt_replaceRule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_replaceRule.Location = new System.Drawing.Point(514, 496);
            this.bt_replaceRule.Name = "bt_replaceRule";
            this.bt_replaceRule.Size = new System.Drawing.Size(104, 23);
            this.bt_replaceRule.TabIndex = 16;
            this.bt_replaceRule.Text = "Replace Rule";
            this.bt_replaceRule.UseVisualStyleBackColor = true;
            this.bt_replaceRule.Click += new System.EventHandler(this.bt_replaceRule_Click);
            // 
            // lb_info_2
            // 
            this.lb_info_2.AutoSize = true;
            this.lb_info_2.Location = new System.Drawing.Point(4, 501);
            this.lb_info_2.Name = "lb_info_2";
            this.lb_info_2.Size = new System.Drawing.Size(0, 12);
            this.lb_info_2.TabIndex = 17;
            // 
            // lv_remote_responseRuleList
            // 
            this.lv_remote_responseRuleList.AllowDrop = true;
            this.lv_remote_responseRuleList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader_responseRule});
            this.lv_remote_responseRuleList.FullRowSelect = true;
            this.lv_remote_responseRuleList.HideSelection = false;
            this.lv_remote_responseRuleList.Location = new System.Drawing.Point(1, 273);
            this.lv_remote_responseRuleList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lv_remote_responseRuleList.Name = "lv_remote_responseRuleList";
            this.lv_remote_responseRuleList.ShowItemToolTips = true;
            this.lv_remote_responseRuleList.Size = new System.Drawing.Size(626, 220);
            this.lv_remote_responseRuleList.TabIndex = 15;
            this.lv_remote_responseRuleList.UseCompatibleStateImageBehavior = false;
            this.lv_remote_responseRuleList.View = System.Windows.Forms.View.Details;
            this.lv_remote_responseRuleList.DoubleClick += new System.EventHandler(this.lv_remote_ruleList_MouseDoubleClick);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "ID";
            this.columnHeader3.Width = 54;
            // 
            // columnHeader_responseRule
            // 
            this.columnHeader_responseRule.Text = "Response Rule";
            this.columnHeader_responseRule.Width = 563;
            // 
            // lv_remote_requestRuleList
            // 
            this.lv_remote_requestRuleList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader_requstRule});
            this.lv_remote_requestRuleList.Cursor = System.Windows.Forms.Cursors.Default;
            this.lv_remote_requestRuleList.FullRowSelect = true;
            this.lv_remote_requestRuleList.HideSelection = false;
            this.lv_remote_requestRuleList.Location = new System.Drawing.Point(1, 52);
            this.lv_remote_requestRuleList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lv_remote_requestRuleList.Name = "lv_remote_requestRuleList";
            this.lv_remote_requestRuleList.ShowItemToolTips = true;
            this.lv_remote_requestRuleList.Size = new System.Drawing.Size(626, 220);
            this.lv_remote_requestRuleList.TabIndex = 14;
            this.lv_remote_requestRuleList.UseCompatibleStateImageBehavior = false;
            this.lv_remote_requestRuleList.View = System.Windows.Forms.View.Details;
            this.lv_remote_requestRuleList.DoubleClick += new System.EventHandler(this.lv_remote_ruleList_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 54;
            // 
            // columnHeader_requstRule
            // 
            this.columnHeader_requstRule.Text = "Request Rule";
            this.columnHeader_requstRule.Width = 562;
            // 
            // watermakTextBox_ruleToken
            // 
            this.watermakTextBox_ruleToken.Location = new System.Drawing.Point(131, 15);
            this.watermakTextBox_ruleToken.Name = "watermakTextBox_ruleToken";
            this.watermakTextBox_ruleToken.Size = new System.Drawing.Size(404, 21);
            this.watermakTextBox_ruleToken.TabIndex = 11;
            this.watermakTextBox_ruleToken.WatermarkText = "input your token";
            // 
            // GetRemoteRuleWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 521);
            this.Controls.Add(this.lb_info_2);
            this.Controls.Add(this.bt_replaceRule);
            this.Controls.Add(this.lv_remote_responseRuleList);
            this.Controls.Add(this.lv_remote_requestRuleList);
            this.Controls.Add(this.bt_getRule);
            this.Controls.Add(this.lb_info_1);
            this.Controls.Add(this.watermakTextBox_ruleToken);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GetRemoteRuleWindow";
            this.Text = "GetRemoteRule";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GetRemoteRuleWindow_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_info_1;
        private WatermakTextBox watermakTextBox_ruleToken;
        private System.Windows.Forms.Button bt_getRule;
        private MyListView lv_remote_responseRuleList;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader_responseRule;
        private MyListView lv_remote_requestRuleList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader_requstRule;
        private System.Windows.Forms.Button bt_replaceRule;
        private System.Windows.Forms.Label lb_info_2;
    }
}