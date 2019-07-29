using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Property_API.Models;

namespace Property_API.Repository
{
    public class PropertyTypeRepository : IRepository<PropertyType>
    {
        private readonly DBContext dBContext;

        public PropertyTypeRepository(DBContext _dBContext)
        {
            dBContext = _dBContext;
        }

        public List<PropertyType> Get(Func<PropertyType, bool> where)
        {
            return dBContext.PropertyTypes.Where(where).ToList();
        }

        public List<PropertyType> GetAll()
        {
            return dBContext.PropertyTypes.ToList();
        }

        public PropertyType GetDetailed(Func<PropertyType, bool> first)
        {
            return dBContext.PropertyTypes.FirstOrDefault(first);
        }

        public List<PropertyType> GetDetailedAll()
        {
            return dBContext.PropertyTypes.ToList();
        }

        public void Insert(PropertyType item)
        {
            dBContext.PropertyTypes.Add(item);
            Save();
        }

        public void Insert(IEnumerable<PropertyType> items)
        {
            foreach(var item in items)
            {
                dBContext.PropertyTypes.Add(item);
                Save();
            }
        }

        public void Remove(PropertyType item)
        {
            dBContext.PropertyTypes.Remove(item);
            Save();
        }

        public void Remove(IEnumerable<PropertyType> items)
        {
            foreach (var item in items)
            {
                dBContext.PropertyTypes.Remove(item);
                Save();
            }
        }

        public void RemoveAtId(int item)
        {
            var propertyType = Get(x => x.Id == item).FirstOrDefault();
            if (propertyType != null)
            {
                dBContext.PropertyTypes.Remove(propertyType);
                Save();
            }
        }

        public void Save()
        {
            dBContext.SaveChanges();
        }

        public void Update(PropertyType item)
        {
            dBContext.Entry(item).State = EntityState.Modified;
            Save();
        }
    }
}
