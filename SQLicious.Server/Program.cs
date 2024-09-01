
using SQLicious.Server.Data.Repository.IRepositories;
using SQLicious.Server.Data.Repository;
using Microsoft.EntityFrameworkCore;
using SQLicious.Server.Data;
using DotNetEnv;
using SQLicious.Server.Services.IServices;
using SQLicious.Server.Services;

namespace SQLicious.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            Env.Load();

            // Add services to the container.
            builder.Services.AddDbContext<RestaurantContext>(options =>
            {
                options.UseSqlServer(Environment.GetEnvironmentVariable("SQLICIOUS_CONNECTION"));
            });


            builder.Services.AddControllers();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<ITableRepository, TableRepository>();
            builder.Services.AddScoped<ITableService, TableService>();

            builder.Services.AddScoped<IBookingRepository, BookingRepository>();
            builder.Services.AddScoped<IBookingService, BookingService>();

            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.Services.AddScoped<ICustomerService, CustomerService>();

            builder.Services.AddScoped<IMenuItemRepository, MenuItemRepository>();
            builder.Services.AddScoped<IMenuItemService, MenuItemService>();

            var app = builder.Build();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.MapFallbackToFile("/index.html");

            app.Run();
        }
    }
}
