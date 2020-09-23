using IPAGEBiblioteca.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IPAGEBiblioteca.Repository.Interfaces
{
    public interface IDefinicoesModels: IRepository<DefinicoesModels>
    {
        Task<bool> Insert(List<DefinicoesModels> Models);
    }
}
