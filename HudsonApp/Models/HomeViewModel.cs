using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace HudsonApp.Models
{
    public class SocialMediaViewModel
    {
        public string ViberAddress { get; set; } = "viber://chat?number=+380960909100";
        public string TelegramAddress { get; set; } = "https://t.me/+380960909100";
        public string InstagramAddress { get; set; } = "https://www.instagram.com/ctohudson/";
        public string FacebookAddress { get; set; } = "https://www.facebook.com/profile.php?id=61572012665056";
        public string TikTokAddress { get; set; } = "https://www.tiktok.com/@hudsongarage2010";
        public string YoutubeAddress { get; set; } = "https://www.youtube.com/channel/UC8wNrjEMlufs1oz3itn84mw";
    }

    public class CallbackViewModel
    {
        [Required(ErrorMessage = "Номер телефону обов'язковий")]
        [RegularExpression(@"^[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{2}[-\s\.]?[0-9]{2}$", ErrorMessage = "Введіть номер у форматі (0XX)XXX-XX-XX")]
        //[RegularExpression(@"^\+380\d{9}$", ErrorMessage = "Введіть номер у форматі +380XXXXXXXXX")]
        public string PhoneNumber { get; set; }

        [ValidateNever]
        public string Name { get; set; }
    }

    public class HomeViewModel
    {
        public SocialMediaViewModel SocialMedia { get; set; } = new();

        public CallbackViewModel CallbackViewModel { get; set; } = new();
    }
}
