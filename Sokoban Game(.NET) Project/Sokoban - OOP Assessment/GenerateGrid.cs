using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Sokoban___OOP_Assessment
{
    //Kian Gault
    // HND: Software Development 
    // ID: 20159222
    internal class GenerateGrid // This class is responsable for drawing the maps of the game foe each level. It also updates the images on the grid 
    {
       //instances of the classes this class will use. - visibility is set to protected so only child of the parent class can access the same objects
        protected Levels Window { get; set; }
        protected Walls WallClass = new Walls();
        protected Character CharClass = new Character();
        protected Crate CrateClass = new Crate();

        public GenerateGrid(Levels window, Character newChar, Crate newCrate) // constructor that takes the class instances and initliazes them
        {
            this.Window = window;
            CharClass = newChar;
            CrateClass = newCrate;
        }

        public GenerateGrid(Levels window, string nameType) // Overload constuctor that takes in a different name than the original constructor 
        {
            this.Window = window;
            nameType = "Sokoban!";
            
        }

        public void drawContents(string uriLocation, int row, int column) // Method that is responsable for drawing the contents on the screen by using an image 
        {
            Image img = new Image() { Source = new BitmapImage(new Uri(uriLocation, UriKind.Relative)) }; // Creates a new Image 
            Window.appGrid.Children.Add(img); // Adds it to the grid in the levels class 
            Grid.SetRow(img, row); //Sets the row for the image
            Grid.SetColumn(img, column); //Sets the column 
        }

        public void drawGrid1() //Method that is responsable for drawing the level one grid 
        {
            //Resets the move counter and sets the current level being played
            Window.Counter = 0;
            Window.counterBlock.Text = "Number of moves: " + Window.Counter;
            Window.CurrentLevel = 1;
            //Sets all the elements on the grid to the level one positions 
            CharClass.CharacterRow = 4;
            CharClass.CharacterColumn = 4;
            CrateClass.CrateRow = 1;
            CrateClass.CrateColumn = 8;
            Window.GoalRow = 8;
            Window.GoalColumn = 8;
            
            //Draws a fresh blank grid 
            for (int x = 0; x < 10; x++)
            {

                for (int y = 0; y < 10; y++)
                {

                    drawContents("Images\\blank.PNG", x, y);
                }

            }

            //Adds in the character, crate and goal images by calling their properties that stored the coordinates 
            drawContents("Images\\character.PNG", CharClass.CharacterRow, CharClass.CharacterColumn);
            drawContents("Images\\Crate.PNG", CrateClass.CrateRow, CrateClass.CrateColumn);
            drawContents("Images\\Goal.PNG", Window.GoalRow, Window.GoalColumn);

            //Adds in the walls which are stored in a 2D array
            for (int wall = 0; wall < WallClass.LevelOneWalls.GetLength(0); wall++) //Uses length of array for a loop
            {
                int wallRowPos = WallClass.LevelOneWalls[wall, 0]; //sets the row position 
                int wallColPos = WallClass.LevelOneWalls[wall, 1]; // Sets the column position 

                drawContents("Images\\Wall.PNG", wallRowPos, wallColPos); //Draws the wall

               
            }

            
            
        }

        public void drawGrid2() //Method Responsable for drawing the second level 
        {
            //Resets the move counter and sets the current level being played
            Window.Counter = 0;
            Window.counterBlock.Text = "Number of moves: " + Window.Counter;
            Window.CurrentLevel = 2;

            //Sets the elements of the grid with the level 2 coordinates 
            CharClass.CharacterRow = 4;
            CharClass.CharacterColumn = 4;
            CrateClass.CrateRow = 1;
            CrateClass.CrateColumn = 8;
            Window.GoalRow = 0;
            Window.GoalColumn = 0;

            //Draws a fresh grid 
            for (int x = 0; x < 10; x++) 
            {

                for (int y = 0; y < 10; y++)
                {

                    drawContents("Images\\blank.PNG", x, y);
                }

            }

            //Draws the character, crate and goal images by calling their properties that stored the coordinates 
            drawContents("Images\\character.PNG", CharClass.CharacterRow, CharClass.CharacterColumn);
            drawContents("Images\\Crate.PNG", CrateClass.CrateRow, CrateClass.CrateColumn);
            drawContents("Images\\Goal.PNG", Window.GoalRow, Window.GoalColumn);

            //Draws the level two walls by using the 2D array 
            for (int wall = 0; wall < WallClass.LevelTwoWalls.GetLength(0); wall++)
            {
                int wallRowPos = WallClass.LevelTwoWalls[wall, 0]; //Uses the first element as the row value
                int wallColPos = WallClass.LevelTwoWalls[wall, 1]; // Uses the second element as the column value

                drawContents("Images\\Wall.PNG", wallRowPos, wallColPos);
                
                
            }



        }

        public void drawGrid3() //Method Responsable for drawing the second level 
        {
            //Resets the move counter and sets the current level being played
            Window.Counter = 0;
            Window.counterBlock.Text = "Number of moves: " + Window.Counter;
            Window.CurrentLevel = 3;
            //Sets the elements of the grid with the level 2 coordinates 
            CharClass.CharacterRow = 2;
            CharClass.CharacterColumn = 3;
            CrateClass.CrateRow = 7;
            CrateClass.CrateColumn = 4;
            Window.GoalRow = 2;
            Window.GoalColumn = 2;

            //Draws a fresh grid 
            for (int x = 0; x < 10; x++)
            {

                for (int y = 0; y < 10; y++)
                {

                    drawContents("Images\\blank.PNG", x, y);
                }

            }

            //Draws the character, crate and goal images by calling their properties that stored the coordinates 
            drawContents("Images\\character.PNG", CharClass.CharacterRow, CharClass.CharacterColumn);
            drawContents("Images\\Crate.PNG", CrateClass.CrateRow, CrateClass.CrateColumn);
            drawContents("Images\\Goal.PNG", Window.GoalRow, Window.GoalColumn);

            //Draws the level two walls by using the 2D array 
            for (int wall = 0; wall < WallClass.LevelThreeWalls.GetLength(0); wall++)
            {
                int wallRowPos = WallClass.LevelThreeWalls[wall, 0]; //Uses the first element as the row value
                int wallColPos = WallClass.LevelThreeWalls[wall, 1]; // Uses the second element as the column value

                drawContents("Images\\Wall.PNG", wallRowPos, wallColPos); 

              
            }



        }
    }
}
