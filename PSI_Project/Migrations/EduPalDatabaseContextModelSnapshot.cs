﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PSI_Project.Data;

#nullable disable

namespace PSI_Project.Migrations
{
    [DbContext(typeof(EduPalDatabaseContext))]
    partial class EduPalDatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PSI_Project.Models.Comment", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<string>("CommentText")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TopicId")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("TopicId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("PSI_Project.Models.Conspectus", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Rating")
                        .HasColumnType("integer");

                    b.Property<string>("TopicId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("TopicId");

                    b.ToTable("Conspectuses");
                });

            modelBuilder.Entity("PSI_Project.Models.Goal", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<DateTime>("GoalDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Goals");
                });

            modelBuilder.Entity("PSI_Project.Models.Message", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsUserMessage")
                        .HasColumnType("boolean");

                    b.Property<string>("SenderId")
                        .HasColumnType("text");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("SenderId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("PSI_Project.Models.Subject", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("PSI_Project.Models.SubjectGoal", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<double>("ActualHoursStudied")
                        .HasColumnType("double precision");

                    b.Property<string>("GoalId")
                        .HasColumnType("text");

                    b.Property<string>("SubjectId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("TargetHours")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("GoalId");

                    b.HasIndex("SubjectId");

                    b.ToTable("SubjectGoal");
                });

            modelBuilder.Entity("PSI_Project.Models.Topic", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<int>("KnowledgeRating")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SubjectId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("SubjectId");

                    b.ToTable("Topics");
                });

            modelBuilder.Entity("PSI_Project.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PSI_Project.Models.Comment", b =>
                {
                    b.HasOne("PSI_Project.Models.Topic", "Topic")
                        .WithMany()
                        .HasForeignKey("TopicId");

                    b.HasOne("PSI_Project.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Topic");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PSI_Project.Models.Conspectus", b =>
                {
                    b.HasOne("PSI_Project.Models.Topic", "Topic")
                        .WithMany()
                        .HasForeignKey("TopicId");

                    b.Navigation("Topic");
                });

            modelBuilder.Entity("PSI_Project.Models.Goal", b =>
                {
                    b.HasOne("PSI_Project.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PSI_Project.Models.Message", b =>
                {
                    b.HasOne("PSI_Project.User", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("PSI_Project.Models.SubjectGoal", b =>
                {
                    b.HasOne("PSI_Project.Models.Goal", null)
                        .WithMany("SubjectGoals")
                        .HasForeignKey("GoalId");

                    b.HasOne("PSI_Project.Models.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("PSI_Project.Models.Topic", b =>
                {
                    b.HasOne("PSI_Project.Models.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("PSI_Project.Models.Goal", b =>
                {
                    b.Navigation("SubjectGoals");
                });
#pragma warning restore 612, 618
        }
    }
}
