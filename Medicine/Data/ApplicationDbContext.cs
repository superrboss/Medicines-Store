using Medicine.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Medicine.Models;

namespace Medicine.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Category> Categories  { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>().Property(p => p.ProfilePicture).HasDefaultValue(null);
            builder.Entity<Category>().HasData(new Category[]
            {
                new Category{Id=1,Name="Drug"},
                new Category{Id=2,Name="Analgesics"},
                new Category{Id=3,Name="Antibiotics"},
                new Category{Id=4,Name="Inhalants"},
            });

        }

    }

}