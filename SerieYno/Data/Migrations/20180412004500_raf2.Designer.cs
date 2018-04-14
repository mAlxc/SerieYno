﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using SerieYno.Data;
using System;

namespace SerieYno.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180412004500_raf2")]
    partial class raf2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("SerieYnoModels.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

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

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("SerieYnoModels.Models.Episode_VueModel", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Cod_vue");

                    b.Property<bool>("Deleted");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<Guid?>("EpisodeID");

                    b.Property<Guid>("ID_ep");

                    b.Property<Guid>("ID_user");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<string>("UtilisateurId");

                    b.HasKey("ID");

                    b.HasIndex("EpisodeID");

                    b.HasIndex("UtilisateurId");

                    b.ToTable("Episode_VueModel");
                });

            modelBuilder.Entity("SerieYnoModels.Models.EpisodeModel", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Deleted");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("Name_ep");

                    b.Property<int>("Num_ep")
                        .HasMaxLength(1);

                    b.Property<Guid>("SaisonId");

                    b.Property<Guid?>("SaisonModelID");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<string>("description");

                    b.HasKey("ID");

                    b.HasIndex("SaisonId");

                    b.HasIndex("SaisonModelID");

                    b.ToTable("EpisodeModel");
                });

            modelBuilder.Entity("SerieYnoModels.Models.SaisonModel", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Deleted");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<int?>("Num_saison")
                        .IsRequired()
                        .HasMaxLength(1);

                    b.Property<Guid>("SerieId");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("ID");

                    b.HasIndex("SerieId");

                    b.ToTable("SaisonModel");
                });

            modelBuilder.Entity("SerieYnoModels.Models.Serie_suivieModel", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Cod_suivie");

                    b.Property<bool>("Deleted");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<Guid>("ID_serie");

                    b.Property<Guid>("ID_user");

                    b.Property<Guid?>("SerieID");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<string>("UtilisateurId");

                    b.HasKey("ID");

                    b.HasIndex("SerieID");

                    b.HasIndex("UtilisateurId");

                    b.ToTable("Serie_suivieModel");
                });

            modelBuilder.Entity("SerieYnoModels.Models.SerieModel", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Deleted");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1024);

                    b.Property<string>("Name_serie")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("Num_max_ep");

                    b.Property<int>("Num_max_saison");

                    b.Property<string>("Photo_serie");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("ID");

                    b.ToTable("SerieModel");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("SerieYnoModels.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("SerieYnoModels.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SerieYnoModels.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("SerieYnoModels.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SerieYnoModels.Models.Episode_VueModel", b =>
                {
                    b.HasOne("SerieYnoModels.Models.EpisodeModel", "Episode")
                        .WithMany()
                        .HasForeignKey("EpisodeID");

                    b.HasOne("SerieYnoModels.Models.ApplicationUser", "Utilisateur")
                        .WithMany()
                        .HasForeignKey("UtilisateurId");
                });

            modelBuilder.Entity("SerieYnoModels.Models.EpisodeModel", b =>
                {
                    b.HasOne("SerieYnoModels.Models.SerieModel", "Saison")
                        .WithMany()
                        .HasForeignKey("SaisonId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SerieYnoModels.Models.SaisonModel")
                        .WithMany("Episodes")
                        .HasForeignKey("SaisonModelID");
                });

            modelBuilder.Entity("SerieYnoModels.Models.SaisonModel", b =>
                {
                    b.HasOne("SerieYnoModels.Models.SerieModel", "Serie")
                        .WithMany("Saisons")
                        .HasForeignKey("SerieId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SerieYnoModels.Models.Serie_suivieModel", b =>
                {
                    b.HasOne("SerieYnoModels.Models.SerieModel", "Serie")
                        .WithMany()
                        .HasForeignKey("SerieID");

                    b.HasOne("SerieYnoModels.Models.ApplicationUser", "Utilisateur")
                        .WithMany()
                        .HasForeignKey("UtilisateurId");
                });
#pragma warning restore 612, 618
        }
    }
}
