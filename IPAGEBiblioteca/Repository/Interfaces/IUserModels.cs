namespace IPAGEBiblioteca.Repository.Interfaces
{
    using IPAGEBiblioteca.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IUserModels:IRepository<UserModels>
    {
        Task<UserStateRequered> Login(string UserName, string Password);
        Task<bool> Guardar(List<UserModels> Models);

        Task<bool> RecoveryUpdate(string user, string passwordOlder, string passwordNews);
    }
}
