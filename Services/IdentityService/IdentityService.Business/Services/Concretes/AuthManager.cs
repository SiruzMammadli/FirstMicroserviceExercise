using AutoMapper;
using Common.Core.Entities;
using Common.Core.Secure.Hashing;
using Common.Core.Secure.Jwt;
using Common.Core.Tools.ResultHelpers.Abstracts;
using Common.Core.Tools.ResultHelpers.Concretes.ErrorResults;
using Common.Core.Tools.ResultHelpers.Concretes.SuccessResults;
using IdentityService.Business.Extensions;
using IdentityService.Business.Services.Abstracts;
using IdentityService.DataAccess.Repositories.Abstracts;
using static IdentityService.Entities.DTOs.UserDto;

namespace IdentityService.Business.Services.Concretes
{
    public class AuthManager : IAuthService
    {
        private readonly IUserRepository _userRepo;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public AuthManager(IUserRepository userRepo, IMapper mapper, IUserService userService)
        {
            _userRepo = userRepo;
            _mapper = mapper;
            _userService = userService;
        }

        public IDataResult<User> GetUser(string email)
        {
            try
            {
                var user = _userRepo.GetSingle(i => i.EmailAddress.Equals(email));
                return new SuccessDataResult<User>(user);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }
        }

        public IResult Login(LoginDto request)
        {
            try
            {
                var foundUser = GetUser(request.emailaddress);
                if (!foundUser.Success) return new ErrorResult(Messages.LoginError);

                var checkPassword = HashGenerator.VerifyPasswordHash(request.password, foundUser.Data.PasswordHash, foundUser.Data.PasswordSalt);
                if (!checkPassword) return new ErrorResult(Messages.LoginError);

                string token = TokenGenerator.CreateToken(foundUser.Data, "user");

                return new SuccessResult(token);
            }
            catch (Exception e)
            {
                return new ErrorResult(e.Message);
            }
        }

        public IResult Register(RegisterDto request)
        {
            try
            {
                var existUser = _userService.GetUser(request.emailaddress);
                if (existUser.Success) return new ErrorResult(Messages.ExistUser);

                byte[] passwordHash, passwordSalt;

                var model = _mapper.Map<User>(request);

                HashGenerator.CreatePasswordHash(request.password, out passwordHash, out passwordSalt);
                model.PasswordHash = passwordHash;
                model.PasswordSalt = passwordSalt;
                model.ProfilePhoto = "/";
                _userRepo.AddAsync(model);
                return new SuccessResult(Messages.RegisterSuccessfully);
            }
            catch (Exception e)
            {
                return new ErrorResult(e.Message);
            }
        }
    }
}
