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
        public DbSet<User> users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserCredit>()
                .HasOne(u => u.User)
                .WithOne(p => p.UserCredit)
                .HasForeignKey<User>(p => p.Id);

            modelBuilder.Entity<UserCredit>().Property(x => x.IsExpired).HasDefaultValue(false);
            modelBuilder.Entity<User>().Property(x => x.IsBanned).HasDefaultValue(false);

        }
    }
}
