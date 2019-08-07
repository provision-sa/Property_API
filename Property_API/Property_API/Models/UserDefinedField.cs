using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Property_API.Models
{
    public class UserDefinedField
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
