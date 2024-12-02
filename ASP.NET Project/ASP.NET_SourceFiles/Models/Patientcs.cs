namespace KwikMedical_Server.Models
{
    /// <summary>
    /// Model schema that provides the table structure for the patients table inside the KwikMedical database
    /// </summary>
    public class Patientcs
    {
        public int Id { get; set; } 
        public string Name { get; set; } = string.Empty; 
        public string CHIRegistrationNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string MedicalCondition { get; set; } = string.Empty;
    }
}
