﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SportsAPI.Models;

namespace SportsAPI.Migrations
{
    [DbContext(typeof(SportsAPIContext))]
    partial class SportsAPIContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SportsAPI.Data.Test", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("Test");
                });

            modelBuilder.Entity("SportsAPI.Data.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("SportsAPI.Data.UserTestMapping", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Distance");

                    b.Property<int>("TId");

                    b.Property<int?>("Time");

                    b.Property<int>("UId");

                    b.HasKey("Id");

                    b.HasIndex("TId");

                    b.HasIndex("UId");

                    b.ToTable("UserTestMapping");
                });

            modelBuilder.Entity("SportsAPI.Data.UserTestMapping", b =>
                {
                    b.HasOne("SportsAPI.Data.Test", "Test")
                        .WithMany()
                        .HasForeignKey("TId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SportsAPI.Data.User", "User")
                        .WithMany()
                        .HasForeignKey("UId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
