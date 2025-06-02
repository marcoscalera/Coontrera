using Microsoft.AspNetCore.Mvc;
using Coontrera.Models;
using Coontrera.Data;
using Coontrera.Helpers; // Seu IPasswordHasher está aqui
using System.Linq;
using Microsoft.EntityFrameworkCore; // Adicionado para .Include()
using Microsoft.AspNetCore.Mvc.Rendering; // Adicionado para SelectList

namespace Coontrera.Controllers
{
    // TODO: Adicionar [Authorize] aqui se o acesso a estas funcionalidades for restrito
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

        // GET: Usuario
        // Ação para listar usuários
        public IActionResult Index()
        {
            // Modificado para incluir o Nível do usuário na listagem
            var usuarios = _context.Usuarios.Include(u => u.Nivel).ToList();
            return View(usuarios);
        }

        // GET: Usuario/Editar/5
        // Nova action para exibir o formulário de edição
        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = _context.Usuarios.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }

            // Popula o ViewBag com a lista de NiveisUsuario para o dropdown
            // O terceiro parâmetro (usuario.IdNivel) pré-seleciona o nível atual do usuário
            ViewBag.NiveisUsuario = new SelectList(_context.NiveisUsuario.OrderBy(n => n.Nivel).ToList(), "Id", "Nivel", usuario.IdNivel);
            return View(usuario);
        }

        // POST: Usuario/Editar/5
        // Ação para editar usuário com tratamento de senha
        [HttpPost]
        [ValidateAntiForgeryToken] // Adicionado para segurança
        public IActionResult Editar(int id, [Bind("Id,Nome,Telefone,Email,IdNivel,PrimeiraAulaRealizada,DataCadastro,SenhaHash")] Usuario formUsuario)
        // O Bind foi atualizado para incluir Id, DataCadastro e SenhaHash para evitar que sejam perdidos ou zerados,
        // mas não diretamente editáveis pelo usuário no formulário principal (exceto os campos permitidos).
        {
            if (id != formUsuario.Id)
            {
                return NotFound();
            }

            // Validação do ModelState
            // Removendo validação da Senha se não for obrigatória na edição ou se for tratada separadamente
            ModelState.Remove("Senha"); // Se Senha não é editada aqui ou é opcional

            if (ModelState.IsValid)
            {
                try
                {
                    // Busca o usuário existente no banco para atualizar apenas os campos necessários
                    // e para não perder dados que não vêm do formulário (como SenhaHash se não alterada).
                    var usuarioParaAtualizar = _context.Usuarios.Find(id);
                    if (usuarioParaAtualizar == null)
                    {
                        return NotFound();
                    }

                    // Atualiza os dados do usuário com base no que veio do formulário
                    usuarioParaAtualizar.Nome = formUsuario.Nome;
                    usuarioParaAtualizar.Telefone = formUsuario.Telefone;
                    usuarioParaAtualizar.Email = formUsuario.Email;
                    usuarioParaAtualizar.IdNivel = formUsuario.IdNivel;
                    usuarioParaAtualizar.PrimeiraAulaRealizada = formUsuario.PrimeiraAulaRealizada;
                    // DataCadastro e SenhaHash são mantidos do formUsuario (que os carregou via hidden fields da action GET)
                    // ou do usuarioParaAtualizar se não vierem no bind.
                    // A forma mais segura é carregar o usuarioParaAtualizar e atualizar campo a campo.

                    // Atualiza a senha apenas se uma nova for fornecida
                    // Esta lógica estava comentada no seu código original
                    // Se você adicionar um campo de senha na view Editar.cshtml, pode usar:
                    // string novaSenha = Request.Form["NovaSenha"]; // Ou um campo específico no modelo
                    // if (!string.IsNullOrWhiteSpace(novaSenha))
                    // {
                    //     usuarioParaAtualizar.SenhaHash = _passwordHasher.HashPassword(novaSenha);
                    // }

                    _context.Update(usuarioParaAtualizar); // Usa _context.Update() para entidades rastreadas
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Usuarios.Any(e => e.Id == formUsuario.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            // Se o ModelState não for válido, repopula o ViewBag para o dropdown e retorna a view com os erros
            ViewBag.NiveisUsuario = new SelectList(_context.NiveisUsuario.OrderBy(n => n.Nivel).ToList(), "Id", "Nivel", formUsuario.IdNivel);
            return View(formUsuario); // Retorna o modelo original com os erros de validação
        }


        // GET: Usuario/Deletar/5
        public IActionResult Deletar(int id)
        {
            if (id == 0) // Ou if (id == null) se for int?
            {
                return NotFound();
            }
            // Modificado para incluir o Nível do usuário na página de confirmação
            var usuario = _context.Usuarios
                                .Include(u => u.Nivel) // Inclui o Nível
                                .FirstOrDefault(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuario/Deletar/5
        [HttpPost, ActionName("Deletar")]
        [ValidateAntiForgeryToken] // Adicionado para segurança
        public IActionResult ConfirmarDeletar(int id) // Nome da action ConfirmarDeletar
        {
            var usuario = _context.Usuarios.Find(id);
            if (usuario == null)
            {
                return NotFound(); // Ou RedirectToAction("Index") com uma mensagem de erro
            }

            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}