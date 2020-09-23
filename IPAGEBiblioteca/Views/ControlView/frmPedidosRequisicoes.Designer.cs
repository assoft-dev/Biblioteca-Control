namespace IPAGEBiblioteca.Views.ControlView
{
    partial class frmPedidosRequisicoes
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPedidosRequisicoes));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnRefres = new DevExpress.XtraEditors.SimpleButton();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.métodosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuNovo = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuEditar = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuApagar = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuRelatorios = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.comprovativoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pedidosModelsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDocNumero = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDataReserva = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDataEntrega = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPedidosEstado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsValid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReservaDias = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalgeral = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAlunoModelsID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAlunoModels = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPedidosOrdemModels = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pedidosModelsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnRefres);
            this.layoutControl1.Controls.Add(this.dateTimePicker2);
            this.layoutControl1.Controls.Add(this.dateTimePicker1);
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(896, 559);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnRefres
            // 
            this.btnRefres.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRefres.ImageOptions.Image")));
            this.btnRefres.Location = new System.Drawing.Point(786, 12);
            this.btnRefres.Name = "btnRefres";
            this.btnRefres.Size = new System.Drawing.Size(98, 27);
            this.btnRefres.StyleController = this.layoutControl1;
            this.btnRefres.TabIndex = 22;
            this.btnRefres.Text = "Refres";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(382, 12);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(400, 23);
            this.dateTimePicker2.TabIndex = 21;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(34, 12);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(322, 23);
            this.dateTimePicker1.TabIndex = 20;
            // 
            // gridControl1
            // 
            this.gridControl1.ContextMenuStrip = this.contextMenuStrip1;
            this.gridControl1.DataSource = this.pedidosModelsBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(12, 43);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(872, 504);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.métodosToolStripMenuItem,
            this.toolStripSeparator1,
            this.MenuNovo,
            this.MenuEditar,
            this.MenuApagar,
            this.MenuRelatorios,
            this.toolStripSeparator2,
            this.comprovativoToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(227, 272);
            // 
            // métodosToolStripMenuItem
            // 
            this.métodosToolStripMenuItem.Enabled = false;
            this.métodosToolStripMenuItem.Name = "métodosToolStripMenuItem";
            this.métodosToolStripMenuItem.Size = new System.Drawing.Size(226, 38);
            this.métodosToolStripMenuItem.Text = "Métodos";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(223, 6);
            // 
            // MenuNovo
            // 
            this.MenuNovo.Image = ((System.Drawing.Image)(resources.GetObject("MenuNovo.Image")));
            this.MenuNovo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MenuNovo.Name = "MenuNovo";
            this.MenuNovo.Size = new System.Drawing.Size(226, 38);
            this.MenuNovo.Text = "Novo";
            // 
            // MenuEditar
            // 
            this.MenuEditar.Image = ((System.Drawing.Image)(resources.GetObject("MenuEditar.Image")));
            this.MenuEditar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MenuEditar.Name = "MenuEditar";
            this.MenuEditar.Size = new System.Drawing.Size(226, 38);
            this.MenuEditar.Text = "View Detalhes";
            // 
            // MenuApagar
            // 
            this.MenuApagar.Image = ((System.Drawing.Image)(resources.GetObject("MenuApagar.Image")));
            this.MenuApagar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MenuApagar.Name = "MenuApagar";
            this.MenuApagar.Size = new System.Drawing.Size(226, 38);
            this.MenuApagar.Text = "Apagar";
            // 
            // MenuRelatorios
            // 
            this.MenuRelatorios.Image = ((System.Drawing.Image)(resources.GetObject("MenuRelatorios.Image")));
            this.MenuRelatorios.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MenuRelatorios.Name = "MenuRelatorios";
            this.MenuRelatorios.Size = new System.Drawing.Size(226, 38);
            this.MenuRelatorios.Text = "Relatórios";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(223, 6);
            // 
            // comprovativoToolStripMenuItem
            // 
            this.comprovativoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("comprovativoToolStripMenuItem.Image")));
            this.comprovativoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.comprovativoToolStripMenuItem.Name = "comprovativoToolStripMenuItem";
            this.comprovativoToolStripMenuItem.Size = new System.Drawing.Size(226, 38);
            this.comprovativoToolStripMenuItem.Text = "Comprovativo";
            // 
            // pedidosModelsBindingSource
            // 
            this.pedidosModelsBindingSource.DataSource = typeof(IPAGEBiblioteca.Models.PedidosModels);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colDocNumero,
            this.colDataReserva,
            this.colDataEntrega,
            this.colPedidosEstado,
            this.colIsValid,
            this.colReservaDias,
            this.colTotalgeral,
            this.colAlunoModelsID,
            this.colAlunoModels,
            this.colPedidosOrdemModels,
            this.gridColumn1});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupCount = 1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colDataReserva, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colID
            // 
            this.colID.FieldName = "ID";
            this.colID.MinWidth = 25;
            this.colID.Name = "colID";
            this.colID.Visible = true;
            this.colID.VisibleIndex = 0;
            this.colID.Width = 93;
            // 
            // colDocNumero
            // 
            this.colDocNumero.FieldName = "DocNumero";
            this.colDocNumero.MinWidth = 25;
            this.colDocNumero.Name = "colDocNumero";
            this.colDocNumero.Visible = true;
            this.colDocNumero.VisibleIndex = 1;
            this.colDocNumero.Width = 119;
            // 
            // colDataReserva
            // 
            this.colDataReserva.FieldName = "DataReserva";
            this.colDataReserva.MinWidth = 25;
            this.colDataReserva.Name = "colDataReserva";
            this.colDataReserva.Visible = true;
            this.colDataReserva.VisibleIndex = 3;
            this.colDataReserva.Width = 94;
            // 
            // colDataEntrega
            // 
            this.colDataEntrega.FieldName = "DataEntrega";
            this.colDataEntrega.MinWidth = 25;
            this.colDataEntrega.Name = "colDataEntrega";
            this.colDataEntrega.Visible = true;
            this.colDataEntrega.VisibleIndex = 4;
            this.colDataEntrega.Width = 89;
            // 
            // colPedidosEstado
            // 
            this.colPedidosEstado.FieldName = "PedidosEstado";
            this.colPedidosEstado.MinWidth = 25;
            this.colPedidosEstado.Name = "colPedidosEstado";
            this.colPedidosEstado.Visible = true;
            this.colPedidosEstado.VisibleIndex = 5;
            this.colPedidosEstado.Width = 89;
            // 
            // colIsValid
            // 
            this.colIsValid.FieldName = "IsValid";
            this.colIsValid.MinWidth = 25;
            this.colIsValid.Name = "colIsValid";
            this.colIsValid.Visible = true;
            this.colIsValid.VisibleIndex = 6;
            this.colIsValid.Width = 89;
            // 
            // colReservaDias
            // 
            this.colReservaDias.FieldName = "ReservaDias";
            this.colReservaDias.MinWidth = 25;
            this.colReservaDias.Name = "colReservaDias";
            this.colReservaDias.OptionsColumn.ReadOnly = true;
            this.colReservaDias.Visible = true;
            this.colReservaDias.VisibleIndex = 7;
            this.colReservaDias.Width = 89;
            // 
            // colTotalgeral
            // 
            this.colTotalgeral.FieldName = "Totalgeral";
            this.colTotalgeral.MinWidth = 25;
            this.colTotalgeral.Name = "colTotalgeral";
            this.colTotalgeral.Visible = true;
            this.colTotalgeral.VisibleIndex = 8;
            this.colTotalgeral.Width = 96;
            // 
            // colAlunoModelsID
            // 
            this.colAlunoModelsID.FieldName = "AlunoModelsID";
            this.colAlunoModelsID.MinWidth = 25;
            this.colAlunoModelsID.Name = "colAlunoModelsID";
            this.colAlunoModelsID.Width = 94;
            // 
            // colAlunoModels
            // 
            this.colAlunoModels.Caption = "Estudante";
            this.colAlunoModels.FieldName = "AlunoModels.Nome";
            this.colAlunoModels.MinWidth = 25;
            this.colAlunoModels.Name = "colAlunoModels";
            this.colAlunoModels.Visible = true;
            this.colAlunoModels.VisibleIndex = 3;
            this.colAlunoModels.Width = 89;
            // 
            // colPedidosOrdemModels
            // 
            this.colPedidosOrdemModels.FieldName = "PedidosOrdemModels";
            this.colPedidosOrdemModels.MinWidth = 25;
            this.colPedidosOrdemModels.Name = "colPedidosOrdemModels";
            this.colPedidosOrdemModels.Width = 94;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "BI";
            this.gridColumn1.FieldName = "AlunoModels.NumeroEstudante";
            this.gridColumn1.MinWidth = 25;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 2;
            this.gridColumn1.Width = 89;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem2});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(896, 559);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 31);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(876, 508);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.dateTimePicker2;
            this.layoutControlItem3.Location = new System.Drawing.Point(348, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(426, 31);
            this.layoutControlItem3.Text = "Dé";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(19, 16);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnRefres;
            this.layoutControlItem4.Location = new System.Drawing.Point(774, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(102, 31);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.dateTimePicker1;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(348, 31);
            this.layoutControlItem2.Text = "Até";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(19, 16);
            // 
            // frmPedidosRequisicoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "frmPedidosRequisicoes";
            this.Size = new System.Drawing.Size(896, 559);
            this.Tag = "Requisições";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pedidosModelsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem métodosToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem MenuEditar;
        private System.Windows.Forms.ToolStripMenuItem MenuApagar;
        private System.Windows.Forms.ToolStripMenuItem MenuRelatorios;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem MenuNovo;
        private System.Windows.Forms.BindingSource pedidosModelsBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colDocNumero;
        private DevExpress.XtraGrid.Columns.GridColumn colDataReserva;
        private DevExpress.XtraGrid.Columns.GridColumn colDataEntrega;
        private DevExpress.XtraGrid.Columns.GridColumn colPedidosEstado;
        private DevExpress.XtraGrid.Columns.GridColumn colIsValid;
        private DevExpress.XtraGrid.Columns.GridColumn colReservaDias;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalgeral;
        private DevExpress.XtraGrid.Columns.GridColumn colAlunoModelsID;
        private DevExpress.XtraGrid.Columns.GridColumn colAlunoModels;
        private DevExpress.XtraGrid.Columns.GridColumn colPedidosOrdemModels;
        private DevExpress.XtraEditors.SimpleButton btnRefres;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private System.Windows.Forms.ToolStripMenuItem comprovativoToolStripMenuItem;
    }
}
