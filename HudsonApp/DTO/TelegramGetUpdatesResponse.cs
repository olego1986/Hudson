using System.ComponentModel;
using Newtonsoft.Json;

namespace HudsonApp.DTO
{
    public class TelegramGetUpdatesResponse
    {
        [JsonProperty("ok")]
        public bool Ok { get; set; }

        [JsonProperty("result")]
        public TelegramGetUpdate[] Result { get; set; }
    }

    public class TelegramGetUpdate
    {
        [JsonProperty("update_id")]
        public string UpdateId { get; set; }

        [JsonProperty("message")]
        public Message Message { get; set; }
    }

    public class Message
    {
        [JsonProperty("message_id")]
        public string MessageId { get; set; }
        [JsonProperty("from")]
        public From From { get; set; }
        [JsonProperty("chat")]
        public Chat Chat { get; set; }
        [JsonProperty("date")]
        public string Date { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("entities")]
        public List<Entity> Entities { get; set; }
    }

    public class From
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("is_bot")]
        public string IsBot { get; set; }
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        [JsonProperty("language_code")]
        public string LanguageCode { get; set; }
    }

    public class Chat
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("all_members_are_administrators")]
        public string AllMembersAreAdministrators { get; set; }
    }

    public class Entity
    {
        [JsonProperty("offset")]
        public string Offset { get; set; }
        [JsonProperty("length")]
        public string Length { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}