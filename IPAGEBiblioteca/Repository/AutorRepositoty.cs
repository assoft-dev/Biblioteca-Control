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
    public class AutorRepositoty : IAutorModels
    {
        private readonly BiblioteContext biblioteContext;
        public AutorRepositoty(BiblioteContext _biblioteContext)
        {
            biblioteContext = _biblioteContext;
        }
        public async Task<bool> Delete(AutorModels Models)
        {
            biblioteContext.AutorModels.Remove(Models);
            return await Salvar();
        }
        public IQueryable<AutorModels> GetAll()
        {
            return biblioteContext.AutorModels;
        }
        public async Task<AutorModels> GetAll(Expression<Func<AutorModels, bool>> predicate)
        {
            return await biblioteContext.AutorModels.FirstOrDefaultAsync(predicate);
        }
        public async Task<bool> Guardar(AutorModels Models)
        {
            if (Models.ID == 0)
                await this.biblioteContext.AutorModels.AddAsync(Models);
            else
                this.biblioteContext.AutorModels.Update(Models);
            return await Salvar();
        }
        private async Task<bool> Salvar()
        {
            return await this.biblioteContext.SaveChangesAsync() > 0 ? true : false;
        }
    }
}
