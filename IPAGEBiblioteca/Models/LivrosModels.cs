using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading;

namespace IPAGEBiblioteca.Models
{
    [Table("Livros")]
    public class LivrosModels
    {
        [Key, Display(Name = "Código")]
        public int ID { get; set; }

        [Display(Name = "Descrição")]
        public string Referencia { get; set; }

        [Display(Name = "Detalhes")]
        public string Comentarios { get; set; }

        [Display(Name = "SBN/Identificação")]
        public string SBN { get; set; }

        [Display(Name = "Edição")]
        public string Edicao { get; set; }

        [Display(Name = "Ano/Lancamento")]
        public int AnoLancamento { get; set; }

        [Display(Name = "Valido")]
        public bool IsValide { get; set; }


        [Display(Name = "Editora"), ForeignKey("EditoraModels")]
        public int EditoraModelsID { get; set; }
        public virtual EditoraModels EditoraModels { get; set; }

        [Display(Name = "Autor"), ForeignKey("autoModels")]
        public int autoModelsID { get; set; }
        public virtual AutorModels autoModels { get; set; }

        public virtual ICollection<PedidosOrdemModels> PedidosOrdemModels { get; set; }
        public virtual ICollection<StocksModels> StocksModels { get; set; }


        [Display(Name = "Pratileira")]
        public string Pratileira { get; set; }

        [Display(Name = "Pratileira/Posição")]
        public string PratileiraPosicao { get; set; }

        [Display(Name = "Código de Barra")]
        public string CodBar { get; set; }
    }
}
