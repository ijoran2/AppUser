using Microsoft.AspNetCore.Mvc;
using Repositorio.modelos;
using Repositorio.Respository;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiEmpleados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IEmpleadosRepository _empleadosRepository;
  

        public UsuariosController(IEmpleadosRepository empleadosRepository)
        {
            _empleadosRepository = empleadosRepository;
        }
        // GET: api/<UsuariosController>
        [HttpGet]
        public async Task <IEnumerable<Usuarios>> GetUsuarios()
        {
            return await _empleadosRepository.Get();
        }
        // GET api/<UsuariosController>/5
        [HttpGet("{Id}")]
        public async Task<Usuarios> GetUsuarios(int Id)
        {
            return await _empleadosRepository.Get(Id);
        }


        // POST api/<UsuariosController>
        [HttpPost]
        public async Task<ActionResult<Usuarios>> PostUsuarios([FromBody] Usuarios usuario)
        {
            var newUsuario = await _empleadosRepository.Create(usuario);
            return CreatedAtAction(nameof(PostUsuarios), new { id = newUsuario.Id }, newUsuario);
        }

        // PUT api/<UsuariosController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutUsuarios(int id, [FromBody] Usuarios usuario)
        {
            if (id != usuario.Id)
            {
                return BadRequest();
            }

            await _empleadosRepository.Update(usuario);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var usuarioToDelete = await _empleadosRepository.Get(id);
            if (usuarioToDelete == null)
                return NotFound();

            await _empleadosRepository.Delete(usuarioToDelete.Id);
            return NoContent();
        }
    }
}
