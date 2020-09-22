using System;
using Microsoft.AspNetCore.Mvc;
using RoofStock.CodingExercise.Api.Models;
using RoofStock.CodingExercise.Api.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RoofStock.CodingExercise.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private IPropertyService _propertyService;

        public PropertyController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        [HttpGet("{id}")]
        public async Task<string> GetByGuid(Guid id)
        {
            var r = await _propertyService.GetByGuid(id);
            var json = JsonConvert.SerializeObject(r);

            return json;
        }

        [HttpGet]
        public async Task<string> Get()
        {
            var r = await _propertyService.GetAll();

            var json = JsonConvert.SerializeObject(r);

            return json;
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] PropertyModel property)
        {
            var r = await _propertyService.Update(property);

            if (r)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _propertyService.Delete(id);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PropertyModel property)
        {
            var r = await _propertyService.Create(property);

            if (r)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}