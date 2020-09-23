namespace IPAGEBiblioteca.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Turma")]
    public class TurmaModels
    {
        [Key, Display(Name = "Código")]
        public int ID { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Display(Name = "Classe"), ForeignKey("ClasseModels")]
        public int ClasseModelsID { get; set; }
        public ClasseModels ClasseModels { get; set; }

        // Alunos pertencentes
        public virtual ICollection<AlunoModels> AlunoModels { get; set; }
    }
}