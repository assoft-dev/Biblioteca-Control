namespace IPAGEBiblioteca.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PedidosOrdem")]
    public class PedidosOrdemModels: IEntity
    {
        public int ID { get ; set; }
        public string DocNumero { get; set; }
        public DateTime DataInsert { get; set; }
        public int Quantidade { get; set; }
        public virtual LivrosModels LivrosModels { get; set; }
        public virtual PedidosModels PedidosModels { get; set; }
    }
}
