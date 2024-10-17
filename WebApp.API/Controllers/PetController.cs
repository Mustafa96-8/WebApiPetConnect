using Contracts;
using Microsoft.AspNetCore.Mvc;
using WebApp.Application.Services.IServices;
using WebApp.Domain.Entities;
using WebApp.Domain.ValueObjects;
using WebApp.Infrastracture;

namespace WebApp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PetController(IPetService petService) : ControllerBase
    {

        private readonly IPetService _petService = petService;

        //get http://localhost:port/Pet/1?page=1&size=10
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get([FromRoute] Guid id, [FromQuery] int page, [FromQuery] int? size) 
        {
            if(Guid.Equals(id, Guid.Empty)) {return BadRequest(); }
            var Pet = _petService.Get(id);
            return Ok(id);                   
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePetRequest request, CancellationToken ct)
        {
            var Pet = _petService.Create();
            return Ok();
        }


        
    }
}
