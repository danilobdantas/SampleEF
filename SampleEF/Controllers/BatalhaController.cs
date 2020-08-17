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
        private readonly IEFCoreRepository _repo;

        public BatalhaController(IEFCoreRepository repo)
        {
            _repo = repo;
        }
        // GET: api/<BatalhaController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var herois = await _repo.GetBatalhas(true);
            return Ok(herois);
        }

        // GET api/<BatalhaController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var heroi = await _repo.GetBatalhaById(id);
            return Ok(heroi);
        }

        // GET api/<BatalhaController>/nome/thor
        [HttpGet("nome/{nome}")]
        public async Task<IActionResult> Get(string nome)
        {
            var heroi = await _repo.GetBatalhaByNome(nome);
            return Ok(heroi);
        }

        // POST api/<BatalhaController>
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

        // PUT api/<BatalhaController>/5
        [HttpPut("{id}")]
        public async Task <IActionResult> Put(int id, Batalha model)
        {
            try
            {
                var batalha = _repo.GetBatalhaById(id);
                if (batalha != null)
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

        // DELETE api/<BatalhaController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var heroi = await _repo.GetBatalhaById(id);
                if (heroi != null )
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
