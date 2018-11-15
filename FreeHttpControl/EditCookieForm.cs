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
            tb_name.Text = "name";
            rtb_value.Text = "vaule";
            tb_attribute.Text = "Path=/";
        }

        public EditCookieForm(ListView yourEditListView , string name, string vaule, string attribute)
            : this(yourEditListView)
        {
            if (name != null) { tb_name.Text = name; }
            if (vaule != null) { rtb_value.Text = vaule; }
            if (attribute != null) { tb_attribute.Text = attribute; }
        }

        private void EditCookieForm_Load(object sender, EventArgs e)
        {
            UpdataSetText();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
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
