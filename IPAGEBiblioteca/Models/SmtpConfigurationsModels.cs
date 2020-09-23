using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IPAGEBiblioteca.Models
{
    [Table("SmtpConfigurations")]
    public class SmtpConfigurationsModels
    {
        [Key, Display(Name = "Código")]
        public int ID { get; set; }

        [Display(Name = "E-Mail")]
        public string MailSender { get; set; }

        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Provedor")]
        public string Host { get; set; }

        [Display(Name = "Porta")]
        public int Port { get; set; }

        public bool Ssl { get; set; }
        public TimeSpan Hora1 { get; set; }
        public TimeSpan Hora2 { get; set; }

        public bool Activo { get; set; }
    }
}
