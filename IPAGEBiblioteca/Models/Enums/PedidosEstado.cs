using System.ComponentModel;

namespace IPAGEBiblioteca.Models.Enums
{
    public enum PedidosEstado
    {

        Requisitado,
        Devolvido,
        [Description("Requisitado e Devolvido")]
        RequisitadoDevolvido,
    }
}
