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
        public static List<ListViewItem> FindMatchTanperRule(Session oSession,ListView ruleListView)
        {
            if (oSession == null || ruleListView == null || ruleListView.Items.Count==0)
            {
                return null;
            }
            List<ListViewItem> matchItemList = new List<ListViewItem>();
            foreach(ListViewItem tempItem in ruleListView.Items)
            {
                if (!tempItem.Checked)
                {
                    continue;
                }
                if(((IFiddlerHttpTamper)tempItem.Tag).HttpFilter.UriMatch.Match(oSession.fullUrl))
                {
                    matchItemList.Add(tempItem);
                }
            }
            return matchItemList;
        }

        public static List<ListViewItem> FindMatchTanperRule(Session oSession, ListView ruleListView,bool isRequest)
        {
            if (oSession == null || ruleListView == null || ruleListView.Items.Count == 0)
            {
                return null;
            }
            List<ListViewItem> matchItemList = new List<ListViewItem>();
            foreach (ListViewItem tempItem in ruleListView.Items)
            {
                if (!tempItem.Checked)
                {
                    continue;
                }
                if (((IFiddlerHttpTamper)tempItem.Tag).HttpFilter.Match(oSession , isRequest))
                {
                    matchItemList.Add(tempItem);
                }
            }
            return matchItemList;
        }
    }
}
