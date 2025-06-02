using Microsoft.AspNetCore.Mvc;
using Coontrera.Models;
using Coontrera.Data;
using Coontrera.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization; 

namespace Coontrera.Controllers
{
[Authorize(Roles = "3")] // EXTREMAMENTE NECESSÁRIO: Restringe acesso a todas as actions deste controller para usuários com Role "3"
    public class UsuarioController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IPasswordHasher _passwordHasher;

        public UsuarioController(AppDbContext context, IPasswordHasher passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public IActionResult Index()
        {
            var usuarios = _context.Usuarios.Include(u => u.Nivel).ToList();
            return View(usuarios);
        }

        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = _context.Usuarios.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }
            ViewBag.NiveisUsuario = new SelectList(_context.NiveisUsuario.OrderBy(n => n.Nivel).ToList(), "Id", "Nivel", usuario.IdNivel);
            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(int id, [Bind("Id,Nome,Telefone,Email,IdNivel,PrimeiraAulaRealizada,DataCadastro,SenhaHash")] Usuario formUsuario)
        {
            if (id != formUsuario.Id)
            {
                return NotFound();
            }

            ModelState.Remove("Senha");

            if (ModelState.IsValid)
            {
                try
                {
                    var usuarioParaAtualizar = _context.Usuarios.Find(id);
                    if (usuarioParaAtualizar == null)
                    {
                        return NotFound();
                    }

                    usuarioParaAtualizar.Nome = formUsuario.Nome;
                    usuarioParaAtualizar.Telefone = formUsuario.Telefone;
                    usuarioParaAtualizar.Email = formUsuario.Email;
                    usuarioParaAtualizar.IdNivel = formUsuario.IdNivel;
                    usuarioParaAtualizar.PrimeiraAulaRealizada = formUsuario.PrimeiraAulaRealizada;
                    
                    _context.Update(usuarioParaAtualizar);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Usuarios.Any(e => e.Id == formUsuario.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.NiveisUsuario = new SelectList(_context.NiveisUsuario.OrderBy(n => n.Nivel).ToList(), "Id", "Nivel", formUsuario.IdNivel);
            return View(formUsuario);
        }

        public IActionResult Deletar(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var usuario = _context.Usuarios
                                .Include(u => u.Nivel)
                                .FirstOrDefault(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        [HttpPost, ActionName("Deletar")]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmarDeletar(int id)
        {
            var usuario = _context.Usuarios.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }
            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}