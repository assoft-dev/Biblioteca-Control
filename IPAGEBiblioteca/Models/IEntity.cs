namespace IPAGEBiblioteca.Models
{
    using System.ComponentModel.DataAnnotations;
    public interface IEntity
    {
        [Key, Display(Name = "Código")]
        int ID { get; set; }
    }
}