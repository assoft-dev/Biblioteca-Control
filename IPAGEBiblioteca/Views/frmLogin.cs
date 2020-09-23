namespace IPAGEBiblioteca.Views
{
    using IPAGEBiblioteca.Controllers.Configura;
    using IPAGEBiblioteca.Controllers.Helps;
    using IPAGEBiblioteca.Models;
    using IPAGEBiblioteca.Repository.Helps;
    using IPAGEBiblioteca.Repository.Interfaces;
    using IPAGEBiblioteca.Views.ControlView;
    using System;
    using System.Windows.Forms;

    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        private int cX, cY;
        private bool mover;
        private readonly IUserModels userModels;
        private ObjectoUserSetings conLogin = ObjectoUserSetings.Default;
        public frmLogin(IUserModels userModels)
        {
            InitializeComponent();
            this.btnCancelar.Click += BtnCancelar_Click;
            btnEntrar.Click += BtnEntrar_Click;
            this.userModels = userModels;

            this.Load += FrmLogin_Load;
            this.FormClosed += FrmLogin_FormClosed;

            txtUserName.TextChanged += TxtUsuários_TextChanged;
            txtPassword.TextChanged += TxtPassword_TextChanged;

            btnAssistenciaTecnica.Click += delegate
            {
                var result = new ProgramasExternos().Executar();
                if (!result)
                    MessageBox.Show("Assistencia não Executada", "Solicitação de Assistência", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };
        }
        private void BtnMudar_Password_Click(object sender, EventArgs e)
        {
            using (var forms = new frmUsuariosRecovery(null))
            {
                OpenFormsDialog.ShowForm(this, null, forms);
            }
        }
        private void TxtPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text.Trim().Equals(string.Empty))
                errorProvider1.SetError(txtPassword, "Este campo não permite valores nulos");
            else
                errorProvider1.Clear();
        }
        private void TxtUsuários_TextChanged(object sender, EventArgs e)
        {
            if (txtUserName.Text.Trim().Equals(string.Empty))
                errorProvider1.SetError(txtUserName, "Este campo não permite valores nulos");
            else
                errorProvider1.Clear();
        }

        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            conLogin = ObjectoUserSetings.Default;
            if (!string.IsNullOrWhiteSpace(txtUserName.Text) && !string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                conLogin.Estado = (bool)checkEdit11.EditValue;
                conLogin.Nome = txtUserName.Text;
                conLogin.Senha = txtPassword.Text;
                conLogin.Save();
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            conLogin = ObjectoUserSetings.Default;
            if (conLogin.Estado)
            {
                checkEdit11.EditValue = (bool)conLogin.Estado;
                txtUserName.Text = conLogin.Nome;
                txtPassword.Text = conLogin.Senha;
                btnEntrar.Focus();
            }
        }
        private async void BtnEntrar_Click(object sender, EventArgs e)
        {
            if (IsFormsValida())
            {
                try
                {
                    Cursor = Cursors.WaitCursor;
                    var result = await userModels.Login(txtUserName.Text, txtPassword.Text);
                    switch (result.UserState)
                    {
                        case UserState.IsValid:
                            Program.Usuarios = result.Models;
                            ApplicarPermissoes(result.Models);
                            break;
                        case UserState.Invalid:
                            MessageBox.Show("Nome de Usuário ou senha esta incorrecta", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        case UserState.Standbay:
                            MessageBox.Show("Usuario encontra-se desativado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        case UserState.Invalid_Grpos:
                            MessageBox.Show("Usuario encontra-se sem um Grupo associado!... Peça ao Admin para reencerir por favor", "Erro de Grupo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        case UserState.Invalid_First_Values:
                            await new BibliotecaContextData(new BiblioteContext()).InsertFirstValues();
                            break;
                        default:
                            MessageBox.Show("Desculpe mais este Usário não tem permissões Associada", "Permissões", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                    }
                }
                finally
                {
                    Cursor = Cursors.Default;
                    txtUserName.SelectAll();
                    txtUserName.Focus();
                }       
            }
        }

        private void ApplicarPermissoes(UserModels userModels)
        {
            if (checkEdit11.IsOn)
            {
                //Guardar Configurações
                conLogin.Estado = (bool)checkEdit11.EditValue;
                conLogin.Nome = txtUserName.Text;
                conLogin.Senha = txtPassword.Text;
                conLogin.Save();
            }   

            var admin = new MenuDesign(userModels.GruposModels.PermissoesModels, new IPAGEBiblioteca.Repository.LogsRepository(new BiblioteContext()));
            this.Visible = false;
            admin.Show();
            admin.FormClosing += delegate { this.Visible = true; };
        }

        private bool IsFormsValida()
        {
            if (string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                MessageBox.Show("Nome de Usuário em Falta", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                MessageBox.Show("Password em Falta", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #region Combinações de Teclas
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                Application.Exit();
                bool res = base.ProcessCmdKey(ref msg, keyData);
                return res;
            }
            if (keyData == Keys.F1)
            {
                txtPassword.Text = string.Empty;
                txtUserName.Text = string.Empty;
                txtUserName.Focus();
                bool res = base.ProcessCmdKey(ref msg, keyData);
                return res;
            }
            if (keyData == Keys.Enter)
            {
                BtnEntrar_Click(null, null);
                bool res = base.ProcessCmdKey(ref msg, keyData);
                return res;
            }
            return false;
        }
        #endregion

        #region Mover formulátios
        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                cX = e.X;
                cY = e.Y;
                mover = true;
            }
        }
        private void Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mover)
            {
                this.Left += e.X - (cX - groupControl1.Left);
                this.Top += e.Y - (cY - groupControl1.Top);
            }
        }
        private void Panel1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                mover = false;
        }
        #endregion
    }
}