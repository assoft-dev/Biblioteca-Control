namespace IPAGEBiblioteca.Repository.Helps
{
    using IPAGEBiblioteca.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class BibliotecaContextData
    {
        private readonly BiblioteContext biblioteContext;
        public BibliotecaContextData(BiblioteContext biblioteContext)
        {
            this.biblioteContext = biblioteContext;          
        }
        public async Task<bool> Seed()
        {
            await this.biblioteContext.Database.MigrateAsync();
            return true;
        }
        public async Task InsertFirstValues()
        {
            await UserOriginal();
        }
        private async Task UserOriginal()
        {
            await biblioteContext.UserModels.AddAsync(new UserModels 
            {
                Data = DateTime.Now,
                Email = "admin@gmail.com",
                IsValido = true,
                Password = "f6fdffe48c908deb0f4c3bd36c032e72",
                UserName = "Admin",
                GruposModels = new GruposModels               
                {
                    Referencias = "Admin-Default",
                    PermissoesModels = new PermissoesModels 
                    {
                        Referencia = "Admin-Default",
                        AlunoConsultas = true,
                        AutoresConsultas = true,
                        Bibliotecas = true,
                        Estudantes = true,
                        ClasseConsultas = true,
                        EditoraConsultas = true,
                        Leituras = true,
                        LeiturasSolicitacoes = true,
                        LivrosConsultas = true,
                        PaisConsultas = true,
                        Stocks = true,
                        TurmaConsultas = true,
                        StocksRegistar = true,
                        InstituicaoConsultas = true,
                        UsuariosConsultas = true,
                        UsuariosGrupos = true,
                        UsuariosPermissoes = true,
                        Usuarios = true,
                        UsuariosRegistar = true,
                    }
                },
                Logs = new List<LogsModels>
                {
                    new LogsModels
                    { 
                         DateTime = DateTime.Now,
                         Referencia = "Dados iniciais",
                    },
                }
            });
            await this.biblioteContext.SaveChangesAsync();
        }
    }
}
