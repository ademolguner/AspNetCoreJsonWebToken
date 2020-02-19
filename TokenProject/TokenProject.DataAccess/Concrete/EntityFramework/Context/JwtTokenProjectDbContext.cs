using Microsoft.EntityFrameworkCore;
using TokenProject.Core.Entities.Concrete;

namespace TokenProject.DataAccess.Concrete.EntityFramework.Context
{
    public class JwtTokenProjectDbContext : DbContext
    {
        public JwtTokenProjectDbContext()
        {
        }

        public JwtTokenProjectDbContext(DbContextOptions<JwtTokenProjectDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=JsonWebToken;Trusted_Connection=true");
        }

        public DbSet<OperationClaim> OperationClaim { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaim { get; set; }
    }
}