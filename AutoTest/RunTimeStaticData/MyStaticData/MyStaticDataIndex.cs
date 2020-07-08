using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FreeHttp.AutoTest.RunTimeStaticData.MyStaticData
{
    /// <summary>
    /// 为StaticData提供类似索引递增的动态数据【IRunTimeStaticData】
    /// </summary>
    [DataContract]
    public class MyStaticDataIndex : IRunTimeStaticData
    {
        [DataMember]
        private bool isNew;
        [DataMember]
        private int dataIndex;
        [DataMember]
        private int defaultStart;
        [DataMember]
        private int defaultEnd;
        [DataMember]
        private int defaultStep;

        [DataMember]
        public string OriginalConnectString { get; private set; }
        public string RunTimeStaticDataTypeAlias
        {
            get { return "staticData_index"; }
        }
        public CaseStaticDataType RunTimeStaticDataType
        {
            get { return CaseStaticDataType.caseStaticData_index; }
        }
        public MyStaticDataIndex(int yourStart, int yourEnd, int yourStep)
        {
            isNew = true;
            dataIndex = defaultStart = yourStart;
            defaultEnd = yourEnd;
            defaultStep = yourStep;
        }

        public MyStaticDataIndex(int yourStart, int yourEnd, int yourStep, string originalConnectString)
            : this(yourStart, yourEnd, yourStep)
        {
            OriginalConnectString = originalConnectString;
        }

        public object Clone()
        {
            return new MyStaticDataIndex(defaultStart, defaultEnd, defaultStep);
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
            int tempData;
            if (int.TryParse(expectData, out tempData))
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
