using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Security;

namespace Product.API.Models
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }

        public DbSet<Products> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RolePermission>()
                .HasKey(rp => new { rp.RoleId, rp.PermissionId });

            modelBuilder.Entity<RolePermission>()
                .HasOne(rp => rp.Role)
                .WithMany(r => r.RolePermissions)
                .HasForeignKey(rp => rp.RoleId);

            modelBuilder.Entity<RolePermission>()
                .HasOne(rp => rp.Permission)
                .WithMany(p => p.RolePermissions)
                .HasForeignKey(rp => rp.PermissionId);
        }

    }


    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Location { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PictureUrl { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
    }

    public class AppRole : IdentityRole
    {
        public bool IsDeleted { get; set; } = false;
        public ICollection<RolePermission> RolePermissions { get; set; }
    }

    public class Permission
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; } = false;
        public ICollection<RolePermission> RolePermissions { get; set; }
    }

    public class RolePermission
    {
        public string RoleId { get; set; }
        public AppRole Role { get; set; }

        public string PermissionId { get; set; }
        public Permission Permission { get; set; }
    }

    public class Products
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public DateTime ProductExpiry { get; set; }
        public int ProductPrice { get; set; }
        public string Company { get; set; }
        public int ProductTypeId { get; set; }
        public bool IsDeleted { get; set; } = false;
        [ForeignKey("ProductTypeId")]
        public virtual ProductType Types { get; set; }
    }

    public class ProductType
    {
        [Key]
        public int ProductTypeId { get; set; }
        public string ProductTypeName { get; set; }
        public bool IsDeleted { get; set; } = false;
    }

}
