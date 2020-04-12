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
    class MyEnabledPictureButton : PictureBox
    {
        public MyEnabledPictureButton()
        {
            //this.MouseMove += pictureBox_MouseMove;
            //this.MouseLeave += pictureBox_MouseLeave;
            this.Cursor = Cursors.Hand;
            this.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        /// <summary>
        /// 不可用时显示的图片
        /// </summary>
        [DescriptionAttribute("")]
        public Image DisEnabledImage { get; set; }


        private Image enabledImage;

        /// <summary>
        /// 可用时显示的图片
        /// </summary>
        [DescriptionAttribute("")]
        public Image EnabledImage { get { return enabledImage; } set { enabledImage =this.Image = value; } }

        public new bool Enabled
        {
            get { return base.Enabled; }
            set
            {
                base.Enabled = value;
                if(base.Enabled )
                {
                    if(EnabledImage!=null)
                    {
                        this.Image = EnabledImage;
                    }
                    this.Cursor = Cursors.Hand;
                }
                else
                {
                    if (DisEnabledImage != null)
                    {
                        this.Image = DisEnabledImage;
                    }
                    this.Cursor = Cursors.No;
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
