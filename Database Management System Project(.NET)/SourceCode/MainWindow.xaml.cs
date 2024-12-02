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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SimplyRugbySystem_KG___Version_1._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string? username; // private string that is responsible for storing the entered username
        private string? password; // private string that is responsible for storing the entered password
        
        private bool validateAdmin; // boolean value that is used to check if the login is valid or not
        private string? validateCoaches;
        private ClubMember member = new ClubMember(); // instance of the object member from the class ClubMember 
        private Coach coach = new Coach();
        private Admin admin = new Admin();
        

        public MainWindow() // Constructor 
        {
            InitializeComponent(); //Initialize the window for login
            txt_Username.Focus(); // Brings focus back to the username box 

            //Displays all logins to the screen. NOTE: This will be removed when the application is installed onto Simply Rugby's servers. This is here for testing and demo purposes
            txtblk_Users.Text += "Admin: \nUsername: " + admin.AdminID + "\nPassword: " + admin.AdminPassword;
            txtblk_Users.Text += "\n\nJunior Coach: \nUsername: " + coach.JuniorCoachID + "\nPassword: " + coach.JuniorCoachPassword;
            txtblk_Users.Text += "\n\nUnder 18s Coach: \nUsername: " + coach.Under18sCoach + "\nPassword: " + coach.Under18sCoachPassword;
            txtblk_Users.Text += "\n\n18s + Coach: \nUsername: " + coach.Coach18PlusID + "\nPassword: " + coach.Coach18PlusPassword;
            txtblk_Users.Text += "\n\n21+ Coach: \nUsername: " + coach.Coach21PlusID + "\nPassword: " + coach.Coach21PlusPassword;


        }

        public void btn_Submit_Click(object sender, RoutedEventArgs e) // event handler for the button called submit
        {
            username = txt_Username.Text; //Takes the entered value from within the text box and stores it
            password = txt_Password.Password; //Takes the entered value from within the text box and stores it

            validateAdmin = member.doesLoginMatchAdminID(username, password); // calls the club member class method that performs a 
                                                                              // boolean check. It passes over the entered username and 
                                                                              // password
            
            validateCoaches = member.doesLoginMatchCoachID(username, password);

            if(validateAdmin == true) //if statement that checks the validation result from the method called earlier 
            {                         // if the result returns true the admin will be directed forward 
                                      // if the result returns false the user will be denided access 

                
                HubWindow hub = new HubWindow("Admin", username); // Calls the hub window while sending over the current user data
                hub.Show(); // Opens the object window 
                this.Close(); // closes the current window 
            }
            else if(validateCoaches == "Junior")
            {
               
                HubWindow hub = new HubWindow("Junior", username); // Calls the hub window while sending over the current user data
                hub.Show(); // Opens the object window 
                this.Close(); // closes the current window
            }
            else if (validateCoaches == "Under18s")
            {
                
                HubWindow hub = new HubWindow("Under 18s", username); // Calls the hub window while sending over the current user data
                hub.Show(); // Opens the object window 
                this.Close(); // closes the current window
            }
            else if (validateCoaches == "18+")
            {
                
                HubWindow hub = new HubWindow("18+ Coach", username); // Calls the hub window while sending over the current user data
                hub.Show(); // Opens the object window 
                this.Close(); // closes the current window
            }
            else if (validateCoaches == "21+")
            {
                
                HubWindow hub = new HubWindow("Senior Coach", username); // Calls the hub window while sending over the current user data
                hub.Show(); // Opens the object window 
                this.Close(); // closes the current window
            }
            else // if the validation is rejected the user will be denied access 
            {
                MessageBox.Show("Login does not match stored login"); // Message informing the user their login was incorrect 
                txt_Username.Text = ""; // Clears the username textbox 
                txt_Password.Password = ""; // Clears the password box 

                txt_Username.Focus(); // Brings focus back to the username box so the user can retry
            }
    
        }

        
    }
}
