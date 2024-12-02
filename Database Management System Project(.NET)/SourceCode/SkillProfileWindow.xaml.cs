using SimplyRugbySystem_KG___Version_1._0.Database_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Metadata;
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
using System.Xml.Linq;

namespace SimplyRugbySystem_KG___Version_1._0
{
    /// <summary>
    /// Interaction logic for SkillProfileWindow.xaml
    /// </summary>
    public partial class SkillProfileWindow : Window
    {
        //This window class handles all events related to the player skill profiles

        //instances of the context and coach classes 
        private DataContext context = new DataContext();
        private Coach coachOperations = new Coach();

        //Four booleans to manage the activity of the teams
        private bool isJuniorTeam = true;
        private bool isUnder18sTeam = false;
        private bool is18sPlusTeam = false;
        private bool is21Team = false;

        //Two strings used to store the current users login data
        private string? currentUserRole;
        private string? currentUserLogin;

        //An array to store the set skill range for the profiles. Current range is 0 out of 5
        private int[] skillLevel = new int[6] { 0, 1, 2, 3, 4, 5 };

        //constructor that populates all the combo boxes with the skill level ranges and also handles user permission access
        public SkillProfileWindow(string? currentUserType, string? currentUsername) // takes in two strings from any window that calls this one
        {
            //Stores the information of the current user
            currentUserRole = currentUserType;
            currentUserLogin = currentUsername;

            InitializeComponent();

            //Uploads the skill rating range to all ComboBoxes 
            comboBox_Standard.ItemsSource = skillLevel;
            comboBox_Spin.ItemsSource = skillLevel;
            comboBox_Pop.ItemsSource = skillLevel;

            comboBox_Front.ItemsSource = skillLevel;
            comboBox_Rear.ItemsSource = skillLevel;
            comboBox_Side.ItemsSource = skillLevel;
            comboBox_Scrabble.ItemsSource = skillLevel;

            comboBox_Drop.ItemsSource = skillLevel;
            comboBox_Goal.ItemsSource = skillLevel;
            comboBox_Grubber.ItemsSource = skillLevel;
            comboBox_Punt.ItemsSource = skillLevel;

            if (currentUserRole == "Admin") // If the current user is an admin then by default show the Juniors 
            {
                checkBox_Juniors.IsChecked = true; // trigger the juniors checked event 


            }
            else if (currentUserRole == "Junior") // if the current user is a junior coach then show the Juniors 
            {

                checkBox_Juniors.IsChecked = true; // trigger the juniors checked event 
                

            }
            else if (currentUserRole == "Under 18s") // if the current user is a under 18s coach then display the under 18s team
            {
              

                checkBox_Under18s.IsChecked = true; // trigger the under 18s checked event 
               

            }
            else if (currentUserRole == "18+ Coach") // if the current user is a 18+ Coach then display the 18s Plus team
            {
                

                checkBox_18Plus.IsChecked = true; // trigger the 18Plus checked event 
               

            }
            else if (currentUserRole == "Senior Coach") // if the current user is a 21+ coach then display the seniors team
            {
               

                checkBox_21Plus.IsChecked = true; // trigger the 21 plus checked event 
               

            }
           
        }

        //Four checkbox events 
        //These are triggered by a checked event 
        //Whatever one is chekced makes that team become the active team being edited and all other teams are put as false
        //These events are triggered during the build of the window and is determined by what user has entered the window.
        //i.e. Junior Coach will be default run the checkBox_Juniors_Checked event
        private void checkBox_Juniors_Checked(object sender, RoutedEventArgs e)
        {
            if (currentUserRole == "Admin" || currentUserRole == "Junior") // checks to see if the person who triggered this event has permission to do so
            {
                //displays the Junior Profiles to the screen
                context.JuniorUsers = context.Junior.ToList();
                listItems.ItemsSource = context.JuniorUsers;

                //Sets the Junior checkbox to true and all other teams to false
                checkBox_Juniors.IsChecked = true;
                checkBox_Under18s.IsChecked = false;
                checkBox_18Plus.IsChecked = false;
                checkBox_21Plus.IsChecked = false;


                //Updates the boolean values so Junior is the active team and all other teams are false
                isJuniorTeam = true;
                isUnder18sTeam = false;
                is18sPlusTeam = false;
                is21Team = false;
                txtblk_CurrentTeam.Text = "Junior Team"; // Displays the current team name to the screen
            }
            else // permission denied message for other coach types
            {
                MessageBox.Show("You can only view your own teams data");
                checkBox_Juniors.IsChecked = false;
            }
        }

        private void checkBox_Under18s_Checked(object sender, RoutedEventArgs e) 
        {
            if (currentUserRole == "Admin" || currentUserRole == "Under 18s") // checks to see if the person who triggered this event has permission to do so
            {
                //displays the Under18s Profiles to the screen
                context.under18sUsers = context.Under18s.ToList();
                listItems.ItemsSource = context.under18sUsers;

                //Sets the under18s checkbox to true and all other teams to false
                checkBox_Juniors.IsChecked = false;
                checkBox_Under18s.IsChecked = true;
                checkBox_18Plus.IsChecked = false;
                checkBox_21Plus.IsChecked = false;
              

                txtblk_CurrentTeam.Text = "Under18s"; // Displays the current team name to the screen

                //Updates the boolean values so under18s is the active team and all other teams are false
                isJuniorTeam = false;
                isUnder18sTeam = true;
                is18sPlusTeam = false;
                is21Team = false;
            }
            else // permission denied message for other coach types
            {
                MessageBox.Show("You can only view your own teams data");
                checkBox_Under18s.IsChecked = false;
            }

        }

        private void checkBox_18Plus_Checked(object sender, RoutedEventArgs e)
        {
            if (currentUserRole == "Admin" || currentUserRole == "18+ Coach") // checks to see if the person who triggered this event has permission to do so
            {
                //displays the 18+ profiles to the screen
                context._18Users = context.Above18.ToList();
                listItems.ItemsSource = context._18Users;

                //Sets the under18s checkbox to true and all other teams to false
                checkBox_Juniors.IsChecked = false;
                checkBox_Under18s.IsChecked = false;
                checkBox_18Plus.IsChecked = true;
                checkBox_21Plus.IsChecked = false;
               

                txtblk_CurrentTeam.Text = "18-20 Squad"; // Displays the current team name to the screen

                //Updates the boolean values so 18 plus is the active team and all other teams are false
                isJuniorTeam = false;
                isUnder18sTeam = false;
                is18sPlusTeam = true;
                is21Team = false;
            }
            else // permission denied message for other coach types
            {
                MessageBox.Show("You can only view your own teams data");
                checkBox_18Plus.IsChecked = false;
            }
        }

        private void checkBox_21Plus_Checked(object sender, RoutedEventArgs e)
        {
            if (currentUserRole == "Admin" || currentUserRole == "Senior Coach") // checks to see if the person who triggered this event has permission to do so
            {
                //displays the 21+ profiles to the screen
                context._21Users = context.Senior.ToList();
                listItems.ItemsSource = context._21Users;

                //Sets the 21+ checkbox to true and all other teams to false
                checkBox_Juniors.IsChecked = false;
                checkBox_Under18s.IsChecked = false;
                checkBox_18Plus.IsChecked = false;
                checkBox_21Plus.IsChecked = true;
                

                txtblk_CurrentTeam.Text = "21+ Squad"; // Displays the current team name to the screen

                //Updates the boolean values so 21+ is the active team and all other teams are false
                isJuniorTeam = false;
                isUnder18sTeam = false;
                is18sPlusTeam = false;
                is21Team = true;
            }
            else // permission denied message for other coach types
            {
                MessageBox.Show("You can only view your own teams data");
                checkBox_21Plus.IsChecked = false;
            }
        }

        //Event handler that unselects any currently viewed player and resets the list display to the full profiles for the current team
        private void btn_Unselect_Click(object sender, RoutedEventArgs e)
        {
            //Finds out what the current team is then redisplays that team
            if (isJuniorTeam == true)
            {
                listItems.SelectedItem = null;
                txt_Search.Text = "";
                context.JuniorUsers = context.Junior.ToList();
                listItems.ItemsSource = context.JuniorUsers.ToList();
            }
            else if (isUnder18sTeam == true)
            {
                listItems.SelectedItem = null;
                txt_Search.Text = "";
                context.under18sUsers = context.Under18s.ToList();
                listItems.ItemsSource = context.under18sUsers.ToList();

            }
            else if (is18sPlusTeam == true)
            {
                listItems.SelectedItem = null;
                txt_Search.Text = "";
                context._18Users = context.Above18.ToList();
                listItems.ItemsSource = context._18Users.ToList();

            }
            else if (is21Team == true)
            {
                listItems.SelectedItem = null;
                txt_Search.Text = "";
                context._21Users = context.Senior.ToList();
                listItems.ItemsSource = context._21Users.ToList();


            }
        }
        // event handler for updating skill profiles 
        private void btn_UpdateRecord_Click(object sender, RoutedEventArgs e)
        {
            // list of local integers that will be used to store all the skill profile ratings for the selected player
            int standard;
            int spin;
            int pop;

            int front;
            int rear;
            int side;
            int scrabble;

            int drop;
            int punt;
            int grubber;
            int goal;

           
            
            //convert all combo box selections into their respective integer variables. No error should arrise as the combo boxes have been set to only integer options.    
            standard = int.Parse(comboBox_Standard.Text);
            spin = int.Parse(comboBox_Spin.Text);
            pop = int.Parse(comboBox_Pop.Text);

            front = int.Parse(comboBox_Front.Text);
            rear = int.Parse(comboBox_Rear.Text); 
            side = int.Parse(comboBox_Side.Text);
            scrabble = int.Parse(comboBox_Scrabble.Text);
  
            drop = int.Parse(comboBox_Drop.Text); 
            punt = int.Parse(comboBox_Punt.Text);
            grubber = int.Parse(comboBox_Grubber.Text);
            goal = int.Parse(comboBox_Goal.Text);


                
            if (isJuniorTeam == true) // if the current team is Junior then proceed 
            {

                //Displays the current table  
                context.JuniorUsers = context.Junior.ToList();
                listItems.ItemsSource = context.JuniorUsers;

                JuniorSquad? selectedUser = listItems.SelectedItem as JuniorSquad; // creates an object of the class JuniorSquad and casts it to the selected item record



                if (selectedUser != null) // if selectedItem cast returned null then no user was found of that selected type. Only proceed if the user was found 
                {
                    //Uses the Find() method to find a player by their ID
                    JuniorSquad? user = context.Junior.Find(selectedUser.Id); // creates a new instance of the Junior Squad class and stores the selected User
                                                                              // within this object by searching for them with the ID property 
                    if (user != null) 
                    {
                        //Sends over all the intended skill ratings to be updated to the Coach class while also sending over the user that has been selected
                        coachOperations.UpdateJuniorUser(user, standard, spin, pop, front, rear, side, scrabble, drop, punt, grubber, goal);
                    
                        context.SaveChanges(); // on return, save the updated changes 

                        //Unselects the record after updating is finished
                        listItems.SelectedItem = null; 
                            
                    }

                }
                else //If no record was selected inform the user they must do so before updating
                {
                        MessageBox.Show("You must select a record before updating");


                }
            }
            else if (isUnder18sTeam == true) // if the current team is Under 18s then proceed 
            {

                //Displays the current table
                context.under18sUsers = context.Under18s.ToList();
                listItems.ItemsSource = context.under18sUsers;

                    
                Under18s? selectedUser = listItems.SelectedItem as Under18s; // creates an object of the class Under 18s and casts it to the selected item record



                if (selectedUser != null) // if selectedItem cast returned null then no user was found of that selected type. Only proceed if the user was found 
                {
                    //Uses the Find() method to find a player by their ID
                    Under18s? user = context.Under18s.Find(selectedUser.Id); // creates a new instance of the Under 18s Squad class and stores the selected User
                                                                             // within this object by searching for them with the ID property 

                    if (user != null)
                    {
                        //Sends over all the intended profile ratings to be updated to the Coach class while also sending over the user that has been selected
                        coachOperations.UpdateUnder18sUser(user, standard, spin, pop, front, rear, side, scrabble, drop, punt, grubber, goal);
                           
                        context.SaveChanges();  // on return, save the updated changes 

                        //Unselects the user after updating is finished
                        listItems.SelectedItem = null;

                    }

                }
                else //If no record was selected inform the user they must do so before updating
                {
                       
                    MessageBox.Show("You must select a record before updating");


                }
            }
            else if (is18sPlusTeam == true) // if the current team is 18+ then proceed 
            {

                //Displays the current table
                context._18Users = context.Above18.ToList();
                listItems.ItemsSource = context._18Users;

                    
                _18Plus? selectedUser = listItems.SelectedItem as _18Plus; // creates an object of the class _18Plus and casts it to the selected item record



                if (selectedUser != null) // if selectedItem cast returned null then no user was found of that selected type. Only proceed if the user was found 
                {
                    //Uses the Find() method to find a player by their ID
                    _18Plus? user = context.Above18.Find(selectedUser.Id); // creates a new instance of the _18Plus Squad class and stores the selected User
                                                                           // within this object by searching for them with the ID property 

                    if (user != null)
                    {
                        //Sends over all the intended skill ratings to be updated to the Coach class while also sending over the user that has been selected
                        coachOperations.Update18PlusUser(user, standard, spin, pop, front, rear, side, scrabble, drop, punt, grubber, goal);
                            
                        context.SaveChanges(); // on return, save the updated changes 

                        //Unselects the user after the updating process has finished
                        listItems.SelectedItem = null;

                    }

                }
                else //If no record was selected inform the user they must do so before updating
                {
                        MessageBox.Show("You must select a record before updating");


                }
            }
            else if (is21Team == true) // if the current team is 21+ then proceed 
            {

                //Displays the current table
                context._21Users = context.Senior.ToList();
                listItems.ItemsSource = context._21Users;

                    
                _21Plus? selectedUser = listItems.SelectedItem as _21Plus; // creates an object of the class _21Plus and casts it to the selected item record



                if (selectedUser != null) // if selectedItem cast returned null then no user was found of that selected type. Only proceed if the user was found 
                {
                    //Uses the Find() method to find a player by their ID
                    _21Plus? user = context.Senior.Find(selectedUser.Id); // creates a new instance of the _21Plus Squad class and stores the selected User
                                                                          // within this object by searching for them with the ID property 

                    if (user != null)
                    {
                        //Sends over all the intended skill ratings to be updated to the coach class while also sending over the user that has been selected
                        coachOperations.Update21PlusUser(user, standard, spin, pop, front, rear, side, scrabble, drop, punt, grubber, goal);
                           
                        context.SaveChanges(); // on return, save the updated changes  

                        //Unselects the user aftet the updating process is completed 
                        listItems.SelectedItem = null;

                    }

                }
                else //If no record was selected inform the user they must do so before updating
                {
                       
                    MessageBox.Show("You must select a record before updating");
                }
            }



        }

        //Event handler that handles the process of searching for a skill profile 
        private void btn_Search_Click(object sender, RoutedEventArgs e)
        {
            try // try catch to handle the exception if the user tries to enter a non-numerical value into the search box
            {
                int userID = int.Parse(txt_Search.Text); // store the searched SRU number into a local integer
                listItems.ItemsSource = null; // Clears the ListView

                if (isJuniorTeam == true) // if the junior team is active then proceed 
                {
                    List<JuniorSquad> selectedUser = new List<JuniorSquad>(); // Creates a new temp list of type JuniorSquad to store the found user records in

                    for (int i = 0; i < context.JuniorUsers?.Count; i++) // for loop that loops the length of the JuniorUsers list
                    {
                        if (userID == context.JuniorUsers[i].SRU) // if the entered SRU numbers the stored SRU number on this iteration then proceed else continue the loop
                        {
                            context.JuniorUsers = context.Junior.ToList(); // Update the junior users list to the most recent version
                            selectedUser.Add(context.JuniorUsers[i]);  // add to the temp list the whole record at index i - the current record on the loop that matches
                            listItems.ItemsSource = selectedUser; // display the new temp list to the ListView


                            return; // end the loop
                        }

                    }
                }
                else if (isUnder18sTeam == true) // if the Under 18s team is active then proceed
                {
                    List<Under18s> selectedUser = new List<Under18s>(); // Creates a new temp list of type Under18s to store the found user records in

                    for (int i = 0; i < context.under18sUsers?.Count; i++) // for loop that loops the length of the Under18sUsers list
                    {
                        if (userID == context.under18sUsers[i].SRU) // if the entered SRU numbers the stored SRU number on this iteration then proceed else continue the loop
                        {
                            context.under18sUsers = context.Under18s.ToList(); // Update the under 18s users list to the most recent version
                            selectedUser.Add(context.under18sUsers[i]); // add to the temp list the whole record at index i - the current record on the loop that matches
                            listItems.ItemsSource = selectedUser; // display the new temp list to the ListView


                            return; // end the loop
                        }

                    }


                }
                else if (is18sPlusTeam == true) // if the 18+ team is active then proceed 
                {
                    List<_18Plus> selectedUser = new List<_18Plus>(); // Creates a new temp list of type _18Plus to store the found user records in

                    for (int i = 0; i < context._18Users?.Count; i++) // for loop that loops the length of the _18Users list
                    {
                        if (userID == context._18Users[i].SRU) // if the entered SRU numbers the stored SRU number on this iteration then proceed else continue the loop
                        {
                            context._18Users = context.Above18.ToList(); // Update the under 18+ users list to the most recent version
                            selectedUser.Add(context._18Users[i]); // add to the temp list the whole record at index i - the current record on the loop that matches
                            listItems.ItemsSource = selectedUser; // display the new temp list to the ListView


                            return; // end the loop
                        }

                    }

                }
                else if (is21Team == true) // if the 21+ team is active then proceed 
                {
                    List<_21Plus> selectedUser = new List<_21Plus>(); // Creates a new temp list of type _21Plus to store the found user records in

                    for (int i = 0; i < context._21Users?.Count; i++) // for loop that loops the length of the _18Users list
                    {
                        if (userID == context._21Users[i].SRU) // if the entered SRU numbers the stored SRU number on this iteration then proceed else continue the loop
                        {
                            context._21Users = context.Senior.ToList(); // Update the under 21+ users list to the most recent version
                            selectedUser.Add(context._21Users[i]); // add to the temp list the whole record at index i - the current record on the loop that matches
                            listItems.ItemsSource = selectedUser; // display the new temp list to the ListView


                            return;  // end the loop
                        }

                    }

                }
            }
            catch // if the user doesn't enter a numerical value
            {
                MessageBox.Show("You must enter a players SRU number that you wish to find");
                txt_Search.Clear();
            }
            
        }

        //Event handler that handles the navigation to the main login page
        private void btn_LogOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        //navigation that sends the user to the players details window and passes along the current user information
        private void btn_PlayerDetailsWindow_Click(object sender, RoutedEventArgs e)
        {
            PlayerDetailsWindow window = new PlayerDetailsWindow(currentUserRole, currentUserLogin);
            window.Show();
            this.Close();
        }
    }
}
