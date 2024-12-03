using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SimplyRugbySystem_KG___Version_1._0.Database_Classes
{
    class DataContext: DbContext
    {
        //This class is our data context class. It inherits from the DbContext class which is apart of the
        //Microsoft.EntityFrameworkCore library which is the connection line between this application and our database file. 
        //This class also provides the design for a database by having our different entities (tables) be declared here using 
        //DbSet which maps the database
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // method that runs when the application starts
        {
            // uses DbContextOptionsBuilder.UseSQLite method to tell the application to look for the file called ClubDatabase.db
            // within the source files of the application. This configures the DbContext opertions to this db file. 
            optionsBuilder.UseSqlite("Data Source = ClubDatabase.db"); 
                                                                        
        }

        //A string method used to validate data for the database before performing the database operation. 
        //This method is called by other classes. 
        public string ValidateData(string name, string address, string DOB)
        {
            if (name.Length == 0 || name.Length >= 50) // if the entered name is empty or over 50 characters return with a name error
            {
                return "Name Error";
            }
            else if (address.Length == 0 || address.Length >= 50) // if the address entry is empty or longer than 50 characters return with an address error
            {
                return "Email Length Error";
            }
            else if(DOB.Length == 0) // if there was no DOB selected return with a DOB error
            {

                return "Date Not Picked";
            }
            {
                return "Passed"; // if all statements are untrue then return with a pass 
            }
            
        }

        // Uses the DbSet class from DbContext to configure our entities for the database. It's parameter type is used to tell DbContext
        // where to find the schema for the table i.e. the fields. 
        // Here we create four tables for our application, one for each level of team. 
        public DbSet<JuniorSquad> Junior { get; set; } // Creates a new DbSet with the type being JuniorSquad Class
        public DbSet<Under18s> Under18s { get; set; } // Creates a new DbSet with the type being Under18s Class
        public DbSet<_18Plus> Above18 { get; set; } // Creates a new DbSet with the type being _18Plus Class 
        public DbSet<_21Plus> Senior { get; set; } // Creates a new DbSet with the type being _21Plus Class 

        //Here we declare four lists of the type class that matches the list description
        //This is used to update the listView XAML object with the database values
        public List<JuniorSquad>? JuniorUsers { get; set; } // Creates a new List of type class JuniorSquad
        public List<Under18s>? under18sUsers { get; set; } // Creates a new List of type class Under18s
        public List<_18Plus>? _18Users { get; set; } // Creates a new List of type class _18Plus
        public List<_21Plus>? _21Users { get; set; } // Creates a new list of type class _21Plus





    }
}
