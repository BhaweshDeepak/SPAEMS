using SMS.Contract.Setting;
using SMS.Core;
using SMS.Implementation.Comman;
using SMS.Repository.Setting;
using System.Collections.Generic;
using System.Linq;


namespace SMS.Implementation.Setting
{
    public class SectionMasterRepository:ISectionMasterRepository
    {
        private readonly DB_SPADevelopementEntities dB_SPADevelopementEntities;
        public SectionMasterRepository()
        {
            dB_SPADevelopementEntities = new DB_SPADevelopementEntities();
        }
        public string DeleteEntity(int entityId)
        {
            var result = dB_SPADevelopementEntities.Sections.Find(entityId);
            result.IsActive = 0;
            result.UpdatedBy = result.CreatedBy;
            result.CreatedDate = System.DateTime.Now;
            dB_SPADevelopementEntities.Entry(result).State = System.Data.Entity.EntityState.Modified;
            dB_SPADevelopementEntities.SaveChanges();
            return "Section Master Deleted successfully";
        }

        public SectionMasterVM GetEntityById(int entityId)
        {
            var sourceResult = dB_SPADevelopementEntities.Sections.Find(entityId);
            var destination = ConvertSourceToDest<Section,SectionMasterVM>.ConvertSourceToDestination(sourceResult);
            return destination;
        }

        public List<SectionMasterVM> GetEntityList()
        {
            var sectionResult = (from sect in dB_SPADevelopementEntities.Sections
                                 join cM in dB_SPADevelopementEntities.Classes
                                 on sect.ClassId equals cM.Id
                                 where (sect.IsActive == 1 && cM.IsActive == 1)
                                 select new SectionMasterVM
                                 {
                                     Id= sect.Id,
                                     Name=sect.Name,
                                     Code=sect.Code,
                                     ClassId= cM.Id,
                                     ClassName= cM.Name

                                 }).ToList();

            return sectionResult;
        }

        public string InsertEntity(SectionMasterVM entity)
        {
            var destination = ConvertSourceToDest<SectionMasterVM,Section>.ConvertSourceToDestination(entity);
            dB_SPADevelopementEntities.Sections.Add(destination);
            dB_SPADevelopementEntities.SaveChanges();
            return "Section created successfully";
        }

        public string UpdateEntity(SectionMasterVM entity)
        {
            var destination = ConvertSourceToDest<SectionMasterVM,Section>.ConvertSourceToDestination(entity);
            dB_SPADevelopementEntities.Entry(destination).State = System.Data.Entity.EntityState.Modified;
            dB_SPADevelopementEntities.SaveChanges();
            return "section master Updated successfully";
        }
    }
}
