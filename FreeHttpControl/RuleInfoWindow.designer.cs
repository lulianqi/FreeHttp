namespace FreeHttp.FreeHttpControl
{
    partial class RuleInfoWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RuleInfoWindow));
            this.pictureBox_close = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lb_caseId = new System.Windows.Forms.Label();
            this.gb_content = new System.Windows.Forms.GroupBox();
            this.rtb_Content = new System.Windows.Forms.RichTextBox();
            this.lb_delay = new System.Windows.Forms.Label();
            this.lb_protocol = new System.Windows.Forms.Label();
            this.gb_assert = new System.Windows.Forms.GroupBox();
            this.tb_expectContent = new System.Windows.Forms.TextBox();
            this.gb_action = new System.Windows.Forms.GroupBox();
            this.listView_action = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lb_expectType = new System.Windows.Forms.Label();
            this.listView_parameterSave = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lb_level = new System.Windows.Forms.Label();
            this.gb_parameterSave = new System.Windows.Forms.GroupBox();
            this.llb_errorInfo = new System.Windows.Forms.LinkLabel();
            this.lb_caseTarget = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_close)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gb_content.SuspendLayout();
            this.gb_assert.SuspendLayout();
            this.gb_action.SuspendLayout();
            this.gb_parameterSave.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox_close
            // 
            this.pictureBox_close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_close.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_close.Image")));
            this.pictureBox_close.Location = new System.Drawing.Point(744, 33);
            this.pictureBox_close.Name = "pictureBox_close";
            this.pictureBox_close.Size = new System.Drawing.Size(20, 20);
            this.pictureBox_close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_close.TabIndex = 2;
            this.pictureBox_close.TabStop = false;
            this.pictureBox_close.Click += new System.EventHandler(this.pictureBox_close_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(721, 33);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // lb_caseId
            // 
            this.lb_caseId.AutoSize = true;
            this.lb_caseId.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_caseId.ForeColor = System.Drawing.Color.RosyBrown;
            this.lb_caseId.Location = new System.Drawing.Point(38, 33);
            this.lb_caseId.Name = "lb_caseId";
            this.lb_caseId.Size = new System.Drawing.Size(62, 16);
            this.lb_caseId.TabIndex = 8;
            this.lb_caseId.Text = "caseId";
            // 
            // gb_content
            // 
            this.gb_content.Controls.Add(this.rtb_Content);
            this.gb_content.Location = new System.Drawing.Point(411, 59);
            this.gb_content.Name = "gb_content";
            this.gb_content.Size = new System.Drawing.Size(353, 155);
            this.gb_content.TabIndex = 10;
            this.gb_content.TabStop = false;
            this.gb_content.Text = "Content";
            // 
            // rtb_Content
            // 
            this.rtb_Content.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtb_Content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_Content.Location = new System.Drawing.Point(3, 17);
            this.rtb_Content.Name = "rtb_Content";
            this.rtb_Content.Size = new System.Drawing.Size(347, 135);
            this.rtb_Content.TabIndex = 0;
            this.rtb_Content.Text = "";
            // 
            // lb_delay
            // 
            this.lb_delay.AutoSize = true;
            this.lb_delay.Location = new System.Drawing.Point(43, 91);
            this.lb_delay.Name = "lb_delay";
            this.lb_delay.Size = new System.Drawing.Size(35, 12);
            this.lb_delay.TabIndex = 11;
            this.lb_delay.Text = "delay";
            // 
            // lb_protocol
            // 
            this.lb_protocol.AutoSize = true;
            this.lb_protocol.Location = new System.Drawing.Point(43, 72);
            this.lb_protocol.Name = "lb_protocol";
            this.lb_protocol.Size = new System.Drawing.Size(53, 12);
            this.lb_protocol.TabIndex = 13;
            this.lb_protocol.Text = "protocol";
            // 
            // gb_assert
            // 
            this.gb_assert.Controls.Add(this.tb_expectContent);
            this.gb_assert.Controls.Add(this.gb_action);
            this.gb_assert.Controls.Add(this.lb_expectType);
            this.gb_assert.Location = new System.Drawing.Point(205, 59);
            this.gb_assert.Name = "gb_assert";
            this.gb_assert.Size = new System.Drawing.Size(200, 155);
            this.gb_assert.TabIndex = 14;
            this.gb_assert.TabStop = false;
            this.gb_assert.Text = "Assert ";
            // 
            // tb_expectContent
            // 
            this.tb_expectContent.Location = new System.Drawing.Point(5, 31);
            this.tb_expectContent.Name = "tb_expectContent";
            this.tb_expectContent.Size = new System.Drawing.Size(190, 21);
            this.tb_expectContent.TabIndex = 5;
            // 
            // gb_action
            // 
            this.gb_action.Controls.Add(this.listView_action);
            this.gb_action.Location = new System.Drawing.Point(4, 50);
            this.gb_action.Name = "gb_action";
            this.gb_action.Size = new System.Drawing.Size(190, 104);
            this.gb_action.TabIndex = 4;
            this.gb_action.TabStop = false;
            this.gb_action.Text = "Action";
            // 
            // listView_action
            // 
            this.listView_action.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6});
            this.listView_action.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_action.HideSelection = false;
            this.listView_action.Location = new System.Drawing.Point(3, 17);
            this.listView_action.Name = "listView_action";
            this.listView_action.Size = new System.Drawing.Size(184, 84);
            this.listView_action.TabIndex = 5;
            this.listView_action.UseCompatibleStateImageBehavior = false;
            this.listView_action.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Result";
            this.columnHeader5.Width = 50;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "ActionDescription";
            this.columnHeader6.Width = 115;
            // 
            // lb_expectType
            // 
            this.lb_expectType.AutoSize = true;
            this.lb_expectType.Location = new System.Drawing.Point(8, 16);
            this.lb_expectType.Name = "lb_expectType";
            this.lb_expectType.Size = new System.Drawing.Size(65, 12);
            this.lb_expectType.TabIndex = 1;
            this.lb_expectType.Text = "ExpectType";
            // 
            // listView_parameterSave
            // 
            this.listView_parameterSave.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.listView_parameterSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_parameterSave.HideSelection = false;
            this.listView_parameterSave.Location = new System.Drawing.Point(3, 17);
            this.listView_parameterSave.Name = "listView_parameterSave";
            this.listView_parameterSave.Size = new System.Drawing.Size(153, 69);
            this.listView_parameterSave.TabIndex = 4;
            this.listView_parameterSave.UseCompatibleStateImageBehavior = false;
            this.listView_parameterSave.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "name";
            this.columnHeader3.Width = 53;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "value";
            this.columnHeader4.Width = 75;
            // 
            // lb_level
            // 
            this.lb_level.AutoSize = true;
            this.lb_level.Location = new System.Drawing.Point(44, 110);
            this.lb_level.Name = "lb_level";
            this.lb_level.Size = new System.Drawing.Size(35, 12);
            this.lb_level.TabIndex = 15;
            this.lb_level.Text = "level";
            // 
            // gb_parameterSave
            // 
            this.gb_parameterSave.Controls.Add(this.listView_parameterSave);
            this.gb_parameterSave.Location = new System.Drawing.Point(40, 125);
            this.gb_parameterSave.Name = "gb_parameterSave";
            this.gb_parameterSave.Size = new System.Drawing.Size(159, 89);
            this.gb_parameterSave.TabIndex = 16;
            this.gb_parameterSave.TabStop = false;
            this.gb_parameterSave.Text = "ParameterSave";
            // 
            // llb_errorInfo
            // 
            this.llb_errorInfo.ActiveLinkColor = System.Drawing.Color.DimGray;
            this.llb_errorInfo.AutoSize = true;
            this.llb_errorInfo.LinkColor = System.Drawing.Color.Red;
            this.llb_errorInfo.Location = new System.Drawing.Point(45, 56);
            this.llb_errorInfo.Name = "llb_errorInfo";
            this.llb_errorInfo.Size = new System.Drawing.Size(101, 12);
            this.llb_errorInfo.TabIndex = 17;
            this.llb_errorInfo.TabStop = true;
            this.llb_errorInfo.Text = "含有错误点击查看";
            this.llb_errorInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llb_errorInfo_LinkClicked);
            // 
            // lb_caseTarget
            // 
            this.lb_caseTarget.AutoSize = true;
            this.lb_caseTarget.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_caseTarget.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.lb_caseTarget.Location = new System.Drawing.Point(212, 33);
            this.lb_caseTarget.Name = "lb_caseTarget";
            this.lb_caseTarget.Size = new System.Drawing.Size(98, 16);
            this.lb_caseTarget.TabIndex = 18;
            this.lb_caseTarget.Text = "caseTarget";
            // 
            // RuleInfoWindow
            // 
            this.ClientSize = new System.Drawing.Size(800, 250);
            this.Controls.Add(this.lb_caseTarget);
            this.Controls.Add(this.llb_errorInfo);
            this.Controls.Add(this.gb_parameterSave);
            this.Controls.Add(this.lb_level);
            this.Controls.Add(this.gb_assert);
            this.Controls.Add(this.lb_protocol);
            this.Controls.Add(this.lb_delay);
            this.Controls.Add(this.gb_content);
            this.Controls.Add(this.lb_caseId);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox_close);
            this.FrameBottomRight = System.Drawing.Color.Cyan;
            this.FrameTopLeft = System.Drawing.Color.SkyBlue;
            this.Name = "RuleInfoWindow";
            this.Load += new System.EventHandler(this.MyCBalloon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_close)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gb_content.ResumeLayout(false);
            this.gb_assert.ResumeLayout(false);
            this.gb_assert.PerformLayout();
            this.gb_action.ResumeLayout(false);
            this.gb_parameterSave.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_close;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lb_caseId;
        private System.Windows.Forms.GroupBox gb_content;
        private System.Windows.Forms.Label lb_delay;
        private System.Windows.Forms.Label lb_protocol;
        private System.Windows.Forms.GroupBox gb_assert;
        private System.Windows.Forms.Label lb_expectType;
        private System.Windows.Forms.ListView listView_parameterSave;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label lb_level;
        private System.Windows.Forms.GroupBox gb_parameterSave;
        private System.Windows.Forms.GroupBox gb_action;
        private System.Windows.Forms.TextBox tb_expectContent;
        private System.Windows.Forms.ListView listView_action;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.LinkLabel llb_errorInfo;
        private System.Windows.Forms.RichTextBox rtb_Content;
        private System.Windows.Forms.Label lb_caseTarget;
    }
}
