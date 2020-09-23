using DevExpress.Data.Async;
using IPAGEBiblioteca.Models;
using System;
using System.Linq;

namespace IPAGEBiblioteca.Repository.Interfaces
{
    public interface IPedidoModels: IRepository<PedidosModels>
    {
        string GetDocument();
        IQueryable<PedidosModels> GetAll(DateTime dateTime1, DateTime dateTime2);
    }
}
