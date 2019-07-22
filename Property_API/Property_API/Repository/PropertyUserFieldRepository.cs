using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Property_API.Models;

namespace Property_API.Repository
{
    public class PropertyUserFieldRepository : IPropertyUserFieldRepository
    {
        private readonly DBContext dBContext;

        public PropertyUserFieldRepository(DBContext _dBContext)
        {
            dBContext = _dBContext;
        }
        public void Delete(int id)
        {
            var propertyUserField = dBContext.PropertyUserFields.Find(id);
            if (propertyUserField != null)
            {
                dBContext.PropertyUserFields.Remove(propertyUserField);
                Save();
            }
        }

        public PropertyUserField GetById(int id)
        {
            return dBContext.PropertyUserFields.Find(id);
        }

        public IEnumerable<PropertyUserField> GetList()
        {
            return dBContext.PropertyUserFields.ToList();
        }

        public void Insert(PropertyUserField propertyUserField)
        {
            dBContext.PropertyUserFields.Add(propertyUserField);
            Save();
        }

        public void Save()
        {
            dBContext.SaveChanges();
        }

        public void Update(PropertyUserField propertyUserField)
        {
            dBContext.Entry(propertyUserField).State = EntityState.Modified;
            Save();
        }
    }
}
