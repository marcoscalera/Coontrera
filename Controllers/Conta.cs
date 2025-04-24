using Microsoft.AspNetCore.Mvc;

namespace SeuProjeto.Controllers
{
    public class ContaController : Controller
    {
        public IActionResult Login() => View();
        public IActionResult Cadastro() => View();
        public IActionResult NovaSenha() => View();
    }
}
