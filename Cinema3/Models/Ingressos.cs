using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema3.Models
{
    public class Ingressos
    {
        [Key]
        public int IngressosId { get; set; }

        [Display(Name =" Nome "), Required]
        public string Nome { get; set; }

        [Range( 1,  11, ErrorMessage = "CPF Inválido")]
        public int? CPF { get; set; }

        [ForeignKey("FilmeId")]
        public virtual Filme Filme { get; set; }    
        
        [Display(Name ="Filmes")]
        public int FilmeId { get; set; }


        [ForeignKey("PeriodoId")]
        public virtual Periodo Periodo { get; set; }

        [Display(Name = "Periodo")]
        public int PeriodoId { get; set; }


        [ForeignKey("SalaId")]
        public virtual Sala Sala { get; set; }

        [Display(Name = "Sala")]
        public int SalaId { get; set; }

        [Required,Display(Name = "Data")]
        public DateTime DataTime { get; set; }

        [Required, Display(Name = "Valor")]
        public double Valor { get; set; }



    }
}
