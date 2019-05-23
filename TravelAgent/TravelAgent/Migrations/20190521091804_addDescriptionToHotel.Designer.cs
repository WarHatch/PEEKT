﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TravelAgent.Data;

namespace TravelAgent.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20190521091804_addDescriptionToHotel")]
    partial class addDescriptionToHotel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<int>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("TravelAgent.Data.Entities.Apartment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<int>("FitsPeople");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Apartments");
                });

            modelBuilder.Entity("TravelAgent.Data.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount");

                    b.Property<bool>("Available");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("ProfilePhoto");

                    b.Property<int?>("RegisteredOfficeId");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("RegisteredOfficeId");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("TravelAgent.Data.Entities.EmployeeTravel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ApartmentId");

                    b.Property<bool>("Confirm");

                    b.Property<int?>("EmployeeId");

                    b.Property<int?>("TravelId");

                    b.HasKey("Id");

                    b.HasIndex("ApartmentId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("TravelId");

                    b.ToTable("EmployeeTravel");
                });

            modelBuilder.Entity("TravelAgent.Data.Entities.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("Description");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<int?>("TravelId");

                    b.HasKey("Id");

                    b.HasIndex("TravelId");

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("TravelAgent.Data.Entities.Office", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<int>("OfficeApartmentId");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("OfficeApartmentId");

                    b.ToTable("Offices");
                });

            modelBuilder.Entity("TravelAgent.Data.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("TravelAgent.Data.Entities.Transport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<int?>("TravelId");

                    b.Property<string>("TypeOfTransport");

                    b.HasKey("Id");

                    b.HasIndex("TravelId");

                    b.ToTable("Transports");
                });

            modelBuilder.Entity("TravelAgent.Data.Entities.Travel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("EndTime");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int?>("OrganizedById");

                    b.Property<DateTime>("StartTime");

                    b.Property<int?>("TravelFromId");

                    b.Property<int?>("TravelToId");

                    b.HasKey("Id");

                    b.HasIndex("OrganizedById");

                    b.HasIndex("TravelFromId");

                    b.HasIndex("TravelToId");

                    b.ToTable("Travels");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("TravelAgent.Data.Entities.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("TravelAgent.Data.Entities.Employee")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("TravelAgent.Data.Entities.Employee")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("TravelAgent.Data.Entities.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TravelAgent.Data.Entities.Employee")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("TravelAgent.Data.Entities.Employee")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TravelAgent.Data.Entities.Employee", b =>
                {
                    b.HasOne("TravelAgent.Data.Entities.Office", "RegisteredOffice")
                        .WithMany()
                        .HasForeignKey("RegisteredOfficeId");
                });

            modelBuilder.Entity("TravelAgent.Data.Entities.EmployeeTravel", b =>
                {
                    b.HasOne("TravelAgent.Data.Entities.Apartment", "Apartment")
                        .WithMany()
                        .HasForeignKey("ApartmentId");

                    b.HasOne("TravelAgent.Data.Entities.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");

                    b.HasOne("TravelAgent.Data.Entities.Travel", "Travel")
                        .WithMany()
                        .HasForeignKey("TravelId");
                });

            modelBuilder.Entity("TravelAgent.Data.Entities.Hotel", b =>
                {
                    b.HasOne("TravelAgent.Data.Entities.Travel", "Travel")
                        .WithMany("Hotels")
                        .HasForeignKey("TravelId");
                });

            modelBuilder.Entity("TravelAgent.Data.Entities.Office", b =>
                {
                    b.HasOne("TravelAgent.Data.Entities.Apartment", "OfficeApartment")
                        .WithMany()
                        .HasForeignKey("OfficeApartmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TravelAgent.Data.Entities.Transport", b =>
                {
                    b.HasOne("TravelAgent.Data.Entities.Travel")
                        .WithMany("Transports")
                        .HasForeignKey("TravelId");
                });

            modelBuilder.Entity("TravelAgent.Data.Entities.Travel", b =>
                {
                    b.HasOne("TravelAgent.Data.Entities.Employee", "OrganizedBy")
                        .WithMany()
                        .HasForeignKey("OrganizedById");

                    b.HasOne("TravelAgent.Data.Entities.Office", "TravelFrom")
                        .WithMany()
                        .HasForeignKey("TravelFromId");

                    b.HasOne("TravelAgent.Data.Entities.Office", "TravelTo")
                        .WithMany()
                        .HasForeignKey("TravelToId");
                });
#pragma warning restore 612, 618
        }
    }
}
