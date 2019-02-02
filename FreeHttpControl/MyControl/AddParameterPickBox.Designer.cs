namespace FreeHttp.FreeHttpControl.MyControl
{
    partial class AddParameterPickBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddParameterPickBox));
            this.cb_ParameterType = new System.Windows.Forms.ComboBox();
            this.cb_ParameterTypeAddition = new System.Windows.Forms.ComboBox();
            this.pb_add = new System.Windows.Forms.PictureBox();
            this.pb_remove = new System.Windows.Forms.PictureBox();
            this.tb_ParameterExpression = new FreeHttp.FreeHttpControl.WatermakTextBox();
            this.tb_ParameterName = new FreeHttp.FreeHttpControl.WatermakTextBox();
            this.cb_pickRange = new System.Windows.Forms.ComboBox();
            this.errorProvider_addParameter = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pb_add)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_remove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_addParameter)).BeginInit();
            this.SuspendLayout();
            // 
            // cb_ParameterType
            // 
            this.cb_ParameterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ParameterType.FormattingEnabled = true;
            this.cb_ParameterType.Items.AddRange(new object[] {
            "Regex",
            "Str",
            "Xml"});
            this.cb_ParameterType.Location = new System.Drawing.Point(124, 3);
            this.cb_ParameterType.Name = "cb_ParameterType";
            this.cb_ParameterType.Size = new System.Drawing.Size(83, 20);
            this.cb_ParameterType.TabIndex = 1;
            this.cb_ParameterType.SelectedIndexChanged += new System.EventHandler(this.cb_ParameterType_SelectedIndexChanged);
            // 
            // cb_ParameterTypeAddition
            // 
            this.cb_ParameterTypeAddition.FormattingEnabled = true;
            this.cb_ParameterTypeAddition.Location = new System.Drawing.Point(210, 3);
            this.cb_ParameterTypeAddition.Name = "cb_ParameterTypeAddition";
            this.cb_ParameterTypeAddition.Size = new System.Drawing.Size(96, 20);
            this.cb_ParameterTypeAddition.TabIndex = 2;
            this.cb_ParameterTypeAddition.SelectedIndexChanged += new System.EventHandler(this.cb_ParameterTypeAddition_SelectedIndexChanged);
            // 
            // pb_add
            // 
            this.pb_add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_add.BackColor = System.Drawing.Color.Transparent;
            this.pb_add.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_add.Image = ((System.Drawing.Image)(resources.GetObject("pb_add.Image")));
            this.pb_add.Location = new System.Drawing.Point(729, 1);
            this.pb_add.Name = "pb_add";
            this.pb_add.Size = new System.Drawing.Size(23, 23);
            this.pb_add.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_add.TabIndex = 57;
            this.pb_add.TabStop = false;
            this.pb_add.Click += new System.EventHandler(this.pb_add_Click);
            this.pb_add.MouseLeave += new System.EventHandler(this.pictureBox_MouseLeave);
            this.pb_add.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            // 
            // pb_remove
            // 
            this.pb_remove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_remove.BackColor = System.Drawing.Color.Transparent;
            this.pb_remove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_remove.Image = ((System.Drawing.Image)(resources.GetObject("pb_remove.Image")));
            this.pb_remove.Location = new System.Drawing.Point(752, 1);
            this.pb_remove.Name = "pb_remove";
            this.pb_remove.Size = new System.Drawing.Size(23, 23);
            this.pb_remove.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_remove.TabIndex = 56;
            this.pb_remove.TabStop = false;
            this.pb_remove.Click += new System.EventHandler(this.pb_remove_Click);
            this.pb_remove.MouseLeave += new System.EventHandler(this.pictureBox_MouseLeave);
            this.pb_remove.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            // 
            // tb_ParameterExpression
            // 
            this.tb_ParameterExpression.Location = new System.Drawing.Point(389, 2);
            this.tb_ParameterExpression.Name = "tb_ParameterExpression";
            this.tb_ParameterExpression.Size = new System.Drawing.Size(336, 21);
            this.tb_ParameterExpression.TabIndex = 3;
            this.tb_ParameterExpression.WatermarkText = null;
            // 
            // tb_ParameterName
            // 
            this.errorProvider_addParameter.SetIconAlignment(this.tb_ParameterName, System.Windows.Forms.ErrorIconAlignment.TopRight);
            this.tb_ParameterName.Location = new System.Drawing.Point(4, 3);
            this.tb_ParameterName.Name = "tb_ParameterName";
            this.tb_ParameterName.Size = new System.Drawing.Size(117, 21);
            this.tb_ParameterName.TabIndex = 0;
            this.tb_ParameterName.WatermarkText = "name";
            // 
            // cb_pickRange
            // 
            this.cb_pickRange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_pickRange.FormattingEnabled = true;
            this.cb_pickRange.Items.AddRange(new object[] {
            "Line",
            "Heads",
            "Entity"});
            this.cb_pickRange.Location = new System.Drawing.Point(309, 3);
            this.cb_pickRange.Name = "cb_pickRange";
            this.cb_pickRange.Size = new System.Drawing.Size(75, 20);
            this.cb_pickRange.TabIndex = 58;
            // 
            // errorProvider_addParameter
            // 
            this.errorProvider_addParameter.ContainerControl = this;
            // 
            // AddParameterPickBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cb_pickRange);
            this.Controls.Add(this.pb_add);
            this.Controls.Add(this.pb_remove);
            this.Controls.Add(this.tb_ParameterExpression);
            this.Controls.Add(this.cb_ParameterTypeAddition);
            this.Controls.Add(this.cb_ParameterType);
            this.Controls.Add(this.tb_ParameterName);
            this.Name = "AddParameterPickBox";
            this.Size = new System.Drawing.Size(777, 26);
            this.Validating += new System.ComponentModel.CancelEventHandler(this.AddParameterPickBox_Validating);
            this.Validated += new System.EventHandler(this.AddParameterPickBox_Validated);
            ((System.ComponentModel.ISupportInitialize)(this.pb_add)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_remove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_addParameter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WatermakTextBox tb_ParameterName;
        private System.Windows.Forms.ComboBox cb_ParameterType;
        private System.Windows.Forms.ComboBox cb_ParameterTypeAddition;
        private WatermakTextBox tb_ParameterExpression;
        private System.Windows.Forms.PictureBox pb_add;
        private System.Windows.Forms.PictureBox pb_remove;
        private System.Windows.Forms.ComboBox cb_pickRange;
        private System.Windows.Forms.ErrorProvider errorProvider_addParameter;
    }
}
