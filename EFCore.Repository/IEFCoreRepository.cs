using EFCore.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Repository
{
    public interface IEFCoreRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();
        Task<Heroi[]> GetHerois(bool incluiBatalhas = false);
        Task<Heroi> GetHeroiById(int id, bool incluiBatalhas = false);
        Task<Heroi[]> GetHeroiByNome(string nome, bool incluiBatalhas = false);
        Task<Batalha[]> GetBatalhas(bool incluiHerois = false);
        Task<Batalha> GetBatalhaById(int id, bool incluiHerois = false);
        Task<Batalha[]> GetBatalhaByNome(string nome, bool incluiHerois = false);

    }
}
