using DMMP.Core.Contract;
using DMMP.Core.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DMMP.WebAPI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class PropertyController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<JobsController> _logger;

        public PropertyController(IUnitOfWork unitOfWork, ILogger<JobsController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        // Get all Properties
        [HttpGet("GetAllProperties")]
        public async Task<ActionResult<IEnumerable<Property>>> GetAllProperties()
        {
            try
            {
                var properties = await _unitOfWork.PropertyRepository.GetAllProperties();
                if (!properties.Any())
                {
                    return NotFound();
                }
                return Ok(properties);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while retrieving all properties");
                return StatusCode(500, "An error occurred while retrieving all properties. Please try again later.");
            }
        }

        // Create Property
        [HttpPost]
        public async Task<ActionResult<Property>> Create([FromBody] Property property)
        {
            // data received is valid 
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _unitOfWork.PropertyRepository.Insert(property);
                await _unitOfWork.SaveChangesAsync();

                return CreatedAtAction(("Get"), new { id = property.Id }, property);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while creating property");
                return StatusCode(500, "An error occurred while creating the property. Please try again later.");
            }
        }

        // read property by id
        [HttpGet("{id}")]
        public async Task<ActionResult<Property>> Get(int id)
        {
            var job = await _unitOfWork.PropertyRepository.GetPropertyById(id);

            if (job == null)
            {
                return NotFound();
            }

            return job;
        }

        // update job 
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Property property)
        {
            if (id != property.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _unitOfWork.PropertyRepository.Update(property);
                await _unitOfWork.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while updating property");
                return StatusCode(500, "An error occurred while updating the property. Please try again later.");
            }
        }

        // delete job
        [HttpDelete("DeleteJob/{id}")]
        public async Task<ActionResult> DeleteObject(int id)
        {
            try
            {
                var property = await _unitOfWork.PropertyRepository.GetPropertyById(id);

                if (property == null)
                {
                    return NotFound();
                }

                _unitOfWork.PropertyRepository.Delete(property);
                await _unitOfWork.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while deleting property");
                return StatusCode(500, "An error occurred while deleting the property. Please try again later.");
            }
        }
    }
}
