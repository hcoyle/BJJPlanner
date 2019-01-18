using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using VaceProject.Models;

namespace VaceProject.DAL
{
    public class VaceContext : IdentityDbContext<ApplicationUser>
    {
        
        public VaceContext() : base("VaceContext")
        {
            
        }

        public static VaceContext Create()
        {
            return new VaceContext();
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUser>()
                .ToTable("dbo.AspNetUsers");
            modelBuilder.Entity<ApplicationUser>()
                      .ToTable("dbo.AspNetUsers");

            modelBuilder.Entity<IdentityRole>()
                     .ToTable("dbo.AspNetRoles");
     
            modelBuilder.Entity<IdentityUserClaim>().ToTable("dbo.AspNetUserClaims");

            modelBuilder.Entity<IdentityUserRole>().ToTable("dbo.AspNetUserRoles");
            modelBuilder.Entity<IdentityUserRole>().HasKey((IdentityUserRole r) => new { UserId = r.UserId, RoleId = r.RoleId }).ToTable("dbo.AspNetUserRoles");

            modelBuilder.Entity<IdentityUserLogin>().ToTable("dbo.AspNetUserLogins");

        }

        
    }
}