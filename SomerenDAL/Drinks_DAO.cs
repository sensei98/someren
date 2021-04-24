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
    public class Drink_DAO : Base
    {
        public List<Drinks> Db_Get_All_Drinks()
        {
            //selecting and sorting the items

            string query = "SELECT Id,NameOfDrink,Price,Stock,Alcohol FROM [Drinks] WHERE stock > 1 AND price > 1 AND NameOfDrink NOT IN ('Water','Orangeade','Cherry juice') ORDER BY Stock,Price ";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Drinks> ReadTables(DataTable datatable)
        {
            List<Drinks> drinkList = new List<Drinks>();

            foreach (DataRow dr in datatable.Rows)
            {

                //if (dr["NameOfDrink"].ToString() == "Water" || dr["NameOfDrink"].ToString() == "Orangeade" || dr["NameOfDrink"].ToString() == "Cherry juice")
                //{
                //    //not to include water and the indicated juices to the list
                //    continue;
                //}
                Drinks drinks = new Drinks()
                {
                    Id = (int)dr["Id"],
                    NameOfDrink = (String)dr["NameOfDrink"],
                    Price = (decimal)dr["Price"],
                    Stock = (int)dr["Stock"],
                    isAlcholic=(bool)dr["Alcohol"]

                };
                drinkList.Add(drinks);
            }
            return drinkList;
        }
        public void UpdateDrink(Drinks drinks)
        {
           string query= $"update Drinks Set NameOfDrink = '{drinks.NameOfDrink}', Price = {drinks.Price},Stock= {drinks.Stock},Alcohol={Convert.ToInt32(drinks.isAlcholic)} where Id = {drinks.Id}";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            ExecuteEditQuery(query, sqlParameters);
        }
        public void InsertDrink(Drinks drinks)
        {
            string query = $"insert into Drinks(NameOfDrink,Price,Stock,Alcohol) values('{drinks.NameOfDrink}',{drinks.Price},{drinks.Stock},{Convert.ToInt32( drinks.isAlcholic)});";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            ExecuteEditQuery(query, sqlParameters);
           
        }
        public void DeleteDrink(Drinks drinks)
        {
            string query = $"Delete from Drinks where Id = {drinks.Id}";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            ExecuteEditQuery(query, sqlParameters);

        }

    }
}
