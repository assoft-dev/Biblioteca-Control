namespace IPAGEBiblioteca.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Aluno")]
    public class AlunoModels: IEntity
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataRegisto { get; set; }

        [Display(Name = "Turma")]
        public virtual TurmaModels Turma { get; set; }

        [Display(Name = "Instituição")]
        public virtual InstituicaoModels Instituicao { get; set; }

        [Display(Name = "Genero")]
        public SexoModels Sexo { get; set; }

        public virtual ICollection<PedidosModels> PedidosModels { get; set; }


        #region Propriedades AutoExecutaveis
        public int Idate { get { return (DateTime.Now.Year - DataNascimento.Year); } }
        #endregion
    }
}
