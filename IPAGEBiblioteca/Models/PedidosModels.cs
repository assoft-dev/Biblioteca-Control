namespace IPAGEBiblioteca.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Pedidos")]
    public class PedidosModels : IEntity
    {
        public int ID { get ; set; }
        public string DocNumero { get; set; }
        public DateTime DataReserva { get; set; }
        public DateTime DataEntrega { get; set; }
        public int ReservaDias { get { return (DataEntrega - DataReserva).Days; } }


        //AutoCalculos
        [Display(Name = "Aluno")]
        public virtual AlunoModels AlunoModels { get; set; }
        public virtual ICollection<PedidosOrdemModels> PedidosOrdemModels { get; set; }
    }
}
