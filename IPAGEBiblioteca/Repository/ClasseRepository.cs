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
    public class ClasseRepository: IClasseModels
    {
        #region Construtores
        private readonly BiblioteContext biblioteContext;
        public ClasseRepository(BiblioteContext biblioteContext)
        {
            this.biblioteContext = biblioteContext;
        }
        #endregion

        #region Metodos
        public async Task<bool> Delete(ClasseModels Models)
        {
            biblioteContext.ClasseModels.Remove(Models);
            return await Salvar();
        }
        public IQueryable<ClasseModels> GetAll()
        {
            return biblioteContext.ClasseModels;
        }
        public async Task<ClasseModels> GetAll(Expression<Func<ClasseModels, bool>> predicate)
        {
            return await biblioteContext.ClasseModels.FirstOrDefaultAsync(predicate);
        }
        public async Task<bool> Insert(ClasseModels Models)
        {
            await this.biblioteContext.ClasseModels.AddAsync(Models);
            return await Salvar();
        }
        public async Task<bool> Update(ClasseModels Models)
        {
            this.biblioteContext.ClasseModels.Update(Models);
            return await Salvar();
        }
        private async Task<bool> Salvar()
        {
            return await this.biblioteContext.SaveChangesAsync() > 0 ? true : false;
        }
        #endregion
    }
}
