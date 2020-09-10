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
    public class LogsRepository: IlogModels
    {
        private readonly BiblioteContext biblioteContext;

        public LogsRepository(BiblioteContext biblioteContext)
        {
            this.biblioteContext = biblioteContext;
        }
        public async Task<bool> Delete(LogsModels Models)
        {
            biblioteContext.LogsModels.Remove(Models);
            return await Salvar();
        }
        public IQueryable<LogsModels> GetAll()
        {
            return biblioteContext.LogsModels;
        }
        public async Task<LogsModels> GetAll(Expression<Func<LogsModels, bool>> predicate)
        {
            return await biblioteContext.LogsModels.FirstOrDefaultAsync(predicate);
        }
        public async Task<bool> Insert(LogsModels Models)
        {
            await this.biblioteContext.LogsModels.AddAsync(Models);
            return await Salvar();
        }
        public async Task<bool> Update(LogsModels Models)
        {
            this.biblioteContext.LogsModels.Update(Models);
            return await Salvar();
        }
        private async Task<bool> Salvar()
        {
            return await this.biblioteContext.SaveChangesAsync() > 0 ? true : false;
        }

    }

}
