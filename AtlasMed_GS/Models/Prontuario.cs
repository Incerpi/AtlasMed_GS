using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AtlasMed_GS.Models
{
    [Table("TB_PRONTUARIO")]
    public class Prontuario
    {
        [Key]
        public int IdProntuario { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        public string Diagnostico { get; set; }

        [Required]
        public string Alergias { get; set; }

        [ForeignKey("Medicacao")]
        public int IdMedicacao { get; set; }
        public virtual Medicacao? Medicacao { get; set; }


    }
}
