using System.ComponentModel.DataAnnotations;

namespace IPAGEBiblioteca.Models.Helps
{
    public class ProdutoStocksModels
    {
        [Display(Name = "Código")]
        public int Codigo { get; set; }

        [Display(Name = "Codigo Stocks")]
        public int CodigoStocksID { get; set; }

        [Display(Name = "Descrição")]
        public string Designacao { get; set; }

        [Display(Name = "P. Unitário"),
            DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N}")]
        public decimal PrecoUnitario { get; set; }

        [Display(Name = "Quantidade"),
            DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N}")]
        public decimal Quantidade { get; set; }

        [Display(Name = "T. Geral"),
             DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N}")]
        public decimal SubTotal { get; set; }

        [Display(Name = "Livros")]
        public int LivrosID { get; }
    }
}
