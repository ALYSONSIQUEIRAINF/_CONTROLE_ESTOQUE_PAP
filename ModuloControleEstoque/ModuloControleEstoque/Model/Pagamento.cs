using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloControleEstoque.Model
{
    [Table("Pagamento")]
    class Pagamento
    {
        [Key]
        public int PagamentoId { get; set; }
        public string NomeCondicaoPagamento { get; set; }
        public string CodigoNegociacaoPagamento { get; set; }
        public string DescricaoCondicaoPagamento { get; set; }
        public double DescontoCondicaoPagamento { get; set; }
        public double AcrescimentoPagamento { get; set; }

        public override string ToString()
        {
            return "\nCondição de Pagamento: " + DescricaoCondicaoPagamento;
        }
    }
}
