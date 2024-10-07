using Contracts;
using Microsoft.AspNetCore.Mvc;
using WebApp.API.Contracts;
using WebApp.Application.Services.IServices;
using WebApp.Domain.ValueObjects;
using WebApp.Infrastracture;

namespace WebApp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PetController : ControllerBase
    {

        private readonly IPetService petService; 



        //get http://localhost:port/Pet/1?page=1&size=10
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get([FromRoute] Guid id, [FromQuery] int page, [FromQuery] int? size) 
        {
            if(Guid.Equals(id, Guid.Empty)) {return BadRequest(); }
            var Pet = petService.Get(id);
            return Ok(id);                   
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePetRequest request, CancellationToken ct)
        {
            var address = Address.Create(request.City, request.Street, request.Building, request.Index);
            if (address.IsFailure) 
                return BadRequest(address.Error);
            return Ok();
        }


        
    }
}
