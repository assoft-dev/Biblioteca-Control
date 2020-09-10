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
    public class PedidosRepository: IPedidoModels
    {
        #region Construtores
        private readonly BiblioteContext biblioteContext;
        public PedidosRepository(BiblioteContext biblioteContext)
        {
            this.biblioteContext = biblioteContext;
        }
        #endregion

        #region Metodos
        public async Task<bool> Delete(PedidosModels Models)
        {
            biblioteContext.PedidosModels.Remove(Models);
            return await Salvar();
        }
        public IQueryable<PedidosModels> GetAll()
        {
            return biblioteContext.PedidosModels;
        }
        public async Task<PedidosModels> GetAll(Expression<Func<PedidosModels, bool>> predicate)
        {
            return await biblioteContext.PedidosModels.FirstOrDefaultAsync(predicate);
        }
        public async Task<bool> Insert(PedidosModels Models)
        {
            await this.biblioteContext.PedidosModels.AddAsync(Models);
            return await Salvar();
        }
        public async Task<bool> Update(PedidosModels Models)
        {
            this.biblioteContext.PedidosModels.Update(Models);
            return await Salvar();
        }
        private async Task<bool> Salvar()
        {
            return await this.biblioteContext.SaveChangesAsync() > 0 ? true : false;
        }
        #endregion
    }
}
