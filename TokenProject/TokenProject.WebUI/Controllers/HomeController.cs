using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;
using TokenProject.WebUI.Models;

namespace TokenProject.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }


        public AccessToken TokenAl()
        {
            AccessToken token = new AccessToken();

            var client = new RestClient("https://localhost:44355/api");
            var request = new RestRequest("/auth/login", Method.POST);

            var reqBody = new UserForLoginDto()
            {
                Email = "ademolguner@outlook.com",
                Password = "1923"
            };
            var jsonToSend = JsonConvert.SerializeObject(reqBody);

            request.AddParameter("application/json; charset=utf-8", jsonToSend, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            try
            {
                // senkron olarak yazıldı bir alttaki metotta asenkron olarakta yazdım. duruma göre kullanabilirsin.
                var response = client.Execute(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    token = JsonConvert.DeserializeObject<AccessToken>(response.Content);

                }
                else
                {
                    token = new AccessToken();
                }
            }
            catch (Exception error)
            {

            }

            return token;
        }

        public void TokenYok()
        {
            var client = new RestClient("https://localhost:44355/api");
            var request = new RestRequest("/herhangibirapi/4", Method.GET);
            request.RequestFormat = DataFormat.Json;

            try
            {
                client.ExecuteAsync(request, response =>
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var resultData = response.Content;
                    }
                    else
                    {

                    }
                });
            }
            catch (Exception error)
            {

            }
        }
        public void TokenVarGecilmez()
        {
            //Header da token göndermediğimiz için else düşecek notauthorize cevabı dönecek
            var client = new RestClient("https://localhost:44355/api");
            var request = new RestRequest("/herhangibirapi/getlist", Method.GET);
            request.RequestFormat = DataFormat.Json;

            try
            {
                client.ExecuteAsync(request, response =>
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var resultData = response.Content;
                    }
                    else
                    {
                        var durum = response.StatusDescription;
                    }
                });
            }
            catch (Exception error)
            {

            }

        }

        public void TokenVarGec()
        {
            #region burada ilk once auth/login cagırıp token degeri alacağız
            var olusanToken = TokenAl();
            #endregion

            #region herhangibirapi apisini çağırıp AUTHORIZE işlemini gecmeyi deneyeceğiz
            var client = new RestClient("https://localhost:44355/api");
            var request = new RestRequest("/herhangibirapi/getlist", Method.GET);
            request.AddHeader("Authorization", "Bearer " + olusanToken.Token);
            request.RequestFormat = DataFormat.Json;

            try
            {
                // asenkron tipte bunuda kullanabilirsin
                client.ExecuteAsync(request, response =>
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var resultData = response.Content;
                    }
                    else
                    {
                        var durum = response.StatusDescription;
                    }
                });
            }
            catch (Exception error)
            {

            }
            #endregion
        }





        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
