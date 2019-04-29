using EventCatalogAPI.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogAPI.Data
{
    public class EventContext:DbContext
    { 
        public EventContext(DbContextOptions options)
            :base(options)
        {

        }
        public DbSet<EventItem> EventItems { get; set; }
        public DbSet<EventCategory> EventCategories { get; set; }
        public DbSet<EventLocation> EventLocations { get; set; }
        protected override void OnModelCreating
            (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventItem>(ConfigureEventItem);
            modelBuilder.Entity<EventLocation>(ConfigureEventLocation);
            modelBuilder.Entity<EventCategory>(ConfigureEventCategory);

        }

        private void ConfigureEventCategory
            (EntityTypeBuilder<EventCategory> builder)
        {
            builder.ToTable("EventCategories");
            builder.Property(c => c.Id)
               .IsRequired()
               .ForSqlServerUseSequenceHiLo("event_category_hilo");
            builder.Property(c => c.CategoryName)
                .IsRequired()
                .HasMaxLength(100);
        }

        private void ConfigureEventLocation(EntityTypeBuilder<EventLocation> builder)
        {
            builder.ToTable("EventLocations");
            builder.Property(c => c.Id)
               .IsRequired()
               .ForSqlServerUseSequenceHiLo("event_location_hilo");
            builder.Property(c => c.LocationName)
                .IsRequired()
                .HasMaxLength(100);
        }

        private void ConfigureEventItem(EntityTypeBuilder<EventItem> builder)
        {
            builder.ToTable("EventItems");
            builder.Property(c => c.Id)
               .IsRequired()
               .ForSqlServerUseSequenceHiLo("event_Item_hilo");
            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(c => c.EventDate)
                .IsRequired();
            builder.HasOne(c => c.EventCategory)
                .WithMany()
                .HasForeignKey(c => c.EventCategoryId);
            builder.HasOne(c => c.EventLocation)
               .WithMany()
               .HasForeignKey(c => c.EventLocationId);

        }
    }
}
