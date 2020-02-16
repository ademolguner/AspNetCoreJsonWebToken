using TokenProject.Core.Entites.Concrete;
using TokenProject.Core.Utilities.Security.Jwt;
using TokenProject.Entites.Dtos;

namespace TokenProject.Business.Abstract
{
    public interface IAuthService
    {
        User Register(UserForRegisterDto userForRegisterDto, string password);
        User Login(UserForLoginDto userForLoginDto);
        bool UserExists(string email);
        AccessToken CreateAccessToken(User user);
    }
}
