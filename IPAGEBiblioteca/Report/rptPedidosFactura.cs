namespace IPAGEBiblioteca.Report
{
    using IPAGEBiblioteca.Models;
    using IPAGEBiblioteca.Repository;
    using System.Collections.Generic;
    using System.Linq;

    public partial class rptPedidosFactura : DevExpress.XtraReports.UI.XtraReport
    {
        public rptPedidosFactura(PedidosModels pedidosModels)
        {
            InitializeComponent();
            var pedidosModels1 = new List<PedidosModels>();
            pedidosModels1.Add(pedidosModels);
            DataSource = pedidosModels1;
            Definicoes();
        }
        public void Definicoes()
        {
            var item1 = new DefinicoesRepository(new Repository.Helps.BiblioteContext())
                            .GetAll()
                            .FirstOrDefault();

            if (item1 != null)
            {
                pImagem.Value = item1.Photos_Desk1;
                pRua.Value = item1.Rua;
                pEmail.Value = item1.Email;
                pTelemovel.Value = item1.Telemovel;
                pTitulo.Value = item1.DefinicoesTitulo;
                pNif.Value = item1.NIF;
            }
            foreach (var item in Parameters)
                item.Visible = false;
        }
    }
}
