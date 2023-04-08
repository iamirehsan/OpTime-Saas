using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OpTime_Saas.Domain.Entities;
using OpTime_Saas.Repository.Implimentation;
using System.Text.Json.Serialization;
using System.Text.Json;
using OpTime_Saas.Base.JsonConverter;
using Hangfire;
using Hangfire.MemoryStorage;
using OpTime_Saas.Base.Jobs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using OpTime_Saas.Repository;
using OpTime_Saas.Service.Interfaces;
using OpTime_Saas.Service.Implimentation.Implementation;
using FluentValidation.AspNetCore;
using OpTime_Saas.Messages.CommandValidator;

namespace OpTime_Saas
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IUnitOfWOrk, UnitOfWork>();
            builder.Services.AddScoped<IServiceHolder, ServiceHolder>();
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")));


            builder.Services.AddIdentity<User, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                            .AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services.AddScoped<UserManager<User>>();


            builder.Services.AddControllers(options =>
            {
            }).AddJsonOptions(opt =>
            {
                opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
                opt.JsonSerializerOptions.Converters.Add(new PersianDateTimeConverter());
                opt.JsonSerializerOptions.Converters.Add(new GuidJsonConverter());
                opt.JsonSerializerOptions.Converters.Add(new IntToStringConverter());
                opt.JsonSerializerOptions.Converters.Add(new LongToStringConverter());
                opt.JsonSerializerOptions.Converters.Add(new DictionaryInt32Converter());
                opt.JsonSerializerOptions.Converters.Add(new DictionaryInt64Converter());
                opt.JsonSerializerOptions.WriteIndented = true;

            }).AddFluentValidation(f => f.RegisterValidatorsFromAssemblyContaining<UserCreditCommandValidator>());

            builder.Services.AddHangfire(configuration => configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseDefaultTypeSerializer()
                .UseMemoryStorage());

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
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = builder.Configuration["Jwt:Issuer"],
                        ValidAudience = builder.Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                    };
                });



            var app = builder.Build().Seed();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseAuthentication();
            app.UseHttpsRedirection();
   

            app.UseAuthorization();
            app.UseHangfireDashboard();
            app.UseHangfireServer();
            RecurringJob.AddOrUpdate<IBannedAccount>("Ban-Accounts", x => x.BannedAccounts(), Cron.Hourly);

            app.MapControllers();

            app.Run();
        }
    }
}