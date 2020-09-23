using IPAGEBiblioteca.Models;
using IPAGEBiblioteca.Repository.Helps;
using IPAGEBiblioteca.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IPAGEBiblioteca.Repository
{
    public class GruposRepository : IGruposRepository
    {
        private readonly BiblioteContext biblioteContext;
        public GruposRepository(BiblioteContext biblioteContext)
        {
            this.biblioteContext = biblioteContext;
        }
        public async Task<bool> Delete(GruposModels Models)
        {
            biblioteContext.GruposModels.Remove(Models);
            return await Salvar();
        }
        public IQueryable<GruposModels> GetAll()
        {
            return biblioteContext.GruposModels;
        }
        public async Task<GruposModels> GetAll(Expression<Func<GruposModels, bool>> predicate)
        {
            return await biblioteContext.GruposModels.FirstOrDefaultAsync(predicate);
        }
        public async Task<bool> Guardar(GruposModels Models)
        {
            if (Models.ID == 0)
                await this.biblioteContext.GruposModels.AddAsync(Models);
            else
                this.biblioteContext.GruposModels.Update(Models);
            return await Salvar();
        }
       
        private async Task<bool> Salvar()
        {
            return await this.biblioteContext.SaveChangesAsync() > 0 ? true : false;
        }
    }
}
