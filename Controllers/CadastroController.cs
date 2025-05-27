using Microsoft.AspNetCore.Mvc;
using Coontrera.Models;
using Coontrera.Data;
using Coontrera.Helpers;
using System;

namespace Coontrera.Controllers
{
    public class CadastroController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IPasswordHasher _passwordHasher;

        public CadastroController(AppDbContext context, IPasswordHasher passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public IActionResult Cadastro() => View();

        [HttpPost]
        public IActionResult Cadastro(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.DataCadastro = DateTime.Now;
                usuario.SenhaHash = _passwordHasher.HashPassword(usuario.Senha);

                _context.Usuarios.Add(usuario);
                _context.SaveChanges();
                return RedirectToAction("Login", "Conta");
            }

            return View(usuario);
        }
    }
}
