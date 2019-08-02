using System.ComponentModel.DataAnnotations;

namespace Property_API.Models
{
    public class PropertyImage
    {
        [Key]
        public int Id { get; set; }
        public int PropertyId { get; set; }
        public string Image { get; set; }
        public bool IsDefault { get; set; }
        public virtual Property Property { get; set; }
    }
}
