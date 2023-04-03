using CustomerTrainingApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CustomerTrainingApp.Data.Data
{
    public class CustomerTrainingDataContext : DbContext
    {
        public CustomerTrainingDataContext(DbContextOptions<CustomerTrainingDataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public DbSet<Employee>? Employees { get; set; }
        public DbSet<Request>? Requests { get; set; }
    }
}
