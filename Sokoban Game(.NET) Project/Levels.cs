using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Input;

namespace Sokoban___OOP_Assessment
{
    //Kian Gault
    // HND: Software Development 
    // ID: 20159222
    internal class Levels : Window // This class is responsable for building the main window of the game. 
    { 
        //Set of encapsulated variables 
        private int goalRow; // integer to store the goal coordinate for the row
        private int goalColumn; // integer to store the goal coordinate for the column
        private int counter; // integer to store the move count
        private int levelCounter = 1; // integer to store the level number 
        private int currentLevel; // integer to store the level that is being currently played
      
        private Movement mover { get; set; } // Creates an instance of the class Movement 
        private Character charClass = new Character(); // Creates an instance of the class Character 
        private Crate crateClass = new Crate(); // Creates an instance of the class Crate 

        // Set of properties that allow other objects to access the private variables of this class
        public int GoalRow // property so the other objects can access the encapsulated variable 
        {
            get { return goalRow; }
            set { goalRow = value; }
        }

        public int GoalColumn // / property so the other objects can access the encapsulated variable
        {
            get { return goalColumn; }

            set { goalColumn = value; }
        }

        public int Counter // property so the other objects can access the encapsulated variable 
        {
            get { return counter; }
            set { counter = value; }
        }
        public int LevelCounter // property so the other objects can access the encapsulated variable 
        {
            get { return levelCounter; }
            set { levelCounter = value; }
        }
        public int CurrentLevel // property so the other objects can access the encapsulated variable 
        {
            get { return currentLevel; }
            set { currentLevel = value; }
        }

        //Window set - up 
        private Canvas windowCanvas { get; set; } // Creates the canvas 
        private Button returnButton { get; set; } // Creates the button for returnning 
        private Button restartLevel { get; set; } // Creates the button for restarting the current level 
        private Button nextLevel { get; set; } // Creates the botton for continuing to the next level
        private TextBlock instructionBlock { get; set; } // Creates a text block for instructions 
        public TextBlock counterBlock { get; set; } // Creates a text block to display the current move counter 
        public TextBlock levelBlock { get; set; } // public so the other class can update the windows xaml object
        private Border gridBorder { get; set; } // Creates the grid border 
        public Grid appGrid  { get; set; } // Creates the main Grid  - public so the class generate grid and it's child can update the grid when needed
        private GenerateGrid generateGrid { get; set; } // Creates an instance of the class GenerateGrid 
       

        public Levels(string windowName) // Constructor that gives the window a name and launches the window
        {
            this.Title = windowName;
            initializeWindow();
            

        }

        public void initializeWindow() // Method that is called when the window opens
        {
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen; // center screen start 
            windowCanvas = new Canvas(); // Creates a new Canvas 
            createGrid(); //Calls the method that creates the grid design 
            createSidePanel(); // Calls the method that handles everything but the grid 
            appGrid.Focus(); // Focuses the screen on the grid

            generateGrid = new GenerateGrid(this, charClass, crateClass); // Calls the GenerateGrid class to populate the grid once the window is launched 
            generateGrid.drawGrid1(); // Calls the method within GenerateGrid to draw the contents of the grid
            

            this.Content = this.windowCanvas; // draws the content on this window's canvas 

            mover = new Movement(this, charClass, crateClass); // Calls the movement class 
            setupPageEvents(); // calls the method responsable for making the buttons functional 

            charClass.CanMove = true; // Lets the player move at the start of the game

        }

        public void createGrid() // This method is responsable for creating the grid's main proprties i.e width x height and size in this case 10x10
        {
            gridBorder = new Border(); // Creates new border 
            gridBorder.BorderThickness = new Thickness(11.00); // Sets the border thickness 
            gridBorder.BorderBrush = Brushes.Black; // Sets the border color 

            appGrid = new Grid(); // Creates a new instance of a grid
            appGrid.Width = appGrid.Height = 400; // Sets the grid height 
            appGrid.HorizontalAlignment = HorizontalAlignment.Left; //Sets the position on the canvas 
            appGrid.VerticalAlignment = VerticalAlignment.Top; // Sets the position on the canvas 
            appGrid.Focusable = true; 
            gridBorder.Child = appGrid; // linkes the created border with the grid

            for (int i = 0; i < 10; i++) // Two for loops that create a 10x10 grid
            {
                appGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for (int i = 0; i < 10; i++)
            {
                appGrid.RowDefinitions.Add(new RowDefinition());
            }
        }

        public void arrangeOnCanvas() //This method is responsable for layoing out the other elememts of the window on the canvas 
        {
            windowCanvas.Children.Add(instructionBlock); // Adds a new textblock 
            windowCanvas.Children.Add(counterBlock); // Adds a new textblock
            windowCanvas.Children.Add(levelBlock); // Adds a new textblock
            windowCanvas.Children.Add(returnButton); // Adds a new button for returning to the home screen
            windowCanvas.Children.Add(restartLevel); // Adds a new button for restarting the current level 
            windowCanvas.Children.Add(nextLevel); // Adds a new button for continuing to the next level 
            windowCanvas.Children.Add(gridBorder); // Adds the grid border to the grid

            //A set of position commands for each of the created elements 
            //Sets the position of the instruction textblock with the user information within it
            Canvas.SetLeft(instructionBlock, 490);
            Canvas.SetTop(instructionBlock, 100);
            //Sets the position of the textblock that contains the move counter 
            Canvas.SetLeft(counterBlock, 850);
            Canvas.SetBottom(counterBlock, 50);
            //Sets the position of the textblock that contains the level block 
            Canvas.SetLeft(levelBlock, 50);
            Canvas.SetTop(levelBlock, 40);
            //Sets the position of the return to home button
            Canvas.SetLeft(returnButton, 900);
            Canvas.SetTop(returnButton, 40);
            //Sets the position of the restart level button 
            Canvas.SetLeft(restartLevel, 490);
            Canvas.SetTop(restartLevel, 440);
            //Sets the position of the next level button
            Canvas.SetLeft(nextLevel, 490);
            Canvas.SetTop(nextLevel, 415);
            //Sets the position of the grid border 
            Canvas.SetLeft(gridBorder, 50);
            Canvas.SetTop(gridBorder, 80);

            

        }

        public void createSidePanel() //This method creates the side portion of the window 
        {
            instructionBlock = new TextBlock(); // Creates the textblock with the main instructions inside
            instructionBlock.FontSize = 25;
            instructionBlock.Text = "Welcome. Your goal is to move the crate into the red dot. \nBe careful not to get stuck! Feel free to restart the current\n" +
                "level if you ever get stuck. \nOnce the goal has been reached press the continue \nbutton to move onto the next level ";
          

            counterBlock = new TextBlock(); // Creates the textblock that displays the stored counter value 
            counterBlock.FontSize = 25;
            counterBlock.Text += "Number of moves: " + Counter; // Displays the counter variable 

            levelBlock = new TextBlock(); // Creates a textblock that displays the current level 
            levelBlock.FontSize = 25;
            levelBlock.Text += "Level: " + levelCounter; // Displays the current level 

            returnButton = new Button(); // Return button that sends the user back to the home screen
            returnButton.Height = 30;
            returnButton.Width = 200;
            returnButton.FontSize = 15;
            returnButton.Focusable = false;
            returnButton.Content = "Return to home page";

            restartLevel = new Button(); // restart level button that restarts the current level 
            restartLevel.Height = 30;
            restartLevel.Width = 245;
            restartLevel.FontSize = 15;
            restartLevel.Focusable = false;
            restartLevel.Content = "Restart Level";

            nextLevel = new Button(); // Next level button that creates the next level on the condition that they have completed the previous level
            nextLevel.Height = 30;
            nextLevel.Width = 245;
            nextLevel.FontSize = 15;
            nextLevel.Focusable = false;
            nextLevel.Content = "Next Level";



            arrangeOnCanvas(); // calls the method to arrange all this information on the canvas 

        }

        public void returnButton_Click(object sender, RoutedEventArgs e) // Button that takes the user to the starting page
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

      

        public void appGrid_KeyDown(object sender, KeyEventArgs e) //Method that makes it so the arrow key presses are functional 
        {

            mover.MoveCharacter(e); // sends the key press to the movement class method MoveCharacter 


        }

        public void setupPageEvents() // Method that sets up all the buttons and makes them functional 
        {

            returnButton.Click += returnButton_Click; // Creates the return button method 
            restartLevel.Click += RestartLevel_Click; // Creates the restart level method 
            nextLevel.Click += NextLevel_Click; // Creates the next level method 
            appGrid.KeyDown += appGrid_KeyDown; // creates the keydown method 
        }

        public void NextLevel_Click(object sender, RoutedEventArgs e) // Button that decides what the next level is
        {
           

            //if statement that checks to see if the user has completed the previous level. if true the second grid will be drawn else a message will be displayed 
            if (LevelCounter == 2) // if the current level is now 2 draw the level 2 map
            {
               
                generateGrid.drawGrid2(); //calls the method that draws the level 2 map
                charClass.CanMove = true; // makes the man be able to move again since he was locked at the end of the previous level
                levelBlock.Text = "Level: " + levelCounter; // updates the level display


            }
            else if(LevelCounter ==3) // if the current is now 3 draw the level 3 map
            {
                
                generateGrid.drawGrid3(); //calls the method that draws the level 3 map
                charClass.CanMove = true; // makes the man be able to move again since he was locked at the end of the previous level
                levelBlock.Text = "Level: " + levelCounter; // updates the level display

            }
            else if(LevelCounter > 3) // if the counter has went past the max level of 3 open the victory screen
            {
                
                VictoryWindow window = new VictoryWindow();
                window.Show();
                this.Close();
            }
            else 
            {
                MessageBox.Show("Level not completed");
            }

        }

        public void RestartLevel_Click(object sender, RoutedEventArgs e) // Restarts the current grid occording to the current level
        {
            //This method uses a different behvaior than the continue method because the user might want to restart the level even if they do 
            // finish the level so it's important track the current level being played. The current level is only updated when the next level is drawn 
            // Compared to the level counter which is updated once the goal is met.

            if (CurrentLevel == 1) // if the current level being played is 1 then redraw the first level
            {
                generateGrid.drawGrid1();
                charClass.CanMove = true;
                LevelCounter = 1;
                Counter = 0;
                counterBlock.Text = "Number of moves: " + Counter.ToString();
            }
            else if(CurrentLevel == 2) // if the current level being played is 2 then redraw the second level
            {
                generateGrid.drawGrid2();
                charClass.CanMove = true;
                LevelCounter = 2;
                Counter = 0;
                counterBlock.Text = "Number of moves: " + Counter.ToString();
            }
            else if(CurrentLevel == 3) // if the current level being played is 3 then redraw the third level
            {
                generateGrid.drawGrid3();
                charClass.CanMove = true;
                LevelCounter = 3;
                Counter = 0;
                counterBlock.Text = "Number of moves: " + Counter.ToString();
            }


        }
    }
}
