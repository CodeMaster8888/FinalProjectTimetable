using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Database.Context
{
    public class UserContext : IUserContext
    {
        private readonly TimetableContext _context;
        
        public UserContext(TimetableContext timetableContext)
        {
            _context = timetableContext ?? throw new ArgumentNullException(nameof(timetableContext));
        }

        public User GetUsername(string username)
        {
            var test = _context.Users.SingleOrDefault(x => x.Username == username);

            return test;
        }

        public void CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

    }
}
