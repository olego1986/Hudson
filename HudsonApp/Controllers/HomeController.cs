using HudsonApp.Models;
using Microsoft.AspNetCore.Mvc;
using HudsonApp.Interfaces;
using Newtonsoft.Json.Linq;
using HudsonApp.DTO;
using HudsonApp.Enums;
using HudsonApp.Extensions;

namespace HudsonApp.Controllers;

public class HomeController(IApi Api, IConfiguration configuration) : Controller
{
    private readonly string telegramBotName = configuration.GetSection("Telegram").GetValue<string>("telegramBotName");//"harage_hudson_bot";
    private readonly string telegramBotUserName = configuration.GetSection("Telegram").GetValue<string>("telegramBotUserName");//"harage_hudson_bot";
    private readonly string chatId = configuration.GetSection("Telegram").GetValue<string>("chatId");//"-4738930860";

    private readonly string telegramBotToken = configuration.GetSection("Telegram").GetValue<string>("telegramBotToken");//"7922292995:AAERr0uiPCSu9YDb_-xP6V9QxXdq8iljreE";

    private readonly string phonePrefix = configuration.GetSection("Constants").GetValue<string>("PhonePrefix");

    [HttpGet]
    [Route("~/")]
    public IActionResult Home()
    {
        var model = new HomeViewModel();
        return View(model);
    }

    [Route("~/services")]
    public IActionResult Services()
    {
        ServiceViewModel model = new ServiceViewModel();
        return View(model);
    }

    [Route("~/contacts")]
    public IActionResult Contacts()
    {
        return View();
    }

    [Route("~/usa-cars")]
    public IActionResult CarUsa()
    {
        return View();
    }

    [Route("~/europe-cars")]
    public IActionResult CarEurope()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CallbackAsync(CallbackViewModel request)
    {
        if (!ModelState.IsValid)
        {
            TempData["ErrorMessage"] = $"Щось не так з номером: {phonePrefix}{request.PhoneNumber}";
            return RedirectToAction("Home");
        }

        var phoneNumber = phonePrefix + request.PhoneNumber.Replace(")", "").Replace("(", "").Replace("-", "");
        var userName = string.IsNullOrWhiteSpace(request.Name) ? "-" : $"<b>{request.Name}</b>";
        var userType = $"<b><i>{((CallbackType)Enum.Parse(typeof(CallbackType), request.CallbackType)).GetEnumDescription()}</i></b>";
        var message = $"Новий запит на дзвінок.\n Ім'я: {userName}\n Тип запиту: {userType}\n Номер телефону:\n📞 {phoneNumber}";

        await SendMessageToTelegram(message);

        TempData["SuccessMessage"] = "Ваш запит на дзвінок прийнято. Ми зателефонуємо найближчим часом.";
        return RedirectToAction("Home");
    }


    [HttpGet]
    public async Task<IActionResult> GetChat(HomeViewModel request)
    {
        if (ModelState.IsValid)
        {
            JObject result = await Api.GetTelegramId(telegramBotToken, CancellationToken.None);
            TelegramGetUpdatesResponse? response = result.ToObject<TelegramGetUpdatesResponse>();

            return View("Home");
        }

        return View("Home", request);
    }

    private async Task SendMessageToTelegram(string message)
    {
        var data = new TelegramSendMessageBody
        {
            ChatId = chatId,
            Text = message,
            ParseMode = "HTML"
        };

        await Api.SendMessage(telegramBotToken, data, CancellationToken.None);
    }

    [Route("~/details")]
    public IActionResult Details()
    {
        return View();
    }
}