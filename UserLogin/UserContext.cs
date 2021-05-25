using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace UserLogin
{
    public class UserContext : DbContext
    {
        // public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Log> Logs { get; set; }

        public UserContext() : base(Properties.Settings.Default.DbConnect) {}
    }
}
