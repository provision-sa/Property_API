using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Property_API.Models
{
    public class UserDefinedGroup
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public PropertyUsageType UsageType { get; set; }
        public int Rank { get; set; }

        public ICollection<UserDefinedField> Fields { get; set; }
    }

    public class Group
    {
        public string Name { get; set; }
        public List<GroupFields> Fields { get; set; }
    }

    public class GroupFields
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }
}
