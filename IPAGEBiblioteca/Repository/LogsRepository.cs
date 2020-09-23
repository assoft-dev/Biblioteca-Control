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

        public IQueryable<LogsModels> GetLogsModels(DateTime dateTime1, DateTime dateTime2)
        {
            return this.biblioteContext.LogsModels
                               .Include(x => x.userModels)
                               .Where(x => x.DateTime.Date >= dateTime1.Date && x.DateTime <= dateTime2.Date);
        }

        public async Task<bool> Guardar(LogsModels Models)
        {
            if (Models.ID == 0)
                await this.biblioteContext.LogsModels.AddAsync(Models);
            else
                this.biblioteContext.LogsModels.Update(Models);
            return await Salvar();
        }
        private async Task<bool> Salvar()
        {
            return await this.biblioteContext.SaveChangesAsync() > 0 ? true : false;
        }
    }
}
