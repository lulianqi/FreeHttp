using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeHttp.AutoTest.RunTimeStaticData.MyStaticData
{
    /// <summary>
    ///  为StaticData提供当基于List的列表数据支持据【IRunTimeStaticData】
    /// </summary>
    public class MyStaticDataList : IRunTimeStaticData
    {
        private bool isNew;
        private string souseData;
        private List<string> souseListData;
        private int nowIndex;
        private bool isRandom;
        private Random ran;

        public string OriginalConnectString { get;private set; }
        public string RunTimeStaticDataTypeAlias
        {
            get { return "staticData_list"; }
        }
        public CaseStaticDataType RunTimeStaticDataType
        {
            get { return CaseStaticDataType.caseStaticData_list; }
        }
        public MyStaticDataList(string yourSourceData, bool isRandomNext)
        {
            isNew = true;
            souseData = yourSourceData;
            souseListData = yourSourceData.Split(',').ToList();
            nowIndex = 0;
            isRandom = isRandomNext;
            if (isRandom)
            {
                ran = new Random();
            }
            else
            {
                ran = null;
            }
        }

        public MyStaticDataList(string yourSourceData, bool isRandomNext, string originalConnectString)
            : this(yourSourceData, isRandomNext)
        {
            OriginalConnectString = originalConnectString;
        }

        public object Clone()
        {
            return new MyStaticDataList(souseData, isRandom);
        }

        public string DataCurrent()
        {
            return souseListData[nowIndex];
        }

        public string DataMoveNext()
        {
            if (isRandom)
            {
                nowIndex = ran.Next(0, souseListData.Count - 1);
                return souseListData[nowIndex];
            }
            else
            {
                if (isNew)
                {
                    isNew = false;
                }
                else
                {
                    nowIndex++;
                    if (nowIndex > (souseListData.Count - 1))
                    {
                        nowIndex = 0;
                    }
                }
                return souseListData[nowIndex];
            }
        }

        public void DataReset()
        {
            isNew = true;
            nowIndex = 0;
        }

        public bool DataSet(string expectData)
        {
            if (souseListData.Contains(expectData))
            {
                nowIndex = souseListData.IndexOf(expectData);
            }
            return false;
        }
    }
}
