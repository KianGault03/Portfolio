using KwikMedical_Server.Data;
using KwikMedical_Server.Models;
using Microsoft.EntityFrameworkCore;

namespace KwikMedical_Server.Repositories
{
    /// <summary>
    /// Repository for performing CRUD operations on patient data.
    /// </summary>
    public class PatientRepository : IPatientRepository
    {
        private readonly ApplicationDBContext _context;

        /// <summary>
        /// Initializes the repository with the database context.
        /// </summary>
        public PatientRepository(ApplicationDBContext context)
        {
            _context = context; // Inject the application's database context.
        }

        // Fetches all patient records from the database.
        public async Task<IEnumerable<Patientcs>> GetAllPatientsAsync() =>
            await _context.Patients.ToListAsync(); // Query all patients from the database.

        // Fetches a patient by their unique ID.
        public async Task<Patientcs> GetPatientByIdAsync(int id) =>
            await _context.Patients.FindAsync(id); // Search for a patient using their primary key.

        // Fetches a patient by their CHI Registration Number.
        public async Task<Patientcs> GetPatientByChiNumberAsync(string chiNumber) =>
            await _context.Patients.FirstOrDefaultAsync(p => p.CHIRegistrationNumber == chiNumber); // Filter patients by CHI number.

        // Adds a new patient to the database.
        public async Task AddPatientAsync(Patientcs patient)
        {
            _context.Patients.Add(patient); // Mark the new patient for addition to the database.
            await _context.SaveChangesAsync(); // Save the changes to the database.
        }

        // Updates an existing patient's information.
        public async Task UpdatePatientAsync(Patientcs patient)
        {
            _context.Patients.Update(patient); // Mark the patient's record for update.
            await _context.SaveChangesAsync(); // Commit the updates to the database.
        }

        // Deletes a patient by their unique ID.
        public async Task DeletePatientAsync(int id)
        {
            var patient = await GetPatientByIdAsync(id); // Find the patient by ID.
            if (patient != null)
            {
                _context.Patients.Remove(patient); // Mark the patient for deletion.
                await _context.SaveChangesAsync(); // Save the deletion changes to the database.
            }
        }
    }
}


