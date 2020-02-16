using System;
using System.Collections.Generic;
using System.Text;
using TokenProject.Core.Entites.Concrete;

namespace TokenProject.Core.Utilities.Security.Jwt
{
   public interface ITokenHelper
    {

        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
