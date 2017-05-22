using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModuloControleEstoque.Model;

namespace ModuloControleEstoque.DAL
{
    class ClienteDAO
    {
        private static List<Cliente> clientes = new List<Cliente>();
        private static Context ctx = Singleton.Instance.Context;

        public static bool AdicionarCliente(Cliente cliente)
        {

            if (ProcurarClientePorCPF(cliente) != null)
            {
                return false;
            }
            else
            {
                try
                {
                    ctx.Clientes.Add(cliente);
                    ctx.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
            }
        }
        
        public static Cliente ProcurarClientePorCPF(Cliente cliente)
        {
            return ctx.Clientes.FirstOrDefault(x => x.CPF.Equals(cliente.CPF));
        }

        public static Cliente ProcurarClientePorCPFString(string cpf)
        {
            return ctx.Clientes.FirstOrDefault(x => x.CPF.Equals(cpf));
        }

        public static bool ExluiCliente(Cliente cliente)
        {
            try
            {
                ctx.Clientes.Remove(cliente);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false; ;
            }
        }

        public static bool EditaCliente(Cliente cliente)
        {
            try
            {
                ctx.Entry(cliente).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public static List<Cliente> RetornarLista()
        {

            return ctx.Clientes.ToList();
        }


    }
}
