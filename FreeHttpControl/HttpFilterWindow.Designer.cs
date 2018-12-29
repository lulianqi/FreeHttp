namespace FreeHttp.FreeHttpControl
{
    partial class HttpFilterWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HttpFilterWindow));
            this.bt_ok = new System.Windows.Forms.Button();
            this.cb_macthMode = new System.Windows.Forms.ComboBox();
            this.rtb_bodyFilter = new System.Windows.Forms.RichTextBox();
            this.lb_info_1 = new System.Windows.Forms.Label();
            this.cb_macthUriMode = new System.Windows.Forms.ComboBox();
            this.tb_urlFilter = new System.Windows.Forms.TextBox();
            this.lb_info_2 = new System.Windows.Forms.Label();
            this.tbe_urlFilter = new FreeHttp.FreeHttpControl.TextBoxEditer();
            this.FilterHeads = new FreeHttp.FreeHttpControl.EditListView();
            this.lb_info_3 = new System.Windows.Forms.Label();
            this.tb_RuleAlias = new FreeHttp.FreeHttpControl.WatermakTextBox();
            this.SuspendLayout();
            // 
            // bt_ok
            // 
            this.bt_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_ok.Location = new System.Drawing.Point(537, 318);
            this.bt_ok.Name = "bt_ok";
            this.bt_ok.Size = new System.Drawing.Size(75, 23);
            this.bt_ok.TabIndex = 9;
            this.bt_ok.Text = "confirm";
            this.bt_ok.UseVisualStyleBackColor = true;
            this.bt_ok.Click += new System.EventHandler(this.bt_ok_Click);
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
            this.cb_macthMode.Location = new System.Drawing.Point(5, 241);
            this.cb_macthMode.Name = "cb_macthMode";
            this.cb_macthMode.Size = new System.Drawing.Size(95, 20);
            this.cb_macthMode.TabIndex = 10;
            this.cb_macthMode.SelectedIndexChanged += new System.EventHandler(this.cb_macthMode_SelectedIndexChanged);
            // 
            // rtb_bodyFilter
            // 
            this.rtb_bodyFilter.Location = new System.Drawing.Point(109, 216);
            this.rtb_bodyFilter.Name = "rtb_bodyFilter";
            this.rtb_bodyFilter.Size = new System.Drawing.Size(501, 100);
            this.rtb_bodyFilter.TabIndex = 11;
            this.rtb_bodyFilter.Text = "";
            // 
            // lb_info_1
            // 
            this.lb_info_1.AutoSize = true;
            this.lb_info_1.Location = new System.Drawing.Point(5, 221);
            this.lb_info_1.Name = "lb_info_1";
            this.lb_info_1.Size = new System.Drawing.Size(101, 12);
            this.lb_info_1.TabIndex = 12;
            this.lb_info_1.Text = "HTTP Body Filter";
            // 
            // cb_macthUriMode
            // 
            this.cb_macthUriMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_macthUriMode.FormattingEnabled = true;
            this.cb_macthUriMode.Items.AddRange(new object[] {
            "Contain",
            "StartWith",
            "Is",
            "Regex",
            "AllPass"});
            this.cb_macthUriMode.Location = new System.Drawing.Point(84, 6);
            this.cb_macthUriMode.Name = "cb_macthUriMode";
            this.cb_macthUriMode.Size = new System.Drawing.Size(89, 20);
            this.cb_macthUriMode.TabIndex = 14;
            // 
            // tb_urlFilter
            // 
            this.tb_urlFilter.AllowDrop = true;
            this.tb_urlFilter.Location = new System.Drawing.Point(179, 5);
            this.tb_urlFilter.Name = "tb_urlFilter";
            this.tb_urlFilter.Size = new System.Drawing.Size(433, 21);
            this.tb_urlFilter.TabIndex = 13;
            this.tb_urlFilter.Enter += new System.EventHandler(this.tb_urlFilter_Enter);
            this.tb_urlFilter.Leave += new System.EventHandler(this.tb_urlFilter_Leave);
            // 
            // lb_info_2
            // 
            this.lb_info_2.AutoSize = true;
            this.lb_info_2.Location = new System.Drawing.Point(7, 9);
            this.lb_info_2.Name = "lb_info_2";
            this.lb_info_2.Size = new System.Drawing.Size(65, 12);
            this.lb_info_2.TabIndex = 15;
            this.lb_info_2.Text = "Uri Filter";
            // 
            // tbe_urlFilter
            // 
            this.tbe_urlFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbe_urlFilter.EditTextBox = this.tb_urlFilter;
            this.tbe_urlFilter.Location = new System.Drawing.Point(589, 5);
            this.tbe_urlFilter.MainContainerControl = this;
            this.tbe_urlFilter.Name = "tbe_urlFilter";
            this.tbe_urlFilter.Size = new System.Drawing.Size(21, 21);
            this.tbe_urlFilter.TabIndex = 51;
            // 
            // FilterHeads
            // 
            this.FilterHeads.ColumnHeaderName = "Head Filter";
            this.FilterHeads.IsItemUnique = true;
            this.FilterHeads.IsKeyValue = true;
            this.FilterHeads.Location = new System.Drawing.Point(2, 31);
            this.FilterHeads.Name = "FilterHeads";
            this.FilterHeads.Size = new System.Drawing.Size(610, 181);
            this.FilterHeads.SplitStr = "  <contain> ";
            this.FilterHeads.TabIndex = 2;
            // 
            // lb_info_3
            // 
            this.lb_info_3.AutoSize = true;
            this.lb_info_3.Location = new System.Drawing.Point(6, 323);
            this.lb_info_3.Name = "lb_info_3";
            this.lb_info_3.Size = new System.Drawing.Size(65, 12);
            this.lb_info_3.TabIndex = 52;
            this.lb_info_3.Text = "Rule Alias";
            // 
            // tb_RuleAlias
            // 
            this.tb_RuleAlias.Location = new System.Drawing.Point(108, 319);
            this.tb_RuleAlias.Name = "tb_RuleAlias";
            this.tb_RuleAlias.Size = new System.Drawing.Size(423, 21);
            this.tb_RuleAlias.TabIndex = 53;
            this.tb_RuleAlias.WatermarkText = "set the rule alias if it is exist";
            // 
            // HttpFilterWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 344);
            this.Controls.Add(this.tb_RuleAlias);
            this.Controls.Add(this.lb_info_3);
            this.Controls.Add(this.tbe_urlFilter);
            this.Controls.Add(this.lb_info_2);
            this.Controls.Add(this.cb_macthUriMode);
            this.Controls.Add(this.tb_urlFilter);
            this.Controls.Add(this.lb_info_1);
            this.Controls.Add(this.rtb_bodyFilter);
            this.Controls.Add(this.cb_macthMode);
            this.Controls.Add(this.bt_ok);
            this.Controls.Add(this.FilterHeads);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HttpFilterWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "HttpFilterWindow";
            this.Deactivate += new System.EventHandler(this.HttpFilterWindow_Deactivate);
            this.Load += new System.EventHandler(this.HttpFilterWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EditListView FilterHeads;
        private System.Windows.Forms.Button bt_ok;
        private System.Windows.Forms.ComboBox cb_macthMode;
        private System.Windows.Forms.RichTextBox rtb_bodyFilter;
        private System.Windows.Forms.Label lb_info_1;
        private System.Windows.Forms.ComboBox cb_macthUriMode;
        private System.Windows.Forms.TextBox tb_urlFilter;
        private System.Windows.Forms.Label lb_info_2;
        private TextBoxEditer tbe_urlFilter;
        private System.Windows.Forms.Label lb_info_3;
        private WatermakTextBox tb_RuleAlias;
    }
}