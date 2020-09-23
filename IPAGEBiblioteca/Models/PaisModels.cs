using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IPAGEBiblioteca.Models
{
    [Table("Pais")]
    public class PaisModels
    {
        [Key, Display(Name = "Código")]
        public int ID { get ; set; }

        [Display(Name = "Referência")]
        public string Referencia { get; set; }
        public virtual ICollection<EditoraModels> EditoraModels { get; set; }
    }
}