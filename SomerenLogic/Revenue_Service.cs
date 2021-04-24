using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomerenDAL;
using SomerenModel;

namespace SomerenLogic
{
    public class Revenue_Service
    {
        Revenue_DAO revenue_db = new Revenue_DAO();

        public List<Revenue> GetRevenues(DateTime startDate, DateTime endDate)
        {
            try
            {
                List<Revenue> revenue = revenue_db.Db_Get_All_Revenue(startDate, endDate);
                return revenue;
            }
            catch (Exception)
            {
                
                throw new Exception("Someren couldn't connect to database!!");
            }
        }
        public List<Revenue> GetRevenues()
        {
            return revenue_db.Db_Get_All_Revenue();
        }
    }
        

    
}
