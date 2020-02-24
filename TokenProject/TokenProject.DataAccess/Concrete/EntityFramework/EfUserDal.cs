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
            var result = from     uoc in context.UserOperationClaim
                         join oc in context.OperationClaim
                             on uoc.Id equals oc.Id
                         where uoc.UserId == user.UserId
                         select new OperationClaim { Id = oc.Id, Name = oc.Name };
            return result.ToList();
        }
    }
}