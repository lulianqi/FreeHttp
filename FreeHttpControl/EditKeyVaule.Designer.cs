namespace FreeHttp.FreeHttpControl
{
    partial class EditKeyVaule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditKeyVaule));
            this.lb_info_2 = new System.Windows.Forms.Label();
            this.lb_info_1 = new System.Windows.Forms.Label();
            this.rtb_value = new System.Windows.Forms.RichTextBox();
            this.tb_key = new System.Windows.Forms.TextBox();
            this.bt_ok = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lb_info_2
            // 
            this.lb_info_2.AutoSize = true;
            this.lb_info_2.Location = new System.Drawing.Point(14, 48);
            this.lb_info_2.Name = "lb_info_2";
            this.lb_info_2.Size = new System.Drawing.Size(41, 12);
            this.lb_info_2.TabIndex = 9;
            this.lb_info_2.Text = "Value:";
            // 
            // lb_info_1
            // 
            this.lb_info_1.AutoSize = true;
            this.lb_info_1.Location = new System.Drawing.Point(13, 16);
            this.lb_info_1.Name = "lb_info_1";
            this.lb_info_1.Size = new System.Drawing.Size(29, 12);
            this.lb_info_1.TabIndex = 8;
            this.lb_info_1.Text = "Key:";
            // 
            // rtb_value
            // 
            this.rtb_value.Location = new System.Drawing.Point(93, 39);
            this.rtb_value.Name = "rtb_value";
            this.rtb_value.Size = new System.Drawing.Size(250, 111);
            this.rtb_value.TabIndex = 7;
            this.rtb_value.Text = "";
            // 
            // tb_key
            // 
            this.tb_key.Location = new System.Drawing.Point(93, 12);
            this.tb_key.Name = "tb_key";
            this.tb_key.Size = new System.Drawing.Size(250, 21);
            this.tb_key.TabIndex = 6;
            // 
            // bt_ok
            // 
            this.bt_ok.Location = new System.Drawing.Point(268, 157);
            this.bt_ok.Name = "bt_ok";
            this.bt_ok.Size = new System.Drawing.Size(75, 23);
            this.bt_ok.TabIndex = 10;
            this.bt_ok.Text = "confirm";
            this.bt_ok.UseVisualStyleBackColor = true;
            this.bt_ok.Click += new System.EventHandler(this.bt_ok_Click);
            // 
            // AddHead
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 185);
            this.Controls.Add(this.bt_ok);
            this.Controls.Add(this.lb_info_2);
            this.Controls.Add(this.lb_info_1);
            this.Controls.Add(this.rtb_value);
            this.Controls.Add(this.tb_key);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddHead";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddHead";
            this.Load += new System.EventHandler(this.EditKeyVaule_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_info_2;
        private System.Windows.Forms.Label lb_info_1;
        private System.Windows.Forms.RichTextBox rtb_value;
        private System.Windows.Forms.TextBox tb_key;
        private System.Windows.Forms.Button bt_ok;

    }
}