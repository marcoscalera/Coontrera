using Microsoft.AspNetCore.Mvc;

namespace Coontrera.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
        public IActionResult SobreNos() => View();
        public IActionResult Servicos() => View();
        public IActionResult FaleConosco() => View();
    }
}
