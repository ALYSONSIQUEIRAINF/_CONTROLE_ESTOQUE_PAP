using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloControleEstoque.Model
{
    [Table("EnderecoPredio")]
    class EnderecoPredio
    {
        [Key]
        public int EnderecoPredioId { get; set; }
        public int CodigoPredio { get; set; }
        public string DescricaoPredio { get; set; }
        public List<EnderecoNivel> EnderecoNivel { get; set; }
        public EnderecoPredio()
        {
            EnderecoNivel = new List<EnderecoNivel>();
        }
    }
}
