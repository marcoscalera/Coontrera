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

        // Construtor com injeção de dependência
        public UsuarioController(AppDbContext context, IPasswordHasher passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        // Ação para listar usuários
        public IActionResult Index()
        {
            var usuarios = _context.Usuarios.ToList();
            return View(usuarios);
        }

        // Ação para editar usuário com tratamento de senha
        [HttpPost]
        public IActionResult Editar(int id, [Bind("Nome,Descricao,Telefone,Email,IdNivel,PrimeiraAulaRealizada")] Usuario form)
        {
            var usuario = _context.Usuarios.Find(id);
            if (usuario == null)
                return NotFound();

            if (ModelState.IsValid)
            {
                // Atualiza os dados do usuário
                usuario.Nome = form.Nome;
                usuario.Telefone = form.Telefone;
                usuario.Email = form.Email;
                usuario.IdNivel = form.IdNivel;
                usuario.PrimeiraAulaRealizada = form.PrimeiraAulaRealizada;

                // Atualiza a senha apenas se uma nova for fornecida
                string novaSenha = Request.Form["Senha"];
                if (!string.IsNullOrWhiteSpace(novaSenha))
                {
                    usuario.SenhaHash = _passwordHasher.HashPassword(novaSenha);
                }

                _context.Usuarios.Update(usuario);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(form);
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
