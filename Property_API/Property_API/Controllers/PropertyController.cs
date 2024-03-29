﻿using Microsoft.AspNetCore.Mvc;
using Property_API.Models;
using Property_API.Repository;
using System.Transactions;

namespace Property_API.Controllers
{
    [Route("Property/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IRepository<Property> _Repo;

        public PropertyController(IRepository<Property> repo)
        {
            _Repo = repo;
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            return new OkObjectResult(_Repo.GetAll());
        }
        
        [HttpGet("{id}")]
        public IActionResult Get(int id) //, bool detailed = false)
        {
            //if (detailed)
            return new OkObjectResult(_Repo.GetDetailed(x => x.Id == id ));
            //else
            //    return new OkObjectResult(_propertyRepository.GetById(id));
        }
        
        [HttpPost]
        public IActionResult Post([FromBody] Property property)
        {
            using (var scope = new TransactionScope())
            {
                _Repo.Update(property);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = property.Id }, property);
            }            
        }
        
        [HttpPut]
        public IActionResult Put([FromBody] Property property)
        {
            if (property != null)
            {
                using (var scope = new TransactionScope())
                {
                    _Repo.Update(property);
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
