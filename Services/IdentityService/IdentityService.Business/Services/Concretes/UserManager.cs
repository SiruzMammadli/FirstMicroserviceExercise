using AutoMapper;
using Common.Core.Tools.ResultHelpers.Abstracts;
using Common.Core.Tools.ResultHelpers.Concretes.ErrorResults;
using Common.Core.Tools.ResultHelpers.Concretes.SuccessResults;
using IdentityService.Business.Extensions;
using IdentityService.Business.Services.Abstracts;
using IdentityService.DataAccess.Repositories.Abstracts;
using static IdentityService.Entities.DTOs.UserDto;

namespace IdentityService.Business.Services.Concretes
{
    public class UserManager : IUserService
    {
        private readonly IUserRepository _userRepo;
        private readonly IMapper _mapper;

        public UserManager(IUserRepository userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }

        public IDataResult<GetUserByEmailDto> GetUser(string email)
        {
            try
            {
                var user = _userRepo.GetSingle(i => i.EmailAddress.Equals(email));
                if (user.EmailAddress is not null)
                {
                    var model = _mapper.Map<GetUserByEmailDto>(user);
                    return new SuccessDataResult<GetUserByEmailDto>(model);
                }
                else
                {
                    return new ErrorDataResult<GetUserByEmailDto>(Messages.UserNotFound);
                }
            }
            catch (Exception e)
            {
                return new ErrorDataResult<GetUserByEmailDto>(e.Message);
            }
        }
    }
}
