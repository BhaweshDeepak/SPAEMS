using System;
using System.Globalization;
using System.Web;
using System.Web.Mvc;

namespace SMS.UI.ExtensionAndHelpers
{
    public static class SPADateExtension
    {
        public static IHtmlString DateFormatt( DateTime dateTime)
        {
            string date = dateTime.ToString("dd-MM-yyyy",CultureInfo.InvariantCulture);
            string Labledate = $"<label>{date}</label>";
            return new HtmlString(Labledate);
        }
    }
}