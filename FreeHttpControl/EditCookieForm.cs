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
    public partial class EditCookieForm : Form
    {

        ListView editListView;
        public EditCookieForm(ListView yourEditListView)
        {
            InitializeComponent();
            editListView = yourEditListView;
        }

        private void EditCookieForm_Load(object sender, EventArgs e)
        {
            tb_name.Text = "name";
            rtb_value.Text = "vaule";
            tb_attribute.Text = "Path=/";
            UpdataSetText();
        }


        private void tb_attribute_TextChanged(object sender, EventArgs e)
        {
            UpdataSetText();
        }

        private void bt_ok_Click(object sender, EventArgs e)
        {
            editListView.Items.Add(rtb_setValue.Text);
            this.Close();
        }

       
        private void UpdataSetText()
        {
            if (tb_attribute.Text != "")
            {
                rtb_setValue.Text = string.Format("Set-Cookie: {0}={1}; {2}", tb_name.Text, rtb_value.Text, tb_attribute.Text);
            }
            else
            {
                rtb_setValue.Text = string.Format("Set-Cookie: {0}={1}", tb_name.Text, rtb_value.Text);
            }
        }
    }
}
