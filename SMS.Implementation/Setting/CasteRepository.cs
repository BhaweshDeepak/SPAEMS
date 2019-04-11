using SMS.Core;
using SMS.Repository.Setting;
using System.Linq;
using System.Collections.Generic;
using SMS.Contract.Setting;
using SMS.Implementation.Comman;

namespace SMS.Implementation.Setting
{
    public class CasteRepository:ICasteRepository
    {
        private readonly DB_SPADevelopementEntities dB_SPADevelopementEntities;
        public CasteRepository()
        {
            dB_SPADevelopementEntities = new DB_SPADevelopementEntities();
        }

        public IEnumerable<CasteMasterVM> GetEntities()
        {
            var result= dB_SPADevelopementEntities.CasteMasters.Where(item => item.IsActive == 1).ToList();
            var destination = new ConvertListSourceToDestination<CasteMaster,CasteMasterVM>().ConvertSourceToDestination(result);
            return destination;
        }
    }
}
