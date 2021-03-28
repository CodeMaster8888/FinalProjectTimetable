using Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Context
{
    public interface IUserContext
    {
        void CreateUser(User user);
        User GetUsername(string username);
    }
}
