using Microsoft.AspNetCore.Mvc;
using Coontrera.Models;
using Coontrera.Data;
using System;

namespace Coontrera.Controllers
{
    public class CadastroController : Controller
    {
        private readonly AppDbContext _context;

        public CadastroController(AppDbContext context)
        {
            _context = context;
        }

        // -------- CADASTRO --------

        public IActionResult Cadastro() => View();

        [HttpPost]
        public IActionResult Cadastro(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                string senhaDigitada = Request.Form["Senha"];
                usuario.DataCadastro = DateTime.Now;
                usuario.Senha = senhaDigitada;

                _context.Usuarios.Add(usuario);
                _context.SaveChanges();
                return RedirectToAction("Login", "Conta");
            }

            return View(usuario);
        }
    }
}
