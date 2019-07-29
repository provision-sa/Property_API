using System.ComponentModel.DataAnnotations;

namespace Property_API.Models
{
    public class UserDefinedField
    {
        [Key]
        public int Id { get; set; }
        public int GroupId { get; set; }
        public string FieldName { get; set; }
        public string FieldType { get; set; }
        //public string ControlType { get; set; }
        //public string ListItems { get; set; }
        public int Rank { get; set; }

        public virtual UserDefinedGroup Group { get; set; }
    }
}
