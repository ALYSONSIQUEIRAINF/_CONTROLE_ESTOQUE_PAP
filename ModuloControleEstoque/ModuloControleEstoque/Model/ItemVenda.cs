using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloControleEstoque.Model
{
    [Table("ItemVenda")]
    class ItemVenda
    {
        [Key]
        public int ItemVendaId { get; set; }
        public int Quantidade { get; set; }
        public int QtdadeEstoque { get; set; }
        public Produto Produto { get; set; }
        public double PrecoUnitario { get; set; }
        public Categoria Categoria { get; set; }
        public Embalagem Embalagem { get; set; }

        public ItemVenda()
        {
            Categoria = new Categoria();
            Embalagem = new Embalagem();
            Produto = new Produto();
        }

    }
}
