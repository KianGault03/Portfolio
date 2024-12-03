using SimplyRugbySystem_KG___Version_1._0.Database_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SimplyRugbySystem_KG___Version_1._0
{
    /// <summary>
    /// Interaction logic for EmailWindow.xaml
    /// </summary>
    public partial class EmailWindow : Window
    {
        // Window class that handles the event triggers for the email window 
        
        private DataContext context = new DataContext(); // instance of the data context class 
        private string? currentUser; // private string that stores the current user type
        private string? currentUserLogin;

        //Constructor that has conditional checks to see who the current user is that just opened the window
        public EmailWindow(string? currentUserRole, string? currentLogin) // takes in two values when opened 
        {
            InitializeComponent();
            //stores the passed over user role and user login
            currentUser = currentUserRole;
            currentUserLogin = currentLogin;

            if (currentUser == "Admin")
            {
                //if the current user is an admin, by default check the Juniors Team box to display the Juniors Team
                checkBox_Juniors.IsChecked = true; // makes the checkbox checked which triggers the checkbox_Juniors event 
              

            }
            else if (currentUser == "Junior")
            {
                //if the current is a Junior Coach then display the Juniors Team 
                checkBox_Juniors.IsChecked = true; // makes the checkbox checked which triggers the checkbox_Juniors event 

            }
            else if (currentUser == "Under 18s")
            {
                //if the current user is a under 18s coach then display the under 18s team
                checkBox_Under18s.IsChecked = true; // makes the checkbox checked which triggers the checkbox_Under18s event 

            }
            else if (currentUser == "18+ Coach")
            {
                //if the current user is a 18s + coach then display the 18s+ team
                checkBox_18Plus.IsChecked = true; // makes the checkbox checked which triggers the checkbox_18Plus event 

            }
            else if (currentUserRole == "Senior Coach")
            {

                checkBox_21Plus.IsChecked = true; // makes the checkbox checked which triggers the checkbox_21Plus event 

            }
            


        }

        //Event handlers for the different check boxes on the window
        //These are used to switch displays from team to team
        //These events can only be triggered by the admin 
        //Coaches only trigger the event on arrival of the window and will only trigger their own teams checkbox
        private void checkBox_Juniors_Checked(object sender, RoutedEventArgs e)
        {
            if(currentUser == "Admin" ||  currentUser == "Junior")
            {
                checkBox_Juniors.IsChecked = true; // sets the check box to checked 
                checkBox_Under18s.IsChecked = false; //unchecks the check box 
                checkBox_18Plus.IsChecked = false; //unchecks the check box 
                checkBox_21Plus.IsChecked = false; //unchecks the check box 

                //Uses the SELECT statement to select only the Name and Email out of the current team
                var result = context.Junior.Select(e => new { e.Name, e.Email }).ToList();

                // foreach statement to display all items stored in the result list 
                foreach (var item in result)
                {
                    list_Emails.Items.Add(item.Name + "\n" + item.Email + "\n"); // adds the names and emails of all junior players 


                }
            }
            else // if another coach tries to access a different team 
            {
                MessageBox.Show("You can only view your own teams E-mails");
                checkBox_Juniors.IsChecked = false;
            }
        }

        private void checkBox_Under18s_Checked(object sender, RoutedEventArgs e)
        {
            if (currentUser == "Admin" || currentUser == "Under 18s")
            {
                list_Emails.Items.Clear();
                

                checkBox_Juniors.IsChecked = false; //unchecks the check box 
                checkBox_Under18s.IsChecked = true; //Makes the check box checked 
                checkBox_18Plus.IsChecked = false; //unchecks the check box 
                checkBox_21Plus.IsChecked = false; //unchecks the check box 

                //Uses the SELECT statement to select only the Name and Email out of the current team
                var result = context.Under18s.Select(e => new { e.Name, e.Email }).ToList();

                // foreach statement to display all items stored in the result list 
                foreach (var item in result)
                {
                    list_Emails.Items.Add(item.Name + "\n" + item.Email + "\n"); // adds the names and emails of all Under 18s players 


                }


            }
            else // if another coach tries to access a different team 
            {
                MessageBox.Show("You can only view your own teams E-mails");
                checkBox_Under18s.IsChecked = false;
            }
        }

        private void checkBox_18Plus_Checked(object sender, RoutedEventArgs e)
        {
            if (currentUser == "Admin" || currentUser == "18+ Coach")
            {
                list_Emails.Items.Clear();
               

                checkBox_Juniors.IsChecked = false; //unchecks the check box
                checkBox_Under18s.IsChecked = false; //unchecks the check box
                checkBox_18Plus.IsChecked = true; // checks the check box
                checkBox_21Plus.IsChecked = false; //unchecks the check box

                //Uses the SELECT statement to select only the Name and Email out of the current team
                var result = context.Above18.Select(e => new { e.Name, e.Email }).ToList();

                // foreach statement to display all items stored in the result list 
                foreach (var item in result)
                {
                    list_Emails.Items.Add(item.Name + "\n" + item.Email + "\n"); // adds the names and emails of all Under 18s players 


                }


            }
            else // if another coach tries to access a different team 
            {
                MessageBox.Show("You can only view your own teams E-mails");
                checkBox_18Plus.IsChecked = false;
            }
        }

        private void checkBox_21Plus_Checked(object sender, RoutedEventArgs e)
        {
            if (currentUser == "Admin" || currentUser == "Senior Coach")
            {
                list_Emails.Items.Clear();
                

                checkBox_Juniors.IsChecked = false; //unchecks the check box
                checkBox_Under18s.IsChecked = false; //unchecks the check box
                checkBox_18Plus.IsChecked = false; //unchecks the check box
                checkBox_21Plus.IsChecked = true; //checks the check box

                //Uses the SELECT statement to select only the Name and Email out of the current team
                var result = context.Senior.Select(e => new { e.Name, e.Email }).ToList();

                //foreach statement to display all items stored in the result list 
                foreach (var item in result)
                {
                    list_Emails.Items.Add(item.Name + "\n" + item.Email + "\n"); // adds the names and emails of all Under 18s players 


                }


            }
            else // if another coach tries to access a different team 
            {
                MessageBox.Show("You can only view your own teams E-mails");
                checkBox_21Plus.IsChecked = false;
            }
        }

        //Event handler for the button that returns the user back to the player details window
        private void btn_Return_Click(object sender, RoutedEventArgs e)
        {
            
            this.Close();
        }
    }
}
