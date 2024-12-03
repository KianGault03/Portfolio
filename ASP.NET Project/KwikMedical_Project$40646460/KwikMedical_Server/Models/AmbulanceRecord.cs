namespace KwikMedical_Server.Models
{
    /// <summary>
    /// Model schema that provides the table structure for the ambulance record table inside the KwikMedical database
    /// </summary>
    public class AmbulanceRecord
    {
        public int Id { get; set; }
        public string PatientCHI { get; set; } = string.Empty; // Link to Patient via CHI number
        public string ResponseWho { get; set; } = string.Empty;
        public string ResponseWhat { get; set; } = string.Empty;
        public string ResponseWhen { get; set; } = string.Empty;
        public string ResponseWhere { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Auto-set timestamp


    }
}
