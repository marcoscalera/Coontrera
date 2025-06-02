using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Coontrera.Data;
using Coontrera.Models;
using Coontrera.Models.DTOs;
using Coontrera.Helpers;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Coontrera.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UsuariosApiController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IPasswordHasher _passwordHasher;

        public UsuariosApiController(AppDbContext context, IPasswordHasher passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        [Authorize(Roles = "3")]
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
                    u.Email,
                    u.DataCadastro,
                    Nivel = u.Nivel != null ? u.Nivel.Nivel : null
                });

            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public IActionResult GetUsuario(int id)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");
            var userNivel = int.Parse(User.FindFirst("role")?.Value ?? "0");

            if (userNivel != 3 && userId != id)
                return Forbid("Você só pode ver seus próprios dados.");

            var usuario = _context.Usuarios
                .Include(u => u.Nivel)
                .Where(u => u.Id == id)
                .Select(u => new
                {
                    u.Id,
                    u.Nome,
                    u.Telefone,
                    u.Email,
                    u.DataCadastro,
                    Nivel = u.Nivel != null ? u.Nivel.Nivel : null
                })
                .FirstOrDefault();

            if (usuario == null)
                return NotFound();

            return Ok(usuario);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult CriarUsuario([FromBody] UsuarioDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (_context.Usuarios.Any(u => u.Telefone == dto.Telefone || u.Email == dto.Email))
                return Conflict("Telefone ou e-mail já cadastrado.");

            var usuario = new Usuario
            {
                Nome = dto.Nome,
                Telefone = dto.Telefone,
                Email = dto.Email,
                IdNivel = 1,
                DataCadastro = DateTime.Now,
                SenhaHash = _passwordHasher.HashPassword(dto.Senha)
            };

            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.Id }, new
            {
                usuario.Id,
                usuario.Nome,
                usuario.Telefone,
                usuario.Email
            });
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarUsuario(int id, [FromBody] UsuarioUpdateDTO dto)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");
            var userNivel = int.Parse(User.FindFirst("role")?.Value ?? "0");

            if (userNivel == 1 && userId != id)
                return Forbid("Você só pode editar seus próprios dados.");

            var usuario = _context.Usuarios.Find(id);
            if (usuario == null)
                return NotFound();

            if (userNivel == 1)
            {
                usuario.Telefone = dto.Telefone;
                usuario.Email = dto.Email;
            }
            else if (userNivel == 3)
            {
                usuario.Nome = dto.Nome;
                usuario.Telefone = dto.Telefone;
                usuario.Email = dto.Email;
                usuario.IdNivel = dto.IdNivel;
                usuario.PrimeiraAulaRealizada = dto.PrimeiraAulaRealizada;
            }

            _context.SaveChanges();
            return NoContent();
        }

        [Authorize(Roles = "3")]
        [HttpDelete("{id}")]
        public IActionResult DeletarUsuario(int id)
        {
            var usuario = _context.Usuarios.Find(id);
            if (usuario == null)
                return NotFound();

            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
