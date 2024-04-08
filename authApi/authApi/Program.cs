
using authApi.Datas;
using authApi.Models;
using authApi.Services;
using authApi.Services.IServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace authApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                                      policy =>
                                      {
                                          policy.WithOrigins("*")
                                                                .AllowAnyHeader()
                                                                .AllowAnyMethod()
                                                                .AllowAnyOrigin();
                                      });
            });
            builder.Services.AddDbContext<AuthContext>();
            builder.Services.AddDbContext<AppDbContext>(option =>
            {
                var connectionString = builder.Configuration.GetConnectionString("Xampmashogyan");
                option.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });

            var settingsSection = builder.Configuration.GetSection("AuthSettings:JwtOptions");

            builder.Services.Configure<JwtOptions>(settingsSection);

            var secret = settingsSection.GetValue<string>("Secret");
            var issuer = settingsSection.GetValue<string>("Issuer");
            var auidience = settingsSection.GetValue<string>("Audience");

            var key = Encoding.ASCII.GetBytes(secret);

            builder.Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidIssuer = issuer,
                    ValidAudience = auidience,
                    ValidateAudience = true
                };
            });

            builder.Services.AddAuthorization();

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddScoped<IAuth, AuthService>();
            builder.Services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

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

            app.UseCors(MyAllowSpecificOrigins);

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        

        //nagyprojectbackend program.cs
        /*
         var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddCors(c => { c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()); });

        builder.Services.AddDbContext<ProjectDatabaseContext>();

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();

        //farkas módszer
        builder.Services.AddSwaggerGen();
        var settingsSection = builder.Configuration.GetSection("AuthSettings");
        var secret = settingsSection.GetValue<string>("Secret");
        var issuer = settingsSection.GetValue<string>("Issuer");
        var auidience = settingsSection.GetValue<string>("Audience");

        var key = Encoding.ASCII.GetBytes(secret);

        //farkas módszer
        builder.Services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(x =>
        {
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = true,
                ValidIssuer = issuer,
                ValidAudience = auidience,
                ValidateAudience = true
            };
        });



        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseCors("AllowOrigin");

        app.UseHttpsRedirection();

        app.UseAuthentication();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
        */
    }
    }
}
