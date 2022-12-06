namespace Common.Core.Entities
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public bool EmailConfirmed { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string ProfilePhoto { get; set; }
        public DateTime Birthday { get; set; }
        public bool IsBlocked { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
