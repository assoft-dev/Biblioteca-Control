using System.ComponentModel;

namespace IPAGEBiblioteca
{
    public enum UserState
    {
        [Description("Usuário Válido")]
        IsValid = 1,

        [Description("Usuário InVálido")]
        Invalid = 2,

        [Description("Usuário Desativado")]
        Standbay = 3,
    }
}