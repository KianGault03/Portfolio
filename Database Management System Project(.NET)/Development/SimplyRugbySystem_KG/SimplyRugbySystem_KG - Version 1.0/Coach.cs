
using SimplyRugbySystem_KG___Version_1._0.Database_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SimplyRugbySystem_KG___Version_1._0
{
    public class Coach
    {
        // This class handles all attributes and behaviors of the Coach users.
        // This class contains the different logins for each coach type and the methods to update the different skill profiles for each team

        private string juniorCoachID = "Junior"; // ID for Junior Coach 
        private string juniorCoachPassword = "JuniorTeam"; // Password for Junior Coach

        private string under18sCoach = "Under18s"; // ID for Under 18s Coach 
        private string under18sCoachPassword = "Under18sTeam"; // Password for Under 18s Coach

        private string coach18PlusID = "18Plus"; // ID for 18s+ Coach
        private string coach18PlusPassword = "18PlusTeam"; // Password for 18s+ Coach

        private string coach21PlusID = "21Plus"; // ID for 21s+ Coach
        private string coach21PlusPassword = "21PlusTeam"; // Password for 21+ Coach


        //Set of properties for all the logins
        public string JuniorCoachID { get { return juniorCoachID; } }
        public string JuniorCoachPassword { get { return juniorCoachPassword; } }

        public string Under18sCoach { get { return under18sCoach; } }
        public string Under18sCoachPassword { get { return under18sCoachPassword; } }

        public string Coach18PlusID { get { return coach18PlusID; } }
        public string Coach18PlusPassword { get { return coach18PlusPassword; } }

        public string Coach21PlusID { get { return coach21PlusID; } }
        public string Coach21PlusPassword { get { return coach21PlusPassword; } }


        //Coach operations that handles updating the skill fields for all the different teams 
        //These update methods follow the same pattern as updating player details by passing all the updated entries from the window and using the selected user
        //by ID then updating all the properties by that user type
        public void UpdateJuniorUser(JuniorSquad user, int userStandard, int userSpin, int userPop, int userFront, int userRear,
            int userSide, int userScrabble, int userDrop, int userPunt, int userGrubber, int userGoal)
        {
            //Uses the user of type Junior Squad to update the selected users properties with the passed in values 

            user.PassingStandard = userStandard;    //updates the Passing: Standard field to the updated rating
            user.PassingSpin = userSpin;            //updates the Passing: Spin field to the updated rating
            user.PassingPop = userPop;              //updates the Passing: Pop field to the updated rating 

            user.TacklingFront = userFront;         //updates the Tackling: Front field to the updated rating 
            user.TacklingRear = userRear;           //updates the Tackling: Rear field to the updated rating 
            user.TacklingSide = userSide;           //updates the Tackling: Side field to the updated rating 
            user.TacklingScrabble = userScrabble;   //updates the Tackling: Scrabble field to the updated rating 

            user.KickingDrop = userDrop;            //updates the Kicking: Drop field to the updated rating
            user.KickingPunt = userPunt;            //updates the Kicking: Punt field to the updated rating 
            user.KickingGrubber = userGrubber;      //updates the Kicking: Grubber field to the updated rating 
            user.KickingGoal = userGoal;            //updates the Kicking: Goal field to the updated rating

            
        }

        public void UpdateUnder18sUser(Under18s user, int userStandard, int userSpin, int userPop, int userFront, int userRear,
         int userSide, int userScrabble, int userDrop, int userPunt, int userGrubber, int userGoal)
        {
            //Uses the user of type Under18s to update the selected users properties with the passed in values 

            user.PassingStandard = userStandard;    //updates the Passing: Standard field to the updated rating
            user.PassingSpin = userSpin;            //updates the Passing: Spin field to the updated rating
            user.PassingPop = userPop;              //updates the Passing: Pop field to the updated rating 

            user.TacklingFront = userFront;         //updates the Tackling: Front field to the updated rating 
            user.TacklingRear = userRear;           //updates the Tackling: Rear field to the updated rating 
            user.TacklingSide = userSide;           //updates the Tackling: Side field to the updated rating 
            user.TacklingScrabble = userScrabble;   //updates the Tackling: Scrabble field to the updated rating 

            user.KickingDrop = userDrop;            //updates the Kicking: Drop field to the updated rating
            user.KickingPunt = userPunt;            //updates the Kicking: Punt field to the updated rating
            user.KickingGrubber = userGrubber;      //updates the Kicking: Grubber field to the updated rating 
            user.KickingGoal = userGoal;            //updates the Kicking: Goal field to the updated rating


        }

        public void Update18PlusUser(_18Plus user, int userStandard, int userSpin, int userPop, int userFront, int userRear,
         int userSide, int userScrabble, int userDrop, int userPunt, int userGrubber, int userGoal)
        {
            //Uses the user of type _18Plus to update the selected users properties with the passed in values 

            user.PassingStandard = userStandard;    //updates the Passing: Standard field to the updated rating
            user.PassingSpin = userSpin;            //updates the Passing: Spin field to the updated rating
            user.PassingPop = userPop;              //updates the Passing: Pop field to the updated rating 

            user.TacklingFront = userFront;         //updates the Tackling: Front field to the updated rating 
            user.TacklingRear = userRear;           //updates the Tackling: Rear field to the updated rating 
            user.TacklingSide = userSide;           //updates the Tackling: Side field to the updated rating
            user.TacklingScrabble = userScrabble;   //updates the Tackling: Scrabble field to the updated rating 

            user.KickingDrop = userDrop;            //updates the Kicking: Drop field to the updated rating
            user.KickingPunt = userPunt;            //updates the Kicking: Punt field to the updated rating
            user.KickingGrubber = userGrubber;      //updates the Kicking: Grubber field to the updated rating 
            user.KickingGoal = userGoal;            //updates the Kicking: Goal field to the updated rating


        }

        public void Update21PlusUser(_21Plus user, int userStandard, int userSpin, int userPop, int userFront, int userRear,
         int userSide, int userScrabble, int userDrop, int userPunt, int userGrubber, int userGoal)
        {
            //Uses the user of type _21Plus to update the selected users properties with the passed in values 

            user.PassingStandard = userStandard;    //updates the Passing: Standard field to the updated rating
            user.PassingSpin = userSpin;            //updates the Passing: Spin field to the updated rating
            user.PassingPop = userPop;              //updates the Passing: Pop field to the updated rating

            user.TacklingFront = userFront;         //updates the Tackling: Front field to the updated rating 
            user.TacklingRear = userRear;           //updates the Tackling: Rear field to the updated rating
            user.TacklingSide = userSide;           //updates the Tackling: Side field to the updated rating
            user.TacklingScrabble = userScrabble;   //updates the Tackling: Scrabble field to the updated rating 

            user.KickingDrop = userDrop;            //updates the Kicking: Drop field to the updated rating
            user.KickingPunt = userPunt;            //updates the Kicking: Punt field to the updated rating
            user.KickingGrubber = userGrubber;      //updates the Kicking: Grubber field to the updated rating 
            user.KickingGoal = userGoal;            //updates the Kicking: Goal field to the updated rating


        }

        //Method that takes in two strings to check if the entered ID and Password matches a stored admin user
        public string loginChecker(string username, string password)
        {
            string enteredUsername = username;
            string enteredPassword = password;
            if (JuniorCoachID == enteredUsername && JuniorCoachPassword == enteredPassword)
            {
                return "Junior";
            }
            else if (Under18sCoach == enteredUsername && Under18sCoachPassword == enteredPassword)
            {
                return "Under18s";
            }
            else if (Coach18PlusID == enteredUsername && Coach18PlusPassword == enteredPassword)
            {
                return "18+";
            }
            else if (Coach21PlusID == enteredUsername && Coach21PlusPassword == enteredPassword)
            {
                return "21+";
            }
            else
            {
                return "Error";
            }
        }
        
        

        
       




    }
}
