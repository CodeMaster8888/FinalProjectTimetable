using Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface ILoginManager
    {
        User Authenticate(string username, string password);
        User Create(User user, string password);
    }
}
