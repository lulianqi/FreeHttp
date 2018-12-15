using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FreeHttp.FreeHttpControl
{
    public partial class EditListView : UserControl
    {
        public EditListView()
        {
            InitializeComponent();
            columnHeader_data.Text = ColumnHeaderName;
            SplitStr=SplitStr==null?": ":SplitStr;
        }

        /// <summary>
        /// 编辑或添加时 key value 的默认分割
        /// </summary>
        [DescriptionAttribute("编辑或添加时 key value 的默认分割")]
        public string SplitStr { get; set; }

        /// <summary>
        /// 是否以key value方式显示
        /// </summary>
        [DescriptionAttribute("是否以key value方式显示")]
        public bool IsKeyValue { get; set; }

        /// <summary>
        /// 可用于显示的列名
        /// </summary>
        [DescriptionAttribute("可用于显示的列名")]
        public string ColumnHeaderName{ get; set; }

        private void EditListView_Load(object sender, EventArgs e)
        {
            columnHeader_data.Text = ColumnHeaderName;
        }

        public ListView ListDataView
        {
            get { return lv_dataList; }
        }

        //pictureBox change for all
        public void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            ((PictureBox)sender).BackColor = Color.Honeydew;
        }

        //pictureBox change for all
        public void pictureBox_MouseLeave(object sender, EventArgs e)
        {
            ((PictureBox)sender).BackColor = Color.Transparent;
        }

        private void EditListView_Resize(object sender, EventArgs e)
        {
            columnHeader_data.Width = lv_dataList.Width;
        }

        private void pictureBox_add_Click(object sender, EventArgs e)
        {
            if(IsKeyValue)
            {
                EditKeyVaule f = new EditKeyVaule(lv_dataList, true, SplitStr);
                f.ShowDialog();
            }
            else
            {
                RemoveHead f = new RemoveHead(lv_dataList, true);
                f.ShowDialog();
            }
        }

        private void pictureBox_remove_Click(object sender, EventArgs e)
        {
            if (lv_dataList.SelectedItems.Count > 0)
            {
                int tempRemoveIndex = lv_dataList.SelectedItems.Count - 1;
                for (int i = tempRemoveIndex; i >= 0; i--)
                {
                    lv_dataList.Items.Remove(lv_dataList.SelectedItems[i]);
                }
            }
            else if (lv_dataList.Items.Count>0)
            {
                if(MessageBox.Show("if you want remove all data","remove all",MessageBoxButtons.OKCancel,MessageBoxIcon.Question)==DialogResult.OK)
                {
                    lv_dataList.Items.Clear();
                }
            }
            else
            {
                MessageBox.Show("nothing to clear");
            }
        }

        private void lv_dataList_DoubleClick(object sender, EventArgs e)
        {
            if (lv_dataList.SelectedItems.Count > 0)
            {
                if (IsKeyValue)
                {
                    EditKeyVaule f = new EditKeyVaule(lv_dataList, false, SplitStr);
                    f.ShowDialog();
                }
                else
                {
                    RemoveHead f = new RemoveHead(lv_dataList, false);
                    f.ShowDialog();
                }
            }
        }
    }
}
