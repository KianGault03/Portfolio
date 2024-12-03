using KwikMedical_Server.Models;

namespace KwikMedical_Server.Services
{
    /// <summary>
    /// Interface defining operations for managing ambulance records.
    /// </summary>
    public interface IAmbulanceRecordService
    {
        // Fetches all ambulance records from the database.
        Task<IEnumerable<AmbulanceRecord>> GetAllRecordsAsync();

        // Gets a specific ambulance record by its unique ID.
        Task<AmbulanceRecord> GetRecordByIdAsync(int id);

        // Adds a new ambulance record to the database.
        Task AddRecordAsync(AmbulanceRecord record);
    }
}

