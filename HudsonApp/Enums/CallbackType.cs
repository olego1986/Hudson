using System.ComponentModel;

namespace HudsonApp.Enums
{
    public enum CallbackType
    {
        [Description("Загальне")]
        General = 0,
        [Description("Проведення ТО")]
        Service = 1,
        [Description("Запчастини")]
        Details = 2,
        [Description("Авто з Сша")]
        Usa = 3,
        [Description("Авто з Європи")]
        Europe = 4,
        [Description("Двигун")]
        Engine = 5,
        [Description("Трансмісія")]
        Transmission = 6,
        [Description("Гальма")]
        Break = 7,
        [Description("Підвіска")]
        Suspension = 8,
        [Description("Кузов")]
        Body = 9,
        [Description("Діагностика")]
        Diagnostic = 10,
        [Description("Електрика")]
        Electric = 11,
        [Description("Доустаткування авто")]
        Install = 12,
        [Description("Додаткова обробка авто")]
        Additional = 13,
        [Description("Інше")]
        Other = 100,
    }
}
