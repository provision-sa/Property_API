using Property_API.Models;
using System.Collections.Generic;

namespace Property_API.Repository
{
    public interface IUserDefinedFieldRepository
    {
        IEnumerable<UserDefinedField> GetList();
        UserDefinedField GetById(int id);
        void Insert(UserDefinedField userDefinedField);
        void Delete(int id);
        void Update(UserDefinedField userDefinedField);
        void Save();
    }
}
