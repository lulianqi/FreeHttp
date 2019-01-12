using FreeHttp.AutoTest.RunTimeStaticData;
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
            KeyValue,
            Parameter,
            DataSouce
        }

        public StaticDataManageWindow(ActuatorStaticDataCollection yourActuatorStaticDataCollection)
        {
            InitializeComponent();
            actuatorStaticDataCollection = yourActuatorStaticDataCollection;
            if (yourActuatorStaticDataCollection != null)
            {
                actuatorStaticDataCollection.OnChangeCollection += actuatorStaticDataCollection_OnChangeCollection;
                //actuatorStaticDataCollection.
            }
        }

        

        ShowRunTimeParameterType nowShowType = ShowRunTimeParameterType.KeyValue;
        ActuatorStaticDataCollection actuatorStaticDataCollection = null;

        public override void VirtualUpdataTime_Tick()
        {
            pb_edit.Enabled = !pb_edit.Enabled;
            UpdatalistView_CaseParameter(false);
        }

        private void StaticDataManageWindow_Load(object sender, EventArgs e)
        {
            
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
                tb_keyAdd.Text = listView_CaseParameter.SelectedItems[0].SubItems[0].Text;
                tb_valueAdd.Text = listView_CaseParameter.SelectedItems[0].SubItems[2].Text;
                switch (nowShowType)
                {
                    case ShowRunTimeParameterType.KeyValue:
                        label_info.Text = string.Format("Data Origin : {0} [eg:{1}]",tb_valueAdd.Text, CaseRunTimeDataTypeEngine.dictionaryStaticDataAnnotation[CaseStaticDataType.caseStaticData_vaule][1]);

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
                        break;
                }
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
                    break;
            }
            UpdatalistView_CaseParameter(true);
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
                    switch (nowShowType)
                    {
                        case ShowRunTimeParameterType.KeyValue:
                            if (actuatorStaticDataCollection.RunActuatorStaticDataKeyList != null && actuatorStaticDataCollection.RunActuatorStaticDataKeyList.Count > 0)
                            {
                                foreach (KeyValuePair<string, string> tempKvp in actuatorStaticDataCollection.RunActuatorStaticDataKeyList)
                                {
                                    ListViewItem tempItem = new ListViewItem(new string[] { tempKvp.Key, CaseRunTimeDataTypeEngine.dictionaryStaticDataAnnotation[CaseStaticDataType.caseStaticData_vaule][1], tempKvp.Value });
                                    tempItem.Tag = tempItem;
                                    listView_CaseParameter.Items.Add(tempItem);
                                }
                            }
                            break;
                        case ShowRunTimeParameterType.Parameter:
                            if (actuatorStaticDataCollection.RunActuatorStaticDataParameterList != null && actuatorStaticDataCollection.RunActuatorStaticDataParameterList.Count > 0)
                            {
                                foreach (KeyValuePair<string, IRunTimeStaticData> tempKvp in actuatorStaticDataCollection.RunActuatorStaticDataParameterList)
                                {
                                    ListViewItem tempItem = new ListViewItem(new string[] { tempKvp.Key, CaseRunTimeDataTypeEngine.dictionaryStaticDataAnnotation[tempKvp.Value.RunTimeStaticDataType][1], tempKvp.Value.DataCurrent() });
                                    tempItem.Tag = tempItem;
                                    listView_CaseParameter.Items.Add(tempItem);
                                }
                            }
                            break;
                        case ShowRunTimeParameterType.DataSouce:
                            foreach (KeyValuePair<string, IRunTimeDataSource> tempKvp in actuatorStaticDataCollection.RunActuatorStaticDataSouceList)
                            {
                                ListViewItem tempItem = new ListViewItem(new string[] { tempKvp.Key, CaseRunTimeDataTypeEngine.dictionaryStaticDataAnnotation[tempKvp.Value.RunTimeStaticDataType][1], tempKvp.Value.DataCurrent() });
                                tempItem.Tag = tempItem;
                                listView_CaseParameter.Items.Add(tempItem);
                            }
                            break;
                        default:
                            //not this way
                            break;
                    }
                }
                catch
                {
                    //RunActuatorStaticDataCollection可能在执行线程中被修改
                }
                listView_CaseParameter.EndUpdate();
                MyControlHelper.SetControlUnfreeze(listView_CaseParameter);
            }
            else
            {
                switch (nowShowType)
                {
                    case ShowRunTimeParameterType.KeyValue:
                        foreach (ListViewItem tempItem in listView_CaseParameter.Items)
                        {
                            if(actuatorStaticDataCollection.RunActuatorStaticDataKeyList.Keys.Contains(((KeyValuePair<string, string>)tempItem.Tag).Key))
                            {
                                tempItem.SubItems[2].Text = actuatorStaticDataCollection.RunActuatorStaticDataKeyList[((KeyValuePair<string, string>)tempItem.Tag).Key];
                            }
                        }
                        break;
                    case ShowRunTimeParameterType.Parameter:
                        foreach (ListViewItem tempItem in listView_CaseParameter.Items)
                        {
                            if (actuatorStaticDataCollection.RunActuatorStaticDataKeyList.Keys.Contains(((KeyValuePair<string, IRunTimeStaticData>)tempItem.Tag).Key))
                            {
                                tempItem.SubItems[2].Text = actuatorStaticDataCollection.RunActuatorStaticDataParameterList[((KeyValuePair<string, IRunTimeStaticData>)tempItem.Tag).Key].DataCurrent();
                            }
                        }
                        break;
                    case ShowRunTimeParameterType.DataSouce:
                        foreach (ListViewItem tempItem in listView_CaseParameter.Items)
                        {
                            if (actuatorStaticDataCollection.RunActuatorStaticDataKeyList.Keys.Contains(((KeyValuePair<string, IRunTimeDataSource>)tempItem.Tag).Key))
                            {
                                tempItem.SubItems[2].Text = actuatorStaticDataCollection.RunActuatorStaticDataParameterList[((KeyValuePair<string, IRunTimeDataSource>)tempItem.Tag).Key].DataCurrent();
                            }
                        }
                        break;
                    default:
                        //not this way
                        break;
                }
            }
        }


        #endregion

        private void pictureBox_add_Click(object sender, EventArgs e)
        {

        }

       
    }
}
