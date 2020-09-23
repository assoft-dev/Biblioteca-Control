namespace IPAGEBiblioteca.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("User")]
    public class UserModels
    {
        [Key, Display(Name = "Código", Order = 0,  Prompt ="Inf. Interna")]
        public int ID { get; set; }

        [Display(Name = "Usuário", Order = 1,
        Prompt = "Nome Completo"),
        Required()]
        public string UserName { get; set; }

        [Display(Name = "Senha", Order = 2),
        Required()]
        public string Password { get; set; }

        [Display(Name = "Data", Order = 3),
        Required(),
        DataType(DataType.DateTime)]
        public DateTime Data { get; set; }

        [Display(Name = "E-Mail", Order = 4), 
        Required(),
        DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Estado", Order = 5)]
        public bool IsValido { get; set; }


        [Display(Name = "Grupos"), ForeignKey("GruposModels")]
        public virtual  int? GruposModelsID { get; set; }
        public virtual GruposModels GruposModels { get; set; }

        [Display(Name = "Logs")]
        public virtual ICollection<LogsModels> Logs { get; set; }

    }
}
