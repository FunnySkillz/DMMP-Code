using DMMP.Core.Contract;
using DMMP.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMMP.Persistence.Repository
{
    public class UserRepository : IUserRepository
    {
        ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(User user)
        {
            _dbContext.Users.Remove(user);
        }

        public async Task DeleteById(int id)
        {
            var toDelete = await _dbContext.Users.Where(u => u.Id == id).SingleOrDefaultAsync();
            Delete(toDelete);
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _dbContext.Users.OrderBy(u => u.Id).ToListAsync();
        }

        public async Task<int> GetCountAsync()
        {
            return await _dbContext.Users.CountAsync();
        }

        public async Task Insert(User newUser)
        {
            await _dbContext.Users.AddAsync(newUser);
        }

        public void Update(User newUser)
        {
            _dbContext.Users.Update(newUser);
        }
    }
}
