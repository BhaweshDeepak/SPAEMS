using SMS.Contract.StudentMaster;
using System.Collections.Generic;

namespace SMS.Repository.StudentMaster
{
    public interface IStudentMasterRepository :IGetCommanRepository<StudentMasterVM>
    {
        /// <summary>
        /// This code is used to perform the Insert and update the student Detail
        /// </summary>
        /// <param name="studentMasterVM"></param>
        /// <returns></returns>
        string UpSertStudentMaster(StudentMasterVM studentMasterVM);

        List<StudentListVM> GetStudentListVMs();
    }
}
