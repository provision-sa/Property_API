using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Property_API.Models;

namespace Property_API.Repository
{
    public class PropertyTypeRepository : IPropertyTypeRepository
    {
        private readonly DBContext dBContext;

        public PropertyTypeRepository(DBContext _dBContext)
        {
            dBContext = _dBContext;
        }

        public void Delete(int id)
        {
            var propertyType = dBContext.PropertyTypes.Find(id);
            if (propertyType != null)
            {
                dBContext.PropertyTypes.Remove(propertyType);
                Save();
            }
        }

        public PropertyType GetById(int id)
        {
            return dBContext.PropertyTypes.Find(id);
        }

        public IEnumerable<PropertyType> GetList()
        {
            return dBContext.PropertyTypes.ToList();
        }

        public IEnumerable<PropertyType> GetListOf(PropertyUsageType propertyUsage)
        {
            var propertyTypes = dBContext.PropertyTypes.Where(pt => pt.UsageType == propertyUsage || pt.UsageType == PropertyUsageType.Both).ToList();
            return propertyTypes;
        }

        public void Insert(PropertyType propertyType)
        {
            dBContext.PropertyTypes.Add(propertyType);
            Save();
        }

        public void Save()
        {
            dBContext.SaveChanges();
        }

        public void Update(PropertyType propertyType)
        {
            dBContext.Entry(propertyType).State = EntityState.Modified;
            Save();
        }
    }
}
