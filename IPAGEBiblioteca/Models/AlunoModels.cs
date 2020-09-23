namespace IPAGEBiblioteca.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Aluno")]
    public class AlunoModels
    {
        [Key, Display(Name = "Código")]
        public int ID { get; set; }

        [Display(Name = "Estudantes")]
        public string Nome { get; set; }

        [Display(Name = "Número")]
        public string NumeroEstudante { get; set; }

        [Display(Name = "Data/Nascimento"), DataType(DataType.DateTime)]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "Data Registo"), DataType(DataType.DateTime)]
        public DateTime DataRegisto { get; set; }

        [Display(Name = "Válido")]
        public bool IsValido { get; set; }

        [Display(Name = "E-Mail"), DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Turma"), ForeignKey("Turma")]
        public int TurmaID { get; set; }
        public virtual TurmaModels Turma { get; set; }

        [Display(Name = "Instituição"), ForeignKey("Instituicao")]
        public int InstituicaoID { get; set; }
        public virtual InstituicaoModels Instituicao { get; set; }

        [Display(Name = "Genero")]
        public SexoModels Sexo { get; set; }

        public virtual ICollection<PedidosModels> PedidosModels { get; set; }

        #region Propriedades AutoExecutaveis
        [Display(Name = "Idade")]
        public int Idate { get { return (DateTime.Now.Year - DataNascimento.Year); } }


        #endregion
    }
}
