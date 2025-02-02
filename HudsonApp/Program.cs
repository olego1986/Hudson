using Hudson.DB;
using Hudson.DB.Repository;
using Hudson.DB.Repository.Interface;
using HudsonApp.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using RestEase.HttpClientFactory;
using SQLitePCL;

namespace HudsonApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            await DbInit();

            builder.Services.AddSingleton<IServiceCategoryRepository, ServiceCategoryRepository>();

            AddExternalApiOptions(builder);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Home}");
                endpoints.MapControllerRoute(
                    name: "contact",
                    defaults:new {controller = "Home", action = "Contacts"},
                    pattern: "/contacts");
                endpoints.MapControllerRoute(
                    name: "contact",
                    defaults: new { controller = "Home", action = "Services" },
                    pattern: "/services");
                endpoints.MapControllerRoute(
                    name: "details",
                    defaults: new { controller = "Home", action = "Details" },
                    pattern: "/details");
                endpoints.MapControllerRoute(
                    name: "usa",
                    defaults: new { controller = "Home", action = "CarUsa" },
                    pattern: "/usa-cars");
                endpoints.MapControllerRoute(
                    name: "europe",
                    defaults: new { controller = "Home", action = "CarEurope" },
                    pattern: "/europe-cars");
            });

            app.Run();
        }

        private static async Task DbInit()
        {
            Batteries.Init();

            await using var db = new AppDbContext();
            await db.Database.EnsureCreatedAsync(CancellationToken.None);
        }

        public static void AddExternalApiOptions(WebApplicationBuilder builder)
        {
            var telegramUrl = "https://api.telegram.org/"; //builder.Configuration.GetValue<string>(CendynConstants.PegasusApiUrls.BaseUrl);
            if (string.IsNullOrEmpty(telegramUrl))
                return;

            builder.Services.AddRestEaseClient<IApi>(telegramUrl, client =>
            {
                client.JsonSerializerSettings = new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    Converters = { new StringEnumConverter() },
                };
            });
        }
    }
}
