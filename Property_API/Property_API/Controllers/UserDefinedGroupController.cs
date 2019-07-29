using Microsoft.AspNetCore.Mvc;
using Property_API.Models;
using Property_API.Repository;
using System.Transactions;

namespace Property_API.Controllers
{
    [Route("Property/[controller]")]
    [ApiController]
    public class UserDefinedGroupController : ControllerBase
    {
        private readonly IUserDefinedGroupRepository _Repo;

        public UserDefinedGroupController(IUserDefinedGroupRepository repo)
        {
            _Repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return new OkObjectResult(_Repo.GetAll());
        }

        //[HttpGet("{type}")]
        //[Route("UserDefinedGroup/:type")]
        //public IActionResult Get(string type)
        //{
        //    PropertyUsageType uType = PropertyUsageType.Both;
        //    switch (type.ToUpper())
        //    {
        //        case "RESIDENTIAL":
        //            uType = PropertyUsageType.Residential;
        //            break;
        //        case "COMMERCIAL":
        //            uType = PropertyUsageType.Commercial;
        //            break;
        //    }

        //    return new OkObjectResult(_Repo.GetDetailed(x => x.UsageType == uType || x.UsageType == PropertyUsageType.Both));
        //}

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return new OkObjectResult(_Repo.GetDetailed(x => x.Id == id));
        }        

        [HttpPost]
        public IActionResult Post([FromBody] UserDefinedGroup userDefinedGroup)
        {
            using (var scope = new TransactionScope())
            {
                _Repo.Insert(userDefinedGroup);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = userDefinedGroup.Id }, userDefinedGroup);
            }
        }
        
        [HttpPut]
        public IActionResult Put([FromBody] UserDefinedGroup userDefinedGroup)
        {
            if (userDefinedGroup != null)
            {
                using (var scope = new TransactionScope())
                {
                    _Repo.Update(userDefinedGroup);
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
