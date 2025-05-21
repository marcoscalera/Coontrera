using Microsoft.AspNetCore.Mvc;
using Coontrera.Models;
using Coontrera.Data;
using System.Linq;

namespace Coontrera.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly AppDbContext _context;

        public UsuarioController(AppDbContext context)
        {
            _context = context;
        }

        // -------- CRUD DE USUÁRIOS --------

        // READ - Listar todos
        public IActionResult Index()
        {
            var usuarios = _context.Usuarios.ToList();
            return View(usuarios);
        }

        // UPDATE - Formulário
        public IActionResult Editar(int id)
        {
            var usuario = _context.Usuarios.Find(id);
            return View(usuario);
        }

        // UPDATE - Salvar
        [HttpPost]
        public IActionResult Editar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                string novaSenha = Request.Form["Senha"];
                usuario.Senha = novaSenha;

                _context.Usuarios.Update(usuario);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        // DELETE - Formulário de confirmação
        public IActionResult Deletar(int id)
        {
            var usuario = _context.Usuarios.Find(id);
            return View(usuario);
        }

        // DELETE - Confirmar exclusão
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
