using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CET322_HW1.Models
{
    public class StudentContext : DbContext
{
        public StudentContext()
        {
        }

        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
    {
    }
    public DbSet<Student> Students { get; set; }

        internal object GetStudent()
        {
            throw new NotImplementedException();
        }
    }
}