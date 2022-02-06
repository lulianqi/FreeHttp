using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FreeHttp.FreeHttpControl
{
    /// <summary>
    /// item 可拖放排序的ListView
    /// </summary>
    //public class MyListView : ListView
    public class MyListView : ListViewExtended
    {
        /// <summary>
        /// 维持group模式下的选中状态（在ListView动态编辑group过程中，会让选择状态异常）
        /// </summary>
        public class GroupSelectedItemsSataus
        {
            private ListView NowListView { get; set; }
            private List<ListViewItem> NowSelectedItems { get; set; }

            public GroupSelectedItemsSataus(ListView listView)
            {
                NowListView = listView;
                NowSelectedItems = new List<ListViewItem>();
            }

            public void GetSnapshoot()
            {
                NowSelectedItems.Clear();
                foreach(ListViewItem listViewItem in NowListView.SelectedItems)
                {
                    NowSelectedItems.Add(listViewItem);
                }
            }

            public void ReCoverSnapshoot()
            {
                if(NowSelectedItems.Count>0)
                {
                    foreach (ListViewItem listViewItem in NowListView.SelectedItems)
                    {
                        if (NowSelectedItems.Contains(listViewItem))
                        {
                            NowSelectedItems.Remove(listViewItem);
                        }
                        else
                        {
                            listViewItem.Selected = false;
                        }
                    }
                    foreach (ListViewItem listViewItem in NowSelectedItems)
                    {
                        listViewItem.Selected = true;
                    }
                }
                NowSelectedItems.Clear();
            }
        }

        private const int WM_LBUTTONDBLCLK = 0x0203;  //左键双击
        private int moveItemIndex = -1;
        public GroupSelectedItemsSataus GroupSelectedSataus { get; private set; }

        /// <summary>
        /// this ListView disable double click to check the checkbox
        /// enable DoubleBuffer
        /// implement items drag in detail mode
        /// </summary>
        public MyListView() : base() 
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();
            GroupSelectedSataus = new GroupSelectedItemsSataus(this);
        }

        /// <summary>
        /// Drag Start (开始拖放/拖入)
        /// </summary>
        public event EventHandler<ItemDragEventArgs> OnItemDragSortStart;

        /// <summary>
        /// Drag End （完成拖放/脱出）
        /// </summary>
        public event EventHandler<DragEventArgs> OnItemDragSortEnd;

        protected override void WndProc(ref Message m)
        { 
            if (m.Msg == WM_LBUTTONDBLCLK)
            { 
                Point p = PointToClient(new Point(Cursor.Position.X, Cursor.Position.Y)); 
                ListViewItem lvi = GetItemAt(p.X, p.Y); 
                if (lvi != null) 
                    lvi.Selected = true; 
                OnDoubleClick(new EventArgs()); 
            } 
            else 
                base.WndProc(ref m); 
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // MyListView
            // 
            this.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.MyListView_ItemDrag);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MyListView_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MyListView_DragEnter);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.MyListView_DragOver);
            this.DragLeave += new System.EventHandler(this.MyListView_DragLeave);
            this.ResumeLayout(false);

        }

        /// <summary>
        /// is your item above your move items (just like AppearsAfterItem)   [if you want enable drag just set ListView AllowDrop is true]
        /// </summary>
        /// <param name="nowIndex">you now item index</param>
        /// <returns>is above item</returns>
        private bool AppearAboveItem(int nowIndex)
        {
            if (nowIndex < moveItemIndex)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyListView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (this.SelectedItems!=null && this.SelectedItems.Count>0)
            {
                GroupSelectedSataus.GetSnapshoot();
                OnItemDragSortStart?.Invoke(sender, e);
                GroupSelectedSataus.ReCoverSnapshoot();
                moveItemIndex = this.SelectedItems[0].Index;
                this.DoDragDrop(this.SelectedItems, DragDropEffects.Move);
            }
        }

        /// <summary>
        /// drag complete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyListView_DragDrop(object sender, DragEventArgs e)
        {
            int targetIndex = this.InsertionMark.Index;
            if (targetIndex == -1)
            {
                return;
            }
            SelectedListViewItemCollection draggedItems =(SelectedListViewItemCollection)e.Data.GetData(typeof(SelectedListViewItemCollection));
            if (draggedItems == null || draggedItems.Count == 0 || draggedItems[0].ListView != this)
            {
                this.InsertionMark.Index = -1;
                return;
            }

            foreach (ListViewItem draggedItem in draggedItems)
            {
                this.Items.Remove(draggedItem);
                this.Items.Insert(targetIndex, draggedItem);
                if (AppearAboveItem(targetIndex))
                {
                    targetIndex++;
                }
            }
            OnItemDragSortEnd?.Invoke(sender, e);
        }


        private void MyListView_DragEnter(object sender, DragEventArgs e)
        {
            GroupSelectedSataus.GetSnapshoot();
            OnItemDragSortStart?.Invoke(sender, null);
            GroupSelectedSataus.ReCoverSnapshoot();
            SelectedListViewItemCollection draggedItems = (SelectedListViewItemCollection)e.Data.GetData(typeof(SelectedListViewItemCollection));
            e.Effect = (draggedItems == null || draggedItems.Count == 0 || draggedItems[0].ListView != this) ? DragDropEffects.None : e.AllowedEffect;
        }

        private void MyListView_DragLeave(object sender, EventArgs e)
        {
            this.InsertionMark.Index = -1;
            OnItemDragSortEnd?.Invoke(sender, null);
        }

        /// <summary>
        /// drag over the contor boundary
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyListView_DragOver(object sender, DragEventArgs e)
        {
            Point targetPoint = this.PointToClient(new Point(e.X, e.Y));
            int targetIndex = this.InsertionMark.NearestIndex(targetPoint);
            //System.Diagnostics.Debug.WriteLine(targetIndex.ToString() + this.InsertionMark.AppearsAfterItem.ToString());
            if (targetIndex > -1)
            {
                this.InsertionMark.Color = Color.PowderBlue;
            }
            //Rectangle itemBounds = myListView.GetItemRect(targetIndex);
            //myListView.InsertionMark.AppearsAfterItem = (targetPoint.X > itemBounds.Left + (itemBounds.Width / 2));
            this.InsertionMark.AppearsAfterItem = (!AppearAboveItem(targetIndex));
            this.InsertionMark.Index = targetIndex;
        }

    }
}
