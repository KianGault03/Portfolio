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
    /// Interaction logic for HubWindow.xaml
    /// </summary>
    public partial class HubWindow : Window
    {
        private string currentUserRole;  // string that stores the current users role i.e Admin or Coach 
                                         // this is then used to give permission access depending on who the current user is
        
        private string currentUserLogin; // string that stores the login that got accepted so it can be displayed to the user

        public HubWindow(string currentUserType, string currentUserID) // Constructor for the class that takes in two strings 
        {
            currentUserRole = currentUserType; // stores the taken in string to determin the user type (Admin or Coach)
            currentUserLogin = currentUserID;  // stores the taken in string containing the entered login for the current user
            InitializeComponent(); // Builds the window 

            txt_CurrentUser.Text = currentUserRole; //Displays the current user type to the screen
            txt_CurrentUsersID.Text = currentUserLogin; // Displays the current user's login to the screen
        }

        private void btn_Return_Click(object sender, RoutedEventArgs e) // Event handler for the button labelled 'Return' 
        {
            MainWindow mainWindow = new MainWindow(); // Creates an instance of the mainwindow class 
            mainWindow.Show(); // uses the class object to show the window to the user
            this.Close(); // closes the current window 
        }

        private void btn_PlayerDetails_Click(object sender, RoutedEventArgs e) // Event handler for the button labelled 'player details 
        {
            // This button's functionality is to naviagate to the player details database window but only if the user is the Admin

            
                PlayerDetailsWindow window = new PlayerDetailsWindow(currentUserRole, currentUserLogin);
                window.Show();
                this.Close();
            
           
        }

        private void btn_PlayerSkillDatabase_Click(object sender, RoutedEventArgs e) // Event handler for the button labelled 'player skill profiles
        {
            SkillProfileWindow window = new SkillProfileWindow(currentUserRole, currentUserLogin);
            window.Show();
            this.Close();

        }
    }
}
