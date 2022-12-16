﻿using LanguageLearningApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLearningApp.Core.Interfaces.Repository
{
    public interface IStudentReadRepository:IReadRepository<Student>
    {
        void UpdateStudentOrder(Student updatedOrder);
    }
}
