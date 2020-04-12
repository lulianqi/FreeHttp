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
        }
    }
}
