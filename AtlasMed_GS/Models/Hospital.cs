using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtlasMed_GS.Models
{

    [Table("TB_HOSPITAL")]
    public class Hospital
    {
        [Key]
        public int IdHospital { get; set; }

        [Required]
        public string Nome { get; set; }

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

