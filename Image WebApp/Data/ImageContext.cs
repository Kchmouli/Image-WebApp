using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Image_WebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace Image_WebApp.Data
{
    public class ImageContext : DbContext
    {
        public ImageContext(DbContextOptions<ImageContext> options) : base(options)
        {
        }
        public DbSet<ImageUrl> ImageUrls { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ImageUrl>().ToTable("ImageUrl");
        }
    }
}
