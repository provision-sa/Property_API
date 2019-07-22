using System.ComponentModel.DataAnnotations;

namespace Property_API.Models
{
    public class PropertyType
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public PropertyUsageType UsageType { get; set; }
    }
}
