using Data;
using Microsoft.EntityFrameworkCore;

namespace Database.Context
{
    public class TimetableContext : DbContext
    {
        public TimetableContext(DbContextOptions options)
          : base(options)
        { }

        public TimetableContext()
        { }

        public virtual DbSet<User> Users { get; set; }
    }
}
