using API.Mappers;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Models.Requests;
using Services.Interfaces;
using Services.Services;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyService _propertyService;

        public PropertyController(IPropertyService propertyService)
        {
            this._propertyService = propertyService;
        }

        [HttpPost]
        public IActionResult Create(CreatePropertyRequest createPropertyRequest)
        {
            var property = _propertyService.CreateProperty(createPropertyRequest.ToProperty());
            return new ObjectResult(property) { StatusCode = StatusCodes.Status201Created };
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public ActionResult DeleteOwner(Guid id)
        {
            if (!this._propertyService.PropertyExists(id))
                return NotFound("Wrong id.");

            this._propertyService.Delete(id);
            return Ok();
        }

        [HttpPost]
        [Route("search/{phoneNumber}")]
        public IActionResult GetAll(string phoneNumber)
        {
            var properties = this._propertyService.GetByPhoneNumber(phoneNumber);
            return Ok(properties);
        }
    }
}
