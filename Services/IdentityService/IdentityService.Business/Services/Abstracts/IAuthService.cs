using Common.Core.Entities;
using Common.Core.Tools.ResultHelpers.Abstracts;
using static IdentityService.Entities.DTOs.UserDto;

namespace IdentityService.Business.Services.Abstracts
{
    public interface IAuthService
    {
        IResult Register(RegisterDto request);
        IResult Login(LoginDto request);
        IDataResult<User> GetUser(string email);
    }
}
