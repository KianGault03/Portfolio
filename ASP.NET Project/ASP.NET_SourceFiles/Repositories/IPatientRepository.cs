using KwikMedical_Server.Models;

namespace KwikMedical_Server.Repositories
{
    /// <summary>
    /// Interface defines a contract for operations related to Patientcs. 
    /// It includes methods for CRUD (Create, Read, Update, Delete) operations, focusing on patients
    /// </summary>
    public interface IPatientRepository
    {
        Task<IEnumerable<Patientcs>> GetAllPatientsAsync();
        Task<Patientcs> GetPatientByIdAsync(int id);
        Task<Patientcs> GetPatientByChiNumberAsync(string chiNumber);
        Task AddPatientAsync(Patientcs patient);
        Task UpdatePatientAsync(Patientcs patient);
        Task DeletePatientAsync(int id);
    }
}
