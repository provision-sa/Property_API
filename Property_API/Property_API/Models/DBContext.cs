using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Property_API.Models
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }
        
        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyImage> PropertyImages { get; set; }
        public DbSet<PropertyType> PropertyTypes { get; set; }
        public DbSet<PropertyUserField> PropertyUserFields { get; set; }
        public DbSet<UserDefinedField> UserDefinedFields { get; set; }
        public DbSet<UserDefinedGroup> UserDefinedGroups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDefinedGroup>().HasData(
                new UserDefinedGroup
                {
                    Id = 1,
                    Description = "Property Overview",
                    UsageType = PropertyUsageType.Both,
                    Rank = 1
                },
                new UserDefinedGroup
                {
                    Id = 2,
                    Description = "Rooms",
                    UsageType = PropertyUsageType.Residential,
                    Rank = 2
                },
                new UserDefinedGroup
                {
                    Id = 3,
                    Description = "External Features",
                    UsageType = PropertyUsageType.Both,
                    Rank = 3
                },
                new UserDefinedGroup
                {
                    Id = 4,
                    Description = "Building",
                    UsageType = PropertyUsageType.Both,
                    Rank = 4
                },
                new UserDefinedGroup
                {
                    Id = 5,
                    Description = "Other Features",
                    UsageType = PropertyUsageType.Both,
                    Rank = 5
                }
            );

            modelBuilder.Entity<UserDefinedField>().HasData(
                new UserDefinedField
                {
                    Id = 1,
                    GroupId = 1,
                    FieldName = "Erf Size",
                    Rank = 1,
                    FieldType = "number"
                },
                new UserDefinedField
                {
                    Id = 2,
                    GroupId = 1,
                    FieldName = "Floor Size",
                    Rank = 2,
                    FieldType = "number"
                },
                new UserDefinedField
                {
                    Id = 3,
                    GroupId = 1,
                    FieldName = "Levies",
                    Rank = 3,
                    FieldType = "number"
                },
                new UserDefinedField
                {
                    Id = 4,
                    GroupId = 1,
                    FieldName = "Rates and Taxes",
                    Rank = 4,
                    FieldType = "number"
                },
                new UserDefinedField
                {
                    Id = 5,
                    GroupId = 1,
                    FieldName = "Pets Allowed",
                    Rank = 5,
                    FieldType = "yesno"
                },
                new UserDefinedField
                {
                    Id = 6,
                    GroupId = 2,
                    FieldName = "Bedroom",
                    Rank = 1,
                    FieldType = "number"
                },
                new UserDefinedField
                {
                    Id = 7,
                    GroupId = 2,
                    FieldName = "Bathrooms",
                    Rank = 2,
                    FieldType = "number"
                },
                new UserDefinedField
                {
                    Id = 8,
                    GroupId = 2,
                    FieldName = "Kitchens",
                    Rank = 3,
                    FieldType = "number"
                },
                new UserDefinedField
                {
                    Id = 9,
                    GroupId = 2,
                    FieldName = "Lounge",
                    Rank = 4,
                    FieldType = "number"
                },
                new UserDefinedField
                {
                    Id = 10,
                    GroupId = 2,
                    FieldName = "Dining Room",
                    Rank = 5,
                    FieldType = "number"
                },
                new UserDefinedField
                {
                    Id = 11,
                    GroupId = 3,
                    FieldName = "Garages",
                    Rank = 1,
                    FieldType = "number"
                },
                new UserDefinedField
                {
                    Id = 12,
                    GroupId = 3,
                    FieldName = "Parking",
                    Rank = 2,
                    FieldType = "number"
                },
                new UserDefinedField
                {
                    Id = 13,
                    GroupId = 3,
                    FieldName = "Secure Parking",
                    Rank = 3,
                    FieldType = "yesno"
                },
                new UserDefinedField
                {
                    Id = 14,
                    GroupId = 3,
                    FieldName = "Garden",
                    Rank = 4,
                    FieldType = "yesno"
                },
                new UserDefinedField
                {
                    Id = 15,
                    GroupId = 3,
                    FieldName = "Pool",
                    Rank = 5,
                    FieldType = "yesno"
                },
                new UserDefinedField
                {
                    Id = 16,
                    GroupId = 3,
                    FieldName = "Braai",
                    Rank = 6,
                    FieldType = "yesno"
                },
                new UserDefinedField
                {
                    Id = 17,
                    GroupId = 3,
                    FieldName = "Scullery",
                    Rank = 7,
                    FieldType = "yesno"
                },
                new UserDefinedField
                {
                    Id = 18,
                    GroupId = 4,
                    FieldName = "Style",
                    Rank = 1,
                    FieldType = "text"
                },
                new UserDefinedField
                {
                    Id = 19,
                    GroupId = 4,
                    FieldName = "Facing",
                    Rank = 2,
                    FieldType = "text"
                },
                new UserDefinedField
                {
                    Id = 20,
                    GroupId = 4,
                    FieldName = "Roof",
                    Rank = 3,
                    FieldType = "text"
                },
                new UserDefinedField
                {
                    Id = 21,
                    GroupId = 4,
                    FieldName = "Walls",
                    Rank = 4,
                    FieldType = "text"
                },
                new UserDefinedField
                {
                    Id = 22,
                    GroupId = 4,
                    FieldName = "Windows",
                    Rank = 5,
                    FieldType = "text"
                },
                new UserDefinedField
                {
                    Id = 23,
                    GroupId = 5,
                    FieldName = "Security",
                    Rank = 1,
                    FieldType = "text"
                },
                new UserDefinedField
                {
                    Id = 24,
                    GroupId = 5,
                    FieldName = "Temperature Control",
                    Rank = 2,
                    FieldType = "text"
                },
                new UserDefinedField
                {
                    Id = 25,
                    GroupId = 5,
                    FieldName = "Nearby Public Transport",
                    Rank = 3,
                    FieldType = "yesno"
                },
                new UserDefinedField
                {
                    Id = 26,
                    GroupId = 5,
                    FieldName = "Internet Access",
                    Rank = 4,
                    FieldType = "text"
                }
            );
        }
    }
}
