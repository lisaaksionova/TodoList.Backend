using Microsoft.EntityFrameworkCore;
using System;
using Todolist.BLL.MediatR.Task.GetAll;
using Todolist.DAL.Persistence;
using Todolist.DAL.Repositories.Interfaces;
using Todolist.DAL.Repositories.Realizations;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLogging();
builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
        options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter()));




builder.Services.AddDbContext<TodolistDbContext>
    (opts => opts.UseSqlServer(
        builder.Configuration["ConnectionStrings:DefaultConnection"]));

builder.Services.AddScoped<ITaskRepository, TaskRepository>();

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssemblies(typeof(GetAllTasksQuery).Assembly));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyHeader()
        .AllowAnyMethod()
        .WithOrigins("http://localhost:3000");
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseRouting();


app.MapControllers();

app.Run();
