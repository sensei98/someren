using SomerenLogic;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SomerenUI
{
    public partial class SomerenUI : Form
    {
        SomerenLogic.Drink_Service drinkService = new SomerenLogic.Drink_Service();
        SomerenLogic.Activity_Service actService = new SomerenLogic.Activity_Service();
        
        public SomerenUI()
        {
            InitializeComponent();
        }
        
        private void SomerenUI_Load(object sender, EventArgs e)
        {
            showPanel("Dashboard");
        }

        private void showPanel(string panelName)
        {
            //dashboard

            if (panelName == "Dashboard")
            {

                // hide all other panels
                HidingPanels();

                // show dashboard
                pnl_Dashboard.Show();
                img_Dashboard.Show();
            }
            //for students
            else if (panelName == "Students")
            {
                // hide all other panels
                HidingPanels();

                // show students
                pnl_Students.Show();

                // fill the students listview within the students panel with a list of students
                SomerenLogic.Student_Service studService = new SomerenLogic.Student_Service();
                List<Student> studentList = studService.GetStudents();

                // clear the listview before filling it again
                listViewStudents.Clear();

                ///////remove this 
                listViewStudents.Columns.Add("Id");
                listViewStudents.Columns.Add("First Name");
                listViewStudents.Columns.Add("Last Name");
                listViewStudents.Columns.Add("Year");


                foreach (SomerenModel.Student s in studentList)
                {

                    ListViewItem li = new ListViewItem(s.StudentNumber.ToString());
                    li.SubItems.Add(s.FirstName.ToString());
                    li.SubItems.Add(s.LastName.ToString());
                    li.SubItems.Add(s.Year.ToString());
                    listViewStudents.Items.Add(li);

                }
            }
            //for lecturers
            else if (panelName == "Lecturers")
            {
                HidingPanels();

                PNL_TEACHERS.Show();

                // fill the students listview within the students panel with a list of students
                SomerenLogic.Teacher_Service teachService = new SomerenLogic.Teacher_Service();
                List<Teacher> teacherList = teachService.GetTeachers();

                // clear the listview before filling it again
                listViewTeachers.Items.Clear();

                foreach (SomerenModel.Teacher s in teacherList)
                {
                    ListViewItem li = new ListViewItem(s.TeacherNumber.ToString());
                    li.SubItems.Add(s.FirstName.ToString());
                    li.SubItems.Add(s.LastName.ToString());
                    li.SubItems.Add(s.Speciality.ToString());
                    listViewTeachers.Items.Add(li);

                }
            }
            // for rooms
            else if(panelName == "Rooms")
            {
                //hiding the panels you dont wanna show 
                HidingPanels();

                //showing Rooms
                PNL_Rooms.Show();

                //filling the rooms listview within the srooms panel with a list of rooms
                SomerenLogic.Room_Service roomService = new SomerenLogic.Room_Service();
                List<Room> roomList = roomService.GetRooms();

                foreach (SomerenModel.Room r in roomList)
                {
                    ListViewItem li = new ListViewItem(r.Number.ToString());
                    li.SubItems.Add(r.Capacity.ToString());
                   
                    if (r.Type == true)
                        li.SubItems.Add("Teacher");
                    else
                        li.SubItems.Add("Student");

                    LV_Rooms.Items.Add(li);
                }
            }
            //for drinks
            if (panelName == "Drinks")
            {
                //hide panels
                HidingPanels();
                //Show the panel
                Pnl_Drinks.Show();

                listViewsDrinks.Items.Clear();

                //Add columns
                listViewsDrinks.Columns.Add("Id");
                listViewsDrinks.Columns.Add("NameOfDrink");
                listViewsDrinks.Columns[1].Width = 100;
                listViewsDrinks.Columns.Add("Price");
                listViewsDrinks.Columns.Add("Stock");
                //listViewsDrinks.Columns.Add("studentId");
                ////listViewsDrinks.Columns[5].Width = 50;
                listViewsDrinks.Columns.Add(" ");
                listViewsDrinks.Columns.Add("Alcoholic");


                // Fill the drink
                LoadDrinks();
            }

            //for register
            if (panelName == "Register")
            {
                //hide panels 
                HidingPanels();

                //show pnl register
                PNL_Register.Show();
                Student_Service studentService = new Student_Service();
                List<Student> studentList = studentService.GetStudents();
                Drink_Service drinkService = new Drink_Service();
                List<Drinks> drinkList = drinkService.GetDrinks();

                listViewStudent.Items.Clear();
                listViewStudent.Columns.Add("Student ID", 100);
                listViewStudent.Columns.Add("Student Name", 200);

                listViewDrink.Items.Clear();
                //listViewDrink.Items.Add("DrinkID", 60);
                listViewDrink.Columns.Add("DrinkID", 80);
                listViewDrink.Columns.Add("DrinkName", 100);
                listViewDrink.Columns.Add("Price", 80);


                foreach (Student s in studentList)
                {
                    ListViewItem li = new ListViewItem(s.StudentNumber.ToString());
                    li.SubItems.Add(s.FullName);
                    listViewStudent.Items.Add(li);
                }

                foreach(Drinks d in drinkList)
                {
                    ListViewItem li = new ListViewItem(d.Id.ToString());
                    //li.SubItems.Add(d.NameOfDrink);
                    li.SubItems.Add(d.NameOfDrink);
                    li.SubItems.Add(d.Price.ToString());
                    listViewDrink.Items.Add(li);
                }

            }

            //for revenue --> RETAKE
            else if(panelName == "Revenue")
            {
                //hiding all other panels
                HidingPanels();
                //showing the revenue panel
                PNL_Revenue.Show();
                //generating the revenue table from database
                ShowRevenue();
            }

            //for activities
            if (panelName == "Activities")
            {
                //showing activities panel
                PnlActivities.Show();

                // clear the listview before filling it again
                listViewActivities.Clear();

                //add columns 
                listViewActivities.Columns.Add("Id");
                listViewActivities.Columns[0].Width = 30;
                listViewActivities.Columns.Add("ActivityName");
                listViewActivities.Columns[1].Width = 100;
                listViewActivities.Columns.Add("NumberofStudents");
                listViewActivities.Columns[2].Width = 100;
                listViewActivities.Columns.Add("NumberofSupervisors");
                listViewActivities.Columns[3].Width = 130;

                LoadActivities();
            }
            //for supervisors
            else if (panelName == "Supervisors")
            {
                HidingPanels();

                SomerenLogic.Teacher_Service teachService = new SomerenLogic.Teacher_Service();
                List<Teacher> teacherList = teachService.GetSupervisors();

                // clear the listview before filling it again
                listViewSupervisors.Items.Clear();

                foreach (SomerenModel.Teacher s in teacherList)
                {
                    ListViewItem li = new ListViewItem(s.TeacherNumber.ToString());
                    li.SubItems.Add(s.FirstName.ToString());
                    li.SubItems.Add(s.LastName.ToString());
                    li.SubItems.Add(s.Speciality.ToString());
                    li.SubItems.Add(s.Supervisor.ToString());
                    listViewSupervisors.Items.Add(li);
                }
            }
            //for timetbale
            else if (panelName == "Timetable")
            {
                HidingPanels();
                PNL_timetable.Show();
                LV_Timetable.Items.Clear(); 
            }

        }

        private void HidingPanels()
        {
            pnl_Dashboard.Hide();
            pnl_Students.Hide();
            PNL_TEACHERS.Hide();
            PNL_Rooms.Hide();
            Pnl_Drinks.Hide();
            img_Dashboard.Hide();
            PNL_timetable.Hide();
            PnlActivities.Hide();
            pnl_Supervisors.Hide();
            PNL_Register.Hide();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dashboardToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            showPanel("Dashboard");
        }
      
        //dashboard
        private void img_Dashboard_Click(object sender, EventArgs e)
        {
            MessageBox.Show("What happens in Someren, stays in Someren!");
        }
        //showing students panel
        private void studentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Students");
        } 

        //showing lectures panel
        private void lecturersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Lecturers");
        }

   
        private void roomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //whenever you click the room , the show panel is equal to room and so it displays it 
            showPanel("Rooms");
        }

        
        //showing drinks panel
        private void drinksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Drinks");
        }   


        private int DrinkId = 0;
        //updating drinks
        private void Btn_Update_Click(object sender, EventArgs e)
        {
            Drinks drinks = new Drinks()
            {
                Id = DrinkId,
                NameOfDrink = txtBox_NameOfDrink.Text,
                Price = decimal.Parse(txtBox_Price.Text),
                Stock = int.Parse(txtBox_Stock.Text),
                isAlcholic = AlcoholCheckBox.Checked
            };
            drinkService.UpdateDrink(drinks);
            LoadDrinks();
        }
        //loading drinks into the listview
        private void LoadDrinks()
        {
            listViewsDrinks.Items.Clear();

            List<Drinks> drinksList = drinkService.GetDrinks();

            foreach (SomerenModel.Drinks d in drinksList)
            {

                ListViewItem li = new ListViewItem(d.Id.ToString());
                li.SubItems.Add(d.NameOfDrink);
                li.SubItems.Add(d.Price.ToString());
                li.SubItems.Add(d.Stock.ToString());
                //li.SubItems.Add(d.studentId.ToString());
                d.Amount = d.Stock;
                if (d.Amount >= 10)
                {
                    li.SubItems.Add("✔️");
                }
                else
                {
                    li.SubItems.Add("⚠️");

                }
                if (d.isAlcholic)
                {
                    li.SubItems.Add("✔️");
                }
                listViewsDrinks.Items.Add(li);

            }
            clearData();
        }
      
        private void listView1_ItemActivate(object sender, EventArgs e)
        {
           
            DrinkId = int.Parse(listViewsDrinks.SelectedItems[0].SubItems[0].Text);
            txtBox_NameOfDrink.Text = listViewsDrinks.SelectedItems[0].SubItems[1].Text;
            txtBox_Price.Text = listViewsDrinks.SelectedItems[0].SubItems[2].Text;
            txtBox_Stock.Text = listViewsDrinks.SelectedItems[0].SubItems[3].Text;
            if (listViewsDrinks.SelectedItems[0].SubItems[4].Text == "✔️")
            {
                AlcoholCheckBox.Checked = true;
            }
            else
            {
                AlcoholCheckBox.Checked = false;
            }
        }
        //inserting drinks
        private void btn_Insert_Click(object sender, EventArgs e)
        {
            Drinks drinks = new Drinks()
            {
                Id = DrinkId,
                NameOfDrink = txtBox_NameOfDrink.Text,
                Price = decimal.Parse(txtBox_Price.Text),
                Stock = int.Parse(txtBox_Stock.Text),
                isAlcholic = AlcoholCheckBox.Checked

            };
            drinkService.InsertDrink(drinks);
            LoadDrinks();
        }

        //clearing data
        private void clearData()
        {
            txtBox_NameOfDrink.Clear();
            txtBox_Price.Clear();
            txtBox_Stock.Clear();
            AlcoholCheckBox.Checked = false;
        }
        //deleting a drink in the database
        private void Btn_Delete_Click(object sender, EventArgs e)
        {
            Drinks drinks = new Drinks()
            {
                Id = DrinkId,
                NameOfDrink = txtBox_NameOfDrink.Text,
                Price = decimal.Parse(txtBox_Price.Text),
                Stock = int.Parse(txtBox_Stock.Text)

            };
            drinkService.DeleteDrink(drinks);
            LoadDrinks();
            clearData();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

      
       
        //showing panel register
        private void registerToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            showPanel("Register");
        }
        // button for reserving a drink 
        private void button1_Click(object sender, EventArgs e)
        {
            List<int> drinkReserved = new List<int>();
            int selectedStudent = int.Parse(listViewStudent.SelectedItems[0].SubItems[0].Text);
           

            for (int i = 0; i < listViewDrink.Items.Count; i++)
            {
                if (listViewDrink.Items[i].Checked)
                {
                    drinkReserved.Add(int.Parse(listViewDrink.Items[i].SubItems[0].Text));
                }
            }

           
            Register_Service registerService = new Register_Service();
            foreach (int DrinkID in drinkReserved)
            {
                registerService.AddRegister(selectedStudent, DrinkID);
            }
            showPanel("Register");


        }

        //showing panel activities
        private void activitiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Activities");
        }
        private int ActivityID = 0;
        //making the items in the listview selectable
        private void listViewActivites_ItemActivate(object sender, EventArgs e)
        {
            ActivityID = int.Parse(listViewActivities.SelectedItems[0].SubItems[0].Text);
            txtBoxDescription.Text = listViewActivities.SelectedItems[0].SubItems[1].Text;
            txtBoxNStudents.Text = listViewActivities.SelectedItems[0].SubItems[2].Text;
            txtBoxNSupervisors.Text = listViewActivities.SelectedItems[0].SubItems[3].Text;

        }
        private void LoadActivities()
        {
            listViewActivities.Items.Clear();

            // fill the students listview within the students panel with a list of students
            
            List<Activity> studentList = actService.GetActivities();
           
                foreach (SomerenModel.Activity s in studentList)
                {

                    ListViewItem li = new ListViewItem(s.Id.ToString());
                    li.SubItems.Add(s.ActivityName);
                    li.SubItems.Add(s.NumberofStudents.ToString());
                    li.SubItems.Add(s.NumberofSupervisors.ToString());

                    listViewActivities.Items.Add(li);
                }

            clearData();
        }

        //insert button
        private void btnInsert_Click(object sender, EventArgs e)
        {
            Activity activity = new Activity()
            {
                Id = ActivityID,
                ActivityName = txtBoxDescription.Text,
                NumberofStudents = int.Parse(txtBoxNStudents.Text),
                NumberofSupervisors = int.Parse(txtBoxNSupervisors.Text)
            };
            actService.AddActivity(activity);
            LoadActivities();
           
        }
        //button for editing an activity
        private void btnEdit_Click(object sender, EventArgs e)
        {
            Activity activity = new Activity()
            {
                Id = ActivityID,
                ActivityName = txtBoxDescription.Text,
                NumberofStudents = int.Parse(txtBoxNStudents.Text),
                NumberofSupervisors = int.Parse(txtBoxNSupervisors.Text)
            };
            actService.EditActivity(activity);
            LoadActivities();
        }
        //clearing data in the textbox
        private void ClearData()
        {
            txtBoxDescription.Clear();
            txtBoxNStudents.Clear();
            txtBoxNSupervisors.Clear();
        }
        //button for removing an activity from the database
        private void btnRemove_Click(object sender, EventArgs e)
        {
            actService.RemoveActivity(ActivityID);
            LoadActivities();
            ClearData();
        }
        //showing the supervisors panel
        private void supervisorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Supervisors");
        }

       
        //button for adding a supervisor
        private void ADDSUPERVISOR_Click_1(object sender, EventArgs e)
        {
            pnl_SecondTeachers.Show();

            SomerenLogic.Teacher_Service teachService = new SomerenLogic.Teacher_Service();
            List<Teacher> teacherList = teachService.GetTeachers();

            // clear the listview before filling it again
            listViewSecondTeachers.Items.Clear();



            foreach (SomerenModel.Teacher s in teacherList)
            {
                ListViewItem li = new ListViewItem(s.FirstName.ToString());
                li.SubItems.Add(s.LastName.ToString());
                listViewSecondTeachers.Items.Add(li);
               
            }
        }
        //button for inserting a supervisor
        private void button2_Click(object sender, EventArgs e)
        {
            SomerenLogic.Teacher_Service teachService = new SomerenLogic.Teacher_Service();
           // List<Teacher> teacherList = teachService.GetTeachers();

          
              if (listViewSecondTeachers.Items.Count > 0)
              {
                    ListViewItem items = listViewSecondTeachers.SelectedItems[0];
                    string firstName = items.SubItems[0].Text;
                    string lastName = items.SubItems[1].Text;
                    teachService.InsertSupervisors(firstName, lastName);
                    showPanel("Supervisors");

              }

               else
               {
                   MessageBox.Show("Please select a teacher");
               }
        }
        //button for removing a supervisor from the table
        private void REMOVESUPERVISOR_Click(object sender, EventArgs e)
        {

            SomerenLogic.Teacher_Service teachService = new SomerenLogic.Teacher_Service();
            List<Teacher> teacherList = teachService.GetTeachers();


            if (listViewSupervisors.Items.Count > 0)
            {
                ListViewItem items = listViewSupervisors.SelectedItems[0];
                int teacherID = int.Parse(items.SubItems[0].Text);
                MessageBox.Show("Are you sure you want to delete supervisor?");
                teachService.DeleteSupervisor(teacherID);
                showPanel("Supervisors");
            }

            else
            {
                MessageBox.Show("Please select a teacher");
            }
        }
        //for showing the Timetable Panel
        private void timetableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Timetable");
        }

        SomerenDAL.Timetable_DAO time = new SomerenDAL.Timetable_DAO();
        //button for monday
        private void btnMonday_Click(object sender, EventArgs e)
        { 
            ShowTimeTables(DayOfWeek.Monday);
            LV_Timetable.Show();
        }
        //button for tuesday
        private void btnTuesday_Click(object sender, EventArgs e)
        {
            ShowTimeTables(DayOfWeek.Tuesday);
            LV_Timetable.Show();
        }
        //button for wednesday
        private void btnWednesday_Click(object sender, EventArgs e)
        {
            ShowTimeTables(DayOfWeek.Wednesday);
            LV_Timetable.Show();
        }
        //button for thursday
        private void btnThursday_Click(object sender, EventArgs e)
        {
            ShowTimeTables(DayOfWeek.Thursday);
            LV_Timetable.Show();
        }
        //button for friday
        private void btnFriday_Click(object sender, EventArgs e)
        {
            ShowTimeTables(DayOfWeek.Friday);
            LV_Timetable.Show();
        }
        SomerenLogic.Timetable_Service timet = new SomerenLogic.Timetable_Service();

        //showing the columns in the listview
        private void ShowTimeTables(DayOfWeek DayOfWeek)
        {
            LV_Timetable.Items.Clear();
          
            List<Timetable> timetableList = timet.GetTimetable(DayOfWeek.ToString());
            foreach (SomerenModel.Timetable t in timetableList)
            {
                ListViewItem li = new ListViewItem(t.Activity.ToString());
               // li.SubItems.Add(
                li.SubItems.Add(t.Supervisor.ToString());
                li.SubItems.Add(t.Date.ToLongDateString());
                li.SubItems.Add(t.Starttime.ToString());
                li.SubItems.Add(t.Endtime.ToString());
                li.SubItems.Add(t.Status.ToString());
                LV_Timetable.Items.Add(li);

            }
        }
        //button for deleting a column in the database for timetable 
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (LV_Timetable.Items.Count > 0)
            {
                ListViewItem items = LV_Timetable.SelectedItems[0];
                int timetableID = int.Parse(items.SubItems[0].Text);
                timet.DeleteTimetable(timetableID);
                showPanel("Timetable");
            }
        }

        //FOR REVENUE --> retake
        SomerenLogic.Revenue_Service revenueService = new SomerenLogic.Revenue_Service();


        private void revenueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Revenue");
        }
        
       
        private void ShowRevenueWithDates(DateTime startDate, DateTime endDate)
        {
            //filling the revenue listview with the list of revenues
            List<Revenue> revenueList = revenueService.GetRevenues(startDate,endDate);

            //clearing the listview 
            LV_Revenue.Items.Clear();

            foreach (SomerenModel.Revenue re in revenueList)
            {
                ListViewItem li = new ListViewItem(re.Sales.ToString());
                li.SubItems.Add(re.Turnover.ToString());
                li.SubItems.Add(re.NrOfCustomers.ToString());
                LV_Revenue.Items.Add(li);
            }
        }
        private void ShowRevenue()
        {
            List<Revenue> revenueList = revenueService.GetRevenues();

            //clearing the listview 
            LV_Revenue.Items.Clear();

            foreach (SomerenModel.Revenue re in revenueList)
            {
                ListViewItem li = new ListViewItem(re.Sales.ToString());
                li.SubItems.Add(re.Turnover.ToString());
                li.SubItems.Add(re.NrOfCustomers.ToString());
                LV_Revenue.Items.Add(li);
            }
        }
        //button for calculating the revenue
        private void button3_Click(object sender, EventArgs e)
        {
            DateTime startDate = Calendar.SelectionStart;
            DateTime endDate = Calendar.SelectionEnd;

            if (startDate < DateTime.Today && endDate < DateTime.Today)
                ShowRevenueWithDates(startDate, endDate);
            else
                MessageBox.Show("Enter a valid date!");
        }

       
    }
}
