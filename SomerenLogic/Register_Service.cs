using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomerenDAL;
using SomerenModel;
using System.Collections.ObjectModel;


namespace SomerenLogic
{
    public class Register_Service
    {
      
            Register_DAO reg = new Register_DAO();
            public void AddRegister(int studentID, int drinkID)
            {
                reg.AddRegister(studentID, drinkID);
            }

        
    }
}
