using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Implementation.Comman
{
    public static class StringToDynamicType
    {
        public static T CastStringToType<T>(this string value)
        {
            T t = Activator.CreateInstance<T>();
            Type type = Activator.CreateInstance<T>().GetType();
            if(value != null)
            {
                return (T)Convert.ChangeType(value,typeof(T));
            }
            else
            {
                return default(T);
            }
        }

    }
}
