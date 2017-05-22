using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloControleEstoque.Model
{
    [Table("EnderecoApartamento")]
    class EnderecoApartamento
    {   [Key]
        public int EnderecoApartamentoId { get; set; }
        public int CodigoApartamento { get; set; }
        public string DescricaoApartamento { get; set; }

    }
}
