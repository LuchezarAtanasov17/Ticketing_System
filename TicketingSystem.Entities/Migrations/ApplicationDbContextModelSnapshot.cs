﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TicketingSystem.Entities.Data;

#nullable disable

namespace TicketingSystem.Entities.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("TicketingSystem.Entities.Models.Message", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(600)
                        .HasColumnType("nvarchar(600)");

                    b.Property<byte[]>("Files")
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime>("PublishedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<Guid?>("TicketId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("TicketId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("TicketingSystem.Entities.Models.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0c1b871b-4ed5-4299-aec4-d59054b07c54"),
                            Description = "Luchezar's project for SoftUni.",
                            Name = "LAAuto"
                        },
                        new
                        {
                            Id = new Guid("83da1e75-3b7d-4a37-a33d-ba8cf149acb8"),
                            Description = "Shows weather analysis.",
                            Name = "Weather forecasting system"
                        },
                        new
                        {
                            Id = new Guid("8c97398e-09d8-4823-a82d-343619758e81"),
                            Name = "Instagram"
                        });
                });

            modelBuilder.Entity("TicketingSystem.Entities.Models.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("7062d4a3-203f-4375-aaef-4918dcfcef04"),
                            ConcurrencyStamp = "bdea90a1-4ea6-4db7-acc6-c5dd6a18bb07",
                            Name = "User",
                            NormalizedName = "USER  "
                        },
                        new
                        {
                            Id = new Guid("6c508509-7dd9-44c3-9597-8c14c65e661b"),
                            ConcurrencyStamp = "b6d65614-7c33-46b0-aecc-ebe78d0f9d7d",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        },
                        new
                        {
                            Id = new Guid("0378ef66-3332-4860-ad38-773ed8c0594a"),
                            ConcurrencyStamp = "b832276f-ec40-4348-95c3-a49808529b84",
                            Name = "Maintenance",
                            NormalizedName = "MAINTENANCE"
                        });
                });

            modelBuilder.Entity("TicketingSystem.Entities.Models.Ticket", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<byte[]>("Files")
                        .HasColumnType("varbinary(max)");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("SenderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("SenderId");

                    b.ToTable("Tickets");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ad90a67e-02be-4f9a-9fa8-74d5abcc2b4b"),
                            Description = "The app doesn't recognize my identity, when I try to log in.",
                            ProjectId = new Guid("8c97398e-09d8-4823-a82d-343619758e81"),
                            ReleaseDate = new DateTime(2022, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SenderId = new Guid("62448744-4356-44dc-a005-0bfb6ba9e8b2"),
                            State = 0,
                            Title = "Login issue.",
                            Type = 0
                        },
                        new
                        {
                            Id = new Guid("543ff3e3-5ac4-45ca-8cd4-f8d942548c7e"),
                            Description = "I need help with finding my login activity.",
                            ProjectId = new Guid("8c97398e-09d8-4823-a82d-343619758e81"),
                            ReleaseDate = new DateTime(2023, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SenderId = new Guid("1456c79b-7080-4586-8467-900a3cb033fe"),
                            State = 1,
                            Title = "Help for account activity.",
                            Type = 2
                        },
                        new
                        {
                            Id = new Guid("d385bf53-6e41-4ea3-8c7f-729c6893466f"),
                            Description = "It would be nice, when deleting any kind of data, a window to pop up for reassurance of my action.",
                            ProjectId = new Guid("0c1b871b-4ed5-4299-aec4-d59054b07c54"),
                            ReleaseDate = new DateTime(2022, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SenderId = new Guid("1456c79b-7080-4586-8467-900a3cb033fe"),
                            State = 1,
                            Title = "A user-friendly request.",
                            Type = 1
                        });
                });

            modelBuilder.Entity("TicketingSystem.Entities.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("62448744-4356-44dc-a005-0bfb6ba9e8b2"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "7cc9c0a2-7761-4f28-ba4a-24e44fb244f7",
                            Email = "user@mail.com",
                            EmailConfirmed = false,
                            FirstName = "Ivan",
                            LastName = "Ivanov",
                            LockoutEnabled = false,
                            NormalizedEmail = "USER@MAIL.COM",
                            NormalizedUserName = "USER",
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            UserName = "User"
                        },
                        new
                        {
                            Id = new Guid("1456c79b-7080-4586-8467-900a3cb033fe"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "2819618b-e4f4-4e10-bb3a-0cc15fbf1f32",
                            Email = "user2@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Georgi",
                            LastName = "Georgiev",
                            LockoutEnabled = false,
                            NormalizedEmail = "USER2@GMAIL.COM",
                            NormalizedUserName = "USER2",
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            UserName = "User2"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("TicketingSystem.Entities.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("TicketingSystem.Entities.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("TicketingSystem.Entities.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("TicketingSystem.Entities.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TicketingSystem.Entities.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("TicketingSystem.Entities.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TicketingSystem.Entities.Models.Message", b =>
                {
                    b.HasOne("TicketingSystem.Entities.Models.User", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TicketingSystem.Entities.Models.Ticket", null)
                        .WithMany("Messages")
                        .HasForeignKey("TicketId");

                    b.Navigation("Author");
                });

            modelBuilder.Entity("TicketingSystem.Entities.Models.Ticket", b =>
                {
                    b.HasOne("TicketingSystem.Entities.Models.Project", "Project")
                        .WithMany("Tickets")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TicketingSystem.Entities.Models.User", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("TicketingSystem.Entities.Models.Project", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("TicketingSystem.Entities.Models.Ticket", b =>
                {
                    b.Navigation("Messages");
                });
#pragma warning restore 612, 618
        }
    }
}
