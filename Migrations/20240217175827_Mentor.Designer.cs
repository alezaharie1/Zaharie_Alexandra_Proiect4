﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Zaharie_Alexandra_Proiect4.Data;

#nullable disable

namespace Zaharie_Alexandra_Proiect4.Migrations
{
    [DbContext(typeof(Zaharie_Alexandra_Proiect4Context))]
    [Migration("20240217175827_Mentor")]
    partial class Mentor
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Zaharie_Alexandra_Proiect4.Models.Course", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("Credits")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MentorID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("MentorID");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("Zaharie_Alexandra_Proiect4.Models.Mentor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("MentorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Mentor");
                });

            modelBuilder.Entity("Zaharie_Alexandra_Proiect4.Models.Course", b =>
                {
                    b.HasOne("Zaharie_Alexandra_Proiect4.Models.Mentor", "Mentor")
                        .WithMany("Courses")
                        .HasForeignKey("MentorID");

                    b.Navigation("Mentor");
                });

            modelBuilder.Entity("Zaharie_Alexandra_Proiect4.Models.Mentor", b =>
                {
                    b.Navigation("Courses");
                });
#pragma warning restore 612, 618
        }
    }
}
