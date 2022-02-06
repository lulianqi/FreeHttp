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
    public partial class SortRule : Form
    {
        MyListView _listView;
     

        public SortRule(MyListView listView)
        {
            _listView = listView;
        }

        private void SortRule_Load(object sender, EventArgs e)
        {
            this.Controls.Add(_listView);
        }
    }
}
