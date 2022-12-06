using Common.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace IdentityService.DataAccess.Contexts
{
    public class IdentityServiceDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Data Source=DESKTOP-LES9OTM; Initial Catalog=MicroS_IdentityServiceDb; Trusted_Connection=true; MultipleActiveResultSets=true; TrustServerCertificate=True";
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString, opt =>
                {
                    opt.EnableRetryOnFailure();
                });
            }
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override int SaveChanges()
        {
            OnBeforeSave();
            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSave();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            OnBeforeSave();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            OnBeforeSave();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void OnBeforeSave()
        {
            var addedEntities = ChangeTracker.Entries()
                                    .Where(i => i.State == EntityState.Added)
                                    .Select(i => (BaseEntity)i.Entity);

            PrepareAddedEntities(addedEntities);
        }

        private void PrepareAddedEntities(IEnumerable<BaseEntity> entities)
        {
            foreach (var entity in entities)
            {
                if (entity.CreatedAt == DateTime.MinValue) entity.CreatedAt = DateTime.Now;
            }
        }
    }
}
