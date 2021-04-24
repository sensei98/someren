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
    public class Room_DAO : Base
    {

        public List<Room> Db_Get_All_Rooms()
        {
            string query = "SELECT Id, RoomType ,NumberOfBeds FROM [Rooms]";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }
        private List<Room> ReadTables(DataTable datatable)
        {
            List<Room> rooms = new List<Room>();
            foreach (DataRow dr in datatable.Rows)
            {
                Room room = new Room()
                {
                    Number = (int)dr["Id"],
                    Capacity = (int)dr["NumberOfBeds"],
                    Type = (bool)dr["RoomType"]

                };
                rooms.Add(room);
            }
            return rooms;
        }
    }
}
