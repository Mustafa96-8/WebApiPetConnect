using Microsoft.AspNetCore.Mvc;
using WebApp.API.Contracts;
using WebApp.API.Domain;
using WebApp.Infrastracture;

namespace WebApp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {

        private readonly ApplicationDbContext _context; 



        //get http://localhost:port/Post/1?page=1&size=10
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get([FromRoute] int id, [FromQuery] int page, [FromQuery] int? size) 
        {
            if (id == 0) { return BadRequest(); }
            return Ok(id);                   
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreatePostRequest request, CancellationToken ct)
        {
            var post = new Post(
                request.Name,
                request.Breed,
                request.Weight,
                request.Height,
                request.Vaccine,
                request.BirthDate,
                request.Photo,
                request.Description,
                request.Adress
                );
                  
            _context.Posts.Add(post);
            _context.SaveChanges();
            return Ok();
        }


        
    }
}
