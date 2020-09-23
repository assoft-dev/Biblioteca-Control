namespace IPAGEBiblioteca.Controllers.Helps
{
    using System;
    using System.IO;
    using System.Windows.Forms;

    public class SaveLayoutXML
    {
        readonly static string caminho = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                                                 "ASSOFTBiblioteca Designer");
        public static string Loader(string formsParent)
        {   
            if (!Directory.Exists(caminho))
                Directory.CreateDirectory(caminho);

            string Filename = string.Format("{0}/{1}.xml", caminho, formsParent);

            if (File.Exists(Filename))
                return Filename;
            else
                return string.Empty;
        }
        public static string Restore(string formsParent)
        {
            if (!Directory.Exists(caminho))
                Directory.CreateDirectory(caminho);
            return string.Format("{0}/{1}.xml", caminho, formsParent);
        }
    }
}
