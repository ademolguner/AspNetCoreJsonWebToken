using System.Collections.Generic;
using System.Linq;
using DataAccess.Concrete.EntityFramework.Contexts;
using TokenProject.Core.DataAccess.EntityFramework;
using TokenProject.Core.Entites.Concrete;
using TokenProject.DataAccess.Abstract;

namespace TokenProject.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, JwtTokenProjectDbContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using var context = new JwtTokenProjectDbContext();
            var result = from operationClaim in context.OperationClaims
                         join userOperationClaim in context.UserOperationClaims
                             on operationClaim.Id equals userOperationClaim.OperationClaimId
                         where userOperationClaim.UserId == user.Id
                         select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
            return result.ToList();
        }
    }
}
