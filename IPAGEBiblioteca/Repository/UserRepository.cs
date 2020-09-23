using DevExpress.Office.Utils;
using IPAGEBiblioteca.Controllers.Helps;
using IPAGEBiblioteca.Models;
using IPAGEBiblioteca.Repository.Helps;
using IPAGEBiblioteca.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
        public async Task<bool> Guardar(UserModels Models)
        {
            if (Models.ID != 0)
                this.biblioteContext.UserModels.Update(Models);
            else
                await this.biblioteContext.UserModels.AddAsync(Models);
            return await Salvar();

        }
        public async Task<bool> Guardar(List<UserModels> Models)
        {
            foreach (var item in Models)
            {
                if (item.ID == 0)
                    await this.biblioteContext.UserModels.AddAsync(item);
                else
                    this.biblioteContext.UserModels.Update(item);
            }
            return await Salvar();
        }

        public async Task<UserStateRequered> Login(string UserName, string Password)
        {
            var md5 = HashControl.GetMD5Hash(Password);
            var userModels = await this.biblioteContext.UserModels.Include(x => x.GruposModels)
                                                                  .ThenInclude(x => x.PermissoesModels)
                                                                  .AsNoTracking()
                                                                  .ToListAsync();
            if (userModels.Count == 0)
            {
                return new UserStateRequered
                {
                    UserState = UserState.Invalid_First_Values,
                    Models = null,
                };
            }
            var result = userModels.FirstOrDefault(x => (x.UserName.ToUpper().Equals(UserName.ToUpper()) || x.UserName.ToUpper().Equals(UserName.ToUpper())) &&
                                                         x.Password.Equals(md5));
            if (result == null)
            {
                return new UserStateRequered
                {
                    UserState = UserState.Invalid,
                    Models = null,
                };
            }       
            else if (!result.IsValido){
                return new UserStateRequered
                {
                    UserState = UserState.Standbay,
                    Models = result,
                };
            }           
            else if(result.GruposModels == null){
                return new UserStateRequered
                {
                    UserState = UserState.Invalid_Grpos,
                    Models = result,
                };
            }
            else if (result.GruposModels.PermissoesModels == null)
            {
                return new UserStateRequered
                {
                    UserState = UserState.Invalid_Permissoes,
                    Models = result,
                };
            }
            else
            {
                return new UserStateRequered
                {
                    UserState = UserState.IsValid,
                    Models = result,
                };
            }
        }
        public async Task<bool> RecoveryUpdate(string user, string senha1, string senha2)
        {
            var testPassword = senha1.Split(',').FirstOrDefault();
            var PinEncrip = "";
            if (testPassword.Equals("MD5"))
                PinEncrip = senha1.Split(',').LastOrDefault();
            else
                PinEncrip = HashControl.GetMD5Hash(senha1);
            var PinEncrip2 = HashControl.GetMD5Hash(senha2);

            var userSeach = await this.biblioteContext.UserModels.Include(x => x.GruposModels)
                                                       .ThenInclude(x => x.PermissoesModels)
                                    .Where(x => (x.UserName.ToLower() == user.ToLower() || x.Email == user) &&
                                                (x.Password == PinEncrip || x.Password == PinEncrip))
                                    .FirstOrDefaultAsync();
            if (userSeach != null)
            {
                userSeach.Password = PinEncrip2;
                this.biblioteContext.LogsModels.Add(new LogsModels
                {
                    userModelsID = userSeach.ID,
                    DateTime = DateTime.Now,
                    Referencia = "Alteração da passwordo do utilizador (Acesso inicial)",
                });
                biblioteContext.UserModels.Update(userSeach);
               return await Salvar();
            }
            else
                return false;
        }
        private async Task<bool> Salvar()
        {
            return await this.biblioteContext.SaveChangesAsync() > 0 ? true : false;
        }
        #endregion
    }
}
