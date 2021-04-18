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
            comboBox_yourRule.DisplayMember = "Token";
            comboBox_yourRule.Text = "please select personal ShareRule";
        }

        private void bt_save_Click(object sender, EventArgs e)
        {
            shareRuleService.SaveShareRules().ContinueWith((rs => loadWindowService.StopLoad())) ;
            loadWindowService.StartLoad(this);
        }
        
    }
}
