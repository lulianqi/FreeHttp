using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeHttp.AutoTest.RunTimeStaticData.MyStaticData
{
    /// <summary>
    /// 为StaticData提供当前时间的动态数据【IRunTimeStaticData】
    /// </summary>
    public struct MyStaticDataNowTime : IRunTimeStaticData
    {
        string myNowStr;
        string myDataFormatInfo;

        public string RunTimeStaticDataType
        {
            get { return "staticData_time"; }
        }

        public MyStaticDataNowTime(string yourRormatInfo)
        {
            myNowStr = "";
            myDataFormatInfo = yourRormatInfo;
        }

        public object Clone()
        {
            return new MyStaticDataNowTime(myDataFormatInfo);
        }

        public string DataCurrent()
        {
            return myNowStr;
        }

        public string DataMoveNext()
        {
            myNowStr = System.DateTime.Now.ToString(myDataFormatInfo);
            return myNowStr;
        }

        public void DataReset()
        {
            myNowStr = "";
        }


        public bool DataSet(string expectData)
        {
            if (expectData != null)
            {
                myNowStr = expectData;
                return true;
            }
            return false;
        }
    }
}
