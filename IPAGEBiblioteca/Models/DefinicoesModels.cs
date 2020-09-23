using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IPAGEBiblioteca.Models
{
    [Table("Definicoes")]
    public class DefinicoesModels
    {
        [Key]
        [Display(Name = "Código")]
        public int ID { get; set; }

        [Display(Name = "Título", GroupName = "Inf. Empresa", Order = 1, Prompt = "Titulo"), Required(ErrorMessage = "Título da Empresa")]
        public string DefinicoesTitulo { get; set; }

        [StringLength(200)]
        [Display(Name = "Identificação Fiscal", GroupName = "Inf. Empresa", Order = 1, Prompt = "Actividade"), Required(ErrorMessage = "Actividade da Empresa")]
        public string NIF { get; set; }

        [StringLength(400)]
        [Display(Name = "Telemovel")]
        public string Telemovel { get; set; }

        [Display(Name = "Rua")]
        [Required(ErrorMessage = "Este campo {0} é necessário")]
        public string Rua { get; set; }

        [StringLength(400)]
        [Display(Name = "E-Mail")]
        [Required(ErrorMessage = "Este campo {0} é necessário")]
        public string Email { get; set; }

        [StringLength(400)]
        [Display(Name = "Ramo")]
        [Required(ErrorMessage = "Este campo {0} é necessário")]
        public string Ramo { get; set; }

        [StringLength(400)]
        [Display(Name = "Banco 1")]
        public string Banco_1 { get; set; }

        [StringLength(400)]
        [Display(Name = "Banco 2")]
        public string Banco_2 { get; set; }

        [StringLength(400)]
        [Display(Name = "Banco 3")]
        public string Banco_3 { get; set; }

        [StringLength(400)]
        [Display(Name = "Banco 4")]
        public string Banco_4 { get; set; }

        [StringLength(400)]
        [Display(Name = "Rodape")]
        public string Outros { get; set; }

        [Display(Name = "Imagem Referências")]
        public string Photos { get; set; }

        [Display(Name = "Imagem Faturas")]
        public byte[] Photos_Desk1 { get; set; }


        [Display(Name = "WebSite")]
        public string WebSite { get; set; }

        [Display(Name = "Fax")]
        public string Fax { get; set; }

        [Display(Name = "Região (Localização)")]
        public string Regiao { get; set; }
    }
}
