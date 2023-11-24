using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AtlasMed_GS.Models
{
    [Table("TB_MEDICACAO")]

    public class Medicacao
    {

        [Key]
        public int IdMedicacao { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        public string PrincipioAtivo { get; set; }

        [Required]
        public string Dosagem { get; set; }
    }
}
