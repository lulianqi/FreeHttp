namespace FreeHttp.FreeHttpControl
{
    partial class SetVaule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetVaule));
            this.bt_ok = new System.Windows.Forms.Button();
            this.tb_vaule = new System.Windows.Forms.TextBox();
            this.lb_info = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bt_ok
            // 
            this.bt_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_ok.Location = new System.Drawing.Point(197, 67);
            this.bt_ok.Name = "bt_ok";
            this.bt_ok.Size = new System.Drawing.Size(75, 23);
            this.bt_ok.TabIndex = 8;
            this.bt_ok.Text = "confirm";
            this.bt_ok.UseVisualStyleBackColor = true;
            this.bt_ok.Click += new System.EventHandler(this.bt_ok_Click);
            // 
            // tb_vaule
            // 
            this.tb_vaule.Location = new System.Drawing.Point(11, 42);
            this.tb_vaule.Name = "tb_vaule";
            this.tb_vaule.Size = new System.Drawing.Size(260, 21);
            this.tb_vaule.TabIndex = 9;
            // 
            // lb_info
            // 
            this.lb_info.Location = new System.Drawing.Point(11, 3);
            this.lb_info.Name = "lb_info";
            this.lb_info.Size = new System.Drawing.Size(260, 36);
            this.lb_info.TabIndex = 10;
            // 
            // SetVaule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 102);
            this.Controls.Add(this.lb_info);
            this.Controls.Add(this.tb_vaule);
            this.Controls.Add(this.bt_ok);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetVaule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SetVaule";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_ok;
        private System.Windows.Forms.TextBox tb_vaule;
        private System.Windows.Forms.Label lb_info;
    }
}