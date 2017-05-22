using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModuloControleEstoque.Model;

namespace ModuloControleEstoque.DAL
{
    class EmbalagemDAO
    {
        public List<Embalagem> Embalagem { get; set; }

        private static Context ctx = Singleton.Instance.Context;

        public static bool CadastrarEmbalagem(Embalagem embalagem)
        {
            if (ProcurarEmbalagemPorDescricao(embalagem) != null)
            {
                return false;
            }
            else
            {
                try
                {
                    ctx.Embalagem.Add(embalagem);
                    ctx.SaveChanges();
                    return true;

                }
                catch (Exception )
                {

                   
                    return false;
                }
            }
        }

        public static Embalagem ProcurarEmbalagemPorDescricao(Embalagem embalagem)
        {
            return ctx.Embalagem.FirstOrDefault(x => x.DescricaoEmbalagem.Equals(embalagem.DescricaoEmbalagem));
        }

        public static List<Embalagem> RetornarListaDeEmbalagem()
        {
            return ctx.Embalagem.ToList();
        }

        public static Embalagem BuscarEmbalagemPorId(int idEmbalagem)
        {
            return ctx.Embalagem.Find(idEmbalagem);
        }
    }
}
