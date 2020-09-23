namespace IPAGEBiblioteca.Views.HelpsLicence
{
    using DevExpress.XtraEditors;
    using FoxLearn.License;
    using System;
    using System.Windows.Forms;

    public partial class frmAbout : XtraUserControl
    {
        const int ProductCode = 1;
        private bool mover;
        private int cX, cY;

        public frmAbout()
        {
            InitializeComponent();
            this.Load += FrmAbout_Load;

            #region Arrastar ControlPanel
            panelControl1.MouseDown += pictureBox2_MouseDown;
            panelControl1.MouseUp += pictureBox2_MouseUp;
            panelControl1.MouseMove += pictureBox2_MouseMove;
            #endregion
        }

        private void FrmAbout_Load(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                txtProdutoID_.Text = ComputerInfo.GetComputerId();
                KeyManager km = new KeyManager(txtProdutoID_.Text);
                LicenseInfo Lic = new LicenseInfo();
                int value = km.LoadSuretyFile(string.Format(@"{0}\Key.Lic", Application.StartupPath), ref Lic);
                string produtoKey = Lic.ProductKey;
                if (km.ValidKey(ref produtoKey))
                {
                    KeyValuesClass kv = new KeyValuesClass();
                    if (km.DisassembleKey(produtoKey, ref kv))
                    {
                        txtProdutoNome.Text = Lic.FullName;
                        txtProdutoKey_.Text = produtoKey;
                        if (kv.Type == LicenseType.TRIAL)
                            txtLicenceType.Text = string.Format("{0} Dias", (kv.Expiration - DateTime.Now.Date).Days);
                        else
                            txtLicenceType.Text = "FULL";
                    }
                }
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                cX = e.X;
                cY = e.Y;
                mover = true;
            }
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            if (mover)
            {
                this.Left += e.X - (cX - panelControl1.Left);
                this.Top += e.Y - (cY - panelControl1.Top);
            }
        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                mover = false;
        }
    }
}
