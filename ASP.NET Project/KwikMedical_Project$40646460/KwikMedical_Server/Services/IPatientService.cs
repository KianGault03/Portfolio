using KwikMedical_Server.Models;

namespace KwikMedical_Server.Services
{
    /// <summary>
    /// Interface defining operations for managing patient data.
    /// </summary>
    public interface IPatientService
    {
        // Retrieves all patients from the database.
        Task<IEnumerable<Patientcs>> GetPatientsAsync();

        // Gets detailed information about a specific patient by ID.
        Task<Patientcs> GetPatientDetailsAsync(int id);

        // Fetches a patient's data using their CHI Registration Number. 
        Task<Patientcs> GetPatientByChiNumberAsync(string chiNumber);

        // Adds a new patient record to the database.
        Task AddPatientAsync(Patientcs patient);
    }
}

