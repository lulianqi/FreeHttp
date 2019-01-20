using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;


/*******************************************************************************
* Copyright (c) 2015 lijie
* All rights reserved.
* 
* 文件名称: 
* 内容摘要: mycllq@hotmail.com
* 
* 历史记录:
* 日	  期:   201505016           创建人: 李杰 15158155511
* 描    述: 创建
*******************************************************************************/


namespace FreeHttp.FreeHttpControl
{
    public partial class MyBaseInfoWindow : Form
    {
        private void InitializeComponent()
        {
            this.lb_info = new System.Windows.Forms.Label();
            this.pictureBox_hide = new System.Windows.Forms.PictureBox();
            this.pictureBox_close = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_hide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_close)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_info
            // 
            this.lb_info.AutoSize = true;
            this.lb_info.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_info.ForeColor = System.Drawing.Color.SaddleBrown;
            this.lb_info.Location = new System.Drawing.Point(3, 4);
            this.lb_info.Name = "lb_info";
            this.lb_info.Size = new System.Drawing.Size(111, 13);
            this.lb_info.TabIndex = 12;
            this.lb_info.Text = "CaseParameter";
            // 
            // pictureBox_hide
            // 
            this.pictureBox_hide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_hide.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_hide.Image = global::FreeHttp.Properties.Resources.minimize;
            this.pictureBox_hide.Location = new System.Drawing.Point(344, 3);
            this.pictureBox_hide.Name = "pictureBox_hide";
            this.pictureBox_hide.Size = new System.Drawing.Size(23, 23);
            this.pictureBox_hide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_hide.TabIndex = 13;
            this.pictureBox_hide.TabStop = false;
            this.pictureBox_hide.Click += new System.EventHandler(this.pictureBox_hide_Click);
            this.pictureBox_hide.MouseLeave += new System.EventHandler(this.pictureBox_MouseLeave);
            this.pictureBox_hide.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            // 
            // pictureBox_close
            // 
            this.pictureBox_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_close.Image = global::FreeHttp.Properties.Resources.close;
            this.pictureBox_close.Location = new System.Drawing.Point(373, 3);
            this.pictureBox_close.Name = "pictureBox_close";
            this.pictureBox_close.Size = new System.Drawing.Size(23, 23);
            this.pictureBox_close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_close.TabIndex = 10;
            this.pictureBox_close.TabStop = false;
            this.pictureBox_close.Click += new System.EventHandler(this.pictureBox_close_Click);
            this.pictureBox_close.MouseLeave += new System.EventHandler(this.pictureBox_MouseLeave);
            this.pictureBox_close.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            // 
            // MyBaseInfoWindow
            // 
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(400, 250);
            this.Controls.Add(this.pictureBox_hide);
            this.Controls.Add(this.lb_info);
            this.Controls.Add(this.pictureBox_close);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MyBaseInfoWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MyBaseInfoWindow_FormClosing);
            this.Load += new System.EventHandler(this.myCaseParameter_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MyBaseInfoWindow_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MyBaseInfoWindow_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MyBaseInfoWindow_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_hide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_close)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public MyBaseInfoWindow()
        {
            InitializeComponent();
        }

        private System.Windows.Forms.PictureBox pictureBox_close;
        private System.Windows.Forms.Label lb_info;
        private PictureBox pictureBox_hide;
        private Timer myUpdataTime = new Timer();
        private int intervalTime = 0;

        private string myWindowName = "unknow";
        private bool isShowHideBox = true;

        /// <summary>
        /// 获取或设置自定义窗体名称
        /// </summary>
        [DescriptionAttribute("窗体名称")]
        public string WindowName
        {
            get { return myWindowName; }
            set
            {
                myWindowName =this.Text=lb_info.Text= value; 
            }
        }

        /// <summary>
        /// 获取或设置是否显示最最小化按钮
        /// </summary>
        [Description("是否显示最最小化按钮")]
        public bool IsShowHideBox
        {
            get { return isShowHideBox; }
            set { isShowHideBox = pictureBox_hide.Visible= value; }
        }

        /// <summary>
        /// 获取或设置定时刷新窗体的时间
        /// </summary>
        [Description("获取或设置定时刷新窗体的时间")]
        public int IntervalTime
        {
            get { return intervalTime; }
            set { intervalTime = value; }
        }

        public void myCaseParameter_Load(object sender, EventArgs e)
        {
            pictureBox_hide.Visible = isShowHideBox;
            this.TopMost = false;
            if (IntervalTime > 0)
            {
                myUpdataTime.Interval = IntervalTime;
                myUpdataTime.Enabled = true;
                myUpdataTime.Tick += new EventHandler(myUpdataTime_Tick);
                myUpdataTime.Start();
            }

            lb_info.Text = myWindowName;
            this.Text = myWindowName;
            this.MaximizeBox = false;

            pictureBox_hide.Location = new Point(this.Width - 56, 4);
            pictureBox_close.Location = new Point(this.Width - 27, 4);
            this.Resize += MyChildWindow_Resize;
        }

        void MyChildWindow_Resize(object sender, EventArgs e)
        {
            pictureBox_hide.Location = new Point(this.Width - 56, 4);
            pictureBox_close.Location = new Point(this.Width - 27, 4);
        }

        public void myUpdataTime_Tick(object sender, EventArgs e)
        {
            VirtualUpdataTime_Tick();
        }

        public virtual void VirtualUpdataTime_Tick() 
        {
        }

        private void pictureBox_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox_hide_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //pictureBox change for all
        public void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            ((PictureBox)sender).BackColor = Color.Honeydew;
        }

        //pictureBox change for all
        public void pictureBox_MouseLeave(object sender, EventArgs e)
        {
            ((PictureBox)sender).BackColor = Color.Transparent;
        }


        bool isMoveForm = false;
        Point myFormStartPos = new Point(0, 0);
        Point tempCrtPos = new Point(0, 0);

        private void MyBaseInfoWindow_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMoveForm = true;
                myFormStartPos = new Point(-e.X, -e.Y);//相对当前控件的鼠标位置
                tempCrtPos = PointToScreen(new Point(-this.Location.X,-this.Location.Y)); //控件相对与容器转换为相对于屏幕
            }
        }

        private void MyBaseInfoWindow_MouseUp(object sender, MouseEventArgs e)
        {
            isMoveForm = false;
        }

        private void MyBaseInfoWindow_MouseMove(object sender, MouseEventArgs e)
        {
            
            if (isMoveForm)
            {
                Point nowMousePos = Control.MousePosition;//鼠标光标相对屏幕的位置
                nowMousePos.Offset(myFormStartPos);
                //this.Location = nowMousePos;//相对于父窗体，（如果没有父窗体则可以这样用）
                this.Location = new Point(nowMousePos.X - tempCrtPos.X, nowMousePos.Y - tempCrtPos.Y);
            }
        }

        private void MyBaseInfoWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
             myUpdataTime.Tick -= new EventHandler(myUpdataTime_Tick);
        }

       


    }
}
