using System.Collections.Immutable;
using Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Data.DBContext;

public class IsaDBContext : DbContext
{
    public IsaDBContext()
    {
        
    }

    public IsaDBContext(DbContextOptions<IsaDBContext> options) : base(options)
    {
        
    }
    
    public DbSet<Product> Products { get; set; }
    public DbSet<MaintenanceActivity> MaintenanceActivities { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            //Version of MySql and required data to connect to the database
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
            optionsBuilder.UseMySql("Server=127.0.0.1,3306;Uid=root;Pwd=Admin180403@.;Database=isa;",serverVersion);
        }
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Product>().ToTable("Products");
        builder.Entity<Product>().HasKey(p => p.id);
        builder.Entity<Product>().Property(p => p.id).ValueGeneratedOnAdd();
        builder.Entity<Product>().HasOne(p => p.activity).WithOne(m => m.product).HasForeignKey<MaintenanceActivity>(p => p.id);
        builder.Entity<Product>().Property(p => p.brand).IsRequired();
        builder.Entity<Product>().Property(p => p.model).IsRequired();
        builder.Entity<Product>().Property(p => p.serialNumber).IsRequired();
        builder.Entity<Product>().Property(p => p.status).IsRequired();
        builder.Entity<Product>().Ignore(p => p.statusDescription);

        builder.Entity<MaintenanceActivity>().ToTable("MaintenanceActivities");
        builder.Entity<MaintenanceActivity>().HasKey(p => p.id);
        builder.Entity<MaintenanceActivity>().Property(p => p.id).ValueGeneratedOnAdd();
        builder.Entity<MaintenanceActivity>().Property(p => p.productSerialNumber).IsRequired();
        builder.Entity<MaintenanceActivity>().Property(p => p.summary).IsRequired();
        builder.Entity<MaintenanceActivity>().Property(p => p.description);
        builder.Entity<MaintenanceActivity>().Property(p => p.activityResult).IsRequired();
    }
}