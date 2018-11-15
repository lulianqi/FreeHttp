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
    public partial class RemoveHead : Form
    {
        public RemoveHead(ListView yourEditListView, bool yourIsAdd)
        {
            InitializeComponent();
            editListView = yourEditListView;
            isAdd = yourIsAdd;
        }


        ListView editListView;
        bool isAdd;

        private void RemoveHead_Load(object sender, EventArgs e)
        {
            if (!isAdd)
            {
                tb_key.Text = editListView.SelectedItems[0].Text;
            }
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        private void bt_ok_Click(object sender, EventArgs e)
        {
            if (tb_key.Text == "")
            {
                MessageBox.Show("input key", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                if (isAdd)
                {
                    editListView.Items.Add(tb_key.Text);
                }
                else
                {
                    editListView.SelectedItems[0].Text = tb_key.Text;
                }
                this.Close();
            }
        }

       
    }
}
