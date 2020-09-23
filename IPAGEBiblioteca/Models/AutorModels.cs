namespace IPAGEBiblioteca.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Autor")]
    public class AutorModels
    {
        [Key, Display(Name = "Código")]
        public int ID { get ; set; }
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public DateTime DataNascimento { get; set; }
        public virtual ICollection<LivrosModels> LivrosModels { get; set; }
    }
}