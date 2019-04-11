using SMS.Contract.StudentFinance;
using SMS.Repository.StudentFinance;
using System;
using System.Collections.Generic;
using SMS.Core;
using SMS.Implementation.Comman;
using System.Linq;

namespace SMS.Implementation.StudentFinance
{
    public class FeeHeadTypeRepository:IFeeHeadTypeRepository
    {
        private readonly DB_SPADevelopementEntities dB_SPADevelopementEntities;
        public FeeHeadTypeRepository()
        {
            dB_SPADevelopementEntities = new DB_SPADevelopementEntities();
        }
        public string DeleteEntity(int entityId)
        {
            using(dB_SPADevelopementEntities)
            {
                var result = dB_SPADevelopementEntities.FeeHeadMasters.Find(entityId);
                result.IsActive = 0;
                dB_SPADevelopementEntities.Entry(result).State = System.Data.Entity.EntityState.Modified;
                dB_SPADevelopementEntities.SaveChanges();
                return "Fee Head Deleted successfully";
            }
        }

        public FeeHeadMasterVM GetEntityById(int entityId)
        {
            using(dB_SPADevelopementEntities)
            {
                var result = dB_SPADevelopementEntities.FeeHeadMasters.Find(entityId);
                var destination = ConvertSourceToDest<FeeHeadMaster,FeeHeadMasterVM>.ConvertSourceToDestination(result);
                return destination;
            }
        }

        public List<FeeHeadMasterVM> GetEntityList()
        {
            using(dB_SPADevelopementEntities)
            {
                var result = dB_SPADevelopementEntities.FeeHeadMasters.Where(item => item.IsActive == 1).ToList();
                var destination = new ConvertListSourceToDestination<FeeHeadMaster,FeeHeadMasterVM>().ConvertSourceToDestination(result);
                return destination;
            }
        }

        public string InsertEntity(FeeHeadMasterVM entity)
        {
            using(dB_SPADevelopementEntities)
            {
                var destination = ConvertSourceToDest<FeeHeadMasterVM,FeeHeadMaster>.ConvertSourceToDestination(entity);
                dB_SPADevelopementEntities.FeeHeadMasters.Add(destination);
                dB_SPADevelopementEntities.SaveChanges();
                return "Fee Head created successfully";
            }
        }

        public string UpdateEntity(FeeHeadMasterVM entity)
        {
            using(dB_SPADevelopementEntities)
            {
                var destination = ConvertSourceToDest<FeeHeadMasterVM,FeeHeadMaster>.ConvertSourceToDestination(entity);
                destination.Updatedby = entity.CreatedBy;
                destination.UpdatedDate = DateTime.Now.Date;
                dB_SPADevelopementEntities.Entry(destination).State = System.Data.Entity.EntityState.Modified;
                dB_SPADevelopementEntities.SaveChanges();
                return "Fee head updated successfully";
            }
        }
    }
}
