using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ScottBrady91.AspNetCore.Identity;
using ToDo.Api.ViewModels.AssignmentViewModel;
using ToDo.Api.ViewModels.LoginViewModel;
using ToDo.Api.ViewModels.TodoViewModel;
using ToDo.Api.ViewModels.UserViewModel;
using ToDo.Domain.Entities;
using ToDo.Infra.Contexts;
using ToDo.Infra.Interfaces;
using ToDo.Infra.Repositories;
using ToDo.Services.Configuration;
using ToDo.Services.DTOs;
using ToDo.Services.Interfaces;
using ToDo.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

#region Jwt

var key = Encoding.ASCII.GetBytes(Settings.Secret);
builder.Services
    .AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(x =>
    {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

#endregion

#region AutoMapper

var autoMapperConfig = new MapperConfiguration(cfg =>
{
    cfg.CreateMap<UserDTO, User>().ReverseMap();
    cfg.CreateMap<CreateUserViewModel, UserDTO>().ReverseMap();
    cfg.CreateMap<UpdateUserViewModel, UserDTO>().ReverseMap();

    cfg.CreateMap<TodoDTO, TodoList>().ReverseMap();
    cfg.CreateMap<CreateTodoViewModel, TodoDTO>().ReverseMap();
    cfg.CreateMap<UpdateTodoViewModel, TodoDTO>().ReverseMap();

    cfg.CreateMap<AssignmentDTO, Assignment>().ReverseMap();
    cfg.CreateMap<CreateAssignmentViewModel, AssignmentDTO>().ReverseMap();
    cfg.CreateMap<UpdateAssignmentViewModel, AssignmentDTO>().ReverseMap();

    cfg.CreateMap<LoginUserDTO, LoginViewModel>().ReverseMap();
});

builder.Services.AddSingleton(autoMapperConfig.CreateMapper());

builder.Services.AddSingleton(d => builder.Configuration);
builder.Services.AddDbContext<TodoContext>(options => options.UseSqlServer(builder.Configuration["connectionStrings:Default"]));

builder.Services.AddScoped<IUserService, UserServices>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<ITodoService, TodoServices>();
builder.Services.AddScoped<ITodoRepository, TodoRepository>();

builder.Services.AddScoped<IAssignmentService, AssignmentServices>();
builder.Services.AddScoped<IAssignmentRepository, AssignmentRepository>();


#endregion

#region Argon2

builder.Services.AddScoped<IPasswordHasher<User>, Argon2PasswordHasher<User>>();

#endregion
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Por favor ultilize Bearer <Token>",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    
    c.AddSecurityRequirement(new OpenApiSecurityRequirement{
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();