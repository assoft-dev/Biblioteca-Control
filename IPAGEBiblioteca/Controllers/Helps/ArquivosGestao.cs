using System;
using System.IO;
using System.Linq;
using System.Text;

namespace IPAGEBiblioteca.Controllers.Helps
{
    public class ArquivosGestao
    {
        public static string ProgramLicence { get { return "ISoft 2019"; } }
        public static FileInfo[] Lerarquivos(string folder, bool FullPatch = false)
        {
            return FullPatch == false ? (new DirectoryInfo(GetLocalDataSoftware(folder))).GetFiles() :
                                        (new DirectoryInfo(folder)).GetFiles();
        }
        public static FileInfo[] Lerarquivos(string folder, string extensoes, bool FullPath = false)
        {
          return FullPath == false ? (new DirectoryInfo(GetLocalDataSoftware(folder))).GetFiles(string.Format("{0}", extensoes)) :
                                     (new DirectoryInfo(folder)).GetFiles(string.Format("{0}", extensoes));
        }

        public static FileInfo[] GetLocalFileError()
        {
            var caminho = GetLocalDataSoftware("Logs");
            return (new DirectoryInfo(caminho)).GetFiles();
        }
        public static string GetLocalDataSoftware()
        {
            var Directo = @"C:\iSoft 2018\";
            if (!Directory.Exists(Directo))
                Directory.CreateDirectory(Directo);
            return Directo;
        }
        public static string GetLocalDataSoftware(string caminho)
        {
            var Directo = string.Format(@"C:\iSoft 2018\{0}", caminho);
            if (!Directory.Exists(Directo))
                Directory.CreateDirectory(Directo);
            return Directo;
        }
        public static string GetLocal()
        {
            return Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory.ToString());
        }
        public static string GetLocalDataUsert(string pasta)
        {
            var Directo = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            Directo = Path.Combine(Directo, pasta);
            return Directo;
        }
        public static string GetLocalDataUsert(string pasta, string pasta1)
        {
            var Directo = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            Directo = Path.Combine(Directo, pasta, pasta1);
            if (!Directory.Exists(Directo))
                Directory.CreateDirectory(Directo);
            return Directo;
        }
        public static string CreateLocalDataUsert(string pasta, string pasta1)
        {
            var Directo = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            Directo = Path.Combine(Directo, pasta, pasta1);

            if (Directory.Exists(Directo))
                Directory.CreateDirectory(Directo);
            //Directory.(Directo)
            return Directo;
        }

        #region Config initial

        // Read
        #region Read File Txt
        public static string GetInitalConfig()
        {
            var fileConfig = @"Config\Initial_Config.ini";
            var Caminho = Lerarquivos(fileConfig);
            var arquivo = Caminho.Where(x => x.Name.Contains("Initial_Config")).FirstOrDefault();

            var result = arquivo.Open(FileMode.Open, FileAccess.ReadWrite);
            using (StreamReader stream = new StreamReader(result))
            {
                var text = stream.ReadToEnd().Split(';');
            }
            return string.Empty;
        }
        public static string CreateInitalConfig(string texto)
        {
            var fileConfig = @"Config\Initial_Config.ini";
            var Caminho = Lerarquivos(fileConfig);
            var arquivo = Caminho.Where(x => x.Name.Contains("Initial_Config")).FirstOrDefault();

            var result = arquivo.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite);
            using (StreamReader stream = new StreamReader(result))
            {
                var text = (stream.ReadToEnd().Split(';')).Where(x => x.Contains(texto));
            }
            return string.Empty;
        }
        #endregion
        // Create

        // Conection: SqlServer;
        // ImpressoraA4Modelo: Termica;
        // ImpressoraA4System  Termica;
        // Impressora80Modelo: Termica;
        // Impressora80System: Termica;
        // ConectionIsServer: Termica;
        #endregion
        public static string GetStringConfig(string Key, string texto)
        {
            var text = new StringBuilder();
            text.AppendLine($"{Key}:{texto};");
            return text.ToString();
        }
        public static string GetStringConfig()
        {
            var text = new StringBuilder();
            text.AppendLine("Conection: SqlServer;");
            text.AppendLine("ImpressoraA4Modelo: Termica;");
            text.AppendLine("ImpressoraA4System  Termica;");
            text.AppendLine("Impressora80Modelo: Termica;");
            text.AppendLine("Impressora80System: Termica;");
            return text.ToString();
        }
    }
}
