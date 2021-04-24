
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomerenDAL;
using SomerenModel;

namespace SomerenLogic
{
    public class Activity_Service
    {

        Activity_DAO activity_db = new Activity_DAO();

        public List<Activity> GetActivities()
        {
            try
            {
                List<Activity> activity = activity_db.Db_Get_All_Activities();
                return activity;
            }
            catch (Exception )
            {
                List<Activity> activity = new List<Activity>();
                Activity activities = new Activity();
                activities.Id = 2;
                activities.ActivityName = "Cricket";
                activities.NumberofStudents = 12;
                activities.NumberofSupervisors = 3;
                activity.Add(activities);
                return activity;
                // Todo: Improve error logic.
                throw new Exception("Someren couldn't connect to the database ");

            }

        }

        public void AddActivity(Activity activities)
        {
          
          
                activity_db.Db_Insert(activities);

        }
        public void EditActivity(Activity activities)
        {
            
                activity_db.Db_Edit(activities);
        }
        public void RemoveActivity( int Id)
        {
         
                activity_db.Db_Remove(Id);

        }
    }
}
