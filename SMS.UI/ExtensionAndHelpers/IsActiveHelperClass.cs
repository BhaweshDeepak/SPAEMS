using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.UI.ExtensionAndHelpers
{
    public  class IsActiveHelperClass
    {
        public static IHtmlString ActiveDeative(int value,string name)
        {
            TagBuilder tb = new TagBuilder("checkbox");
            tb.Attributes.Add("id",name);
            tb.Attributes.Add("name",name);
            tb.Attributes.Add("disable","disable");
            string dataValue = string.Empty;
            if(value == 1)
                dataValue = "Active";
            else
                dataValue = "DeActive";
            tb.Attributes.Add("value",dataValue);
            return new MvcHtmlString(tb.ToString());
        }
    }
}