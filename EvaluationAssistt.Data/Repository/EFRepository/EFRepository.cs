using EvaluationAssistt.Data.Interface;
using EvaluationAssistt.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace EvaluationAssistt.Data.Repository.EFRepository
{
    public class EFRepository<T> : IRepository<T>
        where T: class, IEntity
    {
        private DbSet<T> _dbSet;

        public EFRepository(EvaluationAssisttEntities context)
        {
            _dbSet = context.Set<T>();
        }

        public IQueryable<T> All(bool isDeleted = false)
        {
            return _dbSet.Where(x => x.IsDeleted == isDeleted).AsQueryable();
        }

        public IQueryable<T> All(params string[] join_tables)
        {
            if (join_tables.Length > 0)
            {
                DbQuery<T> _query = _dbSet;

                foreach (var tbl in join_tables)
                {
                    _query = _query.Include(tbl);
                }

                return _query.AsQueryable();
            }

            return _dbSet.AsQueryable();
        }

        public T FindById(int id, bool isDeleted = false)
        {
            return _dbSet.FirstOrDefault(x => x.Id == id && x.IsDeleted == isDeleted);
        }

        public T FindById(int id, params string[] join_tables)
        {
            if (join_tables.Length > 0)
            {
                DbQuery<T> _query = _dbSet;

                foreach (var tbl in join_tables)
                {
                    _query = _query.Include(tbl);
                }

                return _query.FirstOrDefault(x => x.Id == id);
            }

            return _dbSet.FirstOrDefault(x => x.Id == id);
        }

        public T FindSingle(Expression<Func<T, bool>> query, bool isDeleted = false)
        {
            return _dbSet.Where(query).FirstOrDefault(x => x.IsDeleted == isDeleted);
        }

        public T FindSingle(Expression<Func<T, bool>> query, params string[] join_tables)
        {
            if (join_tables.Length > 0)
            {
                DbQuery<T> _query = _dbSet;

                foreach (var tbl in join_tables)
                {
                    _query = _query.Include(tbl);
                }

                return _query.Where(query).FirstOrDefault();
            }

            return _dbSet.Where(query).FirstOrDefault();
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> query, bool isDeleted = false)
        {
            return _dbSet.Where(query).Where(x => x.IsDeleted == isDeleted).AsQueryable();
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> query,  params string[] join_tables)
        {
            if (join_tables.Length > 0)
            {
                var _query = join_tables.Aggregate<string, DbQuery<T>>(_dbSet, (current, table) => current.Include(table));

                return _query.Where(query).AsQueryable();
            }

            return _dbSet.Where(query).AsQueryable();
        }

        public void Insert(T entity)
        {
            entity.IsDeleted = false;

            _dbSet.Add(entity);
        }

        public void Delete(T entity, bool enforceDelete = false)
        {
            if (enforceDelete)
            {
                _dbSet.Remove(entity);
            }
            else
            {
                entity.IsDeleted = true;
            }
        }

        public void DeleteChildCollection(IQueryable<T> collection)
        {
            foreach (T item in collection)
            {
                _dbSet.Remove(item);
            }
        }

        public void DeleteChildCollection(ICollection<T> collection)
        {
            var list = collection.ToList();

            for (var i = 0; i < list.Count; i++)
            {
                _dbSet.Remove(list[i]);
            }
        }
    }
}
