using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FreeHttp.AutoTest.RunTimeStaticData.MyStaticData
{
    /// <summary>
    /// 为StaticData提定长字符串型数字索引支持【IRunTimeStaticData】
    /// </summary>
     [DataContract]
    public class MyStaticDataStrIndex : IRunTimeStaticData
    {
         [DataMember]
        private bool isNew;
         [DataMember]
        private long dataIndex;
         [DataMember]
        private long defaultStart;
         [DataMember]
        private long defaultEnd;
         [DataMember]
        private long defaultStep;
         [DataMember]
        private int strLen;

         [DataMember]
        public string OriginalConnectString { get; private set; }
        public string RunTimeStaticDataTypeAlias
        {
            get { return "staticData_strIndex"; }
        }

        public CaseStaticDataType RunTimeStaticDataType
        {
            get { return CaseStaticDataType.caseStaticData_strIndex; }
        }
        public MyStaticDataStrIndex(long yourStart, long yourEnd, long yourStep, int yourStrLen)
        {
            isNew = true;
            dataIndex = defaultStart = yourStart;
            defaultEnd = yourEnd;
            defaultStep = yourStep;
            strLen = yourStrLen;
        }

        public MyStaticDataStrIndex(long yourStart, long yourEnd, long yourStep, int yourStrLen, string originalConnectString)
            : this(yourStart, yourEnd, yourStep, yourStrLen)
        {
            OriginalConnectString = originalConnectString;
        }

        public object Clone()
        {
            return new MyStaticDataStrIndex(defaultStart, defaultEnd, defaultStep, strLen);
        }

        private string GetLenStr(long yourLeng)
        {
            string outStr = yourLeng.ToString();
            int distinction = strLen - outStr.Length;
            if (distinction > 0)
            {
                for (int i = 0; i < distinction; i++)
                {
                    outStr = "0" + outStr;
                }
            }
            return outStr;
        }

        public string DataCurrent()
        {
            return GetLenStr(dataIndex);
        }

        public string DataMoveNext()
        {
            if (isNew)
            {
                isNew = false;
                return GetLenStr(dataIndex);
            }
            if (dataIndex >= defaultEnd)
            {
                DataReset();
                return DataMoveNext();
            }
            else
            {
                dataIndex += defaultStep;
            }
            return GetLenStr(dataIndex);
        }


        public void DataReset()
        {
            isNew = true;
            dataIndex = defaultStart;
        }


        public bool DataSet(string expectData)
        {
            long tempData;
            if (long.TryParse(expectData, out tempData))
            {
                if (tempData >= defaultStart && tempData <= defaultEnd)
                {
                    dataIndex = tempData;
                    return true;
                }
            }
            return false;
        }
        
    }

}
