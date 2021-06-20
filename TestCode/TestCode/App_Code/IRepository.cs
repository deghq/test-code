using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

/// <summary>
/// Summary description for IRepository
/// </summary>
public interface IRepository<TEntity> where TEntity : class
{
    IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
                                            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderby = null,
                                            string includeProperties = "");
    TEntity GetById(object id);
    TEntity GetById(params object[] id);
    TEntity Insert(TEntity entity);
    void Delete(TEntity entity);
    void Update(TEntity entity);
    DbRawSqlQuery<TEntity> SQLQuery(string sql, params object[] parameters);
}