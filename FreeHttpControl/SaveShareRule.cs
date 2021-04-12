using FreeHttp.FreeHttpControl.ControlHelper;
using FreeHttp.WebService;
using System;
using System.Windows.Forms;

namespace FreeHttp.FreeHttpControl
{
    public partial class SaveShareRule : Form
    {
        ShareRuleService shareRuleService;
        LoadBitmap loadBitmap;
        public SaveShareRule(ShareRuleService ruleService)
        {
            InitializeComponent();
            shareRuleService = ruleService;
            loadBitmap = new LoadBitmap(this.Size);
        }

        private void SaveShareRule_Load(object sender, EventArgs e)
        {

        }

        private void bt_save_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = loadBitmap.DrawCircle((new Random()).Next(0, 7));
        }
        
    }
}
