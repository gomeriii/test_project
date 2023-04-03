using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SecondService.Application.Contracts.Persistence;
using SecondService.Domain.Entities;
using SecondService.Infrastructure.Persistence;

namespace SecondService.Infrastructure.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(SecondServiceContext dbContext) : base(dbContext)
        {
        }

        public async Task<IList<User>> GetByOrganizationAsync(int organizationId, int offset, int count)
        {
            var users = await _dbContext.Users.Where(x => x.OrganizationId == organizationId).Skip(offset).Take(count).ToListAsync();

            return users;
        }
    }
}
