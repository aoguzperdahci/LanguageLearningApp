using LanguageLearningApp.Core.Interfaces.Repository;
using LanguageLearningApp.Core.Interfaces.Services;
using LanguageLearningApp.Infrastructure.Repositories;
using LanguageLearningApp.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var service = builder.Services;
service.AddSingleton<ILessonService, LessonManager>();
service.AddSingleton<IStudentService, StudentManager>();
service.AddSingleton<IQuestionService, QuestionManager>();

service.AddSingleton<ILessonReadRepository, LessonReadRepository>();
service.AddSingleton<IStudentReadRepository, StudentReadRepository>();
service.AddSingleton<IQuestionReadRepository, QuestionReadRepository>();

builder.Services.AddControllers();
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
