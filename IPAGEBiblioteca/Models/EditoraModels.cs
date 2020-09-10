using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IPAGEBiblioteca.Models
{
    [Table("Editora")]
    public class EditoraModels : IEntity
    {
        public int ID { get; set; }
        public string Referencia { get; set; }

        [Display(Name = "Pais")]
        public virtual PaisModels Pais { get; set; }
        public virtual ICollection<LivrosModels> LivrosModels { get; set; }
    }
}