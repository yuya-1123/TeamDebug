using TeamD_Database.Entity;
using Microsoft.EntityFrameworkCore;

namespace TeamD_Database
{
    public class WebApplication1Context : DbContext
    {
        public WebApplication1Context(DbContextOptions<WebApplication1Context> options) : base(options) { }

        // エンティティ定義（作成したエンティティと名前が揃うように設定）
        public DbSet<User> User { get; set; }
        public DbSet<Device> Device { get; set; }
        public DbSet<Rental> Rental { get; set; }

        public DbSet<RentalsHistory> RentalsHistory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /* エンティティの追加設定など */
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasKey(u => u.EmployeeNo);

            modelBuilder.Entity<Device>()
                .HasKey(d => d.AssetsNo);

            modelBuilder.Entity<Rental>()
                .HasKey(r => r.AssetsNo);

            modelBuilder.Entity<RentalsHistory>()
                .HasKey(rh => rh.Id);
        }
    }
}
