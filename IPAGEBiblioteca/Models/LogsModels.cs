namespace IPAGEBiblioteca.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Logs")]
    public class LogsModels : IEntity
    {
        public int ID { get; set; }
        public string Referencia { get; set; }
        public DateTime DateTime { get; set; }

        [Display(Name = "Usuarios")]
        public virtual UserModels userModels { get; set; }
    }
}