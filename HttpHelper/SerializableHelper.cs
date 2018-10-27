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
                serializer.Serialize(writer, new FiddlerModificHttpRuleCollection(requestList,responseList));
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
                    MessageBox.Show(string.Format("{0}\r\n{1}", ex.Message, ex.InnerException.Message),"load user rule fail");
                    File.Copy("RuleData.xml", "RuleData.lastErrorFile",true);
                }
                finally
                {
                    myFileStream.Close();
                }
            }
            return fiddlerModificHttpRuleCollection;
        }
    }

}
