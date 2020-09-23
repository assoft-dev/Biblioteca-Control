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

    public class DefinicoesRepository: IDefinicoesModels
    {
        private readonly BiblioteContext biblioteContext;
        public DefinicoesRepository(BiblioteContext biblioteContext)
        {
            this.biblioteContext = biblioteContext;
        }

        #region Metodos
        public async Task<bool> Delete(DefinicoesModels Models)
        {
            biblioteContext.DefinicoesModels.Remove(Models);
            return await Salvar();
        }
        public IQueryable<DefinicoesModels> GetAll()
        {
            return biblioteContext.DefinicoesModels;
        }
        public async Task<DefinicoesModels> GetAll(Expression<Func<DefinicoesModels, bool>> predicate)
        {
            return await biblioteContext.DefinicoesModels.FirstOrDefaultAsync(predicate);
        }
        public async Task<bool> Guardar(DefinicoesModels Models)
        {
            if (Models.ID == 0)
                await this.biblioteContext.DefinicoesModels.AddAsync(Models);
            else
                this.biblioteContext.DefinicoesModels.Update(Models);

            return await Salvar();
        }
        public async Task<bool> Insert(List<DefinicoesModels> Models)
        {
            foreach (var item in Models)
            {
                if (item.ID == 0)
                    await this.biblioteContext.DefinicoesModels.AddAsync(item);
                else
                    this.biblioteContext.DefinicoesModels.Update(item);
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
