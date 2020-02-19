using System.Collections.Generic;
using TokenProject.Core.Entities.Concrete;

namespace TokenProject.Business.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user);

        void Add(User user);

        User GetByMail(string email);
    }
}