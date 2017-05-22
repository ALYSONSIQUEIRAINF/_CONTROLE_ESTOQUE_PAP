using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloControleEstoque.Model
{
    [Table("Embalagem")]
    public class Embalagem
    {
        [Key]
        public int EmbalagemId { get; set; }
        public string DescricaoEmbalagem { get; set; }
        public int CodigoEmbalagem { get; set; }
        public int QuantidadeProdutoEmbalagem { get; set; }
        public string TipoEmbalagem { get; set; }
        public List<Produto> ProdutoEmbalagem { get; set; }

        public Embalagem()
        {
           
        }
    }
}
