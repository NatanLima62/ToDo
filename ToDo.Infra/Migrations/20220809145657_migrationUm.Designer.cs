﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ToDo.Infra.Contexts;

#nullable disable

namespace ToDo.Infra.Migrations
{
    [DbContext(typeof(TodoContext))]
    [Migration("20220809145657_migrationUm")]
    partial class migrationUm
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ToDo.Domain.Entities.Assignment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<byte>("Conclued")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TINYINT")
                        .HasDefaultValue((byte)0);

                    b.Property<DateTime?>("ConcluedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME");

                    b.Property<DateTime?>("CreateAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME");

                    b.Property<DateTime?>("DeadLine")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("VARCHAR(280)");

                    b.Property<int?>("TodoListId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateAt")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("DATETIME");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TodoListId");

                    b.HasIndex("UserId");

                    b.ToTable("tasks", (string)null);
                });

            modelBuilder.Entity("ToDo.Domain.Entities.TodoList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(180)");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("todos", (string)null);
                });

            modelBuilder.Entity("ToDo.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(180)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(180)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)");

                    b.HasKey("Id");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("ToDo.Domain.Entities.Assignment", b =>
                {
                    b.HasOne("ToDo.Domain.Entities.TodoList", "TodoList")
                        .WithMany("Assignments")
                        .HasForeignKey("TodoListId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ToDo.Domain.Entities.User", "User")
                        .WithMany("Assignments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("TodoList");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ToDo.Domain.Entities.TodoList", b =>
                {
                    b.HasOne("ToDo.Domain.Entities.User", "User")
                        .WithMany("TodoLists")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ToDo.Domain.Entities.TodoList", b =>
                {
                    b.Navigation("Assignments");
                });

            modelBuilder.Entity("ToDo.Domain.Entities.User", b =>
                {
                    b.Navigation("Assignments");

                    b.Navigation("TodoLists");
                });
#pragma warning restore 612, 618
        }
    }
}
