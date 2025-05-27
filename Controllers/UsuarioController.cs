using Microsoft.AspNetCore.Mvc;
using Coontrera.Models;
using Coontrera.Data;
using Coontrera.Helpers;
using System.Linq;

namespace Coontrera.Controllers
{
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
            var usuarios = _context.Usuarios.ToList();
            return View(usuarios);
        }

        public IActionResult Editar(int id)
        {
            var usuario = _context.Usuarios.Find(id);
            return View(usuario);
        }

        [HttpPost]
        public IActionResult Editar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                string novaSenha = Request.Form["Senha"];
                usuario.SenhaHash = _passwordHasher.HashPassword(novaSenha);

                _context.Usuarios.Update(usuario);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        public IActionResult Deletar(int id)
        {
            var usuario = _context.Usuarios.Find(id);
            return View(usuario);
        }

        [HttpPost, ActionName("Deletar")]
        public IActionResult ConfirmarDeletar(int id)
        {
            var usuario = _context.Usuarios.Find(id);
            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
