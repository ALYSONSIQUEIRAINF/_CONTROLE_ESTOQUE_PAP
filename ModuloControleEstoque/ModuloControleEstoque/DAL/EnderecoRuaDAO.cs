using ModuloControleEstoque.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloControleEstoque.DAL
{
    class EnderecoRuaDAO
    {
        private static List<EnderecoPredio> EnderecoPredios = new List<EnderecoPredio>();
        private static Context ctx = Singleton.Instance.Context;

        public static bool AdicionarEnderecoRua(EnderecoRua rua)
        {
            if(ProcurarEnderecoRua(rua) != null)
            {
                return false;
            }else
            {
                try
                {
                    ctx.EnderecoRua.Add(rua);
                    ctx.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
            }
        }

        public static EnderecoRua ProcurarEnderecoRua(EnderecoRua rua)
        {
            return ctx.EnderecoRua.FirstOrDefault(x => x.CodigoRua.Equals(rua.CodigoRua));
        }
    }
}
