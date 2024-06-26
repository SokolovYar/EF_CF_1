﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WpfApp1;

#nullable disable

namespace WpfApp1.Migrations
{
    [DbContext(typeof(AppContext))]
    [Migration("20240322163909_Sokolov_2")]
    partial class Sokolov_2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WpfApp1.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Copies")
                        .HasColumnType("int");

                    b.Property<string>("Mode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Release")
                        .HasColumnType("datetime2");

                    b.Property<int>("StudioId")
                        .HasColumnType("int");

                    b.Property<int>("StyleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StudioId");

                    b.HasIndex("StyleId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("WpfApp1.Studio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descriprion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Studios");
                });

            modelBuilder.Entity("WpfApp1.Style", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Styles");
                });

            modelBuilder.Entity("WpfApp1.Game", b =>
                {
                    b.HasOne("WpfApp1.Studio", "Studio")
                        .WithMany("Games")
                        .HasForeignKey("StudioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WpfApp1.Style", "Style")
                        .WithMany("Games")
                        .HasForeignKey("StyleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Studio");

                    b.Navigation("Style");
                });

            modelBuilder.Entity("WpfApp1.Studio", b =>
                {
                    b.Navigation("Games");
                });

            modelBuilder.Entity("WpfApp1.Style", b =>
                {
                    b.Navigation("Games");
                });
#pragma warning restore 612, 618
        }
    }
}
