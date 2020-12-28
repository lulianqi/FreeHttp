using FreeHttp.FiddlerHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FreeHttp.MyHelper
{
    public static class MyExtensionMethods
    {
        public static List<T> MyClone<T>(this List<T> list)
        {
            List<T> returnList = new List<T>();
            //foreach(var tempVaule in list)
            //{
            //    returnList.Add(tempVaule);
            //}
            returnList.AddRange(list);
            return returnList;
        }

        public static T MyDeepClone<T>(this T source) where T : IFiddlerHttpTamper
        {
            if (!typeof(T).IsSerializable)
            {
                throw new ArgumentException("Your type must be serializable.", "source");
            }
            T cloneObj = default;
            using (Stream jsonStream = MyJsonHelper.JsonDataContractJsonSerializer.ObjectToJsonStream(source))
            {
                cloneObj = MyJsonHelper.JsonDataContractJsonSerializer.JsonStreamToObject<T>(jsonStream);
            }
            return cloneObj;
        }

        public static bool MyContains<T>(this List<T> list, T item)
        {
            if (item == null)
            {
                for (int j = 0; j < list.Count; j++)
                {
                    if (list[j] == null)
                    {
                        return true;
                    }
                }
                return false;
            }

            Type c = typeof(T);
            if (c == typeof(MyKeyValuePair<string, string>))
            {
                for (int j = 0; j < list.Count; j++)
                {
                    if((list[j]).Equals(item))
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                return list.Contains(item);
            }
        }
    }
}
