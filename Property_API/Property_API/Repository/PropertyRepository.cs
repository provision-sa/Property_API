using Microsoft.EntityFrameworkCore;
using Property_API.Models;
using System.Collections.Generic;
using System.Linq;

namespace Property_API.Repository
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly DBContext dBContext;

        public PropertyRepository(DBContext _dBContext)
        {
            dBContext = _dBContext;
        }        

        public void Delete(int id)
        {
            var property = dBContext.Properties.Find(id);
            if (property != null)
            {
                dBContext.Properties.Remove(property);
                Save();
            }
        }

        public Property GetById(int id)
        {
            return dBContext.Properties.Find(id);
        }

        public Property GetDetails(int id)
        {
            var property = dBContext.Properties.Find(id);
            if (property != null)
            {
                var propertyType = dBContext.PropertyTypes.Find(property.PropertyTypeId);                
                property.DisplayData = new List<PropertyDetailGroup>();

                var groups = (from g in dBContext.UserDefinedGroups
                              where g.UsageType == propertyType.UsageType
                              select g).ToList();

                foreach (UserDefinedGroup uGroup in groups)
                {
                    var groupFields = (from f in dBContext.PropertyUserFields
                                       join uf in dBContext.UserDefinedFields on f.UserDefinedFieldId equals uf.Id
                                       join g in dBContext.UserDefinedGroups on uf.GroupId equals g.Id
                                       where f.PropertyId == property.Id
                                       && g.Id == uGroup.Id
                                       select new { uf.FieldName, f.Value, f.Description }).ToList();

                    if (groupFields.Count > 0)
                    {
                        PropertyDetailGroup detailGroup = new PropertyDetailGroup()
                        {
                            GroupName = uGroup.Description,
                            Values = new List<PropertyDetail>()
                        };
                        
                        foreach(var val in groupFields)
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
            return property;
        }

        public IEnumerable<Property> GetList()
        {
            return dBContext.Properties.ToList();
        }

        public void Insert(Property property)
        {
            dBContext.Properties.Add(property);
            Save();
        }

        public void Save()
        {
            dBContext.SaveChanges();
        }

        public void Update(Property property)
        {
            dBContext.Entry(property).State = EntityState.Modified;
            Save();
        }
    }
}
