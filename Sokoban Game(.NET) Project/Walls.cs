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
    public class Walls //Class that stores the values for any walls that get used or updated
    {
        private int[,] levelOneWalls = //wall coordinates for level one 
        { {0,1 }, {0,2}, {1, 1}, {2,1}, {3,1}, {4,1},
          {5,1}, {5,2}, {0,3}, {0,4}, {0,5}, {0,6 },
          {1,6}, {2,6}, {3,6}, {5,6}, {6,6}, {7,6},
          {9,6}, {6,7}, {6,8}
        };
        public int[,] LevelOneWalls //Property 
        {
            get { return levelOneWalls; }
            set { levelOneWalls = value; }
        }
        private int[,] levelTwoWalls = // wall coordinates for level two 
        {
            {1,1}, {5,2}, {2,1} , {4,1} ,{5,1}, {6,3},
            {6,2 }, {7,3}, {9,3}, {0,1}, {7,4}, {7,5},
            {9,4 }, {9,5}, {9,6}, {9,7}, {8,7}, {7,7}
        };
        public int[,] LevelTwoWalls // Property 
        {
            get { return levelTwoWalls; }
            set { levelTwoWalls = value; }
        }
        private int[,] levelThreeWalls = // wall coordinates for level three 
        {
            {1,1}, {1,2}, {1,3}, {1,4}, {1,5},
            {1,6}, {1,7}, {1,8}, {3,8}, {3,7},
            {9,1}, {9,2}, {9,3}, {9,4}, {9,5},
            {9,6}, {9,7}, {9,8}, {2,1}, {3,1},
            {6,1}, {8,1}, {3,2}, {3,3}, {3,4},
            {3,5}, {8,8}, {7,8}, {5,8}, {5,7},
            {5,5}, {5,3}, {5,2}, {6,8}, {5,1}
        };
        public int[,] LevelThreeWalls // property 
        {
            get { return levelThreeWalls; }
            set { levelThreeWalls = value; }
        }

        private int[] wallLevelCounter; // 1D basic array that COULD be used to track the current wall set that is being used.
                                        // This would be useful if future implementations had a large set of different wall arrays
        public int[] WallLevelCounter // Property 
        {
            get { return wallLevelCounter; }
            set { wallLevelCounter = value; }
        }
    }
}
