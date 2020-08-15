using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EFCore.Repository;
using EFCore.Domain;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SampleEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatalhaController : ControllerBase
    {
        public readonly HeroiContext _context;
        public BatalhaController(HeroiContext context)
        {
            _context = context;
        }
        // GET: api/<BatalhaController>
        [HttpGet]
        public  ActionResult Get()
        {
            return Ok(new Batalha());
        }

        // GET api/<BatalhaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BatalhaController>
        [HttpPost]
        public ActionResult Post(Batalha model)
        {
            try
            {
                _context.Batalhas.Add(model);
                _context.SaveChanges();
                return Ok("Show");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // PUT api/<BatalhaController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, Batalha model)
        {
            try
            {
                if (_context.Batalhas.AsNoTracking().FirstOrDefault(x => x.Id == id) != null)
                {
                    _context.Batalhas.Update(model);
                    _context.SaveChanges();
                    return Ok("Coisa fina");
                }

                return Ok("Não Localizado");

            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // DELETE api/<BatalhaController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id, Batalha model)
        {
            try
            {

                if (_context.Batalhas.AsNoTracking().FirstOrDefault(x => x.Id == id) != null)
                {
                    _context.Batalhas.Remove(model);
                    _context.SaveChanges();
                    return Ok("Rapazzzzzzzzzz");
                }

                return Ok("Não Localizado");

            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }
    }
}
