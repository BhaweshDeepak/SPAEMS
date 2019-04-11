using SMS.Contract.StudentMaster;
using SMS.Repository.StudentMaster;
using System;
using System.Collections.Generic;
using SMS.Core;
using SMS.Implementation.Comman;
using System.Linq;

namespace SMS.Implementation.StudentMaster
{
    public class StudentMasterRepository:IStudentMasterRepository
    {
        private readonly DB_SPADevelopementEntities dB_SPADevelopementEntities;
        public StudentMasterRepository()
        {
            dB_SPADevelopementEntities = new DB_SPADevelopementEntities();
        }
        public IEnumerable<StudentMasterVM> GetEntities()
        {
            using(dB_SPADevelopementEntities)
            {
                var result = dB_SPADevelopementEntities.StudentMasters.Where(item => item.IsActive == 1).ToList();
                var destination = new ConvertListSourceToDestination<Core.StudentMaster,StudentMasterVM>().ConvertSourceToDestination(result);
                return destination;
            }
        }

        public List<StudentListVM> GetStudentListVMs()
        {
            using(dB_SPADevelopementEntities)
            {
                var result = dB_SPADevelopementEntities.StudentMasters.Where(item => item.IsActive == 1).Select(item => new StudentListVM
                {
                    StudentId = item.Id,
                    Name = item.Name,
                    FatherName = item.FatherName,
                    MotherName = item.MotherName,
                    EnrollmentNumber = item.RegistrationNumber,
                    RegistrationNumber = item.RollNumber
                }).ToList();

                return result;
            }
        }

        public string UpSertStudentMaster(StudentMasterVM studentMasterVM)
        {
            try
            {
                int studentId = 0;
                var result = ConvertSourceToDest<StudentMasterVM,Core.StudentMaster>.ConvertSourceToDestination(studentMasterVM);
                if(studentMasterVM.Id == 0)
                {
                    using(dB_SPADevelopementEntities)
                    {
                        using(var transaction = dB_SPADevelopementEntities.Database.BeginTransaction())
                        {
                            try
                            {
                                result.CreatedDate = DateTime.Now.Date;
                                dB_SPADevelopementEntities.StudentMasters.Add(result);
                                dB_SPADevelopementEntities.SaveChanges();
                                studentId = result.Id;


                                StudentClassMapping studentClassMapping = new StudentClassMapping();
                                studentClassMapping.StudentId = studentId;
                                studentClassMapping.AcademicYear = 1;
                                studentClassMapping.classId = result.ClassId;
                                studentClassMapping.sectionId = result.SectionId;
                                studentClassMapping.CreatedBy = result.CreatedBy;
                                studentClassMapping.CreatedDate = DateTime.Now.Date;

                                dB_SPADevelopementEntities.StudentClassMappings.Add(studentClassMapping);
                                dB_SPADevelopementEntities.SaveChanges();



                                transaction.Commit();
                            }
                            catch(Exception ex)
                            {
                                transaction.Rollback();
                            }
                        }

                    }
                }
                //this code is used to perform the Student Master Update:
                else
                {
                    using(dB_SPADevelopementEntities)
                    {
                        using(var transaction = dB_SPADevelopementEntities.Database.BeginTransaction())
                        {
                            try
                            {
                                dB_SPADevelopementEntities.Entry(result).State = System.Data.Entity.EntityState.Modified;
                                dB_SPADevelopementEntities.SaveChanges();

                                StudentClassMapping studentClassMapping = dB_SPADevelopementEntities.StudentClassMappings.Where(item => item.StudentId == result.Id).FirstOrDefault();
                                studentClassMapping.AcademicYear = studentMasterVM.AcademicYear;
                                studentClassMapping.classId = studentMasterVM.ClassId;
                                studentClassMapping.sectionId = studentMasterVM.SectionId;
                                studentClassMapping.StudentId = result.Id;
                                studentClassMapping.UpdatedBy = result.CreatedBy;
                                studentClassMapping.UpdatedDate = DateTime.Now.Date;

                                dB_SPADevelopementEntities.Entry(studentClassMapping).State = System.Data.Entity.EntityState.Modified;
                                dB_SPADevelopementEntities.SaveChanges();

                                transaction.Commit();
                            }
                            catch(Exception ex)
                            {
                                transaction.Rollback();
                                return ex.Message;
                           
                            }
                        }

                    }
                }

                return "Student created successfully";
            }
            catch(Exception e)
            {
                return e.Message;

            }

        }
    }
}
