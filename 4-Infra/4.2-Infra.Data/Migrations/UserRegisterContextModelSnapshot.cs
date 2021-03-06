﻿// <auto-generated />
using System;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Restful.Login.Infra.Data.Migrations
{
    [DbContext(typeof(UserRegisterContext))]
    partial class UserRegisterContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0-preview2.19525.5");

            modelBuilder.Entity("Domain.Entities.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnName("birth_date")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("email")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnName("first_name")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnName("last_name")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Phone")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("customer");
                });

            modelBuilder.Entity("Domain.Entities.Grade", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("grades");
                });

            modelBuilder.Entity("Domain.Entities.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("students");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnName("birth_date")
                        .HasColumnType("date");

                    b.Property<string>("ConfirmEmail")
                        .HasColumnName("confirm_email")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ConfirmPassword")
                        .HasColumnName("confirm_password")
                        .HasColumnType("varchar(150)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("created_at")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .HasColumnName("email")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("LastName")
                        .HasColumnName("last_name")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Password")
                        .HasColumnName("password")
                        .HasColumnType("varchar(150)");

                    b.Property<Guid>("RoleId")
                        .HasColumnName("role_id")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnName("updated_at")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("users");
                });

            modelBuilder.Entity("Restful.Login.Domain.Entities.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("course");
                });

            modelBuilder.Entity("Restful.Login.Domain.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("role");
                });

            modelBuilder.Entity("Restful.Login.Domain.Entities.StudentCourse", b =>
                {
                    b.Property<Guid>("StudentId")
                        .HasColumnName("student_id")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CourseId")
                        .HasColumnName("course_id")
                        .HasColumnType("TEXT");

                    b.HasKey("StudentId", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("student_course");
                });

            modelBuilder.Entity("Restful.Login.Domain.Entities.StudentGroup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CourseId")
                        .HasColumnName("course_id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("student_group");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.HasOne("Restful.Login.Domain.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Restful.Login.Domain.Entities.StudentCourse", b =>
                {
                    b.HasOne("Restful.Login.Domain.Entities.Course", "Course")
                        .WithMany("StudentCourses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Student", "Student")
                        .WithMany("StudentCourses")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Restful.Login.Domain.Entities.StudentGroup", b =>
                {
                    b.HasOne("Restful.Login.Domain.Entities.Course", "Course")
                        .WithMany("StudentGroups")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
