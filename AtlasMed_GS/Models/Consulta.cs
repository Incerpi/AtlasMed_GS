using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AtlasMed_GS.Models
{
    [Table("TB_CONSULTA")]
    public class Consulta
    {

        [Key]
        public int IdConsulta { get; set; }

        [ForeignKey("Paciente")]
        public int IdPaciente { get; set; }
        public virtual Paciente? Paciente { get; set; }

        [ForeignKey("Medico")]
        public int IdMedico { get; set; }
        public virtual Medico? Medico { get; set; }

        [ForeignKey("Prontuario")]
        public int IdProntuario { get; set; }
        public virtual Prontuario? Prontuario { get; set; }

        [ForeignKey("Hospital")]
        public int IdHospital { get; set; }
        public virtual Hospital? Hospital { get; set; }

        [Required]
        public DateTime Horario { get; set; }

    }
}
