using System.Collections.Generic;
using System.Linq;
using TokenProject.Core.DataAccess.EntityFramework;
using TokenProject.Core.Entities.Concrete;
using TokenProject.DataAccess.Abstract;
using TokenProject.DataAccess.Concrete.EntityFramework.Context;

namespace TokenProject.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, JwtTokenProjectDbContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using var context = new JwtTokenProjectDbContext();
            var result = from operationClaim in context.OperationClaim
                         join userOperationClaim in context.UserOperationClaim
                             on operationClaim.Id equals userOperationClaim.OperationClaimId
                         where userOperationClaim.UserId == user.UserId
                         select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
            return result.ToList();
        }
    }
}