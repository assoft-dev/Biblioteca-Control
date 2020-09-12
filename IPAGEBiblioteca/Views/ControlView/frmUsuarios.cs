namespace IPAGEBiblioteca.Views.ControlView
{
    using DevExpress.XtraEditors;
    using IPAGEBiblioteca.Controllers.Helps;
    using IPAGEBiblioteca.Models;
    using IPAGEBiblioteca.Repository.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System.Windows.Forms;

    public partial class frmUsuarios : XtraUserControl
    {
        private readonly IUserModels userModels;
        public frmUsuarios(IUserModels userModels)
        {
            InitializeComponent();
            this.userModels = userModels;
            this.Load += delegate { Loader(); };
            this.gridView1.DoubleClick += delegate { EditValues(); };
        }
        private void EditValues()
        {
            if (gridView1.FocusedRowHandle >= 0 || gridView1.SelectedRowsCount > 0)
            {
                using (var forms = new frmUsuariosAdd(userModelsBindingSource.Current as UserModels))
                {
                    var usercontrol = OpenFormsDialog.ShowForm(null, forms);
                    if (usercontrol == DialogResult.OK)
                        Loader();
                }
            }
        }
        private async void Loader()
        {
            userModelsBindingSource.DataSource = await userModels.GetAll().Include(x => x.GruposModels)
                                                                          .ThenInclude(x => x.PermissoesModels).ToListAsync();
        }      
    }
}
