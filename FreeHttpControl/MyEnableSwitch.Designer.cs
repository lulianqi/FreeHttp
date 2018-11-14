namespace FreeHttp.FreeHttpControl
{
    partial class MyEnableSwitch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyEnableSwitch));
            this.pb_switch = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_switch)).BeginInit();
            this.SuspendLayout();
            // 
            // pb_switch
            // 
            this.pb_switch.BackColor = System.Drawing.Color.Transparent;
            this.pb_switch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_switch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_switch.Image = ((System.Drawing.Image)(resources.GetObject("pb_switch.Image")));
            this.pb_switch.Location = new System.Drawing.Point(0, 0);
            this.pb_switch.Name = "pb_switch";
            this.pb_switch.Size = new System.Drawing.Size(36, 20);
            this.pb_switch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_switch.TabIndex = 39;
            this.pb_switch.TabStop = false;
            // 
            // MySwitch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pb_switch);
            this.Name = "MySwitch";
            this.Size = new System.Drawing.Size(36, 20);
            ((System.ComponentModel.ISupportInitialize)(this.pb_switch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_switch;
    }
}
