namespace IPAGEBiblioteca.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Logs")]
    public class LogsModels
    {
        [Key, Display(Name = "Código")]
        public int ID { get; set; }

        [Display(Name = "Referência")]
        public string Referencia { get; set; }

        [Display(Name = "Data/horas"), DataType(DataType.DateTime)]
        public DateTime DateTime { get; set; }

        [Display(Name = "Usuarios"), ForeignKey("userModels")]
        public virtual int? userModelsID { get; set; }
        public virtual UserModels userModels { get; set; }
    }
}