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
    public  class UserRepository: IUserModels
    {
        #region Contrutores da Classe
        private readonly BiblioteContext biblioteContext;
        public UserRepository(BiblioteContext biblioteContext)
        {
            this.biblioteContext = biblioteContext;
        }
        #endregion

        #region Metodos
        public async Task<bool> Delete(UserModels Models)
        {
            biblioteContext.UserModels.Remove(Models);
            return await Salvar();
        }
        public IQueryable<UserModels> GetAll()
        {
            return biblioteContext.UserModels;
        }
        public async Task<UserModels> GetAll(Expression<Func<UserModels, bool>> predicate)
        {
            return await biblioteContext.UserModels.FirstOrDefaultAsync(predicate);
        }
        public async Task<bool> Insert(UserModels Models)
        {
            await this.biblioteContext.UserModels.AddAsync(Models);
            return await Salvar();
        }

        public async Task<UserState> Login(string UserName, string Password)
        {
            var result = await this.biblioteContext.UserModels
                                                   .FirstOrDefaultAsync(x => x.UserName.Equals(UserName) &&
                                                                             x.Password.Equals(Password));
            if (result == null)
                return UserState.Invalid;
            else if (result.IsValido)
                return UserState.Standbay;
            else
                return UserState.IsValid;
        }

        public async Task<bool> Update(UserModels Models)
        {
            this.biblioteContext.UserModels.Update(Models);
            return await Salvar();
        }
        private async Task<bool> Salvar()
        {
            return await this.biblioteContext.SaveChangesAsync() > 0 ? true : false;
        }
        #endregion
    }
}
