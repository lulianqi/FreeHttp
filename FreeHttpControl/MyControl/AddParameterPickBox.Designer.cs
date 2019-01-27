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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddParameterPickBox));
            this.tb_ParameterName = new FreeHttp.FreeHttpControl.WatermakTextBox();
            this.cb_ParameterType = new System.Windows.Forms.ComboBox();
            this.cb_ParameterTypeAddition = new System.Windows.Forms.ComboBox();
            this.tb_ParameterExpression = new FreeHttp.FreeHttpControl.WatermakTextBox();
            this.tb_ParameterExpressionAddition = new FreeHttp.FreeHttpControl.WatermakTextBox();
            this.pb_add = new System.Windows.Forms.PictureBox();
            this.pb_remove = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_add)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_remove)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_ParameterName
            // 
            this.tb_ParameterName.Location = new System.Drawing.Point(4, 3);
            this.tb_ParameterName.Name = "tb_ParameterName";
            this.tb_ParameterName.Size = new System.Drawing.Size(117, 21);
            this.tb_ParameterName.TabIndex = 0;
            this.tb_ParameterName.WatermarkText = null;
            // 
            // cb_ParameterType
            // 
            this.cb_ParameterType.FormattingEnabled = true;
            this.cb_ParameterType.Location = new System.Drawing.Point(125, 4);
            this.cb_ParameterType.Name = "cb_ParameterType";
            this.cb_ParameterType.Size = new System.Drawing.Size(108, 20);
            this.cb_ParameterType.TabIndex = 1;
            // 
            // cb_ParameterTypeAddition
            // 
            this.cb_ParameterTypeAddition.FormattingEnabled = true;
            this.cb_ParameterTypeAddition.Location = new System.Drawing.Point(236, 3);
            this.cb_ParameterTypeAddition.Name = "cb_ParameterTypeAddition";
            this.cb_ParameterTypeAddition.Size = new System.Drawing.Size(141, 20);
            this.cb_ParameterTypeAddition.TabIndex = 2;
            // 
            // tb_ParameterExpression
            // 
            this.tb_ParameterExpression.Location = new System.Drawing.Point(381, 2);
            this.tb_ParameterExpression.Name = "tb_ParameterExpression";
            this.tb_ParameterExpression.Size = new System.Drawing.Size(172, 21);
            this.tb_ParameterExpression.TabIndex = 3;
            this.tb_ParameterExpression.WatermarkText = null;
            // 
            // tb_ParameterExpressionAddition
            // 
            this.tb_ParameterExpressionAddition.Location = new System.Drawing.Point(558, 2);
            this.tb_ParameterExpressionAddition.Name = "tb_ParameterExpressionAddition";
            this.tb_ParameterExpressionAddition.Size = new System.Drawing.Size(172, 21);
            this.tb_ParameterExpressionAddition.TabIndex = 4;
            this.tb_ParameterExpressionAddition.WatermarkText = null;
            // 
            // pb_add
            // 
            this.pb_add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_add.BackColor = System.Drawing.Color.Transparent;
            this.pb_add.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_add.Image = ((System.Drawing.Image)(resources.GetObject("pb_add.Image")));
            this.pb_add.Location = new System.Drawing.Point(734, 1);
            this.pb_add.Name = "pb_add";
            this.pb_add.Size = new System.Drawing.Size(23, 23);
            this.pb_add.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_add.TabIndex = 57;
            this.pb_add.TabStop = false;
            // 
            // pb_remove
            // 
            this.pb_remove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_remove.BackColor = System.Drawing.Color.Transparent;
            this.pb_remove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_remove.Image = ((System.Drawing.Image)(resources.GetObject("pb_remove.Image")));
            this.pb_remove.Location = new System.Drawing.Point(757, 1);
            this.pb_remove.Name = "pb_remove";
            this.pb_remove.Size = new System.Drawing.Size(23, 23);
            this.pb_remove.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_remove.TabIndex = 56;
            this.pb_remove.TabStop = false;
            // 
            // AddParameterPickBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pb_add);
            this.Controls.Add(this.pb_remove);
            this.Controls.Add(this.tb_ParameterExpressionAddition);
            this.Controls.Add(this.tb_ParameterExpression);
            this.Controls.Add(this.cb_ParameterTypeAddition);
            this.Controls.Add(this.cb_ParameterType);
            this.Controls.Add(this.tb_ParameterName);
            this.Name = "AddParameterPickBox";
            this.Size = new System.Drawing.Size(782, 26);
            ((System.ComponentModel.ISupportInitialize)(this.pb_add)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_remove)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WatermakTextBox tb_ParameterName;
        private System.Windows.Forms.ComboBox cb_ParameterType;
        private System.Windows.Forms.ComboBox cb_ParameterTypeAddition;
        private WatermakTextBox tb_ParameterExpression;
        private WatermakTextBox tb_ParameterExpressionAddition;
        private System.Windows.Forms.PictureBox pb_add;
        private System.Windows.Forms.PictureBox pb_remove;
    }
}
