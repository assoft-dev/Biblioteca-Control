namespace IPAGEBiblioteca.Repository.Interfaces
{
    using IPAGEBiblioteca.Models;
    using System;
    using System.Linq;

    public interface IlogModels: IRepository<LogsModels>
    {
        IQueryable<LogsModels> GetLogsModels(DateTime dateTime1, DateTime dateTime2);
    }
}
