
namespace FreeHttp.FreeHttpControl
{
    partial class SaveShareRule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaveShareRule));
            this.rb_updataRule = new System.Windows.Forms.RadioButton();
            this.rb_newRule = new System.Windows.Forms.RadioButton();
            this.comboBox_yourRule = new System.Windows.Forms.ComboBox();
            this.ck_parameterData = new System.Windows.Forms.CheckBox();
            this.bt_save = new System.Windows.Forms.Button();
            this.wtb_ruleRemark = new FreeHttp.FreeHttpControl.WatermakTextBox();
            this.SuspendLayout();
            // 
            // rb_updataRule
            // 
            this.rb_updataRule.AutoSize = true;
            this.rb_updataRule.Location = new System.Drawing.Point(10, 23);
            this.rb_updataRule.Name = "rb_updataRule";
            this.rb_updataRule.Size = new System.Drawing.Size(125, 16);
            this.rb_updataRule.TabIndex = 0;
            this.rb_updataRule.Text = "updata share rule";
            this.rb_updataRule.UseVisualStyleBackColor = true;
            // 
            // rb_newRule
            // 
            this.rb_newRule.AutoSize = true;
            this.rb_newRule.Checked = true;
            this.rb_newRule.Location = new System.Drawing.Point(10, 54);
            this.rb_newRule.Name = "rb_newRule";
            this.rb_newRule.Size = new System.Drawing.Size(149, 16);
            this.rb_newRule.TabIndex = 1;
            this.rb_newRule.TabStop = true;
            this.rb_newRule.Text = "create new share rule";
            this.rb_newRule.UseVisualStyleBackColor = true;
            this.rb_newRule.CheckedChanged += new System.EventHandler(this.rb_newRule_CheckedChanged);
            // 
            // comboBox_yourRule
            // 
            this.comboBox_yourRule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_yourRule.FormattingEnabled = true;
            this.comboBox_yourRule.Items.AddRange(new object[] {
            "Please share a set of rules first"});
            this.comboBox_yourRule.Location = new System.Drawing.Point(157, 21);
            this.comboBox_yourRule.Name = "comboBox_yourRule";
            this.comboBox_yourRule.Size = new System.Drawing.Size(287, 20);
            this.comboBox_yourRule.TabIndex = 24;
            // 
            // ck_parameterData
            // 
            this.ck_parameterData.AutoSize = true;
            this.ck_parameterData.Checked = true;
            this.ck_parameterData.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ck_parameterData.Location = new System.Drawing.Point(10, 91);
            this.ck_parameterData.Name = "ck_parameterData";
            this.ck_parameterData.Size = new System.Drawing.Size(156, 16);
            this.ck_parameterData.TabIndex = 26;
            this.ck_parameterData.Text = " updata parameter data";
            this.ck_parameterData.UseVisualStyleBackColor = true;
            // 
            // bt_save
            // 
            this.bt_save.Location = new System.Drawing.Point(367, 88);
            this.bt_save.Name = "bt_save";
            this.bt_save.Size = new System.Drawing.Size(75, 23);
            this.bt_save.TabIndex = 27;
            this.bt_save.Text = "confirm";
            this.bt_save.UseVisualStyleBackColor = true;
            this.bt_save.Click += new System.EventHandler(this.bt_save_Click);
            // 
            // wtb_ruleRemark
            // 
            this.wtb_ruleRemark.Location = new System.Drawing.Point(157, 52);
            this.wtb_ruleRemark.Name = "wtb_ruleRemark";
            this.wtb_ruleRemark.Size = new System.Drawing.Size(287, 21);
            this.wtb_ruleRemark.TabIndex = 25;
            this.wtb_ruleRemark.WatermarkText = "please enter comment name";
            // 
            // SaveShareRule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 119);
            this.Controls.Add(this.bt_save);
            this.Controls.Add(this.ck_parameterData);
            this.Controls.Add(this.wtb_ruleRemark);
            this.Controls.Add(this.comboBox_yourRule);
            this.Controls.Add(this.rb_newRule);
            this.Controls.Add(this.rb_updataRule);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SaveShareRule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SaveShareRule";
            this.Load += new System.EventHandler(this.SaveShareRule_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rb_updataRule;
        private System.Windows.Forms.RadioButton rb_newRule;
        private System.Windows.Forms.ComboBox comboBox_yourRule;
        private WatermakTextBox wtb_ruleRemark;
        private System.Windows.Forms.CheckBox ck_parameterData;
        private System.Windows.Forms.Button bt_save;
    }
}