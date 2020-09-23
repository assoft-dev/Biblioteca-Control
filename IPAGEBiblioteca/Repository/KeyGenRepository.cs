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

    public class KeyGenRepository: IKeyGenRepository
    {
        private readonly BiblioteContext biblioteContext;
        public KeyGenRepository(BiblioteContext biblioteContext)
        {
            this.biblioteContext = biblioteContext;
        }

        #region Metodos
        public async Task<bool> Delete(KeysGensModels Models)
        {
            biblioteContext.KeysGens.Remove(Models);
            return await Salvar();
        }
        public IQueryable<KeysGensModels> GetAll()
        {
            return biblioteContext.KeysGens;
        }
        public async Task<KeysGensModels> GetAll(Expression<Func<KeysGensModels, bool>> predicate)
        {
            return await biblioteContext.KeysGens.FirstOrDefaultAsync(predicate);
        }
        public async Task<bool> Guardar(KeysGensModels Models)
        {
            if (Models.KeysGenID == 0)
                await this.biblioteContext.KeysGens.AddAsync(Models);
            else
                this.biblioteContext.KeysGens.Update(Models);
            return await Salvar();
        }
        private async Task<bool> Salvar()
        {
            return await this.biblioteContext.SaveChangesAsync() > 0 ? true : false;
        }
        #endregion
    }
}
