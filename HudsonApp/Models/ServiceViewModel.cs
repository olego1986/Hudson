using Hudson.DB.Service;

namespace HudsonApp.Models
{
    public class ServiceViewModel
    {
        public List<ServiceCategory> CategoryItems { get; set; } = [];

        public CallbackViewModel CallbackViewModel { get; set; }= new();
    }
}
