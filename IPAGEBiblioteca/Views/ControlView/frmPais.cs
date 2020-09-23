namespace IPAGEBiblioteca.Views.ControlView
{
    using DevExpress.XtraEditors;
    using IPAGEBiblioteca.Controllers.Helps;
    using IPAGEBiblioteca.Models;
    using IPAGEBiblioteca.Repository;
    using IPAGEBiblioteca.Repository.Helps;
    using IPAGEBiblioteca.Repository.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System.Windows.Forms;

    public partial class frmPais : XtraUserControl
    {
        #region Declaracoes
        private readonly IPaisModels userModels;
        #endregion

        #region Construtores da Classe
        public frmPais(IPaisModels userModels)
        {
            InitializeComponent();
            this.userModels = userModels;

            this.Load += delegate { LoaderFormsXML(); Loader(); };
            this.Disposed += delegate { SaveFormsXML(); };
            this.gridView1.DoubleClick += MenuEditar_Click;

            //Menu
            contextMenuStrip1.Opened += ContextMenuStrip1_Opened;
            MenuNovo.Click += MenuNovo_Click;
            MenuEditar.Click += MenuEditar_Click;
            MenuApagar.Click += MenuApagar_Click;
        }
        #endregion

        #region Menu
        private async void MenuApagar_Click(object sender, System.EventArgs e)
        {
            var userdelete = paisModelsBindingSource.Current as PaisModels;
            if (userdelete != null)
            {
                if (MessageBox.Show("Tens a certeza de que queres mesmo apagar esta infromação?", 
                                    "Perda de Dados Permanente", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    try
                    {
                        if (await userModels.Delete(userdelete))
                        {
                            XtraMessageBox.Show("Apagado com Exito", "Apagar infromação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Loader();
                        }
                    }
                    catch (System.Exception exe)
                    {
                        XtraMessageBox.Show(MessageCaption.ErrorRelacionalShipe + exe.Message, 
                                            "Apagar infromação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }               
                }
            }
        }

        private void MenuEditar_Click(object sender, System.EventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0 || gridView1.SelectedRowsCount > 0)
            {
                using (var forms = new frmPaisAdd(  paisModelsBindingSource.Current as PaisModels,
                                                     new PaisRepository(new BiblioteContext())))
                {
                    var usercontrol = OpenFormsDialog.ShowForm(null, forms);
                    if (usercontrol == DialogResult.OK)
                        Loader();
                }
            }        
        }

        private void MenuNovo_Click(object sender, System.EventArgs e)
        {
            using (var forms = new frmPaisAdd(null,
                                                new PaisRepository(new BiblioteContext())))
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
            }
            else
            {
                //MenuNovo.Enabled = false;
                MenuApagar.Enabled = false;
                MenuEditar.Enabled = false;
            }
        }
        #endregion

        #region Loader()
        private async void Loader()
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                paisModelsBindingSource.DataSource = await userModels.GetAll()
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
