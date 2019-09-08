namespace FreeHttp.FreeHttpControl
{
    partial class ChangeEncodeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeEncodeForm));
            this.bt_ok = new System.Windows.Forms.Button();
            this.tb_contentType = new System.Windows.Forms.TextBox();
            this.lb_info_3 = new System.Windows.Forms.Label();
            this.lb_info_1 = new System.Windows.Forms.Label();
            this.cb_body = new System.Windows.Forms.ComboBox();
            this.lb_info_2 = new System.Windows.Forms.Label();
            this.tb_recode = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // bt_ok
            // 
            this.bt_ok.Location = new System.Drawing.Point(234, 99);
            this.bt_ok.Name = "bt_ok";
            this.bt_ok.Size = new System.Drawing.Size(75, 23);
            this.bt_ok.TabIndex = 10;
            this.bt_ok.Text = "confirm";
            this.bt_ok.UseVisualStyleBackColor = true;
            this.bt_ok.Click += new System.EventHandler(this.bt_ok_Click);
            // 
            // tb_contentType
            // 
            this.tb_contentType.Location = new System.Drawing.Point(99, 67);
            this.tb_contentType.Name = "tb_contentType";
            this.tb_contentType.Size = new System.Drawing.Size(210, 21);
            this.tb_contentType.TabIndex = 6;
            // 
            // lb_info_3
            // 
            this.lb_info_3.AutoSize = true;
            this.lb_info_3.Location = new System.Drawing.Point(13, 70);
            this.lb_info_3.Name = "lb_info_3";
            this.lb_info_3.Size = new System.Drawing.Size(83, 12);
            this.lb_info_3.TabIndex = 8;
            this.lb_info_3.Text = "Content-Type:";
            // 
            // lb_info_1
            // 
            this.lb_info_1.AutoSize = true;
            this.lb_info_1.Location = new System.Drawing.Point(15, 11);
            this.lb_info_1.Name = "lb_info_1";
            this.lb_info_1.Size = new System.Drawing.Size(35, 12);
            this.lb_info_1.TabIndex = 11;
            this.lb_info_1.Text = "Body:";
            // 
            // cb_body
            // 
            this.cb_body.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_body.FormattingEnabled = true;
            this.cb_body.Items.AddRange(new object[] {
            "change request encode",
            "change response encode"});
            this.cb_body.Location = new System.Drawing.Point(99, 7);
            this.cb_body.Name = "cb_body";
            this.cb_body.Size = new System.Drawing.Size(210, 20);
            this.cb_body.TabIndex = 12;
            // 
            // lb_info_2
            // 
            this.lb_info_2.AutoSize = true;
            this.lb_info_2.Location = new System.Drawing.Point(15, 41);
            this.lb_info_2.Name = "lb_info_2";
            this.lb_info_2.Size = new System.Drawing.Size(47, 12);
            this.lb_info_2.TabIndex = 13;
            this.lb_info_2.Text = "Encode:";
            // 
            // tb_recode
            // 
            this.tb_recode.AutoCompleteCustomSource.AddRange(new string[] {
            "utf-8",
            "gb2312",
            "utf-16",
            "utf-32",
            "x-cp20936",
            "gbk",
            "euc-jp",
            "EUC-CN",
            "GB18030",
            "unicodeFFFE",
            "big5",
            "IBM037",
            "IBM437",
            "IBM500"});
            this.tb_recode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tb_recode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tb_recode.Location = new System.Drawing.Point(99, 36);
            this.tb_recode.Name = "tb_recode";
            this.tb_recode.Size = new System.Drawing.Size(210, 21);
            this.tb_recode.TabIndex = 14;
            this.tb_recode.Text = "utf-8";
            this.tb_recode.TextChanged += new System.EventHandler(this.Tb_recode_TextChanged);
            // 
            // ChangeEncodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 128);
            this.Controls.Add(this.tb_recode);
            this.Controls.Add(this.lb_info_2);
            this.Controls.Add(this.cb_body);
            this.Controls.Add(this.lb_info_1);
            this.Controls.Add(this.bt_ok);
            this.Controls.Add(this.lb_info_3);
            this.Controls.Add(this.tb_contentType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangeEncodeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change Encode";
            this.Load += new System.EventHandler(this.ChangeEncodeForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button bt_ok;
        private System.Windows.Forms.TextBox tb_contentType;
        private System.Windows.Forms.Label lb_info_3;
        private System.Windows.Forms.Label lb_info_1;
        private System.Windows.Forms.ComboBox cb_body;
        private System.Windows.Forms.Label lb_info_2;
        private System.Windows.Forms.TextBox tb_recode;
    }
}