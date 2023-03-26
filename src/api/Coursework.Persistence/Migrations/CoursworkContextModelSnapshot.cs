﻿// <auto-generated />
using System;
using Coursework.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Coursework.Persistence.Migrations
{
    [DbContext(typeof(CoursworkContext))]
    partial class CoursworkContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Coursework.Domain.Entities.Candidate", b =>
                {
                    b.Property<Guid>("GID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Biography")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ProfileImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResumeUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserGID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("GID");

                    b.HasIndex("UserGID");

                    b.ToTable("Candidates");
                });

            modelBuilder.Entity("Coursework.Domain.Entities.Recruiter", b =>
                {
                    b.Property<Guid>("GID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ProfileImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserGID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("GID");

                    b.HasIndex("UserGID");

                    b.ToTable("Recruiters");
                });

            modelBuilder.Entity("Coursework.Domain.Entities.RefreshToken", b =>
                {
                    b.Property<Guid>("RefreshTokenGID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserGID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RefreshTokenGID");

                    b.HasIndex("UserGID");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("Coursework.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("GID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("GID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Coursework.Domain.Entities.Candidate", b =>
                {
                    b.HasOne("Coursework.Domain.Entities.User", "User")
                        .WithMany("Candidates")
                        .HasForeignKey("UserGID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Candidates_UserGID");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Coursework.Domain.Entities.Recruiter", b =>
                {
                    b.HasOne("Coursework.Domain.Entities.User", "User")
                        .WithMany("Recruiters")
                        .HasForeignKey("UserGID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Recruiters_UserGID");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Coursework.Domain.Entities.RefreshToken", b =>
                {
                    b.HasOne("Coursework.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserGID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Coursework.Domain.Entities.User", b =>
                {
                    b.Navigation("Candidates");

                    b.Navigation("Recruiters");
                });
#pragma warning restore 612, 618
        }
    }
}
