using Microsoft.AspNetCore.Mvc;
using Coontrera.Models; // Adicionado para Usuario
using Coontrera.Models.DTOs;
using Coontrera.Data;
using Coontrera.Helpers;
using System;
using System.Linq;

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

        // GET: /Cadastro/Cadastro
        public IActionResult Cadastro() => View();

        // POST: /Cadastro/Cadastro
        [HttpPost]
        [ValidateAntiForgeryToken] // Adicionado para segurança
        public IActionResult Cadastro(UsuarioDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            // Verifica duplicidade de e-mail ou telefone
            if (_context.Usuarios.Any(u => u.Email == dto.Email || u.Telefone == dto.Telefone))
            {
                ModelState.AddModelError("", "Já existe um usuário com este e-mail ou telefone.");
                return View(dto);
            }

            // Busca nível padrão "Usuário" ou "Aluno"
            var nivelPadrao = _context.NiveisUsuario.FirstOrDefault(n => n.Nivel == "Usuário" || n.Nivel == "Aluno");
            if (nivelPadrao == null)
            {
                // Se não encontrar, cria um nível padrão "Usuário" para evitar erro crítico.
                // Em um cenário ideal, os níveis seriam pré-cadastrados (semeados no banco).
                nivelPadrao = new NivelUsuario { Nivel = "Usuário", Descricao = "Usuário padrão do sistema" };
                _context.NiveisUsuario.Add(nivelPadrao);
                // Não é necessário SaveChanges aqui se o usuário for salvo depois e o IdNivel for atribuído.
                // Se o usuário não for salvo, ou se houver falha, este nível não persistirá isoladamente.
                // Melhor garantir que os níveis existam no banco de dados independentemente.
                // Para este exemplo, vamos assumir que se não existir, criamos e usamos o ID gerado ao salvar o usuário.
                // Ou, uma abordagem mais segura:
                // _context.SaveChanges(); // Salva o novo nível para obter um ID.
                // Se não encontrar, pode ser um erro de configuração do sistema.
                ModelState.AddModelError("", "Nível padrão de usuário não configurado no sistema. Contate o suporte.");
                return View(dto);
            }

            var usuario = new Usuario
            {
                Nome = dto.Nome,
                Telefone = dto.Telefone,
                Email = dto.Email,
                SenhaHash = _passwordHasher.HashPassword(dto.Senha),
                DataCadastro = DateTime.Now, // Data de cadastro é definida aqui
                IdNivel = nivelPadrao.Id // Associa ao nível padrão encontrado ou criado
            };

            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            // Define TempData para exibir o modal de sucesso na página de login
            TempData["CadastroSucesso"] = true;

            // Redireciona para a página de Login no ContaController
            return RedirectToAction("Login", "Conta");
        }
    }
}