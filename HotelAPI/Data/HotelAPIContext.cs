using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HotelAPI.Models;

namespace HotelAPI.Data
{
    public class HotelAPIContext : DbContext
    {
        public HotelAPIContext(DbContextOptions<HotelAPIContext> options)
            : base(options)
        {
        }

        public DbSet<Booking> Booking { get; set; } = default!;
        public DbSet<Notification> Notification { get; set; } = default!;
        public DbSet<Review> Review { get; set; } = default!;
        public DbSet<Room> Room { get; set; } = default!;
        public DbSet<User> User { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Definirea relației dintre Notification și User
            modelBuilder.Entity<Notification>()
                .HasOne(n => n.User)
                .WithMany(u => u.Notifications)
                .HasForeignKey(n => n.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Definirea relației dintre Booking și User
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.User)
                .WithMany(u => u.Bookings)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Definirea relației dintre Booking și Room
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Room)
                .WithMany(r => r.Bookings)
                .HasForeignKey(b => b.RoomId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
