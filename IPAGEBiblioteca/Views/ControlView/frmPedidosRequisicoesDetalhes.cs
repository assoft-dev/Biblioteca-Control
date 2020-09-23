namespace IPAGEBiblioteca.Views.ControlView
{
    using DevExpress.XtraBars.Docking2010;
    using DevExpress.XtraEditors;
    using IPAGEBiblioteca.Controllers.Helps;
    using IPAGEBiblioteca.Models;
    using IPAGEBiblioteca.Report;
    using IPAGEBiblioteca.Repository.Interfaces;
    using System;
    using System.Windows.Forms;

    public partial class frmPedidosRequisicoesDetalhes : XtraUserControl
    {
        private readonly IPedidoModels pedidoModels;
        public frmPedidosRequisicoesDetalhes(PedidosModels pedidosModels, IPedidoModels pedidoModels)
        {
            InitializeComponent();
            pedidosModelsBindingSource.DataSource = pedidosModels;
            pedidosOrdemModelsBindingSource.DataSource = pedidosModels.PedidosOrdemModels;
            windowsUIButtonPanel1.ButtonClick += WindowsUIButtonPanel1_ButtonClick;
            this.pedidoModels = pedidoModels;
            IDTextEdit.EditValueChanged += IDTextEdit_TextChanged;
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

        private void MenuRelatoriosComprovativo_Click(object sender, EventArgs e)
        {
            var userdelete = pedidosModelsBindingSource.Current as PedidosModels;
            if (userdelete != null)
            {
                ReportControllers.GetReport(new rptPedidosFactura(userdelete), false);
            }
        }
        private void WindowsUIButtonPanel1_ButtonClick(object sender, ButtonEventArgs e)
        {
            switch (e.Button.Properties.Caption)
            {
                case "Guardar":
                    MenuRelatoriosComprovativo_Click(null, null);
                    break;
                case "Apagar":
                    ApagarDados();
                    break;
            }
        }
        private async void ApagarDados()
        {
            if (XtraMessageBox.Show("Tens a certeza de que queres mesmo apagar esta infromação?",
                               "Perda de Dados Permanente", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                try
                {
                    if (await pedidoModels.Delete(new PedidosModels { ID = (int)IDTextEdit.EditValue, }))
                    {
                        XtraMessageBox.Show("Apagado com Exito", "Apagar infromação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception exe)
                {
                    XtraMessageBox.Show(MessageCaption.ErrorRelacionalShipe + exe.Message,
                        "Apagar infromação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        #region Combinações de Teclas
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.btnClose.DialogResult = DialogResult.OK;
                bool res = base.ProcessCmdKey(ref msg, keyData);
                return res;
            }
            return false;
        }
        #endregion
    }
}
