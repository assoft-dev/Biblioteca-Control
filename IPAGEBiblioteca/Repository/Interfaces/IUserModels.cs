namespace IPAGEBiblioteca.Repository.Interfaces
{
    using IPAGEBiblioteca.Models;
    using System.Threading.Tasks;

    public interface IUserModels:IRepository<UserModels>
    {
        Task<UserState> Login(string UserName, string Password); 
    }
}
