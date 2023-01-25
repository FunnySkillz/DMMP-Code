using DMMP.Core.Contract;
using DMMP.Core.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DMMP.WebAPI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class JobsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<JobsController> _logger;

        public JobsController(IUnitOfWork unitOfWork, ILogger<JobsController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        // Get all Jobs
        [HttpGet("GetAllJobs")]
        public async Task<ActionResult<IEnumerable<Job>>> GetAllJobs()
        {
            try
            {
                var jobs = await _unitOfWork.JobRepository.GetAllJobs();
                if (!jobs.Any())
                {
                    return NotFound();
                }
                return Ok(jobs);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while retrieving all jobs");
                return StatusCode(500, "An error occurred while retrieving all jobs. Please try again later.");
            }
        }

        // Create Job
        [HttpPost]
        public async Task<ActionResult<Job>> Create([FromBody] Job job)
        {
            // data received is valid 
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _unitOfWork.JobRepository.Insert(job);
                await _unitOfWork.SaveChangesAsync();

                return CreatedAtAction(("Get"), new { id = job.Id }, job);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while creating job");
                return StatusCode(500, "An error occurred while creating the job. Please try again later.");
            }
        }

        // read job by id
        [HttpGet("{id}")]
        public async Task<ActionResult<Job>> Get(int id)
        {
            var job = await _unitOfWork.JobRepository.GetById(id);

            if (job == null)
            {
                return NotFound();
            }

            return job;
        }

        // update job 
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Job job)
        {
            if (id != job.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _unitOfWork.JobRepository.Update(job);
                await _unitOfWork.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while updating job");
                return StatusCode(500, "An error occurred while updating the job. Please try again later.");
            }
        }

        // delete job
        [HttpDelete("DeleteJob/{id}")]
        public async Task<ActionResult> DeleteObject(int id)
        {
            try
            {
                var job = await _unitOfWork.JobRepository.GetById(id);

                if (job == null)
                {
                    return NotFound();
                }

                _unitOfWork.JobRepository.Delete(job);
                await _unitOfWork.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while deleting job");
                return StatusCode(500, "An error occurred while deleting the job. Please try again later.");
            }
        }

    }
}
