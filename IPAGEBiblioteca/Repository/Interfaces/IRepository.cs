namespace IPAGEBiblioteca.Repository.Interfaces
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    public interface IRepository<T>
    {
        Task<bool> Guardar(T Models);
        Task<bool> Delete(T Models);
        IQueryable<T> GetAll();
        Task<T> GetAll(Expression<Func<T, bool>> predicate);
    }
}
