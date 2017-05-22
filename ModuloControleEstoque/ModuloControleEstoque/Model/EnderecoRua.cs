using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloControleEstoque.Model
{
    [Table("EnderecoRua")]
    class EnderecoRua
    {
        [Key]
        public int EnderecoRuaId { get; set; }
        public int CodigoRua { get; set; }
        public string DescricaoRua { get; set; }
        public List<EnderecoPredio> EnderecoPredio { get; set; }
        public EnderecoRua()
        {
            EnderecoPredio = new List<EnderecoPredio>();
        }
    }
}
