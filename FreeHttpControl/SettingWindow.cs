using FreeHttp.FiddlerHelper;
using FreeHttp.HttpHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FreeHttp.FreeHttpControl
{
    public partial class SettingWindow : Form
    {
        public SettingWindow()
        {
            InitializeComponent();
        }

        public SettingWindow(FiddlerModificSettingInfo yourModifcSettingInfo):this()
        {
            modifcSettingInfo = yourModifcSettingInfo;
        }

        private FiddlerModificSettingInfo modifcSettingInfo;

        private void SettingWindow_Load(object sender, EventArgs e)
        {
            if (modifcSettingInfo != null)
            {
                myEnableSwitch_IsOnlyMatchFistTamperRule.IsEnable = modifcSettingInfo.IsOnlyMatchFistTamperRule;
                myEnableSwitch_IsDefaultEnableRule.IsEnable = modifcSettingInfo.IsDefaultEnableRule;
                myEnableSwitch_IsSkipConnectTunnels.IsEnable = modifcSettingInfo.IsSkipConnectTunnels;
                myEnableSwitch_IsOnlyMatchFistTamperRule.OnChangeEnable += myEnableSwitch_IsOnlyMatchFistTamperRule_OnChangeEable;
                myEnableSwitch_IsDefaultEnableRule.OnChangeEnable += myEnableSwitch_IsDefaultEnableRule_OnChangeEable;
                myEnableSwitch_IsSkipConnectTunnels.OnChangeEnable += myEnableSwitch_IsConnectTunnels_OnChangeEable;
            }
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        void myEnableSwitch_IsConnectTunnels_OnChangeEable(object sender, MyEnableSwitch.ChangeEnableEventArgs e)
        {
            modifcSettingInfo.IsSkipConnectTunnels = e.IsEnable;
        }

        void myEnableSwitch_IsDefaultEnableRule_OnChangeEable(object sender, MyEnableSwitch.ChangeEnableEventArgs e)
        {
            modifcSettingInfo.IsDefaultEnableRule = e.IsEnable;
        }

        void myEnableSwitch_IsOnlyMatchFistTamperRule_OnChangeEable(object sender, MyEnableSwitch.ChangeEnableEventArgs e)
        {
            modifcSettingInfo.IsOnlyMatchFistTamperRule = e.IsEnable;
        }
        

    }
}
