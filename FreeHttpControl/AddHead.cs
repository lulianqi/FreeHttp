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
    public partial class AddHead : Form
    {
        ListView editListView;
        bool isAdd;
        public AddHead(ListView yourEditListView , bool yourIsAdd)
        {
            InitializeComponent();
            editListView = yourEditListView;
            isAdd = yourIsAdd;
        }

        public AddHead(ListView yourEditListView, string yourHeadKey)
            : this(yourEditListView,true)
        {
            tb_key.Text = yourHeadKey;
            tb_key.Enabled = false;
        }

        private void AddResponseHead_Load(object sender, EventArgs e)
        {
            if(!isAdd)
            {
                string headStr= editListView.SelectedItems[0].Text;
                if (headStr.Contains(": "))
                {
                    tb_key.Text = headStr.Remove(headStr.IndexOf(": "));
                    rtb_value.Text = headStr.Substring(headStr.IndexOf(": ") + 2);
                }
            }
        }
        private void bt_ok_Click(object sender, EventArgs e)
        {
            if(tb_key.Text==""||rtb_value.Text=="")
            {
                MessageBox.Show("input key and value","Stop" , MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                if (isAdd)
                {
                    editListView.Items.Add(String.Format("{0}: {1}", tb_key.Text, rtb_value.Text));
                }
                else
                {
                    editListView.SelectedItems[0].Text = String.Format("{0}: {1}", tb_key.Text, rtb_value.Text);
                }
                this.Close();
            }
        }

        
    }
}
