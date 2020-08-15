using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.Domain;
using EFCore.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SampleEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroiController : ControllerBase
    {
        public readonly HeroiContext _context;
        public HeroiController(HeroiContext context)
        {
            _context = context;
        }
        // GET: api/<HeroiController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(new Heroi());
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // GET api/<HeroiController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<HeroiController>
        [HttpPost]
        public ActionResult Post(Heroi model)
        {
            try
            {
                _context.Herois.Add(model);
                _context.SaveChanges();

                return Ok("Delicia");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // PUT api/<HeroiController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, Heroi model)
        {
            try
            {
                if (_context.Herois.AsNoTracking().FirstOrDefault(x => x.Id == id) != null)
                {
                    _context.Herois.Update(model);
                    _context.SaveChanges();
                    return Ok("safado");
                }

                return Ok("Não encontrado");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // DELETE api/<HeroiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
