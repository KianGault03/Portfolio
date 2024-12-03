using SimplyRugbySystem_KG___Version_1._0.Database_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
    /// Interaction logic for PlayerDetailsWindow.xaml
    /// </summary>
    public partial class PlayerDetailsWindow : Window
    { 
        //This window class handles all events for the Player Details Window 
        //Here the operations, Create, Update, delete and Search are triggered. 
        //This window class validates data and handles exceptions but the operations themselves are merely called from this window. 

        private DataContext context = new DataContext(); // Instance of the data context class 
        private Admin adminOperations = new Admin();     // Instance of the Admin class
        
        //Four boolean values that track the current active states of the teams
        //These are used before an operation to see what team should be edited 
        private bool isJuniorTeam = true; 
        private bool isUnder18sTeam = false;
        private bool is18sPlusTeam = false;
        private bool is21Team = false;
        //Two strings to keep track of the current user type and user login
        private string? currentUserRole;   
        private string? currentUserLogin;

        //Window constructor that takes in the users current role and the users ID
        public PlayerDetailsWindow(string? currentUserType, string? currentUsername)
        {
            currentUserLogin = currentUsername;
            currentUserRole = currentUserType;
            InitializeComponent();


            if(currentUserRole == "Admin")
            {
                //if the current user is an admin, by default check the Juniors Team box to display the Juniors Team
                checkBox_Juniors.IsChecked = true; // makes the checkbox checked which triggers the checkbox_Juniors event 


            }
            else if(currentUserRole == "Junior")
            {
                //If the user is a coach, disable all textboxes so they do not have the ability to edit records. 
                txt_PlayerName.IsEnabled = false;
                txt_Address.IsEnabled = false;
                txt_SRUNumber.IsEnabled = false;
                datePicker_DOB.IsEnabled = false;
                txt_Contact.IsEnabled = false;
                txt_YOS.IsEnabled = false;
                txt_BootSize.IsEnabled = false;

                checkBox_Juniors.IsChecked = true; // Displays the Junior Coach's team to them
                checkbox_consent.IsEnabled = false;
              
            }
            else if(currentUserRole == "Under 18s")
            {
                //If the user is a coach, disable all textboxes so they do not have the ability to edit records. 
                txt_PlayerName.IsEnabled = false;
                txt_Address.IsEnabled = false;
                txt_SRUNumber.IsEnabled = false;
                datePicker_DOB.IsEnabled = false;
                txt_Contact.IsEnabled = false;
                txt_YOS.IsEnabled = false;
                txt_BootSize.IsEnabled = false;

                checkBox_Under18s.IsChecked = true; // Displays the Under 18s Team to the coach
                checkbox_consent.IsEnabled = false;

            }
            else if(currentUserRole == "18+ Coach")
            {
                //If the user is a coach, disable all textboxes so they do not have the ability to edit records. 
                txt_PlayerName.IsEnabled = false;
                txt_Address.IsEnabled = false;
                txt_SRUNumber.IsEnabled = false;
                datePicker_DOB.IsEnabled = false;
                txt_Contact.IsEnabled = false;
                txt_YOS.IsEnabled = false;
                txt_BootSize.IsEnabled = false;

                checkBox_18Plus.IsChecked = true; // Displays the 18s + team to the coach 
                checkbox_consent.IsEnabled = false;

            }
            else if(currentUserRole == "Senior Coach")
            {
                //If the user is a coach, disable all textboxes so they do not have the ability to edit records. 
                txt_PlayerName.IsEnabled = false;
                txt_Address.IsEnabled = false;
                txt_SRUNumber.IsEnabled = false;
                datePicker_DOB.IsEnabled = false;
                txt_Contact.IsEnabled = false;
                txt_YOS.IsEnabled = false;
                txt_BootSize.IsEnabled = false;

                checkBox_21Plus.IsChecked = true; // Displays the 18s + Team to the coach
                checkbox_consent.IsEnabled = false;

            }
            
        }

        //Event handler that is triggered when the user clicks on the button labelled "Create"
        private void btn_Create_Click(object sender, RoutedEventArgs e)
        {
            if (currentUserRole == "Admin") // If the current user is an Admin permission granted 
            {
                if (txt_SRUNumber.Text == "") // Checks first to see if all values have been entered before creating
                {
                    MessageBox.Show("You must fill all fields before creating a new record");
                }
                else
                {
                    // stores all the entered values from the text box into local variables of the correct data type
                    string name = txt_PlayerName.Text;
                    string address = txt_Address.Text;
                    int sruNum;
                    string dob = datePicker_DOB.Text;
                    string consent;
                    int contact;
                    int YOS;
                    int bootSize;


                    try // try catch is used here to stop expected errors with converting a string to an int if the user enters letters into the number boxes
                    {
                        //Convert all strings in the text boxes to their intended integer storage
                        sruNum = int.Parse(txt_SRUNumber.Text);
                        contact = int.Parse(txt_Contact.Text);
                        YOS = int.Parse(txt_YOS.Text);
                        bootSize = int.Parse(txt_BootSize.Text);

                        //Local string called validate that calls the context method ValidateDate and sends over the strings to be validated 
                        //Whatever the return string type will be used to decided the next action
                        string validate = context.ValidateData(name, address, dob);

                        //If statement to check if the admin has declared that the new record has parental consent or not
                        if (checkbox_consent.IsChecked == true)
                        {
                            consent = "YES";
                        }
                        else
                        {
                            consent = "NO";
                        }

                        if (validate == "Passed") // if ValidateData returns "Passed" then all data is valid to be created 
                        {

                            if (isJuniorTeam == true) // if the Junior Team is active then proceed 
                            {
                                //Calls the admin class to create a new player in the Junior Table
                                //Sends over all the data to be added
                                adminOperations.CreateJuniorMember(name, address, sruNum, dob, consent, contact, YOS, bootSize);


                                //Clears all text and checks
                                txt_PlayerName.Clear(); 
                                txt_Address.Clear(); 
                                txt_SRUNumber.Clear();
                                checkbox_consent.IsChecked = false;
                                txt_Contact.Clear();
                                txt_YOS.Clear();
                                txt_BootSize.Clear();
                                datePicker_DOB.Text = null;

                                //Updates the list of players with the new version then displays the list to the ListView
                                context.JuniorUsers = context.Junior.ToList();
                                listItems.ItemsSource = context.JuniorUsers;

                            }
                            else if (isUnder18sTeam == true) // if the Under 18s Team is active then proceed 
                            {
                                //Calls the admin class to create a new player in the Under 18s Table
                                //Sends over all the data to be added
                                adminOperations.CreateUnder18sMember(name, address, sruNum, dob, consent, contact, YOS, bootSize);


                                //Clears all text and checks
                                txt_PlayerName.Clear(); 
                                txt_Address.Clear(); 
                                txt_SRUNumber.Clear();
                                checkbox_consent.IsChecked = false;
                                txt_Contact.Clear();
                                txt_YOS.Clear();
                                txt_BootSize.Clear();
                                datePicker_DOB.Text = null;

                                //Updates the list of players with the new version then displays the list to the ListView
                                context.under18sUsers = context.Under18s.ToList();
                                listItems.ItemsSource = context.under18sUsers;
                            }

                            else if (is18sPlusTeam == true) // if the 18s + Team is active then proceed 
                            {
                                //Calls the admin class to create a new player in the 18s+ Table
                                //Sends over all the data to be added
                                adminOperations.Create18PlusMember(name, address, sruNum, dob, contact, YOS, bootSize);

                                //Clears all text and checks
                                txt_PlayerName.Clear(); 
                                txt_Address.Clear(); 
                                txt_SRUNumber.Clear();
                                checkbox_consent.IsChecked = false;
                                txt_Contact.Clear();
                                txt_YOS.Clear();
                                txt_BootSize.Clear();
                                datePicker_DOB.Text = null;

                                //Updates the list of players with the new version then displays the list to the ListView
                                context._18Users = context.Above18.ToList();
                                listItems.ItemsSource = context._18Users;


                            }

                            else if (is21Team == true) // if the 21+ Team is active then proceed 
                            {
                                //Calls the admin class to create a new player in the 21+ Table
                                //Sends over all the data to be added
                                adminOperations.Create21PlusMember(name, address, sruNum, dob, contact, YOS, bootSize);

                                //Clears all text and checks
                                txt_PlayerName.Clear(); 
                                txt_Address.Clear(); 
                                txt_SRUNumber.Clear();
                                checkbox_consent.IsChecked = false;
                                txt_Contact.Clear();
                                txt_YOS.Clear();
                                txt_BootSize.Clear();
                                datePicker_DOB.Text = null;

                                //Updates the list of players with the new version then displays the list to the ListView
                                context._21Users = context.Senior.ToList();
                                listItems.ItemsSource = context._21Users;

                            }

                        }
                        else if (validate == "Name Error") // if ValidateData returns with a name error then stop the process and inform the user
                        {
                            MessageBox.Show("Name must contain between 1 and 50 characters");
                            txt_PlayerName.Focus();
                        }
                        else if (validate == "Email Length Error") // if ValidateData returns with a Email error then stop the process and inform the user
                        {
                            MessageBox.Show("Email must contain between 1 and 50 characters");
                            txt_Address.Text = null;
                            txt_Address.Focus();
                        }
                        else if (validate == "Date Not Picked") // if ValidateData returns with a date error then stop the process and inform the user
                        {
                            MessageBox.Show("A date of birth must be selected");


                        }
                        else
                        {
                            MessageBox.Show("Incorrect Value entered please try again");

                        }

                    }
                    catch // catch statement that tells the user to enter numerical values into these text boxes 
                    {
                        MessageBox.Show("SRU, Contact, YOS and Boot Size all must be numeric");
                        txt_SRUNumber.Text = null;
                        txt_Contact.Text = null;
                        txt_YOS.Text = null;
                        txt_BootSize.Text = null;
                    }
                }

            }
            else // if the user is not an Admin permission denied 
            {
                MessageBox.Show("Only Admins can create new users");
            }
        }
                
        //Event handler that unselects any currently viewed player and resets the list display to the full team
        private void btn_Unselect_Click(object sender, RoutedEventArgs e)
        {
            //Finds out what the current team is then redisplays that team
            if(isJuniorTeam == true)
            {
                listItems.SelectedItem = null;
                txt_Search.Text = "";
                context.JuniorUsers = context.Junior.ToList();
                listItems.ItemsSource = context.JuniorUsers.ToList() ;
            }
            else if(isUnder18sTeam == true) 
            {
                listItems.SelectedItem = null;
                txt_Search.Text = "";
                context.under18sUsers = context.Under18s.ToList();
                listItems.ItemsSource = context.under18sUsers.ToList();

            }
            else if(is18sPlusTeam == true) 
            {
                listItems.SelectedItem = null;
                txt_Search.Text = "";
                context._18Users = context.Above18.ToList();
                listItems.ItemsSource = context._18Users.ToList();

            }
            else if(is21Team == true) 
            {
                listItems.SelectedItem = null;
                txt_Search.Text = "";
                context._21Users = context.Senior.ToList();
                listItems.ItemsSource = context._21Users.ToList();


            }
        }

        //Event handler that triggers when the user clicks in the button labelled "Update"
        private void btn_UpdateRecord_Click(object sender, RoutedEventArgs e)
        {
            if (currentUserRole == "Admin") // if the current user is an admin then permission granted
            {
                if (txt_SRUNumber.Text == "") // first check to see if a user has been selected by checking to see if all text boxes are filled
                {
                    MessageBox.Show("You must select an existing record before updating");
                }
                else
                {
                    //stores all the textbox values into local variables 
                    string name = txt_PlayerName.Text;
                    string address = txt_Address.Text;
                    int sruNum;
                    string dob = datePicker_DOB.Text;
                    string consent;
                    int contact;
                    int YOS;
                    int bootSize;

                    //stores the chosen consent option for the user
                    if (checkbox_consent.IsChecked == true)
                    {
                        consent = "YES";
                        checkbox_consent.IsChecked = true;
                    }
                    else if (checkbox_consent.IsChecked == false)
                    {
                        consent = "NO";
                        checkbox_consent.IsChecked = false;
                    }
                    else
                    {
                        return;
                    }

                    try // try catch statement used to catch any invalid data type errors e.g. trying to put a string into an integer 
                    {
                        //convert all text box values that are numbers into integers 
                        sruNum = int.Parse(txt_SRUNumber.Text);
                        contact = int.Parse(txt_Contact.Text);
                        YOS = int.Parse(txt_YOS.Text);
                        bootSize = int.Parse(txt_BootSize.Text);

                        //Calls DataContext's method ValidateData to validate the strings before advancing 
                        string validate = context.ValidateData(name, address, dob);

                        if (validate == "Passed") // if validateData returns with "Passed" then it's acceptable to update these records to the user
                        {
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

                                    //Sends over all the intended data to be updated to the admin class while also sending over the user that has been selected
                                    adminOperations.UpdateJuniorMember(selectedUser, name, address, sruNum, dob, consent, contact, YOS, bootSize);
                                    context.SaveChanges(); // on return, save the updated changes 

                                    //Clears all text
                                    txt_PlayerName.Clear();
                                    txt_Address.Clear();
                                    txt_SRUNumber.Clear();
                                    checkbox_consent.IsChecked = false;
                                    txt_Contact.Clear();
                                    txt_YOS.Clear();
                                    txt_BootSize.Clear();
                                    datePicker_DOB.Text = null;
                                    listItems.SelectedItem = null;
                                    checkbox_consent.IsChecked = false;

                                }
                                else //If no record was selected inform the user they must do so before updating
                                {
                                    MessageBox.Show("You must select a record before updating");

                                    checkbox_consent.IsChecked = false;

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

                                    //Sends over all the intended data to be updated to the admin class while also sending over the user that has been selected
                                    adminOperations.UpdateUnder18sMember(selectedUser, name, address, sruNum, dob, consent, contact, YOS, bootSize);
                                    context.SaveChanges(); // on return, save the updated changes 

                                    //Clears all text
                                    txt_PlayerName.Clear();
                                    txt_Address.Clear();
                                    txt_SRUNumber.Clear();
                                    checkbox_consent.IsChecked = false;
                                    txt_Contact.Clear();
                                    txt_YOS.Clear();
                                    txt_BootSize.Clear();
                                    datePicker_DOB.Text = "";
                                    listItems.SelectedItem = null;
                                    checkbox_consent.IsChecked = false;
                                }
                                else //If no record was selected inform the user they must do so before updating
                                {
                                    MessageBox.Show("You must select a record before updating");
                                    checkbox_consent.IsChecked = false;
                                }

                            }
                            else if (is18sPlusTeam == true) // if the current team is 18+ then proceed 
                            {
                                //Displays the current table
                                context._18Users = context._18Users?.ToList();
                                listItems.ItemsSource = context._18Users;

                                _18Plus? selectedUser = listItems.SelectedItem as _18Plus; // creates an object of the class _18Plus and casts it to the selected item record


                                if (selectedUser != null) // if selectedItem cast returned null then no user was found of that selected type. Only proceed if the user was found 
                                {
                                    //Uses the Find() method to find a player by their ID
                                    _18Plus? user = context.Above18.Find(selectedUser.Id);  // creates a new instance of the _18Plus Squad class and stores the selected User
                                                                                            // within this object by searching for them with the ID property 

                                    //Sends over all the intended data to be updated to the admin class while also sending over the user that has been selected
                                    adminOperations.Update18PlusMember(selectedUser, name, address, sruNum, dob, contact, YOS, bootSize); 
                                    context.SaveChanges(); // on return, save the updated changes 

                                    //Clears all text
                                    txt_PlayerName.Clear();
                                    txt_Address.Clear();
                                    txt_SRUNumber.Clear();
                                    checkbox_consent.IsChecked = false;
                                    txt_Contact.Clear();
                                    txt_YOS.Clear();
                                    txt_BootSize.Clear();
                                    datePicker_DOB.Text = null;
                                    listItems.SelectedItem = null;
                                    checkbox_consent.IsChecked = false;
                                }
                                else //If no record was selected inform the user they must do so before updating
                                {
                                    MessageBox.Show("You must select a record before updating");
                                    checkbox_consent.IsChecked = false;
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

                                    //Sends over all the intended data to be updated to the admin class while also sending over the user that has been selected
                                    adminOperations.Update21PlusMember(selectedUser, name, address, sruNum, dob, contact, YOS, bootSize);
                                    context.SaveChanges(); // on return, save the updated changes 

                                    //Clears all text
                                    txt_PlayerName.Clear();
                                    txt_Address.Clear();
                                    txt_SRUNumber.Clear();
                                    checkbox_consent.IsChecked = false;
                                    txt_Contact.Clear();
                                    txt_YOS.Clear();
                                    txt_BootSize.Clear();
                                    datePicker_DOB.Text = null;

                                    listItems.SelectedItem = null;
                                    checkbox_consent.IsChecked = false;
                                }
                                else //If no record was selected inform the user they must do so before updating
                                {
                                    MessageBox.Show("You must select a record before updating");
                                    checkbox_consent.IsChecked = false;
                                }


                            }
                        }
                        else if (validate == "Name Error") // if validate data returns with a name error then do not proceed
                        {
                            MessageBox.Show("Name must contain between 1 and 50 characters");
                            txt_PlayerName.Clear();
                            txt_PlayerName.Focus();


                        }
                        else if (validate == "Email Length Error") // if validate data returns with a Email error then do not proceed
                        {
                            MessageBox.Show("Email must contain between 1 and 50 characters");
                            txt_Address.Focus();
                            txt_Address.Clear();

                        }
                        else if (validate == "Date Not Picked") // if validate data returns with a date error then do not proceed
                        {
                            MessageBox.Show("A date of birth must be selected");


                        }
                    }
                    catch // catches any data errors that happen if the user tries to enter a string into an integer variable
                    {
                        MessageBox.Show("SRU, Contact, YOS and Boot Size all must be numeric");
                        txt_SRUNumber.Text = null;
                        txt_Contact.Text = null;
                        txt_YOS.Text = null;
                        txt_BootSize.Text = null;
                    }

                }
            }
            else // message telling the coaches they don't have permission to update
            {
                MessageBox.Show("Only an Admin can update a record");
              
            }
        }

        //Event handler that triggers when the user clicks on the button labelled "Delete"
        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            if (currentUserRole == "Admin") // if the user is an admin then permission granted
            {
                if (isJuniorTeam == true) // if the junior team is active then proceed 
                {

                    JuniorSquad? selectedUser = listItems.SelectedItem as JuniorSquad; // creates an object of the class JuniorSquad and casts it to the selected item record


                    if (selectedUser != null) // if a user has been selected them proceed 
                    {
                        //Uses the Find() method to find a player by their ID
                        JuniorSquad? userJunior = context.Junior.Find(selectedUser.Id); // creates a new instance of the Junior Squad class and stores the selected User
                                                                                        // within this object by searching for them with the ID property 

                        if (userJunior != null) // if the user has been found then proceed 
                        {
                            context.Remove(userJunior); // Uses EntityFrameworkCore's Remove() method to remove the found user by sending over the user's record to be removed
                            context.SaveChanges();      // Saves the current version of the database after the record has been removed

                          
                            //Display the updated Juniors Table 
                            context.JuniorUsers = context.Junior.ToList();
                            listItems.ItemsSource = context.JuniorUsers;
                        }


                    }
                }
                else if(isUnder18sTeam == true) // if the Under 18s team is active then proceed 
                {
                    Under18s? selectedUser = listItems.SelectedItem as Under18s; // creates an object of the class Under18s and casts it to the selected item record


                    if (selectedUser != null) // if a user has been selected them proceed 
                    {
                        //Uses the Find() method to find a player by their ID
                        Under18s? userUnder = context.Under18s.Find(selectedUser.Id); // creates a new instance of the Under18s class and stores the selected User
                                                                                      // within this object by searching for them with the ID property 

                        if (userUnder != null) // if the user has been found then proceed 
                        {
                            context.Remove(userUnder); // Uses EntityFrameworkCore's Remove() method to remove the found user by sending over the user's record to be removed
                            context.SaveChanges();     // Saves the current version of the database after the record has been removed


                            //Display the updated Under 18s Table 
                            context.under18sUsers = context.Under18s.ToList();
                            listItems.ItemsSource = context.under18sUsers;
                        }


                    }
                }
                else if(is18sPlusTeam == true) // if the 18s+ team is active then proceed 
                {
                    _18Plus? selectedUser = listItems.SelectedItem as _18Plus; // creates an object of the class _18Plus and casts it to the selected item record


                    if (selectedUser != null) // if a user has been selected them proceed 
                    {
                        //Uses the Find() method to find a player by their ID
                        _18Plus? userPlus = context.Above18.Find(selectedUser.Id); // creates a new instance of the _18Plus class and stores the selected User
                                                                                   // within this object by searching for them with the ID property 

                        if (userPlus != null) // if the user has been found then proceed 
                        {
                            context.Remove(userPlus); // Uses EntityFrameworkCore's Remove() method to remove the found user by sending over the user's record to be removed
                            context.SaveChanges();    // Saves the current version of the database after the record has been removed


                            //Display the updated 18s+ Table 
                            context._18Users = context.Above18.ToList();
                            listItems.ItemsSource = context._18Users;
                        }


                    }
                }
                else if(is21Team  == true) // if the 21+ team is active then proceed 
                {
                    _21Plus? selectedUser = listItems.SelectedItem as _21Plus; // creates an object of the class _21Plus and casts it to the selected item record


                    if (selectedUser != null) // if a user has been selected them proceed 
                    {
                        //Uses the Find() method to find a player by their ID
                        _21Plus? user21 = context.Senior.Find(selectedUser.Id); // creates a new instance of the _21Plus class and stores the selected User
                                                                                // within this object by searching for them with the ID property 

                        if (user21 != null) // if the user has been found then proceed 
                        {
                            context.Remove(user21); // Uses EntityFrameworkCore's Remove() method to remove the found user by sending over the user's record to be removed
                            context.SaveChanges();  // Saves the current version of the database after the record has been removed


                            //Display the updated 21+ Table 
                            context._21Users = context.Senior.ToList();
                            listItems.ItemsSource = context._21Users;
                        }


                    }



                }
            }
            else
            {
                MessageBox.Show("Only an admin can delete a record");
                
            }
        }

        //Event handler that triggers when the user clicks on the search button
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
                            selectedUser.Add(context.JuniorUsers[i]); // add to the temp list the whole record at index i - the current record on the loop that matches
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


                            return; // end the loop
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

        //Event Handler that simply closes all windows 
        private void btn_Exit_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }
        
        //Four checkbox events 
        //These are triggered by a checked event 
        //Whatever one is chekced makes that team become the active team being edited and all other teams are put as false
        //These events are triggered during the build of the window and is determined by what user has entered the window. i.e. Junior Coach will be default run the checkBox_Juniors_Checked event
        private void checkBox_Juniors_Checked(object sender, RoutedEventArgs e)
        {
            if (currentUserRole == "Admin" || currentUserRole == "Junior") // checks to see if the person who triggered this event has permission to do so
            {
                //displays the Junior table to the screen
                context.JuniorUsers = context.Junior.ToList();
                listItems.ItemsSource = context.JuniorUsers;

                //Sets the datepicker to match the age range for the junior table.
                //This is our way of validating the DOB of our places by making it impossible for the user to select an invalid date for each team
                //The age range for Juniors is 11-14 years old

                datePicker_DOB.DisplayDateStart = new DateTime(2007, 1, 1);
                datePicker_DOB.DisplayDateEnd = new DateTime(2012, 12, 31);

                //Sets the Junior checkbox to true and all other teams to false
                checkBox_Juniors.IsChecked = true;
                checkBox_Under18s.IsChecked = false;
                checkBox_18Plus.IsChecked = false;
                checkBox_21Plus.IsChecked = false;
                checkbox_consent.IsEnabled = true;

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
                //Sets the datepicker to match the age range for the under18s table.
                //This is our way of validating the DOB of our places by making it impossible for the user to select an invalid date for each team
                //The age range for Under18s is 15-17 years old

                datePicker_DOB.DisplayDateStart = new DateTime(2005, 1, 1);
                datePicker_DOB.DisplayDateEnd = new DateTime(2007, 12, 30);

                //displays the Under18s table to the screen
                context.under18sUsers = context.Under18s.ToList();
                listItems.ItemsSource = context.under18sUsers;

                //Sets the under18s checkbox to true and all other teams to false
                checkBox_Juniors.IsChecked = false;
                checkBox_Under18s.IsChecked = true;
                checkBox_18Plus.IsChecked = false;
                checkBox_21Plus.IsChecked = false;
                checkbox_consent.IsEnabled = true;

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
                //displays the 18+ table to the screen
                context._18Users = context.Above18.ToList();
                listItems.ItemsSource = context._18Users;

                //Sets the datepicker to match the age range for the under18s table.
                //This is our way of validating the DOB of our places by making it impossible for the user to select an invalid date for each team
                //The age range for Under18s is 18-21 years old

                datePicker_DOB.DisplayDateStart = new DateTime(2003, 1, 1);
                datePicker_DOB.DisplayDateEnd = new DateTime(2005, 12, 30);

                //Sets the under18s checkbox to true and all other teams to false
                checkBox_Juniors.IsChecked = false;
                checkBox_Under18s.IsChecked = false;
                checkBox_18Plus.IsChecked = true;
                checkBox_21Plus.IsChecked = false;
                checkbox_consent.IsEnabled = false;

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
                //displays the 21+ table to the screen
                context._21Users = context.Senior.ToList();
                listItems.ItemsSource = context._21Users;

                //Sets the datepicker to match the age range for the under18s table.
                //This is our way of validating the DOB of our places by making it impossible for the user to select an invalid date for each team
                //The age range for Under18s is 21+ years old

                datePicker_DOB.DisplayDateStart = new DateTime(1992, 1, 1);
                datePicker_DOB.DisplayDateEnd = new DateTime(2004, 12, 30);

                //Sets the 21+ checkbox to true and all other teams to false
                checkBox_Juniors.IsChecked = false;
                checkBox_Under18s.IsChecked = false;
                checkBox_18Plus.IsChecked = false;
                checkBox_21Plus.IsChecked = true;
                checkbox_consent.IsEnabled = false;

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

        //Event handler that opens the email list window
        private void btn_EMail_Click(object sender, RoutedEventArgs e)
        {
            EmailWindow emailWindow = new EmailWindow(currentUserRole, currentUserLogin); // passes over the current user information for validation
            emailWindow.Show(); // opens the email window but also keeps the player details window open
        }
        //Event handler that opens the skill profile window
        private void btn_SkillWindow_Click(object sender, RoutedEventArgs e)
        {
            SkillProfileWindow window = new SkillProfileWindow(currentUserRole, currentUserLogin); // passes over the current user information for validation reasons
            window.Show();
            this.Close();
        }
        //Event handler that takes the user back to the starting screen and logs them out
        private void btn_LogOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
}
