using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FreeHttp.FreeHttpControl
{
    public partial class MyEnableSwitch : UserControl
    {
        public MyEnableSwitch()
        {
            InitializeComponent();
            myResources = new System.ComponentModel.ComponentResourceManager(typeof(MyEnableSwitch));
        }

        System.ComponentModel.ComponentResourceManager myResources;
        private bool isEnable;

        [DescriptionAttribute("the TextBox that you want to binding")]
        /// <summary>
        /// get or set the switch status
        /// </summary>
        public bool IsEnable
        {
            get { return isEnable; }
            set
            {
                isEnable = value;
                pb_switch.Image = isEnable ? ((Image)(myResources.GetObject("switch_on"))) : ((Image)(myResources.GetObject("switch_off")));
            }
        }
    }
}
