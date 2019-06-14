namespace FreeHttp.FreeHttpControl
{
    partial class UserFeedbackWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserFeedbackWindow));
            this.rtb_feedbackContent = new System.Windows.Forms.RichTextBox();
            this.watermakTextBox_contactInfo = new FreeHttp.FreeHttpControl.WatermakTextBox();
            this.bt_ok = new System.Windows.Forms.Button();
            this.lb_info_1 = new System.Windows.Forms.Label();
            this.llb_gotoGitHub = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // rtb_feedbackContent
            // 
            this.rtb_feedbackContent.Location = new System.Drawing.Point(2, 3);
            this.rtb_feedbackContent.Name = "rtb_feedbackContent";
            this.rtb_feedbackContent.Size = new System.Drawing.Size(723, 284);
            this.rtb_feedbackContent.TabIndex = 0;
            this.rtb_feedbackContent.Text = "";
            // 
            // watermakTextBox_contactInfo
            // 
            this.watermakTextBox_contactInfo.Location = new System.Drawing.Point(140, 291);
            this.watermakTextBox_contactInfo.Name = "watermakTextBox_contactInfo";
            this.watermakTextBox_contactInfo.Size = new System.Drawing.Size(584, 21);
            this.watermakTextBox_contactInfo.TabIndex = 1;
            this.watermakTextBox_contactInfo.WatermarkText = "email qq weixin or any contact information";
            // 
            // bt_ok
            // 
            this.bt_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_ok.Location = new System.Drawing.Point(649, 318);
            this.bt_ok.Name = "bt_ok";
            this.bt_ok.Size = new System.Drawing.Size(75, 23);
            this.bt_ok.TabIndex = 9;
            this.bt_ok.Text = "confirm";
            this.bt_ok.UseVisualStyleBackColor = true;
            this.bt_ok.Click += new System.EventHandler(this.Bt_ok_Click);
            // 
            // lb_info_1
            // 
            this.lb_info_1.AutoSize = true;
            this.lb_info_1.Location = new System.Drawing.Point(3, 294);
            this.lb_info_1.Name = "lb_info_1";
            this.lb_info_1.Size = new System.Drawing.Size(131, 12);
            this.lb_info_1.TabIndex = 10;
            this.lb_info_1.Text = "contact information :";
            // 
            // llb_gotoGitHub
            // 
            this.llb_gotoGitHub.AutoSize = true;
            this.llb_gotoGitHub.LinkColor = System.Drawing.SystemColors.Highlight;
            this.llb_gotoGitHub.Location = new System.Drawing.Point(524, 324);
            this.llb_gotoGitHub.Name = "llb_gotoGitHub";
            this.llb_gotoGitHub.Size = new System.Drawing.Size(119, 12);
            this.llb_gotoGitHub.TabIndex = 11;
            this.llb_gotoGitHub.TabStop = true;
            this.llb_gotoGitHub.Text = "discussed in github";
            this.llb_gotoGitHub.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Llb_gotoGitHub_LinkClicked);
            // 
            // UserFeedbackWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 350);
            this.Controls.Add(this.llb_gotoGitHub);
            this.Controls.Add(this.lb_info_1);
            this.Controls.Add(this.bt_ok);
            this.Controls.Add(this.watermakTextBox_contactInfo);
            this.Controls.Add(this.rtb_feedbackContent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserFeedbackWindow";
            this.Text = "Feedback";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtb_feedbackContent;
        private WatermakTextBox watermakTextBox_contactInfo;
        private System.Windows.Forms.Button bt_ok;
        private System.Windows.Forms.Label lb_info_1;
        private System.Windows.Forms.LinkLabel llb_gotoGitHub;
    }
}