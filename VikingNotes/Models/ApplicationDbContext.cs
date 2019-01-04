using System;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace VikingNotes.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Quiz> Guizzes { get; set; } // step 3c
        public DbSet<Genre> Genres { get; set; } // step 4
        public DbSet<Rating> Ratings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Ignore<IdentityUserLogin>();
            //modelBuilder.Ignore<IdentityUserRole>();
            //modelBuilder.Ignore<IdentityUserClaim>();

            modelBuilder.Entity<ApplicationUser>().ToTable("AspNetUsers");
        
            modelBuilder.Entity<Rating>()
                .HasRequired(e => e.User) 
                .WithMany(e => e.Ratings)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Rating>()
                .HasRequired(e => e.Quiz)
                .WithMany(e => e.Ratings)
                .WillCascadeOnDelete(true);

            base.OnModelCreating(modelBuilder);
        }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}