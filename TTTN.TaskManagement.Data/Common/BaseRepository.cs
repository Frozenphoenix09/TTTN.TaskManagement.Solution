﻿using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TTTN.TaskManagement.Data.Entities;

namespace TTTN.TaskManagement.Data.Common
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        public DbSet<T> Dbset;
        private readonly TTTNTaskManagementDbcontext _dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        public BaseRepository(TTTNTaskManagementDbcontext context)
        {
            _dbContext = context;
            Dbset = context.Set<T>();
        }

        /// <summary>
        /// Function use to get Object flow Id
        /// </summary>
        /// <param name="id">Primary key of Table current</param>
        /// <returns></returns>
        public T GetById(int id)
        {
            return Dbset.Find(id);
        }

        /// <summary>
        /// Function use to get Object flow Id
        /// </summary>
        /// <param name="id">Primary key of Table current</param>
        /// <returns></returns>
        public T GetById(long id)
        {
            return Dbset.Find(id);
        }

        /// <summary>
        /// Get All list Object
        /// </summary>
        /// <returns></returns>
        public List<T> GetAll()
        {
            return Dbset.ToList();
        }

        /// <summary>
        /// Function use to Execute SQL Command Line
        /// </summary>
        /// <typeparam name="TEntity">Object is target</typeparam>
        /// <param name="sql"></param>
        /// <returns></returns>

        /// <summary>
        /// Function use in the case Query have condition
        /// </summary>
        /// <param name="filter">Condition of query</param>
        /// <returns></returns>
        public IQueryable<T> Query(Expression<Func<T, bool>> filter)
        {
            return Dbset.Where(filter);
        }

        /// <summary>
        /// Function use to Update Object
        /// </summary>
        /// <param name="entity">Object is targer Update</param>
        /// <returns></returns>
        public T Update(T entity)
        {
            var dbEntityEntry = _dbContext.Entry(entity);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                Dbset.Attach(entity);
            }
            dbEntityEntry.State = EntityState.Modified;
            return entity;
        }

        /// <summary>
        /// Function use to Insert Object
        /// </summary>
        /// <param name="entity">Object is targer Update</param>
        /// <returns></returns>
        public async Task<T> Insert(T entity)
        {
            await Dbset.AddAsync(entity);
            return entity;
        }

        public List<T> InsertMulti(List<T> entity)
        {
            foreach (var item in entity)
            {
                Dbset.Add(item);
            }
            return entity;
        }

        /// <summary>
        /// Function use to Remove Object in Database
        /// </summary>
        /// <param name="entity">Object is targer Update</param>
        /// <returns></returns>
        public bool Delete(T entity)
        {
            try
            {
                var entry = _dbContext.Entry(entity);
                entry.State = EntityState.Deleted;
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public virtual bool Delete(dynamic id)
        {
            var entity = GetById(id);
            if (entity == null)
            {
                return false;
            }

            Delete(entity);
            return true;
        }

        public bool DeleteMulti(List<T> entity)
        {
            try
            {
                foreach (var item in entity)
                {
                    Delete(item);
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public T Find(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes)
        {
            var query = Dbset.AsQueryable();
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            query = query.Where(expression);
            return query.FirstOrDefault();
        }

        public List<T> FindAll(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes)
        {
            var query = Dbset.AsQueryable();
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            if (expression != null)
            {
                query = query.Where(expression);
            }
            return query.ToList();
        }
    }
}