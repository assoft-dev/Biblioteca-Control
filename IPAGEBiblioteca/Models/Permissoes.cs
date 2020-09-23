namespace IPAGEBiblioteca.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Permissoes")]
    public class PermissoesModels
    {
        [Key, Display(Name = "Código", GroupName = "Interna", Order = 0)]
        public int ID { get; set; }

        [Display(Name = "Descrição", GroupName = "Interna", Order = 1)]
        public string Referencia { get; set; }

        #region Usuarios
        [Display(Name = "Usuários", GroupName = "Usuários", Order = 1)]
        public bool Usuarios { get; set; }

        [Display(Name = "Consultas", GroupName = "Usuários", Order = 2)]
        public bool UsuariosConsultas { get; set; }

        [Display(Name = "Registo", GroupName = "Usuários", Order = 3)]
        public bool UsuariosRegistar { get; set; }

        [Display(Name = "Grupos", GroupName = "Usuários", Order = 4)]
        public bool UsuariosGrupos { get; set; }

        [Display(Name = "Permissões", GroupName = "Usuários", Order = 5)]
        public bool UsuariosPermissoes { get; set; }
        #endregion

        [Display(Name = "Biblioteca", GroupName = "Biblioteca", Order = 0)]
        public bool Bibliotecas { get;  set; }

        [Display(Name = "Livros", GroupName = "Usuários", Order = 1)]
        public bool LivrosConsultas { get;  set; }

        [Display(Name = "Autores", GroupName = "Usuários", Order = 2)]
        public bool AutoresConsultas { get;  set; }

        [Display(Name = "Editora", GroupName = "Usuários", Order = 3)]
        public bool EditoraConsultas { get;  set; }

        [Display(Name = "Pais", GroupName = "Usuários", Order = 4)]
        public bool PaisConsultas { get; set; }


        [Display(Name = "Estudantes", GroupName = "Estudantes", Order = 0)]
        public bool Estudantes { get; set; }

        [Display(Name = "Alunos/Consultas", GroupName = "Estudantes", Order = 1)]
        public bool AlunoConsultas { get; set; }

        [Display(Name = "Instituição/Consultas", GroupName = "Estudantes", Order = 2)]
        public bool InstituicaoConsultas { get; set; }

        [Display(Name = "Classe/Consultas", GroupName = "Estudantes", Order = 3)]
        public bool ClasseConsultas { get; set; }

        [Display(Name = "Turma/Consultas", GroupName = "Estudantes", Order = 4)]
        public bool TurmaConsultas { get; set; }


        //Requisicoes
        [Display(Name = "Stocks", GroupName = "Requisições", Order = 0)]
        public bool Stocks { get; set; }

        [Display(Name = "Stocks/Registar", GroupName = "Requisições", Order = 1)]
        public bool StocksRegistar { get; set; }

        [Display(Name = "Leituras", GroupName = "Requisições", Order = 2)]
        public bool Leituras { get; set; }

        [Display(Name = "Leituras/Solicitações", GroupName = "Requisições", Order = 3)]
        public bool LeiturasSolicitacoes { get; set; }


        [Display(Name = "Grupos")]
        public virtual ICollection<GruposModels> GruposModels { get; set; }
    }
}
