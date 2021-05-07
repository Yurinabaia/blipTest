using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebApiHeroku.Core.Entites;

namespace HerokuDockerDeployment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        static async Task<List<Root>> listaGIT()
        {
            try
            {

                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Add("User-Agent", "Usando Agente GITHUB");
                httpClient.BaseAddress = new Uri("https://api.github.com");
                var gitHubApi = RestService.For<Igit>(httpClient);
                var test = await gitHubApi.GetUser("takenet");
                var x = test.ToList().OrderBy(o => o.created_at).ToList();

                return x;
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
            }
            return null;
        }
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{nomeRepo}")]
        public async Task<List<Root>> GetAsync(string nomeRepo)
        {

            try
            {

                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Add("User-Agent", "Usando Agente GITHUB");
                httpClient.BaseAddress = new Uri("https://api.github.com");
                var gitHubApi = RestService.For<Igit>(httpClient);
                var test = await gitHubApi.GetUser(nomeRepo);
                var x = test.ToList().OrderBy(o => o.created_at).ToList();

                return x;
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
            };
            return null;
        }
    }
}
