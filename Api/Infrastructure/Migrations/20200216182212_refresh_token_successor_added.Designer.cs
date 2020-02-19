﻿// <auto-generated />
using System;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(DefaultContext))]
    [Migration("20200216182212_refresh_token_successor_added")]
    partial class refresh_token_successor_added
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Core.Entities.AdditionalServiceEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("Hotel")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("Hotel");

                    b.ToTable("AdditionalService");
                });

            modelBuilder.Entity("Core.Entities.BookingEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("From")
                        .HasColumnType("date");

                    b.Property<int>("Room")
                        .HasColumnType("int");

                    b.Property<DateTime>("To")
                        .HasColumnType("date");

                    b.Property<int>("User")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Room");

                    b.HasIndex("User");

                    b.ToTable("Booking");
                });

            modelBuilder.Entity("Core.Entities.BookingServiceEntity", b =>
                {
                    b.Property<int>("Booking")
                        .HasColumnType("int");

                    b.Property<int>("Service")
                        .HasColumnType("int");

                    b.HasKey("Booking", "Service");

                    b.HasIndex("Service");

                    b.ToTable("Booking/Service");
                });

            modelBuilder.Entity("Core.Entities.HotelEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("Locality")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Picture")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("Stars")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Hotel");
                });

            modelBuilder.Entity("Core.Entities.RefreshTokenEntity", b =>
                {
                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("ExpiredTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Successor")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("User")
                        .HasColumnType("int");

                    b.Property<bool>("WasUsed")
                        .HasColumnType("bit");

                    b.HasKey("Value");

                    b.HasIndex("Successor")
                        .IsUnique()
                        .HasFilter("[Successor] IS NOT NULL");

                    b.HasIndex("User");

                    b.ToTable("RefreshToken");
                });

            modelBuilder.Entity("Core.Entities.RoomEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Type");

                    b.ToTable("Room");
                });

            modelBuilder.Entity("Core.Entities.RoomFeatureEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("RoomFeature");
                });

            modelBuilder.Entity("Core.Entities.RoomTypeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AdultPlaces")
                        .HasColumnType("int");

                    b.Property<string>("BedsDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("ChildPlaces")
                        .HasColumnType("int");

                    b.Property<int>("Hotel")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.HasIndex("Hotel");

                    b.ToTable("RoomType");
                });

            modelBuilder.Entity("Core.Entities.RoomTypeRoomFeatureEntity", b =>
                {
                    b.Property<int>("Feature")
                        .HasColumnType("int");

                    b.Property<int>("RoomType")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Feature", "RoomType");

                    b.HasIndex("RoomType");

                    b.ToTable("RoomType/RoomFeature");
                });

            modelBuilder.Entity("Core.Entities.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<DateTime>("RegistrationTime")
                        .HasColumnType("datetime");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Core.Entities.AdditionalServiceEntity", b =>
                {
                    b.HasOne("Core.Entities.HotelEntity", "HotelNavigation")
                        .WithMany("AdditionalServices")
                        .HasForeignKey("Hotel")
                        .HasConstraintName("FK_AdditionalService_Hotel")
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Entities.BookingEntity", b =>
                {
                    b.HasOne("Core.Entities.RoomEntity", "RoomNavigation")
                        .WithMany("Bookings")
                        .HasForeignKey("Room")
                        .HasConstraintName("FK_Booking_Room")
                        .IsRequired();

                    b.HasOne("Core.Entities.UserEntity", "UserNavigation")
                        .WithMany("Bookings")
                        .HasForeignKey("User")
                        .HasConstraintName("FK_Booking_User")
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Entities.BookingServiceEntity", b =>
                {
                    b.HasOne("Core.Entities.BookingEntity", "BookingNavigation")
                        .WithMany("BookingServices")
                        .HasForeignKey("Booking")
                        .HasConstraintName("FK_Booking/Service_Booking")
                        .IsRequired();

                    b.HasOne("Core.Entities.AdditionalServiceEntity", "ServiceNavigation")
                        .WithMany("BookingServices")
                        .HasForeignKey("Service")
                        .HasConstraintName("FK_Booking/Service_AdditionalService")
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Entities.RefreshTokenEntity", b =>
                {
                    b.HasOne("Core.Entities.RefreshTokenEntity", "SuccessorNavigation")
                        .WithOne("PrecursorNavigation")
                        .HasForeignKey("Core.Entities.RefreshTokenEntity", "Successor")
                        .HasConstraintName("FK_RefreshToken_RefreshToken");

                    b.HasOne("Core.Entities.UserEntity", "UserNavigation")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("User")
                        .HasConstraintName("FK_RefreshToken_User")
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Entities.RoomEntity", b =>
                {
                    b.HasOne("Core.Entities.RoomTypeEntity", "TypeNavigation")
                        .WithMany("Rooms")
                        .HasForeignKey("Type")
                        .HasConstraintName("FK_Room_RoomType")
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Entities.RoomTypeEntity", b =>
                {
                    b.HasOne("Core.Entities.HotelEntity", "HotelNavigation")
                        .WithMany("RoomTypes")
                        .HasForeignKey("Hotel")
                        .HasConstraintName("FK_RoomType_Hotel")
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Entities.RoomTypeRoomFeatureEntity", b =>
                {
                    b.HasOne("Core.Entities.RoomFeatureEntity", "FeatureNavigation")
                        .WithMany("RoomTypeRoomFeatures")
                        .HasForeignKey("Feature")
                        .HasConstraintName("FK_RoomType/RoomFeature_RoomFeature")
                        .IsRequired();

                    b.HasOne("Core.Entities.RoomTypeEntity", "RoomTypeNavigation")
                        .WithMany("RoomTypeRoomFeatures")
                        .HasForeignKey("RoomType")
                        .HasConstraintName("FK_RoomType/RoomFeature_RoomType")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}