using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Property_API.Models;

namespace Property_API.Repository
{
    public class UserDefinedGroupRepository : IUserDefinedGroupRepository
    {
        private readonly DBContext dBContext;

        public UserDefinedGroupRepository(DBContext _dBContext)
        {
            dBContext = _dBContext;
        }

        public void Delete(int id)
        {
            var userDefinedGroup = dBContext.UserDefinedGroups.Find(id);
            if (userDefinedGroup != null)
            {
                dBContext.UserDefinedGroups.Remove(userDefinedGroup);
                Save();
            }
        }

        public UserDefinedGroup GetById(int id)
        {
            return dBContext.UserDefinedGroups.Find(id);
        }

        public IEnumerable<UserDefinedGroup> GetList()
        {
            return dBContext.UserDefinedGroups.ToList();
        }

        public void Insert(UserDefinedGroup userDefinedGroup)
        {
            dBContext.UserDefinedGroups.Add(userDefinedGroup);
            Save();
        }

        public void Save()
        {
            dBContext.SaveChanges();
        }

        public void Update(UserDefinedGroup userDefinedGroup)
        {
            dBContext.Entry(userDefinedGroup).State = EntityState.Modified;
            Save();
        }
    }
}
