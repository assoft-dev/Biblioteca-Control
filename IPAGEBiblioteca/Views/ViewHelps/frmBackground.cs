namespace IPAGEBiblioteca.Views.ViewHelps
{
    using IPAGEBiblioteca.Controllers.Helps;
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    public partial class frmBackground : DevExpress.XtraEditors.XtraUserControl
    {
        public int ImagemContador = 0;
        public bool validar { get; set; }

        public frmBackground()
        {
            InitializeComponent();
            this.Load += FrmBackground_Load;
            this.timer1.Tick += Timer1_Tick;
            this.Disposed += FrmBackground_Disposed;
        }

        private void FrmBackground_Disposed(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void FrmBackground_Load(object sender, EventArgs e)
        {
            Leitura();
            timer1.Start();
            timer1.Interval = 10000;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (validar)
            {
                if (imageSlider1.CurrentImageIndex == ImagemContador - 1)
                    imageSlider1.SlideFirst();
                else
                    imageSlider1.SlideNext();
            }

        }

        private void Leitura()
        {
            try
            {
                var listaFiles = ArquivosGestao.Lerarquivos(Application.StartupPath + "\\Imagens", true);

                if (listaFiles.Length > 0)
                {
                    foreach (var item in listaFiles)
                    {
                        if ((item.Extension.ToLower().Contains(".png")) || (item.Extension.ToLower().Contains(".jpg")))
                        {
                            imageSlider1.Images.Add(Image.FromFile(item.FullName));
                            ImagemContador++;
                        }
                    }
                    validar = true;
                }
                else
                    validar = false;
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.ToString()); ;
            }
        }

        #region Combinações de Teclas
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                button1.DialogResult = DialogResult.OK;//  this.Dispose();
                bool res = base.ProcessCmdKey(ref msg, keyData);
                return res;
            }
            if (keyData == Keys.F5)
            {
                Leitura();
                bool res = base.ProcessCmdKey(ref msg, keyData);
                return res;
            }
            return false;
        }
        #endregion
    }
}
