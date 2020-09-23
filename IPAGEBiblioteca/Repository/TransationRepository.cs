
using IPAGEBiblioteca.Controllers.Extension;
using IPAGEBiblioteca.Controllers.Helps;
using IPAGEBiblioteca.Models.Helps;
using IPAGEBiblioteca.Repository.Helps;
using IPAGEBiblioteca.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IPAGEBiblioteca.Repository
{
    public class TransationRepository : IDisposable, ITransationRepository
    {
        #region Declaração de Variaveis
        public DbContext Context { get; set; }
        public IExecutionStrategy executionStrategy { get; set; }
        public IDbContextTransaction Transaction { get; set; }
        #endregion

        #region Construtores
        public TransationRepository(DbContext context, bool IsTransation)
        {
            Context = context;
            if (IsTransation)
                executionStrategy = Context.Database.CreateExecutionStrategy();
        }
        public TransationRepository(bool IsTransation)
        {
            Context = new BiblioteContext();
            if (IsTransation)
                Transaction = Context.Database.BeginTransaction();
        }
        #endregion

        #region Insert
        public TransationRepository DoInsert<TEntity>(TEntity entity) where TEntity : class
        {
            Context.Set<TEntity>().Add(entity);
            return this;
        }
        public TransationRepository DoInsert<T>(List<T> entity) where T : class
        {
            foreach (var item in entity)
                Context.Set<T>().Add(item);
            return this;
        }
        public async Task<TEntity> DoInsertReturnAsync<TEntity>(TEntity entity) where TEntity : class
        {
            EntityEntry<TEntity> result = Context.Set<TEntity>().Add(entity);
            await SaveAndContinue();
            return result.Entity;
        }
        public TransationRepository DoInsert<TEntity>(TEntity entities, Func<TEntity, object> predicate) where TEntity : class
        {
            var newValues = predicate.Invoke(entities);
            Expression<Func<TEntity, bool>> compare = arg => predicate(arg).Equals(newValues);
            var compiled = compare.Compile();
            var existing = Context.Set<TEntity>().FirstOrDefault(compiled);

            if (existing == null)
                this.Context.Set<TEntity>().Add(entities);
            else
            {
                try
                {
                    this.Context.Entry(entities).State = EntityState.Modified;
                }
                catch
                {
                    // Buscar Chaves Primárias
                    var getKeys = this.Context.FindPrimaryKeyValues(entities);
                    if (getKeys == null)
                        new Exception();
                    // Buscar Entidade do Banco de dados Já existente
                    var entity1 = this.Context.Set<TEntity>().FindAsync(getKeys);
                    if (entity1 == null)
                        new Exception();

                    this.Context.Entry(entity1).CurrentValues.SetValues(entities);
                }
            }
            return this;
        }
        #endregion

        #region ListAll
        public IQueryable<TEntity> DoGet<TEntity>() where TEntity : class
        {
            return Context.Set<TEntity>().AsNoTracking();
        }
        public IQueryable<TEntity> DoGet<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return Context.Set<TEntity>().Where(predicate).AsNoTracking();
        }
        public int DoGetCount<TEntity>() where TEntity : class
        {
            return Context.Set<TEntity>().Count();
        }
        #endregion

        #region Update
        public TransationRepository DoUpdate<TEntity>(TEntity entities) where TEntity : class
        {
            // Buscar Chaves Primárias
            var getKeys = this.Context.FindPrimaryKeyValues(entities).FirstOrDefault();
            if (getKeys == null)
                new Exception();
            // Buscar Entidade do Banco de dados Já existente
            var entity1 = this.Context.Set<TEntity>().Find(getKeys);
            if (entity1 == null)
                new Exception();
            this.Context.Entry(entity1).CurrentValues.SetValues(entities);
            return this;
        }
        public TransationRepository DoUpdate<T>(List<T> entity) where T : class
        {
            try
            {
                foreach (var models in entity)
                {
                    // Buscar Chaves Primárias
                    var getKeys = this.Context.FindPrimaryKeyValues(models).FirstOrDefault();
                    if (getKeys == null)
                        new Exception();
                    // Buscar Entidade do Banco de dados Já existente
                    var entity1 = this.Context.Set<T>().FindAsync(getKeys);
                    if (entity1 == null)
                        new Exception();
                    this.Context.Entry(entity1).CurrentValues.SetValues(models);
                }
            }
            catch
            {
                foreach (var models in entity)
                    Context.Entry(models).State = EntityState.Modified;
                Context.ChangeTracker.DetectChanges();
            }
            return this;
        }
        #endregion

        #region Delete
        public TransationRepository DoDelete<TEntity>(TEntity entity) where TEntity : class
        {
            Context.Entry(entity).State = EntityState.Deleted;
            return this;
        }
        public TransationRepository DoDelete<TEntity>(int entity) where TEntity : class
        {
            var values = Context.Set<TEntity>().Find(entity);
            Context.Entry(values).State = EntityState.Deleted;
            return this;
        }
        public TransationRepository DoDelete<TEntity>(List<TEntity> entity) where TEntity : class
        {
            Context.Entry(entity).State = EntityState.Deleted;
            return this;
        }
        public TransationRepository DoDelete<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class
        {
            var result = this.Context.Set<TEntity>().FindPredicate(expression);
            this.Context.Entry(result).State = EntityState.Deleted;
            return this;
        }
        public TransationRepository DoDelete<TEntity>(List<TEntity> entity, Func<TEntity, bool> expression) where TEntity : class
        {
            foreach (var item in entity.Where(expression))
                Context.Entry(item).State = EntityState.Deleted;
            return this;
        }
        #endregion

        #region Saves
        public async Task<TransationRepository> SaveAndContinue()
        {
            try
            {
                await Context.SaveChangesAsync();
            }
            catch
            {
                RollBack();
            }
            return this;
        }
        public async Task<EstadoTransations> EndTransaction()
        {
            try
            {
                await Context.SaveChangesAsync();
                Transaction.Commit();
            }
            catch (Exception exe)
            {
                EscreverLogs.Escrever(null, exe);
                MessageBox.Show("Erro na tentativa de salvar!... " + exe.InnerException != null ? exe.InnerException.Message : exe.Message);
                RollBack();
                return new EstadoTransations
                {
                    estado = false,
                    Exception = exe,
                };
            }
            return new EstadoTransations
            {
                estado = true,
                Exception = null,
            };
        }
        #endregion

        #region Error end Roll Back
        private void RollBack()
        {
            Transaction.Rollback();
            Dispose();
        }
        public void Dispose()
        {
            Transaction?.Dispose();
            Context?.Dispose();
        }
        #endregion
    }
}
