using Microsoft.AspNetCore.Mvc;
using Coontrera.Data;
using Coontrera.Helpers;
using Coontrera.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies; 


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

        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(string telefone, string senha) 
        {
            if (string.IsNullOrWhiteSpace(telefone) || string.IsNullOrWhiteSpace(senha))
            {
                ViewBag.Erro = "Preencha todos os campos.";
                return View();
            }

            var usuario = _context.Usuarios.FirstOrDefault(u => u.Telefone == telefone.Trim());

            if (usuario != null && _passwordHasher.VerifyPassword(usuario.SenhaHash, senha))
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, usuario.Nome),
                    new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                    new Claim(ClaimTypes.Role, usuario.IdNivel.ToString()) // A Role é o IdNivel
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    // IsPersistent = true, // Para "Lembrar de mim"
                    // ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(60) // Duração da sessão
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                HttpContext.Session.SetInt32("UsuarioId", usuario.Id);
                HttpContext.Session.SetString("UsuarioNome", usuario.Nome);
                HttpContext.Session.SetInt32("UsuarioNivel", usuario.IdNivel);

                return RedirectToAction("Index", "Home");
            }

            ViewBag.Erro = "Telefone ou senha incorretos.";
            return View();
        }

        public async Task<IActionResult> Logout() 
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme); // EXTREMAMENTE NECESSÁRIO: Faz logout do esquema de cookie
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Conta");
        }

        [HttpGet]
        public IActionResult NovaSenha()
        {
            ViewBag.EtapaRedefinicao = 1;
            return View();
        }

        [HttpPost]
        public IActionResult SolicitarRedefinicaoSenha(string email, string telefone)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(telefone))
            {
                ViewBag.Erro = "Preencha os campos de e-mail e telefone.";
                ViewBag.EtapaRedefinicao = 1;
                ViewBag.Email = email;
                ViewBag.Telefone = telefone;
                return View("NovaSenha");
            }

            var usuario = _context.Usuarios.FirstOrDefault(u => u.Email == email.Trim() && u.Telefone == telefone.Trim());

            if (usuario == null)
            {
                ViewBag.Erro = "Usuário não encontrado com o e-mail e telefone fornecidos.";
                ViewBag.EtapaRedefinicao = 1;
                ViewBag.Email = email;
                ViewBag.Telefone = telefone;
                return View("NovaSenha");
            }

            ViewBag.EtapaRedefinicao = 2;
            ViewBag.TelefoneValidado = usuario.Telefone;
            return View("NovaSenha");
        }

        [HttpPost]
        public IActionResult NovaSenha(string telefone, string novaSenha, string confirmarSenha)
        {
            ViewBag.EtapaRedefinicao = 2;
            ViewBag.TelefoneValidado = telefone;

            if (string.IsNullOrWhiteSpace(novaSenha) || string.IsNullOrWhiteSpace(confirmarSenha))
            {
                ViewBag.Erro = "Preencha os campos de nova senha e confirmação.";
                return View("NovaSenha");
            }

            if (novaSenha != confirmarSenha)
            {
                ViewBag.Erro = "As senhas não coincidem.";
                return View("NovaSenha");
            }

            var usuario = _context.Usuarios.FirstOrDefault(u => u.Telefone == telefone.Trim());

            if (usuario == null)
            {
                ViewBag.Erro = "Ocorreu um erro ao identificar o usuário. Tente o processo novamente.";
                ViewBag.EtapaRedefinicao = 1;
                return View("NovaSenha");
            }

            usuario.SenhaHash = _passwordHasher.HashPassword(novaSenha);
            _context.SaveChanges();

            ViewBag.Sucesso = "Senha alterada com sucesso! Você já pode fazer login com sua nova senha.";
            return View("NovaSenha");
        }
        
        [HttpGet]
        public IActionResult Cadastro() => View();

        [HttpPost]
        public IActionResult Cadastro(Usuario usuario)
        {
            ModelState.Remove("Nivel");
            ModelState.Remove("Feedbacks");
            ModelState.Remove("Logs");
            ModelState.Remove("AulasTeste");

            if (ModelState.IsValid)
            {
                if (_context.Usuarios.Any(u => u.Email == usuario.Email || u.Telefone == usuario.Telefone))
                {
                    ModelState.AddModelError("", "Já existe um usuário com este e-mail ou telefone.");
                    return View(usuario);
                }

                usuario.SenhaHash = _passwordHasher.HashPassword(usuario.Senha);
                usuario.DataCadastro = DateTime.Now;

                if (usuario.IdNivel == 0)
                {
                    var nivelPadrao = _context.NiveisUsuario.FirstOrDefault(n => n.Nivel == "Usuário" || n.Nivel == "Aluno");
                    if (nivelPadrao != null)
                    {
                        usuario.IdNivel = nivelPadrao.Id;
                    }
                    else
                    {
                        ModelState.AddModelError("", "Nível de usuário padrão não encontrado.");
                        return View(usuario);
                    }
                }

                _context.Usuarios.Add(usuario);
                _context.SaveChanges();
                return RedirectToAction("Login");
            }
            return View(usuario);
        }

        public IActionResult AcessoNegado()
        {
            return View(); // Crie Views/Conta/AcessoNegado.cshtml
        }
    }
}