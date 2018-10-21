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
        public static void SerializRuleList(ListView ruleListView)
        {
            if(ruleListView!=null)
            {
                List<IFiddlerHttpTamper> ruleList = new List<IFiddlerHttpTamper>();
                foreach(ListViewItem tempItem in ruleListView.Items)
                {
                    ruleList.Add((IFiddlerHttpTamper)tempItem.Tag);
                }
                //Stream stream = File.Open("data.xml", FileMode.Create);
                TextWriter writer = new StreamWriter("d:\\data.xml", false);
                XmlSerializer serializer = new XmlSerializer(typeof(List<IFiddlerHttpTamper>));
                serializer = new XmlSerializer(typeof(List<IFiddlerHttpTamper>));
                serializer.Serialize(writer, ruleList);
                writer.Close();
            }
        }
    }
}
