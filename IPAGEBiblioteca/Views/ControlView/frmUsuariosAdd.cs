namespace IPAGEBiblioteca.Views.ControlView
{
    using DevExpress.XtraBars.Docking2010;
    using DevExpress.XtraEditors;
    using IPAGEBiblioteca.Controllers.Helps;
    using IPAGEBiblioteca.Models;
    using IPAGEBiblioteca.Repository;
    using IPAGEBiblioteca.Repository.Helps;
    using IPAGEBiblioteca.Repository.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;

    public partial class frmUsuariosAdd : XtraUserControl
    {
        private readonly UserRepository userRepository;
        private readonly IGruposRepository gruposRepository;

        public frmUsuariosAdd(UserModels userModels, UserRepository userRepository,
                                                     IGruposRepository gruposRepository)
        {
            InitializeComponent();
            this.Load += delegate { LoaderFormsXML(); Loader(); };
            btnClose.Click += delegate { SaveFormsXML(); };
            IDTextEdit.EditValueChanged += IDTextEdit_TextChanged;

            windowsUIButtonPanel1.ButtonClick += WindowsUIButtonPanel1_ButtonClick; ;
            this.userRepository = userRepository;
            this.gruposRepository = gruposRepository;
            if (userModels != null)
            {
                IDTextEdit.EditValue = userModels.ID;
                GruposModelsLookUpEdit.EditValue = userModels.GruposModels.ID;
                UserNameTextEdit.EditValue = userModels.UserName;
                PasswordTextEdit.EditValue = userModels.Password;
                EmailTextEdit.EditValue = userModels.Email;
                IsValidoToggleSwitch.EditValue = userModels.IsValido;
                UserNameTextEdit.Focus();
            }
            btnAddForenty.Click += BtnAddForenty_Click;
            EmailTextEdit.Validating += EmailTextEdit_Validating;
            UserNameTextEdit.TextChanged += UserNameTextEdit_TextChanged;
        }

        private void UserNameTextEdit_TextChanged(object sender, EventArgs e)
        {
            string fullName = UserNameTextEdit.Text;
            string[] names = fullName.Split(' ');
            EmailTextEdit.Text = names.First() + names.Last() + "@Gmail.com";
        }

        private void EmailTextEdit_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            EmailTextEdit.Text = EmailTextEdit.Text.Trim();

            if (!string.IsNullOrWhiteSpace(EmailTextEdit.Text.Trim()))
            {
                if (!EmailValidade.GetIstance().IsValidEmail(EmailTextEdit.Text.Trim()))
                {
                    XtraMessageBox.Show("Email Inválido coloque um email válido", "Email Inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    EmailTextEdit.Focus();
                }
                else
                {
                    var result = userRepository.GetAll().Where(x => x.Email.ToLower() == EmailTextEdit.Text.ToLower()).FirstOrDefault();
                    if (result != null)
                    {
                        if (string.IsNullOrWhiteSpace(IDTextEdit.Text) || IDTextEdit.Text.Equals(0))
                        {
                            XtraMessageBox.Show("Lamentamos mais este E-Mail já Existe no Sistema", "E-Mail Existente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            EmailTextEdit.Focus();
                        }
                        else
                        {
                            if (result.ID != int.Parse(IDTextEdit.Text))
                            {
                                XtraMessageBox.Show("Lamentamos mais este E-Mail já Existe no Sistema", "E-Mail Existente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                EmailTextEdit.Focus();
                            }
                        }
                    }
                }
            }
        }

        private void BtnAddForenty_Click(object sender, EventArgs e)
        {
            using (var forms = new frmGruposAdd(null,
                                                new GruposRepository(new BiblioteContext()),
                                                new PermissoesRepository(new BiblioteContext())))
            {
                var usercontrol = OpenFormsDialog.ShowForm(null, forms);
                if (usercontrol == DialogResult.OK)
                    Loader();
            }
        }
        private void IDTextEdit_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(IDTextEdit.Text) || IDTextEdit.Text.Equals("0"))
            {
                // Novo 0, Guardar 1, Delete 3
                windowsUIButtonPanel1.Buttons[1].Properties.Enabled = true;
                windowsUIButtonPanel1.Buttons[3].Properties.Enabled = false;
            }
            else
            {
                // Novo 0, Guardar 1, Delete 3
                windowsUIButtonPanel1.Buttons[1].Properties.Enabled = true;
                windowsUIButtonPanel1.Buttons[3].Properties.Enabled = true;
            }
        }
        private void Loader()
        {
            gruposModelsBindingSource.DataSource = gruposRepository.GetAll().ToList();
            // Editar
            DataDateEdit.DateTime = DateTime.Now;
        }

        #region Combinações de Teclas
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                LoaderFormsXML();
                this.Dispose();
                bool res = base.ProcessCmdKey(ref msg, keyData);
                return res;
            }
            if (keyData == Keys.F5)
            {
                Loader();
                bool res = base.ProcessCmdKey(ref msg, keyData);
                return res;
            }
            return false;
        }
        #endregion

        #region Guardar Forms
        private void LoaderFormsXML()
        {
            #region LoaderLayer
            var caminho = SaveLayoutXML.Loader(this.Name);
            try
            {
                if (!string.IsNullOrWhiteSpace(caminho))
                {
                    dataLayoutControl1.RestoreLayoutFromXml(caminho);
                }
            }
            catch (System.Exception)
            {
                XtraMessageBox.Show("Seu Layote esta mal estruturado por favor apage apartir do Caminho: \n" + caminho,
                                    "Layote da Pagina com mal estruturação.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            #endregion
        }
        private void SaveFormsXML()
        {
            #region SaveForms
            var caminho = SaveLayoutXML.Restore(this.Name);
            try
            {
                dataLayoutControl1.SaveLayoutToXml(caminho);
                this.btnClose.DialogResult = DialogResult.OK;
            }
            catch (System.Exception)
            {
                XtraMessageBox.Show("Seu Layote esta mal estruturado por favor apage e volte a abrir o APP: \n" + caminho,
                                    "Layote da Pagina com mal estruturação.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            #endregion
        }
        #endregion

        private bool Validacao()
        {
            if (string.IsNullOrWhiteSpace(UserNameTextEdit.Text))
            {
                MessageBox.Show("Desculpe o nome do Usuário é imperactivo", "Falta de Informação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UserNameTextEdit.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(PasswordTextEdit.Text))
            {
                MessageBox.Show("Desculpe a senha tem que existir", "Falta de Informação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PasswordTextEdit.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(EmailTextEdit.Text))
            {
                MessageBox.Show("Desculpe o E-Mail é um campo obrigatório", "Falta de Informação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                EmailTextEdit.Focus();
                return false;
            }
            if ((gruposModelsBindingSource.Current as GruposModels) == null)
            {
                MessageBox.Show("Desculpe selecione um Grupo de Trabalho!", "Falta de Informação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                EmailTextEdit.Focus();
                return false;
            }
            return true;
        }

        private void WindowsUIButtonPanel1_ButtonClick(object sender, ButtonEventArgs e)
        {
            switch (e.Button.Properties.Caption)
            {
                case "Novo":
                    NovoDado();
                    break;
                case "Guardar":
                    GuardarDados();
                    break;
                case "Apagar":
                    ApagarDados();
                    break;
            }
        }
        private void NovoDado()
        {
            if (Validacao())
            {
                IDTextEdit.Text = string.Empty;
                UserNameTextEdit.Text = string.Empty;
                PasswordTextEdit.Text = string.Empty; 
                EmailTextEdit.Text = string.Empty;
                DataDateEdit.DateTime = DateTime.Now;
                UserNameTextEdit.Focus();
            }
        }
        private async void GuardarDados()
        {
            if (Validacao())
            {
                var codigo = string.IsNullOrWhiteSpace(IDTextEdit.Text) || IDTextEdit.Text.Equals("0");
                var models  = new UserModels
                {
                    ID = codigo ? 0 : (int) IDTextEdit.EditValue,
                    GruposModelsID =  (int) GruposModelsLookUpEdit.EditValue,
                    Password = HashControl.GetMD5Hash((string) PasswordTextEdit.EditValue),
                    Email = (string) EmailTextEdit.EditValue,
                    IsValido = (bool) IsValidoToggleSwitch.EditValue,
                    Data = DataDateEdit.DateTime,
                    UserName = UserNameTextEdit.Text,
                };
                var result = await  userRepository.Guardar(models);
                if (result)
                    XtraMessageBox.Show("Inserido com Exito", "Inserção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private async void ApagarDados()
        {
            if (MessageBox.Show("Tens a certeza de que queres mesmo apagar esta infromação?",
                "Perda de Dados Permanente", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                try
                {
                    if (await userRepository.Delete(new UserModels { ID = (int)IDTextEdit.EditValue, }))
                    {
                        XtraMessageBox.Show("Apagado com Exito", "Apagar infromação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (System.Exception exe)
                {
                    XtraMessageBox.Show(MessageCaption.ErrorRelacionalShipe + exe.Message,
                        "Apagar infromação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }     
    }
}
