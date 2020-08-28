using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FreeHttp.FreeHttpControl
{
    public partial class RuleInfoWindow : CBalloon.CBalloonBase
    {

        public RuleInfoWindow(ListViewItem yourListViewItem)
        {
            InitializeComponent();
            myListViewItem = yourListViewItem;
            timer = new Timer();
            timer.Interval = 200;
            timer.Tick += Timer_Tick;
        }

        

        //RichTextBox rtb_errorList = new RichTextBox();
        //rtb_errorList.AppendText("test");
        //rtb_errorList.Dock = DockStyle.Fill;
        //this.Controls.Add(rtb_errorList);

        ListViewItem myListViewItem;
        Timer timer;
        Rectangle lastRectangle ;


        private void analyzeCaseData()
        {
           
        }


        private void MyCBalloon_Load(object sender, EventArgs e)
        {
            analyzeCaseData();
            if (myListViewItem != null)
            {
                lastRectangle = myListViewItem.Bounds;
                timer.Start();
            }
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            if(lastRectangle != myListViewItem.Bounds)
            {
                lastRectangle = myListViewItem.Bounds;
                Form mainForm = this.Owner.Owner;
                Point myPosition = new Point(myListViewItem.Bounds.X, myListViewItem.Bounds.Y);
                myPosition = myListViewItem.ListView.PointToScreen(myPosition);
                myPosition = mainForm.PointToClient(myPosition);
                myPosition.Offset(40, 10);
                this.setBalloonPosition(mainForm, myPosition);
            }
        }

        private void pictureBox_close_Click(object sender, EventArgs e)
        {
            this.Owner.Activate();
            this.Close();
        }

        private void llb_errorInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
        }


    }
}
