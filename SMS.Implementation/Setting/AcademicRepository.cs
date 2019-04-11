using SMS.Contract.Setting;
using SMS.Repository.Setting;
using System;
using System.Collections.Generic;
using SMS.Core;
using SMS.Implementation.Comman;
using System.Linq;

namespace SMS.Implementation.Setting
{
    public class AcademicRepository:IAcademicRepository
    {
        private readonly DB_SPADevelopementEntities dB_SPADevelopementEntities;
        public AcademicRepository()
        {
            dB_SPADevelopementEntities = new DB_SPADevelopementEntities();
        }
        public string DeleteEntity(int entityId)
        {
            using(dB_SPADevelopementEntities)
            {
                var result = dB_SPADevelopementEntities.AcademicMasters.Find(entityId);
                result.IsActive = 0;
                result.UpdateDate = DateTime.Now;
                result.UpdatedBy = result.CreatedBy;
                dB_SPADevelopementEntities.Entry(result).State = System.Data.Entity.EntityState.Modified;
                dB_SPADevelopementEntities.SaveChanges();
                return "Academic master deleted successfully";
            }
        }

        public AcademicMasterVm GetEntityById(int entityId)
        {
            using(dB_SPADevelopementEntities)
            {
                var result = dB_SPADevelopementEntities.AcademicMasters.Find(entityId);
                var destination = ConvertSourceToDest<AcademicMaster,AcademicMasterVm>.ConvertSourceToDestination(result);
                return destination;
            }
        }

        public List<AcademicMasterVm> GetEntityList()
        {
            using(dB_SPADevelopementEntities)
            {
                var result = dB_SPADevelopementEntities.AcademicMasters.Where(item => item.IsActive == 1).ToList();
                var destination = new ConvertListSourceToDestination<AcademicMaster,AcademicMasterVm>().ConvertSourceToDestination(result);
                return destination;
            }
        }

        public string InsertEntity(AcademicMasterVm entity)
        {
            using(dB_SPADevelopementEntities)
            {
                var result = ConvertSourceToDest<AcademicMasterVm,AcademicMaster>.ConvertSourceToDestination(entity);
                dB_SPADevelopementEntities.AcademicMasters.Add(result);
                dB_SPADevelopementEntities.SaveChanges();
                return "Academic master created successfully";
            }
        }

        public string UpdateEntity(AcademicMasterVm entity)
        {
            using(dB_SPADevelopementEntities)
            {
                var result = ConvertSourceToDest<AcademicMasterVm,AcademicMaster>.ConvertSourceToDestination(entity);
                result.UpdateDate = entity.UpdateDate;
                result.UpdatedBy = entity.UpdatedBy;
                result.IsActive = 1;

                dB_SPADevelopementEntities.Entry(result).State = System.Data.Entity.EntityState.Modified;
                dB_SPADevelopementEntities.SaveChanges();
                return "Academic Master updated successfully";
            }
        }
    }
}
