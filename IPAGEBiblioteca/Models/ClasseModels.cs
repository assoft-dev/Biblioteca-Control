namespace IPAGEBiblioteca.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Classe")]
    public class ClasseModels : IEntity
    {
        public int ID { get ; set; }
        public string Referencia { get; set; }
        public decimal IdadeInicia { get; set; }
        public decimal IdadeFinaliza { get; set; }
        public virtual ICollection<TurmaModels> TurmaModels { get; set; }
    }
}