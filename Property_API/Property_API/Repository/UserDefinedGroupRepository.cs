using System;
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

        public List<UserDefinedGroup> Get(Func<UserDefinedGroup, bool> where)
        {
            return dBContext.UserDefinedGroups.Where(where).ToList();
        }

        public List<UserDefinedGroup> GetAll()
        {
            return dBContext.UserDefinedGroups.ToList();
        }

        public UserDefinedGroup GetDetailed(Func<UserDefinedGroup, bool> first)
        {
            return dBContext.UserDefinedGroups.FirstOrDefault(first);
        }

        public List<UserDefinedGroup> GetDetailedAll()
        {
            return dBContext.UserDefinedGroups.ToList();
        }

        public List<Group> GetFieldList(string name)
        {
            List<Group> FieldGroups = new List<Group>();
            List<UserDefinedGroup> Groups;
            if (name == "Property Overview")
                Groups = dBContext.UserDefinedGroups.Where(x => x.Description == "Property Overview").OrderBy(x => x.Rank).ToList();
            else
                Groups = dBContext.UserDefinedGroups.Where(x => x.Description != "Property Overview").OrderBy(x => x.Rank).ToList();


            foreach (var group in Groups)
            {
                var fields = dBContext.UserDefinedFields.Where(x => x.GroupId == group.Id).ToList();
                if (fields.Count > 0)
                {
                    var item = new Group()
                    {
                        Name = group.Description,
                        Fields = new List<GroupFields>()
                    };

                    FieldGroups.Add(item);

                    foreach (var field in fields)
                    {
                        item.Fields.Add(new GroupFields()
                        {
                            ID = field.Id,
                            Name = field.FieldName,
                            Type = field.FieldType
                        });
                    }
                }
            }

            return FieldGroups;
        }

        public void Insert(UserDefinedGroup item)
        {
            dBContext.UserDefinedGroups.Add(item);
            Save();
        }

        public void Insert(IEnumerable<UserDefinedGroup> items)
        {
            foreach(var item in items)
            {
                dBContext.UserDefinedGroups.Add(item);
                Save();
            }
        }

        public void Remove(UserDefinedGroup item)
        {
            dBContext.UserDefinedGroups.Remove(item);
            Save();
        }

        public void Remove(IEnumerable<UserDefinedGroup> items)
        {
            foreach(var item in items)
            {
                dBContext.UserDefinedGroups.Remove(item);
                Save();
            }
        }

        public void RemoveAtId(int item)
        {
            var userDefinedGroups = Get(x => x.Id == item).FirstOrDefault();
            if (userDefinedGroups != null)
            {
                dBContext.UserDefinedGroups.Remove(userDefinedGroups);
                Save();
            }
        }

        public void Save()
        {
            dBContext.SaveChanges();
        }

        public void Update(UserDefinedGroup item)
        {
            dBContext.Entry(item).State = EntityState.Modified;
            Save();
        }
    }
}
