


namespace Backend.DataAccess.Entities
{
    public sealed class Subscriber
    {
        public required int SubscriberId { get; set; }
        public required string UserId { get; set; }
        public required string Email { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required DateTimeOffset SignupDate { get; set; }
    }
}
