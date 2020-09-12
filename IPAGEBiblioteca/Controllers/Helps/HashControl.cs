namespace IPAGEBiblioteca.Controllers.Helps
{
    using System.Security.Cryptography;
    using System.Text;

    public static class HashControl
    {
        public static string GetMD5Hash(string imput)
        {
            using (MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider())
            {
                byte[] b = System.Text.Encoding.UTF8.GetBytes(imput);
                b = provider.ComputeHash(b);
                System.Text.StringBuilder sb = new StringBuilder();
                foreach (var item in b)
                    sb.Append(item.ToString("x2"));
                return sb.ToString();
            }
        }
    }
}
