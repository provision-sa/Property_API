using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Property_API.Models;

namespace Property_API.Repository
{
    public class UserDefinedFieldRepository : IRepository<UserDefinedField>
    {
        private readonly DBContext dBContext;

        public UserDefinedFieldRepository(DBContext _dBContext)
        {
            dBContext = _dBContext;
        }

        public List<UserDefinedField> Get(Func<UserDefinedField, bool> where)
        {
            return dBContext.UserDefinedFields.Where(where).ToList();
        }

        public List<UserDefinedField> GetAll()
        {
            return dBContext.UserDefinedFields.ToList();
        }

        public UserDefinedField GetDetailed(Func<UserDefinedField, bool> first)
        {
            return dBContext.UserDefinedFields.FirstOrDefault(first);
        }

        public List<UserDefinedField> GetDetailedAll()
        {
            return dBContext.UserDefinedFields.ToList();
        }

        public void Insert(UserDefinedField item)
        {
            dBContext.UserDefinedFields.Add(item);
            Save();
        }

        public void Insert(IEnumerable<UserDefinedField> items)
        {
            foreach(var item in items)
            {
                dBContext.UserDefinedFields.Add(item);
                Save();
            }
        }

        public void Remove(UserDefinedField item)
        {
            dBContext.UserDefinedFields.Remove(item);
            Save();
        }

        public void Remove(IEnumerable<UserDefinedField> items)
        {
            foreach(var item in items)
            {
                dBContext.UserDefinedFields.Add(item);
                Save();
            }
        }

        public void RemoveAtId(int item)
        {
            var userDefinedField = Get(x => x.Id == item).FirstOrDefault();
            if (userDefinedField != null)
            {
                dBContext.UserDefinedFields.Remove(userDefinedField);
                Save();
            }
        }

        public void Save()
        {
            dBContext.SaveChanges();
        }

        public void Update(UserDefinedField item)
        {
            dBContext.Entry(item).State = EntityState.Modified;
            Save();
        }        
    }
}
