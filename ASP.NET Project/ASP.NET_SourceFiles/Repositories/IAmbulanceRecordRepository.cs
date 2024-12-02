using KwikMedical_Server.Models;

namespace KwikMedical_Server.Repositories
{
    /// <summary>
    /// interface is designed for operations related to ambulance records.
    /// </summary>
    public interface IAmbulanceRecordRepository
    {
        Task<IEnumerable<AmbulanceRecord>> GetAllRecordsAsync();
        Task<AmbulanceRecord> GetRecordByIdAsync(int id);
        Task AddRecordAsync(AmbulanceRecord record);
        Task SaveChangesAsync();
    }
}
