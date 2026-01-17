
using Backend.Business.Implimentation;
using Backend.Business.Interfaces;
using Backend.DataAccess;
using Backend.DataAccess.Implimentation;
using Backend.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddScoped<IAccountLogic, AccountLogic>();
            builder.Services.AddScoped<IAccountDataAccess, AccountDataAccess>();
            builder.Services.AddScoped<IChessContext, ChessContext>();
            builder.Services.AddScoped<ISharedDataAccess, SharedDataAccess>();

            builder.Services.AddAuthentication("Bearer").AddJwtBearer(options =>
            {
                options.Authority = "https://api.descope.com";
                options.Audience = "DESCOPE_PRODUCT_ID";         
            });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<ChessContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("ChessDb")));

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
            app.UseAuthentication();
            app.UseAuthorization();

            app.Run();
        }
    }
}

