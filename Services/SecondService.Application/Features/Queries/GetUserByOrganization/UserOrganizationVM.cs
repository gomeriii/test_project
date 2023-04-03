namespace SecondService.Application.Features.Queries.GetUserByOrganization
{
    public class UserOrganizationVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
