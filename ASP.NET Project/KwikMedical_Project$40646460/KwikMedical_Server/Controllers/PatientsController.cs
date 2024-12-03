using KwikMedical_Server.Models;
using KwikMedical_Server.Services;
using Microsoft.AspNetCore.Mvc;

// An API controller with the base route api/Patients.
[ApiController]
[Route("api/[controller]")]
public class PatientsController : ControllerBase
{
    // Injects IPatientService, which encapsulates patient-related operations.
    private readonly IPatientService _service;
    public PatientsController(IPatientService service)
    {
        _service = service;
    }

    // GET method to fetch all patients
    [HttpGet]
    [Route("All")] 
    public async Task<IActionResult> GetAllPatients()
    {
        var patients = await _service.GetPatientsAsync();  // Fetch all patients
        return Ok(patients); // Return the list of all patients
    }

    // GET method to fetch a patient by chiNumber
    [HttpGet]
    public async Task<IActionResult> GetPatientByChiNumber([FromQuery] string chiNumber)
    {
        if (string.IsNullOrWhiteSpace(chiNumber))
        {
            return BadRequest("CHI number is required.");
        }

        var patient = await _service.GetPatientByChiNumberAsync(chiNumber);
        if (patient == null)
        {
            return NotFound("Patient not found.");
        }

        return Ok(patient); // Return the patient data
    }

    // POST method to create a new patient
    [HttpPost]
    public async Task<IActionResult> CreatePatient([FromBody] Patientcs patient)
    {
        await _service.AddPatientAsync(patient);
        return CreatedAtAction(nameof(GetPatientByChiNumber), new { chiNumber = patient.CHIRegistrationNumber }, patient);
    }
}

