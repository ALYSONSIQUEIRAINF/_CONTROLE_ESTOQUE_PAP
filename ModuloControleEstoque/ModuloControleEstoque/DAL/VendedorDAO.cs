using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModuloControleEstoque.Model;

namespace ModuloControleEstoque.DAL
{
    class VendedorDAO
    {
        private static Context ctx = Singleton.Instance.Context;

        public static bool AdicionarVendedor(Vendedor vendedor)
        {
            if (ProcurarVendedorPorCPF(vendedor) != null)
            {
                return false;
            }
            else
            {
                try
                {
                    ctx.Vendedores.Add(vendedor);
                    ctx.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }

            }
        }

        public static bool AlterarVendedor(Vendedor vendedor)
        {
            try
            {
                ctx.Entry(vendedor).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public static Vendedor ProcurarVendedorPorCPF(Vendedor vendedor)
        {
            return ctx.Vendedores.FirstOrDefault(x => x.CPF.Equals(vendedor.CPF));
        }

        public static Vendedor ProcurarVendedorPorCPFString(string cpf)
        {
            return ctx.Vendedores.FirstOrDefault(x => x.CPF.Equals(cpf));
        }

        public static List<Vendedor> RetornarLista()
        {
            return ctx.Vendedores.ToList();
        }
    }
}
