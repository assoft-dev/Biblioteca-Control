namespace IPAGEBiblioteca.Views
{
    using DevExpress.XtraEditors;
    using IPAGEBiblioteca.Controllers.Helps;
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class frmSplash : XtraForm
    {
        public bool LecencaOk;
        private readonly ILicence licence;
        public frmSplash(ILicence licence)
        {
            InitializeComponent();
            this.pictureEdit1.Image = Image.FromFile(Application.StartupPath + "\\Imagens\\Background.jpeg");
            this.licence = licence;

            this.labelCopyright.Text = "Copyright © 2016-" + DateTime.Now.Year.ToString();
            LecencaOk = licence.LeituraLicençe();
            if (Program.LicenceModelsHelps != null)
            {
                txtEmpresa.Text = Program.LicenceModelsHelps.FullName;
                txtProdutoID.Text = Program.LicenceModelsHelps.KeyID;
                ProdutoKey.Text = Program.LicenceModelsHelps.Key;
                txtLicençeType.Text = Program.LicenceModelsHelps.Dias;
            }
        }
        #region Overrides
        //public override void ProcessCommand(Enum cmd, object arg)
        //{
        //    base.ProcessCommand(cmd, arg);
        //}
        #endregion
    }
}
