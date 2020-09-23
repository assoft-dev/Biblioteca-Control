namespace IPAGEBiblioteca.Models.Helps
{
    using System.Collections.Generic;

    public class EmailMessage
    {
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsHtml { get; set; }
        public List<string> filenames { get; set; }
    }
}
