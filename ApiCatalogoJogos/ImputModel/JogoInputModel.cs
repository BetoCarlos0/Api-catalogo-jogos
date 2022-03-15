using System.ComponentModel.DataAnnotations;

namespace ApiCatalogoJogos.ImputModel
{
    public class JogoInputModel
    {
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Nome Jogo menor que 3 caracteres")]
        public string Nome { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Nome Produtora menor que 3 caracteres")]
        public string Produtora { get; set; }
        [Required]
        [Range(1, 1000, ErrorMessage = "Preço entre R$ 1 e R$ 1.000")]
        public double Preco { get; set; }
    }
}
