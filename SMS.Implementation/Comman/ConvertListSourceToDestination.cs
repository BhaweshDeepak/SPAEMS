using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace SMS.Implementation.Comman
{
    public class ConvertListSourceToDestination<TSource, TDestination>
    {
        public List<TDestination> ConvertSourceToDestination(List<TSource> Tentities)
        {
            List<TDestination> destinations = new List<TDestination>();
            foreach(var sourceObject in Tentities)
            {
                TDestination destination = Activator.CreateInstance<TDestination>();
                foreach(PropertyInfo sourceProperty in sourceObject.GetType().GetProperties())
                {
                    foreach(PropertyInfo destinationProperty in destination.GetType().GetProperties())
                    {
                        if(sourceProperty.Name == destinationProperty.Name && sourceProperty.PropertyType== destinationProperty.PropertyType)
                        {
                            if(sourceProperty.PropertyType== typeof(DateTime))
                            {
                                var value = sourceObject.GetType().GetProperty(sourceProperty.Name).GetValue(sourceObject,null);
                                destinationProperty.SetValue(destination,DateTime.Parse(value.ToString()) ,null);
                            }
                            else
                            {
                                var value = sourceObject.GetType().GetProperty(sourceProperty.Name).GetValue(sourceObject,null);
                                destinationProperty.SetValue(destination,value,null);
                            }
                        }
                    }
                }
                destinations.Add(destination);
            }
            return destinations;
        }
    }
}
