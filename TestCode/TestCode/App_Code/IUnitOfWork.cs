using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for IUnitOfWork
/// </summary>
public interface IUnitOfWork
{
    Repository<tbl_Users> tbl_User { get; }
    void Commit();
    void Dispose();
}