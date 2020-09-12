using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IPAGEBiblioteca.Models
{
    [Table("Grupos")]
    public class GruposModels: IEntity
    {
        public int ID { get; set; }
        public string Referencias { get; set; }

        [Display(Name = "Permissões")]
        public virtual PermissoesModels PermissoesModels { get; set; }

        [Display(Name = "Usuarios")]
        public virtual ICollection<UserModels> UserModels { get; set; }
    }
}