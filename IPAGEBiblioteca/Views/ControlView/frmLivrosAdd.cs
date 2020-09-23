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

    public partial class frmLivrosAdd : XtraUserControl
    {
        private readonly ILivrosModels livrosModels;
        private readonly IAutorModels autorModels;
        private readonly IEditoraModels editoraModels;

        public frmLivrosAdd(LivrosModels userModels, ILivrosModels  livrosModels,
                                                     IAutorModels  autorModels,
                                                     IEditoraModels editoraModels)
        {
            InitializeComponent();
            this.Load += delegate { LoaderFormsXML(); Loader(); };
            btnClose.Click += delegate { SaveFormsXML(); };
            IDTextEdit.EditValueChanged += IDTextEdit_TextChanged;

            windowsUIButtonPanel1.ButtonClick += WindowsUIButtonPanel1_ButtonClick; ;
            this.livrosModels = livrosModels;
            this.autorModels = autorModels;
            this.editoraModels = editoraModels;

            if (userModels != null)
            {
                IDTextEdit.EditValue = userModels.ID;
                txtAutor.EditValue = userModels.autoModelsID;
                txtEditora.EditValue = userModels.EditoraModelsID;
                txtReferencia.EditValue = userModels.Referencia;
                txtComentarios.EditValue = userModels.Comentarios;
                txtSBN.EditValue = userModels.SBN;
                txtEdicao.EditValue = userModels.Edicao;
                txtAnoLancamento.EditValue = userModels.AnoLancamento;
                IsValidoToggleSwitch.EditValue = userModels.IsValide;

                txtCodigoBarra.EditValue = userModels.CodBar;
                txtPratileira.EditValue = userModels.Pratileira;
                txtPratileiraPosicao.EditValue = userModels.PratileiraPosicao;
                txtReferencia.Focus();
            }
            btnAddForenty1.Click += BtnAddForenty_Click;
            btnAddForenty2.Click += BtnAddForenty_Click2;
        }

        private void BtnAddForenty_Click(object sender, EventArgs e)
        {
            using (var forms = new frmAutorAdd(null, new AutorRepositoty(new BiblioteContext())))
            {
                var usercontrol = OpenFormsDialog.ShowForm(null, forms);
                if (usercontrol == DialogResult.OK)
                    Loader();
            }
        }
        private void BtnAddForenty_Click2(object sender, EventArgs e)
        {
            using (var forms = new frmEditoraAdd(null, new EditoraRepository(new BiblioteContext()), 
                                                       new PaisRepository(new BiblioteContext())))
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
            autorModelsBindingSource.DataSource = autorModels.GetAll().ToList();
            editoraModelsBindingSource.DataSource = editoraModels.GetAll().ToList();
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
            if (string.IsNullOrWhiteSpace(txtReferencia.Text))
            {
                MessageBox.Show("Desculpe o nome do Usuário é imperactivo", "Falta de Informação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtReferencia.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtSBN.Text))
            {
                MessageBox.Show("Desculpe selecione um SBN", "Falta de Informação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSBN.Focus();
                return false;
            }
           
            if ((autorModelsBindingSource.Current as AutorModels) == null)
            {
                MessageBox.Show("Desculpe selecione um autor por favor!", "Falta de Informação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAutor.Focus();
                return false;
            }
            if ((editoraModelsBindingSource.Current as EditoraModels) == null)
            {
                MessageBox.Show("Desculpe selecione uma Editora!", "Falta de Informação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEditora.Focus();
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
                txtAutor.EditValue = string.Empty;
                txtEditora.EditValue = string.Empty;
                txtReferencia.EditValue = string.Empty;
                txtComentarios.EditValue = string.Empty;
                txtSBN.EditValue = string.Empty;
                txtEdicao.EditValue = string.Empty;
                txtAnoLancamento.EditValue = string.Empty;
                IsValidoToggleSwitch.EditValue = string.Empty;
                txtCodigoBarra.EditValue = string.Empty;
                txtPratileira.EditValue = string.Empty;
                txtPratileiraPosicao.EditValue = string.Empty;
                txtReferencia.Focus();
            }
        }
        private async void GuardarDados()
        {
            if (Validacao())
            {
                var codigo = string.IsNullOrWhiteSpace(IDTextEdit.Text) || IDTextEdit.Text.Equals("0");
                var models = new LivrosModels
                {
                    ID = codigo ? 0 : (int)IDTextEdit.EditValue,
                    autoModelsID = (int)txtAutor.EditValue,
                    EditoraModelsID = (int)txtEditora.EditValue,
                    Referencia = (string)txtReferencia.EditValue,
                    Comentarios = (string)txtComentarios.EditValue,
                    SBN = (string)txtSBN.EditValue,
                    Edicao = (string)txtEdicao.EditValue,
                    AnoLancamento = (int)txtAnoLancamento.DateTime.Year,
                    IsValide = (bool)IsValidoToggleSwitch.EditValue,
                    CodBar = (string) txtCodigoBarra.EditValue,
                    Pratileira = (string)txtPratileira.EditValue ,
                    PratileiraPosicao = (string) txtPratileiraPosicao.EditValue,
            };
                var result = await livrosModels.Guardar(models);
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
