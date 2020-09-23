namespace IPAGEBiblioteca.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Classe")]
    public class ClasseModels
    {
        [Key, Display(Name = "Código")]
        public int ID { get ; set; }
        
        [Display(Name = "Descrição")]
        public string Referencia { get; set; }

        [Display(Name = "Idade >")]
        public decimal IdadeInicia { get; set; }

        [Display(Name = "Idade <")]
        public decimal IdadeFinaliza { get; set; }
        public virtual ICollection<TurmaModels> TurmaModels { get; set; }
    }
}