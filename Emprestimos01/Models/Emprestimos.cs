using System.ComponentModel.DataAnnotations;

namespace Emprestimos01.Models
{
    public class Emprestimos
    {

        [Key]
        public int EmprestimoId { get; set; }

        public double valorSolicitado { get; set; }

        public double valorEntrada { get; set; }
    }
}
