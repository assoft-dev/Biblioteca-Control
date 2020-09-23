using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IPAGEBiblioteca.Models
{
    [Table("Editora")]
    public class EditoraModels
    {
        [Key, Display(Name = "Código")]
        public int ID { get; set; }
        public string Referencia { get; set; }

        [Display(Name = "Pais"), ForeignKey("Pais")]
        public int PaisID { get; set; }
        public virtual PaisModels Pais { get; set; }
        public virtual ICollection<LivrosModels> LivrosModels { get; set; }
    }
}