using Cadastro_Usuarios.Interfaces;
using Cadastro_Usuarios.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace Cadastro_Usuarios.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _context;
        private readonly ILogger _logger;

        public UsuarioController(IUsuarioRepository context, ILogger<UsuarioController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
            _logger.LogInformation("Método de listagem realizado com sucesso");
            return Ok(_context.Listar_Todos());
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(usuarioViewModel Usuario_Novo)
        {
            try
            {
            _context.Cadastrar(Usuario_Novo);
            _logger.LogInformation("Usuario Cadastrado com sucesso");

            return StatusCode(201);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(Guid id)
        {
            try
            {
            _context.Delete(id);
            _logger.LogInformation("Método de deletar realizado com sucesso");
            return StatusCode(204);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Editar(usuarioViewModel Usuario_atualizado, Guid id)
        {
            try
            {
            string retorno = _context.Editar(Usuario_atualizado, id);

            if (retorno == "Usuario não encontrado!")
            {
                _logger.LogInformation("Usuario não foi encontrado");
                return BadRequest();
            }

            _logger.LogInformation("Informações alteradas");
            return Ok(retorno);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

    }
}
