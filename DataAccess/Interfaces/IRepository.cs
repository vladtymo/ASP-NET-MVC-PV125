using Ardalis.Specification;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        //IEnumerable<TEntity> Get(
        //    Expression<Func<TEntity, bool>> filter = null,
        //    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        //    params string[] includeProperties);

        IEnumerable<TEntity> GetAll();

        TEntity? GetByID(object id);

        void Insert(TEntity entity);

        void Delete(object id);

        void Delete(TEntity entityToDelete);

        void Update(TEntity entityToUpdate);

        TEntity? GetItemBySpec(ISpecification<TEntity> specification);
        IEnumerable<TEntity> GetListBySpec(ISpecification<TEntity> specification);

        void Save();
    }
}
