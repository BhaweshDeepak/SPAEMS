using SMS.Contract.Setting;
using SMS.Repository.Setting;
using System;
using System.Collections.Generic;
using SMS.Core;
using System.Linq;
using SMS.Implementation.Comman;

namespace SMS.Implementation.Setting
{
    public class GenderMasterRepository:IGenderMasterRepository
    {
        private readonly DB_SPADevelopementEntities dB_SPADevelopementEntities;
        public GenderMasterRepository()
        {
            dB_SPADevelopementEntities = new DB_SPADevelopementEntities();
        }
        public string DeleteEntity(int entityId)
        {
            throw new NotImplementedException();
        }

        public GenderMasterVM GetEntityById(int entityId)
        {
            throw new NotImplementedException();
        }

        public List<GenderMasterVM> GetEntityList()
        {
            using(dB_SPADevelopementEntities)
            {
                var result = dB_SPADevelopementEntities.GenderMasters.Where(item => item.IsActive == 1).ToList();
                var destination = new ConvertListSourceToDestination<GenderMaster,GenderMasterVM>().ConvertSourceToDestination(result);
                return destination;
            }
        }

        public string InsertEntity(GenderMasterVM entity)
        {
            throw new NotImplementedException();
        }

        public string UpdateEntity(GenderMasterVM entity)
        {
            throw new NotImplementedException();
        }
    }
}
