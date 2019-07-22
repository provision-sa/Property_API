using Property_API.Models;
using System.Collections.Generic;

namespace Property_API.Repository
{
    public interface IPropertyRepository
    {
        IEnumerable<Property> GetList();
        Property GetById(int id);
        Property GetDetails(int id);
        void Insert(Property property);
        void Delete(int id);
        void Update(Property property);
        void Save();
    }
}
