namespace IPAGEBiblioteca.Views.ControlView
{
    using DevExpress.XtraBars.Docking2010;
    using DevExpress.XtraEditors;
    using IPAGEBiblioteca.Controllers.Helps;
    using IPAGEBiblioteca.Models;
    using IPAGEBiblioteca.Repository;
    using IPAGEBiblioteca.Repository.Helps;
    using IPAGEBiblioteca.Repository.Interfaces;
    using System;
    using System.Linq;
    using System.Windows.Forms;

    public partial class frmStocksAdd : XtraUserControl
    {
        private readonly ILivrosModels livrosModels;
        private readonly IStocksModels stocksModels;

        public frmStocksAdd(StocksModels userModels, IStocksModels stocksModels,
                                                     ILivrosModels livrosModels)
        {
            InitializeComponent();
            this.Load += delegate { LoaderFormsXML(); Loader(); };
            btnClose.Click += delegate { SaveFormsXML(); };
            IDTextEdit.EditValueChanged += IDTextEdit_TextChanged;

            windowsUIButtonPanel1.ButtonClick += WindowsUIButtonPanel1_ButtonClick; ;
            this.livrosModels = livrosModels;
            this.stocksModels = stocksModels;

            if (userModels != null)
            {
                IDTextEdit.EditValue = userModels.ID;
                txtLivros.EditValue = userModels.LivrosModelsID;
                txtQuantidade.EditValue = userModels.Qtd;
                txtQuantidadeMinima.EditValue = userModels.QuantidadeMinima;
                txtQuantidadeMaxima.EditValue = userModels.QuantidadeMaxima;
                txtPrecounitario.EditValue = userModels.PrecoUnitario;
                txtTotal.EditValue = userModels.Total;
                IsValidoToggleSwitch.EditValue = userModels.Isvalid;
                txtComentarios.EditValue = userModels.Comentarios;
                txtdataStocks.EditValue = userModels.Data;
                txtComentarios.Focus();
            }
            else
                txtdataStocks.DateTime = DateTime.Now;
            btnAddForenty1.Click += BtnAddForenty_Click;
            txtPrecounitario.ValueChanged += TxtPrecounitario_ValueChanged;
            txtQuantidade.ValueChanged += TxtPrecounitario_ValueChanged;
        }

        private void TxtPrecounitario_ValueChanged(object sender, EventArgs e)
        {
            txtTotal.Value = txtQuantidade.Value * txtPrecounitario.Value;
        }

        private void BtnAddForenty_Click(object sender, EventArgs e)
        {
            using (var forms = new frmLivrosAdd(null, new LivrosRepository(new BiblioteContext()),
                                                      new AutorRepositoty(new BiblioteContext()),
                                                      new EditoraRepository(new BiblioteContext())))
            {
                var usercontrol = OpenFormsDialog.ShowForm(null, forms);
                if (usercontrol == DialogResult.OK)
                    Loader();
            }
        }
        private void IDTextEdit_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(IDTextEdit.Text) || IDTextEdit.Text.Equals("0"))
            {
                // Novo 0, Guardar 1, Delete 3
                windowsUIButtonPanel1.Buttons[1].Properties.Enabled = true;
                windowsUIButtonPanel1.Buttons[3].Properties.Enabled = false;
            }
            else
            {
                // Novo 0, Guardar 1, Delete 3
                windowsUIButtonPanel1.Buttons[1].Properties.Enabled = true;
                windowsUIButtonPanel1.Buttons[3].Properties.Enabled = true;
            }
        }
        private void Loader()
        {
            livrosModelsBindingSource.DataSource = livrosModels.GetAll().ToList();
        }

        #region Combinações de Teclas
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                LoaderFormsXML();
                this.Dispose();
                bool res = base.ProcessCmdKey(ref msg, keyData);
                return res;
            }
            if (keyData == Keys.F5)
            {
                Loader();
                bool res = base.ProcessCmdKey(ref msg, keyData);
                return res;
            }
            return false;
        }
        #endregion

        #region Guardar Forms
        private void LoaderFormsXML()
        {
            #region LoaderLayer
            var caminho = SaveLayoutXML.Loader(this.Name);
            try
            {
                if (!string.IsNullOrWhiteSpace(caminho))
                {
                    dataLayoutControl1.RestoreLayoutFromXml(caminho);
                }
            }
            catch (System.Exception)
            {
                XtraMessageBox.Show("Seu Layote esta mal estruturado por favor apage apartir do Caminho: \n" + caminho,
                                    "Layote da Pagina com mal estruturação.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            #endregion
        }
        private void SaveFormsXML()
        {
            #region SaveForms
            var caminho = SaveLayoutXML.Restore(this.Name);
            try
            {
                dataLayoutControl1.SaveLayoutToXml(caminho);
                this.btnClose.DialogResult = DialogResult.OK;
            }
            catch (System.Exception)
            {
                XtraMessageBox.Show("Seu Layote esta mal estruturado por favor apage e volte a abrir o APP: \n" + caminho,
                                    "Layote da Pagina com mal estruturação.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            #endregion
        }
        #endregion

        private bool Validacao()
        {
            if (txtLivros.EditValue == null)
            {
                MessageBox.Show("Desculpe selecione um livro por favor!", "Falta de Informação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLivros.ShowPopup();
                return false;
            }
            return true;
        }

        private void WindowsUIButtonPanel1_ButtonClick(object sender, ButtonEventArgs e)
        {
            switch (e.Button.Properties.Caption)
            {
                case "Novo":
                    NovoDado();
                    break;
                case "Guardar":
                    GuardarDados();
                    break;
                case "Apagar":
                    ApagarDados();
                    break;
            }
        }
        private void NovoDado()
        {
            if (Validacao())
            {
                IDTextEdit.EditValue = string.Empty;
                txtLivros.EditValue = string.Empty;
                txtComentarios.EditValue = string.Empty;
                IsValidoToggleSwitch.EditValue = string.Empty;
                txtQuantidade.EditValue = string.Empty;
                txtQuantidadeMinima.EditValue = string.Empty;
                txtQuantidadeMaxima.EditValue = string.Empty;
                txtPrecounitario.EditValue = string.Empty;
                txtTotal.EditValue = string.Empty;
                txtComentarios.EditValue = string.Empty;
                txtdataStocks.EditValue = DateTime.Now;
                txtQuantidade.Focus();
            }
        }
        private async void GuardarDados()
        {
            if (Validacao())
            {
                var codigo = string.IsNullOrWhiteSpace(IDTextEdit.Text) || IDTextEdit.Text.Equals("0");
                var models = new StocksModels
                {
                    ID = codigo ? 0 : (int)IDTextEdit.EditValue,
                    LivrosModelsID = (int)txtLivros.EditValue,
                    Comentarios = (string)txtComentarios.EditValue,
                    Isvalid = (bool)IsValidoToggleSwitch.EditValue,
                    Qtd = (decimal)txtQuantidade.EditValue,
                    QuantidadeMinima = (decimal)txtQuantidadeMinima.EditValue,
                    QuantidadeMaxima = (decimal)txtQuantidadeMaxima.EditValue,
                    PrecoUnitario = (decimal)txtPrecounitario.EditValue,
                    Data = (DateTime)txtdataStocks.EditValue,
                };
                var result = await stocksModels.Guardar(models);
                if (result)
                    XtraMessageBox.Show("Inserido com Exito", "Inserção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private async void ApagarDados()
        {
            if (MessageBox.Show("Tens a certeza de que queres mesmo apagar esta infromação?",
                "Perda de Dados Permanente", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                try
                {
                    if (await livrosModels.Delete(new LivrosModels { ID = (int)IDTextEdit.EditValue, }))
                    {
                        XtraMessageBox.Show("Apagado com Exito", "Apagar infromação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (System.Exception exe)
                {
                    XtraMessageBox.Show(MessageCaption.ErrorRelacionalShipe + exe.Message,
                        "Apagar infromação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
