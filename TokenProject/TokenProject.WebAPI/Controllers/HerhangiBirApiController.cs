using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TokenProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HerhangiBirApiController : ControllerBase
    {
        /// <summary>
        /// Bu metodu çağırabilmek için  Authorize işlemi gerekmektedir.
        /// </summary>
        /// <returns></returns>
        [HttpGet( "GetList")]
        [Authorize]
        public IEnumerable<string> Get()
        {
            return new string[] { "Adem", "Olguner", ".Net Core 3.0", "Json Web Token", "Swagger", "-Authorize", "İşlemleri" };
        }

        
        /// <summary>
        /// Bu metot için Authrorize zorunlu değil.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "Authorize etiketi yok, Token kontrolü zorunlu değil.";
        } 
         
    }
}