using System;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Assignment.Data.Contracts;
using Assignment.Data.Repositories;

namespace Assignment.Database.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected UnitOfWork uow;

        /// <summary>
        /// We will use UnitOfWork classs to force it to be used so various types can be managed by same context
        /// </summary>
        /// <typeparam>
        /// <name>UnitOfWork</name>
        /// </typeparam>
        /// <param name="uow"></param>
        protected Repository(IUnitOfWork uow)
        {
            this.uow = uow as UnitOfWork;
        }
        public virtual void Add(T entity)
        {
            var entry = this.uow.AppDBContext.Entry(entity);
            this.uow.AppDBContext.Set<T>().Attach(entity);
            entry.State = EntityState.Added;
            this.uow.AppDBContext.SaveChanges();
            //this.uow.Commit();
        }
        public virtual async Task<int> AddRange(List<T> entity)
        {
            //uow.MatContext.AddRange(entity);            
            this.uow.AppDBContext.Set<T>().AttachRange(entity);
            //EntityState.Added;
            var result = await this.uow.AppDBContext.SaveChangesAsync();
            this.uow.Commit();
            return result;
        }

        public virtual void Delete(T entity)
        {
            var entry = this.uow.AppDBContext.Entry(entity);
            entry.State = EntityState.Deleted;
            this.uow.AppDBContext.Set<T>().Remove(entity);
        }

        public virtual T GetById(object id)
        {
            return this.uow.AppDBContext.Set<T>().Find(id);
        }

        public virtual T GetByRfid(Func<T, bool> where)
        {
            return this.uow.AppDBContext.Set<T>().Where(where).FirstOrDefault();
        }

        public virtual IQueryable<T> GetAll()
        {
            return this.uow.AppDBContext.Set<T>();
        }

        public virtual IQueryable<T> Query(Expression<Func<T, bool>> filter)
        {
            return this.uow.AppDBContext.Set<T>().Where(filter);
        }

        public virtual void Update(T entity)
        {
            var entry = this.uow.AppDBContext.Entry(entity);
            this.uow.AppDBContext.Set<T>().Attach(entity);
            entry.State = EntityState.Modified;
            this.uow.AppDBContext.SaveChanges();
        }

        public Task<int> AddRangeAsync(List<T> entity)
        {
            throw new NotImplementedException();
        }
    }
}