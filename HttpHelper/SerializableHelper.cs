using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace FreeHttp.HttpHelper
{
    class SerializableHelper
    {
        public static void SerializeRuleList(ListView requestRuleListView, ListView reponseRuleListView)
        {
            if (requestRuleListView != null && reponseRuleListView!=null)
            {
                //dynamic
                List<FiddlerRequsetChange> requestList = new List<FiddlerRequsetChange>();
                List<FiddlerResponseChange> responseList = new List<FiddlerResponseChange>();
                foreach (ListViewItem tempItem in requestRuleListView.Items)
                {
                    requestList.Add((FiddlerRequsetChange)tempItem.Tag);
                }
                foreach (ListViewItem tempItem in reponseRuleListView.Items)
                {
                    responseList.Add((FiddlerResponseChange)tempItem.Tag);
                }
                //Stream stream = File.Open("data.xml", FileMode.Create);
                TextWriter writer = new StreamWriter("RuleData.xml", false);
                XmlSerializer serializer = new XmlSerializer(typeof(FiddlerModificHttpRuleCollection));
                //serializer = new XmlSerializer(typeof(List<IFiddlerHttpTamper>));
                serializer.Serialize(writer, new FiddlerModificHttpRuleCollection(requestList, responseList));
                writer.Close();
            }
        }

        public static FiddlerModificHttpRuleCollection DeserializeRuleList()
        {
            FiddlerModificHttpRuleCollection fiddlerModificHttpRuleCollection = null;
            if (File.Exists("RuleData.xml"))
            {
                XmlSerializer mySerializer = new XmlSerializer(typeof(FiddlerModificHttpRuleCollection));
                FileStream myFileStream = new FileStream("RuleData.xml", FileMode.Open);
                try
                {
                    fiddlerModificHttpRuleCollection = (FiddlerModificHttpRuleCollection)mySerializer.Deserialize(myFileStream);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(string.Format("{0}\r\n{1}", ex.Message, ex.Message, ex.InnerException == null ? "" : ex.InnerException.Message), "load user rule fail");
                    File.Copy("RuleData.xml", "RuleData.lastErrorFile",true);
                }
                finally
                {
                    myFileStream.Close();
                }
            }
            return fiddlerModificHttpRuleCollection;
        }

        public static void SerializeData<T>(T modificSettingInfo, string filePath)
        {
            if (modificSettingInfo != null)
            {
                TextWriter writer = new StreamWriter(filePath, false);
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                //serializer = new XmlSerializer(typeof(List<IFiddlerHttpTamper>));
                serializer.Serialize(writer, modificSettingInfo);
                writer.Close();
            }
        }

        public static T DeserializeData<T>(string filePath)
        {
            T modificSettingInfo = default(T); //对于数值类型会返回零。 对于结构，此关键字将返回初始化为零或 null 的每个结构成员，具体取决于这些结构是值类型还是引用类型,对于数值类型会返回零。 对于结构，此关键字将返回初始化为零或 null 的每个结构成员，具体取决于这些结构是值类型还是引用类型
            if (File.Exists(filePath))
            {
                XmlSerializer mySerializer = new XmlSerializer(typeof(T));
                FileStream myFileStream = new FileStream(filePath, FileMode.Open);
                try
                {
                    modificSettingInfo = (T)mySerializer.Deserialize(myFileStream);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("{0}\r\n{1}", ex.Message, ex.Message, ex.InnerException == null ? "" : ex.InnerException.Message), "load user setting fail");
                    File.Copy(filePath, string.Format("{0}.lastErrorFile", filePath), true);
                }
                finally
                {
                    myFileStream.Close();
                }
            }
            return modificSettingInfo;
        }
    }

}
