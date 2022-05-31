using System.ComponentModel.DataAnnotations;

namespace Cinema3.Models
{
    public class Periodo
    {
        [Key]
        public int PeriodoId { get; set; }

        [Required]
        [Display(Name = "Manhã / Tarde / Noite")]
        public string PeriodoTurno { get; set; }
    }
}
