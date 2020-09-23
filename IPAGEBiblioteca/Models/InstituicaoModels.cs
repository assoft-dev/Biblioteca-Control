namespace IPAGEBiblioteca.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Instituicao")]
    public class InstituicaoModels
    {
        [Key, Display(Name = "Código")]
        public int ID { get; set; }

        [Display(Name = "Descrição")]
        public string Referencia { get; set; }
        public virtual ICollection<AlunoModels> AlunoModels { get; set; }
    }
}