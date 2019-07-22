using Property_API.Models;
using System.Collections.Generic;

namespace Property_API.Repository
{
    public interface IPropertyTypeRepository
    {
        IEnumerable<PropertyType> GetList();
        IEnumerable<PropertyType> GetListOf(PropertyUsageType propertyUsage);
        PropertyType GetById(int id);
        void Insert(PropertyType propertyType);
        void Delete(int id);
        void Update(PropertyType propertyType);
        void Save();
    }
}
