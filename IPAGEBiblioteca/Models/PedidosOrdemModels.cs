namespace IPAGEBiblioteca.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PedidosOrdem")]
    public class PedidosOrdemModels
    {
        [Key, Display(Name = "Código")]
        public int ID { get ; set; }

        [Display(Name = "Data")]
        public DateTime Data { get; set; }

        [Display(Name = "Quantidade"),
               DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N}")]
        public int Quantidade { get; set; }

        [Display(Name = "Preço Unitário"),
        DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N}")]
        public decimal PrecoUnitario { get; set; }

        [Display(Name = "Total Geral"),
        DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N}")]
        public decimal Total { get { return Quantidade * PrecoUnitario; } }

        [Display(Name = "Documento"),
         StringLength(40), ForeignKey("PedidosModels")]
        public string DocNumero { get; set; }
        public virtual PedidosModels PedidosModels { get; set; }

        [Display(Name = "Livros"), ForeignKey("LivrosModels")]
        public int LivrosModelsID { get; set; }
        public virtual LivrosModels LivrosModels { get; set; }

    }
}
