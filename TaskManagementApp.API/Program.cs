using Microsoft.EntityFrameworkCore;
using TaskManagementApp.Application.Commands;
using TaskManagementApp.Application.Interfaces;
using TaskManagementApp.Application.Queries;
using TaskManagementApp.Infrastructure.Persistence;
using TaskManagementApp.Infrastructure.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using TaskManagementApp.Application.Validators;
using MediatR;
using System.Reflection;



var builder = WebApplication.CreateBuilder(args);

//EF Core
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ITaskRepository, TaskRepository>();


builder.Services.AddScoped<CreateTaskHandler>();
builder.Services.AddScoped<CompleteTaskHandler>();
builder.Services.AddScoped<GetTasksByProjectHandler>();

builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<CreateProjectHandler>();
builder.Services.AddScoped<GetProjectsHandler>();

builder.Services.AddControllers()
    .AddJsonOptions(x =>
        x.JsonSerializerOptions.PropertyNamingPolicy = null);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<CreateTaskCommandValidator>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", 
    policy => policy.WithOrigins("http://localhost:5173")
    .AllowAnyHeader()
    .AllowAnyMethod());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.UseCors("AllowFrontend");


app.Run();