using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Sokoban___OOP_Assessment
{
    /// <summary>
    /// Interaction logic for VictoryWindow.xaml
    /// </summary>

    //Kian Gault
    // HND: Software Development 
    // ID: 20159222

    public partial class VictoryWindow : Window
    {
        
        public VictoryWindow()
        {
           
            InitializeComponent(); // creates the victory window
           
        }

      
        private void btn_ReturnToHome_Click(object sender, RoutedEventArgs e)
        { // button that takes the user back to the starting home page
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
            
        }

        private void btn_RestartGame_Click(object sender, RoutedEventArgs e)
        { // button that takes the user back to the game and sets them to level one
            Levels level = new Levels("First Level");
            level.LevelCounter = 1;
            level.Show();
            this.Close();

        }
    }
}
