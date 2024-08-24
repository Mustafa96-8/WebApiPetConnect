using Microsoft.AspNetCore.Mvc;
using WebApp.API.Contracts;
using WebApp.Infrastracture;

namespace WebApp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PetController : ControllerBase
    {

        private readonly IPetService _context; 



        //get http://localhost:port/Pet/1?page=1&size=10
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get([FromRoute] int id, [FromQuery] int page, [FromQuery] int? size) 
        {
            if (id == 0) { return BadRequest(); }
            return Ok(id);                   
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreatePetRequest request, CancellationToken ct)
        {
            /*var pet = new Pet(
                )
                  
            _context.Pets.Add(post);
            _context.SaveChanges();*/
            return Ok();
        }


        
    }
}
