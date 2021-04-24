using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SomerenLogic
{
    public class Drink_Service
    {
        Drink_DAO drinks_db = new Drink_DAO();

        public List<Drinks> GetDrinks()
        {
            try
            {
                List<Drinks> drink = drinks_db.Db_Get_All_Drinks();
                return drink;
            }
            catch (Exception )
            {
                List<Drinks> drink = new List<Drinks>();
                Drinks a = new Drinks();
                a.NameOfDrink = "Gingerale";
                a.Id = 12;
                a.Price = 2;
                //a.Alcohol = false;
                //a.NonAlcohol = true;
                a.Stock = 10;
                //a.studentId = 1;
                //a.Sold = 3;
                drink.Add(a);

                Drinks b = new Drinks();
                b.NameOfDrink = "Mango";
                b.Id = 23;
                b.Price = 2;
                //b.Alcohol = false;
                //b.NonAlcohol = true;
                b.Stock = 11;
                //b.studentId = 1;
                //a.Sold = 5;

                drink.Add(b); ;
                return drink;
                throw new Exception("Someren couldn't connect to the database");


            }
        }
        public void UpdateDrink(Drinks drinks)
        {
            drinks_db.UpdateDrink(drinks);
        }
        public void InsertDrink(Drinks drinks)
        {
            drinks_db.InsertDrink(drinks);
        }
        public void DeleteDrink(Drinks drinks)
        {
            drinks_db.DeleteDrink(drinks);
        }

    }
}
