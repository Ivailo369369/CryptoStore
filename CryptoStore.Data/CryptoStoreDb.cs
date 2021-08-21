namespace CryptoStore.Data
{
    using CryptoStore.Data.Models;
    using CryptoStore.Data.Models.Base;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class CryptoStoreDb : IdentityDbContext<User>
    {
        public CryptoStoreDb(DbContextOptions<CryptoStoreDb> options) 
            :base(options)
        {

        }

        public DbSet<Service> Services { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<Newsletter> Newsletters { get; set; }

        public DbSet<Notification> Notifications { get; set; }

        public DbSet<Partner> Partners { get; set; } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)  
            {
                optionsBuilder.UseSqlServer(ConfigurationData.ConnectionString);
            }
            base.OnConfiguring(optionsBuilder);
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            this.ApplyAuditInformation();

            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            this.ApplyAuditInformation();

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder) => base.OnModelCreating(builder);

        private void ApplyAuditInformation() 
          =>  this.ChangeTracker
               .Entries()
               .Select(entry => new
               {
                   entry.Entity,
                   entry.State
               })
               .ToList()
               .ForEach(entry =>
               {
                   if (entry.Entity is IDeletableEntity deletableEntity)
                   {
                       if (entry.State == EntityState.Deleted)
                       {
                           deletableEntity.DeletedOn = DateTime.UtcNow;
                           deletableEntity.IsDeleted = true;
                       }      
                   }

                   if (entry.Entity is IEntity entity)
                   {
                       if (entry.State is EntityState.Added)
                       {
                           entity.CreatedOn = DateTime.UtcNow; 
                       }
                       else if (entry.State is EntityState.Modified) 
                       {
                           entity.ModifiedOn = DateTime.UtcNow;
                       }
                   }
               });      

    }
}
