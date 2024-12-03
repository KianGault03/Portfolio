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
    public class Crate // Class that stores any variables that get used or updated for the crate
    {
        private int crateRow; // integer that stores the crate row
        private int crateColumn; // integer that stores the crate column

        //Properties so other classes can interact with the crate class 
        public int CrateColumn
        {
            get { return crateColumn; } // returns the private variable 
            set { crateColumn = value; } // sets the value to the private variable 
        }
        public int CrateRow
        {
            get { return crateRow; } // returns the private variable 
            set { crateRow = value; } // sets the value to the private variable 
        }

        
    }
}
