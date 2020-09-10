using IPAGEBiblioteca.Models;
using IPAGEBiblioteca.Repository.Helps;
using IPAGEBiblioteca.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IPAGEBiblioteca.Repository
{
    public class LivrosRepository: ILivrosModels
    {
        private readonly BiblioteContext biblioteContext;

        public LivrosRepository(BiblioteContext biblioteContext)
        {
            this.biblioteContext = biblioteContext;
        }
        public async Task<bool> Delete(LivrosModels Models)
        {
            biblioteContext.LivrosModels.Remove(Models);
            return await Salvar();
        }
        public IQueryable<LivrosModels> GetAll()
        {
            return biblioteContext.LivrosModels;
        }
        public async Task<LivrosModels> GetAll(Expression<Func<LivrosModels, bool>> predicate)
        {
            return await biblioteContext.LivrosModels.FirstOrDefaultAsync(predicate);
        }
        public async Task<bool> Insert(LivrosModels Models)
        {
            await this.biblioteContext.LivrosModels.AddAsync(Models);
            return await Salvar();
        }
        public async Task<bool> Update(LivrosModels Models)
        {
            this.biblioteContext.LivrosModels.Update(Models);
            return await Salvar();
        }
        private async Task<bool> Salvar()
        {
            return await this.biblioteContext.SaveChangesAsync() > 0 ? true : false;
        }
    }
}
