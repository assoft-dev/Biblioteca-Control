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
    using System.Linq;
    using System.Windows.Forms;

    public partial class frmAlunosAdd : XtraUserControl
    {
        private readonly IAlunoModels alunoModels;
        private readonly IInstituicaoModels instituicaoModels;
        private readonly ITurmaModels turmaModels;

        public frmAlunosAdd(AlunoModels alunoModels, IAlunoModels alunoModelsRepostory,
                                                     IInstituicaoModels instituicaoModels,
                                                     ITurmaModels turmaModels)
        {
            InitializeComponent();
            this.Load += delegate { LoaderFormsXML(); Loader(); };
            btnClose.Click += delegate { SaveFormsXML(); };
            IDTextEdit.EditValueChanged += IDTextEdit_TextChanged;

            windowsUIButtonPanel1.ButtonClick += WindowsUIButtonPanel1_ButtonClick; ;
            this.alunoModels = alunoModelsRepostory;
            this.instituicaoModels = instituicaoModels;
            this.turmaModels = turmaModels;

            if (alunoModels != null)
            {
                IDTextEdit.EditValue = alunoModels.ID;
                txtInstituicao.EditValue = alunoModels.InstituicaoID;
                txtTurma.EditValue = alunoModels.TurmaID;
                txtNome.EditValue = alunoModels.Nome;
                txtNumeroEstudante.EditValue = alunoModels.NumeroEstudante;
                txtdataNascimento.EditValue = alunoModels.DataNascimento;        
                txtdataRegisto.EditValue = alunoModels.DataRegisto;
                IsValidoToggleSwitch.EditValue = alunoModels.IsValido;
                txtSexo.EditValue = (SexoModels)alunoModels.Sexo;
                EmailTextEdit.EditValue = (string)alunoModels.Email;
                txtPratileiraPosicao .EditValue = (int) alunoModels.Idate;
                txtNumeroEstudante.Focus();
            }
            else
            {
                txtdataRegisto.DateTime = DateTime.Now; 
                txtNumeroEstudante.Focus();
            }
            btnAddForenty1.Click += BtnAddForenty_Click;
            btnAddForenty2.Click += BtnAddForenty_Click2;

            txtSexo.Properties.DataSource = Enum.GetValues(typeof(SexoModels));
            txtSexo.ItemIndex = 0;

            txtdataNascimento.Validating += TxtdataNascimento_Validating;
            EmailTextEdit.Validating += EmailTextEdit_Validating;
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
                    var result = alunoModels.GetAll().Where(x => x.Email.ToLower() == EmailTextEdit.Text.ToLower()).FirstOrDefault();
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
        private void TxtdataNascimento_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var idade = DateTime.Now.Year - txtdataNascimento.DateTime.Year;
            txtPratileiraPosicao.Value = idade;
        }

        private void BtnAddForenty_Click(object sender, EventArgs e)
        {
            using (var forms = new frmInstituicaoAdd(null, new InstituicaoRepository(new BiblioteContext())))
            {
                var usercontrol = OpenFormsDialog.ShowForm(null, forms);
                if (usercontrol == DialogResult.OK)
                    Loader();
            }
        }
        private void BtnAddForenty_Click2(object sender, EventArgs e)
        {
            using (var forms = new frmTurmaAdd(null, new TurmaRepository(new BiblioteContext()), 
                                                     new ClasseRepository(new BiblioteContext())))
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
            instituicaoModelsBindingSource.DataSource = instituicaoModels.GetAll().ToList();
            turmaModelsBindingSource.DataSource = turmaModels.GetAll().ToList();
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
            if (string.IsNullOrWhiteSpace(txtNumeroEstudante.Text))
            {
                MessageBox.Show("Desculpe Digite o numero de Estudante por favor", "Falta de Informação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNumeroEstudante.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("Desculpe digite o nome do Estudante", "Falta de Informação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNome.Focus();
                return false;
            }
            if (txtPratileiraPosicao.Value < 0)
            {
                XtraMessageBox.Show("Desculpe a Idade não pode ser Negativa", "Falta de Informação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtdataNascimento.ShowPopup();
                return false;
            }
            if (string.IsNullOrWhiteSpace(EmailTextEdit.Text))
            {
                XtraMessageBox.Show("Desculpe o Email do estudante é Obrigatório", "Falta de Informação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                EmailTextEdit.Focus();
                return false;
            }
            if (txtInstituicao.EditValue == null)
            {
                MessageBox.Show("Desculpe selecione a Instituição por favor!", "Falta de Informação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtInstituicao.ShowPopup();
                return false;
            }
            if (txtTurma.EditValue == null)
            {
                MessageBox.Show("Desculpe selecione uma Turma!", "Falta de Informação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTurma.ShowPopup();
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
                IDTextEdit.EditValue = string.Empty;
                txtInstituicao.EditValue = string.Empty;
                txtTurma.EditValue = string.Empty;
                txtNumeroEstudante.EditValue = string.Empty;
                txtNome.EditValue = string.Empty;
                txtdataNascimento.EditValue = string.Empty;
                IsValidoToggleSwitch.EditValue = string.Empty;
                txtPratileiraPosicao.EditValue = string.Empty;
                txtdataRegisto.DateTime = DateTime.Now;
                EmailTextEdit.EditValue = string.Empty;
                txtNumeroEstudante.Focus();
            }
        }
        private async void GuardarDados()
        {
            if (Validacao())
            {
                var codigo = string.IsNullOrWhiteSpace(IDTextEdit.Text) || IDTextEdit.Text.Equals("0");
                var models = new AlunoModels
                {
                    ID = codigo ? 0 : (int)IDTextEdit.EditValue,
                    InstituicaoID = (int)txtInstituicao.EditValue,
                    TurmaID = (int)txtTurma.EditValue,
                    Nome = (string)txtNome.EditValue,
                    NumeroEstudante = (string)txtNumeroEstudante.EditValue,
                    DataNascimento = (DateTime)txtdataNascimento.EditValue,
                    DataRegisto = (DateTime)txtdataRegisto.EditValue,
                    IsValido = (bool)IsValidoToggleSwitch.EditValue,
                    Sexo = (SexoModels)txtSexo.EditValue,
                    Email = (string)  EmailTextEdit.EditValue,          
                };
                var result = await alunoModels.Guardar(models);
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
                    if (await alunoModels.Delete(new AlunoModels { ID = (int)IDTextEdit.EditValue, }))
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
