using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Assignment.Data.Contracts
{
  public  interface IRepository<T> where T:class
    {
        /// <summary>
            /// Adds the entity
            /// </summary>
            /// <param name="entity">
            /// T of entity
            /// </param>
            void Add(T entity);
            Task<int> AddRange(List<T> entity);

            /// <summary>
            /// Updates the entity
            /// </summary>
            /// <param name="entity">T of entity</param>
            void Update(T entity);

            /// <summary>
            /// Deletes the entity
            /// </summary>
            /// <param name="entity">T of entity</param>
            void Delete(T entity);

            /// <summary>
            /// Get the entity
            /// </summary>
            /// <param name="id">key of T</param>
            /// <returns>Type of T</returns>
            T GetById(object id);

            /// <summary>
            /// The get by RFID.
            /// </summary>
            /// <param name="where">
            /// The where.
            /// </param>
            /// <returns>Type of T</returns>
            T GetByRfid(Func<T, bool> where);

            /// <summary>
            /// Gets the list
            /// </summary>
            /// <returns>IEnumerable T</returns>
            IQueryable<T> GetAll();

            /// <summary>
            /// The get.
            /// </summary>
            /// <param name="filter">
            /// The filter.
            /// </param>
            /// <returns>
            /// The <see cref="T"/>.
            /// </returns>
            IQueryable<T> Query(Expression<Func<T, bool>> filter);
        }
}
