using LanguageLearningApp.Core.Interfaces.Repository;
using LanguageLearningApp.Core.Interfaces.Services;
using LanguageLearningApp.Infrastructure.Repositories;
using LanguageLearningApp.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var service = builder.Services;

builder.Services.AddControllers();
service.AddSingleton<ILessonService, LessonManager>();
service.AddSingleton<ILessonRepository, LessonRepository>();

service.AddSingleton<IExamQuestionService, ExamQuestionManager>();
service.AddSingleton<IExamQuestionsRepository, ExamQuestionRepository>();


service.AddSingleton<IStudentRepository, StudentRepository>();


service.AddSingleton<IQuestionRepository, QuestionRepository>();

service.AddSingleton<IExamService, ExamManager>();
service.AddSingleton<IExamRepository, ExamRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
