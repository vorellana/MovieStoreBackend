#nullable disable
using Microsoft.EntityFrameworkCore;
using MovieStoreBackend.Entities;

namespace MovieStoreBackend.DataAccess.EFCore
{
    public class MovieStoreDataContext: DbContext
    {

        public MovieStoreDataContext(DbContextOptions<MovieStoreDataContext> options)
            : base(options)
        {
        }

        public DbSet<MovieCategory> MovieCategory { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<DiskType> DiskType { get; set; }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<Sale> Sale { get; set; }
        public DbSet<Disk> Disk { get; set; }
        public DbSet<SaleDetail> SaleDetail { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieCategory>().Property(b => b.CreatedAt).HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Customer>().Property(b => b.CreatedAt).HasDefaultValueSql("getdate()");
            modelBuilder.Entity<DiskType>().Property(b => b.CreatedAt).HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Movie>().Property(b => b.CreatedAt).HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Sale>().Property(b => b.CreatedAt).HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Disk>().Property(b => b.CreatedAt).HasDefaultValueSql("getdate()");
            modelBuilder.Entity<SaleDetail>().Property(b => b.CreatedAt).HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Movie>().HasOne(d => d.MovieCategory).WithMany(i => i.Movies);
            modelBuilder.Entity<Sale>().HasOne(d => d.Customer).WithMany(i => i.Sales);
            modelBuilder.Entity<Disk>().HasOne(d => d.DiskType).WithMany(i => i.Disks);
            modelBuilder.Entity<Disk>().HasOne(d => d.Movie).WithMany(i => i.Disks);
            modelBuilder.Entity<SaleDetail>().HasOne(d => d.Disk).WithMany(i => i.SalesDetails);
            modelBuilder.Entity<SaleDetail>().HasOne(d => d.Sale).WithMany(i => i.SalesDetails);
        }
    }
}
