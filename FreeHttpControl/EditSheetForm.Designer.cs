namespace FreeHttp.FreeHttpControl
{
    partial class EditSheetForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditSheetForm));
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.pb_saveSheet = new System.Windows.Forms.PictureBox();
            this.pb_export = new System.Windows.Forms.PictureBox();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_saveSheet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_export)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.GridColor = System.Drawing.Color.AliceBlue;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dataGridView.RowTemplate.Height = 23;
            this.dataGridView.Size = new System.Drawing.Size(871, 410);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView_RowsAdded);
            this.dataGridView.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dataGridView_RowsRemoved);
            // 
            // pb_saveSheet
            // 
            this.pb_saveSheet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_saveSheet.BackColor = System.Drawing.Color.Transparent;
            this.pb_saveSheet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_saveSheet.Image = ((System.Drawing.Image)(resources.GetObject("pb_saveSheet.Image")));
            this.pb_saveSheet.Location = new System.Drawing.Point(823, 1);
            this.pb_saveSheet.Name = "pb_saveSheet";
            this.pb_saveSheet.Size = new System.Drawing.Size(23, 23);
            this.pb_saveSheet.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_saveSheet.TabIndex = 43;
            this.pb_saveSheet.TabStop = false;
            this.pb_saveSheet.Click += new System.EventHandler(this.pb_saveSheet_Click);
            this.pb_saveSheet.MouseLeave += new System.EventHandler(this.pictureBox_MouseLeave);
            this.pb_saveSheet.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            // 
            // pb_export
            // 
            this.pb_export.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_export.BackColor = System.Drawing.Color.Transparent;
            this.pb_export.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_export.Image = ((System.Drawing.Image)(resources.GetObject("pb_export.Image")));
            this.pb_export.Location = new System.Drawing.Point(847, 1);
            this.pb_export.Name = "pb_export";
            this.pb_export.Size = new System.Drawing.Size(23, 23);
            this.pb_export.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_export.TabIndex = 44;
            this.pb_export.TabStop = false;
            this.pb_export.Click += new System.EventHandler(this.pb_export_Click);
            this.pb_export.MouseLeave += new System.EventHandler(this.pictureBox_MouseLeave);
            this.pb_export.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "csv files (*.csv)|*.csv";
            // 
            // EditSheetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 410);
            this.Controls.Add(this.pb_export);
            this.Controls.Add(this.pb_saveSheet);
            this.Controls.Add(this.dataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "EditSheetForm";
            this.Text = "EditSheetForm";
            this.Load += new System.EventHandler(this.EditSheetForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_saveSheet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_export)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.PictureBox pb_saveSheet;
        private System.Windows.Forms.PictureBox pb_export;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}