using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SimplyRugbySystem_KG___Version_1._0
{
    public class ClubMember
    {
        // a class that handles the login checks for the system.

        private Admin admin = new Admin(); // creates an instance of the admin object 
        private Coach coach = new Coach(); // creates an instance of the coach object 
        
        public bool doesLoginMatchAdminID(string userNameID, string password) // boolean method that takes in two strings 
        {
            return admin.loginChecker(userNameID, password); // checks to see if the entered login matches a stored admin login
        }

        public string doesLoginMatchCoachID(string usernameID, string password)
        {

            return coach.loginChecker(usernameID, password); // checks to see if the entered login matches one of the coach logins 

        }
        

    }
}
