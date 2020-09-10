namespace IPAGEBiblioteca.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Instituicao")]
    public class InstituicaoModels: IEntity
    {
        public int ID { get; set; }
        public string Referencia { get; set; }

        public virtual ICollection<AlunoModels> AlunoModels { get; set; }
    }
}