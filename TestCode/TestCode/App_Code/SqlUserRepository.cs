using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class SqlUserRepository
{
    public SqlUserRepository()
    {
    }

    public void Save(User user)
    {
        // TODO: Add save user to database
        // TODO: Make sure to encrpt the password
    }

    public User ReadByEmailAndPassword(string email, string password)
    {
        // TODO: Add read by email and password from database
        throw new NotImplementedException();
    }
}