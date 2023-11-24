using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AtlasMed_GS.Models
{
    [Table("TB_MEDICO")]
    public class Medico
    {
        [Key]
        public int IdMedico { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Cpf { get; set; }

        [Required]
        public string Crm { get; set; }

        [Required]
        public string Especialidade { get; set; }

        [ForeignKey("Hospital")]
        public int IdHospital { get; set; }
        public virtual Hospital? Hospital { get; set; }
    }
}
