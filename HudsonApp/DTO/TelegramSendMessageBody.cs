using Newtonsoft.Json;

namespace HudsonApp.DTO;

public class TelegramSendMessageBody
{
    [JsonProperty("chat_id")]
    public string ChatId { get; set; }
    [JsonProperty("text")]
    public string Text { get; set; }
    [JsonProperty("parse_mode")]
    public string ParseMode { get; set; }
}