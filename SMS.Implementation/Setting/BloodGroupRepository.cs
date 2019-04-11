using System;
using System.Collections.Generic;
using SMS.Core;
using System.Linq;
using SMS.Repository.Setting;
using SMS.Contract.Setting;
using SMS.Implementation.Comman;

namespace SMS.Implementation.Setting
{
    public class BloodGroupRepository:IBloodGroupMasterRepository
    {
        private readonly DB_SPADevelopementEntities dB_SPADevelopementEntities;
        public BloodGroupRepository()
        {
            dB_SPADevelopementEntities = new DB_SPADevelopementEntities();
        }
        public IEnumerable<BloodGroupVM> GetEntities()
        {
            using(dB_SPADevelopementEntities)
            {
                var result= dB_SPADevelopementEntities.BloodGroups.Where(x => x.IsActive == 1).ToList();
                var destination =new  ConvertListSourceToDestination<BloodGroup,BloodGroupVM>().ConvertSourceToDestination(result);
                return destination;
            }
        }
    }
}
