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
    }
}
