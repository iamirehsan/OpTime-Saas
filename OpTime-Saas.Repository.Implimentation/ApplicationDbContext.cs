using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OpTime_Saas.Domain.Entities;

namespace OpTime_Saas.Repository.Implimentation
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<UserCredit> userCredits{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserCredit>()
                .HasOne(u => u.User)
                .WithOne(p => p.UserCredit)
                .HasForeignKey<User>(p => p.Id);
        }
    }
}
