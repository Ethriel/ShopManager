using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;
using ShopManager.Database;
using ShopManager.Server.Extensions;
using ShopManager.Services.Utility;
using System.Text;


namespace ShopManager.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Logging.AddConsole();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Console.OutputEncoding = Encoding.GetEncoding(builder.Configuration.GetValue<string>("ConsoleLogEncoding"));

            builder.Services.AddSingleton<IConfiguration>(provider => builder.Configuration);

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddDbContext<ShopDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
            builder.Services.AddAutoMapper(AutomapperUtility.GetAllAutomapperProfiles());
            builder.Services.AddScoped<DbContext, ShopDbContext>();
            builder.Services.AddValidators();
            builder.Services.AddAppServices();
            builder.Services.AddFluentValidationAutoValidation(config =>
            {
                config.DisableBuiltInModelValidation = true;
                config.ValidationStrategy = SharpGrip.FluentValidation.AutoValidation.Mvc.Enums.ValidationStrategy.Annotations;
                config.EnableBodyBindingSourceAutomaticValidation = true;
                config.EnableFormBindingSourceAutomaticValidation = true;
                config.EnableQueryBindingSourceAutomaticValidation = true;
            });
            builder.Services.AddCors();
            builder.Services.AddTestDataServices(builder.Configuration);

            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.UseTestDataServices();

            //app.UseDefaultFiles();
            //app.UseStaticFiles();

            app.UseCors(
                opt => opt.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod());

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseExceptionHandler(a => a.Run(async context =>
            {
                var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                var exception = exceptionHandlerPathFeature?.Error;

                var result = JsonConvert.SerializeObject(new { error = exception?.Message });
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsync(result);
            }));

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.MapFallbackToFile("/index.html");

            app.Run();
        }
    }
}
