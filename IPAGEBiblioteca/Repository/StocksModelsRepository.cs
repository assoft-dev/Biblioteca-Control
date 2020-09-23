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
    public  class StocksModelsRepository:  IStocksModels
    {
        private readonly BiblioteContext biblioteContext;
        public StocksModelsRepository(BiblioteContext biblioteContext)
        {
            this.biblioteContext = biblioteContext;
        }

        #region Metodos
        public async Task<bool> Delete(StocksModels Models)
        {
            biblioteContext.StocksModels.Remove(Models);
            return await Salvar();
        }
        public IQueryable<StocksModels> GetAll()
        {
            return biblioteContext.StocksModels;
        }
        public async Task<StocksModels> GetAll(Expression<Func<StocksModels, bool>> predicate)
        {
            return await biblioteContext.StocksModels.FirstOrDefaultAsync(predicate);
        }
        public async Task<bool> Guardar(StocksModels Models)
        {
            if (Models.ID == 0)
                await this.biblioteContext.StocksModels.AddAsync(Models);
            else
                this.biblioteContext.StocksModels.Update(Models);
            return await Salvar();
        }
        private async Task<bool> Salvar()
        {
            return await this.biblioteContext.SaveChangesAsync() > 0 ? true : false;
        }
        #endregion
    }
}
