namespace FreeHttp.FreeHttpControl
{
    partial class EditParameterPickWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditParameterPickWindow));
            this.lb_info = new System.Windows.Forms.Label();
            this.bt_ok = new System.Windows.Forms.Button();
            this.pb_add = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_add)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_info
            // 
            this.lb_info.AutoSize = true;
            this.lb_info.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb_info.Location = new System.Drawing.Point(16, 12);
            this.lb_info.Name = "lb_info";
            this.lb_info.Size = new System.Drawing.Size(479, 12);
            this.lb_info.TabIndex = 1;
            this.lb_info.Text = "Parameter Name     PickType      PickAdditional    PickRange    Pick Expression";
            // 
            // bt_ok
            // 
            this.bt_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_ok.Location = new System.Drawing.Point(711, 31);
            this.bt_ok.Name = "bt_ok";
            this.bt_ok.Size = new System.Drawing.Size(75, 23);
            this.bt_ok.TabIndex = 11;
            this.bt_ok.Text = "confirm";
            this.bt_ok.UseVisualStyleBackColor = true;
            this.bt_ok.Click += new System.EventHandler(this.bt_ok_Click);
            // 
            // pb_add
            // 
            this.pb_add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_add.BackColor = System.Drawing.Color.Transparent;
            this.pb_add.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_add.Image = ((System.Drawing.Image)(resources.GetObject("pb_add.Image")));
            this.pb_add.Location = new System.Drawing.Point(762, 2);
            this.pb_add.Name = "pb_add";
            this.pb_add.Size = new System.Drawing.Size(23, 23);
            this.pb_add.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_add.TabIndex = 58;
            this.pb_add.TabStop = false;
            this.pb_add.Visible = false;
            this.pb_add.Click += new System.EventHandler(this.pb_add_Click);
            // 
            // EditParameterPickWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 59);
            this.Controls.Add(this.pb_add);
            this.Controls.Add(this.bt_ok);
            this.Controls.Add(this.lb_info);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditParameterPickWindow";
            this.Text = "EditParameterPickWindow";
            this.Load += new System.EventHandler(this.EditParameterPickWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_add)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_info;
        private System.Windows.Forms.Button bt_ok;
        private System.Windows.Forms.PictureBox pb_add;
    }
}