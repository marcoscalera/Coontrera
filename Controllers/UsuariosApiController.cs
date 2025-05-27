using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Coontrera.Data;
using Coontrera.Models;
using Coontrera.Models.DTOs;
using Coontrera.Helpers;
using System.Linq;

namespace Coontrera.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosApiController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IPasswordHasher _passwordHasher;

        public UsuariosApiController(AppDbContext context, IPasswordHasher passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        // GET: api/UsuariosApi
        [HttpGet]
        public IActionResult GetUsuarios()
        {
            var usuarios = _context.Usuarios
                .Include(u => u.Nivel)
                .ToList()
                .Select(u => new
                {
                    u.Id,
                    u.Nome,
                    u.Telefone,
                    u.DataCadastro,
                    Nivel = u.Nivel != null ? u.Nivel.Nivel : null
                });

            return Ok(usuarios);
        }

        // GET: api/UsuariosApi/5
        [HttpGet("{id}")]
        public IActionResult GetUsuario(int id)
        {
            var usuario = _context.Usuarios
                .Include(u => u.Nivel)
                .Where(u => u.Id == id)
                .Select(u => new
                {
                    u.Id,
                    u.Nome,
                    u.Telefone,
                    u.DataCadastro,
                    Nivel = u.Nivel != null ? u.Nivel.Nivel : null
                })
                .FirstOrDefault();

            if (usuario == null)
                return NotFound();

            return Ok(usuario);
        }

        // POST: api/UsuariosApi
        [HttpPost]
        public IActionResult CriarUsuario([FromBody] UsuarioDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var usuario = new Usuario
            {
                Nome = dto.Nome,
                Descricao = dto.Descricao,
                Telefone = dto.Telefone,
                IdNivel = dto.IdNivel,
                DataCadastro = DateTime.Now,
                SenhaHash = _passwordHasher.HashPassword(dto.Senha)
            };

            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.Id }, new
            {
                usuario.Id,
                usuario.Nome,
                usuario.Telefone
            });
        }

        // PUT: api/UsuariosApi/5
        [HttpPut("{id}")]
        public IActionResult AtualizarUsuario(int id, [FromBody] UsuarioUpdateDTO dto)
        {
            var usuario = _context.Usuarios.Find(id);
            if (usuario == null)
                return NotFound();

            usuario.Nome = dto.Nome;
            usuario.Descricao = dto.Descricao;
            usuario.Telefone = dto.Telefone;
            usuario.IdNivel = dto.IdNivel;
            usuario.PrimeiraAulaRealizada = dto.PrimeiraAulaRealizada;

            _context.Usuarios.Update(usuario);
            _context.SaveChanges();

            return NoContent(); // 204
        }

        // DELETE: api/UsuariosApi/5
        [HttpDelete("{id}")]
        public IActionResult DeletarUsuario(int id)
        {
            var usuario = _context.Usuarios.Find(id);
            if (usuario == null)
                return NotFound();

            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();

            return NoContent(); // 204
        }
    }
}
