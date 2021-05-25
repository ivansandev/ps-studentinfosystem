using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using UserLogin;

namespace StudentInfoSystem.Model
{
    public class StudentInfoContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Log> Logs { get; set; }

        public StudentInfoContext() : base(Properties.Settings.Default.DbConnect) {}
    }
}
