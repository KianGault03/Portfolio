using KwikMedical_Server.Models;
using KwikMedical_Server.Services;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace KwikMedical_Server.Controllers
{
    /// <summary>
    /// Controller that allows access to the API's endpoints - for Ambulance records
    /// </summary>
    [Route("api/[controller]")] //Supply base route of the controller 
    [ApiController] // Enables automatic model validation and dependency injection for HTTP requests.
    public class AmbulanceRecordsController : ControllerBase // Base class for web API controllers without a view.
    {
        // Dependency Injection: Injects an implementation of IAmbulanceRecordService to handle ambulance record operations
        private readonly IAmbulanceRecordService _service;
        public AmbulanceRecordsController(IAmbulanceRecordService service)
        {
            _service = service;
        }

        // HTTP Method: Handles POST requests to create a new ambulance record.
        [HttpPost]
        public async Task<IActionResult> CreateRecord(AmbulanceRecord record)
        {
            // Ensures the PatientCHI field is provided. 
            if (string.IsNullOrWhiteSpace(record.PatientCHI))
                return BadRequest("Patient CHI number is required.");

            // Delegates record creation to the service layer.
            await _service.AddRecordAsync(record);
            // Returns a 201 Created response with the record's location (GetRecordById).
            return CreatedAtAction(nameof(GetRecordById), new { id = record.Id }, record);
        }

        // HTTP Method: Handles GET requests to retrieve an ambulance record by its ID.
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRecordById(int id)
        {
            // Retrieves the record from the service layer.
            var record = await _service.GetRecordByIdAsync(id);
            if (record == null) return NotFound();
            return Ok(record);
        }
    }
}

