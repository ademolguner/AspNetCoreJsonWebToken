using System.Collections.Generic;
using TokenProject.Core.Entities.Concrete;

namespace TokenProject.Core.Utilities.Security.Jwt
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}