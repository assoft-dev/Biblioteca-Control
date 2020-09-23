namespace IPAGEBiblioteca.Controllers.Helps
{
    using System;
    using System.IO;
    using System.Text;
    using System.Windows.Forms;

    public class EscreverLogs
    {
        public static void Escrever(Control control, Exception exception, string text = "")
        {
            try
            {
                string logFilePath = GetLocalDataSoftware("Logs") + @"\Logs-" + DateTime.Today.ToString("MM-dd-yyyy") + "." + "txt";
                FileInfo logFileInfo = new FileInfo(logFilePath);
                DirectoryInfo logDirInfo = new DirectoryInfo(logFileInfo.DirectoryName);
                if (!logDirInfo.Exists) logDirInfo.Create();
                using (FileStream fileStream = new FileStream(logFilePath, FileMode.Append))
                {
                    using (StreamWriter log = new StreamWriter(fileStream))
                    {
                        log.WriteLine(AppendLog(exception));
                    }
                }
            }
            catch (Exception exe)
            {
                MessageBox.Show("Erro" + exe.Message);
            }
        }
        public static void Escrever(Exception exception, string text = "")
        {
            try
            {
                string logFilePath = GetLocalDataSoftware("Logs") + @"\Logs-" + DateTime.Today.ToString("MM-dd-yyyy") + "." + "txt";

                FileInfo logFileInfo = new FileInfo(logFilePath);
                DirectoryInfo logDirInfo = new DirectoryInfo(logFileInfo.DirectoryName);
                if (!logDirInfo.Exists) logDirInfo.Create();
                using (FileStream fileStream = new FileStream(logFilePath, FileMode.Append))
                {
                    using (StreamWriter log = new StreamWriter(fileStream))
                    {
                        log.WriteLine(AppendLog(exception));
                    }
                }
            }
            catch (Exception exe)
            {
                MessageBox.Show("Erro" + exe.Message);
            }
            finally
            {
                MessageBox.Show(exception.Message);
            }
        }
        private static StringBuilder AppendLog(Exception exception)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("\r\nLog Entry : ");
            stringBuilder.AppendLine(string.Format("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString()));
            stringBuilder.AppendLine("  :");
            stringBuilder.AppendLine(string.Format("  :{0}", exception.Message));
            stringBuilder.AppendLine("Detalhes Técnicos: ");
            stringBuilder.AppendLine(string.Format("  :{0}", exception.StackTrace));
            stringBuilder.AppendLine("-------------------------------");
            return stringBuilder;
        }
        private static string GetLocalDataSoftware(string caminho)
        {
            var Directo = string.Format(@"C:\iSoft 2018\{0}", caminho);
            if (!Directory.Exists(Directo))
                Directory.CreateDirectory(Directo);
            return Directo;
        }
    }
}
