namespace FreeHttp.FreeHttpControl
{
    partial class StaticDataManageWindow
    {
        private System.Windows.Forms.ListView listView_CaseParameter;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label lb_info_dataSouce;
        private System.Windows.Forms.Label lb_info_parameter;
        private System.Windows.Forms.Label lb_info_keyValue;
        private System.Windows.Forms.ColumnHeader columnHeader2;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StaticDataManageWindow));
            this.listView_CaseParameter = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lb_info_dataSouce = new System.Windows.Forms.Label();
            this.lb_info_parameter = new System.Windows.Forms.Label();
            this.lb_info_keyValue = new System.Windows.Forms.Label();
            this.pb_addRequestRule = new System.Windows.Forms.PictureBox();
            this.pb_removeRequestRule = new System.Windows.Forms.PictureBox();
            this.tb_valueAdd = new System.Windows.Forms.TextBox();
            this.tb_keyAdd = new System.Windows.Forms.TextBox();
            this.label_info = new System.Windows.Forms.Label();
            this.pb_edit = new FreeHttp.FreeHttpControl.MyPictureButton();
            this.pb_next = new FreeHttp.FreeHttpControl.MyPictureButton();
            this.pb_reset = new FreeHttp.FreeHttpControl.MyPictureButton();
            ((System.ComponentModel.ISupportInitialize)(this.pb_addRequestRule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_removeRequestRule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_edit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_next)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_reset)).BeginInit();
            this.SuspendLayout();
            // 
            // listView_CaseParameter
            // 
            this.listView_CaseParameter.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView_CaseParameter.Location = new System.Drawing.Point(4, 35);
            this.listView_CaseParameter.Name = "listView_CaseParameter";
            this.listView_CaseParameter.Size = new System.Drawing.Size(564, 328);
            this.listView_CaseParameter.TabIndex = 14;
            this.listView_CaseParameter.UseCompatibleStateImageBehavior = false;
            this.listView_CaseParameter.View = System.Windows.Forms.View.Details;
            this.listView_CaseParameter.SelectedIndexChanged += new System.EventHandler(this.listView_CaseParameter_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 101;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Type";
            this.columnHeader2.Width = 93;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Value";
            this.columnHeader3.Width = 362;
            // 
            // lb_info_dataSouce
            // 
            this.lb_info_dataSouce.AutoSize = true;
            this.lb_info_dataSouce.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lb_info_dataSouce.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_info_dataSouce.ForeColor = System.Drawing.Color.DarkGray;
            this.lb_info_dataSouce.Location = new System.Drawing.Point(314, 14);
            this.lb_info_dataSouce.Name = "lb_info_dataSouce";
            this.lb_info_dataSouce.Size = new System.Drawing.Size(79, 13);
            this.lb_info_dataSouce.TabIndex = 19;
            this.lb_info_dataSouce.Text = "DataSouce";
            this.lb_info_dataSouce.Click += new System.EventHandler(this.lb_info_runTimeParameter_Click);
            this.lb_info_dataSouce.MouseLeave += new System.EventHandler(this.lb_info_MouseLeave);
            this.lb_info_dataSouce.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lb_info_MouseMove);
            // 
            // lb_info_parameter
            // 
            this.lb_info_parameter.AutoSize = true;
            this.lb_info_parameter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lb_info_parameter.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_info_parameter.ForeColor = System.Drawing.Color.DarkGray;
            this.lb_info_parameter.Location = new System.Drawing.Point(231, 14);
            this.lb_info_parameter.Name = "lb_info_parameter";
            this.lb_info_parameter.Size = new System.Drawing.Size(79, 13);
            this.lb_info_parameter.TabIndex = 18;
            this.lb_info_parameter.Text = "Parameter";
            this.lb_info_parameter.Click += new System.EventHandler(this.lb_info_runTimeParameter_Click);
            this.lb_info_parameter.MouseLeave += new System.EventHandler(this.lb_info_MouseLeave);
            this.lb_info_parameter.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lb_info_MouseMove);
            // 
            // lb_info_keyValue
            // 
            this.lb_info_keyValue.AutoSize = true;
            this.lb_info_keyValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.lb_info_keyValue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lb_info_keyValue.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_info_keyValue.ForeColor = System.Drawing.Color.SaddleBrown;
            this.lb_info_keyValue.Location = new System.Drawing.Point(154, 14);
            this.lb_info_keyValue.Name = "lb_info_keyValue";
            this.lb_info_keyValue.Size = new System.Drawing.Size(71, 13);
            this.lb_info_keyValue.TabIndex = 17;
            this.lb_info_keyValue.Text = "KeyValue";
            this.lb_info_keyValue.Click += new System.EventHandler(this.lb_info_runTimeParameter_Click);
            this.lb_info_keyValue.MouseLeave += new System.EventHandler(this.lb_info_MouseLeave);
            this.lb_info_keyValue.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lb_info_MouseMove);
            // 
            // pb_addRequestRule
            // 
            this.pb_addRequestRule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_addRequestRule.BackColor = System.Drawing.Color.White;
            this.pb_addRequestRule.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_addRequestRule.Image = ((System.Drawing.Image)(resources.GetObject("pb_addRequestRule.Image")));
            this.pb_addRequestRule.Location = new System.Drawing.Point(522, 36);
            this.pb_addRequestRule.Name = "pb_addRequestRule";
            this.pb_addRequestRule.Size = new System.Drawing.Size(22, 22);
            this.pb_addRequestRule.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_addRequestRule.TabIndex = 55;
            this.pb_addRequestRule.TabStop = false;
            this.pb_addRequestRule.MouseLeave += new System.EventHandler(this.pictureBox_MouseLeave);
            this.pb_addRequestRule.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            // 
            // pb_removeRequestRule
            // 
            this.pb_removeRequestRule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_removeRequestRule.BackColor = System.Drawing.Color.White;
            this.pb_removeRequestRule.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_removeRequestRule.Image = ((System.Drawing.Image)(resources.GetObject("pb_removeRequestRule.Image")));
            this.pb_removeRequestRule.Location = new System.Drawing.Point(544, 36);
            this.pb_removeRequestRule.Name = "pb_removeRequestRule";
            this.pb_removeRequestRule.Size = new System.Drawing.Size(22, 22);
            this.pb_removeRequestRule.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_removeRequestRule.TabIndex = 54;
            this.pb_removeRequestRule.TabStop = false;
            this.pb_removeRequestRule.MouseLeave += new System.EventHandler(this.pictureBox_MouseLeave);
            this.pb_removeRequestRule.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            // 
            // tb_valueAdd
            // 
            this.tb_valueAdd.Location = new System.Drawing.Point(118, 397);
            this.tb_valueAdd.Name = "tb_valueAdd";
            this.tb_valueAdd.Size = new System.Drawing.Size(370, 21);
            this.tb_valueAdd.TabIndex = 57;
            // 
            // tb_keyAdd
            // 
            this.tb_keyAdd.Enabled = false;
            this.tb_keyAdd.Location = new System.Drawing.Point(4, 397);
            this.tb_keyAdd.Name = "tb_keyAdd";
            this.tb_keyAdd.Size = new System.Drawing.Size(108, 21);
            this.tb_keyAdd.TabIndex = 56;
            // 
            // label_info
            // 
            this.label_info.AutoSize = true;
            this.label_info.Location = new System.Drawing.Point(7, 375);
            this.label_info.Name = "label_info";
            this.label_info.Size = new System.Drawing.Size(83, 12);
            this.label_info.TabIndex = 61;
            this.label_info.Text = "Data Origin :";
            // 
            // pb_edit
            // 
            this.pb_edit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_edit.DisEnabledImage = ((System.Drawing.Image)(resources.GetObject("pb_edit.DisEnabledImage")));
            this.pb_edit.EnabledImage = ((System.Drawing.Image)(resources.GetObject("pb_edit.EnabledImage")));
            this.pb_edit.Image = ((System.Drawing.Image)(resources.GetObject("pb_edit.Image")));
            this.pb_edit.Location = new System.Drawing.Point(495, 397);
            this.pb_edit.Name = "pb_edit";
            this.pb_edit.Size = new System.Drawing.Size(23, 23);
            this.pb_edit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_edit.TabIndex = 62;
            this.pb_edit.TabStop = false;
            // 
            // pb_next
            // 
            this.pb_next.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_next.DisEnabledImage = ((System.Drawing.Image)(resources.GetObject("pb_next.DisEnabledImage")));
            this.pb_next.EnabledImage = ((System.Drawing.Image)(resources.GetObject("pb_next.EnabledImage")));
            this.pb_next.Image = ((System.Drawing.Image)(resources.GetObject("pb_next.Image")));
            this.pb_next.Location = new System.Drawing.Point(519, 397);
            this.pb_next.Name = "pb_next";
            this.pb_next.Size = new System.Drawing.Size(23, 23);
            this.pb_next.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_next.TabIndex = 63;
            this.pb_next.TabStop = false;
            // 
            // pb_reset
            // 
            this.pb_reset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_reset.DisEnabledImage = ((System.Drawing.Image)(resources.GetObject("pb_reset.DisEnabledImage")));
            this.pb_reset.EnabledImage = ((System.Drawing.Image)(resources.GetObject("pb_reset.EnabledImage")));
            this.pb_reset.Image = ((System.Drawing.Image)(resources.GetObject("pb_reset.Image")));
            this.pb_reset.Location = new System.Drawing.Point(543, 397);
            this.pb_reset.Name = "pb_reset";
            this.pb_reset.Size = new System.Drawing.Size(23, 23);
            this.pb_reset.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_reset.TabIndex = 64;
            this.pb_reset.TabStop = false;
            // 
            // StaticDataManageWindow
            // 
            this.ClientSize = new System.Drawing.Size(572, 428);
            this.Controls.Add(this.pb_reset);
            this.Controls.Add(this.pb_next);
            this.Controls.Add(this.pb_edit);
            this.Controls.Add(this.label_info);
            this.Controls.Add(this.tb_valueAdd);
            this.Controls.Add(this.tb_keyAdd);
            this.Controls.Add(this.pb_addRequestRule);
            this.Controls.Add(this.pb_removeRequestRule);
            this.Controls.Add(this.lb_info_dataSouce);
            this.Controls.Add(this.lb_info_parameter);
            this.Controls.Add(this.lb_info_keyValue);
            this.Controls.Add(this.listView_CaseParameter);
            this.IntervalTime = 3000;
            this.IsShowHideBox = false;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "StaticDataManageWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.WindowName = "";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StaticDataManageWindow_FormClosing);
            this.Load += new System.EventHandler(this.StaticDataManageWindow_Load);
            this.Controls.SetChildIndex(this.listView_CaseParameter, 0);
            this.Controls.SetChildIndex(this.lb_info_keyValue, 0);
            this.Controls.SetChildIndex(this.lb_info_parameter, 0);
            this.Controls.SetChildIndex(this.lb_info_dataSouce, 0);
            this.Controls.SetChildIndex(this.pb_removeRequestRule, 0);
            this.Controls.SetChildIndex(this.pb_addRequestRule, 0);
            this.Controls.SetChildIndex(this.tb_keyAdd, 0);
            this.Controls.SetChildIndex(this.tb_valueAdd, 0);
            this.Controls.SetChildIndex(this.label_info, 0);
            this.Controls.SetChildIndex(this.pb_edit, 0);
            this.Controls.SetChildIndex(this.pb_next, 0);
            this.Controls.SetChildIndex(this.pb_reset, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pb_addRequestRule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_removeRequestRule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_edit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_next)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_reset)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.PictureBox pb_addRequestRule;
        private System.Windows.Forms.PictureBox pb_removeRequestRule;
        private System.Windows.Forms.TextBox tb_valueAdd;
        private System.Windows.Forms.TextBox tb_keyAdd;
        private System.Windows.Forms.Label label_info;
        private MyPictureButton pb_edit;
        private MyPictureButton pb_next;
        private MyPictureButton pb_reset;

    }
}
