using System.ComponentModel.DataAnnotations;

namespace Cinema3.Models
{
    public class Filme
    {
        [Key]
        public int FilmeId { get; set; }
        [Required]
        [Display(Name = "Filme(s)")]
        public string Nome { get; set; }

    }
}
