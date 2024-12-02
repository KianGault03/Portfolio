using KwikMedical_Server.Models;
using Microsoft.EntityFrameworkCore;

namespace KwikMedical_Server.Data
{
    public class ApplicationDBContext : DbContext
    {
        // The constructor accepts DbContextOptions and passes it to the base DbContext constructor.
        public ApplicationDBContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {
            // This allows the context to be configured (e.g., with connection strings, database providers) from outside the class
        }
        // Represents tables in the database, These properties allow EF Core to query and save data for the corresponding tables.
        public DbSet<Patientcs>? Patients { get; set; }
        public DbSet<AmbulanceRecord> AmbulanceRecords { get; set; }

    }
}
