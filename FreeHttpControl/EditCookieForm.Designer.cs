namespace FreeHttp.FreeHttpControl
{
    partial class EditCookieForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditCookieForm));
            this.rtb_setValue = new System.Windows.Forms.RichTextBox();
            this.tb_name = new System.Windows.Forms.TextBox();
            this.rtb_value = new System.Windows.Forms.RichTextBox();
            this.lb_info_1 = new System.Windows.Forms.Label();
            this.lb_info_2 = new System.Windows.Forms.Label();
            this.lb_info_3 = new System.Windows.Forms.Label();
            this.bt_ok = new System.Windows.Forms.Button();
            this.tb_attribute = new WatermakTextBox();
            this.SuspendLayout();
            // 
            // rtb_setValue
            // 
            this.rtb_setValue.Dock = System.Windows.Forms.DockStyle.Top;
            this.rtb_setValue.Enabled = false;
            this.rtb_setValue.Location = new System.Drawing.Point(0, 0);
            this.rtb_setValue.Name = "rtb_setValue";
            this.rtb_setValue.Size = new System.Drawing.Size(449, 70);
            this.rtb_setValue.TabIndex = 0;
            this.rtb_setValue.Text = "";
            // 
            // tb_name
            // 
            this.tb_name.Location = new System.Drawing.Point(87, 76);
            this.tb_name.Name = "tb_name";
            this.tb_name.Size = new System.Drawing.Size(350, 21);
            this.tb_name.TabIndex = 1;
            this.tb_name.TextChanged += new System.EventHandler(this.tb_attribute_TextChanged);
            // 
            // rtb_value
            // 
            this.rtb_value.Location = new System.Drawing.Point(87, 103);
            this.rtb_value.Name = "rtb_value";
            this.rtb_value.Size = new System.Drawing.Size(350, 85);
            this.rtb_value.TabIndex = 2;
            this.rtb_value.Text = "";
            this.rtb_value.TextChanged += new System.EventHandler(this.tb_attribute_TextChanged);
            // 
            // lb_info_1
            // 
            this.lb_info_1.AutoSize = true;
            this.lb_info_1.Location = new System.Drawing.Point(7, 80);
            this.lb_info_1.Name = "lb_info_1";
            this.lb_info_1.Size = new System.Drawing.Size(35, 12);
            this.lb_info_1.TabIndex = 4;
            this.lb_info_1.Text = "Name:";
            // 
            // lb_info_2
            // 
            this.lb_info_2.AutoSize = true;
            this.lb_info_2.Location = new System.Drawing.Point(8, 112);
            this.lb_info_2.Name = "lb_info_2";
            this.lb_info_2.Size = new System.Drawing.Size(41, 12);
            this.lb_info_2.TabIndex = 5;
            this.lb_info_2.Text = "Value:";
            // 
            // lb_info_3
            // 
            this.lb_info_3.AutoSize = true;
            this.lb_info_3.Location = new System.Drawing.Point(9, 199);
            this.lb_info_3.Name = "lb_info_3";
            this.lb_info_3.Size = new System.Drawing.Size(71, 12);
            this.lb_info_3.TabIndex = 6;
            this.lb_info_3.Text = "Attributes:";
            // 
            // bt_ok
            // 
            this.bt_ok.Location = new System.Drawing.Point(362, 219);
            this.bt_ok.Name = "bt_ok";
            this.bt_ok.Size = new System.Drawing.Size(75, 23);
            this.bt_ok.TabIndex = 7;
            this.bt_ok.Text = "confirm";
            this.bt_ok.UseVisualStyleBackColor = true;
            this.bt_ok.Click += new System.EventHandler(this.bt_ok_Click);
            // 
            // tb_attribute
            // 
            this.tb_attribute.Location = new System.Drawing.Point(87, 195);
            this.tb_attribute.Name = "tb_attribute";
            this.tb_attribute.Size = new System.Drawing.Size(350, 21);
            this.tb_attribute.TabIndex = 3;
            this.tb_attribute.WatermarkText = "Domain=company.cn; HttpOnly;Path=/; Expires=Wed, 30 Aug 2019 00:00:00 GMT";
            this.tb_attribute.TextChanged += new System.EventHandler(this.tb_attribute_TextChanged);
            // 
            // EditCookieForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 254);
            this.Controls.Add(this.bt_ok);
            this.Controls.Add(this.lb_info_3);
            this.Controls.Add(this.lb_info_2);
            this.Controls.Add(this.lb_info_1);
            this.Controls.Add(this.tb_attribute);
            this.Controls.Add(this.rtb_value);
            this.Controls.Add(this.tb_name);
            this.Controls.Add(this.rtb_setValue);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditCookieForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "EditCookieForm";
            this.Load += new System.EventHandler(this.EditCookieForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtb_setValue;
        private System.Windows.Forms.TextBox tb_name;
        private System.Windows.Forms.RichTextBox rtb_value;
        private WatermakTextBox tb_attribute;
        private System.Windows.Forms.Label lb_info_1;
        private System.Windows.Forms.Label lb_info_2;
        private System.Windows.Forms.Button bt_ok;
        private System.Windows.Forms.Label lb_info_3;
    }
}