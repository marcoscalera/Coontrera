﻿using Microsoft.AspNetCore.Mvc;
using Coontrera.Models;
using Coontrera.Models.DTOs;
using Coontrera.Data;
using Coontrera.Helpers;

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
        [ValidateAntiForgeryToken]
        public IActionResult Cadastro(UsuarioDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            if (_context.Usuarios.Any(u => u.Email == dto.Email || u.Telefone == dto.Telefone))
            {
                ModelState.AddModelError("", "Já existe um usuário com este e-mail ou telefone.");
                return View(dto);
            }

            var nivelPadrao = _context.NiveisUsuario.FirstOrDefault(n => n.Nivel == "Usuário" || n.Nivel == "Aluno");
            
            if (nivelPadrao == null)
            {
                ModelState.AddModelError("", "Nível padrão de usuário não está configurado no sistema. Por favor, contate o suporte.");
                return View(dto);
            }

            var usuario = new Usuario
            {
                Nome = dto.Nome,
                Telefone = dto.Telefone,
                Email = dto.Email,
                SenhaHash = _passwordHasher.HashPassword(dto.Senha),
                DataCadastro = DateTime.Now,
                IdNivel = nivelPadrao.Id
            };

            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            TempData["CadastroSucesso"] = true;
            return RedirectToAction("Login", "Conta");
        }
    }
}