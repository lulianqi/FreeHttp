using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeHttp.AutoTest
{
    public static class MyExtensionMethods
    {
        /// <summary>
        /// 以指定字符将字符串分割并转换为int(eg: "10-11-12-13")
        /// </summary>
        /// <param name="str">指定字符串</param>
        /// <param name="yourSplitChar">分割字符</param>
        /// <param name="yourIntArray">转换结果</param>
        /// <returns>是否成功（任意一个转换失败都会返回False）</returns>
        public static bool MySplitToIntArray(this string str, char yourSplitChar, out int[] yourIntArray)
        {
            yourIntArray = null;
            if (str == null)
            {
                return false;
            }
            string[] strArray = str.Split(new char[] { yourSplitChar }, StringSplitOptions.None);
            yourIntArray = new int[strArray.Length];
            for (int i = 0; i < strArray.Length; i++)
            {
                if (!int.TryParse(strArray[i], out yourIntArray[i]))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 以指定字符将字符串中末尾int数据提取出来(eg: "testdata-10")
        /// </summary>
        /// <param name="str">指定字符串</param>
        /// <param name="yourSplitChar">分割字符</param>
        /// <param name="yourStr">提取后的前半截字符串</param>
        /// <param name="yourInt">提取后的int</param>
        /// <returns>是否成功 int转换失败后也返回错误</returns>
        public static bool MySplitIntEnd(this string str, char yourSplitChar, out string yourStr, out int yourInt)
        {
            yourStr = null;
            yourInt = 0;
            if (str == null)
            {
                return false;
            }
            if (str.Contains(yourSplitChar))
            {
                int lastSplitCharIndex = str.LastIndexOf(yourSplitChar);
                if (lastSplitCharIndex == str.Length - 1) // 如果使用endwith会产生多余的string对象
                {
                    return false;
                }
                if (int.TryParse(str.Substring(lastSplitCharIndex + 1, str.Length - lastSplitCharIndex - 1), out yourInt))
                {
                    yourStr = str.Substring(0, lastSplitCharIndex);
                    return true;
                }
            }
            return false;
        }


        /// <summary>
        /// 添加键值，若遇到已有key则覆盖
        /// </summary>
        /// <param name="dc">Dictionary</param>
        /// <param name="yourKey">Key</param>
        /// <param name="yourValue">Value</param>
        public static void MyAdd(this Dictionary<string, string> dc, string yourKey, string yourValue)
        {
            if (dc.ContainsKey(yourKey))
            {
                dc[yourKey] = yourValue;
            }
            else
            {
                dc.Add(yourKey, yourValue);
            }
        }

        /// <summary>
        /// 添加键值，若遇到已有key则覆盖
        /// </summary>
        /// <typeparam name="T">T Type</typeparam>
        /// <param name="dc">Dictionary</param>
        /// <param name="yourKey">yourKey</param>
        /// <param name="yourValue">yourValue</param>
        public static void MyAdd<T>(this Dictionary<string, T> dc, string yourKey, T yourValue)
        {
            if (dc.ContainsKey(yourKey))
            {
                dc[yourKey] = yourValue;
            }
            else
            {
                dc.Add(yourKey, yourValue);
            }
        }

        /// <summary>
        /// 【NameValueCollection】添加键值，检查NameValueCollection是否为null
        /// </summary>
        /// <param name="nvc">NameValueCollection</param>
        /// <param name="yourKey">Key</param>
        /// <param name="yourValue">Value</param>
        public static void MyAdd(this NameValueCollection nvc, string yourName, string yourValue)
        {
            if (nvc != null)
            {
                nvc.Add(yourName, yourValue);
            }
        }

        /// <summary>
        ///  转换为{[key:value][key:value].......}
        /// </summary>
        /// <param name="nvc">NameValueCollection</param>
        /// <returns>{[key:value][key:value].......}</returns>
        public static string MyToFormatString(this NameValueCollection nvc)
        {
            if (nvc != null)
            {
                if (nvc.Count > 0)
                {
                    if (nvc.Count < 2)
                    {
                        return string.Format("{{ [{0}:{1}] }}", nvc.Keys[0], nvc[nvc.Keys[0]]);
                    }
                    else
                    {
                        StringBuilder tempStrBld = new StringBuilder("{ ", nvc.Count * 32);
                        foreach (string tempKey in nvc.Keys)
                        {
                            tempStrBld.AppendFormat("[{0}:{1}] ", tempKey, nvc[tempKey]);
                        }
                        tempStrBld.Append("}");
                        return tempStrBld.ToString();
                    }
                }
            }
            return "";
        }

        /// <summary>
        /// 返回对象的深度克隆(泛型数据，要求T必须为值类型，或类似string的特殊引用类型[因为虽然使用string的克隆会有相同的引用，但对string进行修改的时都会创建新的对象])
        /// </summary>
        /// <typeparam name="TKey">TKey</typeparam>
        /// <typeparam name="TValue">TKey</typeparam>
        /// <param name="dc">目标Dictionary</param>
        /// <returns>对象的深度克隆</returns>
        public static Dictionary<TKey, TValue> MyClone<TKey, TValue>(this Dictionary<TKey, TValue> dc)
        {
            Dictionary<TKey, TValue> cloneDc = new Dictionary<TKey, TValue>();
            foreach (KeyValuePair<TKey, TValue> tempKvp in dc)
            {
                cloneDc.Add(tempKvp.Key, tempKvp.Value);
            }
            return cloneDc;
        }

        /// <summary>
        /// 返回对象的深度克隆(泛型数据，要求T必须为值类型，或类似string的特殊引用类型[因为虽然使用string的克隆会有相同的引用，但对string进行修改的时都会创建新的对象](该重载可以约束支持clone的TValue))
        /// </summary>
        /// <typeparam name="TKey">TKey</typeparam>
        /// <typeparam name="TValue">TKey</typeparam>
        /// <param name="dc">目标Dictionary</param>
        /// <returns>对象的深度克隆</returns>
        public static Dictionary<TKey, TValue> MyDeepClone<TKey, TValue>(this Dictionary<TKey, TValue> dc) where TValue : ICloneable
        {
            Dictionary<TKey, TValue> cloneDc = new Dictionary<TKey, TValue>();
            foreach (KeyValuePair<TKey, TValue> tempKvp in dc)
            {
                cloneDc.Add(tempKvp.Key, (TValue)tempKvp.Value.Clone());
            }
            return cloneDc;
        }

        public static Dictionary<string, TTargetValue> ToChangeType<TValue,TTargetValue>(this Dictionary<string, TValue> dc) where TValue : TTargetValue
        {
            if(dc!=null)
            {
                Dictionary<string, TTargetValue> newDc = new Dictionary<string, TTargetValue>();
                foreach(var item in dc)
                {
                    newDc.Add(item.Key, item.Value);
                }
                return newDc;
            }
            return null;
        }

        public static void Add(this List<List<string>> myList, object[] yourValue)
        {
            if(yourValue!=null)
            {
                List<string> tempAddList = new List<string>(yourValue.Length);
                for(int i =0 ; i<yourValue.Length;i++)
                {
                    //tempAddList.Add((yourValue[i] is System.DBNull)?"":(string)yourValue[i]);
                    tempAddList.Add((yourValue[i] is string) ? (string)yourValue[i]:"");
                }
                myList.Add(tempAddList);
            }
        }

    }
}
