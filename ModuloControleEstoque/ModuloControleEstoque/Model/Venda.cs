using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloControleEstoque.Model
{
    [Table("Vendas")]
    class Venda
    {
        [Key]
        public int VendaId { get; set; }
        public Cliente Cliente { get; set; }
        public Vendedor Vendedor { get; set; }
        public List<ItemVenda> Produtos { get; set; }
        public DateTime DataDaVenda { get; set; }
        public Pagamento Pagamento { get; set; }
        public Transportadora Transportadora { get; set; }

        public int MyProperty { get; set; }


        public Venda()
        {
            Cliente = new Cliente();
            Vendedor = new Vendedor();
            Produtos = new List<ItemVenda>();
            Pagamento = new Pagamento();
        }
    }
}
