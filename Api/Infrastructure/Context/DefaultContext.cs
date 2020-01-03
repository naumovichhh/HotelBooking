using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public partial class DefaultContext : DbContext
    {
        public DefaultContext()
        {
        }

        public DefaultContext(DbContextOptions<DefaultContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdditionalServiceEntity> AdditionalService { get; set; }
        public virtual DbSet<BookingEntity> Booking { get; set; }
        public virtual DbSet<BookingServiceEntity> BookingService { get; set; }
        public virtual DbSet<HotelEntity> Hotel { get; set; }
        public virtual DbSet<RoomEntity> Room { get; set; }
        public virtual DbSet<RoomFeatureEntity> RoomFeature { get; set; }
        public virtual DbSet<RoomTypeEntity> RoomType { get; set; }
        public virtual DbSet<RoomTypeRoomFeatureEntity> RoomTypeRoomFeature { get; set; }
        public virtual DbSet<UserEntity> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdditionalServiceEntity>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.HotelNavigation)
                    .WithMany(p => p.AdditionalServices)
                    .HasForeignKey(d => d.Hotel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AdditionalService_Hotel");
            });

            modelBuilder.Entity<BookingEntity>(entity =>
            {
                entity.Property(e => e.From).HasColumnType("date");

                entity.Property(e => e.To).HasColumnType("date");

                entity.Property(e => e.User)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.HasOne(d => d.RoomNavigation)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.Room)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_Room");

                entity.HasOne(d => d.UserNavigation)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.User)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_User");
            });

            modelBuilder.Entity<BookingServiceEntity>(entity =>
            {
                entity.HasKey(e => new { e.Booking, e.Service });

                entity.ToTable("Booking/Service");

                entity.HasOne(d => d.BookingNavigation)
                    .WithMany(p => p.BookingServices)
                    .HasForeignKey(d => d.Booking)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking/Service_Booking");

                entity.HasOne(d => d.ServiceNavigation)
                    .WithMany(p => p.BookingServices)
                    .HasForeignKey(d => d.Service)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking/Service_AdditionalService");
            });

            modelBuilder.Entity<HotelEntity>(entity =>
            {
                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Locality)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Picture)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<RoomEntity>(entity =>
            {
                entity.HasOne(d => d.TypeNavigation)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.Type)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Room_RoomType");
            });

            modelBuilder.Entity<RoomFeatureEntity>(entity =>
            {
                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<RoomTypeEntity>(entity =>
            {
                entity.Property(e => e.BedsDescription)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.HasOne(d => d.HotelNavigation)
                    .WithMany(p => p.RoomTypes)
                    .HasForeignKey(d => d.Hotel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoomType_Hotel");
            });

            modelBuilder.Entity<RoomTypeRoomFeatureEntity>(entity =>
            {
                entity.HasKey(e => new { e.Feature, e.RoomType });

                entity.ToTable("RoomType/RoomFeature");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.FeatureNavigation)
                    .WithMany(p => p.RoomTypeRoomFeatures)
                    .HasForeignKey(d => d.Feature)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoomType/RoomFeature_RoomFeature");

                entity.HasOne(d => d.RoomTypeNavigation)
                    .WithMany(p => p.RoomTypeRoomFeatures)
                    .HasForeignKey(d => d.RoomType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoomType/RoomFeature_RoomType");
            });

            modelBuilder.Entity<UserEntity>(entity =>
            {
                entity.HasKey(e => e.Name);

                entity.Property(e => e.Name).HasMaxLength(30);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.RegistrationTime).HasColumnType("datetime");

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}