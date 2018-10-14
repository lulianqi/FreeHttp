namespace FreeHttp.FreeHttpControl
{
    partial class RawResponseEdit
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RawResponseEdit));
            this.cb_responseLine = new System.Windows.Forms.ComboBox();
            this.rtb_rawResponse = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip_forRtbResponse = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog_responseFile = new System.Windows.Forms.OpenFileDialog();
            this.ck_directResponse = new System.Windows.Forms.CheckBox();
            this.toolTip_RawResponseEdit = new System.Windows.Forms.ToolTip(this.components);
            this.antoContentLengthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip_forRtbResponse.SuspendLayout();
            this.SuspendLayout();
            // 
            // cb_responseLine
            // 
            this.cb_responseLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_responseLine.FormattingEnabled = true;
            this.cb_responseLine.Location = new System.Drawing.Point(3, 3);
            this.cb_responseLine.Name = "cb_responseLine";
            this.cb_responseLine.Size = new System.Drawing.Size(329, 20);
            this.cb_responseLine.TabIndex = 0;
            this.cb_responseLine.SelectedIndexChanged += new System.EventHandler(this.cb_responseLine_SelectedIndexChanged);
            // 
            // rtb_rawResponse
            // 
            this.rtb_rawResponse.ContextMenuStrip = this.contextMenuStrip_forRtbResponse;
            this.rtb_rawResponse.DetectUrls = false;
            this.rtb_rawResponse.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rtb_rawResponse.Location = new System.Drawing.Point(0, 25);
            this.rtb_rawResponse.Name = "rtb_rawResponse";
            this.rtb_rawResponse.Size = new System.Drawing.Size(550, 176);
            this.rtb_rawResponse.TabIndex = 1;
            this.rtb_rawResponse.Text = "";
            // 
            // contextMenuStrip_forRtbResponse
            // 
            this.contextMenuStrip_forRtbResponse.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addFileToolStripMenuItem,
            this.antoContentLengthToolStripMenuItem});
            this.contextMenuStrip_forRtbResponse.Name = "contextMenuStrip_forRtbResponse";
            this.contextMenuStrip_forRtbResponse.Size = new System.Drawing.Size(196, 70);
            // 
            // addFileToolStripMenuItem
            // 
            this.addFileToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("addFileToolStripMenuItem.Image")));
            this.addFileToolStripMenuItem.Name = "addFileToolStripMenuItem";
            this.addFileToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.addFileToolStripMenuItem.Text = "add file";
            this.addFileToolStripMenuItem.Click += new System.EventHandler(this.addFileToolStripMenuItem_Click);
            // 
            // openFileDialog_responseFile
            // 
            this.openFileDialog_responseFile.FileName = "openFileDialog";
            // 
            // ck_directResponse
            // 
            this.ck_directResponse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ck_directResponse.Location = new System.Drawing.Point(433, 5);
            this.ck_directResponse.Name = "ck_directResponse";
            this.ck_directResponse.Size = new System.Drawing.Size(114, 16);
            this.ck_directResponse.TabIndex = 39;
            this.ck_directResponse.Text = "Response Direct";
            this.toolTip_RawResponseEdit.SetToolTip(this.ck_directResponse, "not send the request to the real sever \r\nit will direct return your response");
            this.ck_directResponse.UseVisualStyleBackColor = true;
            // 
            // antoContentLengthToolStripMenuItem
            // 
            this.antoContentLengthToolStripMenuItem.Name = "antoContentLengthToolStripMenuItem";
            this.antoContentLengthToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.antoContentLengthToolStripMenuItem.Text = "anto Content-Length";
            this.antoContentLengthToolStripMenuItem.Click += new System.EventHandler(this.antoContentLengthToolStripMenuItem_Click);
            // 
            // RawResponseEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ck_directResponse);
            this.Controls.Add(this.rtb_rawResponse);
            this.Controls.Add(this.cb_responseLine);
            this.Name = "RawResponseEdit";
            this.Size = new System.Drawing.Size(550, 201);
            this.Load += new System.EventHandler(this.RawResponseEdit_Load);
            this.Resize += new System.EventHandler(this.RawResponseEdit_Resize);
            this.contextMenuStrip_forRtbResponse.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_responseLine;
        private System.Windows.Forms.RichTextBox rtb_rawResponse;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_forRtbResponse;
        private System.Windows.Forms.ToolStripMenuItem addFileToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog_responseFile;
        private System.Windows.Forms.CheckBox ck_directResponse;
        private System.Windows.Forms.ToolTip toolTip_RawResponseEdit;
        private System.Windows.Forms.ToolStripMenuItem antoContentLengthToolStripMenuItem;
    }
}
