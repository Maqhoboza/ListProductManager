using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ListProdManager.Models;

namespace ListProdManager.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ListProdManager.Models.Product> Product { get; set; }
        public DbSet<ListProdManager.Models.Category> Category { get; set; }
        public DbSet<ListProdManager.Models.MyFile> MyFile { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(b => b.ProductCode).HasComputedColumnSql("CONVERT(varchar, getdate(), 126) yyyy-mm-dd T hh:mm:ss:nnn + [ProductId]");
            base.OnModelCreating(modelBuilder);

         }
        }
}
