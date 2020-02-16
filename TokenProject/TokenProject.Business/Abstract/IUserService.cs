using System.Collections.Generic;
using TokenProject.Core.Entites.Concrete;

namespace TokenProject.Business.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user);

        void Add(User user);

        User GetByMail(string email);
    }
}