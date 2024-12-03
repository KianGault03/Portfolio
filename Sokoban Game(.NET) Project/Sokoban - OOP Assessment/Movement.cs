using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Diagnostics.Metrics;
using System.Windows;

namespace Sokoban___OOP_Assessment
{
    //Kian Gault
    // HND: Software Development 
    // ID: 20159222
    class Movement : GenerateGrid // inheritence with the generate grid class. This allows movememnt to inherit all behaviour of the gird
    {
        private int targetedCellRow, targetedCellColumn; // int that stores the targeted row and column of the character 
        private int targetedCrateRow, targetedCrateColumn; // int that stores the targeted row and column of the crate 

        public Movement(Levels window, Character newChar, Crate newCrate) : base(window, newChar, newCrate) // constuctor that links the levels class and the inherited generateGird class 
        {
            this.Window = window; // calls the base class instance 
            base.CharClass = newChar; // calls the base class instance 
            base.CrateClass = newCrate; // calls the base class instance 

        }

        public void MoveCharacter(KeyEventArgs e) //Method that records the arrow presses of the user. It then determins the direction and stores it 
        {

            switch (e.Key) // switch case to store the chosen direction 
            {
                case Key.Left:
                    move("Left"); // sends the word Left to the move method 
                    break;
                case Key.Up:
                    move("Up"); // sends the word up to the move method 
                    break;
                case Key.Right:
                    move("Right"); // sends the word right to the move method 
                    break;
                case Key.Down:
                    move("Down"); // sends the word down to the move method 
                    break;
                default:
                    break;

            }

        }
        public void move(string direction) // Method responsable for calculating the move of the user. it also receives the direction from the moveCharacter method 
        {

            int i = 0, j = 0; // sets the column and row direction to 0,0

            switch (direction) //Takes the result of the move character switch case to determin the direction 
            {
                case "Left":
                    i = 0; j = -1; //Sets the direction to left
                    break;
                case "Up":
                    i = -1; j = 0; //Sets the direction to up
                    break;
                case "Right":
                    i = 0; j = 1; // Sets the direction to right 
                    break;
                case "Down":
                    i = 1; j = 0; // Sets the direction to Down 
                    break;

            }


            //If statement that checks to make sure the location the character is moving is within the 5x5 grid
            if (((targetedCellRow = base.CharClass.CharacterRow + i) < 10) && ((targetedCellRow = base.CharClass.CharacterRow + i) >= 0) && ((targetedCellColumn = base.CharClass.CharacterColumn + j) < 10) && ((targetedCellColumn = base.CharClass.CharacterColumn + j) >= 0))
            {
                targetedCrateRow = base.CrateClass.CrateRow + i; // sets the tartged crate row pos 
                targetedCrateColumn = base.CrateClass.CrateColumn + j; //sets the targeted column pos

                bool wall = WallChecker(); //calls the method responsable for checking if the player is trying to walk into a wall with a true or false return 
                bool crate = CrateChecker(); // calls the method responsable for checking if the player has walked into a crate returning with a true or false 
                bool goal = GoalChecker(); // calls the method responsable for checking if the crate is in the targeted goal coordinates returning with a true or false
                
                
                if (wall == true) // if the player has walked into wall end the move 
                {
                    return;
                } 
                else if(crate == true && base.CharClass.CanMove == true) // if the player has moved into a crate proceed 
                {

                    bool wallAndCrate = WallAndCrateChecker(); // calls the method responsable for checking if a crate is going to collid with a wall 
                    if (wallAndCrate == true) // if true then stop the move 
                    {
                        return;
                    }
                    else // if not proceed
                    {
                        if (targetedCrateRow < 10 && targetedCrateRow >= 0 && targetedCrateColumn < 10 && targetedCrateColumn >=0) // checks to see if the targeted crate pos is 
                        {                                                                                                           // within the grid 
                            base.drawContents("Images\\Crate.PNG", targetedCrateRow, targetedCrateColumn); // calls the base class to draw the crate image
                            base.drawContents("Images\\Character.PNG", base.CrateClass.CrateRow, base.CrateClass.CrateColumn); // calls the base class to draw the character 
                            base.drawContents("Images\\Blank.PNG", base.CharClass.CharacterRow, base.CharClass.CharacterColumn); // calls the base class to draw a blank space where the character was


                            //Calls the methods reponsable for updating the positions and counter 
                            updateCharacterLocation();
                            updateCrateLocation();
                            updateCounter();
                           

                        }
                        else
                        {
                            return;
                        }
                    }

                }
                else if(base.CharClass.CanMove == true) // if the character has permission to move and there is no crate ahead then move forward 
                {
                    if (targetedCellRow == base.Window.GoalRow && targetedCellColumn == base.Window.GoalColumn) // Stops the man from moving over the end goal
                    {

                        return; //No move return to start 

                    }
                    else
                    {
                        base.drawContents("Images\\Character.PNG", targetedCellRow, targetedCellColumn); //Calls the base class method to draw the images for character 
                        base.drawContents("Images\\Blank.PNG", base.CharClass.CharacterRow, base.CharClass.CharacterColumn); //Calls the base class method to draw the images for blank spaces
                        updateCharacterLocation(); //Calls the method to update the character location 
                        updateCounter(); //Calls the method to update the move counter 
                    }


                }

                if (goal == true) // if the goal has been reached end the game and update the level counter 
                {
                    MessageBox.Show("Level completed!"); //Message displayed to the user 
                    updateLevelCounter(); //Calls the method to update the level counter 
                    base.CharClass.CanMove = false; // removes permission for the man to move after the level has finished 
                    return; // Ends the move 
                }

            }

        }

        //Counter Methods 
        public void updateLevelCounter() // Method that updates the level counter when called  
        {
            base.Window.LevelCounter++; //Increase the level counter by 1 
        }


        public string updateCounter() //Method that returns a string to the screen displaying the updated move counter 
        {
            base.Window.Counter++; // Increase the move counter by 1
            return base.Window.counterBlock.Text = "Number of moves: " + base.Window.Counter.ToString(); //Re-display the counter with the updated value
        }
        

        public void updateCharacterLocation() //Method that updates the stored character position 
        {
            base.CharClass.CharacterColumn = targetedCellColumn; //Calls the character class to update the character location with the new position 
            base.CharClass.CharacterRow = targetedCellRow; //Calls the character class to update the character location with the new position 
        }
       

        public void updateCrateLocation() // Method that updates the crate location 
        {
            base.CrateClass.CrateRow = targetedCrateRow; //Calls the crate class to update the crate location with the new position 
            base.CrateClass.CrateColumn = targetedCrateColumn; //Calls the crate class to update the crate location with the new position 

        }
        
        public bool GoalChecker() //method that returns a true or false if the crate is within the target coordinates 
        {
            if(targetedCrateRow == base.Window.GoalRow && targetedCrateColumn == base.Window.GoalColumn) // If the crate and goal coordinates match return true else return false
            {
                return true;
            }

          
            return false;
        }


        public bool WallChecker() //method that returns true or false if the character has moved trying to move into a stored wall position 
        {
            if (base.Window.LevelCounter == 1) //Run if the current level is 1 
            {
                for (int k = 0; k < base.WallClass.LevelOneWalls.GetLength(0); k++)
                {
                    if (targetedCellRow == base.WallClass.LevelOneWalls[k, 0] && targetedCellColumn == base.WallClass.LevelOneWalls[k, 1]) // if the targeted coordinates match the current 
                    {                                                                                                      // iteration of the wall return true 
                        return true;

                    }

                }
            }
            else if(base.Window.LevelCounter == 2) // Run if the current level is 2 
            {
                for (int k = 0; k < base.WallClass.LevelTwoWalls.GetLength(0); k++)
                {
                    if (targetedCellRow == base.WallClass.LevelTwoWalls[k, 0] && targetedCellColumn == base.WallClass.LevelTwoWalls[k, 1]) //if the targeted position equals the stored wall position 
                    {                                                                                                      // return true 
                        return true;

                    }

                }

            }
            else if(base.Window.LevelCounter == 3)
            {
                for (int k = 0; k < base.WallClass.LevelThreeWalls.GetLength(0); k++)
                {
                    if (targetedCellRow == base.WallClass.LevelThreeWalls[k, 0] && targetedCellColumn == base.WallClass.LevelThreeWalls[k, 1]) //if the targeted position equals the stored wall position 
                    {                                                                                                      // return true 
                        return true;

                    }

                }
            }
              return false; // else return false 
        }


        public bool CrateChecker() // method that checks if the character has moved into a crate position if true then return true else return false 
        {
            if (targetedCellRow == base.CrateClass.CrateRow && targetedCellColumn == base.CrateClass.CrateColumn) // if there is a crate in the targeted location return true
            {
                
                    return true;
        
            }

                return false;
        }
        

        public bool WallAndCrateChecker() // method that checks if the crate is trying to be pushed into a wall 
        {
            if (base.Window.LevelCounter == 1) // level 1 check 
            {
                for (int k = 0; k < base.WallClass.LevelOneWalls.GetLength(0); k++)
                {
                    if (targetedCrateRow == base.WallClass.LevelOneWalls[k, 0] && targetedCrateColumn == base.WallClass.LevelOneWalls[k, 1])
                    { // uses the for loop index to iterate through the array checking the first and second value stored in the 2D array
                        return true;
                    }

                }
            }
            else if(base.Window.LevelCounter == 2) // level 2 check 
            {
                for (int k = 0; k < base.WallClass.LevelTwoWalls.GetLength(0); k++)
                {
                    if (targetedCrateRow == base.WallClass.LevelTwoWalls[k, 0] && targetedCrateColumn == base.WallClass.LevelTwoWalls[k, 1])
                    { // uses the for loop index to iterate through the array checking the first and second value stored in the 2D array
                        return true;
                    }

                }
            }
            else if(base.Window.LevelCounter == 3)
            {
                for (int k = 0; k < base.WallClass.LevelThreeWalls.GetLength(0); k++)
                {
                    if (targetedCrateRow == base.WallClass.LevelThreeWalls[k, 0] && targetedCrateColumn == base.WallClass.LevelThreeWalls[k, 1])
                    { // uses the for loop index to iterate through the array checking the first and second value stored in the 2D array
                        return true;
                    }

                }
            }
            return false; 
        }

       
    }
}
