namespace IPAGEBiblioteca.Views.ControlView
{
    partial class frmStocks
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStocks));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.métodosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuNovo = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuEditar = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuApagar = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuRelatorios = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.stocksModelsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQtd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuantidadeMinima = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuantidadeMaxima = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrecoUnitario = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsvalid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colComentarios = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colData = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLivrosModels = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stocksModelsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(789, 510);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gridControl1
            // 
            this.gridControl1.ContextMenuStrip = this.contextMenuStrip1;
            this.gridControl1.DataSource = this.stocksModelsBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(12, 12);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(765, 486);
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
            this.toolStripSeparator2});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(162, 206);
            // 
            // métodosToolStripMenuItem
            // 
            this.métodosToolStripMenuItem.Enabled = false;
            this.métodosToolStripMenuItem.Name = "métodosToolStripMenuItem";
            this.métodosToolStripMenuItem.Size = new System.Drawing.Size(161, 38);
            this.métodosToolStripMenuItem.Text = "Métodos";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(158, 6);
            // 
            // MenuNovo
            // 
            this.MenuNovo.Image = ((System.Drawing.Image)(resources.GetObject("MenuNovo.Image")));
            this.MenuNovo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MenuNovo.Name = "MenuNovo";
            this.MenuNovo.Size = new System.Drawing.Size(161, 38);
            this.MenuNovo.Text = "Novo";
            // 
            // MenuEditar
            // 
            this.MenuEditar.Image = ((System.Drawing.Image)(resources.GetObject("MenuEditar.Image")));
            this.MenuEditar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MenuEditar.Name = "MenuEditar";
            this.MenuEditar.Size = new System.Drawing.Size(161, 38);
            this.MenuEditar.Text = "Editar";
            // 
            // MenuApagar
            // 
            this.MenuApagar.Image = ((System.Drawing.Image)(resources.GetObject("MenuApagar.Image")));
            this.MenuApagar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MenuApagar.Name = "MenuApagar";
            this.MenuApagar.Size = new System.Drawing.Size(161, 38);
            this.MenuApagar.Text = "Apagar";
            // 
            // MenuRelatorios
            // 
            this.MenuRelatorios.Image = ((System.Drawing.Image)(resources.GetObject("MenuRelatorios.Image")));
            this.MenuRelatorios.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MenuRelatorios.Name = "MenuRelatorios";
            this.MenuRelatorios.Size = new System.Drawing.Size(161, 38);
            this.MenuRelatorios.Text = "Relatórios";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(158, 6);
            // 
            // stocksModelsBindingSource
            // 
            this.stocksModelsBindingSource.DataSource = typeof(IPAGEBiblioteca.Models.StocksModels);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colQtd,
            this.colQuantidadeMinima,
            this.colQuantidadeMaxima,
            this.colPrecoUnitario,
            this.colTotal,
            this.colIsvalid,
            this.colComentarios,
            this.colData,
            this.colLivrosModels});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowFooter = true;
            // 
            // colID
            // 
            this.colID.FieldName = "ID";
            this.colID.MinWidth = 25;
            this.colID.Name = "colID";
            this.colID.Visible = true;
            this.colID.VisibleIndex = 0;
            this.colID.Width = 53;
            // 
            // colQtd
            // 
            this.colQtd.FieldName = "Qtd";
            this.colQtd.MinWidth = 25;
            this.colQtd.Name = "colQtd";
            this.colQtd.Visible = true;
            this.colQtd.VisibleIndex = 3;
            this.colQtd.Width = 71;
            // 
            // colQuantidadeMinima
            // 
            this.colQuantidadeMinima.FieldName = "QuantidadeMinima";
            this.colQuantidadeMinima.MinWidth = 25;
            this.colQuantidadeMinima.Name = "colQuantidadeMinima";
            this.colQuantidadeMinima.Visible = true;
            this.colQuantidadeMinima.VisibleIndex = 4;
            this.colQuantidadeMinima.Width = 71;
            // 
            // colQuantidadeMaxima
            // 
            this.colQuantidadeMaxima.FieldName = "QuantidadeMaxima";
            this.colQuantidadeMaxima.MinWidth = 25;
            this.colQuantidadeMaxima.Name = "colQuantidadeMaxima";
            this.colQuantidadeMaxima.Visible = true;
            this.colQuantidadeMaxima.VisibleIndex = 5;
            this.colQuantidadeMaxima.Width = 71;
            // 
            // colPrecoUnitario
            // 
            this.colPrecoUnitario.FieldName = "PrecoUnitario";
            this.colPrecoUnitario.MinWidth = 25;
            this.colPrecoUnitario.Name = "colPrecoUnitario";
            this.colPrecoUnitario.Visible = true;
            this.colPrecoUnitario.VisibleIndex = 6;
            this.colPrecoUnitario.Width = 71;
            // 
            // colTotal
            // 
            this.colTotal.FieldName = "Total";
            this.colTotal.MinWidth = 25;
            this.colTotal.Name = "colTotal";
            this.colTotal.Visible = true;
            this.colTotal.VisibleIndex = 7;
            this.colTotal.Width = 71;
            // 
            // colIsvalid
            // 
            this.colIsvalid.FieldName = "Isvalid";
            this.colIsvalid.MinWidth = 25;
            this.colIsvalid.Name = "colIsvalid";
            this.colIsvalid.Visible = true;
            this.colIsvalid.VisibleIndex = 8;
            this.colIsvalid.Width = 98;
            // 
            // colComentarios
            // 
            this.colComentarios.FieldName = "Comentarios";
            this.colComentarios.MinWidth = 25;
            this.colComentarios.Name = "colComentarios";
            this.colComentarios.Visible = true;
            this.colComentarios.VisibleIndex = 2;
            this.colComentarios.Width = 58;
            // 
            // colData
            // 
            this.colData.FieldName = "Data";
            this.colData.MinWidth = 25;
            this.colData.Name = "colData";
            this.colData.Visible = true;
            this.colData.VisibleIndex = 9;
            this.colData.Width = 72;
            // 
            // colLivrosModels
            // 
            this.colLivrosModels.FieldName = "LivrosModels.Referencia";
            this.colLivrosModels.MinWidth = 25;
            this.colLivrosModels.Name = "colLivrosModels";
            this.colLivrosModels.Visible = true;
            this.colLivrosModels.VisibleIndex = 1;
            this.colLivrosModels.Width = 99;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(789, 510);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(769, 490);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // frmStocks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "frmStocks";
            this.Size = new System.Drawing.Size(789, 510);
            this.Tag = "Livros:";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.stocksModelsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
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
        private System.Windows.Forms.BindingSource stocksModelsBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colQtd;
        private DevExpress.XtraGrid.Columns.GridColumn colQuantidadeMinima;
        private DevExpress.XtraGrid.Columns.GridColumn colQuantidadeMaxima;
        private DevExpress.XtraGrid.Columns.GridColumn colPrecoUnitario;
        private DevExpress.XtraGrid.Columns.GridColumn colTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colIsvalid;
        private DevExpress.XtraGrid.Columns.GridColumn colComentarios;
        private DevExpress.XtraGrid.Columns.GridColumn colData;
        private DevExpress.XtraGrid.Columns.GridColumn colLivrosModels;
    }
}
