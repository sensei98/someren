using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Collections.ObjectModel;
using SomerenModel;

namespace SomerenDAL
{
    public class Teacher_DAO : Base
    {

        public List<Teacher> Db_Get_All_Teachers()
        {
            string query = "SELECT Id,FirstName,LastName,Speciality,Supervisors FROM [Teacher]";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }
        public List<Teacher> Db_Get_All_Supervisors()
        {
            string query = "SELECT Teacher.Id,Teacher.FirstName,Teacher.LastName,Teacher.Speciality,Teacher.Supervisors FROM Teacher JOIN Supervisors ON Teacher.Id = Supervisors.TeachersID";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }
        public void InsertSupervisor(string firstName, string lastName)
        {
            string query = "INSERT INTO Supervisors(TeachersID) SELECT Teacher.Id FROM Teacher WHERE( Teacher.FirstName='" + firstName + "' AND Teacher.LastName='"+ lastName + "')";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            ExecuteEditQuery(query, sqlParameters);
        }
        public void DeleteSupervisor(int teacherID)
        {
            string query = $"DELETE FROM Supervisors WHERE Supervisors.TeachersID='"+teacherID+"'";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            ExecuteEditQuery(query, sqlParameters);

        }


        private List<Teacher> ReadTables(DataTable dataTable)
        {
            List<Teacher> teachers = new List<Teacher>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Teacher teacher = new Teacher()
                {
                    TeacherNumber = (int)dr["Id"],
                    FirstName = (String)dr["FirstName"],
                    LastName = (String)dr["LastName"],
                    Speciality = (String)dr["Speciality"],
                    Supervisor = (bool)dr["Supervisors"]

                };
                teachers.Add(teacher);
            }
            return teachers;
        }
    }
}
