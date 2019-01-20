using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeHttp.AutoTest.RunTimeStaticData
{
    public static class RunTimeStaticDataHelper
    {
        public static bool AddStaticDataToCollection(ActuatorStaticDataCollection actuatorStaticDataCollection, CaseStaticDataType dataType, string staticDataKey, string staticDataVaule, out string errorMes)
        {
            errorMes = null;
            if (actuatorStaticDataCollection==null)
            {
                errorMes = "your ActuatorStaticDataCollection is null";
                return false;
            }

            if (actuatorStaticDataCollection.IsHaveSameKey(staticDataKey))
            {
                errorMes = (string.Format("find same key 【{0}】in RunTimeParameter with [ CaseStaticDataClass.caseStaticDataKey] in - ScriptRunTime ,and will drop this key", staticDataKey));
                return false;
            }

            switch(CaseRunTimeDataTypeEngine.dictionaryStaticDataTypeClass[dataType])
            {
                case CaseStaticDataClass.caseStaticDataKey:
                    if (dataType == CaseStaticDataType.caseStaticData_vaule)
                    {
                        if (!actuatorStaticDataCollection.AddStaticDataKey(staticDataKey, new FreeHttp.AutoTest.RunTimeStaticData.MyStaticData.MyStaticDataValue(staticDataVaule)))
                        {
                            errorMes = (string.Format("can not add {0} into ActuatorStaticDataCollection", staticDataKey));
                            return false;
                        }
                        //runActuatorStaticDataCollection.RunActuatorStaticDataKeyList.MyAdd(new KeyValuePair<string, string>());
                    }
                    else
                    {
                        throw new Exception(string.Format("find nonsupport Protocol 【{0}】with [ CaseStaticDataClass.caseStaticDataKey] in - ScriptRunTime ", dataType));
                    }
                    break;
                case CaseStaticDataClass.caseStaticDataParameter:
                    IRunTimeStaticData tempRunTimeStaticData;
                    string tempTypeError;
                    if (CaseRunTimeDataTypeEngine.dictionaryStaticDataParameterAction[dataType](out tempRunTimeStaticData, out tempTypeError, staticDataVaule))
                    {
                        if (!actuatorStaticDataCollection.AddStaticDataParameter(staticDataKey, tempRunTimeStaticData))
                        {
                            errorMes = (string.Format("can not add {0} into ActuatorStaticDataCollection", staticDataKey));
                            return false;
                        }
                        //runActuatorStaticDataCollection.RunActuatorStaticDataParameterList.MyAdd(tempName, tempRunTimeStaticData);
                    }
                    else
                    {
                        errorMes = string.Format("find error in 【RunTimeStaticData】->【{0}】:value:【{1}】 by {2}", staticDataKey, staticDataVaule, tempTypeError);
                        return false;
                    }
                    break;
                case CaseStaticDataClass.caseStaticDataSource:
                    IRunTimeDataSource tempRunTimeDataSource;
                    if (CaseRunTimeDataTypeEngine.dictionaryStaticDataSourceAction[dataType](out tempRunTimeDataSource, out tempTypeError, staticDataVaule))
                    {
                        if (!actuatorStaticDataCollection.AddStaticDataSouce(staticDataKey, tempRunTimeDataSource))
                        {
                            errorMes = (string.Format("can not add {0} into ActuatorStaticDataCollection", staticDataKey));
                            return false;
                        }
                        //runActuatorStaticDataCollection.RunActuatorStaticDataSouceList.MyAdd<IRunTimeDataSource>(tempName, tempRunTimeDataSource);
                    }
                    else
                    {
                        errorMes = (string.Format("find error in 【RunTimeStaticData】->【{0}】:value:【{1}】 by {2}", staticDataKey, staticDataVaule, tempTypeError));
                        return false;
                    }
                    break;
                default:
                    throw new Exception(" find nonsupport CaseStaticDataClass");
            }
            return true;
        }
    }
}
