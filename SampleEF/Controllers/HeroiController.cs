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
        private readonly IEFCoreRepository _repo;

        public HeroiController(IEFCoreRepository repo)
        {
            _repo = repo;
        }
        // GET: api/<HeroiController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var herois = await _repo.GetHerois();
            return Ok(herois);
        }

        // GET api/<HeroiController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var heroi = await _repo.GetHeroiById(id);
            return Ok(heroi);
        }

        // GET api/<BatalhaController>/nome/thor
        [HttpGet("nome/{nome}")]
        public async Task<IActionResult> Get(string nome)
        {
            var heroi = await _repo.GetHeroiByNome(nome);
            return Ok(heroi);
        }

        // POST api/<HeroiController>
        [HttpPost]
        public async Task<IActionResult> Post(Batalha model)
        {
            try
            {
                _repo.Add(model);
                if (await _repo.SaveChangesAsync())
                {
                    return Ok("Show");
                }

            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }

            return BadRequest("Deu erro");
        }

        // PUT api/<HeroiController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Heroi model)
        {
            try
            {
                var heroi = _repo.GetHeroiById(id);
                if (heroi != null)
                {
                    _repo.Update(model);

                    if (await _repo.SaveChangesAsync())
                    {
                        return Ok("Coisa fina");
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }

            return BadRequest("Deu erro");
        }

        // DELETE api/<HeroiController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var heroi = await _repo.GetHeroiById(id);
                if (heroi != null)
                {
                    _repo.Delete(heroi);

                    if (await _repo.SaveChangesAsync())
                    {
                        return Ok("Rapazzzzzzzzzz");
                    }

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
