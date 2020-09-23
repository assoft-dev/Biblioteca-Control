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
    public class PedidosOrdemRepository: IPedidoOrdemModels
    {
        #region Construtores
        private readonly BiblioteContext biblioteContext;
        public PedidosOrdemRepository(BiblioteContext biblioteContext)
        {
            this.biblioteContext = biblioteContext;
        }
        #endregion

        public async Task<bool> Delete(PedidosOrdemModels Models)
        {
            biblioteContext.PedidosOrdemModels.Remove(Models);
            return await Salvar();
        }
        public IQueryable<PedidosOrdemModels> GetAll()
        {
            return biblioteContext.PedidosOrdemModels;
        }
        public async Task<PedidosOrdemModels> GetAll(Expression<Func<PedidosOrdemModels, bool>> predicate)
        {
            return await biblioteContext.PedidosOrdemModels.FirstOrDefaultAsync(predicate);
        }
        public async Task<bool> Guardar(PedidosOrdemModels Models)
        {
            if (Models.ID == 0)
                await this.biblioteContext.PedidosOrdemModels.AddAsync(Models);
            else
                this.biblioteContext.PedidosOrdemModels.Update(Models);
            return await Salvar();
        }
        private async Task<bool> Salvar()
        {
            return await this.biblioteContext.SaveChangesAsync() > 0 ? true : false;
        }
    }
}
