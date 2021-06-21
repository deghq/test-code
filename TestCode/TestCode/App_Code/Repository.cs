using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

/// <summary>
/// Summary description for Repository
/// </summary>
public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    internal TestCode _dbContext;
    internal DbSet<TEntity> _dbSet;

    public Repository(TestCode dbContext)
    {
        this._dbContext = dbContext;
        //this._testApplication.Database.CommandTimeout = 30000;
        this._dbSet = dbContext.Set<TEntity>();
    }

    public virtual int GenerateId(Expression<Func<TEntity, int>> selector)
    {
        return this._dbContext.Set<TEntity>().Max(selector);
    }

    public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
                                            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderby = null,
                                            string includeProperties = "")
    {
        IQueryable<TEntity> query = this._dbSet;
        if (filter != null)
        {
            query = query.Where(filter);
        }

        foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        {
            query = query.Include(includeProperty);
        }

        if (orderby != null)
        {
            return orderby(query).ToList();
        }

        return query.ToList();
    }

    public virtual TEntity GetById(object id)
    {
        return this._dbSet.Find(id);
    }

    public virtual TEntity GetById(params object[] id)
    {
        return this._dbSet.Find(id);
    }

    public virtual TEntity Insert(TEntity entity)
    {
        try
        {
            this._dbSet.Add(entity);
            this._dbContext.SaveChanges();
            return entity;
        }
        catch (System.Data.Entity.Validation.DbEntityValidationException e)
        {
            foreach (var eve in e.EntityValidationErrors)
            {
                Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                    eve.Entry.Entity.GetType().Name, eve.Entry.State);

                foreach (var ve in eve.ValidationErrors)
                {
                    Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage);
                }
            }
            throw;
        }
    }

    public virtual void Delete(TEntity entity)
    {
        if (this._dbContext.Entry(entity).State == EntityState.Detached)
        {
            this._dbSet.Attach(entity);
        }

        this._dbSet.Remove(entity);
        this._dbContext.SaveChanges();
    }


    public virtual void DeleteById(object id)
    {
        var entity = this._dbSet.Find(id);
        this._dbSet.Remove(entity);
        this._dbContext.SaveChanges();
    }


    public virtual void Update(TEntity entity)
    {
        this._dbSet.Attach(entity);
        this._dbContext.Entry(entity).State = EntityState.Modified;
    }

    public DbRawSqlQuery<TEntity> SQLQuery(string sql, params object[] parameters)
    {
        return this._dbContext.Database.SqlQuery<TEntity>(sql, parameters);
    }
}