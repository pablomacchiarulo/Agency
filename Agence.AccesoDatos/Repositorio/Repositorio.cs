using Agence.AccesoDatos.Contratos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Agence.AccesoDatos.Repositorio
{
    public class Repositorio<TEntity> : IRepositorio<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        public Repositorio(DbContext context)
        {
            Context = context;
        }

        /// <summary>
        /// Método para agregar una entidad
        /// </summary>
        /// <param name="entity">Entidad agreagda</param>
        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        /// <summary>
        /// Método para agregar una lista de entidades
        /// </summary>
        /// <param name="entities">lista de entidades agreagdas</param>
        public void AddRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().AddRange(entities);
        }

        /// <summary>
        /// Obtener lista de entidades con predicado
        /// </summary>
        /// <param name="predicate">filtros para la búsqueda</param>
        /// <returns>Devuelve la lista de la entidad.</returns>
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }

        /// <summary>
        /// Obtener entidad con predicado
        /// </summary>
        /// <param name="predicate">filtros para la búsqueda</param>
        /// <returns>Devuelve la entidad.</returns>
        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().SingleOrDefault(predicate);
        }

        /// <summary>
        /// Obtener  entidad con predicado
        /// </summary>
        /// <param name="predicate">filtros para la búsqueda</param>
        /// <returns>Devuelve el primere registro la entidad.</returns>
        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().FirstOrDefault(predicate);
        }

        /// <summary>
        /// Obtener  entidad por identificador
        /// </summary>
        /// <param name="id">identificador para la búsqueda</param>
        /// <returns>Devuelve el registro de la entidad.</returns>
        public TEntity Get(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        /// <summary>
        /// Obtener  entidad 
        /// </summary>
        /// <returns>Devuelve la listra de registros de la entidad.</returns>
        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }

        /// <summary>
        /// Método para eliminar una entidad
        /// </summary>
        /// <param name="entity">Entidad eliminada</param>
        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        /// <summary>
        /// Método para eliminar una lista de entidades
        /// </summary>
        /// <param name="entities">lista de entidades eliminadas</param>
        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
        }

    }
}
