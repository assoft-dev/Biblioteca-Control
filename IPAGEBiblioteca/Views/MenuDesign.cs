namespace IPAGEBiblioteca.Views
{
    using DevExpress.LookAndFeel;
    using DevExpress.XtraEditors;
    using IPAGEBiblioteca.Controllers.Configura;
    using IPAGEBiblioteca.Controllers.Helps;
    using IPAGEBiblioteca.Models;
    using IPAGEBiblioteca.Repository;
    using IPAGEBiblioteca.Repository.Helps;
    using IPAGEBiblioteca.Repository.Interfaces;
    using IPAGEBiblioteca.Views.ControlView;
    using IPAGEBiblioteca.Views.ViewHelps;
    using System;
    using System.Linq;
    using System.Net;
    using System.Windows.Forms;

    public partial class MenuDesign : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly PermissoesModels permissoesModels;
        private readonly IlogModels logsRepository;
        public Timer Time_ { get; set; }
        private ObjectoUserSetings objectoUserSetings { get; set; }

        public MenuDesign(PermissoesModels permissoesModels,
                          IlogModels logsRepository)
        {
            InitializeComponent();
            this.permissoesModels = permissoesModels;
            this.logsRepository = logsRepository;
            Program.menuDesign = this;
            objectoUserSetings = new ObjectoUserSetings();


            #region Time
            Time_ = new Timer();
            Time_.Enabled = true;
            Time_.Start();
            Time_.Tick += delegate { barStaticItem2.Caption = $"{DateTime.Now:F}"; };

            // Sistema/Usuarios
            btnUsuariosConsultas.Click += delegate { OpenForms(new frmUsuarios(new UserRepository(new BiblioteContext()))); };
            btnUsuariosAuditoria.Click += delegate { OpenForms(new frmLogs(new LogsRepository(new BiblioteContext()))); };
            btnGrupos.Click += delegate { OpenForms(new frmGrupos(new GruposRepository(new BiblioteContext()))); };
            btnPermissoes.Click += delegate { OpenFormsDialog.ShowForm(this, null, new frmPermisssoesAdd(new PermissoesRepository(new BiblioteContext()))); };

            // Biblioteca
            btnLivros.Click += delegate { OpenForms(new frmLivros(new LivrosRepository(new BiblioteContext()))); };
            btnAutores.Click += delegate { OpenForms(new frmAutor(new AutorRepositoty(new BiblioteContext()))); };
            btnEditora.Click += delegate { OpenForms(new frmEditora(new EditoraRepository(new BiblioteContext()))); };
            btnPais.Click += delegate { OpenForms(new frmPais(new PaisRepository(new BiblioteContext()))); };

            // Estudantes
            btnAlunoConsultas.Click += delegate { OpenForms(new frmAlunos(new AlunoRepository(new BiblioteContext()))); };
            btnInstituicaoConsultas.Click += delegate { OpenForms(new frmInstituicao(new InstituicaoRepository(new BiblioteContext()))); };
            btnClasseConsultas.Click += delegate { OpenForms(new frmClasse(new ClasseRepository(new BiblioteContext()))); };
            btnturmaConsultas.Click += delegate { OpenForms(new frmTurma(new TurmaRepository(new BiblioteContext()))); };

            //Toos
            btnTatil.CheckedChanged += delegate {
                WindowsFormsSettings.TouchUIMode = btnTatil.Checked == true ? TouchUIMode.True : TouchUIMode.False;
                ObjectoUserSetings.Default.TouchUI = btnTatil.Checked;
                ObjectoUserSetings.Default.Save();
            };
            //Requisições
            StocksConsultas.Click += delegate { OpenForms(new frmStocks(new StocksModelsRepository(new BiblioteContext()))); };
            StocksRegistar.Click += delegate {
                OpenFormsDialog.ShowForm(this, null, new frmStocksAdd(null, new StocksModelsRepository(new BiblioteContext()),
                                                                            new LivrosRepository(new BiblioteContext())));
            };
            RequisicoesLeitura.Click += delegate {
                OpenFormsDialog.ShowForm(this, null, 
                                               new frmPedidosRequisicoesAdd(new PedidosRepository(new BiblioteContext()), 
                                                                            new AlunoRepository(new BiblioteContext()),
                                                                            new StocksModelsRepository(new BiblioteContext())));
            };
            RequisicoesPedidos.Click += delegate { OpenForms(new frmPedidosRequisicoes(new PedidosRepository(new BiblioteContext()))); };

            AplicarPermissoes();
            FormsThemeReader();
            SetStatuBar();
            this.FormClosed += MenuDesign_FormClosed;
            btnDefinicoes.Click += delegate { OpenFormsDialog.ShowForm(this, null, new frmDefinicoesAdd(new DefinicoesRepository(new BiblioteContext()))); };
            //tabbedView1.DocumentClosed += TabbedView1_DocumentClosed;

            tabbedView1.AddDocument(new frmBackground());
        }

        private void MenuDesign_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormsThemeCloser();
        }

        private void AplicarPermissoes()
        {
            if (permissoesModels != null)
            {
                // Aplicar Todas as Permissoes;
                btnUsuarios.Enabled = permissoesModels.Usuarios;
                btnUsuariosConsultas.Enabled = permissoesModels.UsuariosConsultas;
                btnUsuariosAuditoria.Enabled = permissoesModels.UsuariosGrupos;
                btnPermissoes.Enabled = permissoesModels.UsuariosPermissoes;

                // Biblioteca
                btnBiblioteca.Enabled = permissoesModels.Bibliotecas;
                btnLivros.Enabled = permissoesModels.LivrosConsultas;
                btnAutores.Enabled = permissoesModels.AutoresConsultas;
                btnEditora.Enabled = permissoesModels.EditoraConsultas;
                btnPais.Enabled = permissoesModels.PaisConsultas;

                // Estudantes
                btnEstudante.Enabled = permissoesModels.Estudantes;
                btnAlunoConsultas.Enabled = permissoesModels.AlunoConsultas;
                btnInstituicaoConsultas.Enabled = permissoesModels.InstituicaoConsultas;
                btnClasseConsultas.Enabled = permissoesModels.ClasseConsultas;
                btnturmaConsultas.Enabled = permissoesModels.TurmaConsultas;

                // Requisições
                StocksRegistar.Enabled = permissoesModels.StocksRegistar;
                StocksConsultas.Enabled = permissoesModels.Stocks;
                RequisicoesLeitura.Enabled = permissoesModels.Leituras;
                RequisicoesPedidos.Enabled = permissoesModels.LeiturasSolicitacoes;
            }
            else
            {
                XtraMessageBox.Show("Não ainda resgistado as permissões", "Permissões não Existentes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Singliton
        private void OpenForms(object control1)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                var control = control1 as Control;

                // Produtos
                tabbedView1.AddOrActivateDocument(x => {
                    return x.Control.Name == control.Name;
                }, () =>
                {
                    control.Text = control.Tag == null ? control.Name : control.Tag.ToString();
                    var text = $"Acesso ao Formulário: {control.Text} as : {DateTime.Now:F}";
                    AddLogsUsuarios(text);
                    return control;
                });
            }
            finally
            {      
                GC.Collect();
                Cursor = Cursors.Default;
            }
        }
        private async void AddLogsUsuarios(string text)
        {
            await logsRepository.Guardar(
                                           new LogsModels
                                           {                                             
                                               DateTime = DateTime.Now,
                                               Referencia = text,
                                               userModelsID = Program.Usuarios.ID,
                                          });
        }
        #endregion

        private void SetStatuBar()
        {
            try
            {
                barHeaderItem8.Caption = string.Format("USUÁRIO: ({0})", Program.Usuarios.UserName);
                barHeaderItem7.Caption = $"{$"Lic: ({Program.LicenceModelsHelps.FullName}) "}" +
                                         $"{$"Lic: ({(Program.LicenceModelsHelps.Dias == "FULL" ? "Genuina" : string.Concat("Faltam: ", Program.LicenceModelsHelps.DiasSimples))})"}";
                
                var hostName = Dns.GetHostName();
                var ipAdress = Dns.GetHostEntry(hostName).AddressList.LastOrDefault();
                barHeaderItem6.Caption = $"SGBD: SQL-SERVER ({ipAdress}) ";
            }
            catch (System.Exception exe)
            {
                EscreverLogs.Escrever(this, exe);
            }
        }
        private void FormsThemeReader()
        {
            defaultLookAndFeel1.LookAndFeel.SkinName = objectoUserSetings.DefaultAppSkin;
            skinPaletteDropDownButtonItem1.Caption = objectoUserSetings.DefaultPalette;
            btnTatil.Checked = objectoUserSetings.TouchUI == true ? true : false;
        }
        private void FormsThemeCloser()
        {
            objectoUserSetings.DefaultAppSkin = defaultLookAndFeel1.LookAndFeel.SkinName;
            objectoUserSetings.DefaultPalette = skinPaletteDropDownButtonItem1.Caption;
            objectoUserSetings.TouchUI = btnTatil.Checked == true ? true : false;
            objectoUserSetings.Save();
        }
    }
    #endregion
}
