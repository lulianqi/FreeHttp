using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace FreeHttp.AutoTest.RunTimeStaticData.MyStaticData
{
     [DataContract]
    public class MyStaticDataValue : IRunTimeStaticData
    {
         [DataMember]
        private string defaultValue;

         [DataMember]
        public string OriginalConnectString { get;private set; }


        public string RunTimeStaticDataTypeAlias
        {
            get { return "staticData_value"; }
        }
        public CaseStaticDataType RunTimeStaticDataType
        {
            get { return CaseStaticDataType.caseStaticData_vaule; }
        }


        public MyStaticDataValue(string yourVaule)
        {
            defaultValue=OriginalConnectString=yourVaule;
        }


        public object Clone()
        {
            return new MyStaticDataValue(defaultValue);
        }


        public string DataCurrent()
        {
            return defaultValue;
        }

        public string DataMoveNext()
        {
            return defaultValue;
        }


        public void DataReset()
        {
            
        }


        public bool DataSet(string expectData)
        {
            if (expectData!=null)
            {
                defaultValue = expectData;
                return true;
            }
            return false;
        }

    }
}
