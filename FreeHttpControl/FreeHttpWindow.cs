using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FreeHttp.FreeHttpControl
{
    public partial class FreeHttpWindow : UserControl
    {
        public FreeHttpWindow()
        {
            InitializeComponent();
        }

        private void FreeHttpWindow_Load(object sender, EventArgs e)
        {
            cb_macthMode.SelectedIndex = 0;
        }


        #region Public Event
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

        private void tabControl_Modific_Resize(object sender, EventArgs e)
        {
            //tabPage_requestModific
            groupBox_headsModific.Width = tabControl_Modific.Width - 20;
            requestRemoveHeads.Width = (groupBox_headsModific.Width - 10) / 3;
            requestAddHeads.Width = (groupBox_headsModific.Width - 10) * 2 / 3;
        }
        #endregion

        
    }
}
