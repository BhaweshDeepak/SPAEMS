using SMS .Contract;
using SMS .Repository .Setting;
using System;
using System .Collections .Generic;
using System .Linq;
using System .Text;
using System .Threading .Tasks;
using SMS .Core;
using AutoMapper;
using SMS.Implementation.Comman;

namespace SMS .Implementation .Setting
{
    public class InstituteRepository : IInstituteRepository
    {
        private readonly DB_SPADevelopementEntities sMSDataLayerEntities;
        public InstituteRepository ()
        {
            sMSDataLayerEntities = new DB_SPADevelopementEntities();
        }
        public string DeleteEntity (int entityId)
        {

            using (sMSDataLayerEntities)
            {
                var model = sMSDataLayerEntities .InstituteDetails .Find(entityId);
                sMSDataLayerEntities .Entry(model) .State = System .Data .Entity .EntityState .Modified;
                sMSDataLayerEntities .SaveChanges();
                return SuccessErrorMessage .InstituteCreated;
            }

        }

        public InstitueDetail GetEntityById (int entityId)
        {
            return sMSDataLayerEntities .InstituteDetails .Where(item => item.Id==entityId).Select(x => new InstitueDetail {
                Id= x.Id,
                Name=x.Name,
                Address=x.Address,
                Phone= x.Phone,
                EmailAddress= x.EmailAddress,
                Mobile= x.Mobile,
                InstituteImage= x.InstituteImage
            }).First();
        }

        public List<InstitueDetail> GetEntityList ()
        {
            throw new NotImplementedException();
        }

        public string InsertEntity (InstitueDetail entity)
        {
            using(sMSDataLayerEntities)
            {
                var dest = ConvertSourceToDest<Contract.InstitueDetail,Core.InstituteDetail>.ConvertSourceToDestination(entity);
                sMSDataLayerEntities.InstituteDetails.Add(dest);
                sMSDataLayerEntities.SaveChanges();
                return "Institute Created SuccessFully";
            }
        }

        public string UpdateEntity (InstitueDetail entity)
        {
            using(sMSDataLayerEntities)
            {
                var dest=ConvertSourceToDest<Contract.InstitueDetail,Core.InstituteDetail>.ConvertSourceToDestination(entity);
                sMSDataLayerEntities.Entry(dest).State = System.Data.Entity.EntityState.Modified;
                sMSDataLayerEntities.SaveChanges();
                return "Institute UpDated SuccessFully";
            }
        }
    }
}
