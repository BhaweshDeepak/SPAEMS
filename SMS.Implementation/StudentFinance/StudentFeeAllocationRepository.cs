using SMS.Contract.StudentFinance;
using SMS.Repository.StudentFinance;
using System;
using System.Collections.Generic;
using SMS.Core;
using SMS.Implementation.Comman;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace SMS.Implementation.StudentFinance
{
    public class StudentFeeAllocationRepository:IStudentFeeAllocationListRepository
    {
        private readonly DB_SPADevelopementEntities dB_SPADevelopementEntities;
        public StudentFeeAllocationRepository()
        {
            dB_SPADevelopementEntities = new DB_SPADevelopementEntities();
        }
        public List<StudentFeeListVM> GetStudentFeeList()
        {
            List<StudentFeeListVM> studentFeeListVMs = new List<StudentFeeListVM>();
            using(dB_SPADevelopementEntities)
            {
                using(var conn = dB_SPADevelopementEntities.Database.Connection)
                {
                    using(var cmd = conn.CreateCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "Proc_GetStudentFeeInformation";
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        using(var reader = cmd.ExecuteReader())
                        {
                            while(reader.Read())
                            {
                                var result=reader.GetName(0);
                                StudentFeeListVM studentFeeListVM = new StudentFeeListVM();
                                studentFeeListVM.Id =Convert.ToInt32(reader["Id"]);
                                studentFeeListVM.Name = reader["Name"].ToString();
                                studentFeeListVM.FatherName = reader["FatherName"].ToString();
                                studentFeeListVM.RegistrationNumber = reader["RegistrationNumber"].ToString();
                                studentFeeListVM.RollNumber = reader["ROllNumber"].ToString();
                                studentFeeListVM.ContactPhone = reader["ContactPhone"].ToString();
                                studentFeeListVM.ClassName = reader["ClassName"].ToString();
                                studentFeeListVM.SectionName = reader["SectionName"].ToString();
                                studentFeeListVM.HeaderTypeId = Convert.ToInt32(reader["HeadTypeId"]);
                                studentFeeListVM.HeadName = reader["HeadName"].ToString();
                                studentFeeListVM.AlloatedAmount = Convert.ToDecimal(reader["AllotedAmount"]);
                                studentFeeListVM.DiscountAmount = reader["DiscountAmount"].ToString().CastStringToType<decimal>();
                                studentFeeListVM.DiscountPercenatge = reader["DiscountPercentage"].ToString().CastStringToType<decimal>();
                                studentFeeListVM.NetAmount = reader["NetFeeAmount"].ToString().CastStringToType<decimal>();

                                studentFeeListVMs.Add(studentFeeListVM);
                            }
                        }
                        conn.Close();
                    }
                }

                return studentFeeListVMs;
            }
        }
    }
}
