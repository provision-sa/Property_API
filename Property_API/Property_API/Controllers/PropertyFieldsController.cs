using Microsoft.AspNetCore.Mvc;
using Property_API.Repository;

namespace Property_API.Controllers
{
    [Route("Property/[controller]")]
    [ApiController]
    public class PropertyFieldsController : ControllerBase
    {
        private readonly IUserDefinedGroupRepository _Repo;

        public PropertyFieldsController(IUserDefinedGroupRepository repo)
        {
            _Repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return new OkObjectResult(_Repo.GetFieldList(""));
        }

        [HttpGet("{name}")]
        public IActionResult Get(string name)
        {
            return new OkObjectResult(_Repo.GetFieldList(name));
        }
    }
}
