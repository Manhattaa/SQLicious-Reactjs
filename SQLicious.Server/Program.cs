using SQLicious.Server.Data.Repository.IRepositories;
using SQLicious.Server.Data.Repository;
using Microsoft.EntityFrameworkCore;
using SQLicious.Server.Data;
using DotNetEnv;
using SQLicious.Server.Services.IServices;
using SQLicious.Server.Services;
using Microsoft.AspNetCore.Cors;
using SQLicious.Server.Options;
using Microsoft.AspNetCore.Identity;
using SQLicious.Server.Model;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using SQLicious.Server.Options.Email;
using SQLicious.Server.Options.Email.IEmail;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using DinkToPdf.Contracts;
using DinkToPdf;

namespace SQLicious.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            Env.Load();

            var mailKitSettingsSection = new MailKitSettings
            {
                MailServer = Environment.GetEnvironmentVariable("MAILSERVER"),
                MailPort = int.Parse(Environment.GetEnvironmentVariable("MAILPORT")),
                SenderName = Environment.GetEnvironmentVariable("SENDERNAME"),
                Sender = Environment.GetEnvironmentVariable("SENDER"),
                Password = Environment.GetEnvironmentVariable("PASSWORD")
            };

            builder.Services.Configure<MailKitSettings>(options =>
            {
                options.MailServer = mailKitSettingsSection.MailServer;
                options.MailPort = mailKitSettingsSection.MailPort;
                options.SenderName = mailKitSettingsSection.SenderName;
                options.Sender = mailKitSettingsSection.Sender;
                options.Password = mailKitSettingsSection.Password;
            });

            // Identity Setup
            builder.Services.AddIdentity<Admin, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedEmail = true;
                options.Tokens.AuthenticatorTokenProvider = TokenOptions.DefaultAuthenticatorProvider;
            })
                .AddEntityFrameworkStores<RestaurantContext>()
                .AddDefaultTokenProviders();


            // Adding JWT Bearer Authentication
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = Environment.GetEnvironmentVariable("JWT_ISSUER"),
                    ValidAudience = Environment.GetEnvironmentVariable("JWT_AUDIENCE"),
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT_SECRET")))
                };
            });

            // Add Authorization
            builder.Services.AddAuthorization();

            // Add services to the container.
            builder.Services.AddDbContext<RestaurantContext>(options =>
            {
                options.UseSqlServer(Environment.GetEnvironmentVariable("SQLICIOUS_CONNECTION"));
            });

            builder.Services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
                });

            // CORS
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins("https://localhost:5173", "https://localhost:7213", "https://localhost:7294")
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                });
            });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SQLicious API", Version = "v1" });

                // Define Bearer Authentication scheme for Swagger
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer"
                });

                // Apply Bearer authentication globally in Swagger UI
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new List<string>()
                    }
                });
            });

            // Service Registrations
            builder.Services.AddScoped<ITableRepository, TableRepository>();
            builder.Services.AddScoped<ITableService, TableService>();
            builder.Services.AddScoped<IBookingRepository, BookingRepository>();
            builder.Services.AddScoped<IBookingService, BookingService>();
            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.Services.AddScoped<ICustomerService, CustomerService>();
            builder.Services.AddScoped<IAdminRepository, AdminRepository>();
            builder.Services.AddScoped<IAdminService, AdminService>();
            builder.Services.AddScoped<IMenuItemRepository, MenuItemRepository>();
            builder.Services.AddScoped<IMenuItemService, MenuItemService>();
            builder.Services.AddScoped<JwtRepository>();
            builder.Services.AddScoped<AuthenticationService>();
            builder.Services.AddScoped<IEmailSender, EmailSender>();
            builder.Services.AddScoped<IPDFService, PDFService>();
            builder.Services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
            builder.Services.AddHttpClient();

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

            app.UseAuthentication(); 
            app.UseAuthorization();

            app.UseCors();

            app.MapControllers();

            app.MapFallbackToFile("/index.html");

            app.Run();
        }
    }
}
