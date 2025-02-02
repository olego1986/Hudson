using System.ComponentModel.DataAnnotations;

namespace Hudson.DB.Service
{
    public class ServiceItemWork
    {
        [Key]
        public int Id { get; set; }
        public int ServiceCategoryId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }

        public bool IsActive { get; set; }
        public int Amount { get; set; }

        public ServiceCategory ServiceCategory { get; set; }
    }
}
