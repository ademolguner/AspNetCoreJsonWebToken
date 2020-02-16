using TokenProject.Core.Entites;

namespace TokenProject.Entites.Dtos
{
    public class UserForLoginDto : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
