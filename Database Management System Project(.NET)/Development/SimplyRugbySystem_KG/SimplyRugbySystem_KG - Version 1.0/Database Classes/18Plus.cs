using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyRugbySystem_KG___Version_1._0.Database_Classes
{
    public class _18Plus
    {
        //This class is our _18Plus entity design. It is used by the DataContext class to design the 18 Plus squad table for the database
        //It does this by reading the different properties below and using them to store the fields of the tables
        //Whenever the user wishes to update or create a new record, it calls DataContext which then uses this class

        //Uses the componentModel.DataAnnotations library to set the next property below as the primary key of this class.
        //This value is automatically assigned to the property Id and auto increments with each assignment. 
        //This Id is used for many search operations throughout the application so it had to be unique.
        [Key]
        public int Id { get; set; }
        public int SRU { get; set; } // int Property to store the players SRU number
        public string? Name { get; set; } // string property to store the playes full name
        public string? Email { get; set; } // string property to store the players Email
        public string? DOB { get; set; } // string property to store the players DOB
        public int ContactNumber { get; set; } // int property to store the players contact number 
        public int YearsOfService { get; set; } // int property to store the players years of service at the club
        public int BootSize { get; set; } // int property to store the players size of boot

        //Set of properties used for the skill profiles
        public int PassingStandard { get; set; } // int property to store the players Passing: Standard score
        public int PassingSpin { get; set; } // int property to store the players Passing: Spin score
        public int PassingPop { get; set; } // int property to store the players Passing: Pop score

        public int TacklingFront { get; set; } // int property to store the players Tackling: Front score
        public int TacklingRear { get; set; } // int property to score the players Tackling: Rear score
        public int TacklingSide { get; set; } // int property to score the players Tackling: Side score
        public int TacklingScrabble { get; set; } // int property to score the players Tackling: Scrabble

        public int KickingDrop { get; set; } // int property to score the players Kicking: Drop
        public int KickingPunt { get; set; } // int property to score the players Kicking: Punt
        public int KickingGrubber { get; set; } // int property to score the players Kicking: Grubber 
        public int KickingGoal { get; set; } // int property to score the players Kicking: Goal



    }
}
