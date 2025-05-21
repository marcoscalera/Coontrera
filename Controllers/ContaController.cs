using Microsoft.AspNetCore.Mvc;
using Coontrera.Data;
using Coontrera.Helpers;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace Coontrera.Controllers
{
    public class ContaController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IPasswordHasher _passwordHasher;

        public ContaController(AppDbContext context, IPasswordHasher passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        // -------- LOGIN E AUTENTICAÇÃO --------
        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(string telefone, string senha)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Telefone == telefone);

            if (usuario != null && _passwordHasher.VerifyPassword(usuario.SenhaHash, senha))
            {
                HttpContext.Session.SetInt32("UsuarioId", usuario.Id);
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Erro = "Telefone ou senha incorretos.";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        // -------- REDEFINIÇÃO DE SENHA --------
        public IActionResult NovaSenha() => View();

        [HttpPost]
        public IActionResult NovaSenha(string telefone, string novaSenha, string confirmarSenha)
        {
            if (novaSenha != confirmarSenha)
            {
                ViewBag.Erro = "As senhas não coincidem.";
                return View();
            }

            var usuario = _context.Usuarios.FirstOrDefault(u => u.Telefone == telefone);

            if (usuario == null)
            {
                ViewBag.Erro = "Usuário não encontrado.";
                return View();
            }

            usuario.SenhaHash = _passwordHasher.HashPassword(novaSenha);
            _context.SaveChanges();

            ViewBag.Sucesso = "Senha alterada com sucesso!";
            return View();
        }

        // -------- CADASTRO (exemplo de criação de usuário) --------
        [HttpGet]
        public IActionResult Cadastro() => View();

        [HttpPost]
        public IActionResult Cadastro(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.SenhaHash = _passwordHasher.HashPassword(usuario.Senha);
                usuario.DataCadastro = DateTime.Now;

                _context.Usuarios.Add(usuario);
                _context.SaveChanges();
                return RedirectToAction("Login");
            }
            return View(usuario);
        }
    }
}
