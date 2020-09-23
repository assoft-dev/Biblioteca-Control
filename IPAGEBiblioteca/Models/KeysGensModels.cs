namespace IPAGEBiblioteca.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class KeysGensModels
    {
        [Key]
        public int KeysGenID { get; set; }
        public string Key { get; set; }
        public DateTime DataActual { get; set; }
        public DateTime DataFinal { get; set; }
    }
}
