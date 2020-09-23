namespace IPAGEBiblioteca.Views.ControlView
{
    using DevExpress.XtraEditors;
    using DevExpress.XtraGrid.Views.Grid;
    using IPAGEBiblioteca.Controllers.Helps;
    using IPAGEBiblioteca.Models;
    using IPAGEBiblioteca.Models.Enums;
    using IPAGEBiblioteca.Report;
    using IPAGEBiblioteca.Repository;
    using IPAGEBiblioteca.Repository.Helps;
    using IPAGEBiblioteca.Repository.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class frmPedidosRequisicoes : XtraUserControl
    {
        #region Declaracoes
        private readonly IPedidoModels pedidoModels;
        #endregion

        #region Construtores da Classe
        public frmPedidosRequisicoes(IPedidoModels pedidoModels)
        {
            InitializeComponent();
            this.pedidoModels = pedidoModels;

            this.Load += delegate { LoaderFormsXML(); Loader(); };
            this.Disposed += delegate { SaveFormsXML(); };


            //Menu
            contextMenuStrip1.Opened += ContextMenuStrip1_Opened;
            MenuNovo.Click += MenuNovo_Click;
            this.MenuEditar.Click += MenuEditar_Click;
            //MenuEditar.Click += MenuEditar_Click;
            MenuApagar.Click += MenuApagar_Click;
            MenuRelatorios.Click += MenuRelatorios_Click;
            comprovativoToolStripMenuItem.Click += MenuRelatoriosComprovativo_Click;
            btnRefres.Click += delegate { Loader(); };
            CriarCores();
        }
        #endregion

        private void CriarCores()
        {
            #region Criando Estilo para as Celulas
            //Changing the appearance settings of column cells dynamically
            try
            {
                gridView1.RowStyle += (sender, e) =>
                {
                    GridView View = sender as GridView;
                    //var estado = Convert.ToString();

                    var retorn =  View.GetRowCellValue(e.RowHandle, "PedidosEstado");
                    if (retorn != null)
                    {
                        switch ((PedidosEstado)retorn)
                        {
                            case PedidosEstado.Requisitado:
                                e.Appearance.BackColor = Color.FromArgb(150, Color.LightCoral);
                                e.Appearance.BackColor2 = Color.White;
                                break;
                            case PedidosEstado.Devolvido:
                                e.Appearance.BackColor = Color.White;
                                e.Appearance.BackColor2 = Color.Purple;
                                break;
                            case PedidosEstado.RequisitadoDevolvido:
                                e.Appearance.BackColor = Color.Orange;
                                e.Appearance.BackColor2 = Color.White;
                                break;
                            default:
                                break;
                        }
                        //Override any other formatting
                        e.HighPriority = true;
                    }  
                };
            }
            catch (System.Exception)
            {
                return;
            }
            #endregion
        }

        #region Menu
        private void MenuRelatoriosComprovativo_Click(object sender, System.EventArgs e)
        {
            var userdelete = pedidosModelsBindingSource.Current as PedidosModels;
            if (userdelete != null)            {
                ReportControllers.GetReport(new rptPedidosFactura(userdelete), false);
            }
        }
        private void MenuRelatorios_Click(object sender, System.EventArgs e)
        {
            var userdelete = pedidosModelsBindingSource.DataSource as List<PedidosModels>;
            if (userdelete.Count > 0)
            {
                ReportControllers.GetReport(new rptPedidos(userdelete), false);
            }
        }
        private async void MenuApagar_Click(object sender, EventArgs e)
        {
            var userdelete = pedidosModelsBindingSource.Current as PedidosModels;
            if (userdelete != null)
            {
                if (MessageBox.Show("Tens a certeza de que queres mesmo apagar esta infromação?", 
                                    "Perda de Dados Permanente", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    try
                    {
                        if (await pedidoModels.Delete(userdelete))
                        {
                            XtraMessageBox.Show("Apagado com Exito", "Apagar infromação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception exe)
                    {
                        XtraMessageBox.Show(MessageCaption.ErrorRelacionalShipe + exe.Message, 
                                            "Apagar infromação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }             
                }
            }
        }

        private void MenuEditar_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0 || gridView1.SelectedRowsCount > 0)
            {
                using (var forms = new frmPedidosRequisicoesDetalhes(
                                                     pedidosModelsBindingSource.Current as PedidosModels, 
                                                                     new PedidosRepository(new BiblioteContext())))
                {
                    var usercontrol = OpenFormsDialog.ShowForm(null, forms);
                    if (usercontrol == DialogResult.OK)
                        Loader();
                }
            }
        }

        private void MenuNovo_Click(object sender, EventArgs e)
        {
            using (var forms = new frmPedidosRequisicoesAdd(
                                                new PedidosRepository(new BiblioteContext()),
                                                new AlunoRepository(new BiblioteContext()),
                                                new StocksModelsRepository(new BiblioteContext())))
            {
                var usercontrol = OpenFormsDialog.ShowForm(null, forms);
                if (usercontrol == DialogResult.OK)
                    Loader();
            }
        }
        private void ContextMenuStrip1_Opened(object sender, System.EventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0 && gridView1.SelectedRowsCount > 0)
            {
                //MenuNovo.Enabled = fals;
                MenuApagar.Enabled = true;
                MenuEditar.Enabled = true;
                MenuRelatorios.Enabled = true;
                comprovativoToolStripMenuItem.Enabled = true;
            }
            else
            {
                //MenuNovo.Enabled = false;
                MenuApagar.Enabled = false;
                MenuEditar.Enabled = false;
                comprovativoToolStripMenuItem.Enabled = false;
                MenuRelatorios.Enabled = false;
            }
        }
        #endregion

        #region Loader()
        private async void Loader()
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                pedidosModelsBindingSource.DataSource = await pedidoModels
                                                                  .GetAll(dateTimePicker1.Value.Date, dateTimePicker2.Value.Date)
                                                                  
                                                                  .ToListAsync();
            }
            finally
            {
                Cursor = Cursors.Default;
            }  
        }
        #endregion

        #region Conbinações de Teclas
        #region Combinações de Teclas
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
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
                    gridView1.RestoreLayoutFromXml(caminho);
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
                gridView1.SaveLayoutToXml(caminho);
            }
            catch (System.Exception)
            {
                XtraMessageBox.Show("Seu Layote esta mal estruturado por favor apage e volte a abrir o APP: \n" + caminho,
                                    "Layote da Pagina com mal estruturação.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            #endregion
        }
        #endregion
    }
}
