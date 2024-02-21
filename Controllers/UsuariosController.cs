using APIUsuarios.DAO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIUsuarios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        [HttpGet]
        [Route("listar")]
        public IActionResult Listar()
        {
            var dao = new UsuarioDAO();
            var usuarios = dao.ListarUsuarios();
            return Ok(usuarios);
        }
    }
}
