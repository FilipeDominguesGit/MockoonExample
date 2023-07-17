using Microsoft.AspNetCore.Mvc;
using MockoonExample.Service.Infrastructure;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MockoonExample.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {

        private IPetShopClient _petShopClient;

        public PetsController(IPetShopClient petShopClient)
        {
            _petShopClient = petShopClient;
        }

        // GET api/<PetsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var pet = await _petShopClient.GetPetByIdAsync(id);
            return Ok(pet);
        }

        // POST api/<PetsController>    
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Pet pet)
        {
            var response = await _petShopClient.CreatePetAsync(pet);
            return CreatedAtAction(nameof(Get), new { id = response.Id }, response);
        }
    }
}
