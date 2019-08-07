using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Property_API.Models
{
    public class PropertyImage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int PropertyId { get; set; }
        public string Image { get; set; }
        public bool IsDefault { get; set; }
        public virtual Property Property { get; set; }
    }
}
