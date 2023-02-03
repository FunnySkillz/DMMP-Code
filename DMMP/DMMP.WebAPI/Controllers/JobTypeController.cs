using DMMP.Core.Contract;
using DMMP.Core.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DMMP.WebAPI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class JobTypeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<JobsController> _logger;

        public JobTypeController(IUnitOfWork unitOfWork, ILogger<JobsController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }


        // Get all Job Types
        [HttpGet("GetAllJobTypes")]
        public async Task<ActionResult<IEnumerable<JobType>>> GetAllJobTypes()
        {
            try
            {
                var jobTypes = await _unitOfWork.JobTypeRepository.GetAllJobTypes();
                if (!jobTypes.Any())
                {
                    return NotFound();
                }
                return Ok(jobTypes);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while retrieving all job types");
                return StatusCode(500, "An error occurred while retrieving all job types. Please try again later.");
            }
        }

        // Create Job Type
        [HttpPost]
        public async Task<ActionResult<JobType>> Create([FromBody] JobType jobType)
        {
            // data received is valid 
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _unitOfWork.JobTypeRepository.Insert(jobType);
                await _unitOfWork.SaveChangesAsync();

                return CreatedAtAction(("Get"), new { id = jobType.Id }, jobType);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while creating job type");
                return StatusCode(500, "An error occurred while creating the job type. Please try again later.");
            }
        }

        // read jobtype by id
        [HttpGet("{id}")]
        public async Task<ActionResult<JobType>> Get(int id)
        {
            var jobType = await _unitOfWork.JobTypeRepository.GetJobTypeById(id);

            if (jobType == null)
            {
                return NotFound();
            }

            return jobType;
        }

        // update Job Type 
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] JobType jobType)
        {
            if (id != jobType.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _unitOfWork.JobTypeRepository.Update(jobType);
                await _unitOfWork.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while updating jobType");
                return StatusCode(500, "An error occurred while updating the jobType. Please try again later.");
            }
        }

        // delete Job Type
        [HttpDelete("DeleteJobType/{id}")]
        public async Task<ActionResult> DeleteObject(int id)
        {
            try
            {
                var jobType = await _unitOfWork.JobTypeRepository.GetJobTypeById(id);

                if (jobType == null)
                {
                    return NotFound();
                }

                _unitOfWork.JobTypeRepository.Delete(jobType);
                await _unitOfWork.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while deleting Job Type");
                return StatusCode(500, "An error occurred while deleting the Job Type. Please try again later.");
            }
        }
    }
}
