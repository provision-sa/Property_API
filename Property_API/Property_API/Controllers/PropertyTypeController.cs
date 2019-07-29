using Microsoft.AspNetCore.Mvc;
using Property_API.Models;
using Property_API.Repository;
using System.Transactions;

namespace Property_API.Controllers
{
    [Route("Property/[controller]")]
    [ApiController]
    public class PropertyTypeController : ControllerBase
    {
        private readonly IRepository<PropertyType> _Repo;

        public PropertyTypeController(IRepository<PropertyType> repo)
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

        [HttpGet("{type}/{typename}")]
        public IActionResult Get(string Type, string TypeName)
        {

            PropertyUsageType type = PropertyUsageType.Both;
            switch(TypeName.ToUpper())
            {
                case "RESIDENTIAL":
                    type = PropertyUsageType.Residential;
                    break;
                case "COMMERCIAL":
                    type = PropertyUsageType.Commercial;
                    break;
            }

            return new OkObjectResult(_Repo.Get(x => x.UsageType == type || x.UsageType == PropertyUsageType.Both));
        }

        [HttpPost]
        public IActionResult Post([FromBody] PropertyType propertyType)
        {
            using (var scope = new TransactionScope())
            {
                _Repo.Insert(propertyType);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = propertyType.Id }, propertyType);
            }
        }
        
        [HttpPut]
        public IActionResult Put([FromBody] PropertyType propertyType)
        {
            if (propertyType != null)
            {
                using (var scope = new TransactionScope())
                {
                    _Repo.Update(propertyType);
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
