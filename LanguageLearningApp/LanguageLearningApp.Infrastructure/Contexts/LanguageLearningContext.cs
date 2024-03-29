﻿using LanguageLearningApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLearningApp.Infrastructure.Contexts
{
    public class LanguageLearningContext : DbContext
    {       
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var path = System.Environment.CurrentDirectory.Replace("WebAPI", "Infrastructure");
            options.UseSqlite($"Data Source ={path}\\LanguageLearningDB.db");
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Lesson> Lessons{ get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamQuestions> ExamQuestions { get; set; }
        public DbSet<GapFillingQuestion> GapFillingQuestions { get; set; }

        public DbSet<MultimediaContent> MultimediaContents{ get; set; }
        public DbSet<TestQuestion> TestQuestions { get; set; }

    }
}
