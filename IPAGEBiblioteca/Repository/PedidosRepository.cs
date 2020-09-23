using IPAGEBiblioteca.Controllers.Helps;
using IPAGEBiblioteca.Models;
using IPAGEBiblioteca.Repository.Helps;
using IPAGEBiblioteca.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IPAGEBiblioteca.Repository
{
    public class PedidosRepository: IPedidoModels
    {
        #region Construtores
        private readonly BiblioteContext biblioteContext;
        public PedidosRepository(BiblioteContext biblioteContext)
        {
            this.biblioteContext = biblioteContext;
        }
        #endregion

        #region Metodos
        public async Task<bool> Delete(PedidosModels Models)
        {
            biblioteContext.PedidosModels.Remove(Models);
            return await Salvar();
        }
        public IQueryable<PedidosModels> GetAll()
        {
            return biblioteContext.PedidosModels;
        }
        public IQueryable<PedidosModels> GetAll(DateTime dateTime1, DateTime dateTime2)
        {
            return biblioteContext.PedidosModels
                                  .Include(x => x.PedidosOrdemModels)
                                  .ThenInclude(x=>x.LivrosModels)
                                  .Include(x => x.AlunoModels)
                                 .Where(x => x.Data >= dateTime1 && x.Data <= dateTime2).AsNoTracking();
        }
        public async Task<bool> Guardar(PedidosModels Models)
        {
            if (Models.ID == 0)
                await this.biblioteContext.PedidosModels.AddAsync(Models);
            else
                this.biblioteContext.PedidosModels.Update(Models);
            return await Salvar();
        }
        private async Task<bool> Salvar()
        {
            return await this.biblioteContext.SaveChangesAsync() > 0 ? true : false;
        }
        private PedidosModels GetSingleInvoice()
        {
            return this.biblioteContext.PedidosModels
                               .OrderByDescending(x => x.ID)
                               .AsNoTracking()
                               .FirstOrDefault();
        }
        public string GetDocument()
        {
            var dici = string.Empty;
            try
            {
                var result = GetSingleInvoice();
                if (result != null)
                {
                    var fatura = result.DocNumero;
                    var tipo = fatura.Split(' ').FirstOrDefault();
                    var serie = fatura.Split(' ').LastOrDefault().Split('/').FirstOrDefault();
                    var numero = fatura.Split('/').LastOrDefault();
                    var numerosomado = Convert.ToInt32(numero) + 1;
                    var minhafatura = tipo + " " + serie + "/" + numerosomado;
                    return minhafatura;
                }
                else
                {
                    var fatura = "DOC" + " " + "ENC" + DateTime.Now.Year + "/" + 1;
                    return fatura;
                }
            }
            catch (Exception exe)
            {
                EscreverLogs.Escrever(null, exe, "Erro na Recriação da sequencia das facturas:");
            }
            return dici;
        }

        public Task<PedidosModels> GetAll(Expression<Func<PedidosModels, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
