namespace Coontrera.Models.DTOs
{
    public class UsuarioUpdateDTO
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Telefone { get; set; }
        public int IdNivel { get; set; }
        public bool PrimeiraAulaRealizada { get; set; }
    }
}
