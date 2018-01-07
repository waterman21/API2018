using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Runtime.Serialization;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MovieTimeWebAPI.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }

        [Required]
        [DataMember]
        [MaxLength(50)]
        public string Pseudo { get; set; }
        [Required]
        [DataMember]
        [MaxLength(50)]
        public string Prenom { get; set; }
        [Required]
        [DataMember]
        [MaxLength(50)]
        public string Nom { get; set; }

        public bool Type { get; set; }

        public IList<Listing> Visionnages { get; set; }

    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Categorie> Categorie { get; set; }
        public DbSet<Film> Film { get; set; }
        public DbSet<Listing> Listing { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>().Property(u => u.UserName).HasMaxLength(128);

            //Uncomment this to have Email length 128 too (not neccessary)
            //modelBuilder.Entity<ApplicationUser>().Property(u => u.Email).HasMaxLength(128);

            modelBuilder.Entity<IdentityRole>().Property(r => r.Name).HasMaxLength(128);
        }
    }
}