using System.Collections.Generic;
using SMS.Contract.StudentFinance.StudentFeeDeposit;
using SMS.Repository.StudentFinance;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using SMS.Implementation.Comman;
using System;

namespace SMS.Implementation.StudentFinance
{
    public class StudentFeeDepositRepository:IStudentFeeDeposit
    {
        private readonly string _connectionString;

        public StudentFeeDepositRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["SPADevelopment"].ConnectionString;
        }
        public IDictionary<int,string> GetAutoCompleteFeild(string entityData,int autoCompleteType)
        {
            switch(autoCompleteType)
            {
                case 1:
                    return GetStudentNameListByName(entityData);
                case 2:
                    return GetStudentNameListByRollNumber(entityData);
                default:
                    return null;
            }
        }

        private IDictionary<int,string> GetStudentNameListByName(string entityData)
        {
            Dictionary<int,string> dictionary = new Dictionary<int,string>();
            SqlParameter[] sqlParams = {
                        new SqlParameter("name",entityData){ SqlDbType=SqlDbType.VarChar, Direction=ParameterDirection.Input}
                    };
            string comandText = "select Id, Name from Student.StudentMaster where StudentMaster.Name like  '%' + @name +'%'";
            using(var reader = SqlHelper.ExecuteReader(_connectionString,comandText,CommandType.Text,sqlParams))
            {
                while(reader.Read())
                {
                    int studentId = Convert.ToInt32(reader["Id"]);
                    string studentName = reader["Name"].ToString();
                    dictionary.Add(studentId,studentName);
                }
            }
            return dictionary;
        }


        private IDictionary<int,string> GetStudentNameListByRollNumber(string entityData)
        {
            Dictionary<int,string> dictionary = new Dictionary<int,string>();
            SqlParameter[] sqlParams = {
                        new SqlParameter("@roll",entityData){ SqlDbType=SqlDbType.VarChar, Direction=ParameterDirection.Input}
                    };
            string comandText = "select Id, Name from Student.StudentMaster where StudentMaster.Name like ''@roll%''";
            using(var reader = SqlHelper.ExecuteReader(_connectionString,comandText,CommandType.Text,sqlParams))
            {
                while(reader.Read())
                {
                    int studentId = Convert.ToInt32(reader["Id"]);
                    string studentName = reader["Name"].ToString();
                    dictionary.Add(studentId,studentName);
                }
            }
            return dictionary;
        }

        public List<AutoCompleteStudent> GetStudentDetailById(int entityId)
        {
            SqlParameter[] sqlParams = {
                 new SqlParameter("@studentId",entityId){ SqlDbType= SqlDbType.Int, Direction= ParameterDirection.Input}
            };
            List<AutoCompleteStudent> autoCompleteStudents = new List<AutoCompleteStudent>();
            using(var reader= SqlHelper.ExecuteReader(_connectionString,SqlConstant.GetStudentList,CommandType.StoredProcedure,sqlParams))
            {
                while(reader.Read())
                {
                    AutoCompleteStudent autoCompleteStudent = new AutoCompleteStudent();
                    autoCompleteStudent.StudentId = Convert.ToInt32(reader["Id"]);
                    autoCompleteStudent.FatherName = reader["FatherName"].ToString();
                    autoCompleteStudent.MotherName = reader["MotherName"].ToString();
                    autoCompleteStudent.StudentName = reader["Name"].ToString();
                    autoCompleteStudent.RollNumber = reader["RollNumber"].ToString();
                    autoCompleteStudent.RegistrationNumber = reader["RegistrationNumber"].ToString();
                    autoCompleteStudent.ClassName = reader["ClassName"].ToString();
                    autoCompleteStudent.SectionName = reader["SectionName"].ToString();

                    autoCompleteStudents.Add(autoCompleteStudent);
                }

                return autoCompleteStudents;
            }
        }

        public List<StudentFeeSummaryDetail> GetStudentFeeSummaryDetails(int studentId)
        {
            List<StudentFeeSummaryDetail> studentFeeSummaryDetails = new List<StudentFeeSummaryDetail>();
            SqlParameter[] sqlParameters = {
                 new SqlParameter("@studentId", studentId){ SqlDbType= SqlDbType.Int, Direction= ParameterDirection.Input}
            };

            using(var reader= SqlHelper.ExecuteReader(_connectionString,SqlConstant.GetStudentFeeDetail,CommandType.StoredProcedure,sqlParameters))
            {
                while(reader.Read())
                {
                    StudentFeeSummaryDetail studentFeeSummaryDetail = new StudentFeeSummaryDetail();
                    studentFeeSummaryDetail.AllotedAmount = Convert.ToDecimal(reader["AllotedAmount"]);
                    studentFeeSummaryDetail.DiscountPercenatge = Convert.ToDecimal(reader["AllotedAmount"]);
                    studentFeeSummaryDetail.DiscountAmount = Convert.ToDecimal(reader["DiscountAmount"]);
                    studentFeeSummaryDetail.NetFeeAmount = Convert.ToDecimal(reader["NetFeeAmount"]);
                    studentFeeSummaryDetail.FeePaymentType = reader["PaymentType"].ToString();
                    studentFeeSummaryDetail.HeadName = reader["HeadName"].ToString();
                    studentFeeSummaryDetail.AmountDeposited = Convert.ToDecimal(reader["AmountDeposit"]);

                    studentFeeSummaryDetails.Add(studentFeeSummaryDetail);
                }
            }

            return studentFeeSummaryDetails;
        }
    }
}
