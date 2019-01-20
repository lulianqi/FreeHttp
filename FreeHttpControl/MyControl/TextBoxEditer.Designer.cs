namespace FreeHttp.FreeHttpControl
{
    partial class TextBoxEditer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextBoxEditer));
            this.pb_editTextBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_editTextBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pb_editTextBox
            // 
            this.pb_editTextBox.BackColor = System.Drawing.Color.Transparent;
            this.pb_editTextBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_editTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_editTextBox.Image = ((System.Drawing.Image)(resources.GetObject("pb_editTextBox.Image")));
            this.pb_editTextBox.Location = new System.Drawing.Point(0, 0);
            this.pb_editTextBox.Name = "pb_editTextBox";
            this.pb_editTextBox.Size = new System.Drawing.Size(21, 21);
            this.pb_editTextBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_editTextBox.TabIndex = 40;
            this.pb_editTextBox.TabStop = false;
            this.pb_editTextBox.Click += new System.EventHandler(this.pb_editTextBox_Click);
            this.pb_editTextBox.MouseLeave += new System.EventHandler(this.pictureBox_MouseLeave);
            this.pb_editTextBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            // 
            // TextBoxEditer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pb_editTextBox);
            this.Name = "TextBoxEditer";
            this.Size = new System.Drawing.Size(21, 21);
            ((System.ComponentModel.ISupportInitialize)(this.pb_editTextBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_editTextBox;
    }
}
