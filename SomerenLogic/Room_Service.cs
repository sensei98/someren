using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SomerenDAL;
using SomerenModel;
using System.Threading.Tasks;

namespace SomerenLogic
{
    public class Room_Service
    {
        Room_DAO room_db = new Room_DAO();

        public List<Room> GetRooms()
        {
            try
            {
                List<Room> room = room_db.Db_Get_All_Rooms();
                return room;
            }
            catch (Exception)
            {
                List<Room> room = new List<Room>();
                Room r1 = new Room();
                r1.Number = 2;
                r1.Capacity = 30;
                r1.Type = true;
                room.Add(r1);


                Room r2 = new Room();
                r2.Number = 2;
                r2.Capacity = 20;
                r2.Type = false;
                room.Add(r2);

                return room;
                throw new Exception("Someren couldnt connect!");
            }

        }
    }
}
