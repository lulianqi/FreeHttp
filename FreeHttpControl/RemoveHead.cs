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
        ListView editListView;
        bool isAdd;
        bool isUnique;   //is not allow repetition

        public RemoveHead(ListView yourEditListView, bool yourIsAdd)
            : this(yourEditListView, yourIsAdd, false) { }

        public RemoveHead(ListView yourEditListView, bool yourIsAdd, bool yourIsUnique)
        {
            InitializeComponent();
            editListView = yourEditListView;
            isAdd = yourIsAdd;
            isUnique = yourIsUnique;
        }

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
                string tempItemStr = tb_key.Text;
                if (isUnique)
                {
                    foreach (ListViewItem tempItem in editListView.Items)
                    {
                        if (tempItem.Text == tempItemStr)
                        {
                            if (!isAdd && tempItem == editListView.SelectedItems[0])
                            {
                                continue;
                            }
                            MessageBox.Show("Find the same data in the list", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                    }
                }
                if (isAdd)
                {
                    editListView.Items.Add(tempItemStr);
                }
                else
                {
                    editListView.SelectedItems[0].Text = tempItemStr;
                }
                this.Close();
            }
        }

       
    }
}
