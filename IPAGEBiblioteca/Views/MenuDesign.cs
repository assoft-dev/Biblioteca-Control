namespace IPAGEBiblioteca.Views
{
    using DevExpress.XtraBars.FluentDesignSystem;
    using IPAGEBiblioteca.Models;

    public partial class MenuDesign : FluentDesignForm
    {
        private PermissoesModels permissoesModels;

        public MenuDesign(PermissoesModels permissoesModels)
        {
            InitializeComponent();
            this.permissoesModels = permissoesModels;
        }
        private void AplicarPermissoes()
        {
            // Aplicar Todas as Permissoes;
        }
    }
}
