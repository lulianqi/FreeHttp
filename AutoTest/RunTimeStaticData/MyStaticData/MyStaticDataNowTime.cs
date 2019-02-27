using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FreeHttp.AutoTest.RunTimeStaticData.MyStaticData
{
    /// <summary>
    /// 为StaticData提供当前时间的动态数据【IRunTimeStaticData】
    /// </summary>
     [DataContract]
    public class MyStaticDataNowTime : IRunTimeStaticData
    {
         [DataMember]
        string myNowStr;
         [DataMember]
        string myDataFormatInfo;
         [DataMember]
        int timestampFormatdividend;

         [DataMember]
        public string OriginalConnectString { get; private set; }
        public string RunTimeStaticDataTypeAlias
        {
            get { return "staticData_time"; }
        }
        public CaseStaticDataType RunTimeStaticDataType
        {
            get { return CaseStaticDataType.caseStaticData_time; }
        }
        public MyStaticDataNowTime(string yourRormatInfo)
        {
            myNowStr = "";
            if (int.TryParse(yourRormatInfo, out timestampFormatdividend))
            {
                if(timestampFormatdividend<=0)
                {
                    timestampFormatdividend = 0;
                    myDataFormatInfo = "";
                }
            }
            else
            {
                myDataFormatInfo = yourRormatInfo;
            }
        }

        public MyStaticDataNowTime(string yourRormatInfo, string originalConnectString)
            : this(yourRormatInfo)
        {
            OriginalConnectString = originalConnectString;
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
            if (timestampFormatdividend == 0)
            {
                myNowStr = System.DateTime.Now.ToString(myDataFormatInfo);
            }
            else
            {
                myNowStr = ((DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / timestampFormatdividend).ToString();
            }
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
