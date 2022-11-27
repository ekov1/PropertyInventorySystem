using API.Mappers;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Models.Requests;
using Services.Interfaces;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("corsPolicy")]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService _ownerService;

        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        [HttpPost]
        public IActionResult Create(CreateOwnerRequest ownerRequest)
        {
            if (this._ownerService.OwnerExists(ownerRequest.PhoneNumber))
            {
              return  new ObjectResult(ownerRequest) { StatusCode = StatusCodes.Status422UnprocessableEntity  };
            }
            var owner = _ownerService.AddOwner(ownerRequest.ToOwner());
            return new ObjectResult(owner) { StatusCode = StatusCodes.Status201Created };
        }

        [HttpPut]
        public IActionResult EditOwner(EditOwnerRequest editOwnerRequest)
        {
            if (!this._ownerService.OwnerExists(editOwnerRequest.Id))
                return NotFound("Wrong id.");

            var ownerResult = _ownerService.EditOwner(editOwnerRequest.ToOwner());
            return Ok(ownerResult);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public ActionResult DeleteOwner(Guid id)
        {
            if (!this._ownerService.OwnerExists(id))
                return NotFound("Wrong id.");

            this._ownerService.Delete(id);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var owners = this._ownerService.GetAll();
            return Ok(owners);
        }

        [HttpGet]
        [Route("GetById/{id:Guid}")]
        public IActionResult GetAll(Guid id)
        {
            var owner = _ownerService.GetById(id);

            if (owner == null)
            {
                return NotFound("Owner is not found.");
            }

            return Ok(owner);
        }
    }
}
