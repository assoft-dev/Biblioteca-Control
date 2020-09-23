namespace IPAGEBiblioteca.Views.ControlView
{
    using DevExpress.XtraBars.Docking2010;
    using DevExpress.XtraEditors;
    using IPAGEBiblioteca.Controllers.Helps;
    using IPAGEBiblioteca.Models;
    using IPAGEBiblioteca.Models.Enums;
    using IPAGEBiblioteca.Models.Helps;
    using IPAGEBiblioteca.Report;
    using IPAGEBiblioteca.Repository;
    using IPAGEBiblioteca.Repository.Helps;
    using IPAGEBiblioteca.Repository.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public partial class frmPedidosRequisicoesAdd : XtraUserControl
    {
        #region Variaveis Globais
        private readonly IPedidoModels pedidoModels;
        private readonly IAlunoModels alunoModels;
        private readonly IStocksModels stocksModels;
        #endregion

        #region Construtores
        public frmPedidosRequisicoesAdd(IPedidoModels pedidoModels, 
                                        IAlunoModels alunoModels,
                                        IStocksModels stocksModels)
        {
            InitializeComponent();
            this.pedidoModels = pedidoModels;
            this.alunoModels = alunoModels;
            this.stocksModels = stocksModels;
            this.Load += delegate { LoaderFormsXML(); Loader(); };
            btnClose.Click += delegate { SaveFormsXML(); };
            txtCodigo.EditValueChanged += IDTextEdit_TextChanged;
            windowsUIButtonPanel1.ButtonClick += WindowsUIButtonPanel1_ButtonClick;

            txtProduto.KeyDown += TxtProduto_KeyDown;
            txtProduto.Validated += delegate { Edit(txtProduto.Text); };
            txtProduto.ButtonClick += TxtProduto_ButtonClick;
            txtAcrescer.EditValueChanged += TxtAcrescer_EditValueChanged;
            txtAcrescer.KeyPress += TxtAcrescer_KeyPress;
            //txtAcrescer
            //btnAdicionar.Click += delegate { Execute(); };

            //if (alunoModels != null)
            //{
            //    IDTextEdit.EditValue = alunoModels.ID;
            //    txtInstituicao.EditValue = alunoModels.InstituicaoID;
            //    txtTurma.EditValue = alunoModels.TurmaID;
            //    txtNome.EditValue = alunoModels.Nome;
            //    txtNumeroEstudante.EditValue = alunoModels.NumeroEstudante;
            //    txtdataNascimento.EditValue = alunoModels.DataNascimento;
            //    txtdataRegisto.EditValue = alunoModels.DataRegisto;
            //    IsValidoToggleSwitch.EditValue = alunoModels.IsValido;
            //    txtSexo.EditValue = (SexoModels)alunoModels.Sexo;
            //    txtPratileiraPosicao.EditValue = (int)alunoModels.Idate;
            //    txtNumeroEstudante.Focus();
            //}
            //else
            //{
            //    txtdataRegisto.DateTime = DateTime.Now;
            //    txtNumeroEstudante.Focus();
            //}
            btnAddForenty1.Click += BtnAddForenty_Click;
            txtDataEntrada.Validated += TxtdataNascimento_Validating;


            // Menu de contexto 2
            contextMenuStrip2.Opened += ContextMenuStrip2_Opened;
            btnAumentar.Click += delegate { btnAumetar_Click(); };
            btnDimunir.Click += delegate { btnDiminuir_Click(); };
            btnExcluir.Click += delegate { btnExcluir_Click(); };

            txtEstudantes.EditValueChanged += TxtEstudantes_EditValueChanging;
            produtoStocksModelsBindingSource.DataSource = new List<ProdutoStocksModels>();
        }

        private void TxtProduto_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            using (var forms = new frmStocksAdd(null, new StocksModelsRepository(new BiblioteContext()),
                                                     new LivrosRepository(new BiblioteContext())))
            {
                var usercontrol = OpenFormsDialog.ShowForm(null, forms);
                if (usercontrol == DialogResult.OK)
                    Loader();
            }
        }

        private void TxtEstudantes_EditValueChanging(object sender, EventArgs e)
        {
            var estudante = txtEstudantes.GetSelectedDataRow() as AlunoModels;
            if (estudante != null)
            {
                txtEstudanteNome.EditValue = estudante.Nome;
                txtEstudanteBI.EditValue = estudante.NumeroEstudante;
            }
        }
        private void TxtdataNascimento_Validating(object sender, EventArgs e)
        {
            var idade = (txtDataEntrada.DateTime - DateTime.Now);
            txtIdade.Value = (decimal) idade.TotalDays;
        }

        private void BtnAddForenty_Click(object sender, EventArgs e)
        {
            using (var forms = new frmAlunosAdd(null, new AlunoRepository(new BiblioteContext()),
                                                      new InstituicaoRepository(new BiblioteContext()),
                                                      new TurmaRepository(new BiblioteContext())))
            {
                var usercontrol = OpenFormsDialog.ShowForm(null, forms);
                if (usercontrol == DialogResult.OK)
                    Loader();
            }
        }
        private void IDTextEdit_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodigo.Text) || txtCodigo.Text.Equals("0"))
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
            alunoModelsBindingSource.DataSource = alunoModels.GetAll()
                                                             .Include(x => x.Instituicao)
                                                             .Include(x => x.Turma).ToList();

            txtEstadoPedido.Properties.DataSource = Enum.GetValues(typeof(PedidosEstado));

            var result = stocksModels.GetAll().Include(x => x.LivrosModels).Select
                (x => x.LivrosModels.Referencia).ToList();

            AutoCompleteDev.Autocomplete(txtProduto, result);
        }

        #region Guardar Forms
        private void LoaderFormsXML()
        {
            #region LoaderLayer
            var caminho = SaveLayoutXML.Loader(this.Name);
            try
            {
                if (!string.IsNullOrWhiteSpace(caminho))
                {
                    layoutControl1.RestoreLayoutFromXml(caminho);
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
                layoutControl1.SaveLayoutToXml(caminho);
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
            if (txtEstudantes.EditValue == null)
            {
                XtraMessageBox.Show(string.Empty +
                                   "Descupe notamos que ainda não foi Cadastrado os estudantes!..." +
                                   "Tente Cadastrar um Pagamento por favor", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEstudantes.ShowPopup();
                txtEstudantes.Focus();
                return false;
            }
            if (txtEstadoPedido.EditValue == null)
            {
                XtraMessageBox.Show(string.Empty +
                                   "Descupe notamos que ainda não foi selecionado nehuma Acção!..." +
                                   "Tente Cadastrar um Pagamento por favor", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEstadoPedido.ShowPopup();
                txtEstadoPedido.Focus();
                return false;
            }
            if (gridControl1.DataSource == null)
            {
                XtraMessageBox.Show("Desculpe não foi adicionado nada na Bandeja", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEstadoPedido.Focus();
                return false;
            }
            else
                return true;
        }
        #region Metodos
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
            txtCodigo.EditValue = string.Empty;
            txtCodigoProdutoStocs.EditValue = string.Empty;
            txtProduto.EditValue = string.Empty;
            txtQuantidadeStocks.EditValue = string.Empty;
            txtPrecoUntario.EditValue = string.Empty;
            txtQuantidadeActual.EditValue = string.Empty;
            txtAcrescer.EditValue = string.Empty;
            txtTotalGeral.EditValue = string.Empty;
            txtProduto.Focus();
        }
        private async void ApagarDados()
        {
            if (MessageBox.Show("Tens a certeza de que queres mesmo apagar esta infromação?",
                "Perda de Dados Permanente", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                try
                {
                    if (await pedidoModels.Delete(new PedidosModels { ID = (int)txtCodigo.EditValue, }))
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
        private void TxtAcrescer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                Execute();
        }

        private void TxtProduto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                Edit(txtProduto.Text);
            }
        }

        void btnExcluir_Click()
        {
            var result = GetFaturaReciboSelected();
            if (result != null)
                (produtoStocksModelsBindingSource.DataSource as List<ProdutoStocksModels>).Remove(result);
            gridControl1.RefreshDataSource();
        }
        void btnDiminuir_Click()
        {
            var result = produtoStocksModelsBindingSource.Current as ProdutoStocksModels;

            if (result != null)
            {
                result.Quantidade += 1;
                result.SubTotal += result.Quantidade * result.PrecoUnitario;
                gridControl1.RefreshDataSource();
            }
        }
        void btnAumetar_Click()
        {
            var result = produtoStocksModelsBindingSource.Current as ProdutoStocksModels;

            if (result != null)
            {
                result.Quantidade -= 1;
                result.SubTotal += result.Quantidade * result.PrecoUnitario;
                gridControl1.RefreshDataSource();
            }
        }
        private void ContextMenuStrip2_Opened(object sender, EventArgs e)
        {
            var result = GetFaturaReciboSelected();
            if (result != null)
            {
                btnAumentar.Enabled = true;
                btnDimunir.Enabled = true;
                btnExcluir.Enabled = true;
            }
            else
            {
                btnAumentar.Enabled = false;
                btnDimunir.Enabled = false;
                btnExcluir.Enabled = false;
            }
        }
        ProdutoStocksModels GetFaturaReciboSelected()
        {
            if (gridView1.SelectedRowsCount > 0)
                if (gridView1.FocusedRowHandle >= 0)
                    return (produtoStocksModelsBindingSource.Current as ProdutoStocksModels);
                else
                    return null;
            return null;
        }
        List<ProdutoStocksModels> GetFaturaReciboAll()
        {
            if (gridView1.SelectedRowsCount > 0)
                if (gridView1.FocusedRowHandle >= 0)
                    return (produtoStocksModelsBindingSource.DataSource as List<ProdutoStocksModels>).ToList();
                else
                    return null;
            return null;
        }

        private void Execute()
        {
            if (Validar1())
            {
                // Não adiconar valores repetidos
                var result = produtoStocksModelsBindingSource.DataSource as List<ProdutoStocksModels>;

                if (result.Count > 0)
                {
                    foreach (var item in result.Where(x => x.Designacao.ToUpper().Equals(txtProduto.Text.ToUpper())))
                    {
                        item.Quantidade += txtAcrescer.Value;
                        item.SubTotal += txtAcrescer.Value * item.PrecoUnitario;
                        //item.IVA += ((txtPrecoUntario.Value * txtAcrescer.Value) * txtIVAImposto.Value) / 100;
                        gridControl1.RefreshDataSource();
                        NovoDado();
                        return;
                    }
                    produtoStocksModelsBindingSource.Add(
                                                    new ProdutoStocksModels
                                                    {
                                                        Codigo = string.IsNullOrWhiteSpace(txtCodigo.Text) ? 0 : Convert.ToInt32(txtCodigo.Text),
                                                        CodigoStocksID = string.IsNullOrWhiteSpace(txtCodigoProdutoStocs.Text) ? 0 : Convert.ToInt32(txtCodigoProdutoStocs.Text),
                                                        Designacao = txtProduto.Text,
                                                        PrecoUnitario = txtPrecoUntario.Value,
                                                        Quantidade = txtAcrescer.Value,
                                                        SubTotal = txtPrecoUntario.Value * txtAcrescer.Value,
                                                        //Custo = txtCustoSuportado.Value,
                                                        //PrecoUnitarioAquisicao = txtPreçoCompra.Value,
                                                        //IVA = txtIVAImposto.Value != 0 ? ((txtPrecoUntario.Value * txtAcrescer.Value) * txtIVAImposto.Value) / 100 : txtIVAImposto.Value,
                                                    });
                    NovoDado();
                }
                else
                {
                    produtoStocksModelsBindingSource.Add(
                  new ProdutoStocksModels
                  {
                      Codigo = string.IsNullOrWhiteSpace(txtCodigo.Text) ? 0 : Convert.ToInt32(txtCodigo.Text),
                      CodigoStocksID = string.IsNullOrWhiteSpace(txtCodigoProdutoStocs.Text) ? 0 : Convert.ToInt32(txtCodigoProdutoStocs.Text),
                      Designacao = txtProduto.Text,
                      PrecoUnitario = txtPrecoUntario.Value,
                      Quantidade = txtAcrescer.Value,
                      SubTotal = txtPrecoUntario.Value * txtAcrescer.Value,  
                  });
                  NovoDado();
                }
            }
        }

        private bool Validar1()
        {
            return true;
        }

        #region Calcular
        private void TxtAcrescer_EditValueChanged(object sender, EventArgs e)
        {
            if (txtQuantidadeStocks.Value != 0)
            {
                txtQuantidadeActual.Value = txtQuantidadeStocks.Value - txtAcrescer.Value;
                txtTotalGeral.Value = txtAcrescer.Value * txtPrecoUntario.Value;
                if (txtQuantidadeActual.Value < 0)
                {
                    txtAcrescer.Value = 0;
                    txtQuantidadeActual.Value = txtQuantidadeStocks.Value;
                    txtTotalGeral.Value = 0;
                }

                //Activar AdicionalButton
                if (!string.IsNullOrEmpty(txtProduto.Text))
                    btnAdicionar.Enabled = true;
                else
                    btnAdicionar.Enabled = false;
            }
        }
        #endregion

        private void Edit(string text)
        {
            var result = stocksModels.GetAll().Include(x => x.LivrosModels)
                                              .Where(x => x.LivrosModels.Referencia.ToUpper() == text.ToUpper()).FirstOrDefault();
            if (result == null)
            {
                txtProduto.Text.ToUpper();
                txtQuantidadeActual.Value = 0;
                txtPrecoUntario.Value = 0;
                txtQuantidadeStocks.Value = 0;
                txtQuantidadeActual.Value = 0;
                //txtEstadoPedido.EditValue = 0;
                txtCodigo.Text = 0.ToString();
                txtCodigoProdutoStocs.Text = 0.ToString();
                txtCodigoProdutoStocs.EditValue = 0;
                txtPrecoUntario.Focus();
            }
            else
            {
                // Situação 1
                var stocksResult = result;
                if (stocksResult != null)
                {
                    txtCodigo.Text = stocksResult.LivrosModels.ID.ToString();
                    txtCodigoProdutoStocs.EditValue = stocksResult.ID;
                    txtProduto.Text = result.LivrosModels.Referencia;
                    txtPrecoUntario.Value = stocksResult.PrecoUnitario;
                    txtQuantidadeStocks.Value = stocksResult.Qtd;
                    txtQuantidadeActual.Value = stocksResult.Qtd;
                    //txtPreçoCompra.Value = stocksResult.Produto.Preco_Compra;
                     // txtEstadoPedido.EditValue = stocksResult.Produto.FornecedorID;
                    txtAcrescer.Focus();
                }
                else
                {
                    MessageBox.Show("Este Produto nunca tinha sido adiquirido", "Produto em falta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    var r = txtProduto.Text;
                    //LimparCampos();
                    txtProduto.Text = r;
                    txtProduto.SelectAll();
                }
            }
        }
        private string GetFaturaLast()
        {
            return pedidoModels.GetDocument();
        }
        private async void GuardarDados()
        {
            if (Validacao())
            {
                Cursor = Cursors.WaitCursor;

                try
                {
                    await ApplyCompras();

                    NovoDado();
                    Loader();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }
        }
        private async Task ApplyCompras()
        {
            try
            {
                #region Busca de Faturas
                var faturaOrigianl_ = GetFaturaLast();
                var tableall = GetFaturaReciboAll();
                #endregion

                // Envio de Valores
                using (var tran = new TransationRepository(new BiblioteContext(), true))
                {
                    await tran.executionStrategy.ExecuteAsync(async () =>
                    {
                        tran.Transaction = tran.Context.Database.BeginTransaction();

                        #region FaturasCompras
                        var faturas = new PedidosModels
                        {
                            DataEntrega = DateTime.Now,
                            IsValid = (bool) txtDisponibilidade.IsOn,
                            DataReserva = txtDataEntrada.DateTime,
                            Data = DateTime.Now.Date,
                            DocNumero = faturaOrigianl_,
                            PedidosEstado = (PedidosEstado)txtEstadoPedido.EditValue,
                            Totalgeral = tableall.Sum(x => x.SubTotal),
                            AlunoModelsID = (int) txtEstudantes.EditValue,                       
                        };
                        tran.DoInsert(faturas);
                        #endregion

                        var resultData1 = tableall;
                        foreach (var item in resultData1)
                        {
                            var faturasOrdem = new PedidosOrdemModels
                            {
                                Data = txtDataEntrada.DateTime,
                                PrecoUnitario = item.PrecoUnitario,
                                Quantidade = (int)item.Quantidade,
                                DocNumero = faturaOrigianl_,
                                LivrosModelsID = item.Codigo,  
                            };
                            tran.DoInsert(faturasOrdem);

                            //Stocks
                            var returnModelStocks = await tran.DoGet<StocksModels>(x => x.ID == item.CodigoStocksID)
                                                       .FirstOrDefaultAsync();
                            returnModelStocks.Qtd -= (int)item.Quantidade;
                            tran.DoUpdate(returnModelStocks);
                        }
                        #endregion

                        if ((await tran.EndTransaction()).estado)
                        {
                            MessageBox.Show("Produto Vendido Com Sucesso Aquarde o recibo de comprovação\nTambém diminuimos no Stock");
                            Imprimir_Faturas(faturaOrigianl_);
                            NovoDado();
                            produtoStocksModelsBindingSource.DataSource = null;
                        }
                        else
                            XtraMessageBox.Show("Desculpe mais esta venda não foi efectivada", "Má conclusão", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    });
                }
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message, "Erro de SQL",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        async void Imprimir_Faturas(string txtBillNo)
        {
            // Imprimir Faturas mais Recibo
            try
            {
                Cursor = Cursors.WaitCursor;
                var Docs = await pedidoModels.GetAll().Include(x => x.AlunoModels)
                                             .Include(x => x.PedidosOrdemModels)
                                             .ThenInclude(x => x.LivrosModels)    
                                             .Where(x => x.DocNumero.Equals(txtBillNo)).FirstOrDefaultAsync();
                if (Docs != null)
                    ReportControllers.GetReport(new rptPedidosFactura(Docs), false);
            }
            catch (Exception exe)
            {
                EscreverLogs.Escrever(exe);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
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
            if (keyData == Keys.F1)
            {
                NovoDado();
                bool res = base.ProcessCmdKey(ref msg, keyData);
                return res;
            }
            if ((keyData == Keys.F2))
            {
                GuardarDados();
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

        #endregion
    }
}
