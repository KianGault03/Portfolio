using KwikMedical_Server.Models;
using KwikMedical_Server.Repositories;

namespace KwikMedical_Server.Services
{
    /// <summary>
    /// Service class for managing business logic related to patient data.
    /// </summary>
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _repository;

        /// <summary>
        /// Initializes the service with a patient repository.
        /// </summary>
        /// <param name="repository">The repository to perform data operations.</param>
        public PatientService(IPatientRepository repository)
        {
            _repository = repository; // Inject the patient repository.
        }

        // Fetches all patient records from the database.
        public async Task<IEnumerable<Patientcs>> GetPatientsAsync() =>
            await _repository.GetAllPatientsAsync(); // Retrieve all patients using the repository.

        // Fetches detailed information about a specific patient by ID.
        public async Task<Patientcs> GetPatientDetailsAsync(int id) =>
            await _repository.GetPatientByIdAsync(id); // Query the patient repository by ID.

        // Fetches a patient's information using their CHI Registration Number.
        public async Task<Patientcs> GetPatientByChiNumberAsync(string chiNumber) =>
            await _repository.GetPatientByChiNumberAsync(chiNumber); // Search patients by CHI number.

        // Adds a new patient to the database.
        public async Task AddPatientAsync(Patientcs patient)
        {
            // Add any business logic or validations here if required.
            await _repository.AddPatientAsync(patient); // Pass the new patient data to the repository.
        }
    }
}

