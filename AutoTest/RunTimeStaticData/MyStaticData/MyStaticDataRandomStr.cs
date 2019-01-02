using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeHttp.AutoTest.RunTimeStaticData.MyStaticData
{
    /// <summary>
    /// 为StaticData提供随机字符串动态数据【IRunTimeStaticData】
    /// </summary>
    public struct MyStaticDataRandomStr : IRunTimeStaticData
    {
        string myNowStr;
        int myStrNum;
        int myStrType;

        public string RunTimeStaticDataType
        {
            get { return "staticData_random"; }
        }

        public MyStaticDataRandomStr(int yourStrNum, int yourStrType)
        {
            myNowStr = "";
            myStrNum = yourStrNum;
            myStrType = yourStrType;
        }

        public object Clone()
        {
            return new MyStaticDataRandomStr(myStrNum, myStrType);
        }

        public string DataCurrent()
        {
            return myNowStr;
        }

        public string DataMoveNext()
        {
            myNowStr = MyCommonTool.GenerateRandomStr(myStrNum, myStrType);
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
