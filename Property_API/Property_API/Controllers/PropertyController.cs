using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Property_API.Repository;

namespace Property_API.Controllers
{
    [Route("Property/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyRepository _propertyRepository;

        public PropertyController(IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }

        // GET: Property/Property
        [HttpGet]
        public IActionResult Get()
        {
            return new OkObjectResult(_propertyRepository.GetList());
        }

        // GET: Property/Property/5
        [HttpGet("{id}")]
        public IActionResult Get(int id) //, bool detailed = false)
        {
            //if (detailed)
            return new OkObjectResult(_propertyRepository.GetDetails(id));
            //else
            //    return new OkObjectResult(_propertyRepository.GetById(id));
        }

        // POST: Property/Property
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: Property/Property/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: Property/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
