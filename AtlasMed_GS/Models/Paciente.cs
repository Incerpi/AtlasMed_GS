using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AtlasMed_GS.Models
{
    [Table("TB_PACIENTE")]
    public class Paciente
    {

        [Key]
        public int IdPaciente { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Cpf { get; set; }

        [Required]
        public DateTime DataNascimento { get; set;}

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Telefone { get; set; }

        [Required]
        public string Rua { get; set; }

        [Required]
        public string Numero { get; set; }

        [Required]
        public string Bairro { get; set; }

        [Required]
        public string Cidade { get; set; }

        [Required]
        public string Estado { get; set; }

        [Required]
        public string Cep { get; set; }

    }
}
