
using DMMP.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMMP.Core.Contract
{
    public interface IUserRepository
    {
        Task<int> GetCountAsync();

        Task Insert(User newUser);
        Task<List<User>> GetAllUsers();
        void Update(User newUser);
        void Delete(User user);
        Task DeleteById(int id);

    }
}
