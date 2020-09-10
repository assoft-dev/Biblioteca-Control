using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IPAGEBiblioteca.Models
{
    [Table("Turma")]
    public class TurmaModels: IEntity
    {
        public int ID { get; set; }
        public string Descricao { get; set; }

        [Display(Name = "Classe")]
        public ClasseModels ClasseModels { get; set; }

        // Alunos pertencentes
        public virtual ICollection<AlunoModels> AlunoModels { get; set; }
    }
}