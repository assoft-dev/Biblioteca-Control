using IPAGEBiblioteca.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace IPAGEBiblioteca.Repository.Helps
{
    public class BiblioteContext: DbContext
    {
        private const string Conections = "Server=.; DataBase=Biblioteca; User ID = sa; Password=junior";
        public BiblioteContext()
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
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
        public DbSet<StocksModels> StocksModels { get; set; }
        public DbSet<PermissoesModels> PermissoesModels { get; set; }
        public DbSet<GruposModels> GruposModels { get; set; }
        public DbSet<KeysGensModels> KeysGens { get; set; }
        public DbSet<DefinicoesModels> DefinicoesModels { get; set; }    
        public DbSet<SmtpConfigurationsModels> SmtpConfigurationsModels { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //if (MenuServerStatic.GetCOnectionString().Equals("ConexaoVendasPostgreSQL"))
            //    modelBuilder.HasDefaultSchema("dbo");

            // Restringuir Apagar Dados externos
            var cascadeFKs = builder.Model
                  .G­etEntityTypes()
                  .SelectMany(t => t.GetForeignKeys())
                  .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Casca­de);
            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restr­ict;

            //     builder.Entity<Fatura>()
            //  .Property<int>(x => x.FaturasID)
            //  .ValueGeneratedOnAdd();
            //     builder.Entity<Fatura>()
            //                  .HasAlternateKey(x => x.FaturasID);

            builder.Entity<UserModels>()
                   .HasMany(e => e.Logs)
                   .WithOne(e => e.userModels)
                   .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(builder);
        }
    }
}
