using System.ComponentModel.DataAnnotations;

namespace Hudson.DB.Service
{
    public class ServiceCategory
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public bool IsDefault { get; set; }

        public List<ServiceItemWork> ServiceItemWorks { get; set; }
    }
}
