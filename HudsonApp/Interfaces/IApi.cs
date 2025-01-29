using HudsonApp.DTO;
using Newtonsoft.Json.Linq;
using RestEase;

namespace HudsonApp.Interfaces
{
    public interface IApi
    {
        [Get("bot{token}/getUpdates")]
        //[Post("rezapi/V1/{company}/{chain}/{hotelCode}/reservation/detail")]
        Task<JObject> GetTelegramId([Path("token")] string token, CancellationToken cancellationToken);

        [Post("bot{token}/sendMessage")]
        Task<object> SendMessage([Path("token")] string token, [Body] TelegramSendMessageBody body, CancellationToken cancellationToken);
    }
}
