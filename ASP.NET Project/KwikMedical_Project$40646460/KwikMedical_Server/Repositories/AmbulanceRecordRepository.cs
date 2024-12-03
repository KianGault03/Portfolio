using KwikMedical_Server.Data;
using KwikMedical_Server.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KwikMedical_Server.Repositories
{
    /// <summary>
    /// Interface for Ambulance Record repository that defines the contract for data operations
    /// related to the AmbulanceRecord model.
    /// </summary>
    public class AmbulanceRecordRepository : IAmbulanceRecordRepository
    {
        private readonly ApplicationDBContext _context;

        public AmbulanceRecordRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        // Retrieves all ambulance records asynchronously.
        public async Task<IEnumerable<AmbulanceRecord>> GetAllRecordsAsync()
        {
            return await _context.AmbulanceRecords.ToListAsync();
        }

        // Retrieves an ambulance record by its unique ID.
        public async Task<AmbulanceRecord> GetRecordByIdAsync(int id)
        {
            return await _context.AmbulanceRecords.FindAsync(id);
        }

        // Adds a new ambulance record to the database.
        public async Task AddRecordAsync(AmbulanceRecord record)
        {
            await _context.AmbulanceRecords.AddAsync(record);
        }

        // Saves any pending changes to the database context.
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}




