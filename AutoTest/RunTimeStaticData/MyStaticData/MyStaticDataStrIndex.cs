using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeHttp.AutoTest.RunTimeStaticData.MyStaticData
{
    /// <summary>
    /// 为StaticData提定长字符串型数字索引支持【IRunTimeStaticData】
    /// </summary>
    public struct MyStaticDataStrIndex : IRunTimeStaticData
    {
        private bool isNew;
        private long dataIndex;
        private long defaultStart;
        private long defaultEnd;
        private long defaultStep;
        private int strLen;

        public string RunTimeStaticDataType
        {
            get { return "staticData_strIndex"; }
        }
        public MyStaticDataStrIndex(long yourStart, long yourEnd, long yourStep, int yourStrLen)
        {
            isNew = true;
            dataIndex = defaultStart = yourStart;
            defaultEnd = yourEnd;
            defaultStep = yourStep;
            strLen = yourStrLen;
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
