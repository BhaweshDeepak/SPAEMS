using SMS.Contract.Setting;
using SMS.Core;
using SMS.Implementation.Comman;
using SMS.Repository.Setting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Implementation.Setting
{
    public class ClassMasterRepository:IClassMasterRepository
    {
        private readonly DB_SPADevelopementEntities dB_SPADevelopementEntities;
        public ClassMasterRepository()
        {
            dB_SPADevelopementEntities = new DB_SPADevelopementEntities();
        }
        public string DeleteEntity(int entityId)
        {
            var result = dB_SPADevelopementEntities.Classes.Find(entityId);
            result.IsActive = 0;
            result.UpdatedDate = DateTime.Now;
            dB_SPADevelopementEntities.Entry(result).State = System.Data.Entity.EntityState.Modified;
            dB_SPADevelopementEntities.SaveChanges();
            return "Class Deleted successFully";

        }

        public ClassMasterVm GetEntityById(int entityId)
        {
            var result = dB_SPADevelopementEntities.Classes.Find(entityId);
            var destination = ConvertSourceToDest<Core.Class,ClassMasterVm>.ConvertSourceToDestination(result);
            return destination;
        }

        public List<ClassMasterVm> GetEntityList()
        {
            var result = dB_SPADevelopementEntities.Classes.Where(item => item.IsActive == 1).ToList();
            var destionationList = new ConvertListSourceToDestination<Core.Class,ClassMasterVm>().ConvertSourceToDestination(result);
            return destionationList;
        }

        public string InsertEntity(ClassMasterVm entity)
        {
            var result = ConvertSourceToDest<ClassMasterVm,Class>.ConvertSourceToDestination(entity);
            dB_SPADevelopementEntities.Classes.Add(result);
            dB_SPADevelopementEntities.SaveChanges();
            return "Class Created SuccessFully";
        }

        public string UpdateEntity(ClassMasterVm entity)
        {
            var result = ConvertSourceToDest<ClassMasterVm,Class>.ConvertSourceToDestination(entity);
            dB_SPADevelopementEntities.Entry(result).State = System.Data.Entity.EntityState.Modified;
            dB_SPADevelopementEntities.SaveChanges();
            return "Class Updated SuccessFully";
        }
    }
}
