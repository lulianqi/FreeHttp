namespace FreeHttp.FreeHttpControl
{
    partial class StaticDataAddWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StaticDataAddWindow));
            this.comboBox_CaseStaticDataClass = new System.Windows.Forms.ComboBox();
            this.lb_info_1 = new System.Windows.Forms.Label();
            this.comboBox_CaseStaticDataType = new System.Windows.Forms.ComboBox();
            this.lb_info_2 = new System.Windows.Forms.Label();
            this.tb_key = new FreeHttp.FreeHttpControl.WatermakTextBox();
            this.tb_value = new FreeHttp.FreeHttpControl.WatermakTextBox();
            this.pb_confirm = new FreeHttp.FreeHttpControl.MyEnabledPictureButton();
            ((System.ComponentModel.ISupportInitialize)(this.pb_confirm)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox_CaseStaticDataClass
            // 
            this.comboBox_CaseStaticDataClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_CaseStaticDataClass.FormattingEnabled = true;
            this.comboBox_CaseStaticDataClass.Location = new System.Drawing.Point(72, 41);
            this.comboBox_CaseStaticDataClass.Name = "comboBox_CaseStaticDataClass";
            this.comboBox_CaseStaticDataClass.Size = new System.Drawing.Size(167, 20);
            this.comboBox_CaseStaticDataClass.TabIndex = 14;
            this.comboBox_CaseStaticDataClass.SelectedIndexChanged += new System.EventHandler(this.comboBox_CaseStaticDataClass_SelectedIndexChanged);
            // 
            // lb_info_1
            // 
            this.lb_info_1.AutoSize = true;
            this.lb_info_1.Location = new System.Drawing.Point(8, 44);
            this.lb_info_1.Name = "lb_info_1";
            this.lb_info_1.Size = new System.Drawing.Size(59, 12);
            this.lb_info_1.TabIndex = 15;
            this.lb_info_1.Text = "DataType:";
            // 
            // comboBox_CaseStaticDataType
            // 
            this.comboBox_CaseStaticDataType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_CaseStaticDataType.FormattingEnabled = true;
            this.comboBox_CaseStaticDataType.Location = new System.Drawing.Point(242, 41);
            this.comboBox_CaseStaticDataType.Name = "comboBox_CaseStaticDataType";
            this.comboBox_CaseStaticDataType.Size = new System.Drawing.Size(185, 20);
            this.comboBox_CaseStaticDataType.TabIndex = 16;
            this.comboBox_CaseStaticDataType.SelectedIndexChanged += new System.EventHandler(this.comboBox_CaseStaticDataType_SelectedIndexChanged);
            // 
            // lb_info_2
            // 
            this.lb_info_2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_info_2.ForeColor = System.Drawing.Color.Maroon;
            this.lb_info_2.Location = new System.Drawing.Point(8, 72);
            this.lb_info_2.Name = "lb_info_2";
            this.lb_info_2.Size = new System.Drawing.Size(419, 106);
            this.lb_info_2.TabIndex = 17;
            this.lb_info_2.Text = "StaticDataInfo";
            // 
            // tb_key
            // 
            this.tb_key.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tb_key.Location = new System.Drawing.Point(7, 188);
            this.tb_key.Name = "tb_key";
            this.tb_key.Size = new System.Drawing.Size(123, 21);
            this.tb_key.TabIndex = 18;
            this.tb_key.WatermarkText = "Static Data Name";
            // 
            // tb_value
            // 
            this.tb_value.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tb_value.Location = new System.Drawing.Point(135, 188);
            this.tb_value.Name = "tb_value";
            this.tb_value.Size = new System.Drawing.Size(265, 21);
            this.tb_value.TabIndex = 19;
            this.tb_value.WatermarkText = "Initialize Data Format";
            // 
            // pb_confirm
            // 
            this.pb_confirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pb_confirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_confirm.DisEnabledImage = null;
            this.pb_confirm.EnabledImage = null;
            this.pb_confirm.Image = ((System.Drawing.Image)(resources.GetObject("pb_confirm.Image")));
            this.pb_confirm.Location = new System.Drawing.Point(405, 187);
            this.pb_confirm.Name = "pb_confirm";
            this.pb_confirm.Size = new System.Drawing.Size(23, 23);
            this.pb_confirm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_confirm.TabIndex = 20;
            this.pb_confirm.TabStop = false;
            this.pb_confirm.Click += new System.EventHandler(this.pb_confirm_Click);
            // 
            // StaticDataAddWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 218);
            this.Controls.Add(this.lb_info_2);
            this.Controls.Add(this.pb_confirm);
            this.Controls.Add(this.tb_value);
            this.Controls.Add(this.tb_key);
            this.Controls.Add(this.comboBox_CaseStaticDataType);
            this.Controls.Add(this.lb_info_1);
            this.Controls.Add(this.comboBox_CaseStaticDataClass);
            this.IsShowHideBox = false;
            this.MaximizeBox = false;
            this.Name = "StaticDataAddWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Static Data";
            this.WindowName = "Add Static Data";
            this.Load += new System.EventHandler(this.StaticDataAdd_Load);
            this.Controls.SetChildIndex(this.comboBox_CaseStaticDataClass, 0);
            this.Controls.SetChildIndex(this.lb_info_1, 0);
            this.Controls.SetChildIndex(this.comboBox_CaseStaticDataType, 0);
            this.Controls.SetChildIndex(this.tb_key, 0);
            this.Controls.SetChildIndex(this.tb_value, 0);
            this.Controls.SetChildIndex(this.pb_confirm, 0);
            this.Controls.SetChildIndex(this.lb_info_2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pb_confirm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_CaseStaticDataClass;
        private System.Windows.Forms.Label lb_info_1;
        private System.Windows.Forms.ComboBox comboBox_CaseStaticDataType;
        private System.Windows.Forms.Label lb_info_2;
        private WatermakTextBox tb_key;
        private WatermakTextBox tb_value;
        private MyEnabledPictureButton pb_confirm;
    }
}