using EFCore.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Repository
{
    public class EFCoreRepository : IEFCoreRepository
    {
        private readonly HeroiContext _context;

        public EFCoreRepository(HeroiContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Heroi[]> GetHerois(bool incluiBatalhas = false)
        {
            IQueryable<Heroi> query = _context.Herois
                .Include(h => h.IdentidadeSecreta)
                .Include(h => h.Armas);

            if (incluiBatalhas)
            {
                query = query.Include(h => h.HeroisBatalhas)
                    .ThenInclude(h => h.Batalha);
            }

            query = query.AsNoTracking().OrderBy(h => h.Id);

            return await query.ToArrayAsync();

        }

        public async Task<Heroi> GetHeroiById(int id, bool incluiBatalhas = false)
        {
            IQueryable<Heroi> query = _context.Herois
                .Include(h => h.Armas)
                .Include(h => h.IdentidadeSecreta);

            if (incluiBatalhas)
            {
                query = query.Include(h => h.HeroisBatalhas)
                    .ThenInclude(h => h.Batalha);
            }


            query = query.OrderBy(h => h.Id).AsNoTracking();

            return await query.FirstOrDefaultAsync(h => h.Id == id);
        }

        public async Task<Heroi[]> GetHeroiByNome(string nome, bool incluiBatalhas = false)
        {
            IQueryable<Heroi> query = _context.Herois
                .Include(h => h.Armas)
                .Include(h => h.IdentidadeSecreta);

            if (incluiBatalhas)
            {
                query = query.Include(h => h.HeroisBatalhas)
                    .ThenInclude(h => h.Batalha);
            }

            query = query.Where(h => h.Nome.Contains(nome))
                    .OrderBy(h => h.Nome).AsNoTracking();

            return await query.ToArrayAsync();
        }

        public async Task<Batalha[]> GetBatalhas(bool incluiHerois = false)
        {
            IQueryable<Batalha> query = _context.Batalhas;

            if (incluiHerois)
            {
                query = query.Include(b => b.HeroisBatalhas)
                    .ThenInclude(b => b.Heroi);
            }
            query = query.OrderBy(b => b.Id).AsNoTracking();

            return await query.ToArrayAsync();
        }

        public async Task<Batalha> GetBatalhaById(int id, bool incluiHerois = false)
        {
            IQueryable<Batalha> query = _context.Batalhas;

            if (incluiHerois)
            {
                query = query.Include(b => b.HeroisBatalhas)
                    .ThenInclude(b => b.Heroi);
            }

            query = query.OrderBy(b => b.Id).AsNoTracking();

            return await query.FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<Batalha[]> GetBatalhaByNome(string nome, bool incluiHerois = false)
        {
            IQueryable<Batalha> query = _context.Batalhas;

            if (incluiHerois)
            {
                query = query.Include(b => b.HeroisBatalhas)
                    .ThenInclude(b => b.Heroi);
            }

            query = query.Where(b => b.Nome.Contains(nome))
                            .OrderBy(b => b.Nome).AsNoTracking();

            return await query.ToArrayAsync();

        }
    }
}
