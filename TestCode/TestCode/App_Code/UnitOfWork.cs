using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UnitOfWork
/// </summary>
public class UnitOfWork : IUnitOfWork
{
    public UnitOfWork()
    {
        this._dbContext = new TestCode();
    }
    private TestCode _dbContext;

    private Repository<tbl_Users> _tbl_User;


    public Repository<tbl_Users> tbl_User
    {
        get { return this._tbl_User ?? (this._tbl_User = new Repository<tbl_Users>(this._dbContext)); }
    }

    public void Commit()
    {
        this._dbContext.SaveChanges();
    }
    public void Dispose()
    {
        this._dbContext.Dispose();
    }
}