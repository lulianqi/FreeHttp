using FreeHttp.AutoTest.RunTimeStaticData;
using FreeHttp.AutoTest.RunTimeStaticData.MyStaticData;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FreeHttp.FreeHttpControl
{
    partial class StaticDataManageWindow : MyBaseInfoWindow
    {
        public enum ShowRunTimeParameterType
        {
            KeyValue = 0,
            Parameter = 1,
            DataSouce=2
        }

        public StaticDataManageWindow(ActuatorStaticDataCollection yourActuatorStaticDataCollection)
        {
            InitializeComponent();
            actuatorStaticDataCollection = yourActuatorStaticDataCollection;
            if (yourActuatorStaticDataCollection != null)
            {
                actuatorStaticDataCollection.OnChangeCollection += actuatorStaticDataCollection_OnChangeCollection;
            }
        }



        private ShowRunTimeParameterType nowShowType = ShowRunTimeParameterType.KeyValue;
        private ListViewItem nowEditItem = null;
        private ActuatorStaticDataCollection actuatorStaticDataCollection = null;

        public override void VirtualUpdataTime_Tick()
        {
            //pb_edit.Enabled = !pb_edit.Enabled;
            UpdatalistView_CaseParameter(false);
        }

        private void StaticDataManageWindow_Load(object sender, EventArgs e)
        {
            if (actuatorStaticDataCollection == null)
            {
                MessageBox.Show("actuatorStaticDataCollection is null");
                this.Close();
            }
            ShowInfoChange(nowShowType);
        }

        private void StaticDataManageWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(actuatorStaticDataCollection!=null)
            {
                actuatorStaticDataCollection.OnChangeCollection -= actuatorStaticDataCollection_OnChangeCollection;
                actuatorStaticDataCollection = null;
            }
        }

        void actuatorStaticDataCollection_OnChangeCollection(object sender, ActuatorStaticDataCollection.ChangeDataEventArgs e)
        {
            UpdatalistView_CaseParameter(e.IsAddOrDel);
        }

        private void lb_info_runTimeParameter_Click(object sender, EventArgs e)
        {
            ShowRunTimeParameterType hereType;
            if (Enum.TryParse<ShowRunTimeParameterType>(((Label)sender).Text, out hereType))
            {
                ShowInfoChange(hereType);
            }
        }

        private void listView_CaseParameter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView_CaseParameter.SelectedItems.Count > 0)
            {
                EditItemChange(listView_CaseParameter.SelectedItems[0]);
            }
        }

        private void listView_CaseParameter_DoubleClick(object sender, EventArgs e)
        {
            
            if(listView_CaseParameter.SelectedItems!=null&& listView_CaseParameter.SelectedItems.Count>0)
            {
                if (listView_CaseParameter.SelectedItems[0].Tag is MyStaticDataSourceCsv)
                {
                    MyStaticDataSourceCsv nowDataSourceCsv = (MyStaticDataSourceCsv)listView_CaseParameter.SelectedItems[0].Tag;
                    //ShowSheetForm f = new ShowSheetForm("", nowDataSourceCsv.GetDataSource());
                    EditSheetForm f = new EditSheetForm(listView_CaseParameter.SelectedItems[0].SubItems[0].Text, nowDataSourceCsv.GetDataSource(), nowDataSourceCsv.GetDataLocation());
                    f.StartPosition = FormStartPosition.CenterScreen;
                    f.SaveSheetData += editSheetForm_SaveSheetData;
                    f.ShowDialog();
                }
            }
        }

        void editSheetForm_SaveSheetData(object sender, EditSheetForm.SaveSheetDataEventArgs e)
        {
            if (e.SheetData != null && listView_CaseParameter.SelectedItems != null && listView_CaseParameter.SelectedItems.Count > 0)
            {
                if (listView_CaseParameter.SelectedItems[0].Tag is MyStaticDataSourceCsv)
                {
                    MyStaticDataSourceCsv nowDataSourceCsv = (MyStaticDataSourceCsv)listView_CaseParameter.SelectedItems[0].Tag;
                    if(nowDataSourceCsv.SetDataSource(e.SheetData))
                    {
                        if (e.SelectCell != null)
                        {
                            nowDataSourceCsv.SetDataLocation(e.SelectCell.Value.Y, e.SelectCell.Value.X);
                        }
                        UpdatalistView_CaseParameter(false);
                    }
                    else
                    {
                        MessageBox.Show("you data is empty \nplease check it ", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    if(nowEditItem!=null)
                    {
                        tb_valueAdd.Text = nowEditItem.SubItems[2].Text;
                    }
                }
            }
        }

        private void listView_CaseParameter_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (listView_CaseParameter.SelectedItems != null && listView_CaseParameter.SelectedItems.Count > 0)
            {
                //this.DoDragDrop(listView_CaseParameter.SelectedItems, DragDropEffects.Move);
                this.DoDragDrop(string.Format("*#{0}(+)*#", listView_CaseParameter.SelectedItems[0].SubItems[0].Text), DragDropEffects.Move);
            }
        }

        private void pictureBox_controlData_Click(object sender, EventArgs e)
        {
            if (nowEditItem==null)
            {
                MessageBox.Show("can not find edit Parameter Data", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            IRunTimeStaticData editRunTimeStaticData = (IRunTimeStaticData)nowEditItem.Tag;
            if(sender == pb_edit)
            {
                if (!editRunTimeStaticData.DataSet(tb_valueAdd.Text))
                {
                    MessageBox.Show(string.Format("{0} is illegal for this RunTimeStaticData", tb_valueAdd.Text), "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            else if(sender == pb_next)
            {
                editRunTimeStaticData.DataMoveNext();
            }
            else if (sender == pb_reset)
            {
                editRunTimeStaticData.DataReset();
            }
            else
            {
                MessageBox.Show("can not find edit data", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            FreeHttpWindow.MarkRuleItem(nowEditItem);
            nowEditItem.SubItems[2].Text = tb_valueAdd.Text = editRunTimeStaticData.DataCurrent();
        }

        private void pb_addStaticData_Click(object sender, EventArgs e)
        {
            StaticDataAddWindow f = new StaticDataAddWindow(actuatorStaticDataCollection, (int)nowShowType, ShowInfoChange);
            f.ShowDialog();
        }

        private void pb_delStaticData_Click(object sender, EventArgs e)
        {
            if (listView_CaseParameter.SelectedItems.Count > 0)
            {
                foreach(ListViewItem teamItem in listView_CaseParameter.SelectedItems)
                {
                    actuatorStaticDataCollection.RemoveStaticData(teamItem.SubItems[0].Text, false);
                    if (nowEditItem == teamItem)
                    {
                        EditItemChange(null);
                    }
                }
            }
            else
            {
                MessageBox.Show("please select the static data items that your want remove");
            }
        }

        #region public event helper
        private void lb_info_MouseMove(object sender, MouseEventArgs e)
        {
            ((Label)sender).BackColor = Color.LavenderBlush;
        }

        private void lb_info_MouseLeave(object sender, EventArgs e)
        {
            ((Label)sender).BackColor = Color.FromArgb(194, 217, 247);
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
        #endregion


        #region innerFunction
        private void ShowInfoChange(ShowRunTimeParameterType showParameter)
        {
            switch (showParameter)
            {
                case ShowRunTimeParameterType.KeyValue:
                    nowShowType = ShowRunTimeParameterType.KeyValue;
                    lb_info_keyValue.ForeColor = Color.SaddleBrown;
                    lb_info_parameter.ForeColor = lb_info_dataSouce.ForeColor = Color.DarkGray;
                    break;
                case ShowRunTimeParameterType.Parameter:
                    nowShowType = ShowRunTimeParameterType.Parameter;
                    lb_info_parameter.ForeColor = Color.SaddleBrown;
                    lb_info_keyValue.ForeColor = lb_info_dataSouce.ForeColor = Color.DarkGray;
                    break;
                case ShowRunTimeParameterType.DataSouce:
                    nowShowType = ShowRunTimeParameterType.DataSouce;
                    lb_info_dataSouce.ForeColor = Color.SaddleBrown;
                    lb_info_keyValue.ForeColor = lb_info_parameter.ForeColor = Color.DarkGray;
                    break;
                default:
                    MessageBox.Show("nonsupport static data type");
                    break;
            }
            EditItemChange(null);
            UpdatalistView_CaseParameter(true);
        }

        private void EditItemChange(ListViewItem yourEidtItem)
        {
            if (yourEidtItem == null)
            {
                nowEditItem = null;
                tb_keyAdd.Text = tb_valueAdd.Text = "";
                label_info.Text = "please select a data item";
                pb_edit.Enabled = pb_next.Enabled = pb_reset.Enabled = false;
                return;
            }

            nowEditItem = yourEidtItem;
            IRunTimeStaticData editStaticData = null;
            tb_keyAdd.Text = nowEditItem.SubItems[0].Text;
            tb_valueAdd.Text = nowEditItem.SubItems[2].Text;
            switch (nowShowType)
            {
                case ShowRunTimeParameterType.KeyValue:
                    pb_edit.Enabled = true;
                    pb_next.Enabled = pb_reset.Enabled = false;
                    break;
                case ShowRunTimeParameterType.Parameter:
                case ShowRunTimeParameterType.DataSouce:
                    pb_edit.Enabled = pb_next.Enabled = pb_reset.Enabled = true;
                    break;
                default:
                    MessageBox.Show("nonsupport static data type");
                    break;
            }
            editStaticData = nowEditItem.Tag as IRunTimeStaticData;
            if (editStaticData == null)
            {
                label_info.Text = "error data for IRunTimeStaticData";
                pb_edit.Enabled = pb_next.Enabled = pb_reset.Enabled = false;
                return;
            }
            label_info.Text = string.Format("Data Origin : {0} [eg:{1}]", editStaticData.OriginalConnectString, CaseRunTimeDataTypeEngine.dictionaryStaticDataAnnotation[editStaticData.RunTimeStaticDataType][1]); 
        }

        [MethodImplAttribute(MethodImplOptions.Synchronized)]
        public void UpdatalistView_CaseParameter(bool isNew)
        {
            if (isNew)
            {
                MyControlHelper.SetControlFreeze(listView_CaseParameter);
                listView_CaseParameter.BeginUpdate();
                listView_CaseParameter.Items.Clear();
                try
                {
                    //Dictionary<string, IRunTimeStaticData> tempUpdateStaticDataDictionary = null;
                    //Dictionary<string, IRunTimeDataSource> tempUpdateDataSourceDictionary = null;
                    dynamic tempUpdateDictionary = null;
                    switch (nowShowType)
                    {
                        case ShowRunTimeParameterType.KeyValue:
                            tempUpdateDictionary = actuatorStaticDataCollection.RunActuatorStaticDataKeyList;
                            break;
                        case ShowRunTimeParameterType.Parameter:
                            tempUpdateDictionary = actuatorStaticDataCollection.RunActuatorStaticDataParameterList;
                            break;
                        case ShowRunTimeParameterType.DataSouce:
                            tempUpdateDictionary = actuatorStaticDataCollection.RunActuatorStaticDataSouceList;
                            break;
                        default:
                            MessageBox.Show("nonsupport static data type");
                            break;
                    }
                    if (tempUpdateDictionary != null && tempUpdateDictionary.Count > 0)
                    {
                        foreach (var tempKvp in tempUpdateDictionary)
                        {
                            ListViewItem tempItem = new ListViewItem(new string[] { tempKvp.Key, CaseRunTimeDataTypeEngine.dictionaryStaticDataAnnotation[tempKvp.Value.RunTimeStaticDataType][0], tempKvp.Value.DataCurrent() });
                            tempItem.Tag = tempKvp.Value;
                            listView_CaseParameter.Items.Add(tempItem);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                listView_CaseParameter.EndUpdate();
                MyControlHelper.SetControlUnfreeze(listView_CaseParameter);
            }
            else
            {
                foreach (ListViewItem tempItem in listView_CaseParameter.Items)
                {
                    if (actuatorStaticDataCollection.IsHaveSameKey(tempItem.SubItems[0].Text))
                    {
                        IRunTimeStaticData tempStaticData = tempItem.Tag as IRunTimeStaticData;
                        if (tempStaticData != null)
                        {
                            if(tempItem.SubItems[2].Text != tempStaticData.DataCurrent())
                            {
                                tempItem.SubItems[2].Text = tempStaticData.DataCurrent();
                            }
                        }
                        else
                        {
                            UpdatalistView_CaseParameter(true);
                            return;
                        }
                    }
                    else
                    {
                        UpdatalistView_CaseParameter(true);
                        return;
                    }
                }
            }
        }

        #endregion
   
    }
}
