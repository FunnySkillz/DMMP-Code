
using DMMP.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMMP.Core.Contract
{
    public interface IJobTypeRepository
    {
        Task<int> GetCountAsync();
        Task Insert(JobType newJobType);
        Task<List<JobType>> GetAllJobTypes();
        Task<JobType?> GetJobTypeById(int id);
        void Update(JobType newImoObject);
        void Delete(JobType newImoObject);

    }
}
