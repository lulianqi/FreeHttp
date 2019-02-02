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
    public partial class ShowSheetForm : Form
    {
        public ShowSheetForm()
        {
            InitializeComponent();
        }

        private List<List<string>> listViewSource;
        public ShowSheetForm(string name, List<List<string>> dataSource)
            : this()
        {
            this.Text = string.IsNullOrEmpty(name) ? "" : name;
            if (dataSource != null) { listViewSource = dataSource; }
        }

        private void ShowSheetForm_Load(object sender, EventArgs e)
        {
            int columnCount = 0;
            if (listViewSource != null)
            {
                foreach(List<string> tempRowItem in listViewSource)
                {
                    if(tempRowItem!=null && tempRowItem.Count>0)
                    {
                        if(tempRowItem.Count>columnCount)
                        {
                            for(int i = columnCount;i<tempRowItem.Count;i++)
                            {
                                listView.Columns.Add((i + 1).ToString());
                            }
                            columnCount = tempRowItem.Count;
                        }
                        listView.Items.Add(new ListViewItem(tempRowItem.ToArray()));
                    }
                    else
                    {
                        listView.Items.Add(new ListViewItem());
                    }
                }
            }
        }
    }
}
