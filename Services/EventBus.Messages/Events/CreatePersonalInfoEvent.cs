namespace EventBus.Messages.Events
{
    public class CreatePersonalInfoEvent : IntegrationBaseEvent
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}