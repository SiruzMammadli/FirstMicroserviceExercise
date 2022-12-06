namespace IdentityService.Entities.DTOs
{
    public class UserDto
    {
        public record GetUserByEmailDto(string emailaddress, string username, string firstname, string lastname, DateTime birthday);
        public record RegisterDto(string emailaddress, string username, string firstname, string lastname, DateTime birthday, string password);
        public record LoginDto(string emailaddress, string password);
    }
}
