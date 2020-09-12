using IPAGEBiblioteca.Repository;
using IPAGEBiblioteca.Repository.Helps;
using IPAGEBiblioteca.Views;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IPAGEBiblioteca
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Acessar e verificar a Base de dados
            using (var frm = new frmSplash())
            {
                frm.Show();
                Task.Run(async () => { await new BibliotecaContextData(new BiblioteContext()).Seed(); }).Wait();
            }
            Application.Run(new frmLogin(new UserRepository(new BiblioteContext())));
        }
    }
}
