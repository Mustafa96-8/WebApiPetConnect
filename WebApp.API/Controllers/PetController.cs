using Contracts;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApp.Application.Services.IServices;
using WebApp.Domain.Entities;
using WebApp.Domain.ValueObjects;
using WebApp.Infrastracture;

namespace WebApp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PetController(IPetService petService,IValidator<CreatePetRequest> validator) : ControllerBase
    {

        private readonly IPetService _petService = petService;
        private readonly IValidator<CreatePetRequest?> _validator = validator;

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
            var result = await _validator.ValidateAsync(request, ct);

            if (result.IsValid == false) 
            { 
                return BadRequest(result.Errors);
            }


            var idResult = await _petService.Create(request,ct);
            if (idResult.IsFailure)
                return BadRequest(idResult.Error);

            return Ok(idResult.Value);
        }



    }
}
