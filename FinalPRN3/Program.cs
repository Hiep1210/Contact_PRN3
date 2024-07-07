using FinalPRN3.Common;
using FinalPRN3.Mapper;
using FinalPRN3.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.OData;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace FinalPRN3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddOData(opt => opt
            .Select()
            .Expand()
            .Filter()
            .OrderBy()
            .SetMaxTop(100)
            ).AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
            //.AddNewtonsoftJson(options =>
            //{
            //    //options.SerializerSettings.ContractResolver = new IgnoreVirtualContractResolver();
            //    options.SerializerSettings.Converters.Add(new IgnoreVirtualContractResolver());
            //})
            ;
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddCors();
            builder.Services.AddSwaggerGen();
            //        builder.Services.AddSwaggerGen(c =>
            //        {
            //            c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

            //            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            //            {
            //                Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
            //                Name = "Authorization",
            //                In = ParameterLocation.Header,
            //                Type = SecuritySchemeType.ApiKey,
            //                Scheme = "Bearer"
            //            });

            //            c.AddSecurityRequirement(new OpenApiSecurityRequirement()
            //{
            //    {
            //        new OpenApiSecurityScheme
            //        {
            //            Reference = new OpenApiReference
            //            {
            //                Type = ReferenceType.SecurityScheme,
            //                Id = "Bearer"
            //            },
            //            Scheme = "oauth2",
            //            Name = "Bearer",
            //            In = ParameterLocation.Header,
            //        },
            //        new List<string>()
            //    }
            //});
            //        });
            builder.Services.AddSingleton<IConfiguration>(configuration);
            builder.Services.AddDbContext<lovetientdContext>();
            builder.Services.AddAutoMapper(typeof(MyMapper).Assembly);
            builder.Services.AddScoped<PhotoManager>();
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
                opt =>
                {
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                        .GetBytes(builder.Configuration.GetSection("jwtSecret").Value)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                }
              );

            var app = builder.Build();
            app.UseCors(builder =>
            {
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });

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
}
