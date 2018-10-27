using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeHttp.HttpHelper
{
    public enum ContentModificMode
    {
        NoChange,
        KeyVauleReplace,
        EntireReplace
    }

     [Serializable]
    public class ContentModific
    {
        public ContentModificMode ModificMode { get; set; }
        public string TargetKey { get; set; }
        public string ReplaceContent { get; set; }

        public ContentModific()
        {
            ModificMode = ContentModificMode.NoChange;
            TargetKey = null;
            ReplaceContent = null;
        }
        public ContentModific(string targetKey,string replaceContent)
        {
            if (string.IsNullOrEmpty(targetKey))
            {
                ModificMode = ContentModificMode.EntireReplace;
                TargetKey = null;
            }
            else
            {
                ModificMode = ContentModificMode.KeyVauleReplace;
                TargetKey = targetKey;
            }

            if (ModificMode == ContentModificMode.EntireReplace && string.IsNullOrEmpty(replaceContent))
            {
                ModificMode = ContentModificMode.NoChange;
                ReplaceContent = null;
            }
            else
            {
                ReplaceContent = (replaceContent == null ? "" : replaceContent);
            }
            
        }
    }
}
