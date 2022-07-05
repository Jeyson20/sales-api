using Microsoft.EntityFrameworkCore;
using Sample.Application.Interfaces;
using Sample.Domain.Common;
using Sample.Domain.Entities;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Infraestructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IDateTimeService _dateTimeService;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IDateTimeService dateTimeService) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _dateTimeService = dateTimeService;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        //detecta los cambios al guardar y actualizar y modifica las fechas
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = _dateTimeService.NowUtc;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = _dateTimeService.NowUtc;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
