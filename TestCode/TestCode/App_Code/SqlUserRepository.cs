using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class SqlUserRepository
{
    public SqlUserRepository()
    {
        this._UnitOfWork = new UnitOfWork();
    }

    private readonly IUnitOfWork _UnitOfWork;

    public int GenerateId()
    {
        return this._UnitOfWork.tbl_User.Get().Count() > 0 ? this._UnitOfWork.tbl_User.GenerateId(x => x.id) + 1 : 0;
    }

    public bool IsDuplicate(string email)
    {
        var duplicate = this._UnitOfWork.tbl_User.Get(x => x.Email.Equals(email)).Count();

        return (duplicate > 0);
    }


    public void Save(User user)
    {
        // TODO: Add save user to database
        // TODO: Make sure to encrpt the password

        try
        {
            string password = EnctyptDecrypt.Encrypt(user.Password);

            tbl_Users tblUsers = new tbl_Users();
            tblUsers.Email = user.Email;
            tblUsers.Password = password;
            tblUsers.Phone = user.Phone;

            if (user.Id == 0)
            {
                tblUsers.id = this.GenerateId();
                this._UnitOfWork.tbl_User.Insert(tblUsers);
            }
            else
            {
                tblUsers.id = user.Id;
                this._UnitOfWork.tbl_User.Insert(tblUsers);
            }

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            this._UnitOfWork.Dispose();
        }
    }

    public User ReadByEmailAndPassword(string email, string password)
    {
        // TODO: Add read by email and password from database

        User userModel = new User();
        try
        {
            string message = string.Empty;
            string passwordEncrypted = EnctyptDecrypt.Encrypt(password);
            userModel = this._UnitOfWork.tbl_User.Get(x => x.Email.Equals(email) 
                                                        && x.Password.Equals(passwordEncrypted))
                                           .Select(x=> new User()
                                            {
                                                Id = x.id,
                                                Email = x.Email,
                                                Password = x.Password
                                            })
                                          .FirstOrDefault();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            this._UnitOfWork.Dispose();
        }

        return userModel;
    }
}