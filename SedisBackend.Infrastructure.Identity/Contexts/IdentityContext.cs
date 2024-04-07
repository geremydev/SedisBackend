using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SedisBackend.Core.Domain.Health_Centers;
using SedisBackend.Infrastructure.Identity.Entities;
using SedisBackend.Infrastructure.Identity.Relation;


namespace SedisBackend.Infrastructure.Identity.Contexts
{
    public class IdentityContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options) { }

        public DbSet<UserEntityRelation> UserEntityRelation { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //FLUENT API

            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("Identity");

            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable(name: "Users");
            });

            modelBuilder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Roles");
            });

            modelBuilder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable(name: "UserRoles");
            });

            modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable(name: "UserLogins");
            });

            modelBuilder.Entity<UserEntityRelation>().ToTable("UserEntityRelation");

            modelBuilder.Entity<UserEntityRelation>()
            .HasKey(p => p.Id);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(k => k.AssignedUsers)
                .WithOne(k => k.User)
                .HasForeignKey(k => k.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
