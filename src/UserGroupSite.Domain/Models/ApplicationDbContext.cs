using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace UserGroupSite.Domain.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<Location> Locations { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventSpeaker>().HasKey(es => new { es.EventId, es.SpeakerId });

            modelBuilder.Entity<EventSpeaker>()
                .HasOne(es => es.Speaker)
                .WithMany(s => s.SpeakerEvents)
                .HasForeignKey(se => se.SpeakerId);

            modelBuilder.Entity<EventSpeaker>()
                .HasOne(es => es.Event)
                .WithMany(e => e.EventSpeakers)
                .HasForeignKey(es => es.EventId);
        }
    }
}
