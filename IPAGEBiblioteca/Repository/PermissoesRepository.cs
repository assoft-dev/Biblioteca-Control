namespace IPAGEBiblioteca.Repository
{
    using IPAGEBiblioteca.Models;
    using IPAGEBiblioteca.Repository.Helps;
    using IPAGEBiblioteca.Repository.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public class PermissoesRepository : IPermissoesModels
    {
        private readonly BiblioteContext biblioteContext;
        public PermissoesRepository(BiblioteContext biblioteContext)
        {
            this.biblioteContext = biblioteContext;
        }
        #region Metodos
        public async Task<bool> Delete(PermissoesModels Models)
        {
            biblioteContext.PermissoesModels.Remove(Models);
            return await Salvar();
        }
        public IQueryable<PermissoesModels> GetAll()
        {
            return biblioteContext.PermissoesModels;
        }
        public async Task<PermissoesModels> GetAll(Expression<Func<PermissoesModels, bool>> predicate)
        {
            return await biblioteContext.PermissoesModels.FirstOrDefaultAsync(predicate);
        }
        public async Task<bool> Guardar(PermissoesModels Models)
        {
            await this.biblioteContext.PermissoesModels.AddAsync(Models);
            return await Salvar();
        }

        public async Task<bool> Insert(List<PermissoesModels> permissoesModels)
        {
            if (permissoesModels.Count > 0)
            {
                foreach (var item in permissoesModels)
                {
                    if (item.ID != 0)
                        this.biblioteContext.PermissoesModels.Update(item);
                    else
                        await this.biblioteContext.PermissoesModels.AddAsync(item);
                }
            }
            return await Salvar();
        }
        private async Task<bool> Salvar()
        {
            return await this.biblioteContext.SaveChangesAsync() > 0 ? true : false;
        }
        #endregion
    }
}
