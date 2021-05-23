using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace SSTFU_V2.Models
{
    public class EFDBContext:DbContext
    {
        public DbSet<EUser> Users { get; set; }
        public DbSet<ESportObject> SportObjects { get; set; }
        public DbSet<ERentPlace> RentPlaces { get; set; }
        public DbSet<ESportInventory> SportInventorry { get; set; }
        public DbSet<ESportInventoryType> SportInventoryTypes { get; set; }
        public DbSet<EObjectCategory> ObjectCategories { get; set; }


        public EFDBContext(DbContextOptions<EFDBContext> options):base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<EUser>().HasKey(p=>p.Token);
        }
    }
}
