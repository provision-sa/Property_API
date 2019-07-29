using Microsoft.EntityFrameworkCore;
using Property_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Property_API.Repository
{
    public class PropertyRepository : IRepository<Property>
    {
        private readonly DBContext dBContext;

        public PropertyRepository(DBContext _dBContext)
        {
            dBContext = _dBContext;
        }

        public List<Property> Get(Func<Property, bool> where)
        {
            return dBContext.Properties.Where(where).ToList();
        }

        public List<Property> GetAll()
        {
            return dBContext.Properties.ToList();
        }

        public Property GetDetailed(Func<Property, bool> first)
        {
            var property = dBContext.Properties.FirstOrDefault(first);
            if (property != null)
            {
                GetDetail(ref property);
            }
            return property;
        }

        public List<Property> GetDetailedAll()
        {
            var properties = dBContext.Properties.ToList();

            //foreach(var property in properties)
            //{
            //    GetDetail(ref property);
            //}

            return properties;
        }

        private void GetDetail(ref Property property)
        {
            int propID = property.Id;
            var propertyType = dBContext.PropertyTypes.Find(property.PropertyTypeId);
            property.DisplayData = new List<PropertyDetailGroup>();
            property.DisplayImage = (from i in dBContext.PropertyImages
                                       where i.PropertyId == propID
                                       && i.IsDefault
                                       select i.ImagePath).FirstOrDefault();            

            var groups = (from g in dBContext.UserDefinedGroups
                          where g.UsageType == propertyType.UsageType
                          || g.UsageType == PropertyUsageType.Both // property types should only be res/comm
                          orderby g.Rank
                          select g).ToList();

            foreach (UserDefinedGroup uGroup in groups)
            {
                var groupFields = (from f in dBContext.PropertyUserFields
                                   join uf in dBContext.UserDefinedFields on f.UserDefinedFieldId equals uf.Id
                                   join g in dBContext.UserDefinedGroups on uf.GroupId equals g.Id
                                   where f.PropertyId == propID
                                   && g.Id == uGroup.Id
                                   orderby g.Rank, uf.Rank
                                   select new { uf.FieldName, f.Value, f.Description }).ToList();

                if (groupFields.Count > 0)
                {
                    PropertyDetailGroup detailGroup = new PropertyDetailGroup()
                    {
                        GroupName = uGroup.Description,
                        Values = new List<PropertyDetail>()
                    };

                    if (uGroup.Description == "Property Overview")
                    {
                        detailGroup.Values.Add(new PropertyDetail()
                        {
                            Name = "Property Type",
                            Value = property.PropertyType.Description
                        });
                    }

                    foreach (var val in groupFields)
                    {
                        detailGroup.Values.Add(new PropertyDetail()
                        {
                            Name = val.FieldName,
                            Value = val.Value,
                            Description = val.Description
                        });
                    }

                    property.DisplayData.Add(detailGroup);
                }
            }
        }

        public void Insert(Property item)
        {
            dBContext.Properties.Add(item);
            Save();
        }

        public void Insert(IEnumerable<Property> items)
        {
            foreach (var item in items )
            {
                dBContext.Properties.Add(item);                
            }
            Save();
        }

        public void Remove(Property item)
        {
            dBContext.Properties.Remove(item);
            Save();
        }

        public void Remove(IEnumerable<Property> items)
        {
            foreach (var item in items)
            {
                dBContext.Properties.Remove(item);
            }
            Save();
        }

        public void RemoveAtId(int item)
        {
            var property = Get(x => x.Id == item).FirstOrDefault();
            if (property != null)
            {
                dBContext.Properties.Remove(property);
                Save();
            }
        }

        public void Save()
        {
            dBContext.SaveChanges();
        }

        public void Update(Property item)
        {
            dBContext.Entry(item).State = EntityState.Modified;
            Save();
        }
    }
}
