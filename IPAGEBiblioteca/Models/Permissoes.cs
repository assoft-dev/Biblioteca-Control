namespace IPAGEBiblioteca.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Permissoes")]
    public class PermissoesModels: IEntity
    {
        public int ID { get; set; }

        #region Usuarios
        public bool UsuariosConsultas { get; set; }
        public bool UsuariosRegistar { get; set; }
        #endregion

        [Display(Name = "Grupos")]
        public virtual ICollection<GruposModels> GruposModels { get; set; }
    }
}
