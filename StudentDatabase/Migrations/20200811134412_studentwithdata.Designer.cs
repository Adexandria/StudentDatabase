﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentDatabase.DbContexts;

namespace StudentDatabase.Migrations
{
    [DbContext(typeof(StudentsDb))]
    [Migration("20200811134412_studentwithdata")]
    partial class studentwithdata
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StudentDatabase.Entities.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Classes")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("DateOfBirth")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                            Classes = 5,
                            DateOfBirth = new DateTimeOffset(new DateTime(1999, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)),
                            FirstName = "Adeola",
                            Gender = 1,
                            LastName = "Aderibigbe",
                            MiddleName = "Wuraola",
                            State = 23
                        },
                        new
                        {
                            Id = new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                            Classes = 5,
                            DateOfBirth = new DateTimeOffset(new DateTime(1998, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)),
                            FirstName = "Uriel",
                            Gender = 0,
                            LastName = "Aye",
                            MiddleName = "Ayebanengimote",
                            State = 5
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
