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
    public partial class EditKeyVaule : Form
    {
        ListView editListView;
        string splitStr; //splitStr ": "
        bool isAdd;      //add or edit mode
        public EditKeyVaule(ListView yourEditListView , bool yourIsAdd ,string yourSplitStr)
        {
            InitializeComponent();
            editListView = yourEditListView;
            isAdd = yourIsAdd;
            splitStr = yourSplitStr == null ? ": " : yourSplitStr;
        }

        public EditKeyVaule(ListView yourEditListView, string yourHeadKey,string yourSplitStr)
            : this(yourEditListView, true, yourSplitStr)
        {
            tb_key.Text = yourHeadKey;
            tb_key.Enabled = false;
        }

        private void EditKeyVaule_Load(object sender, EventArgs e)
        {
            if(!isAdd)
            {
                string headStr= editListView.SelectedItems[0].Text;
                if (headStr.Contains(splitStr))
                {
                    tb_key.Text = headStr.Remove(headStr.IndexOf(splitStr));
                    rtb_value.Text = headStr.Substring(headStr.IndexOf(splitStr) + splitStr.Length);
                }
            }
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
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
                    editListView.Items.Add(String.Format("{0}{1}{2}", tb_key.Text,splitStr, rtb_value.Text));
                }
                else
                {
                    editListView.SelectedItems[0].Text = String.Format("{0}{1}{2}", tb_key.Text,splitStr, rtb_value.Text);
                }
                this.Close();
            }
        }

        
    }
}
