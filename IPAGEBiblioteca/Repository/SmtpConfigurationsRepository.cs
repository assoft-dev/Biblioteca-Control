using IPAGEBiblioteca.Models;
using IPAGEBiblioteca.Repository.Helps;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IPAGEBiblioteca.Repository
{
    public class SmtpConfigurationsRepository
    {
        private readonly BiblioteContext biblioteContext;
        public SmtpConfigurationsRepository(BiblioteContext biblioteContext)
        {
            this.biblioteContext = biblioteContext;
        }

        #region Metodos
        public async Task<bool> Delete(SmtpConfigurationsModels Models)
        {
            biblioteContext.SmtpConfigurationsModels.Remove(Models);
            return await Salvar();
        }
        public IQueryable<SmtpConfigurationsModels> GetAll()
        {
            return biblioteContext.SmtpConfigurationsModels;
        }
        public async Task<SmtpConfigurationsModels> GetAll(Expression<Func<SmtpConfigurationsModels, bool>> predicate)
        {
            return await biblioteContext.SmtpConfigurationsModels.FirstOrDefaultAsync(predicate);
        }
        public async Task<bool> Insert(SmtpConfigurationsModels Models)
        {
            if (Models.ID == 0)
                await this.biblioteContext.SmtpConfigurationsModels.AddAsync(Models);
            else
                this.biblioteContext.SmtpConfigurationsModels.Update(Models);
            return await Salvar();
        }
        public async Task<bool> Update(SmtpConfigurationsModels Models)
        {
            
            return await Salvar();
        }
        private async Task<bool> Salvar()
        {
            return await this.biblioteContext.SaveChangesAsync() > 0 ? true : false;
        }
        #endregion
    }
}
