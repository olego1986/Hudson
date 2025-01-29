using HudsonApp.Interfaces;
using Microsoft.AspNetCore.Builder;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using RestEase.HttpClientFactory;
using static System.Net.WebRequestMethods;

namespace HudsonApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
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
