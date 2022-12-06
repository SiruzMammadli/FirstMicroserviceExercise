using Common.Core.Tools.ResultHelpers.Abstracts;
using static IdentityService.Entities.DTOs.UserDto;

namespace IdentityService.Business.Services.Abstracts
{
    public interface IUserService
    {
        IDataResult<GetUserByEmailDto> GetUser(string email);
    }
}
