using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FreeHttp.AutoTest.RunTimeStaticData.MyStaticData
{
    /// <summary>
    /// 为StaticData提供长数字索引支持【IRunTimeStaticData】
    /// </summary>
     [DataContract]
    public class MyStaticDataLong : IRunTimeStaticData
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
        public string OriginalConnectString { get; private set; }
        public string RunTimeStaticDataTypeAlias
        {
            get { return "staticData_long"; }
        }
        public CaseStaticDataType RunTimeStaticDataType
        {
            get { return CaseStaticDataType.caseStaticData_long; }
        }
        public MyStaticDataLong(long yourStart, long yourEnd, long yourStep)
        {
            isNew = true;
            dataIndex = defaultStart = yourStart;
            defaultEnd = yourEnd;
            defaultStep = yourStep;
        }

        public MyStaticDataLong(long yourStart, long yourEnd, long yourStep, string originalConnectString)
            : this(yourStart, yourEnd, yourStep)
        {
            OriginalConnectString = originalConnectString;
        }

        public object Clone()
        {
            return new MyStaticDataLong(defaultStart, defaultEnd, defaultStep);
        }


        public string DataCurrent()
        {
            return dataIndex.ToString();
        }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
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
                //lock(this)
                //{
                    dataIndex += defaultStep;
                //}
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
