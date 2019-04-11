using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;


namespace SMS.Implementation.Comman
{
    public static class StringExtension
    {
        public static List<T> ConvertStringTolistInt<T>(this string value)
        {
            List<T> lstResult = new List<T>();
            Type type = Activator.CreateInstance<T>().GetType();
            if(value.Split(',').Count() > 0)
            {
                string[] strValue = value.Split(',');
                foreach(var data in strValue)
                {
                    lstResult.Add((T)Convert.ChangeType(data,typeof(T)));
                }
            }
            return lstResult;
        }
    }
}
