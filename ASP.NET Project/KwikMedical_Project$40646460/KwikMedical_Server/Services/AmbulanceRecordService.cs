using KwikMedical_Server.Models;
using KwikMedical_Server.Repositories;

namespace KwikMedical_Server.Services
{
    /// <summary>
    /// Service class for managing business logic related to ambulance records.
    /// </summary>
    public class AmbulanceRecordService : IAmbulanceRecordService
    {
        private readonly IAmbulanceRecordRepository _repository;

        /// <summary>
        /// Initializes the service with an ambulance record repository.
        /// </summary>
        /// <param name="repository">The repository to perform data operations.</param>
        public AmbulanceRecordService(IAmbulanceRecordRepository repository)
        {
            _repository = repository; // Inject the ambulance record repository.
        }

        // Fetches all ambulance records from the database.
        public async Task<IEnumerable<AmbulanceRecord>> GetAllRecordsAsync()
        {
            return await _repository.GetAllRecordsAsync(); // Retrieve all ambulance records.
        }

        // Fetches a specific ambulance record using its unique ID.
        public async Task<AmbulanceRecord> GetRecordByIdAsync(int id)
        {
            return await _repository.GetRecordByIdAsync(id); // Query the repository for a specific record by ID.
        }

        // Adds a new ambulance record to the database.
        public async Task AddRecordAsync(AmbulanceRecord record)
        {
            // Add any business logic or validations if necessary.
            await _repository.AddRecordAsync(record); // Pass the new record to the repository.
            await _repository.SaveChangesAsync(); // Save the changes to the database.
        }
    }
}

