using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using SMS.Repository.Setting;
using SMS.Implementation.Setting;
using SMS.Repository.StudentMaster;
using SMS.Implementation.StudentMaster;
using SMS.Repository.StudentFinance;
using SMS.Implementation.StudentFinance;

namespace SMS.UI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IInstituteRepository,InstituteRepository>();
            container.RegisterType<IClassMasterRepository,ClassMasterRepository>();
            container.RegisterType<ISectionMasterRepository,SectionMasterRepository>();
            container.RegisterType<IAcademicRepository,AcademicRepository>();
            container.RegisterType<IGenderMasterRepository,GenderMasterRepository>();
            container.RegisterType<IStudentMasterRepository,StudentMasterRepository>();
            container.RegisterType<IBloodGroupMasterRepository,BloodGroupRepository>();
            container.RegisterType<ICasteRepository,CasteRepository>();
            container.RegisterType<IReligionMasterRepository,ReligionMasterVMRepository>();
            container.RegisterType<ICategoryMasterRepossitory,CategoryMasterRepository>();
            container.RegisterType<IFeeHeadTypeRepository,FeeHeadTypeRepository>();
            container.RegisterType<IFeeAllocationRepository,FeeAllocationRepository>();
            container.RegisterType<IStudentFeeAllocationListRepository,StudentFeeAllocationRepository>();
            container.RegisterType<IStudentFeeDeposit,StudentFeeDepositRepository>();



            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

        }
    }
}