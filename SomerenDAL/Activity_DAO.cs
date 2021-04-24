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
    public class Activity_DAO : Base
    {
        public List<Activity> Db_Get_All_Activities()
        {
            string query = "SELECT Id,ActivityName,NumberofStudents,NumberofSupervisors FROM [Activities]";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Activity> ReadTables(DataTable dataTable)
        {
            List<Activity> activities = new List<Activity>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Activity activity = new Activity()
                {
                    Id = (int)dr["Id"],
                    // change name in the future
                    ActivityName=(String)dr["ActivityName"],
                    NumberofStudents=(int)(dr["NumberofStudents"]),
                    NumberofSupervisors=(int)(dr["NumberofSupervisors"])
                   
                    
                };
                activities.Add(activity);
            }
            return activities;
        }


        public void Db_Insert(Activity activities)
        {
            string query = $"INSERT INTO Activities(ActivityName,NumberofStudents,NumberofSupervisors) VALUES('{activities.ActivityName}',{activities.NumberofStudents},{activities.NumberofSupervisors})";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            ExecuteEditQuery(query, sqlParameters);
            
        }

        public void Db_Edit(Activity activities)
        {
            string query = $"update Activities Set ActivityName='{activities.ActivityName}', NumberofStudents = {activities.NumberofStudents},NumberofSupervisors= {activities.NumberofSupervisors} where Id = {activities.Id}";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            ExecuteEditQuery(query, sqlParameters);
          

        }

        public void Db_Remove(int id)
        {
            string query = $"Delete from Activities where Id = {id}";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            ExecuteEditQuery(query, sqlParameters);
         
        }

    }
}
