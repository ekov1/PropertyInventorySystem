using API.Mappers;
using Microsoft.AspNetCore.Mvc;
using Models.Requests;
using Services.Interfaces;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        public ActionResult DeleteOwner(Guid ownerId)
        {
            if (!this._ownerService.OwnerExists(ownerId))
                return NotFound("Wrong id.");

            this._ownerService.Delete(ownerId);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var owners = this._ownerService.GetAll();
            return Ok(owners);
        }

        //[HttpGet]
        //[Route("GetById/{id}")]
        //public IActionResult GetAll(Guid ownerId)
        //{
        //    var owner = _ownerService.GetById(ownerId);

        //    if (owner == null)
        //    {
        //        return NotFound("Owner is not found.");
        //    }

        //    return Ok(owner);
        //}
    }
}
