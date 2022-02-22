using FreeHttp.AutoTest.RunTimeStaticData;
using FreeHttp.FiddlerHelper;
using FreeHttp.FreeHttpControl.ControlHelper;
using FreeHttp.WebService;
using FreeHttp.WebService.DataModel;
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
    public partial class GetRemoteRuleWindow : MyBaseInfoWindow
    {
        public enum ShowRuleCollectionType
        {
            RemoteRule = 0,
            SharedRule = 1,
            LocalRule = 2
        }

        FreeHttpWindow mainWindow;
        ShareRuleService shareRuleService;
        RuleInfoWindow myListViewCBallon;
        RuleDetails localRuleDetails;
        RuleDetails nowRuleDetails;
        LoadWindowService loadWindowService;

        private ShowRuleCollectionType nowShowType = ShowRuleCollectionType.RemoteRule;
        private Point lv_requestRuleOriginLocation = new Point(2, 72);
        private Point lv_responseRuleOriginLocation = new Point(2, 293);
        private int lv_requestRuleOriginHeight = 220;
        private int lv_requestRuleOriginWidth = 626;


        public GetRemoteRuleWindow(FreeHttpWindow freeHttpWindow , ShowRuleCollectionType expectType= ShowRuleCollectionType.RemoteRule)
        {
            InitializeComponent();
            nowShowType = expectType;
            mainWindow = freeHttpWindow;
            lv_remote_requestRuleList.SmallImageList = mainWindow.imageList_forTab;
            lv_remote_responseRuleList.SmallImageList = mainWindow.imageList_forTab;
            loadWindowService = new LoadWindowService();
        }
        
        public void GotoPrvateRule(string ruleToken)
        {
            ShowInfoChange(ShowRuleCollectionType.SharedRule);
            LoadShareRuleSummary(shareRuleService.NowShareRuleSummary);
            foreach(ListViewItem item in lv_shareRuleList.Items)
            {
                if(item.SubItems[0].Text == ruleToken)
                {
                    item.Selected = true;
                }
            }
            lv_shareRuleList_DoubleClick(null, null);
        }
        private void SaveShareRule()
        {
            List<FiddlerRequestChange> nowFiddlerRequestChangeRuleList = new List<FiddlerRequestChange>();
            List<FiddlerResponseChange> nowFiddlerResponseChangeRuleList = new List<FiddlerResponseChange>();
            ActuatorStaticDataCollection nowStaticDataCollection = new ActuatorStaticDataCollection();
            // new WebService.RuleReportService().UploadRulesAsync<FiddlerRequestChange, FiddlerResponseChange>(FiddlerRequestChangeRuleList, FiddlerResponseChangeRuleList , StaticDataCollection).Wait();
            if (lv_remote_requestRuleList.CheckedItems!=null && lv_remote_requestRuleList.CheckedItems.Count>0)
            {
                foreach(ListViewItem requestItem in lv_remote_requestRuleList.CheckedItems)
                {
                    if(!(requestItem.Tag is FiddlerRequestChange))
                    {
                        MessageBox.Show("data error");
                        _ = RemoteLogService.ReportLogAsync("requestItem.Tag is not FiddlerRequestChange", RemoteLogService.RemoteLogOperation.ShareRule, RemoteLogService.RemoteLogType.Error);
                        return;
                    }
                    nowFiddlerRequestChangeRuleList.Add(requestItem.Tag as FiddlerRequestChange);
                }
            }

            if (lv_remote_responseRuleList.CheckedItems != null && lv_remote_responseRuleList.CheckedItems.Count > 0)
            {
                foreach (ListViewItem reponseItem in lv_remote_responseRuleList.CheckedItems)
                {
                    if (!(reponseItem.Tag is FiddlerResponseChange))
                    {
                        MessageBox.Show("data error");
                        _ = RemoteLogService.ReportLogAsync("requestItem.Tag is not FiddlerRequestChange", RemoteLogService.RemoteLogOperation.ShareRule, RemoteLogService.RemoteLogType.Error);
                        return;
                    }
                    nowFiddlerResponseChangeRuleList.Add(reponseItem.Tag as FiddlerResponseChange);
                }
            }

            if(nowFiddlerRequestChangeRuleList.Count==0 && nowFiddlerResponseChangeRuleList.Count==0)
            {
                MessageBox.Show("Please check the rules you want to share","stop");
                MyHelper.MyGlobalHelper.markControlService.MarkControl(lv_remote_requestRuleList, System.Drawing.Color.Pink, 2);
                MyHelper.MyGlobalHelper.markControlService.MarkControl(lv_remote_responseRuleList, System.Drawing.Color.Pink, 2);
                return;
            }

            shareRuleService.NowSaveRuleDetails = new RuleDetails() {
                ModificHttpRuleCollection = new FiddlerModificHttpRuleCollection(nowFiddlerRequestChangeRuleList, nowFiddlerResponseChangeRuleList),
                StaticDataCollection = localRuleDetails.StaticDataCollection
            };

            FreeHttp.FreeHttpControl.SaveShareRule saveShareRuleWindow = new SaveShareRule(shareRuleService);
            saveShareRuleWindow.Owner = this;
            saveShareRuleWindow.StartPosition = FormStartPosition.CenterParent;
            saveShareRuleWindow.ShowDialog();
            return;
        }
        private void AddRuleToListView(ListView yourListViews, IFiddlerHttpTamper yourHttpTamper)
        {
            int tempListViewItemImageIndex = yourHttpTamper.TamperProtocol == TamperProtocalType.WebSocket ? 4 : yourHttpTamper.IsRawReplace ? 1 : 0;
            ListViewItem nowRuleItem = new ListViewItem(new string[] { (yourListViews.Items.Count + 1).ToString(), yourHttpTamper.HttpFilter?.GetShowTitle() ?? "" }, tempListViewItemImageIndex);
            nowRuleItem.Tag = yourHttpTamper;
            nowRuleItem.ToolTipText = yourHttpTamper.HttpFilter.ToString();
            //nowRuleItem.Checked = yourHttpTamper.IsEnable;
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
        private void GetRemoteRuleWindow_Load(object sender, EventArgs e)
        {
            watermakTextBox_ruleToken.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            watermakTextBox_ruleToken.AutoCompleteSource = AutoCompleteSource.CustomSource;

            lv_requestRuleOriginLocation = lv_remote_requestRuleList.Location;
            lv_requestRuleOriginHeight = lv_remote_requestRuleList.Height;
            localRuleDetails = new RuleDetails() { ModificHttpRuleCollection = mainWindow.ModificHttpRuleCollection, StaticDataCollection = mainWindow.StaticDataCollection };
            ShowInfoChange(nowShowType);
            shareRuleService = new ShareRuleService(WebService.UserComputerInfo.GetFreeHttpUser());
            //_ = shareRuleService.GetShareRuleSummaryAsync();
            shareRuleService.GetShareRuleSummaryAsync().ContinueWith((rs)=> LoadShareRuleSummary(rs.Result));
        }
        private void ShowInfoChange(ShowRuleCollectionType showParameter)
        {
            ClearRemoteRule();
            switch (showParameter)
            {
                case ShowRuleCollectionType.RemoteRule:
                    nowShowType = ShowRuleCollectionType.RemoteRule;
                    lb_info_RemoteRule.ForeColor = Color.SaddleBrown;
                    lb_info_SharedRule.ForeColor = lb_info_LocalRule.ForeColor = Color.DarkGray;
                    lb_info_RemoteRule.BackColor = Color.LavenderBlush;
                    lb_info_SharedRule.BackColor = lb_info_LocalRule.BackColor = Color.FromArgb(194, 217, 247);

                    lb_info_1.Text = "remote rule token:";
                    lb_info_1.Visible = true;
                    watermakTextBox_ruleToken.Visible = true;
                    bt_getRule.Visible = true;
                    lv_shareRuleList.Visible = false;
                    lv_remote_requestRuleList.Location = lv_requestRuleOriginLocation;
                    lv_remote_requestRuleList.Height = lv_requestRuleOriginHeight;
                    lv_remote_requestRuleList.Width = lv_requestRuleOriginWidth;
                    lv_remote_responseRuleList.Location = lv_responseRuleOriginLocation;
                    lv_remote_responseRuleList.Width = lv_requestRuleOriginWidth;
                    lv_remote_requestRuleList.CheckBoxes = false;
                    lv_remote_responseRuleList.CheckBoxes = false;
                    ClearShowShareTakenItemBackColor();
                    bt_merge.Text = "Merge Remote Rule";
                    bt_replace.Visible = true;
                    break;
                case ShowRuleCollectionType.SharedRule:
                    nowShowType = ShowRuleCollectionType.SharedRule;
                    lb_info_SharedRule.ForeColor = Color.SaddleBrown;
                    lb_info_RemoteRule.ForeColor = lb_info_LocalRule.ForeColor = Color.DarkGray;
                    lb_info_SharedRule.BackColor = Color.LavenderBlush;
                    lb_info_RemoteRule.BackColor = lb_info_LocalRule.BackColor = Color.FromArgb(194, 217, 247);

                    lb_info_1.Visible = false;
                    watermakTextBox_ruleToken.Visible = false;
                    bt_getRule.Visible = true;
                    lv_shareRuleList.Visible = true;
                    lv_remote_requestRuleList.Location = new Point(lv_requestRuleOriginLocation.X+ lv_shareRuleList.Width, lv_requestRuleOriginLocation.Y - 40);
                    lv_remote_requestRuleList.Height = lv_requestRuleOriginHeight + 40;
                    lv_remote_requestRuleList.Width = lv_requestRuleOriginWidth - lv_shareRuleList.Width;
                    
                    lv_remote_responseRuleList.Location = new Point(lv_responseRuleOriginLocation.X + lv_shareRuleList.Width, lv_responseRuleOriginLocation.Y);
                    lv_remote_responseRuleList.Width = lv_requestRuleOriginWidth - lv_shareRuleList.Width;
                    lv_remote_requestRuleList.CheckBoxes = false;
                    lv_remote_responseRuleList.CheckBoxes = false;
                    bt_merge.Text = "Merge Share Rule";
                    bt_replace.Visible = true;
                    break;
                case ShowRuleCollectionType.LocalRule:
                    nowShowType = ShowRuleCollectionType.LocalRule;
                    lb_info_LocalRule.ForeColor = Color.SaddleBrown;
                    lb_info_RemoteRule.ForeColor = lb_info_SharedRule.ForeColor = Color.DarkGray;
                    lb_info_LocalRule.BackColor = Color.LavenderBlush;
                    lb_info_RemoteRule.BackColor = lb_info_SharedRule.BackColor = Color.FromArgb(194, 217, 247);

                    lb_info_1.Visible = false;
                    watermakTextBox_ruleToken.Visible = false;
                    bt_getRule.Visible = false;
                    lv_shareRuleList.Visible = false;
                    lv_remote_requestRuleList.Location = new Point(lv_requestRuleOriginLocation.X, lv_requestRuleOriginLocation.Y - 40);
                    lv_remote_requestRuleList.Height = lv_requestRuleOriginHeight + 40;
                    lv_remote_requestRuleList.Width = lv_requestRuleOriginWidth;

                    lv_remote_responseRuleList.Location = lv_responseRuleOriginLocation;
                    lv_remote_responseRuleList.Width = lv_requestRuleOriginWidth;
                    lv_remote_requestRuleList.CheckBoxes = true;
                    lv_remote_responseRuleList.CheckBoxes = true;
                    ClearShowShareTakenItemBackColor();
                    bt_merge.Text = "Save Share Rule";
                    bt_replace.Visible = false;
                    //action
                    LoadRules(localRuleDetails);
                    break;
                default:
                    MessageBox.Show("nonsupport static data type");
                    break;
            }
            
        }

        private void LoadShareRuleSummary(ShareRuleSummary shareRuleSummary)
        {
            if(shareRuleSummary==null)
            {
                _ = RemoteLogService.ReportLogAsync("LoadShareRuleSummary fial with null data", RemoteLogService.RemoteLogOperation.RemoteRule, RemoteLogService.RemoteLogType.Error);
                return;
            }
            if (shareRuleSummary.ShareRuleList?.Count > 0)
            {
               
                var autoCompleteStringCollection = new AutoCompleteStringCollection();
                foreach (var tempShareToken in shareRuleSummary.ShareRuleList)
                {
                    autoCompleteStringCollection.Add(tempShareToken.ShowWholeTag);
                    this.Invoke(new Action(() => watermakTextBox_ruleToken.AutoCompleteCustomSource.Add(tempShareToken.ShowWholeTag)));
                }
            }
            if (shareRuleSummary.PrivateRuleList?.Count > 0)
            {
                lv_shareRuleList.Items.Clear();
                this.Invoke(new Action(() => FreeHttpControl.MyControlHelper.SetControlFreeze(lv_shareRuleList)));
                foreach (var tempShareToken in shareRuleSummary.PrivateRuleList)
                {
                    lv_shareRuleList.Items.Add(new ListViewItem(new string[] {tempShareToken.Token,tempShareToken.Remark }));
                }
                this.Invoke(new Action(() => FreeHttpControl.MyControlHelper.SetControlUnfreeze(lv_shareRuleList)));
            }
        }

        private void LoadRules(RuleDetails ruleDetails)
        {
            if(ruleDetails==null || (ruleDetails.ModificHttpRuleCollection?.RequestRuleList?.Count<1 && ruleDetails.ModificHttpRuleCollection?.ResponseRuleList?.Count < 1))
            {
                lb_info_2.Text = "your local rule is empty";
                return;
            }
            foreach (var tempRule in ruleDetails.ModificHttpRuleCollection?.RequestRuleList?? new List<FiddlerRequestChange>())
            {
                AddRuleToListView(lv_remote_requestRuleList, tempRule);
            }
            foreach (var tempRule in ruleDetails.ModificHttpRuleCollection?.ResponseRuleList??new List<FiddlerResponseChange>())
            {
                AddRuleToListView(lv_remote_responseRuleList, tempRule);
            }
            lb_info_2.Text = string.Format("Get RequestRule:{0} ; ResponseRule:{1} ; StaticData:{2}", ruleDetails.ModificHttpRuleCollection.RequestRuleList.Count, ruleDetails.ModificHttpRuleCollection.ResponseRuleList.Count, ruleDetails.StaticDataCollection?.Count ?? 0);
            nowRuleDetails = ruleDetails;
        }

        private RuleDetails GetRuleDetailsFromToken(string shareToken)
        {
            RuleDetails ruleDetails = null;
            try
            {
                System.Threading.Tasks.Task<RuleDetails> ruleTask = System.Threading.Tasks.Task.Run(new Func<RuleDetails>(() =>
                {
                    //return WebService.RemoteRuleService.GetRemoteRuleAsync(watermakTextBox_ruleToken.Text).GetAwaiter().GetResult();
                    return shareRuleService.GetShareRuleDetailAsync(shareToken).GetAwaiter().GetResult();
                }));
                ruleDetails = ruleTask.GetAwaiter().GetResult();
                if (ruleDetails == null)
                {
                    MessageBox.Show("your rule token is not permitted", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else if (ruleDetails.ModificHttpRuleCollection == null || ((ruleDetails.ModificHttpRuleCollection.RequestRuleList == null || ruleDetails.ModificHttpRuleCollection.RequestRuleList.Count == 0) && (ruleDetails.ModificHttpRuleCollection.ResponseRuleList == null || ruleDetails.ModificHttpRuleCollection.ResponseRuleList.Count == 0)))
                {
                    MessageBox.Show("can not find any rule in your storage spaces", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    ruleDetails = null;
                }
            }
            catch (Exception ex)
            {
                _ = RemoteLogService.ReportLogAsync(ex.ToString(), RemoteLogService.RemoteLogOperation.RemoteRule, RemoteLogService.RemoteLogType.Error);
                ruleDetails = null;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return ruleDetails;
        }

        private void lb_info_showType_Click(object sender, EventArgs e)
        {
            ShowRuleCollectionType hereType;
            if (Enum.TryParse<ShowRuleCollectionType>(((Label)sender).Text, out hereType))
            {
                ShowInfoChange(hereType);
            }
        }
        private void bt_getRule_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(watermakTextBox_ruleToken.Text))
            {
                MessageBox.Show("just input your rule token", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                MyHelper.MyGlobalHelper.markControlService.MarkControl(watermakTextBox_ruleToken, System.Drawing.Color.Pink, 2);
                return;
            }
            string shareToken = watermakTextBox_ruleToken.Text.Contains('[') ? watermakTextBox_ruleToken.Text.Substring(0, watermakTextBox_ruleToken.Text.IndexOf('[')).Trim() : watermakTextBox_ruleToken.Text.Trim();
            ClearRemoteRule();
            loadWindowService.StartLoad(this,true);
            RuleDetails ruleDetails = GetRuleDetailsFromToken(shareToken);
            loadWindowService.StopLoad();
            if (ruleDetails == null)
            {
                MyHelper.MyGlobalHelper.markControlService.MarkControl(watermakTextBox_ruleToken, System.Drawing.Color.Pink, 2);
                return;
            }
            LoadRules(ruleDetails);
        }

        private ListViewItem nowShowShareTakenListViewItem = null;
        private void ClearShowShareTakenItemBackColor()
        {
            if (nowShowShareTakenListViewItem != null)
            {
                MyHelper.MyGlobalHelper.markControlService.SetColor(nowShowShareTakenListViewItem, Color.Azure);
                nowShowShareTakenListViewItem = null;
            }
        }
        private void lv_shareRuleList_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem tempListViewItem = lv_shareRuleList.SelectedItems[0];
            loadWindowService.StartLoad(this, true);
            RuleDetails ruleDetails = GetRuleDetailsFromToken(tempListViewItem.SubItems[0].Text);
            loadWindowService.StopLoad();
            if(ruleDetails==null)
            {
                MessageBox.Show("get share taken fail", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MyHelper.MyGlobalHelper.markControlService.MarkControl(watermakTextBox_ruleToken, System.Drawing.Color.Pink, 2);
                return;
            }

            ClearRemoteRule();
            ClearShowShareTakenItemBackColor();
            MyHelper.MyGlobalHelper.markControlService.SetColor(tempListViewItem, Color.Pink);
            nowShowShareTakenListViewItem = tempListViewItem;
            LoadRules(ruleDetails);
        }

        private void copyThisTokenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(lv_shareRuleList.SelectedItems?.Count>0)
            {
                Clipboard.SetText(lv_shareRuleList.SelectedItems[0].SubItems[0].Text, TextDataFormat.Text);
                MessageBox.Show($"{lv_shareRuleList.SelectedItems[0].SubItems[0].Text} has been copied to the clipboard", "copied");
            }
        }

        private async void deleteThisTokenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lv_shareRuleList.SelectedItems?.Count > 0)
            {
                ListViewItem tempListViewItem = lv_shareRuleList.SelectedItems[0];
                if (await shareRuleService.DeleteShareRuleDetailAsync(tempListViewItem.SubItems[0].Text))
                {
                    MessageBox.Show("Delete has succeed", "succeed",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    lv_shareRuleList.Items.Remove(tempListViewItem);
                    if(nowShowShareTakenListViewItem== tempListViewItem)
                    {
                        ClearRemoteRule();
                        nowShowShareTakenListViewItem = null;
                    }
                }
                else
                {
                    MessageBox.Show("delete share taken fail","Fail",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please choose the item that your want delete first");
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

        private void bt_merge_Click(object sender, EventArgs e)
        {
            switch(nowShowType)
            {
                case ShowRuleCollectionType.RemoteRule:
                    if (nowRuleDetails == null)
                    {
                        MyHelper.MyGlobalHelper.markControlService.MarkControl(watermakTextBox_ruleToken, System.Drawing.Color.Pink, 2);
                        MessageBox.Show("please get remore rule first", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    mainWindow.MergeRuleStorage(nowRuleDetails);
                    MessageBox.Show("Complete the merge rule", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    break;
                case ShowRuleCollectionType.SharedRule:
                    if (nowRuleDetails == null)
                    {
                        MyHelper.MyGlobalHelper.markControlService.MarkControl(watermakTextBox_ruleToken, System.Drawing.Color.Pink, 2);
                        MessageBox.Show("please select and load share rule first\r\ndouble click to loading rule", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    mainWindow.MergeRuleStorage(nowRuleDetails);
                    MessageBox.Show("Complete the merge rule", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    break;
                case ShowRuleCollectionType.LocalRule:
                    SaveShareRule();
                    break;
                default:
                    MessageBox.Show("Unknow state", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    break;
            }
        }

        private void bt_replace_Click(object sender, EventArgs e)
        {
            switch (nowShowType)
            {
                case ShowRuleCollectionType.RemoteRule:
                case ShowRuleCollectionType.SharedRule:
                    if (nowRuleDetails == null)
                    {
                        MyHelper.MyGlobalHelper.markControlService.MarkControl(watermakTextBox_ruleToken, System.Drawing.Color.Pink, 2);
                        MessageBox.Show("please select share rule first", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    if (MessageBox.Show("This operation will removes all local rules and replace with the remote rules \r\nwhether to confirm ", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        mainWindow.ReplaceRuleStorage(nowRuleDetails);
                        MessageBox.Show("Complete the replacement rule", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    break;
                default:
                    MessageBox.Show("Unknow state", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    break;
            }
        }

        #region public event helper
        private void lb_info_MouseMove(object sender, MouseEventArgs e)
        {
            ((Label)sender).BackColor = Color.LavenderBlush;
        }

        private void lb_info_MouseLeave(object sender, EventArgs e)
        {
            if(sender== lb_info_RemoteRule && nowShowType== ShowRuleCollectionType.RemoteRule ||
                sender == lb_info_SharedRule && nowShowType == ShowRuleCollectionType.SharedRule||
                    sender == lb_info_LocalRule && nowShowType == ShowRuleCollectionType.LocalRule)
            {
                return;
            }
            ((Label)sender).BackColor = Color.FromArgb(194, 217, 247);
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

        #endregion

       
    }
}
