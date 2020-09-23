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

    public partial class frmTurmaAdd : XtraUserControl
    {
        private readonly ITurmaModels turmaModels;
        private readonly IClasseModels classeModels;

        public frmTurmaAdd(TurmaModels userModels, ITurmaModels turmaModels,
                                                   IClasseModels classeModels)
        {
            InitializeComponent();
            this.turmaModels = turmaModels;
            this.classeModels = classeModels;
            this.Load += delegate { LoaderFormsXML(); Loader(); };
            btnClose.Click += delegate { SaveFormsXML(); };
            IDTextEdit.EditValueChanged += IDTextEdit_TextChanged;
            windowsUIButtonPanel1.ButtonClick += WindowsUIButtonPanel1_ButtonClick; ;

            if (userModels != null)
            {
                IDTextEdit.EditValue = userModels.ID;
                GruposModelsLookUpEdit.EditValue = userModels.ClasseModelsID;
                UserNameTextEdit.EditValue = userModels.Descricao;
                UserNameTextEdit.Focus();
            }
            btnAddForenty.Click += BtnAddForenty_Click;
            GruposModelsLookUpEdit.EditValueChanged += GruposModelsLookUpEdit_EditValueChanged;
        }

        private void GruposModelsLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(UserNameTextEdit.Text))
            {
                UserNameTextEdit.Text = GruposModelsLookUpEdit.Text;
                UserNameTextEdit.Focus();
            }
        }

        private void BtnAddForenty_Click(object sender, EventArgs e)
        {
            using (var forms = new frmClasseAdd(null, new ClasseRepository(new BiblioteContext())))
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
            classeModelsBindingSource.DataSource = classeModels.GetAll().ToList();
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

        #region Guardar Forms XML
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
            if (string.IsNullOrWhiteSpace(UserNameTextEdit.Text))
            {
                MessageBox.Show("Desculpe o campo Referência precisa ser prienchido", "Falta de Informação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UserNameTextEdit.Focus();
                return false;
            }
         
            if ((classeModelsBindingSource.Current as ClasseModels) == null)
            {
                MessageBox.Show("Desculpe selecione a Classe!", "Falta de Informação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GruposModelsLookUpEdit.ShowPopup();
                GruposModelsLookUpEdit.Focus();
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
            IDTextEdit.Text = string.Empty;
            UserNameTextEdit.Text = string.Empty;
            UserNameTextEdit.Focus();
        }
        private async void GuardarDados()
        {
            if (Validacao())
            {
                var codigo = string.IsNullOrWhiteSpace(IDTextEdit.Text) || IDTextEdit.Text.Equals("0");
                var models  = new TurmaModels
                {
                    ID = codigo ? 0 : (int)IDTextEdit.EditValue,
                    ClasseModelsID = (int) GruposModelsLookUpEdit.EditValue,
                    Descricao = (string) UserNameTextEdit.EditValue,             
                };
                var result = await  turmaModels.Guardar(models);
                if (result){
                    XtraMessageBox.Show("Inserido com Exito", "Inserção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NovoDado();
                }
            }
        }
        private async void ApagarDados()
        {
            if (MessageBox.Show("Tens a certeza de que queres mesmo apagar esta infromação?",
                                "Perda de Dados Permanente", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) {
                try
                {
                    if (await turmaModels.Delete(new TurmaModels { ID = (int) IDTextEdit.EditValue, }))
                    {
                        XtraMessageBox.Show("Apagado com Exito", "Apagar infromação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        NovoDado();
                        }
                }
                catch (Exception exe)
                {
                    XtraMessageBox.Show(MessageCaption.ErrorRelacionalShipe + exe.Message,
                        "Apagar infromação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }     
    }
}
