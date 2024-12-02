using Microsoft.EntityFrameworkCore.Infrastructure;
using SimplyRugbySystem_KG___Version_1._0.Database_Classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SimplyRugbySystem_KG___Version_1._0
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //App class which is the MAIN class that always runs first when the program is debugged.
        //Here we make use of the OnStartup method which launches everytime the applications starts. 
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ShutdownMode = ShutdownMode.OnLastWindowClose; // sets the application to fully shutdown (cut connection with the database) when the last window is closed. 

            //Here we make use of Microsoft.EntityFrameWork.Core.Infastructure to use the class DatabaseFacade's method called
            //EnsureCreated(). This method will look in the facade object and run the DataContext classes config method. 
            //EnsureCreated will check the config file path for the .db file and check to see if this file does in fact exist there. 
            //If this check is false it will create a new .db file with the same name in that place. This makes sure the database
            //is always there and there is no need to manually create a database file. 
            DatabaseFacade facade = new DatabaseFacade(new DataContext());
            facade.EnsureCreated(); 
        }

      
    }
}
