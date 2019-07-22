using Property_API.Models;
using System.Collections.Generic;

namespace Property_API.Repository
{
    public interface IUserDefinedGroupRepository
    {
        IEnumerable<UserDefinedGroup> GetList();
        UserDefinedGroup GetById(int id);
        void Insert(UserDefinedGroup userDefinedGroup);
        void Delete(int id);
        void Update(UserDefinedGroup userDefinedGroup);
        void Save();
    }
}
