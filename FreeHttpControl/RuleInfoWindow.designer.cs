namespace FreeHttp.FreeHttpControl
{
    partial class RuleInfoWindow
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RuleInfoWindow));
            this.pictureBox_close = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lb_ruleId = new System.Windows.Forms.Label();
            this.pb_ruleIcon = new System.Windows.Forms.PictureBox();
            this.rtb_filter = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_close)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_ruleIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_close
            // 
            this.pictureBox_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_close.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_close.Image")));
            this.pictureBox_close.Location = new System.Drawing.Point(873, 33);
            this.pictureBox_close.Name = "pictureBox_close";
            this.pictureBox_close.Size = new System.Drawing.Size(20, 20);
            this.pictureBox_close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_close.TabIndex = 2;
            this.pictureBox_close.TabStop = false;
            this.pictureBox_close.Click += new System.EventHandler(this.pictureBox_close_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(850, 33);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // lb_ruleId
            // 
            this.lb_ruleId.AutoSize = true;
            this.lb_ruleId.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_ruleId.ForeColor = System.Drawing.Color.RosyBrown;
            this.lb_ruleId.Location = new System.Drawing.Point(60, 37);
            this.lb_ruleId.Name = "lb_ruleId";
            this.lb_ruleId.Size = new System.Drawing.Size(62, 16);
            this.lb_ruleId.TabIndex = 8;
            this.lb_ruleId.Text = "RuleId";
            // 
            // pb_ruleIcon
            // 
            this.pb_ruleIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_ruleIcon.Cursor = System.Windows.Forms.Cursors.Default;
            this.pb_ruleIcon.Location = new System.Drawing.Point(35, 35);
            this.pb_ruleIcon.Name = "pb_ruleIcon";
            this.pb_ruleIcon.Size = new System.Drawing.Size(20, 20);
            this.pb_ruleIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_ruleIcon.TabIndex = 9;
            this.pb_ruleIcon.TabStop = false;
            // 
            // rtb_filter
            // 
            this.rtb_filter.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtb_filter.DetectUrls = false;
            this.rtb_filter.Location = new System.Drawing.Point(35, 59);
            this.rtb_filter.Name = "rtb_filter";
            this.rtb_filter.ReadOnly = true;
            this.rtb_filter.Size = new System.Drawing.Size(858, 242);
            this.rtb_filter.TabIndex = 0;
            this.rtb_filter.Text = "";
            // 
            // RuleInfoWindow
            // 
            this.ClientSize = new System.Drawing.Size(929, 337);
            this.Controls.Add(this.rtb_filter);
            this.Controls.Add(this.pb_ruleIcon);
            this.Controls.Add(this.lb_ruleId);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox_close);
            this.FrameBottomRight = System.Drawing.Color.Cyan;
            this.FrameTopLeft = System.Drawing.Color.SkyBlue;
            this.Name = "RuleInfoWindow";
            this.Load += new System.EventHandler(this.MyCBalloon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_close)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_ruleIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_close;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lb_ruleId;
        private System.Windows.Forms.PictureBox pb_ruleIcon;
        private System.Windows.Forms.RichTextBox rtb_filter;
    }
}
