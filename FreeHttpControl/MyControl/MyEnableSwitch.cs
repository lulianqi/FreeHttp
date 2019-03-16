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

        public class ChangeEnableEventArgs:EventArgs
        {
            public bool IsEnable{get; set;}
            public ChangeEnableEventArgs(bool isEnable)
            {
                IsEnable = isEnable;
            }
        }

        

        public MyEnableSwitch()
        {
            InitializeComponent();
            myResources = new System.ComponentModel.ComponentResourceManager(typeof(MyEnableSwitch));
        }

        System.ComponentModel.ComponentResourceManager myResources;
        private bool isEnable;
        public event EventHandler<ChangeEnableEventArgs> OnChangeEnable;

        [DescriptionAttribute("the TextBox that you want to binding")]
        /// <summary>
        /// get or set the switch status (set thie value will not call OnChangeEnable)
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

        private void pb_switch_Click(object sender, EventArgs e)
        {
            IsEnable = !IsEnable;
            if(OnChangeEnable!=null)
            {
                this.OnChangeEnable(this, new ChangeEnableEventArgs(IsEnable));
            }
        }
    }
}
