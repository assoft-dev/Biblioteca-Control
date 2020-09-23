namespace IPAGEBiblioteca.Repository.Interfaces
{
    using IPAGEBiblioteca.Models.Helps;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;


    public interface ITransationRepository
    {
        void Dispose();

        #region Delete
        TransationRepository DoDelete<TEntity>(int entity) where TEntity : class;
        TransationRepository DoDelete<TEntity>(List<TEntity> entity) where TEntity : class;
        TransationRepository DoDelete<TEntity>(TEntity entity) where TEntity : class;
        TransationRepository DoDelete<TEntity>(List<TEntity> entity, Func<TEntity, bool> expression) where TEntity : class;
        TransationRepository DoDelete<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class;

        #endregion

        #region Get
        IQueryable<TEntity> DoGet<TEntity>() where TEntity : class;
        IQueryable<TEntity> DoGet<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;
        int DoGetCount<TEntity>() where TEntity : class;
        #endregion

        #region Insert
        TransationRepository DoInsert<TEntity>(TEntity entity) where TEntity : class;
        TransationRepository DoInsert<T>(List<T> entity) where T : class;
        Task<TEntity> DoInsertReturnAsync<TEntity>(TEntity entity) where TEntity : class;
        TransationRepository DoInsert<TEntity>(TEntity entities, Func<TEntity, object> predicate) where TEntity : class;
        #endregion

        #region Update
        TransationRepository DoUpdate<TEntity>(TEntity entity) where TEntity : class;
        TransationRepository DoUpdate<T>(List<T> entity) where T : class;
        #endregion

        #region Saves
        Task<EstadoTransations> EndTransaction();
        Task<TransationRepository> SaveAndContinue();
        #endregion
    }
}
