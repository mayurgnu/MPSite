using DomainModels.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace ApplicationCore
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public DbSet<User> AspNetUsers { get; set; }
        public DbSet<Role> AspNetRoles { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Product> Products { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("data source=DESKTOP-4VG8BV2\\SQLEXPRESS; initial catalog=ASPNETCoreSite;Integrated Security=true");
        //    base.OnConfiguring(optionsBuilder);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasOne(o => o.User).WithMany(u => u.Orders).HasForeignKey(o => o.UserId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Cart>().HasOne(c => c.User).WithMany().HasForeignKey(c => c.UserId).OnDelete(DeleteBehavior.Restrict);

            // Customize the ASP.NET Identity model and override the defaults if needed.
            modelBuilder.Entity<IdentityUserRole<int>>(i =>
            {
                i.HasKey(x => new { x.RoleId, x.UserId });
                i.ToTable("AspNetUserRoles");
            });
            modelBuilder.Entity<IdentityUserLogin<int>>(i =>
            {
                i.HasKey(x => new { x.ProviderKey, x.LoginProvider });
                i.ToTable("AspNetUserLogins");
            });
            modelBuilder.Entity<IdentityRoleClaim<int>>(i =>
            {
                i.HasKey(x => x.Id);
                i.ToTable("AspNetRoleClaims");
            });
            modelBuilder.Entity<IdentityUserClaim<int>>(i =>
            {
                i.HasKey(x => x.Id);
                i.ToTable("AspNetUserClaims");
            });
            modelBuilder.Entity<IdentityUserToken<int>>(i =>
            {
                i.HasKey(x => x.UserId);
                i.ToTable("AspNetUserToken");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
