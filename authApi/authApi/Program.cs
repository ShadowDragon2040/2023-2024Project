
using authApi.Datas;
using authApi.Models;
using authApi.Services;
using authApi.Services.IServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace authApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(c => { c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()); });

            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                var connectionString = builder.Configuration.GetConnectionString("Xampmashogyan");
                options.UseMySql(connectionString,ServerVersion.AutoDetect(connectionString));
            });
            builder.Services.AddDbContext<AuthContext>();


            builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("AuthSettings:JwtOptions"));

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            //builder.Services.AddScoped<JwtOptions>();
            builder.Services.AddScoped<IAuth, AuthService>();
            builder.Services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
            // Add services to the container.

            builder.Services.AddDbContext<AuthContext>();
            builder.Services.AddAuthorization();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            app.UseAuthentication();

            app.UseAuthorization();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors("AllowOrigin");



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
