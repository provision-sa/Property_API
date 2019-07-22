using Property_API.Models;
using System.Collections.Generic;

namespace Property_API.Repository
{
    public interface IPropertyUserFieldRepository
    {
        IEnumerable<PropertyUserField> GetList();
        PropertyUserField GetById(int id);
        void Insert(PropertyUserField propertyUserField);
        void Delete(int id);
        void Update(PropertyUserField propertyUserField);
        void Save();
    }
}
