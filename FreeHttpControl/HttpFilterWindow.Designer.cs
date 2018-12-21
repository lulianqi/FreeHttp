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
            this.FilterHeads = new FreeHttp.FreeHttpControl.EditListView();
            this.SuspendLayout();
            // 
            // bt_ok
            // 
            this.bt_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_ok.Location = new System.Drawing.Point(489, 299);
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
            this.cb_macthMode.Location = new System.Drawing.Point(5, 219);
            this.cb_macthMode.Name = "cb_macthMode";
            this.cb_macthMode.Size = new System.Drawing.Size(95, 20);
            this.cb_macthMode.TabIndex = 10;
            this.cb_macthMode.SelectedIndexChanged += new System.EventHandler(this.cb_macthMode_SelectedIndexChanged);
            // 
            // rtb_bodyFilter
            // 
            this.rtb_bodyFilter.Location = new System.Drawing.Point(109, 194);
            this.rtb_bodyFilter.Name = "rtb_bodyFilter";
            this.rtb_bodyFilter.Size = new System.Drawing.Size(458, 100);
            this.rtb_bodyFilter.TabIndex = 11;
            this.rtb_bodyFilter.Text = "";
            // 
            // lb_info_1
            // 
            this.lb_info_1.AutoSize = true;
            this.lb_info_1.Location = new System.Drawing.Point(5, 199);
            this.lb_info_1.Name = "lb_info_1";
            this.lb_info_1.Size = new System.Drawing.Size(101, 12);
            this.lb_info_1.TabIndex = 12;
            this.lb_info_1.Text = "HTTP Body Filter";
            // 
            // FilterHeads
            // 
            this.FilterHeads.ColumnHeaderName = "Head Filter";
            this.FilterHeads.Dock = System.Windows.Forms.DockStyle.Top;
            this.FilterHeads.IsKeyValue = true;
            this.FilterHeads.Location = new System.Drawing.Point(0, 0);
            this.FilterHeads.Name = "FilterHeads";
            this.FilterHeads.Size = new System.Drawing.Size(568, 191);
            this.FilterHeads.SplitStr = "  <contain> ";
            this.FilterHeads.TabIndex = 2;
            // 
            // HttpFilterWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 327);
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
    }
}