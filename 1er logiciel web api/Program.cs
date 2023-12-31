using _1er_logiciel_web_api.Models;
using AutoMapper;
using AutoMapperDemo;

using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;


namespace _1er_logiciel_web_api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        // Add services to the container.




        builder.Services.AddAuthentication("Bearer")
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = builder.Configuration["Authentication:Issuer"],
                ValidAudience = builder.Configuration["Authentication:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.ASCII.GetBytes(builder.Configuration["Authentication:SecretForKey"]))
            };
        }
        );

        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy("MustBeFromAntwerp", policy =>
            {
                policy.RequireAuthenticatedUser();
                policy.RequireClaim("name", "Antwerp");
            });
        });






        // builder.Services.AddAutoMapper(typeof(MapperConfig));

        builder.Services.AddDbContext<AppDbContext>(); //On ajoute le fichier "AppDbContext" dans la solution pour y accéder plus tard
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();
        app.UseAuthentication();

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
    }
}
