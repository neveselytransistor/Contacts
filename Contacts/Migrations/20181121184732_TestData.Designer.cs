﻿// <auto-generated />
using Contacts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Contacts.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20181121184732_TestData")]
    partial class TestData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024");

            modelBuilder.Entity("Contacts.Models.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Contacts");

                    b.HasData(
                        new { Id = 1, Name = "Tom's friend", Phone = "123456789", UserId = 1 },
                        new { Id = 2, Name = "Alice's friend", Phone = "123456789", UserId = 2 },
                        new { Id = 3, Name = "Sam's friend", Phone = "123456789", UserId = 3 }
                    );
                });

            modelBuilder.Entity("Contacts.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<string>("Surname");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new { Id = 1, Email = "tom@mail.ru", Name = "Tom", Password = "1234" },
                        new { Id = 2, Email = "alice@mail.ru", Name = "Alice", Password = "1234" },
                        new { Id = 3, Email = "sam@mail.ru", Name = "Sam", Password = "1234" }
                    );
                });

            modelBuilder.Entity("Contacts.Models.Contact", b =>
                {
                    b.HasOne("Contacts.Models.User")
                        .WithMany("Contacts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}