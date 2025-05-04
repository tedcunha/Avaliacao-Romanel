using Avaliacao.Romannel.Infra.Persistence;
using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Configuration;
using System.Reflection;
using Avaliacao.Romannel.Application.Validators;
using Avaliacao.Romannel.Application.Commands;
using Avaliacao.Romannel.Domain.Repositories;
using Avaliacao.Romannel.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Configurar o DbContext com SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
        //sql => sql.MigrationsAssembly("Infrastructure") // opcional, define onde estão as migrations
    )
);

builder.Services.AddValidatorsFromAssemblyContaining<CreateClienteValidator>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateClienteCommandHandler).Assembly));

builder.Services.AddScoped<IClienteRepository, ClienteRepository>();


// ➤ FluentValidation
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<CreateClienteValidator>();

// Add services to the container.

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
