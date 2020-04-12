using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FreeHttp.FreeHttpControl
{
    class MySwitchPictureButton : PictureBox
    {
        public MySwitchPictureButton()
        {
            //this.MouseMove += pictureBox_MouseMove;
            //this.MouseLeave += pictureBox_MouseLeave;
            this.Cursor = Cursors.Hand;
            this.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        /// <summary>
        /// 备用状态显示的图片
        /// </summary>
        [DescriptionAttribute("")]
        public Image SwitchOffImage { get; set; }


        private Image switchOnImage;

        /// <summary>
        /// 主要状态显示的图片
        /// </summary>
        [DescriptionAttribute("")]
        public Image SwitchOnImage { get { return switchOnImage; } set { switchOnImage = this.switchOnImage = value; } }

        private bool switchState = true;

        public bool SwitchState
        {
            get { return switchState; }
            set
            {
                switchState = value;
                if(switchState)
                {
                    if(SwitchOnImage!=null)
                    {
                        this.Image = SwitchOnImage;
                    }
                }
                else
                {
                    if (SwitchOffImage != null)
                    {
                        this.Image = SwitchOffImage;
                    }
                }
            }
        }


        protected override void OnMouseMove(MouseEventArgs e)
        {
            pictureBox_MouseMove(this, e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            pictureBox_MouseLeave(this, e);
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

    }
}
