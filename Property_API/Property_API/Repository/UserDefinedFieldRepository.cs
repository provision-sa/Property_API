using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Property_API.Models;

namespace Property_API.Repository
{
    public class UserDefinedFieldRepository : IUserDefinedFieldRepository
    {
        private readonly DBContext dBContext;

        public UserDefinedFieldRepository(DBContext _dBContext)
        {
            dBContext = _dBContext;
        }

        public void Delete(int id)
        {
            var userDefineField = dBContext.UserDefinedFields.Find(id);
            if (userDefineField != null)
            {
                dBContext.UserDefinedFields.Remove(userDefineField);
                Save();
            }
        }

        public UserDefinedField GetById(int id)
        {
            return dBContext.UserDefinedFields.Find(id);
        }

        public IEnumerable<UserDefinedField> GetList()
        {
            return dBContext.UserDefinedFields.ToList();
        }

        public void Insert(UserDefinedField userDefinedField)
        {
            dBContext.UserDefinedFields.Add(userDefinedField);
            Save();
        }

        public void Save()
        {
            dBContext.SaveChanges();
        }

        public void Update(UserDefinedField userDefinedField)
        {
            dBContext.Entry(userDefinedField).State = EntityState.Modified;
            Save();
        }
    }
}
