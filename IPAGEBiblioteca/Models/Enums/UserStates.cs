using IPAGEBiblioteca.Models;
using System.ComponentModel;

namespace IPAGEBiblioteca
{
    public class UserStateRequered
    {
        public UserState UserState { get; set; }
        public UserModels Models { get; set; }
    }
    public enum UserState
    {
        [Description("Usuário Válido")]
        IsValid = 1,

        [Description("Usuário InVálido")]
        Invalid = 2,

        [Description("Usuário Desativado")]
        Standbay = 3,

        [Description("Usuário sem grupo Associado")]
        Invalid_Grpos = 4,

        [Description("Usuário sem Permissão Associado")]
        Invalid_Permissoes = 5,

        [Description("Usuário sem Permissão Associado")]
        Invalid_First_Values = 6
    }
}