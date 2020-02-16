using System;
using TokenProject.Business.Abstract;
using TokenProject.Core.Entites.Concrete;
using TokenProject.Core.Utilities.Security.Hashing;
using TokenProject.Core.Utilities.Security.Jwt;
using TokenProject.Entites.Dtos;

namespace TokenProject.Business.Concrete.Managers
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public  User Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Add(user);
            return user;
        }

        public  User Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                  throw  new Exception("hata metni");
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                    throw new Exception("hata metni"); ;
            }

            return  userToCheck;
        }

        public bool UserExists(string email)
        {
            if (_userService.GetByMail(email) != null)
            {
                return false;
            }
            return true;
        }

        public AccessToken CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return  accessToken;
        }

         
    }
}
