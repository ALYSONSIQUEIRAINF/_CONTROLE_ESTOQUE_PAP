using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ModuloControleEstoque.Model
{
    [Table("Estoques")]
    public class Estoque
    {
        [Key]
        public int EstoqueId { get; set; }
        public int Quantidade { get; set; }
        public Produto Produtos { get; set; }
        public double MargemSeg { get; set; }

        public Estoque()
        {
            Produtos = new Produto();
        }

        public static implicit operator RoutedEventArgs(Estoque v)
        {
            throw new NotImplementedException();
        }
    }
}
