namespace IPAGEBiblioteca.Models
{
    using DevExpress.XtraEditors.Filtering.Templates;
    using IPAGEBiblioteca.Models.Enums;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Pedidos")]
    public class PedidosModels
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), 
        Display(Name = "Código")]
        public int ID { get ; set; }

        [Key, StringLength(40),
        Display(Name = "Documento")]
        public string DocNumero { get; set; }

        [Display(Name = "Data Reserva"), DataType(DataType.DateTime)]
        public DateTime DataReserva { get; set; }

        [Display(Name = "Data"), Column(TypeName = "date")]
        public DateTime Data { get; set; }

        [Display(Name = "Data Entrega"), DataType(DataType.DateTime)]
        public DateTime DataEntrega { get; set; }

        [Display(Name = "Pedidos Estado")]
        public PedidosEstado PedidosEstado { get; set; }

        [Display(Name = "Disponibilidade")]
        public bool IsValid { get; set; }

        [Display(Name = "Dias")]
        public int ReservaDias { get { return (DataEntrega - DataReserva).Days; } }

        [Display(Name = "Total Geral"),
         DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N}")]
        public decimal Totalgeral { get; set; }


        [Display(Name = "Aluno"), ForeignKey("AlunoModels")]
        public int AlunoModelsID { get; set; }
        public virtual AlunoModels AlunoModels { get; set; }

        [Display(Name = "Alunos")]
        public string AlunoNome
        {
            get
            {
                if (AlunoModels != null)
                    return string.Format("{0} {1}", AlunoModels.Nome, AlunoModels.NumeroEstudante);
                return string.Empty;
            }
        }

        public virtual ICollection<PedidosOrdemModels> PedidosOrdemModels { get; set; }
    }
}
