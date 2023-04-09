using System.Text.Json.Serialization;

namespace APITeste.Models
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }

        [JsonIgnore]
        public List<Produto> Produtos { get; set; } = new List<Produto>();
    }
}
