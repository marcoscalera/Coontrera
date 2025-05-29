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

        // Construtor com injeção de dependência
        public UsuariosApiController(AppDbContext context, IPasswordHasher passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        [HttpGet]
        public IActionResult GetUsuarios()
        {
            // Retorna lista de usuários com seus níveis
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
                    Nivel = u.Nivel?.Nivel
                });

            return Ok(usuarios);
        }

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
                    u.Email,
                    u.DataCadastro,
                    Nivel = u.Nivel.Nivel
                })
                .FirstOrDefault(); 

            if (usuario == null)
                return NotFound();

            return Ok(usuario);
        }

        [HttpPost]
        public IActionResult CriarUsuario([FromBody] UsuarioDTO dto)
        {
            // Validação e criação de novo usuário
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Verifica duplicidade de telefone ou email
            if (_context.Usuarios.Any(u => u.Telefone == dto.Telefone || u.Email == dto.Email))
                return Conflict("Telefone ou e-mail já cadastrado.");

            var usuario = new Usuario
            {
                Nome = dto.Nome,
                Telefone = dto.Telefone,
                Email = dto.Email,
                IdNivel = 1, // Nível 1 (Estudante) por padrão
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
            var usuario = _context.Usuarios.Find(id);
            if (usuario == null)
                return NotFound();

            usuario.Nome = dto.Nome;
            usuario.Telefone = dto.Telefone;
            usuario.Email = dto.Email;
            usuario.IdNivel = dto.IdNivel;
            usuario.PrimeiraAulaRealizada = dto.PrimeiraAulaRealizada;

            _context.Usuarios.Update(usuario);
            _context.SaveChanges();

            return NoContent(); // 204
        }

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
