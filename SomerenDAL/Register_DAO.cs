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
    public class Register_DAO : Base
    {
        public void AddRegister(int studentID, int drinkID)
        {
            string query = $"INSERT INTO Reg(studentID, drinkID) VALUES({studentID}, {drinkID})";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            ExecuteEditQuery(query, sqlParameters);
        }
    }
}
