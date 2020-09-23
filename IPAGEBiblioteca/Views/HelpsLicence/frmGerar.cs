namespace IPAGEBiblioteca.Views.HelpsLicence
{
    using DevExpress.XtraEditors;
    using FoxLearn.License;
    using IPAGEBiblioteca.Controllers.Helps;
    using IPAGEBiblioteca.Models.Helps;
    using IPAGEBiblioteca.Repository;
    using IPAGEBiblioteca.Repository.Helps;
    using IPAGEBiblioteca.Repository.Interfaces;
    using System;
    using System.ComponentModel;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public partial class frmGerar : XtraUserControl
    {
        const int ProdutoID = 0;
        private bool mover;
        private int cX, cY;
        public frmGerar()
        {
            InitializeComponent();
            btnGerar.Click += BtnGerar_Click;

            txtLicenceExpiracao.TextChanged += TxtLicenceExpiracao_TextChanged;

            #region Arrastar ControlPanel
            panelControl1.MouseDown += pictureBox2_MouseDown;
            panelControl1.MouseUp += pictureBox2_MouseUp;
            panelControl1.MouseMove += pictureBox2_MouseMove;
            #endregion

            btnEnviar.Click += async (sender, args) =>
            {
                if (string.IsNullOrWhiteSpace(txtProdutoKey.Text))
                {
                    MessageBox.Show("Gere uma licença por favor", "Licença Vazia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtProdutoKey.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtToEmail.Text))
                {
                    MessageBox.Show("Digite um Email Válido por favor", "Licença Vazia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtToEmail.Focus();
                    return;
                }
                try
                {
                    Cursor = Cursors.WaitCursor;
                    if (await EnviarEmail())
                        MessageBox.Show("Email bem Enviado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Má conclusão de Envio", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch
                {
                    MessageBox.Show("Má conclusão de Envio", "internet em Falta no PC", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            };

            // EMail sender 
            txtToEmail.Validating += TxtEmail_Validating;
        }
        private void TxtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtToEmail.Text))
            {
                if (!EmailValidade.GetIstance().IsValidEmail(txtToEmail.Text))
                {
                    txtToEmail.SelectAll();
                    btnEnviar.Enabled = false;
                    txtToEmail.Focus();
                }
                else
                    btnEnviar.Enabled = true;
            }
            else
                btnEnviar.Enabled = false;
        }

        private void TxtLicenceExpiracao_TextChanged(object sender, EventArgs e)
        {
            var test = 0;
            // Testar se é Numero ou não

            if (!int.TryParse(txtLicenceExpiracao.Text, out test))
            {
                MessageBox.Show("Desculpe mais neste campo só pode ir valores numéricos","", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLicenceExpiracao.SelectAll();
            }
        }

        public void BtnGerar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtLicenceExpiracao.Text))
            {
                KeyManager km = new KeyManager(txtProdutoID.Text);
                KeyValuesClass kv;
                string productKey = string.Empty;
                if (cbLicenceType.SelectedIndex == 0)
                {
                    kv = new KeyValuesClass()
                    {
                        Type = LicenseType.FULL,
                        Header = Convert.ToByte(9),
                        Footer = Convert.ToByte(6),
                        ProductCode = (byte)ProdutoID,
                        Edition = FoxLearn.License.Edition.ENTERPRISE,
                        Version = 1,
                    };
                    if (!km.GenerateKey(kv, ref productKey))
                        txtProdutoKey.Text = "Erro ao Gerar a Licença";
                }
                else
                {
                    kv = new KeyValuesClass()
                    {
                        Type = LicenseType.TRIAL,
                        Header = Convert.ToByte(9),
                        Footer = Convert.ToByte(6),
                        ProductCode = (byte) ProdutoID,
                        Edition = FoxLearn.License.Edition.ENTERPRISE,
                        Version = 1,
                        Expiration = DateTime.Now.AddDays(Convert.ToInt32(txtLicenceExpiracao.Text))
                    };
                    if (!km.GenerateKey(kv, ref productKey))
                        txtProdutoKey.Text = "Erro ao Gerar a Licença";
                }
                txtProdutoKey.Text = productKey;
            }
            else
            {
                MessageBox.Show("Digite o número de dias a usar o sistema por favor!...", "");
                txtLicenceExpiracao.Focus();
            }
        }

        private void frmGerar_Load(object sender, EventArgs e)
        {
            cbLicenceType.SelectedIndex = 0;
            txtProdutoID.Text = ComputerInfo.GetComputerId();
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

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private async Task<bool> EnviarEmail()
        {
            try
            {           
                IGmailEmailService sender = new GmailEmailServiceRepository(new BiblioteContext());
                EmailMessage mail = new EmailMessage
                {
                    Subject = string.Format("Envio de uma Licença Detalhes: ID: {0}", txtProdutoID.Text),
                    IsHtml = false,
                    ToEmail = txtToEmail.Text,
                    Body = "Aqui esta a Sua Licença: " + txtProdutoKey.Text,
                };
                return await sender.SendEmailMessageAsync(mail, "albertoafonsoaderito@gmail.com", "junior1123");
            }
            catch (System.Exception exe)
            {
                MessageBox.Show("Erro de Envio de Email Verifique seu mais ou certifique-se de qui estas conectado a Internet: Detalhes\n",
                                exe.InnerException.InnerException.Message,
                                MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
