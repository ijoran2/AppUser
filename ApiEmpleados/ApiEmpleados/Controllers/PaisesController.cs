using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repositorio.modelos;
using Repositorio.Respository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiEmpleados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisesController : ControllerBase
    {

        private readonly IPaisesRepository _paisiesRepository;


        public PaisesController(IPaisesRepository paisesRepository)
        {
            _paisiesRepository = paisesRepository; 
        }

        // GET: api/<PaisesController>
        [HttpGet]
        public async Task<IEnumerable<Paises>> GetPaises()
        {
            return await _paisiesRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<Paises> GetPaises(int Id)
        {
            return await _paisiesRepository.Get(Id);
        }


        // POST api/<PaisesController>
        [HttpPost]
        public async Task<ActionResult<Paises>> PostPaises([FromBody] Paises pais)
        {
            var newUsuario = await _paisiesRepository.Create(pais);
            return CreatedAtAction(nameof(PostPaises), new { id = newUsuario.Id }, newUsuario);
        }

        // PUT api/<PaisesController>/5
        
        [HttpPut("{id}")]
        public async Task<ActionResult> Putpaises(int id, [FromBody] Paises pais)
        {
            if (id != pais.Id)
            {
                return BadRequest();
            }

            await _paisiesRepository.Update(pais);

            return NoContent();
        }
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var usuarioToDelete = await _paisiesRepository.Get(id);
            if (usuarioToDelete == null)
                return NotFound();

           // await _paisiesRepository.Delete(usuarioToDelete.Id);
            return NoContent();
        }
    }
}
