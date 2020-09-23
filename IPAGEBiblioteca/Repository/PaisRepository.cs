namespace IPAGEBiblioteca.Repository
{
    using IPAGEBiblioteca.Models;
    using IPAGEBiblioteca.Repository.Helps;
    using IPAGEBiblioteca.Repository.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public class PaisRepository: IPaisModels
    {
        #region Contrutores da Classe
        private readonly BiblioteContext biblioteContext;
        public PaisRepository(BiblioteContext biblioteContext)
        {
            this.biblioteContext = biblioteContext;
        }
        #endregion

        #region Metodos
        public async Task<bool> Delete(PaisModels Models)
        {
            biblioteContext.PaisModels.Remove(Models);
            return await Salvar();
        }
        public IQueryable<PaisModels> GetAll()
        {
            return biblioteContext.PaisModels;
        }
        public async Task<PaisModels> GetAll(Expression<Func<PaisModels, bool>> predicate)
        {
            return await biblioteContext.PaisModels.FirstOrDefaultAsync(predicate);
        }
        public async Task<bool> Guardar(PaisModels Models)
        {
            if (Models.ID == 0)
                await this.biblioteContext.PaisModels.AddAsync(Models);
            else
                this.biblioteContext.PaisModels.Update(Models);
            return await Salvar();
        }
        private async Task<bool> Salvar()
        {
            return await this.biblioteContext.SaveChangesAsync() > 0 ? true : false;
        }
        #endregion
    }
}
