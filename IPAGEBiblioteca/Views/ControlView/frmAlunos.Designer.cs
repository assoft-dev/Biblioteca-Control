namespace IPAGEBiblioteca.Views.ControlView
{
    partial class frmAlunos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAlunos));
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
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.alunoModelsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNome = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNumeroEstudante = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDataNascimento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDataRegisto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsValido = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTurmaID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInstituicaoID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSexo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIdate = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alunoModelsBindingSource)).BeginInit();
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
            this.gridControl1.DataSource = this.alunoModelsBindingSource;
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
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colNome,
            this.colNumeroEstudante,
            this.colDataNascimento,
            this.colDataRegisto,
            this.colIsValido,
            this.colTurmaID,
            this.colInstituicaoID,
            this.colSexo,
            this.colIdate});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowFooter = true;
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
            // alunoModelsBindingSource
            // 
            this.alunoModelsBindingSource.DataSource = typeof(IPAGEBiblioteca.Models.AlunoModels);
            // 
            // colID
            // 
            this.colID.FieldName = "ID";
            this.colID.MinWidth = 25;
            this.colID.Name = "colID";
            this.colID.Visible = true;
            this.colID.VisibleIndex = 0;
            this.colID.Width = 94;
            // 
            // colNome
            // 
            this.colNome.FieldName = "Nome";
            this.colNome.MinWidth = 25;
            this.colNome.Name = "colNome";
            this.colNome.Visible = true;
            this.colNome.VisibleIndex = 1;
            this.colNome.Width = 94;
            // 
            // colNumeroEstudante
            // 
            this.colNumeroEstudante.FieldName = "NumeroEstudante";
            this.colNumeroEstudante.MinWidth = 25;
            this.colNumeroEstudante.Name = "colNumeroEstudante";
            this.colNumeroEstudante.Visible = true;
            this.colNumeroEstudante.VisibleIndex = 2;
            this.colNumeroEstudante.Width = 94;
            // 
            // colDataNascimento
            // 
            this.colDataNascimento.FieldName = "DataNascimento";
            this.colDataNascimento.MinWidth = 25;
            this.colDataNascimento.Name = "colDataNascimento";
            this.colDataNascimento.Visible = true;
            this.colDataNascimento.VisibleIndex = 3;
            this.colDataNascimento.Width = 94;
            // 
            // colDataRegisto
            // 
            this.colDataRegisto.FieldName = "DataRegisto";
            this.colDataRegisto.MinWidth = 25;
            this.colDataRegisto.Name = "colDataRegisto";
            this.colDataRegisto.Visible = true;
            this.colDataRegisto.VisibleIndex = 4;
            this.colDataRegisto.Width = 94;
            // 
            // colIsValido
            // 
            this.colIsValido.FieldName = "IsValido";
            this.colIsValido.MinWidth = 25;
            this.colIsValido.Name = "colIsValido";
            this.colIsValido.Visible = true;
            this.colIsValido.VisibleIndex = 5;
            this.colIsValido.Width = 94;
            // 
            // colTurmaID
            // 
            this.colTurmaID.Caption = "Descrição";
            this.colTurmaID.FieldName = "Turma.Descricao";
            this.colTurmaID.MinWidth = 25;
            this.colTurmaID.Name = "colTurmaID";
            this.colTurmaID.Visible = true;
            this.colTurmaID.VisibleIndex = 6;
            this.colTurmaID.Width = 94;
            // 
            // colInstituicaoID
            // 
            this.colInstituicaoID.Caption = "Descrição";
            this.colInstituicaoID.FieldName = "Instituicao.Referencia";
            this.colInstituicaoID.MinWidth = 25;
            this.colInstituicaoID.Name = "colInstituicaoID";
            this.colInstituicaoID.Visible = true;
            this.colInstituicaoID.VisibleIndex = 7;
            this.colInstituicaoID.Width = 94;
            // 
            // colSexo
            // 
            this.colSexo.FieldName = "Sexo";
            this.colSexo.MinWidth = 25;
            this.colSexo.Name = "colSexo";
            this.colSexo.Visible = true;
            this.colSexo.VisibleIndex = 8;
            this.colSexo.Width = 94;
            // 
            // colIdate
            // 
            this.colIdate.FieldName = "Idate";
            this.colIdate.MinWidth = 25;
            this.colIdate.Name = "colIdate";
            this.colIdate.OptionsColumn.ReadOnly = true;
            this.colIdate.Visible = true;
            this.colIdate.VisibleIndex = 9;
            this.colIdate.Width = 94;
            // 
            // frmAlunos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "frmAlunos";
            this.Size = new System.Drawing.Size(789, 510);
            this.Tag = "Estudantes";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alunoModelsBindingSource)).EndInit();
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
        private System.Windows.Forms.BindingSource alunoModelsBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colNome;
        private DevExpress.XtraGrid.Columns.GridColumn colNumeroEstudante;
        private DevExpress.XtraGrid.Columns.GridColumn colDataNascimento;
        private DevExpress.XtraGrid.Columns.GridColumn colDataRegisto;
        private DevExpress.XtraGrid.Columns.GridColumn colIsValido;
        private DevExpress.XtraGrid.Columns.GridColumn colTurmaID;
        private DevExpress.XtraGrid.Columns.GridColumn colInstituicaoID;
        private DevExpress.XtraGrid.Columns.GridColumn colSexo;
        private DevExpress.XtraGrid.Columns.GridColumn colIdate;
    }
}
