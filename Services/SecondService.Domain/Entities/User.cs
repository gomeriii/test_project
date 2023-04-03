using System.ComponentModel.DataAnnotations.Schema;

namespace SecondService.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }

        [ForeignKey(nameof(Organization))]
        public int? OrganizationId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Patronymic { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public virtual Organization Organization { get; set; }
    }
}
