using API.Mappers;
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
        private readonly IPropertyOwnerService _propertyOwnerService;

        public PropertyController(IPropertyOwnerService propertyOwnerService)
        {
            this._propertyOwnerService = propertyOwnerService;
        }

        [HttpPost]
        public IActionResult Create(CreatePropertyRequest createPropertyRequest)
        {
            var property = _propertyOwnerService.CreateProperty(createPropertyRequest.ToProperty());
            return new ObjectResult(property) { StatusCode = StatusCodes.Status201Created };
        }

        //[HttpPost]
        //[Route("search")]
        //public IActionResult GetAll()
        //{
        //    var owners = this._ownerService.GetAll();
        //    return Ok(owners);
        //}
    }
}
