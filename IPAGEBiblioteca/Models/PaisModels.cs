using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace IPAGEBiblioteca.Models
{
    [Table("Pais")]
    public class PaisModels : IEntity
    {
        public int ID { get ; set; }
        public string Referencia { get; set; }
        public virtual ICollection<EditoraModels> EditoraModels { get; set; }
    }
}