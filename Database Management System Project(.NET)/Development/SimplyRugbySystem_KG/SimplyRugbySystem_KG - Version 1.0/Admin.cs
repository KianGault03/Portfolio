using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows;
using SimplyRugbySystem_KG___Version_1._0.Database_Classes;
using System.Net;
using System.Reflection.Metadata;
using System.Xml.Linq;
using System.Diagnostics;

namespace SimplyRugbySystem_KG___Version_1._0
{
    
    public class Admin
    {
        //This class exists for the Admin User and all their attributes and behaviours. Whenever an operation containing an admin
        //is needed this class is called. 

        private string adminID = "Admin"; // stored login for the admin of the club
        private string adminPassword = "Admins"; // stored password for the admin of the club 
        private DataContext context = new DataContext(); // Creates an instance of the data context class to perform database operations. 

        public string AdminID // property for the admin ID 
        {
            get { return adminID; }  // returns the the private variable for the login
            set { adminID = value; } // sets the value to the private string (this is likely to not be needed but the option is still there)
        }

        public string AdminPassword // property for the admin password
        {
            get { return adminPassword; }  // returns the the private variable for the password
            set { adminPassword = value; } // sets the value to the private string (this is likely to not be needed but the option is still there)
        }
       
        
        // This method is called by the club member class when a login as been submitted. This method takes in a username 
        // and passsword and then checks these passed in values against it's own privately stored IDs and Passswords. 
        // if there is a match it will return true or if there isn't it will return false. 
        public bool loginChecker(string username, string password)
        {
            string enterUsername = username;
            string enterPassword = password;

            if (AdminID == enterUsername && AdminPassword == enterPassword)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //The first set up database operations for the admin that handles creating and updating Junior Team members
        //These methods both take in all the entered data by the user from within the player details window
        //The data has already been validated here so it's okay to upload to the database
        public void CreateJuniorMember(string name, string address, int sruNum, string dob, string consent, int contact, int YOS, int boot)
        {
            //Uses the entityFrameWork.Core method Add() to add users to data context's Junior instance of the Junior Squad Class
            //This method will create a new row.
           context.Junior.Add(new JuniorSquad()
           {
               Name = name, // add the entered name to the Name field 
               Email = address, // add the entered Email address to the Email field
               SRU = sruNum, // add the entered SRU number to the SRU field
               DOB = dob, // add the entered DOB from the datepicker to the DOB string field 
               Consent = consent, // add the chosen consent to the consent field 
               ContactNumber = contact, // add the entered contact to the contact field 
               YearsOfService = YOS, // add the entered years of service number to the YOS field 
               BootSize = boot // add the entered boot size to the boot field
            }); 
           context.SaveChanges(); //EntityFrameWork.core uses DbContext to save the recently added changes. 
        }

        public void UpdateJuniorMember(JuniorSquad user, string name, string address, int sruNum, string dob, string consent, int contact, int YOS, int boot)
        {
           //Uses the passed in user of type JuniorSquad which has the current viewed players record. We then use this user type to update the correcr users attributes

            user.Name = name; // updates the entity property to match the updated name 
            user.Email = address; // updates the entity property to match the updated address 
            user.SRU = sruNum; // updates the entity property to match the updated SRU
            user.DOB = dob; // updates the entity property to match the updated DOB 
            user.Consent = consent; // updates the entity property to match the updated Consent choice
            user.ContactNumber = contact; // updates the entity property to match the updated contact number choice 
            user.YearsOfService = YOS; // updates the entity property to match the updated years of service number
            user.BootSize = boot; // updates the entity property to match the updated boot size

           
            
        }


        //The Second set of database operations for the admin that handles creating and updating Under 18s Team members
        //These methods both take in all the entered data by the user from within the player details window
        //The data has already been validated here so it's okay to upload to the database
        public void CreateUnder18sMember(string name, string address, int sruNum, string dob, string consent, int contact, int YOS, int boot)
        {
            //Uses the entityFrameWork.Core method Add() to add users to data context's Under18s instance of the Under 18s Squad Class
            //This method will create a new row.
            context.Under18s.Add(new Under18s()
            {
                Name = name, // add the entered name to the Name field 
                Email = address, // add the entered Email address to the Email field
                SRU = sruNum, // add the entered SRU number to the SRU field
                DOB = dob, // add the entered DOB from the datepicker to the DOB string field 
                Consent = consent, // add the chosen consent to the consent field 
                ContactNumber = contact, // add the entered contact to the contact field 
                YearsOfService = YOS, // add the entered years of service number to the YOS field 
                BootSize = boot // add the entered boot size to the boot field
            });
            context.SaveChanges(); //EntityFrameWork.core uses DbContext to save the recently added changes. 
        }

        public void UpdateUnder18sMember(Under18s user, string name, string address, int sruNum, string dob, string consent, int contact, int YOS, int boot)
        {
            //Uses the passed in user of type Under18s which has the current viewed players record. We then use this user type to update the correcr users attributes

            user.Name = name; // updates the entity property to match the updated name 
            user.Email = address; // updates the entity property to match the updated address 
            user.SRU = sruNum; // updates the entity property to match the updated SRU
            user.DOB = dob; // updates the entity property to match the updated DOB 
            user.Consent = consent; // updates the entity property to match the updated Consent choice
            user.ContactNumber = contact; // updates the entity property to match the updated contact number choice 
            user.YearsOfService = YOS; // updates the entity property to match the updated years of service number
            user.BootSize = boot; // updates the entity property to match the updated boot size

            

        }


        //The Third set of database operations for the admin that handles creating and updating 18+ Team members
        //These methods both take in all the entered data by the user from within the player details window
        //The data has already been validated here so it's okay to upload to the database
        public void Create18PlusMember(string name, string address, int sruNum, string dob, int contact, int YOS, int boot)
        {
            //Uses the entityFrameWork.Core method Add() to add users to data context's Above18s instance of the _18Plus Squad Class
            //This method will create a new row.
            context.Above18.Add(new _18Plus()
            {
                Name = name, // add the entered name to the Name field 
                Email = address, // add the entered Email address to the Email field
                SRU = sruNum, // add the entered SRU number to the SRU field
                DOB = dob, // add the entered DOB from the datepicker to the DOB string field 
                ContactNumber = contact, // add the entered contact to the contact field 
                YearsOfService = YOS, // add the entered years of service number to the YOS field
                BootSize = boot // add the entered boot size to the boot field
            });
            context.SaveChanges(); //EntityFrameWork.core uses DbContext to save the recently added changes. 
        }

        public void Update18PlusMember(_18Plus user, string name, string address, int sruNum, string dob, int contact, int YOS, int boot)
        {
            //Uses the passed in user of type _18Plus which has the current viewed players record. We then use this user type to update the correcr users attributes

            user.Name = name; // updates the entity property to match the updated name 
            user.Email = address; // updates the entity property to match the updated address 
            user.SRU = sruNum; // updates the entity property to match the updated SRU
            user.DOB = dob; // updates the entity property to match the updated DOB 
            user.ContactNumber = contact; // updates the entity property to match the updated contact number choice 
            user.YearsOfService = YOS; // updates the entity property to match the updated years of service number
            user.BootSize = boot; // updates the entity property to match the updated boot size


        }


        //The Final set of database operations for the admin that handles creating and updating 18+ Team members
        //These methods both take in all the entered data by the user from within the player details window
        //The data has already been validated here so it's okay to upload to the database
        public void Create21PlusMember(string name, string address, int sruNum, string dob, int contact, int YOS, int boot)
        {
            //Uses the entityFrameWork.Core method Add() to add users to data context's Senior instance of the _21Plus Squad Class
            //This method will create a new row.
            context.Senior.Add(new _21Plus()
            {
                Name = name, // add the entered name to the Name field 
                Email = address, // add the entered Email address to the Email field
                SRU = sruNum, // add the entered SRU number to the SRU field
                DOB = dob, // add the entered DOB from the datepicker to the DOB string field 
                ContactNumber = contact, // add the entered contact to the contact field 
                YearsOfService = YOS, // add the entered years of service number to the YOS field
                BootSize = boot // add the entered boot size to the boot field
            });
            context.SaveChanges(); //EntityFrameWork.core uses DbContext to save the recently added changes. 
        }

        public void Update21PlusMember(_21Plus user, string name, string address, int sruNum, string dob, int contact, int YOS, int boot)
        {
            //Uses the passed in user of type _18Plus which has the current viewed players record. We then use this user type to update the correcr users attributes

            user.Name = name; // updates the entity property to match the updated name 
            user.Email = address; // updates the entity property to match the updated address 
            user.SRU = sruNum; // updates the entity property to match the updated SRU
            user.DOB = dob; // updates the entity property to match the updated DOB 
            user.ContactNumber = contact; // updates the entity property to match the updated contact number choice 
            user.YearsOfService = YOS; // updates the entity property to match the updated years of service number
            user.BootSize = boot;// updates the entity property to match the updated boot size



        }

     



















    }
}
