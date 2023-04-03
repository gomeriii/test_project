using System.Collections.Generic;
using System.Threading.Tasks;
using SecondService.Domain.Entities;

namespace SecondService.Application.Contracts.Persistence
{
    public interface IUserRepository
    {
        Task<IList<User>> GetByOrganizationAsync(int organizationId, int offset, int count);
    }
}