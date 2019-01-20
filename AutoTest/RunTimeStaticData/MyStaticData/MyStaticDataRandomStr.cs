using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FreeHttp.AutoTest.RunTimeStaticData.MyStaticData
{
    /// <summary>
    /// 为StaticData提供随机字符串动态数据【IRunTimeStaticData】
    /// </summary>
     [DataContract]
    public class MyStaticDataRandomStr : IRunTimeStaticData
    {
         [DataMember]
        string myNowStr;
         [DataMember]
        int myStrNum;
         [DataMember]
        int myStrType;

         [DataMember]
        public string OriginalConnectString { get; private set; }
        public string RunTimeStaticDataTypeAlias
        {
            get { return "staticData_random"; }
        }
        public CaseStaticDataType RunTimeStaticDataType
        {
            get { return CaseStaticDataType.caseStaticData_random; }
        }
        public MyStaticDataRandomStr(int yourStrNum, int yourStrType)
        {
            myNowStr = "";
            myStrNum = yourStrNum;
            myStrType = yourStrType;
        }

        public MyStaticDataRandomStr(int yourStrNum, int yourStrType, string originalConnectString)
            : this(yourStrNum, yourStrType)
        {
            OriginalConnectString = originalConnectString;
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
