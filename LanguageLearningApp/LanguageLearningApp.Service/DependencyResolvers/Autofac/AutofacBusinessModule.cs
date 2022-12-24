using Autofac;
using LanguageLearningApp.Core.Interfaces.Repository;
using LanguageLearningApp.Core.Interfaces.Services;
using LanguageLearningApp.Infrastructure.Repositories;
using LanguageLearningApp.Service;


namespace LanguageLearningApp.Infrastructure.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ExamManager>().As<IExamService>().SingleInstance();
            builder.RegisterType<ExamRepository>().As<IExamRepository>().SingleInstance();

            builder.RegisterType<LessonManager>().As<ILessonService>().SingleInstance() ;
            builder.RegisterType<LessonRepository>().As<ILessonRepository>().SingleInstance();

            builder.RegisterType<ExamQuestionManager>().As<IExamQuestionService>().SingleInstance();
            builder.RegisterType<ExamQuestionRepository>().As<IExamQuestionsRepository>().SingleInstance();

            builder.RegisterType<StudentRepository>().As<IStudentRepository>().SingleInstance();

            builder.RegisterType<QuestionRepository>().As<IQuestionRepository>().SingleInstance();


        }
    }
}
