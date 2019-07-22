using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Property_API.Repository;

namespace Property_API.Controllers
{
    [Route("PropertyType/[controller]")]
    [ApiController]
    public class PropertyTypeController : ControllerBase
    {
        private readonly IPropertyTypeRepository _propertyTypeRepository;

        public PropertyTypeController(IPropertyTypeRepository propertyTypeRepository)
        {
            _propertyTypeRepository = propertyTypeRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return new OkObjectResult(_propertyTypeRepository.GetList());
        }
        
        [HttpGet("{id}")]
        public IActionResult Get(int id) 
        {            
            return new OkObjectResult(_propertyTypeRepository.GetById(id));
        }

        // POST: api/PropertyType
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/PropertyType/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
