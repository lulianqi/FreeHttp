using FreeHttp.FiddlerHelper;
using FreeHttp.WebService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static FreeHttp.WebService.RemoteRuleService;

namespace FreeHttp.FreeHttpControl
{
    public partial class GetRemoteRuleWindow : Form
    {
        FreeHttpWindow mainWindow;
        RuleInfoWindow myListViewCBallon;
        RuleDetails nowRuleDetails;
        public GetRemoteRuleWindow(FreeHttpWindow freeHttpWindow)
        {
            InitializeComponent();
            mainWindow = freeHttpWindow;
            lv_remote_requestRuleList.SmallImageList = mainWindow.imageList_forTab;
            lv_remote_responseRuleList.SmallImageList = mainWindow.imageList_forTab;
        }

        private void GetRemoteRuleWindowAddRuleToListView(ListView yourListViews, IFiddlerHttpTamper yourHttpTamper)
        {

            int tempListViewItemImageIndex = yourHttpTamper.TamperProtocol == TamperProtocalType.WebSocket ? 4 : yourHttpTamper.IsRawReplace ? 1 : 0;
            ListViewItem nowRuleItem = new ListViewItem(new string[] { (yourListViews.Items.Count + 1).ToString(), yourHttpTamper.HttpFilter?.GetShowTitle() ?? "" }, tempListViewItemImageIndex);
            nowRuleItem.Tag = yourHttpTamper;
            nowRuleItem.ToolTipText = yourHttpTamper.HttpFilter.ToString();
            nowRuleItem.Checked = yourHttpTamper.IsEnable;
            yourListViews.Items.Add(nowRuleItem);
          
        }

        private void ClearRemoteRule()
        {
            if (myListViewCBallon != null)
            {
                myListViewCBallon.Close();
            }
            lv_remote_requestRuleList.Items.Clear();
            lv_remote_responseRuleList.Items.Clear();
            lb_info_2.Text = "";
            nowRuleDetails = null;
        }

        private void bt_getRule_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(watermakTextBox_ruleToken.Text))
                {
                    MessageBox.Show("just input your rule token", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                ClearRemoteRule();
                System.Threading.Tasks.Task<RuleDetails> ruleTask = System.Threading.Tasks.Task.Run(new Func<RuleDetails>(() =>
                {
                //6077f8fa617545cb9fbf12b1c874f7ee
                return WebService.RemoteRuleService.GetRemoteRuleAsync(watermakTextBox_ruleToken.Text).GetAwaiter().GetResult();
                }));
                RuleDetails ruleDetails = ruleTask.GetAwaiter().GetResult();
                if (ruleDetails == null)
                {
                    MessageBox.Show("your rule token is not permitted", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                if (ruleDetails.ModificHttpRuleCollection == null || ((ruleDetails.ModificHttpRuleCollection.RequestRuleList == null || ruleDetails.ModificHttpRuleCollection.RequestRuleList.Count == 0) && (ruleDetails.ModificHttpRuleCollection.ResponseRuleList == null || ruleDetails.ModificHttpRuleCollection.ResponseRuleList.Count == 0)))
                {
                    MessageBox.Show("can not find any rule in your storage spaces", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                //this.Height = 560;
                foreach (var tempRule in ruleDetails.ModificHttpRuleCollection.RequestRuleList)
                {
                    GetRemoteRuleWindowAddRuleToListView(lv_remote_requestRuleList, tempRule);
                }
                foreach (var tempRule in ruleDetails.ModificHttpRuleCollection.ResponseRuleList)
                {
                    GetRemoteRuleWindowAddRuleToListView(lv_remote_responseRuleList, tempRule);
                }
                lb_info_2.Text = string.Format("Get RequestRule:{0} ; ResponseRule:{1} ; StaticData:{2}", ruleDetails.ModificHttpRuleCollection.RequestRuleList.Count, ruleDetails.ModificHttpRuleCollection.ResponseRuleList.Count, ruleDetails.StaticDataCollection?.Count??0);
                nowRuleDetails = ruleDetails;
            }
            catch(Exception ex)
            {
                _ = RemoteLogService.ReportLogAsync(ex.ToString(), RemoteLogService.RemoteLogOperation.RemoteRule, RemoteLogService.RemoteLogType.Error);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
        private void lv_remote_ruleList_MouseDoubleClick(object sender, EventArgs e)
        {
            if ((sender as ListView)?.SelectedItems.Count == 0) return;
            ListViewItem nowListViewItem = (sender as ListView)?.SelectedItems[0];
            if (nowListViewItem == null) return;
            Point myPosition = new Point(nowListViewItem.Bounds.X, nowListViewItem.Bounds.Y);
            myPosition = nowListViewItem.ListView.PointToScreen(myPosition);
            myPosition = this.PointToClient(myPosition);
            myPosition.Offset(30, 10);
            if(myListViewCBallon!=null)
            {
                myListViewCBallon.Close();
            }
            myListViewCBallon = new RuleInfoWindow(nowListViewItem);
            myListViewCBallon.Owner = this;
            myListViewCBallon.HasShadow = true;
            myListViewCBallon.setBalloonPosition(this, myPosition, new Size(0, 0));
            myListViewCBallon.Show();
            myListViewCBallon.UpdateBalloonPosition(myPosition);
        }

        private void GetRemoteRuleWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (myListViewCBallon != null)
            {
                myListViewCBallon.Close();
            }
        }

        private void bt_replaceRule_Click(object sender, EventArgs e)
        {
            if(nowRuleDetails==null)
            {
                MessageBox.Show("please get remore rule first", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            mainWindow.ReplaceRuleStorage(nowRuleDetails);
            this.Close();
        }
    }
}
