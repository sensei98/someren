using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using SomerenModel;
using System.Data;
namespace SomerenDAL
{
    public class Revenue_DAO:Base
    {
        public List<Revenue> Db_Get_All_Revenue(DateTime startDate, DateTime endDate)
        {
            string query = GetAllRevenue(startDate, endDate);
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }
       
        public string GetAllRevenue(DateTime startDate, DateTime endDate)
        {
            string startDateFormat = startDate.ToString("yyyy-MM-dd");
            string endDateFormat = endDate.ToString("yyyy-MM-dd");

            string query = "SELECT COUNT (R.drinksID) AS [totalDrinks], COUNT (DISTINCT R.StudentID) AS [NrofCustomers], ((SUM(D.Price)) * COUNT (D.ID)) AS [Turnover] " +
                                " FROM revenue AS R" +
                                " JOIN student AS S ON S.Id = R.StudentID" +
                                " JOIN drinks AS D ON D.id = R.DrinksID" +
                                $" WHERE R.purchaseDate BETWEEN '{startDateFormat}' AND '{endDateFormat}'; ";

            return query;
        }

        public List<Revenue> Db_Get_All_Revenue()
        {
            string query = "SELECT COUNT (R.drinksID) AS [TotalDrinks],  COUNT (DISTINCT R.StudentID) AS [NrofCustomers] ,((SUM(D.Price)) * COUNT (D.ID)) AS [Turnover] " +
                                " FROM revenue AS R" +
                                " JOIN student AS S ON S.Id = R.StudentID" +
                                " JOIN drinks AS D ON D.id = R.DrinksID";

            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Revenue> ReadTables(DataTable dataTable)
        {
            List<Revenue> revenues = new List<Revenue>();
            Revenue revenue;

            foreach (DataRow dr in dataTable.Rows)
            {
                try
                {
                    revenue = new Revenue()
                    {
                        Sales = (int)dr["TotalDrinks"],
                        Turnover = (decimal)dr["Turnover"],
                        NrOfCustomers = (int)dr["NrofCustomers"]
                    };
                }
                catch
                {
                    try
                    {
                        revenue = new Revenue()
                        {
                            Sales = (int)dr["TotalDrinks"],
                            Turnover = (decimal)dr["Turnover"],
                            NrOfCustomers = (int)dr["NrofCustomers"]
                        };
                    }
                    catch
                    {
                        revenue = new Revenue()
                        {
                            Sales = 0,
                            Turnover = 0
                        };
                    }

                }

                revenues.Add(revenue);
            }
            return revenues;
        }

    }
}
