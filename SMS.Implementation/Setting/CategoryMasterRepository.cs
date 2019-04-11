using SMS.Contract.Setting;
using SMS.Repository.Setting;
using System;
using System.Collections.Generic;
using System.Linq;
using SMS.Core;
using SMS.Implementation.Comman;

namespace SMS.Implementation.Setting
{
    public class CategoryMasterRepository:ICategoryMasterRepossitory
    {
        private readonly DB_SPADevelopementEntities dB_SPADevelopementEntities;
        public CategoryMasterRepository()
        {
            dB_SPADevelopementEntities = new DB_SPADevelopementEntities();
        }
        public string DeleteEntity(int entityId)
        {
            var result = dB_SPADevelopementEntities.Categories.Find(entityId);
            result.IsActive = 0;
            dB_SPADevelopementEntities.Entry(result).State = System.Data.Entity.EntityState.Modified;
            dB_SPADevelopementEntities.SaveChanges();
            return "Category deleted successfully";
        }

        public CategoryMasterVM GetEntityById(int entityId)
        {
            var result = dB_SPADevelopementEntities.Categories.Find(entityId);
            var destination = ConvertSourceToDest<Category,CategoryMasterVM>.ConvertSourceToDestination(result);
            return destination;
        }

        public List<CategoryMasterVM> GetEntityList()
        {
            var result = dB_SPADevelopementEntities.Categories.Where(item => item.IsActive == 1).ToList();
            var destination = new ConvertListSourceToDestination<Category,CategoryMasterVM>().ConvertSourceToDestination(result);
            return destination;
        }

        public string InsertEntity(CategoryMasterVM entity)
        {
            var result = ConvertSourceToDest<CategoryMasterVM,Category>.ConvertSourceToDestination(entity);
            dB_SPADevelopementEntities.Categories.Add(result);
            dB_SPADevelopementEntities.SaveChanges();
            return "Category created successfully";

        }

        public string UpdateEntity(CategoryMasterVM entity)
        {
            var result = ConvertSourceToDest<CategoryMasterVM,Category>.ConvertSourceToDestination(entity);
            result.UpdatedBy = entity.CreatedBy;
            result.UpdatedDate = DateTime.Now.Date;
            dB_SPADevelopementEntities.Entry(result).State = System.Data.Entity.EntityState.Modified;
            dB_SPADevelopementEntities.SaveChanges();
            return "Category updated successfully";
        }
    }
}
