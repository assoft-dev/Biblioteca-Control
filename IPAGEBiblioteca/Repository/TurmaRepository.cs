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
    public class TurmaRepository: ITurmaModels
    {
        #region Contrutores 
        private readonly BiblioteContext biblioteContext;
        public TurmaRepository(BiblioteContext biblioteContext)
        {
            this.biblioteContext = biblioteContext;
        }
        #endregion

        public async Task<bool> Delete(TurmaModels Models)
        {
            biblioteContext.TurmaModels.Remove(Models);
            return await Salvar();
        }
        public IQueryable<TurmaModels> GetAll()
        {
            return biblioteContext.TurmaModels;
        }
        public async Task<TurmaModels> GetAll(Expression<Func<TurmaModels, bool>> predicate)
        {
            return await biblioteContext.TurmaModels.FirstOrDefaultAsync(predicate);
        }
        public async Task<bool> Insert(TurmaModels Models)
        {
            await this.biblioteContext.TurmaModels.AddAsync(Models);
            return await Salvar();
        }
        public async Task<bool> Update(TurmaModels Models)
        {
            this.biblioteContext.TurmaModels.Update(Models);
            return await Salvar();
        }
        private async Task<bool> Salvar()
        {
            return await this.biblioteContext.SaveChangesAsync() > 0 ? true : false;
        }
    }
}
