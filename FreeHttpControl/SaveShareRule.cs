using FreeHttp.FreeHttpControl.ControlHelper;
using FreeHttp.WebService;
using System;
using System.Windows.Forms;

namespace FreeHttp.FreeHttpControl
{
    public partial class SaveShareRule : Form
    {
        ShareRuleService shareRuleService;
        LoadWindowService loadWindowService;
        public SaveShareRule(ShareRuleService ruleService)
        {
            InitializeComponent();
            shareRuleService = ruleService;
            loadWindowService = new LoadWindowService();
        }

        private void SaveShareRule_Load(object sender, EventArgs e)
        {
            comboBox_yourRule.DataSource = shareRuleService.NowShareRuleSummary.PrivateRuleList;
            comboBox_yourRule.ValueMember = "Token";
            comboBox_yourRule.DisplayMember = "ShowTag";
            comboBox_yourRule.Text = "please select personal ShareRule";
            rb_newRule_CheckedChanged(sender, e);
        }

        private void rb_newRule_CheckedChanged(object sender, EventArgs e)
        {
            if(rb_newRule.Checked)
            {
                wtb_ruleRemark.Enabled = true;
                comboBox_yourRule.Enabled = false;
            }
            else
            {
                wtb_ruleRemark.Enabled = false;
                comboBox_yourRule.Enabled = true;
            }
        }
        private void bt_save_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(wtb_ruleRemark.Text))
            {
                MessageBox.Show("please enter comment name", "Stop");
                MyHelper.MyGlobalHelper.markControlService.MarkControl(wtb_ruleRemark, System.Drawing.Color.Aquamarine, 2);
                return;
            }
            shareRuleService.SaveShareRules(wtb_ruleRemark.Text, ck_parameterData.Checked).ContinueWith((rs => {
                if(rs.Result.Key==null)
                {
                    MessageBox.Show("Save share rule fail ,Please try again later", "Fail",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
                else
                {
                    shareRuleService.NowShareRuleSummary.PrivateRuleList.Add(new WebService.DataModel.ShareRuleSummary.RuleToken() { Token = rs.Result.Key, Remark = rs.Result.Value });
                    MessageBox.Show($"your share rule [{rs.Result.Value??"-"}] save succeed", "succeed", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
                loadWindowService.StopLoad();
                MyHelper.MyGlobalHelper.PutGlobalMessage(this, new MyHelper.MyGlobalHelper.GlobalMessageEventArgs(false, $"{rs.Result.Key}:{rs.Result.Value}"));
            })) ;
            loadWindowService.StartLoad(this);
        }
    }
}
