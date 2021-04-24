using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomerenDAL;
using SomerenModel;

namespace SomerenLogic
{
    public class Timetable_Service
    {
        Timetable_DAO timetable_db = new Timetable_DAO();
        public List<Timetable> GetTimetable(string dayOfWeek)
        {
            try
            {
                List<Timetable> timetables = timetable_db.Db_Get_All_Timetable(dayOfWeek);
                return timetables;
            }
            catch (Exception)
            {
                List<Timetable> timetable = new List<Timetable>();
                Timetable a = new Timetable();
                
                a.Activity = "football";
                a.Supervisor = "Monasry";
                a.Date = new DateTime(2020, 03, 23);
                a.Starttime = new TimeSpan (19, 30, 30);
                a.Endtime = new TimeSpan(21, 30, 00);
                a.Status = "Supervised";
                timetable.Add(a);

                Timetable b = new Timetable();
              
                b.Activity = "basketball";
                b.Supervisor = "hooli";
                b.Date = new DateTime(2020, 03, 24);
                b.Starttime = new TimeSpan( 24, 16, 30, 30);
                b.Endtime = new TimeSpan(21, 30, 00);
                b.Status = "supervised";
               timetable.Add(b);

                Timetable c = new Timetable();
               
                c.Activity = "soccer";
                c.Supervisor = "ionna";
                c.Date = new DateTime(2020, 03, 24);
                c.Starttime = new TimeSpan(19, 30, 30);
                c.Endtime = new TimeSpan( 21, 30, 00);
                c.Status = "supervised";
                timetable.Add(c);
                return timetable;
                throw new Exception("Someren couldnt connect to database!!");
            }
        }
        public void DeleteTimetable(int Id)
        {
            timetable_db.DeleteTimetable(Id);
        }
    }
}
