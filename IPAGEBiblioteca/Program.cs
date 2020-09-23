namespace IPAGEBiblioteca
{
    using DevExpress.LookAndFeel;
    using DevExpress.Skins;
    using DevExpress.UserSkins;
    using DevExpress.XtraEditors;
    using IPAGEBiblioteca.Controllers.Configura;
    using IPAGEBiblioteca.Controllers.Helps;
    using IPAGEBiblioteca.Models;
    using IPAGEBiblioteca.Models.Helps;
    using IPAGEBiblioteca.Repository;
    using IPAGEBiblioteca.Repository.Helps;
    using IPAGEBiblioteca.Views;
    using IPAGEBiblioteca.Views.HelpsLicence;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    static class Program
    {
        #region Propriedades
        public static MenuDesign menuDesign { get; set; }
        public static UserModels Usuarios { get; set; }
        public static LicenceModelsHelps LicenceModelsHelps { get; set; }
        #endregion


        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += new ThreadExceptionEventHandler(ErrorThread);
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("pt-BR");
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("pt-BR");

            // Leitura de Temas e Paletas
            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            var objectoUserSetings = new ObjectoUserSetings();

            UserLookAndFeel.Default.SetSkinStyle(
               objectoUserSetings.DefaultAppSkin,
               objectoUserSetings.DefaultPalette);

            WindowsFormsSettings.TouchUIMode = objectoUserSetings.TouchUI == true ? TouchUIMode.True : TouchUIMode.False;
            WindowsFormsSettings.DefaultFont = objectoUserSetings.DefaultAppFont;
            WindowsFormsSettings.DefaultPrintFont = objectoUserSetings.DefaultAppFont;
            var licenceResult = false;

            // Acessar e verificar a Base de dados
            using (var frm = new frmSplash(new ILicence()))
            {
                frm.Show();

                // Licença
                licenceResult = frm.LecencaOk;
                Task.Run(async () => { await new BibliotecaContextData(new BiblioteContext()).Seed(); }).Wait();
            }
            if (licenceResult){
                Application.Run(new frmLogin(new UserRepository(new BiblioteContext())));
            }
            else
            {
                XtraMessageBox.Show("Lamentamos Muito mais o seu Software ainda não foi Registado\nFaçau agora!...\n"
                                                           , "Licença requerida",
                                                            MessageBoxButtons.OK,
                                                            MessageBoxIcon.Warning);
                Application.Exit();
                Application.Run(new frmRegistar(new KeyGenRepository(new BiblioteContext())));
            }
        }
        private static void ErrorThread(object sender, ThreadExceptionEventArgs e)
        {
            EscreverLogs.Escrever(null, e.Exception);
        }
    }
}
