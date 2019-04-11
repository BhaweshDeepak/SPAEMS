using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace SMS.Implementation.Comman
{
    public static class ConvertSourceToDest<TSource, TDestination>
    {
        public static TDestination ConvertSourceToDestination(TSource source)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<TSource, TDestination>(); });
            IMapper mapper = config.CreateMapper();
            var dest = mapper.Map<TSource, TDestination>(source);
            return dest;
        }
    }
}
