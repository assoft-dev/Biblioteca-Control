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
    public class EditoraRepository: IEditoraModels
    {
        #region Construtores
        private readonly BiblioteContext biblioteContext;
        public EditoraRepository(BiblioteContext biblioteContext)
        {
            this.biblioteContext = biblioteContext;
        }  
        #endregion

        #region Metodos
        public async Task<bool> Delete(EditoraModels Models)
        {
            biblioteContext.EditoraModels.Remove(Models);
            return await Salvar();
        }
        public IQueryable<EditoraModels> GetAll()
        {
            return biblioteContext.EditoraModels;
        }
        public async Task<EditoraModels> GetAll(Expression<Func<EditoraModels, bool>> predicate)
        {
            return await biblioteContext.EditoraModels.FirstOrDefaultAsync(predicate);
        }
        public async Task<bool> Insert(EditoraModels Models)
        {
            await this.biblioteContext.EditoraModels.AddAsync(Models);
            return await Salvar();
        }
        public async Task<bool> Update(EditoraModels Models)
        {
            this.biblioteContext.EditoraModels.Update(Models);
            return await Salvar();
        }
        private async Task<bool> Salvar()
        {
            return await this.biblioteContext.SaveChangesAsync() > 0 ? true : false;
        }
        #endregion
    }
}
