using HudsonApp.Interfaces;
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
            
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Home}/{id?}");

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
