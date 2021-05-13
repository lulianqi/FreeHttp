
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
            this.components = new System.ComponentModel.Container();
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
            this.lb_info_LocalRule = new System.Windows.Forms.Label();
            this.lb_info_SharedRule = new System.Windows.Forms.Label();
            this.lb_info_RemoteRule = new System.Windows.Forms.Label();
            this.lv_shareRuleList = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip_shareRuleList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyThisTokenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteThisTokenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip_shareRuleList.SuspendLayout();
            this.SuspendLayout();
            // 
            // lb_info_1
            // 
            this.lb_info_1.AutoSize = true;
            this.lb_info_1.Location = new System.Drawing.Point(13, 38);
            this.lb_info_1.Name = "lb_info_1";
            this.lb_info_1.Size = new System.Drawing.Size(113, 12);
            this.lb_info_1.TabIndex = 12;
            this.lb_info_1.Text = "remote tule token:";
            // 
            // bt_getRule
            // 
            this.bt_getRule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_getRule.Location = new System.Drawing.Point(544, 34);
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
            this.bt_replaceRule.Location = new System.Drawing.Point(515, 516);
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
            this.lb_info_2.Location = new System.Drawing.Point(5, 521);
            this.lb_info_2.Name = "lb_info_2";
            this.lb_info_2.Size = new System.Drawing.Size(0, 12);
            this.lb_info_2.TabIndex = 17;
            // 
            // lv_remote_responseRuleList
            // 
            this.lv_remote_responseRuleList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader_responseRule});
            this.lv_remote_responseRuleList.FullRowSelect = true;
            this.lv_remote_responseRuleList.HideSelection = false;
            this.lv_remote_responseRuleList.Location = new System.Drawing.Point(2, 293);
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
            this.lv_remote_requestRuleList.Location = new System.Drawing.Point(2, 72);
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
            this.watermakTextBox_ruleToken.Location = new System.Drawing.Point(132, 35);
            this.watermakTextBox_ruleToken.Name = "watermakTextBox_ruleToken";
            this.watermakTextBox_ruleToken.Size = new System.Drawing.Size(404, 21);
            this.watermakTextBox_ruleToken.TabIndex = 11;
            this.watermakTextBox_ruleToken.WatermarkText = "input your token";
            // 
            // lb_info_LocalRule
            // 
            this.lb_info_LocalRule.AutoSize = true;
            this.lb_info_LocalRule.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lb_info_LocalRule.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_info_LocalRule.ForeColor = System.Drawing.Color.DarkGray;
            this.lb_info_LocalRule.Location = new System.Drawing.Point(366, 9);
            this.lb_info_LocalRule.Name = "lb_info_LocalRule";
            this.lb_info_LocalRule.Size = new System.Drawing.Size(79, 13);
            this.lb_info_LocalRule.TabIndex = 22;
            this.lb_info_LocalRule.Text = "LocalRule";
            this.lb_info_LocalRule.Click += new System.EventHandler(this.lb_info_showType_Click);
            this.lb_info_LocalRule.MouseLeave += new System.EventHandler(this.lb_info_MouseLeave);
            this.lb_info_LocalRule.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lb_info_MouseMove);
            // 
            // lb_info_SharedRule
            // 
            this.lb_info_SharedRule.AutoSize = true;
            this.lb_info_SharedRule.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lb_info_SharedRule.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_info_SharedRule.ForeColor = System.Drawing.Color.DarkGray;
            this.lb_info_SharedRule.Location = new System.Drawing.Point(271, 9);
            this.lb_info_SharedRule.Name = "lb_info_SharedRule";
            this.lb_info_SharedRule.Size = new System.Drawing.Size(87, 13);
            this.lb_info_SharedRule.TabIndex = 21;
            this.lb_info_SharedRule.Text = "SharedRule";
            this.lb_info_SharedRule.Click += new System.EventHandler(this.lb_info_showType_Click);
            this.lb_info_SharedRule.MouseLeave += new System.EventHandler(this.lb_info_MouseLeave);
            this.lb_info_SharedRule.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lb_info_MouseMove);
            // 
            // lb_info_RemoteRule
            // 
            this.lb_info_RemoteRule.AutoSize = true;
            this.lb_info_RemoteRule.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.lb_info_RemoteRule.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lb_info_RemoteRule.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_info_RemoteRule.ForeColor = System.Drawing.Color.SaddleBrown;
            this.lb_info_RemoteRule.Location = new System.Drawing.Point(176, 9);
            this.lb_info_RemoteRule.Name = "lb_info_RemoteRule";
            this.lb_info_RemoteRule.Size = new System.Drawing.Size(87, 13);
            this.lb_info_RemoteRule.TabIndex = 20;
            this.lb_info_RemoteRule.Text = "RemoteRule";
            this.lb_info_RemoteRule.Click += new System.EventHandler(this.lb_info_showType_Click);
            this.lb_info_RemoteRule.MouseLeave += new System.EventHandler(this.lb_info_MouseLeave);
            this.lb_info_RemoteRule.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lb_info_MouseMove);
            // 
            // lv_shareRuleList
            // 
            this.lv_shareRuleList.BackColor = System.Drawing.Color.Azure;
            this.lv_shareRuleList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader4});
            this.lv_shareRuleList.ContextMenuStrip = this.contextMenuStrip_shareRuleList;
            this.lv_shareRuleList.FullRowSelect = true;
            this.lv_shareRuleList.HideSelection = false;
            this.lv_shareRuleList.Location = new System.Drawing.Point(2, 32);
            this.lv_shareRuleList.Name = "lv_shareRuleList";
            this.lv_shareRuleList.ShowItemToolTips = true;
            this.lv_shareRuleList.Size = new System.Drawing.Size(230, 481);
            this.lv_shareRuleList.TabIndex = 23;
            this.lv_shareRuleList.UseCompatibleStateImageBehavior = false;
            this.lv_shareRuleList.View = System.Windows.Forms.View.Details;
            this.lv_shareRuleList.Visible = false;
            this.lv_shareRuleList.DoubleClick += new System.EventHandler(this.lv_shareRuleList_DoubleClick);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Share Token";
            this.columnHeader2.Width = 110;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Remark";
            this.columnHeader4.Width = 115;
            // 
            // contextMenuStrip_shareRuleList
            // 
            this.contextMenuStrip_shareRuleList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyThisTokenToolStripMenuItem,
            this.deleteThisTokenToolStripMenuItem});
            this.contextMenuStrip_shareRuleList.Name = "contextMenuStrip_shareRuleList";
            this.contextMenuStrip_shareRuleList.Size = new System.Drawing.Size(211, 48);
            // 
            // copyThisTokenToolStripMenuItem
            // 
            this.copyThisTokenToolStripMenuItem.Image = global::FreeHttp.Properties.Resources.copy_value;
            this.copyThisTokenToolStripMenuItem.Name = "copyThisTokenToolStripMenuItem";
            this.copyThisTokenToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.copyThisTokenToolStripMenuItem.Text = "Copy this share token";
            this.copyThisTokenToolStripMenuItem.Click += new System.EventHandler(this.copyThisTokenToolStripMenuItem_Click);
            // 
            // deleteThisTokenToolStripMenuItem
            // 
            this.deleteThisTokenToolStripMenuItem.Image = global::FreeHttp.Properties.Resources.delete_value;
            this.deleteThisTokenToolStripMenuItem.Name = "deleteThisTokenToolStripMenuItem";
            this.deleteThisTokenToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.deleteThisTokenToolStripMenuItem.Text = "Delete this share token";
            this.deleteThisTokenToolStripMenuItem.Click += new System.EventHandler(this.deleteThisTokenToolStripMenuItem_Click);
            // 
            // GetRemoteRuleWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 544);
            this.Controls.Add(this.lv_shareRuleList);
            this.Controls.Add(this.lb_info_LocalRule);
            this.Controls.Add(this.lb_info_SharedRule);
            this.Controls.Add(this.lb_info_RemoteRule);
            this.Controls.Add(this.lb_info_2);
            this.Controls.Add(this.bt_replaceRule);
            this.Controls.Add(this.lv_remote_responseRuleList);
            this.Controls.Add(this.lv_remote_requestRuleList);
            this.Controls.Add(this.bt_getRule);
            this.Controls.Add(this.lb_info_1);
            this.Controls.Add(this.watermakTextBox_ruleToken);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsShowHideBox = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GetRemoteRuleWindow";
            this.WindowName = "";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GetRemoteRuleWindow_FormClosing);
            this.Load += new System.EventHandler(this.GetRemoteRuleWindow_Load);
            this.Controls.SetChildIndex(this.watermakTextBox_ruleToken, 0);
            this.Controls.SetChildIndex(this.lb_info_1, 0);
            this.Controls.SetChildIndex(this.bt_getRule, 0);
            this.Controls.SetChildIndex(this.lv_remote_requestRuleList, 0);
            this.Controls.SetChildIndex(this.lv_remote_responseRuleList, 0);
            this.Controls.SetChildIndex(this.bt_replaceRule, 0);
            this.Controls.SetChildIndex(this.lb_info_2, 0);
            this.Controls.SetChildIndex(this.lb_info_RemoteRule, 0);
            this.Controls.SetChildIndex(this.lb_info_SharedRule, 0);
            this.Controls.SetChildIndex(this.lb_info_LocalRule, 0);
            this.Controls.SetChildIndex(this.lv_shareRuleList, 0);
            this.contextMenuStrip_shareRuleList.ResumeLayout(false);
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
        private System.Windows.Forms.Label lb_info_LocalRule;
        private System.Windows.Forms.Label lb_info_SharedRule;
        private System.Windows.Forms.Label lb_info_RemoteRule;
        private System.Windows.Forms.ListView lv_shareRuleList;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_shareRuleList;
        private System.Windows.Forms.ToolStripMenuItem copyThisTokenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteThisTokenToolStripMenuItem;
    }
}