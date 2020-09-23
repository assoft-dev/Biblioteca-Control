using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IPAGEBiblioteca.Models
{
    [Table("Stocks")]
    public class StocksModels
    {
        [Display(Name = "Código")]
        public int ID { get; set; }

        [Display(Name = "Quantidade"), 
        DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N}"),]
        public decimal Qtd { get; set; }

        [Display(Name = "Quantidade Mínima"), 
        DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N}"),]
        public decimal QuantidadeMinima { get; set; }

        [Display(Name = "Quantidade Máxima"), 
        DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N}"),]
        public decimal QuantidadeMaxima { get; set; }

        [Display(Name = "Precço Unitário"), 
        DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N}"),]
        public decimal PrecoUnitario { get; set; }

        [Display(Name = "Total Geral"), 
        DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N}"), ]
        public Decimal Total { get { return Qtd * PrecoUnitario; } }

        [Display(Name = "Disponibilidade")]
        public bool Isvalid { get; set; }

        [Display(Name = "Comentários")]
        public string Comentarios { get; set; }

        [Display(Name = "Data"),DataType(DataType.DateTime)]
        public DateTime Data { get; set; }

        [Display(Name = "Livros"), ForeignKey("LivrosModels")]
        public int LivrosModelsID { get; set; }
        public virtual LivrosModels LivrosModels { get; set; }
    }
}
