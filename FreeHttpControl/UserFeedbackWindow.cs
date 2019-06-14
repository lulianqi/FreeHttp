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
    public partial class UserFeedbackWindow : Form
    {
        class Feedback
        {
            public string user_mac { get; set; }
            public string contact_infomation { get; set; }
            public string feedback_content { get; set; }

        }

        public UserFeedbackWindow()
        {
            InitializeComponent();
        }

        private void Llb_gotoGitHub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/lulianqi/FreeHttp/issues");
        }

        private void Bt_ok_Click(object sender, EventArgs e)
        {
            var temp = rtb_feedbackContent.Text;
            var x = Fiddler.WebFormats.JSON.JsonEncode(new Feedback() { "q","e",""});
            //Task<string> checkUpgradeTask = new Task<string>(() =>
            //{
            //    Fiddler.WebFormats.JSON j= new Fiddler.WebFormats.JSON()
            //    string tempResponse = (new WebService.MyWebTool.MyHttp()).SendData(string.Format(@"https://api.lulianqi.com/UpdateCheck/v1.1?user={0}", UserComputerInfo.GetComputerMac()));
            //    string isNeedUpdata = FreeHttp.AutoTest.ParameterizationPick.ParameterPickHelper.PickStrParameter("\"isNeedUpdata\":", ",", tempResponse);
            //    string url = FreeHttp.AutoTest.ParameterizationPick.ParameterPickHelper.PickStrParameter("\"url\":", ",", tempResponse);
            //    string message = FreeHttp.AutoTest.ParameterizationPick.ParameterPickHelper.PickStrParameter("\"message\":", ",", tempResponse);
            //    if (string.IsNullOrEmpty(isNeedUpdata))
            //    {
            //        return new UpgradeServiceEventArgs(false, null);
            //    }
            //    if (isNeedUpdata == "true")
            //    {
            //        return new UpgradeServiceEventArgs(true, url);
            //    }
            //    return null;
            //});
            //checkUpgradeTask.Start();
            //checkUpgradeTask.ContinueWith((task) => { if (checkUpgradeTask.Result != null) this.GetUpgradeMes(this, checkUpgradeTask.Result); });
        }
    }
}
