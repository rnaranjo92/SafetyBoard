using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SafetyBoard.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(255)]
        public string DriversLicense { get; set; }


        [Required]
        public bool AllowAccess { get; set; }

        public Organization Organization { get; set; }

        [Required]
        public int OrganizationId { get; set; }

        [Required]
        [StringLength(15)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(15)]
        public string LastName { get; set; }

        public ICollection<UserNotification> UserNotification { get; private set; }
        public ICollection<Inspection> Inspection { get; private set; }


        public ApplicationUser()
        {
            UserNotification = new Collection<UserNotification>();
            Inspection = new Collection<Inspection>();
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public void Notify(Notification notification)
        {
            UserNotification.Add(new UserNotification(this, notification));
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Posting> Postings { get; set; }
        public DbSet<PostingType> PostingTypes { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Inspection> Inspections { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<UserNotification> UserNotifications { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Inspection>()
                .HasRequired(i => i.InspectionType)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Inspection>()
                .HasRequired(i => i.Organization)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Posting>()
                .HasRequired(p => p.Organization)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserNotification>()
                .HasRequired(n => n.User)
                .WithMany(u=>u.UserNotification)
                .WillCascadeOnDelete(false);

            
        }
    }
}