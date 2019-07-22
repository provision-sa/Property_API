using System.ComponentModel.DataAnnotations;

namespace Property_API.Models
{
    public class PropertyUserField
    {
        [Key]
        public int Id { get; set; }
        public int PropertyId { get; set; }
        public int UserDefinedFieldId { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }

        public virtual Property Property { get; set; }
        public virtual UserDefinedField UserDefinedField { get; set; }
    }
}
