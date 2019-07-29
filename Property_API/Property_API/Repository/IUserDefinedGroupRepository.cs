using Property_API.Models;
using System.Collections.Generic;

namespace Property_API.Repository
{
    public interface IUserDefinedGroupRepository : IRepository<UserDefinedGroup>
    {
        List<Group> GetFieldList(string name);
    }
}
