using DMMP.Core.Contract;
using DMMP.Core.Entity;
using DMMP.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMMP.Persistence.Repository
{
    public class JobTypeRepositry : IJobTypeRepository
    {
        ApplicationDbContext _dbContext;

        public JobTypeRepositry(ApplicationDbContext dbContect)
        {
            _dbContext = dbContect;
        }

        public void Delete(JobType jobTypeDelete)
        {
            _dbContext.JobTypes.Remove(jobTypeDelete);
        }

        public async Task<List<JobType>> GetAllJobTypes()
        {
            return await _dbContext.JobTypes.OrderBy(jt => jt.Id).ToListAsync();
        }
        public async Task<JobType?> GetJobTypeById(int id)
        {
            return await _dbContext.JobTypes.SingleOrDefaultAsync(jt => jt.Id == id);
        }

        public async Task<int> GetCountAsync()
        {
            return await _dbContext.JobTypes.CountAsync();
        }

        public void Insert(JobType newJobType)
        {
            _dbContext.JobTypes.AddAsync(newJobType);
        }

        public void Update(JobType newImoObject)
        {
            _dbContext.JobTypes.Update(newImoObject);
        }
    }
}
