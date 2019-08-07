using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Property_API.Models
{
    public class PropertyUserField
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int PropertyId { get; set; }
        public int UserDefinedFieldId { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }

        public virtual Property Property { get; set; }
        public virtual UserDefinedField UserDefinedField { get; set; }
    }
}
