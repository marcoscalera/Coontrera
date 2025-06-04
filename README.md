# Projeto Coontrera - Clínica de Pilates e Fisioterapia

## Descrição

O **Coontrera** é um projeto full-stack desenvolvido em ASP.NET Core MVC e Razor Pages, representando o sistema web para uma clínica de fisioterapia e pilates. A aplicação permite o gerenciamento de usuários, apresentação de serviços, informações sobre a clínica e interação com os clientes, além de uma API para funcionalidades específicas.

O sistema foi construído com foco em uma interface de usuário moderna, responsiva e intuitiva, utilizando Bootstrap 5 e boas práticas de desenvolvimento web.

## Funcionalidades Implementadas

* **Autenticação e Autorização:**
    * Cadastro de novos usuários com atribuição de nível padrão.
    * Login e logout de usuários para a área MVC (utilizando autenticação por Cookies).
    * Autenticação baseada em JWT para a API.
    * Recuperação de senha em duas etapas (validação de e-mail/telefone, seguida pela definição da nova senha).
    * Controle de acesso baseado em Níveis (Roles), com Nível 3 designado para administradores.
    * Página de "Acesso Negado" para usuários autenticados sem permissão para um recurso específico.

* **Painel Administrativo (Gerenciamento de Usuários - Nível 3):**
    * Listagem de todos os usuários cadastrados com seus respectivos níveis.
    * Funcionalidade para editar informações de usuários (Nome, Email, Telefone, Nível, status da primeira aula).
    * Funcionalidade para deletar usuários.

* **Funcionalidades para Usuários/Visitantes:**
    * Página Inicial (`Index.cshtml`) com design de boas-vindas, banner e chamada para ação (Agende sua aula experimental).
    * Página de Serviços (`Servicos.cshtml`) detalhando os tratamentos oferecidos (Fisioterapia, Pilates, Quiropraxia, Hidroterapia, Liberação Miofascial, Dry Needling) com navegação interna e design responsivo.
    * Página Sobre Nós (`SobreNos.cshtml`) com a história da clínica e galeria de imagens.
    * Página Fale Conosco (`FaleConosco.cshtml`) com informações de contato (WhatsApp, Instagram, Localização) e mapa.
    * Formulários de Cadastro e Login com validações e interface aprimorada, incluindo funcionalidade de "mostrar/ocultar senha".

* **API (Exemplo):**
    * Endpoints para gerenciamento de usuários (`UsuariosApiController.cs`) protegidos por JWT e roles.

* **Interface e Usabilidade:**
    * Design responsivo utilizando Bootstrap 5, adaptável a desktops, tablets e celulares.
    * Layout consistente em todas as páginas, utilizando um `_Layout.cshtml` compartilhado com navbar fixa e rodapé informativo.
    * Uso de fontes modernas (Poppins e Playfair Display) e uma paleta de cores coesa definida em CSS (`styles.css`).
    * Animações sutis (AOS - Animate On Scroll) para uma experiência de usuário mais dinâmica.
    * Página de Erro (`Error.cshtml`) amigável.

## Tecnologias Utilizadas

* **Backend:**
    * ASP.NET Core MVC / Razor Pages (C#)
    * Entity Framework Core (para interação com o banco de dados)
    * SQL Server 
    * Autenticação por Cookies (para MVC)
    * Autenticação JWT (para API)
    * Injeção de Dependência

* **Frontend:**
    * HTML5
    * CSS3 (com variáveis CSS e design responsivo)
    * Bootstrap 5
    * JavaScript (para interatividade, como mostrar/ocultar senha e validações)
    * Razor Syntax
    * Font Awesome (para ícones)
    * Google Fonts (Poppins, Playfair Display)
    * AOS (Animate On Scroll) library

* **Ferramentas e Outros:**
    * Visual Studio / VS Code
    * Git / GitHub
    * Swagger (para documentação da API)

## Estrutura do Projeto (Simplificada)
