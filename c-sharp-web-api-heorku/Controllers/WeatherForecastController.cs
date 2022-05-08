using AutoMapper;
using c_sharp_web_api_heorku.Context;
using c_sharp_web_api_heorku.DTOs;
using c_sharp_web_api_heorku.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace c_sharp_web_api_heorku.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private DataContext db = new DataContext();
        private readonly IMapper _mapper;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet]
        [Route("empresas")]
        [ProducesResponseType(typeof(Empresas), StatusCodes.Status200OK)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> GetEmpresas()
        {
            try
            {
                IReadOnlyList<Empresas> emp = this.db.Empresas.ToList();

                IReadOnlyList<EmpresasDto> empDto = _mapper.Map<IReadOnlyList<EmpresasDto>>(emp);

                return Ok(empDto);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }

        }
    }
}
