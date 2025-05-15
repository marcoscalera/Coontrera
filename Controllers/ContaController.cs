using Microsoft.AspNetCore.Mvc;
using Coontrera.Models; // Modelos como Usuario
using Coontrera.Data;   // DbContext
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace Coontrera.Controllers
{
    public class ContaController : Controller
    {
        private readonly AppDbContext _context;

        public ContaController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Conta/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Conta/Login
        [HttpPost]
        public IActionResult Login(string telefone, string senha)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Telefone == telefone);

            if (usuario != null && usuario.VerificarSenha(senha))
            {
                HttpContext.Session.SetInt32("UsuarioId", usuario.Id); // guarda o id na sessão
                return RedirectToAction("Index", "Home"); // redireciona para a página principal
            }

            ViewBag.Erro = "Telefone ou senha incorretos.";
            return View();
        }

        // GET: /Conta/Cadastro
        public IActionResult Cadastro()
        {
            return View();
        }

        // POST: /Conta/Cadastro
        [HttpPost]
        public IActionResult Cadastro(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                // Recebe a senha digitada do formulário
                string senhaDigitada = Request.Form["Senha"];

                usuario.DataCadastro = DateTime.Now;
                usuario.Senha = senhaDigitada; // Isso aciona o setter e aplica o hash com salt

                _context.Usuarios.Add(usuario);
                _context.SaveChanges();

                return RedirectToAction("Login");
            }

            return View(usuario);
        }

        // POST: /Conta/NovaSenha
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

            usuario.Senha = novaSenha; // seta o hash da nova senha
            _context.SaveChanges();

            ViewBag.Sucesso = "Senha alterada com sucesso!";
            return View();
        }
    }
}
