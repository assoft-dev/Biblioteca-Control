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
    public class InstituicaoRepository: IInstituicaoModels
    {
        private readonly BiblioteContext biblioteContext;
        public InstituicaoRepository(BiblioteContext biblioteContext)
        {
            this.biblioteContext = biblioteContext;
        }

        public async Task<bool> Delete(InstituicaoModels Models)
        {
            biblioteContext.InstituicaoModels.Remove(Models);
            return await Salvar();
        }
        public IQueryable<InstituicaoModels> GetAll()
        {
            return biblioteContext.InstituicaoModels;
        }
        public async Task<InstituicaoModels> GetAll(Expression<Func<InstituicaoModels, bool>> predicate)
        {
            return await biblioteContext.InstituicaoModels.FirstOrDefaultAsync(predicate);
        }
        public async Task<bool> Insert(InstituicaoModels Models)
        {
            await this.biblioteContext.InstituicaoModels.AddAsync(Models);
            return await Salvar();
        }
        public async Task<bool> Update(InstituicaoModels Models)
        {
            this.biblioteContext.InstituicaoModels.Update(Models);
            return await Salvar();
        }
        private async Task<bool> Salvar()
        {
            return await this.biblioteContext.SaveChangesAsync() > 0 ? true : false;
        }
    }
}
