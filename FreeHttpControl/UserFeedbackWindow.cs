//#define NET4_5UP
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
        FreeHttpWindow mainWindow;
        public UserFeedbackWindow(FreeHttpWindow freeHttpWindow)
        {
            InitializeComponent();
            mainWindow = freeHttpWindow;
        }

        private void Llb_gotoGitHub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/lulianqi/FreeHttp/issues");
        }

        private void Bt_ok_Click(object sender, EventArgs e)
        {
            if(rtb_feedbackContent.Text=="")
            {
                MessageBox.Show("Please enter content", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

#if NET4_5UP
            Task<int> submitFeedback = WebService.FeedbackService.SubmitFeedbackAsync(WebService.UserComputerInfo.GetComputerMac(), watermakTextBox_contactInfo.Text, rtb_feedbackContent.Text);
            submitFeedback.ContinueWith((task) => { if (mainWindow == null) return;  if (!(task.Result == 200 || task.Result ==201)) { mainWindow.PutError(string.Format("submit feedback fial with {0}", task.Result)); } else { mainWindow.PutInfo("submit feedback succeed"); } });
#endif

#if NET4
            WebService.FeedbackService.SubmitFeedbackTask(WebService.UserComputerInfo.GetComputerMac(), watermakTextBox_contactInfo.Text, rtb_feedbackContent.Text,new Action<int>((code) => { if (mainWindow == null) return; if (!(code == 200 || code ==201)) { mainWindow.PutError(string.Format("submit feedback fial with {0}", code)); } else { mainWindow.PutInfo("submit feedback succeed"); } }));
#endif
            this.Close();
        }

    }
}
