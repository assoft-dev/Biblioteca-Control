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

    public class AlunoRepository : IAlunoModels
    {
        private readonly BiblioteContext biblioteContext;
        public AlunoRepository(BiblioteContext biblioteContext)
        {
            this.biblioteContext = biblioteContext;
        }
        public async Task<bool> Delete(AlunoModels Models)
        {
             biblioteContext.AlunoModels.Remove(Models);
             return await Salvar();
        }
        public IQueryable<AlunoModels> GetAll()
        {
             return biblioteContext.AlunoModels;
        }
        public async Task<AlunoModels> GetAll(Expression<Func<AlunoModels, bool>> predicate)
        {
            return await biblioteContext.AlunoModels.FirstOrDefaultAsync(predicate);
        }
        public async Task<bool> Insert(AlunoModels Models)
        {
            await this.biblioteContext.AlunoModels.AddAsync(Models);
            return await Salvar();
        }
        public async Task<bool> Update(AlunoModels Models)
        {
            this.biblioteContext.AlunoModels.Update(Models);
            return await Salvar();
        }
        private async Task<bool> Salvar()
        {
            return await this.biblioteContext.SaveChangesAsync() > 0 ? true : false;
        }
    }
}
