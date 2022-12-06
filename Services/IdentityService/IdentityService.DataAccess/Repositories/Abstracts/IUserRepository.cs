using Common.Core.Entities;
using Common.Core.Repositories.Interfaces;

namespace IdentityService.DataAccess.Repositories.Abstracts
{
    public interface IUserRepository : IWriteRepository<User>, IReadRepository<User>
    {
    }
}
