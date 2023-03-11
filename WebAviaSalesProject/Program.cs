using System.Text.Json.Serialization;
using WebAviaSalesProject.Database;

namespace WebAviaSalesProject;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        var c = builder.Services.AddControllers();
        c.AddJsonOptions(opt =>
        {
            opt.JsonSerializerOptions.
                ReferenceHandler = ReferenceHandler.Preserve;
        });
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddAuthentication();

        builder.Services.AddSqlServer<AviaSalesContext>("server=localhost;Initial Catalog=AviaSales;Integrated Security=True");

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
    