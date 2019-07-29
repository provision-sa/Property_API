using Microsoft.AspNetCore.Mvc;
using Property_API.Models;
using Property_API.Repository;
using System.Transactions;

namespace Property_API.Controllers
{
    [Route("Property/[controller]")]
    [ApiController]
    public class UserDefinedFieldController : ControllerBase
    {
        private readonly IRepository<UserDefinedField> _Repo;

        public UserDefinedFieldController(IRepository<UserDefinedField> repo)
        {
            _Repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return new OkObjectResult(_Repo.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return new OkObjectResult(_Repo.GetDetailed(x => x.Id == id));
        }

        [HttpGet("{group}/{id}")]
        public IActionResult Get(string group, int id)
        {
            return new OkObjectResult(_Repo.Get(x => x.GroupId == id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] UserDefinedField userDefinedField)
        {
            using (var scope = new TransactionScope())
            {
                _Repo.Insert(userDefinedField);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = userDefinedField.Id }, userDefinedField);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] UserDefinedField userDefinedField)
        {
            if (userDefinedField != null)
            {
                using (var scope = new TransactionScope())
                {
                    _Repo.Update(userDefinedField);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _Repo.RemoveAtId(id);
            return new OkResult();
        }
    }
}
