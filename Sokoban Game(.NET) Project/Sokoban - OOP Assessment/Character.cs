using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban___OOP_Assessment
{
    //Kian Gault
    // HND: Software Development 
    // ID: 20159222
    public class Character // Class that stores any variables that get used or updated for the character 
    {
        private int characterRow; // integer that stores the current character row 
        private int characterColumn; // integer that stores the current character column
        private bool canMove; // boolean that checks to see if the character has permission to move

        //Properties so other classes can interact with the character class 
        public int CharacterColumn
        {
            get { return characterColumn; } // returns the private variable 
            set { characterColumn = value; } // sets the value to the private variables 
        } 

        public int CharacterRow
        {
            get { return characterRow; } // returns the private variable 
            set { characterRow = value; } // sets the value to the private variables 
        }

        public bool CanMove
        {
            get { return canMove; } // returns the private variable 
            set { canMove = value; } // sets the value to the private variables 
        }
    }
}
