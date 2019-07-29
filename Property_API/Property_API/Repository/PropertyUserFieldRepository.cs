using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Property_API.Models;

namespace Property_API.Repository
{
    public class PropertyUserFieldRepository : IRepository<PropertyUserField>
    {
        private readonly DBContext dBContext;

        public PropertyUserFieldRepository(DBContext _dBContext)
        {
            dBContext = _dBContext;
        }

        public List<PropertyUserField> Get(Func<PropertyUserField, bool> where)
        {
            return dBContext.PropertyUserFields.Where(where).ToList();
        }

        public List<PropertyUserField> GetAll()
        {
            return dBContext.PropertyUserFields.ToList();
        }

        public PropertyUserField GetDetailed(Func<PropertyUserField, bool> first)
        {
            return dBContext.PropertyUserFields.FirstOrDefault(first);
        }

        public List<PropertyUserField> GetDetailedAll()
        {
            return dBContext.PropertyUserFields.ToList();
        }

        public void Insert(PropertyUserField item)
        {
            dBContext.PropertyUserFields.Add(item);
            Save();
        }

        public void Insert(IEnumerable<PropertyUserField> items)
        {
            foreach (var item in items)
            {
                dBContext.PropertyUserFields.Add(item);
                Save();
            }
        }

        public void Remove(PropertyUserField item)
        {
            dBContext.PropertyUserFields.Remove(item);
            Save();
        }

        public void Remove(IEnumerable<PropertyUserField> items)
        {
            foreach (var item in items)
            {
                dBContext.PropertyUserFields.Remove(item);
                Save();
            }
        }

        public void RemoveAtId(int item)
        {
            var propertyUserField = Get(x => x.Id == item).FirstOrDefault();
            if (propertyUserField != null)
            {
                dBContext.PropertyUserFields.Remove(propertyUserField);
                Save();
            }
        }

        public void Save()
        {
            dBContext.SaveChanges();
        }

        public void Update(PropertyUserField item)
        {
            dBContext.Entry(item).State = EntityState.Modified;
            Save();
        }
    }
}
