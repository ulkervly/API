using Microsoft.EntityFrameworkCore;
using MyBiz.Configurations;
using MyBiz.Core.Models;




namespace MyBiz.Data.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)  
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EmployeeConfiguration).Assembly);
            base.OnModelCreating(modelBuilder);
        }

    }
}
