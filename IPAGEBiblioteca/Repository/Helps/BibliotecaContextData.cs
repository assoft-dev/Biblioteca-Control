using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace IPAGEBiblioteca.Repository.Helps
{
    public class BibliotecaContextData
    {
        private readonly BiblioteContext biblioteContext;
        public BibliotecaContextData(BiblioteContext biblioteContext)
        {
            this.biblioteContext = biblioteContext;          
        }
        public async Task<bool> Seed()
        {
            await this.biblioteContext.Database.EnsureCreatedAsync();
            await this.biblioteContext.Database.MigrateAsync();
            return true;
        }
        public async Task<bool> InsertFirstValues()
        {
            throw new NotImplementedException();
        }
    }
}
