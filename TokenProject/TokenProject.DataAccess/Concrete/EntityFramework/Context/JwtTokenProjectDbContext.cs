using Microsoft.EntityFrameworkCore;
using TokenProject.Core.Entites.Concrete;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class JwtTokenProjectDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=JsonWebToken;Trusted_Connection=true");
        }

        
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

    }
}
