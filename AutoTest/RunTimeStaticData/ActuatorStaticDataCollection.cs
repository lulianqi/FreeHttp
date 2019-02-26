using FreeHttp.AutoTest.RunTimeStaticData.MyStaticData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FreeHttp.AutoTest.RunTimeStaticData
{
    /// <summary>
    /// ActuatorStaticData 集合
    /// </summary>
    [DataContract]  //[Serializable] 默认序列化公开字段及属性，且要求其有公开的Set,用[DataContract]指没有这个限制，使用 [DataMember(Name = "ID")] / [DataMember]  标记成员
    [KnownType(typeof(MyStaticDataValue)), KnownType(typeof(MyStaticDataIndex)), KnownType(typeof(MyStaticDataList)), KnownType(typeof(MyStaticDataLong)), KnownType(typeof(MyStaticDataNowTime)), KnownType(typeof(MyStaticDataRandomStr)), KnownType(typeof(MyStaticDataSourceCsv)), KnownType(typeof(MyStaticDataStrIndex))]
    public class ActuatorStaticDataCollection : IDisposable, ICloneable
    {
        public class ChangeDataEventArgs : EventArgs
        {
            public bool IsAddOrDel { get; set; }
            public ChangeDataEventArgs(bool isAddOrDel)
            {
                IsAddOrDel = isAddOrDel;
            }
        }

        [DataMember]
        public bool IsAllCollectionKeyUnique { get; private set; }

        /// <summary>
        /// RunTimeParameter List
        /// </summary>
        [DataMember]
        private Dictionary<string, IRunTimeStaticData> runActuatorStaticDataKeyList;

        /// <summary>
        /// RunTimeStaticData List
        /// </summary>
        [DataMember]
        private Dictionary<string, IRunTimeStaticData> runActuatorStaticDataParameterList;

        /// <summary>
        /// RunTimeDataSouce List
        /// </summary>
        [DataMember]
        private Dictionary<string, IRunTimeDataSource> runActuatorStaticDataSouceList;


        private readonly object padlock = new object();

        public ActuatorStaticDataCollection()
        {
            runActuatorStaticDataKeyList = new Dictionary<string, IRunTimeStaticData>();
            runActuatorStaticDataParameterList = new Dictionary<string, IRunTimeStaticData>();
            runActuatorStaticDataSouceList = new Dictionary<string, IRunTimeDataSource>();
            IsAllCollectionKeyUnique = false;
        }

        public ActuatorStaticDataCollection(bool isAllCollectionKeyUnique):this()
        {
            IsAllCollectionKeyUnique = isAllCollectionKeyUnique;
        }

        public ActuatorStaticDataCollection(Dictionary<string, IRunTimeStaticData> yourActuatorParameterList, Dictionary<string, IRunTimeStaticData> yourActuatorStaticDataList, Dictionary<string, IRunTimeDataSource> yourActuatorStaticDataSouceList)
        {
            runActuatorStaticDataKeyList = yourActuatorParameterList;
            runActuatorStaticDataParameterList = yourActuatorStaticDataList;
            runActuatorStaticDataSouceList = yourActuatorStaticDataSouceList;
            IsAllCollectionKeyUnique = false;
        }

        //public event EventHandler OnChangeCollection;
        public delegate void ChangeCollectionEventHandler(object sender, ChangeDataEventArgs e);
        public event ChangeCollectionEventHandler OnChangeCollection;

        private void OnListChanged(bool isAddOrDel)
        {
            if(OnChangeCollection!=null)
            {
                this.OnChangeCollection(this, new ChangeDataEventArgs(isAddOrDel));
            }
        }

        public Dictionary<string, IRunTimeStaticData> RunActuatorStaticDataKeyList
        {
            get { return runActuatorStaticDataKeyList; }
        }

        public Dictionary<string, IRunTimeStaticData> RunActuatorStaticDataParameterList
        {
            get { return runActuatorStaticDataParameterList; }
        }

        public Dictionary<string, IRunTimeDataSource> RunActuatorStaticDataSouceList
        {
            get { return runActuatorStaticDataSouceList; }
        }


        private object IsHasSameKey(string key, int ignoreListIndex)
        {
            if (runActuatorStaticDataKeyList.ContainsKey(key) && ignoreListIndex != 1)
            {
                return runActuatorStaticDataKeyList;
            }
            if (runActuatorStaticDataParameterList.ContainsKey(key) && ignoreListIndex != 2)
            {
                return runActuatorStaticDataParameterList;
            }
            if (runActuatorStaticDataSouceList.ContainsKey(key) && ignoreListIndex != 3)
            {
                return runActuatorStaticDataSouceList;
            }
            return null;
        }

        /// <summary>
        /// Is the StaticDataCollection has th same key name 
        /// </summary>
        /// <param name="yourKey">your Key</param>
        /// <returns>is has </returns>
        public bool IsHaveSameKey(string yourKey)
        {
            return (IsHasSameKey(yourKey, 0) != null);
        }

        /// <summary>
        /// Add Data into runActuatorStaticDataKeyList (if DataParameter or DataSouce has same key retrun false , if DataKey has same key cover the vaule)
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="vaule">vaule</param>
        /// <returns>is success</returns>
        [MethodImplAttribute(MethodImplOptions.Synchronized)]
        public bool AddStaticDataKey(string key, IRunTimeStaticData vaule)
        {
            //if (!(vaule is MyStaticDataValue))
            //{
            //    return false;
            //}
            if (IsHasSameKey(key, IsAllCollectionKeyUnique?0:1) != null)
            {
                if (!RemoveStaticData(key, false))
                {
                    return false;
                }
            }
            runActuatorStaticDataKeyList.MyAdd(key, vaule);
            OnListChanged(true);
            return true;
        }

        /// <summary>
        /// Add Data into runActuatorStaticDataParameterList (if DataKey or DataSouce has same key retrun false , if DataParameter has same key cover the vaule) 
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="vaule">vaule</param>
        /// <returns>is success</returns>
        [MethodImplAttribute(MethodImplOptions.Synchronized)]
        public bool AddStaticDataParameter(string key, IRunTimeStaticData vaule)
        {
            if (IsHasSameKey(key, IsAllCollectionKeyUnique ? 0 : 2) != null)
            {
                if (!RemoveStaticData(key, false))
                {
                    return false;
                }
            }
            runActuatorStaticDataParameterList.MyAdd<IRunTimeStaticData>(key, vaule);
            OnListChanged(true);
            return true;
        }

        /// <summary>
        /// Add Data into runActuatorStaticDataSouceList (if DataKey or DataParameter has same key retrun false , if DataSouce has same key cover the vaule)
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="vaule">vaule</param>
        /// <returns>is success</returns>
        [MethodImplAttribute(MethodImplOptions.Synchronized)]
        public bool AddStaticDataSouce(string key, IRunTimeDataSource vaule)
        {
            if (IsHasSameKey(key, IsAllCollectionKeyUnique ? 0 : 3) != null)
            {
                if (!RemoveStaticData(key, false))
                {
                    return false;
                }
            }
            runActuatorStaticDataSouceList.MyAdd<IRunTimeDataSource>(key, vaule);
            OnListChanged(true);
            return true;
        }

        /// <summary>
        /// Remove Static Data in any list (if there not has any same key retrun false)
        /// </summary>
        /// <param name="key">key or Regex</param>
        /// <param name="isRegex">is use Regex</param>
        /// <returns>is success</returns>
        [MethodImplAttribute(MethodImplOptions.Synchronized)]
        public bool RemoveStaticData(string key, bool isRegex)
        {
            if (!isRegex)
            {
                var tempDataList = IsHasSameKey(key, 0);
                if (tempDataList == null)
                {
                    return false;
                }
                else if (tempDataList == runActuatorStaticDataKeyList)
                {
                    runActuatorStaticDataKeyList.Remove(key);
                }
                else if (tempDataList == runActuatorStaticDataParameterList)
                {
                    runActuatorStaticDataParameterList.Remove(key);
                }
                else if (tempDataList == runActuatorStaticDataSouceList)
                {
                    runActuatorStaticDataSouceList.Remove(key);
                }
                else
                {
                    //ErrorLog.PutInLog(string.Format("error to [RemoveStaticData] in ActuatorStaticDataCollection  the key is {0} ", key));
                    return false;
                }
            }
            else
            {
                try
                {
                    bool isFindAndRegexKey = false;
                    System.Text.RegularExpressions.Regex sr;
                    sr = new System.Text.RegularExpressions.Regex(key, System.Text.RegularExpressions.RegexOptions.None);
                    List<string> dataToDel = new List<string>();

                    foreach (var tempKey in runActuatorStaticDataKeyList.Keys)
                    {
                        if (sr.IsMatch(tempKey))
                        {
                            dataToDel.Add(tempKey);
                        }
                    }
                    foreach (string tempKey in dataToDel)
                    {
                        runActuatorStaticDataKeyList.Remove(tempKey);
                    }
                    if (dataToDel.Count > 0)
                    {
                        isFindAndRegexKey = true;
                        dataToDel.Clear();
                    }

                    foreach (var tempKey in runActuatorStaticDataParameterList.Keys)
                    {
                        if (sr.IsMatch(tempKey))
                        {
                            dataToDel.Add(tempKey);
                        }
                    }
                    foreach (string tempKey in dataToDel)
                    {
                        runActuatorStaticDataParameterList.Remove(tempKey);
                    }
                    if (dataToDel.Count > 0)
                    {
                        isFindAndRegexKey = true;
                        dataToDel.Clear();
                    }

                    foreach (var tempKey in runActuatorStaticDataSouceList.Keys)
                    {
                        if (sr.IsMatch(tempKey))
                        {
                            dataToDel.Add(tempKey);
                        }
                    }
                    foreach (string tempKey in dataToDel)
                    {
                        runActuatorStaticDataSouceList.Remove(tempKey);
                    }
                    if (dataToDel.Count > 0)
                    {
                        isFindAndRegexKey = true;
                        dataToDel.Clear();
                    }

                    if (!isFindAndRegexKey)
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    //ErrorLog.PutInLog(ex);
                    return false;
                }

            }
            OnListChanged(true);
            return true;
        }

        /// <summary>
        /// set or change data in any list
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="configVaule">config Vaule</param>
        /// <returns>is success</returns>
        [MethodImplAttribute(MethodImplOptions.Synchronized)]
        public bool SetStaticDataValue(string key, string configVaule)
        {
            var tempDataList = GetStaticData(key, 0);
            if (tempDataList == null)
            {
                return false;
            }
            if (tempDataList.DataSet(configVaule))
            {
                OnListChanged(false);
                return true;
            }
            return false;
        }

        public IRunTimeStaticData GetStaticData(string key ,int GetListIndex)
        {
            if (runActuatorStaticDataKeyList.ContainsKey(key) && (GetListIndex == 1 || GetListIndex == 0))
            {
                return runActuatorStaticDataKeyList[key];
            }
            if (runActuatorStaticDataParameterList.ContainsKey(key) && (GetListIndex == 1 || GetListIndex == 0))
            {
                return runActuatorStaticDataParameterList[key];
            }
            if (runActuatorStaticDataSouceList.ContainsKey(key) && (GetListIndex == 1 || GetListIndex == 0))
            {
                return runActuatorStaticDataSouceList[key];
            }
            return null;
        }

        public IRunTimeStaticData this[string key]
        {
            get
            {
                return GetStaticData(key, 0);
            }
            set
            {
                var tempDataList = IsHasSameKey(key, 0);
                if (tempDataList == null)
                {
                    throw new Exception("ActuatorStaticDataCollection do not have this key");
                }
                else if (tempDataList == runActuatorStaticDataKeyList )
                {
                    if (value is MyStaticDataValue)
                    {
                        runActuatorStaticDataKeyList[key] = value;
                    }
                    else
                    {
                        throw new Exception("this StaticData must be a MyStaticDataValue");
                    }
                }
                else if (tempDataList == runActuatorStaticDataParameterList)
                {
                    runActuatorStaticDataParameterList[key] = value;
                }
                else if (tempDataList == runActuatorStaticDataSouceList )
                {
                    if (value is IRunTimeDataSource)
                    {
                        runActuatorStaticDataSouceList[key] = (IRunTimeDataSource)value;
                    }
                    else
                    {
                        throw new Exception("this StaticData must be a IRunTimeDataSource");
                    }
                }
                else
                {
                    throw new Exception("nuknow DataSource");
                }
                OnListChanged(false);
            }
        }

        public object Clone()
        {
            return new ActuatorStaticDataCollection(runActuatorStaticDataKeyList.MyDeepClone(), runActuatorStaticDataParameterList.MyDeepClone(), runActuatorStaticDataSouceList.MyDeepClone());
        }

        public void Dispose()
        {
            runActuatorStaticDataKeyList.Clear();
            runActuatorStaticDataParameterList.Clear();
            runActuatorStaticDataSouceList.Clear();
        }

    }
}
