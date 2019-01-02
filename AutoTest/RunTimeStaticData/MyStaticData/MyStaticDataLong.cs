using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeHttp.AutoTest.RunTimeStaticData.MyStaticData
{
    /// <summary>
    /// 为StaticData提供长数字索引支持【IRunTimeStaticData】
    /// </summary>
    public struct MyStaticDataLong : IRunTimeStaticData
    {
        private bool isNew;
        private long dataIndex;
        private long defaultStart;
        private long defaultEnd;
        private long defaultStep;

        public string RunTimeStaticDataType
        {
            get { return "staticData_long"; }
        }
        public MyStaticDataLong(long yourStart, long yourEnd, long yourStep)
        {
            isNew = true;
            dataIndex = defaultStart = yourStart;
            defaultEnd = yourEnd;
            defaultStep = yourStep;
        }

        public object Clone()
        {
            return new MyStaticDataLong(defaultStart, defaultEnd, defaultStep);
        }


        public string DataCurrent()
        {
            return dataIndex.ToString();
        }

        public string DataMoveNext()
        {
            if (isNew)
            {
                isNew = false;
                return dataIndex.ToString();
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
            return dataIndex.ToString();
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
