using System;

namespace IPAGEBiblioteca.Models.Helps
{
    public  class LicenceModelsHelps
    {
        public string FullName { get; set; }
        public string KeyID { get; set; }
        public string Key { get; set; }
        public string typelicence { get; set; }
        public DateTime DataExpiration { get; set; }
        public string Dias { get; set; }
        public int Year { get; set; }
        public int DiasSimples { get; set; }
        public Edition licencaNaturesa { get; set; }
    }
    public enum Edition
    {
        ENTERPRISE, PROFESSIONAL, STANDARD, ULTIMATE
    }

}
