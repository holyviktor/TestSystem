using Microsoft.EntityFrameworkCore;
using TestSystem.Core.Entities;

namespace TestSystem.Infrastructure.Data
{
    public class TestSystemDbContext : DbContext
    {
        public TestSystemDbContext(DbContextOptions options) : base(options) { }
        public TestSystemDbContext() { }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TestSystemDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

    }
}
