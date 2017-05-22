using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModuloControleEstoque.Model;

namespace ModuloControleEstoque.DAL
{
    class VendaDAO
    {

        private static List<Venda> vendas = new List<Venda>();

        private static Context ctx = Singleton.Instance.Context;

        public static bool AdicionarVenda(Venda venda)
        {

            try
            {
                ctx.Vendas.Add(venda);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }



        }

        public static List<Venda> RetornarLista()
        {
            return ctx.Vendas.ToList();
        }

        

        public static List<Venda> BuscarVendasPorCliente(Cliente cliente)
        {

            return ctx.Vendas.Where(x => x.Cliente.CPF.Equals(cliente.CPF)).ToList();

        }
        
    }
}
