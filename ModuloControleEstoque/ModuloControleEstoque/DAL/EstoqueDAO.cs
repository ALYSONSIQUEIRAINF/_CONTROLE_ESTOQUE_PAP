using ModuloControleEstoque.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ModuloControleEstoque.DAL
{
    class EstoqueDAO
    {
        private static List<Estoque> estoques = new List<Estoque>();
        private static Context ctx = Singleton.Instance.Context;

        public static bool AdicionarEstoque(Estoque produto)
        {
            try
            {
                ctx.Estoque.Add(produto);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public static Estoque ProcurarEstoque(int id)
        {
            return ctx.Estoque.FirstOrDefault(x => x.Produtos.ProdutoId.Equals(id));
        }

        public static Estoque ProcurarEstoque1(int id)
        {
            return ctx.Estoque.FirstOrDefault(x => x.Produtos.ProdutoId.Equals(id));
        }

        public static Estoque ProcurarEstoque2(int codigo)
        {
            return ctx.Estoque.FirstOrDefault(x => x.Produtos.CodigoProduto.Equals(codigo));
        }

        public static List<Estoque> RetornarLista()
        {

            return ctx.Estoque.ToList();
        }

        public static bool AlterarProdutoEstoque(Estoque estoque)
        {
            try
            {
                ctx.Entry(estoque).State = System.Data.Entity.EntityState.Modified;
                //ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        
        public static bool AlterarEstoque(Estoque estoque)
        {
            try
            {
                ctx.Entry(estoque).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        
        public static bool RemoverEstoque(Estoque estoque)
        {
            try
            {
                ctx.Estoque.Remove(estoque);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        
    }
}
