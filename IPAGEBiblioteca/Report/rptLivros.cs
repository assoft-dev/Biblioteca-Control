using DevExpress.XtraReports.UI;
using IPAGEBiblioteca.Models;
using IPAGEBiblioteca.Repository;
using System.Collections.Generic;
using System.Linq;

namespace IPAGEBiblioteca.Report
{
    public partial class rptLivros : XtraReport
    {
        public rptLivros(List<LivrosModels> models)
        {
            InitializeComponent();
            DataSource = models;
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
