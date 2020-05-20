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
            this.Cursor = Cursors.Hand;
            this.SizeMode = PictureBoxSizeMode.StretchImage;
            //if(IsAutoChangeSwitchState)
            //{
            //    this.Click += (sender, e) => { SwitchState = !SwitchState; };
            //}
        }

       

        [DescriptionAttribute("Is auto change switchState when click")]
        public bool IsAutoChangeSwitchState { get; set; } = false;

        /// <summary>
        /// 备用状态显示的图片
        /// </summary>
        [DescriptionAttribute("Image when switchState is false")]
        public Image SwitchOffImage { get; set; }


        private Image switchOnImage;

        /// <summary>
        /// 主要状态显示的图片
        /// </summary>
        [DescriptionAttribute("Image when switchState is true")]
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

        protected override void OnClick(EventArgs e)
        {
            if (IsAutoChangeSwitchState)
            {
                SwitchState = !SwitchState;
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
