using Fiddler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FreeHttp.HttpHelper
{
    class FiddlerSessionHelper
    {
        public static ListViewItem FindMatchTanperRule(Session oSession,ListView ruleListView)
        {
            if (oSession == null || ruleListView == null || ruleListView.Items.Count==0)
            {
                return null;
            }
            foreach(ListViewItem tempItem in ruleListView.Items)
            {
                if(((IFiddlerHttpTamper)tempItem.Tag).UriMatch.Match(oSession.fullUrl))
                {
                    return tempItem;
                }
            }
            return null;
        }
    }
}
