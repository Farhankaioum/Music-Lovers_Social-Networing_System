using GigHub.Web.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GigHub.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Gig> Gigs { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Attendance> Attendances { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Many to Many relationship between Git to UserTable
            builder.Entity<Attendance>()
                .HasKey(k => new { k.GigId, k.AttendeeId});

            builder.Entity<Attendance>()
                .HasOne(g => g.Gig)
                .WithMany(a => a.Attendances)
                .HasForeignKey(a => a.GigId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Attendance>()
                .HasOne(a => a.Attendee)
                .WithMany(a => a.Attendances)
                .HasForeignKey(a => a.AttendeeId)
                .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(builder);
        }
    }
}
