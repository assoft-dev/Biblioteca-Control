namespace IPAGEBiblioteca.Controllers.Helps
{
    using DevExpress.XtraEditors;
    using FoxLearn.License;
    using IPAGEBiblioteca.Models.Helps;
    using IPAGEBiblioteca.Repository;
    using IPAGEBiblioteca.Views.HelpsLicence;
    using System;
    using System.IO;
    using System.Windows.Forms;

    public class ILicence
    {
        public LicenceModelsHelps GetLicence()
        {
            var U = ComputerInfo.GetComputerId();
            KeyManager km = new KeyManager(U);
            LicenseInfo Lic = new LicenseInfo();
            Models.Helps.LicenceModelsHelps modelsHelps = null;
            try
            {
                var getLicence = GetLocalDataUsert("ISoft 2019", "Licence");
                int value = km.LoadSuretyFile(string.Format(@"{0}\Key.Lic", getLicence), ref Lic);
                string produtoKey = Lic.ProductKey;
                if (km.ValidKey(ref produtoKey))
                {
                    KeyValuesClass kv = new KeyValuesClass();
                    if (km.DisassembleKey(produtoKey, ref kv))
                    {
                        modelsHelps = new LicenceModelsHelps
                        {
                            FullName = Lic.FullName,
                            DataExpiration = kv.Expiration,
                            Dias = kv.Type == LicenseType.TRIAL ? $"{(kv.Expiration - DateTime.Now.Date).Days} Dias" : "FULL",
                            DiasSimples = (kv.Expiration - DateTime.Now.Date).Days,
                            Key = produtoKey,
                            KeyID = U,
                            typelicence = kv.Type.ToString(),
                            Year = Lic.Year,
                            licencaNaturesa = (Models.Helps.Edition) kv.Edition,
                        };
                        return modelsHelps;
                    }
                    return null;
                }
                else
                    return null;
            }
            catch (System.Exception exe)
            {
                XtraMessageBox.Show("Erro na Leitura da licença\n"
                                     + exe.Message, "Tente mais outra vez",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Error);
            }
            return modelsHelps;
        }

        public bool LeituraLicençe()
        {
            try
            {
                var licenceModelsHelps = GetLicence();
                if (licenceModelsHelps != null)
                {
                    Program.LicenceModelsHelps = licenceModelsHelps;

                    // Verificar se os Dias trias termináram
                    if (licenceModelsHelps.Dias.Equals("FULL"))
                        return true;
                    else if (Convert.ToInt32(licenceModelsHelps.DiasSimples) >= 0)
                    {
                        // Testar se Ainda esta Dentro do Praso de Validade
                        if (Convert.ToInt32(licenceModelsHelps.DiasSimples) <= 15)
                        {
                            using (DevExpress.XtraBars.Alerter.AlertControl f = new DevExpress.XtraBars.Alerter.AlertControl())
                            {
                                f.Show( new Form(),
                                       "Atenção esta quase na Hora de Pagares a sua Subiscrição de Licença",
                                       "Atenção solicite uma licença já já no Admim do Sistema:");
                                f.AlertClick += delegate
                                {
                                    var t = new frmRegistar(new KeyGenRepository(new Repository.Helps.BiblioteContext()));
                                    t.TopMost = true;
                                    t.Show();
                                };
                            }
                        }
                        return true;
                    }
                    else
                        XtraMessageBox.Show(string.Format("Lamentamos!..... (-_-) \nmais o seu Software tem a licença expirada á {0} Dias\nConsidere Contactar o Adminstrador de Sistema para lhe conseder uma nova licença!...",
                        licenceModelsHelps.Dias.Replace("-", "")));
                    return false;
                }
            }
            catch (System.Exception exe)
            {
                XtraMessageBox.Show("ERRROOOO!... Por Favor tente Acertar o seu relogio por favor\n"
                                     + exe.Message, "Faltando Acertos de Datas",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Error);
            }
            return false;
        }

        public static string GetLocalDataUsert(string pasta, string pasta1)
        {
            var Directo = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            Directo = Path.Combine(Directo, pasta, pasta1);
            if (!Directory.Exists(Directo))
                Directory.CreateDirectory(Directo);
            return Directo;
        }
    }
}
