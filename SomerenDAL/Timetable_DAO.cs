using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using SomerenModel;

namespace SomerenDAL
{
    public class Timetable_DAO:Base
    {
        public List<Timetable> Db_Get_All_Timetable(string dayOfWeek)
        {
            string query = Weeks(dayOfWeek);
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }
        public string Weeks(string DayOfWeek)
        {
            string query =$"SELECT a.ActivityName, s.FirstName, [date], starttime,endtime,[status]" +
                " FROM timetable " +
                "JOIN teacher as s on s.Id = Timetable.Supervisor  " +
                "JOIN activities as a on a.Id = Timetable.Activity  " +
                $" WHERE FORMAT(timetable.[Date], 'dddd') = '{DayOfWeek}' ";
            return query;
        }

        private List<Timetable> ReadTables(DataTable datatable)
        {
            List<Timetable> timeTableList = new List<Timetable>();
            foreach (DataRow dr in datatable.Rows)
            {
                Timetable timetable = new Timetable()
                {
                    Activity = (string)dr["ActivityName"],
                    Supervisor = (string)dr["Firstname"],
                    Date = (DateTime)dr["Date"],
                    Starttime = (TimeSpan)dr["Starttime"],
                    Endtime = (TimeSpan)dr["Endtime"],
                    Status = (string)dr["Status"]
                };
                timeTableList.Add(timetable);
            }
            return timeTableList;
        }
        public void DeleteTimetable(int Id)
        {
            string query = $"DELETE FROM Timetable WHERE Id = {Id}";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            ExecuteEditQuery(query, sqlParameters);
        }
    }
}
