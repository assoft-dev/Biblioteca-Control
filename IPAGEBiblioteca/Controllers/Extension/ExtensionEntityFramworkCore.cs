using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IPAGEBiblioteca.Controllers.Extension
{
    public static class ExtensionEntityFramworkCore
    {
        #region MultipleInclud()
        public static IQueryable<T> IncludeMultiple<T>(this IQueryable<T> query, params Expression<Func<T, object>>[] includes)
                                                     where T : class
        {
            if (includes != null)
            {
                query = includes.Aggregate(query,
                          (current, include) => current.Include(include));
            }
            return query;
        }
        #endregion

        /// <summary>
        /// Faz um set.Any(predicate)
        /// Se não existe nada no set então adiciona
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="set">Set onde será adicionada a entidade</param>
        /// <param name="predicate">Condição (exemplo: dbUser => dbUser.Nome == "Gustavo")</param>
        /// <param name="entity">Entidade para adicionar</param>
        /// <returns></returns>
        /// 

        #region AddIfNotExists
        public static T AddIfNotExists<T>(this DbSet<T> dbSet, T entity, Expression<Func<T, bool>> predicate = null) where T : class
        {
            var exists = predicate != null ? dbSet.Any(predicate) : dbSet.Any();
            return !exists ? dbSet.Add(entity).Entity : null;
        }
        public async static Task<T> AddIfNotExistsAsync<T>(this DbSet<T> dbSet, T entity, Expression<Func<T, bool>> predicate = null) where T : class
        {
            var exists = predicate != null ? await dbSet.AnyAsync(predicate) : await dbSet.AnyAsync();
            return !exists ? dbSet.Add(entity).Entity : null;
        }
        #endregion

        #region AddRangeIfNotExists
        public static void AddRangeIfNotExists<TEnt, TKey>(this DbSet<TEnt> dbSet, IEnumerable<TEnt> entities, Func<TEnt, TKey> predicate) where TEnt : class
        {
            var entitiesExist = from ent in dbSet
                                where entities.Any(add => predicate(ent).Equals(predicate(add)))
                                select ent;
            dbSet.AddRange(entities.Except(entitiesExist));
        }
        public static void AddRangeIfNotExists<TEnt, TKey>(this DbSet<TEnt> dbSet, List<TEnt> entities, Func<TEnt, TKey> predicate) where TEnt : class
        {
            var entitiesExist = from ent in dbSet
                                where entities.Any(add => predicate(ent).Equals(predicate(add)))
                                select ent;
            dbSet.AddRange(entities.Except(entitiesExist));
        }
        #endregion

        #region FindPredicate
        public static IEnumerable<T> FindPredicate<T>(this DbSet<T> dbSet, Expression<Func<T, bool>> predicate) where T : class
        {
            var local = dbSet.Local.Where(predicate.Compile());
            return local.Any()
                ? local
                : dbSet.Where(predicate).ToArray();
        }
        public static async Task<IEnumerable<T>> FindPredicateAsync<T>(this DbSet<T> dbSet, Expression<Func<T, bool>> predicate) where T : class
        {
            var local = dbSet.Local.Where(predicate.Compile());
            return local.Any()
                ? local
                : await dbSet.Where(predicate).ToArrayAsync().ConfigureAwait(false);
        }
        #endregion

        #region Where <IN> OR <NOT IN>
        public static IQueryable<TEntity> WhereIn<TEntity, TValue>(
        this IQueryable<TEntity> queryable,
        Expression<Func<TEntity, TValue>> valueSelector,
        IEnumerable<TValue> values)
        where TEntity : class
        {
            if (queryable == null)
                throw new ArgumentNullException("queryable");

            if (valueSelector == null)
                throw new ArgumentNullException("valueSelector");

            if (values == null)
                throw new ArgumentNullException("values");

            if (!values.Any())
                return queryable.Where(e => true);

            var parameterExpression = valueSelector.Parameters.Single();

            var equals = from value in values
                         select Expression.Equal(valueSelector.Body, Expression.Constant(value, typeof(TValue)));

            var body = equals.Aggregate(Expression.Or);

            return queryable.Where(Expression.Lambda<Func<TEntity, bool>>(body, parameterExpression));
        }

        public static IQueryable<TEntity> WhereNotIn<TEntity, TValue>(
       this IQueryable<TEntity> queryable,
       Expression<Func<TEntity, TValue>> valueSelector,
       IEnumerable<TValue> values)
       where TEntity : class
        {
            if (queryable == null)
                throw new ArgumentNullException("queryable");

            if (valueSelector == null)
                throw new ArgumentNullException("valueSelector");

            if (values == null)
                throw new ArgumentNullException("values");

            if (!values.Any())
                return queryable.Where(e => true);

            var parameterExpression = valueSelector.Parameters.Single();

            var equals = from value in values
                         select Expression.NotEqual(valueSelector.Body, Expression.Constant(value, typeof(TValue)));

            var body = equals.Aggregate(Expression.And);

            return queryable.Where(Expression.Lambda<Func<TEntity, bool>>(body, parameterExpression));
        }
        #endregion

        #region GetKeyNames
        public static IEnumerable<string> FindPrimaryKeyNames<T>(this DbContext dbContext, T entity)
        {
            return from p in dbContext.FindPrimaryKeyProperties(entity)
                   select p.Name;
        }
        public static IEnumerable<object> FindPrimaryKeyValues<T>(this DbContext dbContext, T entity)
        {
            return from p in dbContext.FindPrimaryKeyProperties(entity)
                   select entity.GetPropertyValue(p.Name);
        }
        private static IReadOnlyList<IProperty> FindPrimaryKeyProperties<T>(this DbContext dbContext, T entity)
        {
            return dbContext.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties;
        }
        private static object GetPropertyValue<T>(this T entity, string name)
        {
            return entity.GetType().GetProperty(name).GetValue(entity, null);
        }
        #endregion
    }
}
