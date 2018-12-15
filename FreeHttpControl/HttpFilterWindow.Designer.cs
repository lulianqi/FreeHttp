namespace FreeHttp.FreeHttpControl
{
    partial class HttpFilterWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HttpFilterWindow));
            this.requestAddHeads = new FreeHttp.FreeHttpControl.EditListView();
            this.SuspendLayout();
            // 
            // requestAddHeads
            // 
            this.requestAddHeads.ColumnHeaderName = "Head Filter";
            this.requestAddHeads.Dock = System.Windows.Forms.DockStyle.Top;
            this.requestAddHeads.IsKeyValue = true;
            this.requestAddHeads.Location = new System.Drawing.Point(0, 0);
            this.requestAddHeads.Name = "requestAddHeads";
            this.requestAddHeads.Size = new System.Drawing.Size(568, 191);
            this.requestAddHeads.SplitStr = "  <contain> ";
            this.requestAddHeads.TabIndex = 2;
            // 
            // HttpFilterWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 327);
            this.Controls.Add(this.requestAddHeads);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HttpFilterWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "HttpFilterWindow";
            this.Load += new System.EventHandler(this.HttpFilterWindow_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private EditListView requestAddHeads;
    }
}