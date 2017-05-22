using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModuloControleEstoque.Model;
using ModuloControleEstoque.DAL;

namespace ModuloControleEstoque.DAL
{
    class PagamentoDAO
    {
        private static List<Pagamento> pagamentos = new List<Pagamento>();

        private static Context ctx = Singleton.Instance.Context;

        public static bool AdicionarCondicaoPagamento(Pagamento pagamento)
        {
            if (procurarCondicaoPagamentoPorCodigo(pagamento) != null)
            {
                return false;
            }
            else
            {
                try
                {
                    ctx.Pagamentos.Add(pagamento);
                    ctx.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }


            }
        }

        public static bool AlterarPagamento(Pagamento pagamento)
        {
            try
            {
                ctx.Entry(pagamento).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public static Pagamento procurarCondicaoPagamentoPorCodigo(Pagamento pagamento)
        {
            return ctx.Pagamentos.FirstOrDefault(x => x.CodigoNegociacaoPagamento.Equals(pagamento.CodigoNegociacaoPagamento));
        }

        public static Pagamento procurarCondicaoPagamentoPorId(int id)
        {
            return ctx.Pagamentos.FirstOrDefault(x => x.PagamentoId.Equals(id));
        }

        public static List<Pagamento> retornarListaDePagamento()
        {
            return ctx.Pagamentos.ToList();
        }


    }
}
