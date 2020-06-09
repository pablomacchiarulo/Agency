using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Agence.AccesoDatos.Contratos
{
    public interface IRepositorio<TEntity> where TEntity : class
    {
        /// <summary>
        /// Obtener  entidad por identificador
        /// </summary>
        /// <param name="id">identificador para la búsqueda</param>
        /// <returns>Devuelve el registro de la entidad.</returns>
        TEntity Get(int id);

        /// <summary>
        /// Obtener  entidad 
        /// </summary>
        /// <returns>Devuelve la listra de registros de la entidad.</returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Obtener lista de entidades con predicado
        /// </summary>
        /// <param name="predicate">filtros para la búsqueda</param>
        /// <returns>Devuelve la lista de la entidad.</returns>
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Método para agregar una entidad
        /// </summary>
        /// <param name="entity">Entidad agreagda</param>
        void Add(TEntity entity);

        /// <summary>
        /// Método para eliminar una entidad
        /// </summary>
        /// <param name="entity">Entidad eliminada</param>
        void Remove(TEntity entity);

    }
}
