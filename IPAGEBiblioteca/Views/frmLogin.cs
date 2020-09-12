namespace IPAGEBiblioteca.Views
{
    using IPAGEBiblioteca.Models;
    using IPAGEBiblioteca.Repository.Helps;
    using IPAGEBiblioteca.Repository.Interfaces;
    using System;
    using System.Windows.Forms;

    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        private int cX, cY;
        private bool mover;
        private readonly IUserModels userModels;
        public frmLogin(IUserModels userModels)
        {
            InitializeComponent();
            this.btnCancelar.Click += BtnCancelar_Click;
            btnEntrar.Click += BtnEntrar_Click;
            this.userModels = userModels;
        }

        private async void BtnEntrar_Click(object sender, EventArgs e)
        {
            if (IsFormsValida())
            {
                var result = await userModels.Login(txtUserName.Text, txtPassword.Text);
                switch (result.UserState)
                {
                    case UserState.IsValid:
                        ApplicarPermissoes(result.Models);                    
                        break;
                    case UserState.Invalid:
                        MessageBox.Show("Nome de Usuário ou senha esta incorrecta", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case UserState.Standbay:
                        MessageBox.Show("Usuario encontra-se desativado","Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        }

        private void ApplicarPermissoes(UserModels userModels)
        {
            using (var admin = new MenuDesign(userModels.GruposModels.PermissoesModels))
            {
                this.Visible = false;
                admin.Show();
                admin.FormClosing += delegate { this.Visible = true; };
            }
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