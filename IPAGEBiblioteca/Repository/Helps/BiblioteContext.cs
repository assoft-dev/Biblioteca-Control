using IPAGEBiblioteca.Models;
using Microsoft.EntityFrameworkCore;

namespace IPAGEBiblioteca.Repository.Helps
{
    public class BiblioteContext: DbContext
    {
        private const string Conections = "Server=.; DataBase=Biblioteca; User ID = sa; Password=junior";
        public BiblioteContext()
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlServer(Conections, x => { x.EnableRetryOnFailure(); });
        }
        public DbSet<AlunoModels> AlunoModels { get; set; }
        public DbSet<AutorModels> AutorModels { get; set; }
        public DbSet<ClasseModels> ClasseModels { get; set; }
        public DbSet<EditoraModels> EditoraModels { get; set; }
        public DbSet<InstituicaoModels> InstituicaoModels { get; set; }
        public DbSet<LivrosModels> LivrosModels { get; set; }
        public DbSet<PaisModels> PaisModels { get; set; }
        public DbSet<PedidosModels> PedidosModels { get; set; }
        public DbSet<PedidosOrdemModels> PedidosOrdemModels { get; set; }
        public DbSet<TurmaModels> TurmaModels { get; set; }
        public DbSet<UserModels> UserModels { get; set; }
        public DbSet<LogsModels> LogsModels { get; set; }


        public DbSet<PermissoesModels> PermissoesModels { get; set; }
        public DbSet<GruposModels> GruposModels { get; set; }
    }
}
