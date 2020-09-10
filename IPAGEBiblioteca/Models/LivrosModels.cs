using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading;

namespace IPAGEBiblioteca.Models
{
    [Table("Livros")]
    public class LivrosModels: IEntity
    {
        public int ID { get; set; }
        public string Referencia { get; set; }
        public string Comentarios { get; set; }
        public string SBN { get; set; }
        public string Edicao { get; set; }
        public int AnoLancamento { get; set; }

        [Display(Name = "Editora")]
        public virtual EditoraModels EditoraModels { get; set; }

        [Display(Name = "Autor")]
        public virtual AutorModels autoModels { get; set; }

        public virtual ICollection<PedidosOrdemModels> PedidosOrdemModels { get; set; }
    }
}
