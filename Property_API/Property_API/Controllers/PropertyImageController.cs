using Microsoft.AspNetCore.Mvc;
using Property_API.Models;
using Property_API.Repository;
using System.Transactions;

namespace Property_API.Controllers
{
    [Route("Property/[controller]")]
    [ApiController]
    public class PropertyImageController : ControllerBase
    {
        private readonly IPropertyImageRepository _Repo;

        public PropertyImageController(IPropertyImageRepository repo)
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

        [HttpGet("{Property}/{PropertyId}", Name ="GetImagesByProperty")]
        public IActionResult Get(string Property, int PropertyId) //Property string is more of a placeholder here.
        {            
            return new OkObjectResult(_Repo.GetImages(PropertyId));
        }

        [HttpPost]
        public IActionResult Post([FromBody] PropertyImage propertyImage)
        {
            using (var scope = new TransactionScope())
            {
                _Repo.Insert(propertyImage);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = propertyImage.Id }, propertyImage);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] PropertyImage propertyImage)
        {
            if (propertyImage != null)
            {
                using (var scope = new TransactionScope())
                {
                    _Repo.Update(propertyImage);
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
