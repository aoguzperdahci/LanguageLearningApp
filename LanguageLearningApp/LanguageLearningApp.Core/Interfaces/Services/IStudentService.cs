﻿using LanguageLearningApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLearningApp.Core.Interfaces.Services
{
    public interface IStudentService
    {
        Lesson currentLesson();
        public void getStudentId(int StudentId);

        public bool isStudent();   
    }
}