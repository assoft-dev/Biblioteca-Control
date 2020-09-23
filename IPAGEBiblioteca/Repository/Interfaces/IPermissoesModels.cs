namespace IPAGEBiblioteca.Repository.Interfaces
{
    using DevExpress.Office.Utils;
    using IPAGEBiblioteca.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPermissoesModels: IRepository<PermissoesModels>
    {
        Task<bool> Insert(List<PermissoesModels> permissoesModels);
    }
}
