using Common.Core.Entities;
using Common.Core.Repositories.Concretes;
using IdentityService.DataAccess.Contexts;
using IdentityService.DataAccess.Repositories.Abstracts;

namespace IdentityService.DataAccess.Repositories.Concretes
{
    public class UserRepository : GenericRepository<User, IdentityServiceDbContext>, IUserRepository
    {
    }
}
