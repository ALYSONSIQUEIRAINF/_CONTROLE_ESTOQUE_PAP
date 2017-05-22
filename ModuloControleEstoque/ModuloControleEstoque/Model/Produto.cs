using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModuloControleEstoque.DAL;

namespace ModuloControleEstoque.Model
{
    [Table("Produto")]
    public class Produto
    {
        [Key]
        public int ProdutoId { get; set; }
        public int CodigoProduto { get; set; }
        public string DescricaoProduto { get; set; }
        public double PrecoProduto { get; set; }
        public double PesoBrutoProduto { get; set; }
        public double PesoLiquidoProduto { get; set; }
        public int QuantidadeEstoqueProduto { get; set; }
        public string EnderecoRua { get; set; }
        public string EnderecoBloco { get; set; }
        public string EnderecoPratileira { get; set; }
        public Embalagem EmbalagemProduto { get; set; }
        public Categoria CategoriaProduto { get; set; }


        public Produto()
        {
            EmbalagemProduto = new Embalagem();
            CategoriaProduto = new Categoria();
        }

        public override string ToString()
        {
            return "\nNome: " + DescricaoProduto + " Preço: " + PrecoProduto;
        }
    }
}

