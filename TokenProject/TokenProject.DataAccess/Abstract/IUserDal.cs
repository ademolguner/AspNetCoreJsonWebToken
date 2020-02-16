using System.Collections.Generic;
using TokenProject.Core.DataAccess;
using TokenProject.Core.Entites.Concrete;

namespace TokenProject.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
    }
}
