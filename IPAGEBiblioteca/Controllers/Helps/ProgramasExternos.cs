using System;
using System.Diagnostics;
using System.IO;

namespace IPAGEBiblioteca.Controllers.Helps
{
    public class ProgramasExternos
    {
        public bool Executar()
        {
            var caminho = ArquivosGestao.GetLocal();
            var caminhopossivel = string.Empty;
            var caminhobase = $@"{caminho}\AssistenciaTecnica\AnyDesk.exe";
            var caminhobaseExistente86 = @"C:\Program Files (x86)\AnyDesk\AnyDesk.exe";
            var caminhobaseExistente64 = @"C:\Program Files\AnyDesk\AnyDesk.exe";

            if (File.Exists(caminhobaseExistente86))
                caminhopossivel = caminhobaseExistente86;
            else if (File.Exists(caminhobaseExistente64))
                caminhopossivel = caminhobaseExistente64;
            else if (File.Exists(caminhobase))
                caminhopossivel = caminhobase;
            else
                return false;

            ProcessStartInfo info = new ProcessStartInfo(caminhopossivel, "");
            try
            {
                Process.Start(info);
                return true;
            }
            catch (Exception exe)
            {
                EscreverLogs.Escrever(exe);
                return false;
            }
        }
    }
}
