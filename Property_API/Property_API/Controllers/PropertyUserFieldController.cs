using Microsoft.AspNetCore.Mvc;
using Property_API.Models;
using Property_API.Repository;
using System.Transactions;

namespace Property_API.Controllers
{
    [Route("Property/[controller]")]
    [ApiController]
    public class PropertyUserFieldController : ControllerBase
    {
        private readonly IRepository<PropertyUserField> _Repo;

        public PropertyUserFieldController(IRepository<PropertyUserField> repo)
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

        [HttpPost]
        public IActionResult Post([FromBody] PropertyUserField propertyUserField)
        {
            using (var scope = new TransactionScope())
            {
                _Repo.Insert(propertyUserField);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = propertyUserField.Id }, propertyUserField);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] PropertyUserField propertyUserField)
        {
            if (propertyUserField != null)
            {
                using (var scope = new TransactionScope())
                {
                    _Repo.Update(propertyUserField);
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
