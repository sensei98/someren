using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomerenDAL;
using SomerenModel;
using System.Collections.ObjectModel;
using System.Windows.Forms;

namespace SomerenLogic
{
    public class Teacher_Service
    {

        Teacher_DAO teacher_db = new Teacher_DAO();

        public List<Teacher> GetTeachers()
        {
            try
            {
                List<Teacher> teacher = teacher_db.Db_Get_All_Teachers();
                return teacher;
            }
            catch (Exception)
            {
                //// something went wrong connecting to the database, so we will add a fake student to the list to make sure the rest of the application continues working!
                List<Teacher> teacher = new List<Teacher>();
                Teacher a = new Teacher();
                a.FirstName = "No Name";
                a.LastName = "No Last Name";
                a.TeacherNumber = 127345;
                a.Speciality = "Nothing";
                teacher.Add(a);
                Teacher b = new Teacher();
                b.FirstName = "No Name 2";
                b.LastName = "No Last Name 2";
                b.TeacherNumber = 197474;
                b.Speciality = "Nothing 2";
                teacher.Add(b);
                return teacher;
                throw new Exception("Someren couldn't connect to the database");


            }

        }
        public List<Teacher> GetSupervisors()
        {
            try
            {
                List<Teacher> teacher = teacher_db.Db_Get_All_Supervisors();
                return teacher;
            }
            catch (Exception)
            {
                //// something went wrong connecting to the database, so we will add a fake student to the list to make sure the rest of the application continues working!
                List<Teacher> teacher = new List<Teacher>();
                Teacher a = new Teacher();
                a.FirstName = "No Name";
                a.LastName = "No Last Name";
                a.TeacherNumber = 127345;
                a.Speciality = "Nothing";
                
                teacher.Add(a);
                Teacher b = new Teacher();
                b.FirstName = "No Name 2";
                b.LastName = "No Last Name 2";
                b.TeacherNumber = 197474;
                b.Speciality = "Nothing 2";
                teacher.Add(b);
                return teacher;
                throw new Exception("Someren couldn't connect to the database");


            }
        }
        public void InsertSupervisors(string firstName, string lastName)
        {
            try
            {
                teacher_db.InsertSupervisor(firstName, lastName);
            }
            catch
            {
                MessageBox.Show("There is nothing here!");
            }
        }
        public void DeleteSupervisor(int teacherID)
        {
            try
            {
                teacher_db.DeleteSupervisor(teacherID);
            }
            catch
            {
                MessageBox.Show("Nothing to delete!!");
            }
        }

    }
}
