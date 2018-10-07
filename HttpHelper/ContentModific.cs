using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeHttp.HttpHelper
{
    public class ContentModific
    {
        public bool IsEntireReplace { get; set; }
        public string TargetContent { get; set; }
        public string ReplaceContent { get; set; }

        public ContentModific(string targetContent,string replaceContent)
        {
            if(string.IsNullOrEmpty(replaceContent))
            {
                IsEntireReplace = true;
            }
            else
            {
                ReplaceContent = replaceContent;
            }
            TargetContent = targetContent;
        }
    }
}
