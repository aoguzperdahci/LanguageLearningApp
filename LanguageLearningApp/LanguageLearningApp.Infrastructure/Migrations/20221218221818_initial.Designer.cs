﻿// <auto-generated />
using LanguageLearningApp.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LanguageLearningApp.Infrastructure.Migrations
{
    [DbContext(typeof(LanguageLearningContext))]
    [Migration("20221218221818_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.1");

            modelBuilder.Entity("LanguageLearningApp.Core.Entities.Exam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ExamResult")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LessonId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StudentId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("LessonId");

                    b.HasIndex("StudentId");

                    b.ToTable("Exams");
                });

            modelBuilder.Entity("LanguageLearningApp.Core.Entities.ExamQuestions", b =>
                {
                    b.Property<int>("ExamId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("QuestionNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int>("QuestionId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("StudentAnswer")
                        .HasColumnType("TEXT");

                    b.HasKey("ExamId", "QuestionNumber");

                    b.HasIndex("QuestionId");

                    b.ToTable("ExamQuestions");
                });

            modelBuilder.Entity("LanguageLearningApp.Core.Entities.Lesson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("LessonContent")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Level")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("MultimediaContentId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Order")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("MultimediaContentId");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("LanguageLearningApp.Core.Entities.MultimediaContent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("MultimediaContents");
                });

            modelBuilder.Entity("LanguageLearningApp.Core.Entities.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CorrectAnswer")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Difficulty")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("LessonId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("QuestionText")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("LessonId");

                    b.ToTable("Questions");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Question");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("LanguageLearningApp.Core.Entities.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("LessonId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("LessonId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("LanguageLearningApp.Core.Entities.GapFillingQuestion", b =>
                {
                    b.HasBaseType("LanguageLearningApp.Core.Entities.Question");

                    b.HasDiscriminator().HasValue("GapFillingQuestion");
                });

            modelBuilder.Entity("LanguageLearningApp.Core.Entities.TestQuestion", b =>
                {
                    b.HasBaseType("LanguageLearningApp.Core.Entities.Question");

                    b.Property<string>("ChoiceA")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ChoiceB")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ChoiceC")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ChoiceD")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ChoiceE")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("TestQuestion");
                });

            modelBuilder.Entity("LanguageLearningApp.Core.Entities.Exam", b =>
                {
                    b.HasOne("LanguageLearningApp.Core.Entities.Lesson", "Lesson")
                        .WithMany()
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LanguageLearningApp.Core.Entities.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lesson");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("LanguageLearningApp.Core.Entities.ExamQuestions", b =>
                {
                    b.HasOne("LanguageLearningApp.Core.Entities.Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("LanguageLearningApp.Core.Entities.Lesson", b =>
                {
                    b.HasOne("LanguageLearningApp.Core.Entities.MultimediaContent", "MultimediaContent")
                        .WithMany()
                        .HasForeignKey("MultimediaContentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MultimediaContent");
                });

            modelBuilder.Entity("LanguageLearningApp.Core.Entities.Question", b =>
                {
                    b.HasOne("LanguageLearningApp.Core.Entities.Lesson", "Lesson")
                        .WithMany()
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lesson");
                });

            modelBuilder.Entity("LanguageLearningApp.Core.Entities.Student", b =>
                {
                    b.HasOne("LanguageLearningApp.Core.Entities.Lesson", "Lesson")
                        .WithMany()
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lesson");
                });
#pragma warning restore 612, 618
        }
    }
}