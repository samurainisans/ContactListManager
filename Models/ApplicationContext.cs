using Microsoft.EntityFrameworkCore;

namespace MVC_Web_App.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; } = null!;
        public DbSet<ContactGroup> ContactGroups { get; set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>()
                .HasOne(c => c.ContactGroup)
                .WithMany(g => g.Contacts)
                .HasForeignKey(c => c.ContactGroupId);
        }
            }
}
