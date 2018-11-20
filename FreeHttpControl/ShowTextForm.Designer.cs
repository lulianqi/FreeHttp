namespace FreeHttp.FreeHttpControl
{
    partial class ShowTextForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowTextForm));
            this.rtb_textInfo = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtb_textInfo
            // 
            this.rtb_textInfo.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.rtb_textInfo.DetectUrls = false;
            this.rtb_textInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_textInfo.Location = new System.Drawing.Point(0, 0);
            this.rtb_textInfo.Name = "rtb_textInfo";
            this.rtb_textInfo.ReadOnly = true;
            this.rtb_textInfo.Size = new System.Drawing.Size(628, 284);
            this.rtb_textInfo.TabIndex = 0;
            this.rtb_textInfo.Text = "";
            // 
            // ShowTextForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 284);
            this.Controls.Add(this.rtb_textInfo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "ShowTextForm";
            this.Text = "ShowTextForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtb_textInfo;
    }
}