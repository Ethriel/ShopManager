
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ShopManager.Database;
using ShopManager.Services;
using ShopManager.Services.Abstraction;
using ShopManager.Services.Implementation;
using ShopManager.TestDbData.TestData;
using System.Text;

namespace ShopManager.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Logging.AddConsole();
            Console.OutputEncoding = Encoding.GetEncoding(builder.Configuration.GetValue<string>("ConsoleLogEncoding"));

            builder.Services.AddSingleton<IConfiguration>(provider => builder.Configuration);
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddDbContext<ShopDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
            builder.Services.AddScoped<DbContext, ShopDbContext>();
            // Custom services
            builder.Services.AddScoped(typeof(IEntityService<>), typeof(EntityService<>));
            builder.Services.AddScoped(typeof(IEntityExtendedService<>), typeof(EntityExtendedService<>));
            builder.Services.AddScoped(typeof(IMapperService<,>), typeof(MapperService<,>));
            builder.Services.AddScoped(typeof(IGenericModelService<,>), typeof(GenericModelService<,>));
            builder.Services.AddScoped<IShopService, ShopService>();

            var isFirstRun = builder.Configuration.GetValue<bool>("IsFirstRun");
            var isTestRun = builder.Configuration.GetValue<bool>("IsTestRun");

            if (isFirstRun && isTestRun)
            {
                // Test data services
                builder.Services.AddScoped<TestCategories>();
                builder.Services.AddScoped<TestProducts>();
                builder.Services.AddScoped<TestClients>();
                builder.Services.AddScoped<TestPurchases>();
                builder.Services.AddScoped<TestDataService>();
            }

            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (isFirstRun && isTestRun)
            {
                var testDataService = app.Services.GetService<TestDataService>();
                testDataService.CreateTestData();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();

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
