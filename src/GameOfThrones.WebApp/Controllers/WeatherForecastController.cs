using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace GameOfThrones.WebApp.Controllers
{
    //[Authorize]
    [RoutePrefix("api/weatherforecast")]
    public class WeatherForecastController: ApiController
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public WeatherForecastController()
        {

        }


        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(Summaries);
        }
    }
}