using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SecondService.Domain.Entities;

namespace SecondService.Infrastructure.Persistence
{
    public class SecondServiceContextSeed
    {
        public static async Task SeedAsync(SecondServiceContext secondServiceContext, ILogger<SecondServiceContextSeed> logger)
        {            
            if (!secondServiceContext.Users.Any())
            {
                secondServiceContext.Users.AddRange(GetPreconfiguredUsers());
                secondServiceContext.Organizations.AddRange(GetPreconfiguredOrganizations());
                await secondServiceContext.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(SecondServiceContext).Name);
            }
        }

        private static IEnumerable<User> GetPreconfiguredUsers()
        {
            return new List<User>
            {
                new User(){Email = "test1@test.ru",Name = "TestName", Patronymic = "TestPatronymic", Surname = "TestSurname", PhoneNumber = "+79998887766"}
            };
        }

        private static IEnumerable<Organization> GetPreconfiguredOrganizations()
        {
            return new List<Organization>
            {
                new Organization(){Name = "TestOrganization"},
                new Organization(){Name = "TestOrganization2"},
                new Organization(){Name = "TestOrganization3"},
            };
        }
    }
}
