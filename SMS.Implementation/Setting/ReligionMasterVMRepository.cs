using SMS.Contract.Setting;
using SMS.Repository.Setting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMS.Core;
using SMS.Implementation.Comman;

namespace SMS.Implementation.Setting
{
    public class ReligionMasterVMRepository:IReligionMasterRepository
    {
        private readonly DB_SPADevelopementEntities dB_SPADevelopementEntities;
        public ReligionMasterVMRepository()
        {
            dB_SPADevelopementEntities = new DB_SPADevelopementEntities();
        }
        public string DeleteEntity(int entityId)
        {
            throw new NotImplementedException();
        }

        public ReligionMasterVM GetEntityById(int entityId)
        {
            throw new NotImplementedException();
        }

        public List<ReligionMasterVM> GetEntityList()
        {
            using(dB_SPADevelopementEntities)
            {
                var result = dB_SPADevelopementEntities.ReligionMasters.Where(item => item.IsActive == 1).ToList();
                var destination = new ConvertListSourceToDestination<ReligionMaster,ReligionMasterVM>().ConvertSourceToDestination(result);
                return destination;
            }
        }

        public string InsertEntity(ReligionMasterVM entity)
        {
            throw new NotImplementedException();
        }

        public string UpdateEntity(ReligionMasterVM entity)
        {
            throw new NotImplementedException();
        }
    }
}
