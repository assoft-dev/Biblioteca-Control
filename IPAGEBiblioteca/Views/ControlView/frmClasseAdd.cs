namespace IPAGEBiblioteca.Views.ControlView
{
    using DevExpress.XtraBars.Docking2010;
    using DevExpress.XtraEditors;
    using IPAGEBiblioteca.Controllers.Helps;
    using IPAGEBiblioteca.Models;
    using IPAGEBiblioteca.Repository.Interfaces;
    using System;
    using System.Windows.Forms;

    public partial class frmClasseAdd : XtraUserControl
    {
        private readonly IClasseModels classeModels;

        public frmClasseAdd(ClasseModels classeModels, IClasseModels classeModelsRepository)
        {
            InitializeComponent();
            this.classeModels = classeModelsRepository;
            this.Load += delegate { LoaderFormsXML();};
            btnClose.Click += delegate { SaveFormsXML(); };
            IDTextEdit.EditValueChanged += IDTextEdit_TextChanged;
            windowsUIButtonPanel1.ButtonClick += WindowsUIButtonPanel1_ButtonClick; ;

            if (classeModels != null)
            {
                IDTextEdit.EditValue = classeModels.ID;
                UserNameTextEdit.EditValue = classeModels.Referencia;
                txtIdade1.EditValue = classeModels.IdadeInicia;
                txtIdade2.Value = classeModels.IdadeFinaliza;
                UserNameTextEdit.Focus();
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
            txtIdade1.Text = string.Empty;
            txtIdade2.EditValue = string.Empty;
            UserNameTextEdit.Focus();
        }
        private async void GuardarDados()
        {
            if (Validacao())
            {
                var codigo = string.IsNullOrWhiteSpace(IDTextEdit.Text) || IDTextEdit.Text.Equals("0");
                var models  = new ClasseModels
                {
                    ID = codigo == true ? 0 : (int)IDTextEdit.EditValue,
                    Referencia = (string) UserNameTextEdit.EditValue,
                    IdadeInicia = (decimal) txtIdade1.EditValue,
                    IdadeFinaliza = (decimal) txtIdade2.EditValue,
                };
                var result = await classeModels.Guardar(models);
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
                    if (await classeModels.Delete(new ClasseModels { ID = (int) IDTextEdit.EditValue, }))
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
