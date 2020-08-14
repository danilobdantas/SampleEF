using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.Domain;
using EFCore.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SampleEF.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        public readonly HeroiContext _context;
        public WeatherForecastController(HeroiContext context)
        {
            _context = context;

        }
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching", "SupaHot"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        //public WeatherForecastController(ILogger<WeatherForecastController> logger)
        //{
        //    _logger = logger;
        //}

        // GET api/values/5
        [HttpGet("{nameHero}")]
        public ActionResult Get(string nameHero)
        {
            var heroi = new Heroi { Nome = nameHero };
            _context.Herois.Add(heroi);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public ActionResult Get()
        {
            var listHeroi = _context.Herois.ToList();
            return Ok(listHeroi);
        }
        
        [HttpGet("filtro/{nameHero}")]
        public ActionResult GetFiltro(string nameHero)
        {
            var listHeroi = _context.Herois.Where(h => h.Nome.Contains(nameHero)).ToList();
            return Ok(listHeroi);
        }

        [HttpGet("AddRange")]
        public ActionResult GetAddRange()
        {
            _context.AddRange(
                new Heroi { Nome = "Capitão América" },
                new Heroi { Nome = "Doutor Estranho" },
                new Heroi { Nome = "Pantera Negra" },
                new Heroi { Nome = "Viúva Negra" },
                new Heroi { Nome = "Hulk" },
                new Heroi { Nome = "Gavião Arqueiro" },
                new Heroi { Nome = "Capitã Marvel" }
                );

            _context.SaveChanges();

            return Ok();
        }

        [HttpGet("atualiza/{nome}")]
        public ActionResult Atualiza(string nome)
        {
            var heroi = _context.Herois.Where(h => h.Id == 3).FirstOrDefault();

            heroi.Nome = "Home Aranha";
            _context.SaveChanges();

            return Ok();
        }

        [HttpGet("exclui/{id}")]
        public ActionResult Exclui(int id)
        {
            var heroi = _context.Herois.Where(h => h.Id == id).Single();

            _context.Herois.Remove(heroi);
            _context.SaveChanges();

            return Ok();
        }
    }
}
