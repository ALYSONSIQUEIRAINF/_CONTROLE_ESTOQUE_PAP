using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModuloControleEstoque.Model;

namespace ModuloControleEstoque.DAL
{
    class CategoriaDAO
    {
        private static Context ctx = Singleton.Instance.Context;
        private List<Categoria> categorias = new List<Categoria>();

        public static bool AdicionarCategoriaProduto(Categoria categoria )
        {
            if(ProcurarCategoriaPorNome(categoria) != null)
            {
                return false;
            }
            else
            {
                try
                {
                    ctx.Categoria.Add(categoria);
                    ctx.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public static Categoria ProcurarCategoriaPorNome(Categoria categoria)
        {
            return ctx.Categoria.FirstOrDefault(x => x.DescricaoCategoria.Equals(categoria.DescricaoCategoria));
        }

        public static bool EditaCategoriaProduto(Categoria categoria)
        {
            try
            {
                ctx.Entry(categoria).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public static bool ExcluiCategoriaProduto(Categoria categoria)
        {
            return false;
        }

        public static Categoria BuscarCategoriaPorId(int idCategoria)
        {
            return ctx.Categoria.Find(idCategoria);
        }

        public static List<Categoria> RetornarListaDeCategoria()
        {
            return ctx.Categoria.ToList();
        }
    }
}
