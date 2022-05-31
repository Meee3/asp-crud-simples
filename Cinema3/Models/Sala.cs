using System.ComponentModel.DataAnnotations;

namespace Cinema3.Models
{
    public class Sala
    {
        [Key]
        public int SalaId { get; set; }
       [Required]
       [Display(Name ="Quantidade de Assentos")]
        public int quantidadeAssentos { get; set; }
    }
}
