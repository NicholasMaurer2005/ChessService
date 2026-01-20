using ChessService.Business.Implimentation;
using ChessService.Business.Interfaces;
using ChessService.DataAccess;
using ChessService.DataAccess.Implimentation;
using ChessService.DataAccess.Interfaces;
using ChessService.Shared.Helpers;
using Microsoft.EntityFrameworkCore;

//DESCOPE CLIENT SECRET EXPIRES: January 20, 2028

namespace ChessService
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
            builder.Services.AddScoped<IAuthHelper, DescopeHelper>("https://api.descope.com");

            builder.Services.Configure<DescopeHelper.AuthOptions>(options =>
            {
                options.ClientId = builder.Configuration["DESCOPE_CLIENT_ID"],
                options.ClientSecret = builder.Configuration["DESCOPE_CLIENT_SECRET"] ?? throw new ConfigurationErrorsException()
            });

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

