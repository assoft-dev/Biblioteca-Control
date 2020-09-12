﻿namespace IPAGEBiblioteca.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("User")]
    public class UserModels: IEntity
    {
        [Display(Name = "Código")]
        public int ID { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
        public DateTime Data { get; set; }

        [Display(Name = "E-Mail"), Required()]
        public string Email { get; set; }

        [Display(Name = "Estado")]
        public bool IsValido { get; set; }

        [Display(Name = "Grupos")]
        public virtual GruposModels GruposModels { get; set; }

        [Display(Name = "Logs")]
        public virtual ICollection<LogsModels> Logs { get; set; }

    }
}
