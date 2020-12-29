using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeHttp.MyHelper
{
    public class MyJsonHelper
    {
        public class JsonDataContractJsonSerializer
        {
            /// <summary>
            /// 使用.net内置方法将对象序列号为str 对象需要使用[System.Runtime.Serialization.DataContract()]标记
            /// </summary>
            /// <param name="obj"></param>
            /// <returns></returns>
            public static string ObjectToJsonStr(object obj)
            {
                System.Runtime.Serialization.Json.DataContractJsonSerializer serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(obj.GetType());
                using (MemoryStream stream = new MemoryStream())
                {
                    serializer.WriteObject(stream, obj);
                    using (StreamReader sr = new StreamReader(stream))
                    {
                        stream.Position = 0;
                        return sr.ReadToEnd();
                    }
                }
            }

            public static Stream ObjectToJsonStream(object obj)
            {
                System.Runtime.Serialization.Json.DataContractJsonSerializer serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(obj.GetType());
                MemoryStream stream = new MemoryStream();
                serializer.WriteObject(stream, obj);
                return stream;
            }

            public static T JsonStringToObject<T>(string str)
            {
                T serializeClass = default(T);
                System.Runtime.Serialization.Json.DataContractJsonSerializer ser = new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(T));
                try
                {
                    using (MemoryStream ms = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(str)))
                    {
                        serializeClass = (T)ser.ReadObject(ms);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    serializeClass = default(T);
                }
                finally
                {

                }
                return serializeClass;
            }

            public static T JsonStreamToObject<T>(Stream jsonStream)
            {
                T serializeClass = default(T);
                System.Runtime.Serialization.Json.DataContractJsonSerializer ser = new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(T));
                try
                {
                    jsonStream.Position = 0;
                    serializeClass = (T)ser.ReadObject(jsonStream);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    serializeClass = default(T);
                }
                finally
                {

                }
                return serializeClass;
            }
        }
    }
}
