namespace IPAGEBiblioteca.Views.ControlView
{
    using DevExpress.XtraBars.Docking2010;
    using DevExpress.XtraEditors;
    using IPAGEBiblioteca.Controllers.Helps;
    using IPAGEBiblioteca.Models;
    using IPAGEBiblioteca.Repository.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;

    public partial class frmPermisssoesAdd : XtraUserControl
    {
        private readonly IPermissoesModels permissoesModels;
        public frmPermisssoesAdd(IPermissoesModels permissoesModels)
        {
            InitializeComponent();
            this.permissoesModels = permissoesModels;
            this.Load += delegate { LoaderFormsXML(); Loader(); };
            btnClose.Click += delegate { SaveFormsXML(); };
            IDTextEdit.EditValueChanged += IDTextEdit_TextChanged;
            windowsUIButtonPanel1.ButtonClick += WindowsUIButtonPanel1_ButtonClick;
            permissoesModelsBindingSource.AddNew();
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
            permissoesModelsBindingSource.DataSource = permissoesModels.GetAll().ToList();
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
            if (string.IsNullOrWhiteSpace(ReferenciaTextEdit.Text))
            {
                XtraMessageBox.Show("Desculpe digite a referência do Grupo por favor", "Falta de Informação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ReferenciaTextEdit.Focus();
                return false;
            }
            int i = 0;
            foreach (var item in permissoesModelsBindingSource.DataSource as List<PermissoesModels>)
            {
                i = i + 1;
                if (string.IsNullOrWhiteSpace(item.Referencia))
                {
                    XtraMessageBox.Show("Desculpe mais existem campos que não estão Devidamente preenchidos! O " + i +"ª Não esta devidamente preenchido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
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
                permissoesModelsBindingSource.AddNew();
            }
        }
        private async void GuardarDados()
        {
            if (Validacao())
            {
                var permissoes = permissoesModelsBindingSource.DataSource as List<PermissoesModels>;
                if (permissoes != null)
                {
                    var result = await permissoesModels.Insert(permissoes);
                    if (result)
                        XtraMessageBox.Show("Inserido com Exito", "Inserção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private async void ApagarDados()
        {
            if (MessageBox.Show("Tens a certeza de que queres mesmo apagar esta infromação?",
                "Perda de Dados Permanente", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                try
                {
                    if (await permissoesModels.Delete(new PermissoesModels { ID = (int)IDTextEdit.EditValue, }))
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
