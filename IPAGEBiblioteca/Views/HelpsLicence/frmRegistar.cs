namespace IPAGEBiblioteca.Views.HelpsLicence
{
    using DevExpress.XtraEditors;
    using FoxLearn.License;
    using IPAGEBiblioteca.Controllers.Helps;
    using IPAGEBiblioteca.Models;
    using IPAGEBiblioteca.Models.Helps;
    using IPAGEBiblioteca.Repository;
    using IPAGEBiblioteca.Repository.Helps;
    using IPAGEBiblioteca.Repository.Interfaces;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Forms;


    public partial class frmRegistar : XtraForm
    {
        const int ProdutoID = 1;
        private bool mover;
        private int cX, cY;
        private readonly IKeyGenRepository keyGenRepository;

        public frmRegistar(IKeyGenRepository keyGenRepository)
        {
            InitializeComponent();

            btnSolicitar.Click += BtnSolicitar_Click;
            textBox1.KeyPress += TextBox1_KeyPress;
            btnGerarSenha.Click += BtnGerarSenha_Click;
            btnRegistar.Click += BtnRegistar_Click;
            textBox1.TextChanged += TextBox1_TextChanged;

            #region Arrastar ControlPanel
            panelControl1.MouseDown += pictureBox2_MouseDown;
            panelControl1.MouseUp += pictureBox2_MouseUp;
            panelControl1.MouseMove += pictureBox2_MouseMove;

            txtProdutoID.MouseDoubleClick += delegate
            {
                if (txtProdutoID.ReadOnly)
                    txtProdutoID.ReadOnly = false;
                else
                    txtProdutoID.ReadOnly = true;
            };
            btnsolicitartestes.Click += async (sender, args) =>
            {
                try
                {
                    Cursor = Cursors.WaitCursor;
                    if (await EnviarEmail())
                        XtraMessageBox.Show("Email bem Enviado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        XtraMessageBox.Show("Má conclusão de Envio", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch
                {
                    XtraMessageBox.Show("Má conclusão de Envio", "internet em Falta no PC", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            };

            btntestar.Click += (sender, args) =>
            {
                // Teste se já foi adicionado uma licenca desta Naturesa
                var items = keyGenRepository.GetAll().FirstOrDefault();
                if (items != null)
                {
                    XtraMessageBox.Show("Desculpe não podes mais usar uma Licença Contacte o administrador do sistema\n" +
                                        "Detalhes\n",
                                        "Messagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    Cursor = Cursors.WaitCursor;
                    try
                    {
                        using (var forms = new frmGerar())
                        {
                            forms.cbLicenceType.SelectedIndex = 1;
                            forms.txtLicenceExpiracao.Text = "15";

                            forms.BtnGerar_Click(sender, args);

                            txtProdutoKey.Text = forms.txtProdutoKey.Text;

                            BtnRegistar_Click(sender, args);

                            XtraMessageBox.Show("Sua licença de Teste foi Gerada com Exito tens 15 Dias Uteis", "Messagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (System.Exception exe)
                    {
                        XtraMessageBox.Show("Erro ao Gerar a Licença! " + exe.Message, "Messagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        Cursor = Cursors.Default;
                    }
                }
            };
            this.keyGenRepository = keyGenRepository;
            #endregion
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                if (textBox1.Text.Equals("ASSOFT@outlook.PT/JUNIOR937097905"))
                    btnGerarSenha.Visible = true;
                else
                    btnGerarSenha.Visible = false;
            }
        }
        private void BtnGerarSenha_Click(object sender, EventArgs e)
        {
            OpenFormsDialog.ShowForm(this, null, new frmGerar());
        }
        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (!string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    if (textBox1.Text.Equals("assoft@outlook.pt/JUNIOR937097905"))
                        btnGerarSenha.Visible = true;
                    else
                        btnGerarSenha.Visible = false;
                }
            }
        }

        private void BtnSolicitar_Click(object sender, EventArgs e)
        {
            if (textBox1.Visible)
                textBox1.Visible = false;
            else
            {
                textBox1.Visible = true;
                textBox1.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRegistar_Load(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                txtProdutoID.Text = ComputerInfo.GetComputerId();
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private async void BtnRegistar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtProdutoKey.Text))
            {
                XtraMessageBox.Show("Digite a sua Licença por favor", "Licença Vazia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProdutoKey.Focus();
                return;
            }
            // Teste se já foi adicionado uma licenca desta Naturesa
            var items = keyGenRepository.GetAll().Where(x => x.Key == txtProdutoKey.Text).FirstOrDefault();
            if (items != null)
            {
                XtraMessageBox.Show("Desculpe mais esta Licença já foi usada e já não pode voltar a ser usada\n" +
                                    "Detalhes\n" +
                                    string.Format("Data do Licenciamento: {0}\n Data Final: {1}\n Key: {2}",
                                    items.DataActual,
                                    items.DataFinal,
                                    items.Key),
                                    "Messagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            KeyManager km = new KeyManager(txtProdutoID.Text);
            string produtoKey = txtProdutoKey.Text;
            if (km.ValidKey(ref produtoKey))
            {
                var f = GetDefinicoes();
                KeyValuesClass kv = new KeyValuesClass();
                LicenseInfo lic = new LicenseInfo();

                if (f != null)
                {
            
                    if (km.DisassembleKey(txtProdutoKey.Text, ref kv))
                    {
                        lic.ProductKey = produtoKey;
                        lic.FullName = f.DefinicoesTitulo;
  
                        if (kv.Type == LicenseType.TRIAL)
                        {
                            lic.Day = kv.Expiration.Day;
                            lic.Month = kv.Expiration.Month;
                            lic.Year = kv.Expiration.Year;
                        }
                        kv.Edition = FoxLearn.License.Edition.STANDARD;
                        if (kv.Edition == FoxLearn.License.Edition.ENTERPRISE)
                        {

                        }
                        var getLicence = ArquivosGestao.GetLocalDataUsert(ArquivosGestao.ProgramLicence, "Licence");
                        km.SaveSuretyFile(string.Format(@"{0}\Key.Lic", getLicence), lic);
                        XtraMessageBox.Show("Sua licença foi registado com Sucesso\nTente reiniciar a aplicação para aplicar a licença ao seu sistema!", "Messagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                else
                {
                    if (km.DisassembleKey(txtProdutoKey.Text, ref kv))
                    {
                        lic.ProductKey = produtoKey;
                        lic.FullName = Environment.UserName; 
                        if (kv.Type == LicenseType.TRIAL)
                        {
                            lic.Day = kv.Expiration.Day;
                            lic.Month = kv.Expiration.Month;
                            lic.Year = kv.Expiration.Year;
                        }
                        var getLicence = ArquivosGestao.GetLocalDataUsert(ArquivosGestao.ProgramLicence, "Licence");
                        km.SaveSuretyFile(string.Format(@"{0}\Key.Lic", getLicence), lic);
                       
                        XtraMessageBox.Show("Sua licença foi registado com Sucesso\nTente reiniciar a aplicação para aplicar a licença ao seu sistema!", "Messagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }

                var keygen = new KeysGensModels
                {
                    DataActual = DateTime.Now,
                    DataFinal = Convert.ToDateTime(new DateTime(lic.Year, lic.Month, lic.Day)),
                    Key = txtProdutoKey.Text,
                };
                await keyGenRepository.Guardar(keygen);
  
                this.Close();
            }
            else
            {
                XtraMessageBox.Show("Não foi Possivel Registar a Sua Licença\nConsidere pedir uma Licença diferente da que estas a tentar Registar", "Messagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private DefinicoesModels GetDefinicoes()
        {
            return new DefinicoesRepository(new BiblioteContext()).GetAll().FirstOrDefault();
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
        private async Task<bool> EnviarEmail()
        {
            try
            {
                IGmailEmailService sender = new GmailEmailServiceRepository(new BiblioteContext());
                EmailMessage mail = new EmailMessage
                {
                    Subject = "Solicitação da senha: " + Environment.UserName,
                    IsHtml = false,
                    ToEmail = "assoft@outlook.pt",
                    Body = "Aqui esta o meu ID: " + txtProdutoID.Text,
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
