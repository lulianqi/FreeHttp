namespace FreeHttp.FreeHttpControl
{
    partial class RawRequestEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RawRequestEdit));
            this.rtb_request = new System.Windows.Forms.RichTextBox();
            this.pictureBox_changeMode = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_changeMode)).BeginInit();
            this.SuspendLayout();
            // 
            // rtb_request
            // 
            this.rtb_request.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_request.Location = new System.Drawing.Point(0, 0);
            this.rtb_request.Name = "rtb_request";
            this.rtb_request.Size = new System.Drawing.Size(511, 209);
            this.rtb_request.TabIndex = 0;
            this.rtb_request.Text = "";
            // 
            // pictureBox_changeMode
            // 
            this.pictureBox_changeMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_changeMode.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_changeMode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_changeMode.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_changeMode.Image")));
            this.pictureBox_changeMode.Location = new System.Drawing.Point(485, 3);
            this.pictureBox_changeMode.Name = "pictureBox_changeMode";
            this.pictureBox_changeMode.Size = new System.Drawing.Size(23, 22);
            this.pictureBox_changeMode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_changeMode.TabIndex = 39;
            this.pictureBox_changeMode.TabStop = false;
            this.pictureBox_changeMode.Click += new System.EventHandler(this.pictureBox_changeMode_Click);
            this.pictureBox_changeMode.MouseLeave += new System.EventHandler(this.pictureBox_MouseLeave);
            this.pictureBox_changeMode.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            // 
            // RawRequestEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBox_changeMode);
            this.Controls.Add(this.rtb_request);
            this.Name = "RawRequestEdit";
            this.Size = new System.Drawing.Size(511, 209);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_changeMode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtb_request;
        private System.Windows.Forms.PictureBox pictureBox_changeMode;
    }
}
