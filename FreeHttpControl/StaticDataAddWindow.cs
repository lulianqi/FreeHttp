using FreeHttp.AutoTest.RunTimeStaticData;
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
    public partial class StaticDataAddWindow : MyBaseInfoWindow
    {
        public StaticDataAddWindow(ActuatorStaticDataCollection yourActuatorStaticDataCollection, int yourIndex)
        {
            InitializeComponent();
            actuatorStaticDataCollection = yourActuatorStaticDataCollection;
            startIndex = yourIndex;
        }

        ActuatorStaticDataCollection actuatorStaticDataCollection = null;
        BindingSource bs_DataClass = new BindingSource();
        int startIndex;
        //BindingSource bs_DataType = new BindingSource();
        private void StaticDataAdd_Load(object sender, EventArgs e)
        {
            bs_DataClass.DataSource = CaseRunTimeDataTypeEngine.dictionaryStaticDataTypeSource;
            comboBox_CaseStaticDataClass.DataSource = bs_DataClass;
            comboBox_CaseStaticDataClass.DisplayMember = "Key";
            //comboBox_CaseStaticDataClass.ValueMember = "Value";
            try
            {
                comboBox_CaseStaticDataClass.SelectedIndex = startIndex;
            }
            catch
            {
                comboBox_CaseStaticDataClass.SelectedIndex = 0;
            }
            if(actuatorStaticDataCollection==null)
            {
                MessageBox.Show("actuatorStaticDataCollection is null");
                this.Close();
            }
        }

        private void comboBox_CaseStaticDataClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox_CaseStaticDataType.DataSource = ((KeyValuePair<CaseStaticDataClass, List<CaseStaticDataType>>)comboBox_CaseStaticDataClass.SelectedItem).Value;
        }

        private void comboBox_CaseStaticDataType_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> tempInfoList = CaseRunTimeDataTypeEngine.dictionaryStaticDataAnnotation[(CaseStaticDataType)comboBox_CaseStaticDataType.SelectedItem];
            lb_info_2.Text = string.Format("【{4}】:{0}\r\n【Data Format】: [{1}] [eg: {2}]\r\n{3}",tempInfoList[4],tempInfoList[1],tempInfoList[2],tempInfoList[3],tempInfoList[0]);
            tb_value.WatermarkText = tempInfoList[1];
        }

        private void pb_confirm_Click(object sender, EventArgs e)
        {
            if(tb_key.Text==""|| tb_value.Text=="")
            {
                MessageBox.Show("the key or the value is empty ,please set it", "stop", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FreeHttpWindow.MarkWarnControl(tb_key);
                FreeHttpWindow.MarkWarnControl(tb_value);
                return;
            }
            if(actuatorStaticDataCollection.IsHaveSameKey(tb_key.Text))
            {
                //DialogResult tempDs;
                if (MessageBox.Show(string.Format("find the same data name in your data list ,do you want delete that repetitive data [{0}] fist", tb_key.Text), "Same Name", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Cancel)
                {
                    return;
                }
                actuatorStaticDataCollection.RemoveStaticData(tb_key.Text, false);
            }
            string errMes=null;
            if(!RunTimeStaticDataHelper.AddStaticDataToCollection(actuatorStaticDataCollection, (CaseStaticDataType)comboBox_CaseStaticDataType.SelectedItem, tb_key.Text, tb_value.Text,out errMes))
            {
                MessageBox.Show(string.Format("add static data fail \r\n{0}",string.IsNullOrEmpty(errMes)?"unknow error":errMes), "stop", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FreeHttpWindow.MarkWarnControl(tb_value);
                return;
            }
            this.Close();
        }
    }
}
