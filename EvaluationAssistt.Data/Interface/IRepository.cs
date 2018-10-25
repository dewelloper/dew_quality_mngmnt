using EvaluationAssistt.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EvaluationAssistt.Data.Interface
{
    public interface IRepository<T>
        where T: class, IEntity
    {
        IQueryable<T> All(bool isDeleted = false);

        IQueryable<T> All(params string[] join_tables);

        T FindById(int id, bool isDeleted = false);

        T FindById(int id, params string[] join_tables);

        T FindSingle(Expression<Func<T, bool>> query, bool isDeleted = false);

        T FindSingle(Expression<Func<T, bool>> query, params string[] join_tables);

        IQueryable<T> Find(Expression<Func<T, bool>> query, bool isDeleted = false);

        IQueryable<T> Find(Expression<Func<T, bool>> query, params string[] join_tables);

        void Insert(T entity);

        void Delete(T entity, bool enforceDelete = false);

        void DeleteChildCollection(IQueryable<T> collection);

        void DeleteChildCollection(ICollection<T> collection);
    }
}
