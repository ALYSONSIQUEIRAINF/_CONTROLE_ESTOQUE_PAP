using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModuloControleEstoque.Model;
using ModuloControleEstoque.DAL;
using System.Data.SqlClient;

namespace ModuloControleEstoque.DAL
{
    class ProdutoDAO
    {
        private static List<Produto> produtos = new List<Produto>();

        private static Context ctx = Singleton.Instance.Context;

        public static bool AdicionarProduto(Produto produto)
        {

            if (ProcurarProdutoPorCodigo(produto) != null)
            {
                return false;
            }
            else
            {
                try
                {
                    ctx.Produtos.Add(produto);
                    ctx.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
            }
        }

        public static Produto ProcurarProdutoPorCodigo1(int cod)
        {
            return ctx.Produtos.FirstOrDefault(x => x.CodigoProduto.Equals(cod));
        }

        public static Produto ProcurarProdutoPorCodigo(Produto produto)
        {
            return ctx.Produtos.FirstOrDefault(x => x.CodigoProduto.Equals(produto.CodigoProduto));
        }

        public static Produto BuscarProdutoPorId(int id)
        {
            return ctx.Produtos.Find(id);
        }

        public static List<Produto> RetornarListaDeProduto()
        {
            return ctx.Produtos.ToList();
        }

        public static bool AlteraSaldoEstoqueProduto(Produto produto)
        {
            try
            {
                ctx.Entry(produto).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public static Produto ProcurarEnderecoRua(Produto p)
        {
           return ctx.Produtos.FirstOrDefault(x => x.EnderecoRua.Equals(p.EnderecoRua));
        }
        public static Produto ProcurarEnderecoBloco(Produto p)
        {
            return ctx.Produtos.FirstOrDefault(x => x.EnderecoBloco.Equals(p.EnderecoBloco));
        }
        public static Produto ProcurarEnderecoPratileira(Produto p)
        {
            return ctx.Produtos.FirstOrDefault(x => x.EnderecoPratileira.Equals(p.EnderecoPratileira));
        }

        public static bool CadastrarEnderecoProduto(Produto produto)
        {
            if (ProcurarEnderecoRua(produto) != null &&
                ProcurarEnderecoBloco(produto) != null &&
                ProcurarEnderecoPratileira(produto) != null)
                
            {
                return false;
            }else
            {
                try
                {
                    ctx.Entry(produto).State = System.Data.Entity.EntityState.Modified;
                    ctx.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
            }

            
        }



        public static bool AlteraCadastroProduto(Produto produto)
        {
            try
            {
                ctx.Entry(produto).State = System.Data.Entity.EntityState.Modified;
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
