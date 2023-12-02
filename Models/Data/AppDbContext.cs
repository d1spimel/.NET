using Microsoft.EntityFrameworkCore;
using WebApplication8.Models;

namespace WebApplication8.Models.Data
{
    public class CompanyContext : DbContext
    {
        public DbSet<Company>? Companies { get; set; }

        public CompanyContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Companies;Trusted_Connection=True;");
        }
    }

    public class UserContext : DbContext
    {
        public DbSet<User>? Users { get; set; }

        public UserContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Users;Trusted_Connection=True;");
        }
    }

    public class AppDbContext : DbContext
    {
        public DbSet<Company>? Companies { get; set; }
        public DbSet<User>? Users { get; set; }

        public AppDbContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Specify the database name in the connection string
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=YourDatabaseName;Trusted_Connection=True;");
        }
    }
}
