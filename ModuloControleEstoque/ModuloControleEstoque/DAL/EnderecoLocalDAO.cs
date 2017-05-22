using ModuloControleEstoque.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloControleEstoque.DAL
{
    class EnderecoLocalDAO
    {
        private static List<EnderecoRua> EnderecoRuas = new List<EnderecoRua>();
        private static Context ctx = Singleton.Instance.Context;

        public static bool AdicionarEnderecoLocal(EnderecoLocal local)
        {
            if(ProcurarEnderecoLocal(local) != null)
            {
                return false;
            }else
            {
                try
                {
                    ctx.EnderecoLocal.Add(local);
                    ctx.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
            }
        }

        public static EnderecoLocal ProcurarEnderecoLocal(EnderecoLocal local)
        {
            return ctx.EnderecoLocal.FirstOrDefault(x => x.CodigoLocal.Equals(local.CodigoLocal));
        }
    }
}
